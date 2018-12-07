using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Utilities;
using POM.Classes;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace BlueGreenOwner.TestCases
{
    public class MyLoanInformation : LoginMethod
    { 
       
        public static void ValidateOwnersLoanSortedByEarliestMaturityDate(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

               ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu, regardless if they are active or inactive");

                int count = myLoanObj.LoanDropDownValues.Count;
               


                List<String> loanItems = myLoanObj.GetLoanNumber(driver,  count);

                List<String> MaturityDateItems = myLoanObj.GetMatuaritytyDate(driver, count);

                
                Assert.IsTrue(loanItems.Exists(x => x.Contains(Constants.LoanType)), "Loan number dropdown doesnot contain Inactive loan");
                extentTest.Pass("Loan number dropdown contains Inactive loan", AttachScrenshot(driver, testContext, "AllLoansDisplayed").Build());


                // validating if Active loans are displayed on top followed by Inactive loans
                for (int j = 0; j < count; j++)
                {

                    if (loanItems[j].Contains(Constants.LoanType))
                    {
                       
                            Assert.IsTrue(!loanItems[j - 1].ToString().Contains(Constants.LoanType), "Active loans are not displayed on top followed");
                            extentTest.Pass("Active loans are displayed on top followed by Inactive loans", AttachScrenshot(driver, testContext, "ActiveLoansDisplayedOnTop").Build());
                        

                    }

                }


                //Validating if Active loans are sorted by maturity date with the earliest maturity date appearing first
                for (int k = 0; k < count; k++)
                {
                    if (!loanItems[k].Contains(Constants.LoanType) && !loanItems[k+1].Contains(Constants.LoanType))
                    {
                        Assert.IsTrue(DateTime.Parse(MaturityDateItems[k]) < (DateTime.Parse(MaturityDateItems[k+1])), "Active loans are not sorted by recent maturity date");
                        extentTest.Info("Active loans are sorted by recent maturity date");
                    }

                    else
                    {
                        extentTest.Info("There is only one Active loan or This is the last Active loan in the dropdown which cannot be compared by maturity date ");
                    }
                }

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }

                
            }


        }


        public static void ValidateUpdateBorrowerInformationAndUpdateAutomaticPaymentLink(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

               ClickButton(myLoanObj.LoanDropDown, driver);
               extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu, regardless if they are active or inactive");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver,  count);
              
                // validating Update Borrower information link redirects to borrower information page and Update automatic payment link redirects to manage auto - pay page
                int j = 0;


                while (j < count && !loanItems[j].Contains(Constants.LoanType))
                {

                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");

                    myLoanObj.LoanDropDownValues[j].Click();
                    extentTest.Info("Active loan " + loanItems[j] + " is clicked");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforUpdateBorrowerInformationLink, driver), "Update Borrower Information Link is not displayed for active loan " + loanItems[j]);
                    extentTest.Pass("Update Borrower Information Link is displayed for active loan " + loanItems[j], AttachScrenshot(driver, testContext, "UpdateBorrowerInfoLinkDisplayed").Build());

                    Assert.IsTrue(IsButtonEnabled(myLoanObj.UpdateBorrowerInformationLink, driver), "Update Borrower Information Link is disabled for" + loanItems[j]);
                    extentTest.Info("Update Borrower Information Link is enabled for" + loanItems[j]);

                    ClickLink(myLoanObj.UpdateBorrowerInformationLink, driver);
                    extentTest.Info("Update Borrower Information Link is clicked for active loan" + loanItems[j]);

                    Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforBorrowerInformationPage, driver), "Borrower Information page is not displayed for active loan" + loanItems[j]);
                    extentTest.Pass("Borrower Information page is displayed for active loan" + loanItems[j], AttachScrenshot(driver, testContext, "BorrowerInformationPgDisplayed").Build());

                    driver.Navigate().Back();
                    extentTest.Info("Navigating back to My loan information page");

                    Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                    extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPgDisplayed").Build());

                    Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforUpdateAutomaticPaymentLink, driver), "Update automatic payment Link is not displayed for active loan " + loanItems[j]);
                    extentTest.Pass("Update automatic payment Link is displayed for active loan " + loanItems[j], AttachScrenshot(driver, testContext, "UpdateAutomaticPaymentLinkDisplayed").Build());

                    Assert.IsTrue(IsButtonEnabled(myLoanObj.UpdateAutomaticPaymentLink, driver), "Update automatic payment Link is disabled");
                    extentTest.Info("Update automatic payment Link is enabled");

                    ClickLink(myLoanObj.UpdateAutomaticPaymentLink, driver);
                    extentTest.Info("Update automatic payment Link is clicked for active loan" + loanItems[j]);

                    Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforManageAutoPayPage, driver), "Manage Auto Pay page is not displayed for active loan" + loanItems[j]);
                    extentTest.Pass("Manage auto pay page is displayed for active loan" + loanItems[j], AttachScrenshot(driver, testContext, "ManageAutoPayPageDisplayed").Build());

                    driver.Navigate().Back();
                    extentTest.Info("Navigating back to My loan information page");

                    j++;


                }

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
               
            }


        }



        public static void ValidateUpdateBorrowerInformationAndUpdateAutomaticPaymentLink_InactiveLoan(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver, count);

                
                
                //Validating Update Borrower information link and Update automatic payment link doesn’t display for Inactive loans

                for (int k = 0; k < count; k++)
                {
                    if (loanItems[k].Contains(Constants.LoanType))
                    {
                        ClickButton(myLoanObj.LoanDropDown, driver);
                        extentTest.Info("Loan number drop down is clicked");

                        myLoanObj.LoanDropDownValues[k].Click();
                        extentTest.Info("Inactive loan " + loanItems[k] + " is clicked");

                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                        Assert.IsTrue(IsElementInvisible(myLoanObj.LocatorforUpdateBorrowerInformationLink, driver), "Update Borrower Information Link is displayed for Inactive loan " + loanItems[k]);
                        extentTest.Pass("Update Borrower Information Link should not display for Inactive loan " + loanItems[k], AttachScrenshot(driver, testContext, "UpdateBorrowerInfoLinkNotDisplayed").Build());

                        Assert.IsTrue(IsElementInvisible(myLoanObj.LocatorforUpdateAutomaticPaymentLink, driver), "Update automatic payment Link is displayed for Inactive loan " + loanItems[k]);
                        extentTest.Pass("Update automatic payment Link should not display for Inactive loan " + loanItems[k], AttachScrenshot(driver, testContext, "UpdateAutomaticPaymentLinkNotDisplayed").Build());

                    }
                }


                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
                

            }


        }



        public static void ValidateLoanDetailsAndNextPaymentDetails(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu, regardless if they are active or inactive");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver, count);
                //Getting the hidden elements of dropdown list

               // Businesslogic.GetHiddenElementsFromDropDown(driver, loanItems, count);

                List<By> loanInfoPgObjests = new List<By>() { myLoanObj.LocatorforLoanDetails_Table,myLoanObj.LocatorforOriginalLoanAmount,myLoanObj.LocatorforPrincipalBalance,
                myLoanObj.LocatorforMaturityDate_Row,myLoanObj.LocatorforInterstPaidInYear,myLoanObj.LocatorforNextPaymentDetails_Table,myLoanObj.LocatorforDueDate,
                myLoanObj.LocatorforTotalPayment };

                List<String> fieldName = new List<String>() { "Loan Details_Table","Original Loan Amount","Principal Balance","Maturity Date","Interst Paid In <Year>",
                "Next Payment Details_Table","Due Date","Total Payment"};


                //Validating loan details and next payment details displays for each loan selected

                for (int k = 0; k < count; k++)
                {
                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");

                    myLoanObj.LoanDropDownValues[k].Click();
                    extentTest.Info(loanItems[k] + " is selected");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    Businesslogic.IsAllFieldsPresent(testContext, fieldName, loanInfoPgObjests, driver, myLoanObj.MyLoanInformationPg.Text);


                }


                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }

               
            }


        }



        public static void ValidatePageNavigationsOnMyLoanInformationPage(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu, regardless if they are active or inactive");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver, count);
                
                List<By> loanInfoPgObjests = new List<By>() { myLoanObj.LocatorforDownloadTaxDocumentBtn, myLoanObj.LocatorforRequestPayOffQuoteBtn, myLoanObj.LocatorforMakeAPaymentBtn_MyLoanInfoPage };

                List<String> fieldName = new List<String>() { "Download Tax Document Button", "Request Pay Off Quote button", "Make A Payment Button" };

                
                //Validating page navigation of my loan information page

                for (int k = 0; k < count; k++)
                {
                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");

                    myLoanObj.LoanDropDownValues[k].Click();
                    extentTest.Info(loanItems[k] + " is selected");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    if (!loanItems[k].Contains(Constants.LoanType))
                    {
                        Businesslogic.IsAllFieldsPresent(testContext, fieldName, loanInfoPgObjests, driver, myLoanObj.MyLoanInformationPg.Text);

                        JavascriptClickElement(myLoanObj.DownloadTaxDocumentBtn, driver);
                        extentTest.Info("Download Tax Document Button is clicked for " + loanItems[k]);

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforTaxFormsPage, driver), "Tax forms page is not displayed for " + loanItems[k]);
                        extentTest.Pass("Tax forms page is displayed for" + loanItems[k], AttachScrenshot(driver, testContext, "TaxFormsPageDisplayed").Build());

                        driver.Navigate().Back();

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed on navigating back");
                        extentTest.Pass("My loan information page is displayed on navigating back", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                        JavascriptClickElement(myLoanObj.RequestPayOffQuoteBtn, driver);
                        extentTest.Info("Request Pay Off Quote button is clicked for " + loanItems[k]);

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforRequestPayOffQuotePage, driver), "Request Pay Off Quote page is not displayed for " + loanItems[k]);
                        extentTest.Pass("Request Pay Off Quote page is displayed for " + loanItems[k], AttachScrenshot(driver, testContext, "RequestPayOffQuotePageDisplayed").Build());

                        String loanNumber_RequestPayOff = myLoanObj.LoanNo_RequestPayOffPage.Text;

                        Assert.IsTrue(loanNumber_RequestPayOff.Contains(loanItems[k]), "Selected Loan number :" + loanItems[k] + " is not prepopulated in the request a payoff quote page dropdown");
                        extentTest.Info("Selected Loan number : " + loanItems[k] + " is prepopulated in the request a payoff quote page dropdown");

                        driver.Navigate().Back();

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed on navigating back");
                        extentTest.Pass("My loan information page is displayed on navigating back", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                        JavascriptClickElement(myLoanObj.MakeAPaymentBtn_MyLoanInfoPage, driver);
                        extentTest.Info("Make A Payment button is clicked for " + loanItems[k]);

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMakeAPaymentPage_LoanPayment, driver), "Make A Payment page is not displayed for " + loanItems[k]);
                        extentTest.Pass("Make A Payment page is displayed for " + loanItems[k], AttachScrenshot(driver, testContext, "MakeAPaymentPageDisplayed").Build());

                        String loanNumber = myLoanObj.LoanNo_MakeAPaymentPage.Text.Substring(13, 6);

                        Assert.IsTrue(loanItems[k].Contains(loanNumber), "Selected Loan number :" + loanItems[k] + " is not displayed in Make A Payment page");
                        extentTest.Info("Selected Loan number : " + loanItems[k] + " is displayed in Make A Payment page");

                        driver.Navigate().Back();

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed on navigating back");
                        extentTest.Pass("My loan information page is displayed on navigating back", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());
                    }

                    else
                    {
                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforDownloadTaxDocumentBtn, driver), "Download Tax Document button is not displayed for " + loanItems[k]);
                        extentTest.Pass("Download Tax Document button is displayed for " + loanItems[k], AttachScrenshot(driver, testContext, "DownloadTaxDocumentBtnDisplayed").Build());

                        JavascriptClickElement(myLoanObj.DownloadTaxDocumentBtn, driver);
                        extentTest.Info("Download Tax Document Button is clicked for " + loanItems[k]);

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforTaxFormsPage, driver), "Tax forms page is not displayed for " + loanItems[k]);
                        extentTest.Pass("Tax forms page is displayed for" + loanItems[k], AttachScrenshot(driver, testContext, "TaxFormsPageDisplayed").Build());

                        driver.Navigate().Back();

                        Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed on navigating back");
                        extentTest.Pass("My loan information page is displayed on navigating back", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                        Assert.IsTrue(IsElementInvisible(myLoanObj.LocatorforRequestPayOffQuoteBtn, driver), "Request pay off quote button is displayed for Inactive loan _" + loanItems[k]);
                        extentTest.Info("Request pay off quote button should not display for Inactive loan _ " + loanItems[k]);

                        Assert.IsTrue(IsElementInvisible(myLoanObj.LocatorforMakeAPaymentBtn_MyLoanInfoPage, driver), "Make a payment button is displayed for Inactive loan_" + loanItems[k]);
                        extentTest.Info("Make a payment button should not display for Inactive loan _" + loanItems[k]);
                        

                    }

                }


                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
                
            }


        }


        public static void ValidateDataInTransactionHistoryTable_MultipleActiveLoan(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver, count);
                
                //Validating Data in transaction History table for each loan selected

                for (int k = 0; k < count; k++)
                {
                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");

                    myLoanObj.LoanDropDownValues[k].Click();
                    extentTest.Info(loanItems[k] + " is selected");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    ClickButton(myLoanObj.LocatorforTransactionHistoryLink, driver);
                    extentTest.Info("Transaction History Link is clicked");

                    List<By> transactionObjests = new List<By>() { myLoanObj.LocatorforTransactionHistoryTable,myLoanObj.LocatorforDescription,myLoanObj.LocatorforRecieved,
                    myLoanObj.LocaxtorforEffective,myLoanObj.LocatorforTotalAmount};

                    List<String> fieldName = new List<String>() { "Transaction table","Description column","Recieved column",
                   "Effective column","Total amount column"};

                    List<By> columnObjests = new List<By>() { myLoanObj.LocatorforDescriptionColumn_Values,myLoanObj.LocatorforRecievedColumn_Values,
                   myLoanObj.LocatorforEffectiveColumn_Values,myLoanObj.LocatorforTotalAmountColumn_Values};

                    List<String> columnValues = new List<String>() { "Description column values","Recieved column values",
                   "Effective column values","Total amount column values"};

                    Businesslogic.IsAllFieldsPresent(testContext, fieldName, transactionObjests, driver, myLoanObj.MyLoanInformationPg.Text);

                    if (myLoanObj.ViewAllLink.Displayed)
                    {
                        ClickLink(myLoanObj.ViewAllLink, driver);
                        extentTest.Info("View all link is clicked");

                        Businesslogic.IsAllColumnValuesPresent(testContext, columnValues, columnObjests, driver, myLoanObj.MyLoanInformationPg.Text);
                    }

                    else
                    {
                        Businesslogic.IsAllColumnValuesPresent(testContext, columnValues, columnObjests, driver, myLoanObj.MyLoanInformationPg.Text);

                    }

                }
                
                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
                

            }


        }



        public static void ValidateDataInTransactionHistoryTable_InactiveLoan(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu");

                int count = myLoanObj.LoanDropDownValues.Count;

                List<String> loanItems = myLoanObj.GetLoanNumber(driver, count);
                
                //Validating Data in transaction History table for each loan selected

                for (int k = 0; k < count; k++)
                {
                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");

                    myLoanObj.LoanDropDownValues[k].Click();
                    extentTest.Info(loanItems[k] + " is selected");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    ClickButton(myLoanObj.LocatorforTransactionHistoryLink, driver);
                    extentTest.Info("Transaction History Link is clicked");

                    List<By> transactionObjests = new List<By>() { myLoanObj.LocatorforTransactionHistoryTable,myLoanObj.LocatorforDescription,myLoanObj.LocatorforRecieved,
                    myLoanObj.LocaxtorforEffective,myLoanObj.LocatorforTotalAmount};

                    List<String> fieldName = new List<String>() { "Transaction table","Description column","Recieved column",
                   "Effective column","Total amount column"};

                    List<By> columnObjests = new List<By>() { myLoanObj.LocatorforDescriptionColumn_Values,myLoanObj.LocatorforRecievedColumn_Values,
                   myLoanObj.LocatorforEffectiveColumn_Values,myLoanObj.LocatorforTotalAmountColumn_Values};

                    List<String> columnValues = new List<String>() { "Description column values","Recieved column values",
                   "Effective column values","Total amount column values"};

                    Businesslogic.IsAllFieldsPresent(testContext, fieldName, transactionObjests, driver, myLoanObj.MyLoanInformationPg.Text);

                    if (myLoanObj.ViewAllLink.Displayed)
                    {
                        ClickLink(myLoanObj.ViewAllLink, driver);
                        extentTest.Info("View all link is clicked");

                        Businesslogic.IsAllColumnValuesPresent(testContext, columnValues, columnObjests, driver, myLoanObj.MyLoanInformationPg.Text);
                    }

                    else
                    {
                        Businesslogic.IsAllColumnValuesPresent(testContext, columnValues, columnObjests, driver, myLoanObj.MyLoanInformationPg.Text);

                    }

                }

                

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
                

            }


        }



        public static void ValidateMortgageMakeAPaymentPageAndWesternUnionSpeedpayPage(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.LoanDropDown, driver);
                extentTest.Info("Loan number drop down is clicked");

                Assert.IsTrue(IsAllElementsVisible(myLoanObj.LocatorforLoanDropDownValues, driver), "Owner's loans did not display in the drop down menu");
                extentTest.Info("Owner's loans are displayed in the drop down menu");

                Assert.IsTrue(!myLoanObj.LoanNo.Text.Contains(Constants.LoanType), "Active loan is not displayed in select a loan dropdown");
                extentTest.Pass("Active loan is displayed in select a loan dropdown", AttachScrenshot(driver, testContext, "ActiveLoanDisplayed").Build());
               
                JavascriptClickElement(myLoanObj.MakeAPaymentBtn_MyLoanInfoPage, driver);
                extentTest.Info("Make A Payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMakeAPaymentPage_LoanPayment, driver), "Make A Payment page is not displayed ");
                extentTest.Pass("Make A Payment page is displayed", AttachScrenshot(driver, testContext, "MakeAPaymentPageDisplayed").Build());

               //This validation does not hold good for stgint
                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["MakeAPaymentPage_LoanPayment"]), "Make A Payment button does not redirect to new sitecore Make a payment page_loan payment");
                //extentTest.Pass("Make A Payment button redirects to new sitecore Make a payment page_loan payment " , AttachScrenshot(driver, testContext, "MakeAPaymentButtonWorks").Build());

                String tagName= myLoanObj.LoanNoHyperLink_MakeAPaymentPage.TagName;

                Assert.IsTrue(tagName.Equals("a"), "Loan number in the blue box is not a hyperlink_make a payment page");
                extentTest.Info("Loan number in the blue box is a hyperlink_make a payment page");

                Assert.IsTrue(IsElementPresentUsingBy(myLoanObj.LocatorforNeedAssistance_MakeALoanPayment,driver), "Need assistance section is not displayed on make a payment page_loan payment ");
                extentTest.Pass("Need assistance section is displayed on make a payment page_loan payment  ", AttachScrenshot(driver, testContext, "NeedAssistanceDisplayed").Build());

                Assert.IsTrue(IsElementPresentUsingBy(myLoanObj.LocatorforPoweredBy_MakeALoanPayment, driver), "Powered by section is not displayed on make a payment page_loan payment ");
                extentTest.Info("Powered by section is displayed on make a payment page_loan payment");

                Assert.IsTrue(IsElementPresentUsingBy(myLoanObj.LocatorforWesternUnionLogo, driver), "Western Union SpeedPay logo is not displayed on make a payment page_loan payment ");
                extentTest.Info("Western Union SpeedPay logo is displayed on make a payment page_loan payment");

                String parentWindow=driver.CurrentWindowHandle;

                ClickLink(myLoanObj.MakeALoanPaymentBtn, driver);
                extentTest.Info("Make a loan payment button is clicked");

                Thread.Sleep(8000);
                
                IList<String >allWindowHanles= driver.WindowHandles;

                Assert.IsTrue(allWindowHanles.Count>1, "Western Union payment services page is not opened in new tab");
                extentTest.Info("Western Union payment services page is opened in new tab");

                SwitchTochildWindow(driver, 1);
                extentTest.Info("switched to child window");
                try
                {
                    Assert.IsTrue(driver.Url.ToLower().Contains(ConfigurationManager.AppSettings["WesternUnionPaymentServices"].ToLower()), "Western Union payment services page is not displayed ");
                    extentTest.Pass("Western Union payment services page is displayed  ", AttachScrenshot(driver, testContext, "WesternUnionPgDisplayesd").Build());
                }
                catch(Exception exception)
                {
                    if(exception !=null)
                    {
                        extentTest.Error("Error occured on Child window , switching back to parent window");
                        SwitchToParentWindow(driver);
                        Assert.Fail(exception.Message);
                        
                    }

                }
                //List<By> speedpayObj = new List<By>() { myLoanObj.LocatorforAccountNumberField_WesternUnionSpeedpayPage,myLoanObj.LocatorforAccountNumberTxtBox_WesternUnionSpeedpayPage,myLoanObj.LocatorforZipcodeField_WesternUnionSpeedpayPage,myLoanObj.LocatorforZipcodeTextBox_WesternUnionSpeedpayPage};

                //List<String> fieldName = new List<String> { " Loan number field", "Loan number text box", "Zipcode field", "Zipcode text box" };

                //Businesslogic.IsAllFieldsPresent(testContext, fieldName, speedpayObj, driver, Constants.WesternUnionSpeedpayPage);

                SwitchToParentWindow(driver);
                extentTest.Info("switched to parent window");

                ClickLink(myLoanObj.LocatorforGoBackLink,driver);
                extentTest.Info("Go back link is clicked");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed on clicking Go back link");
                extentTest.Pass("My loan information page is displayed on clicking Go back link", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }


               
            }


        }


        public static void ValidateRequestPayOffPage(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            RequestPayOffPage pageObj = new RequestPayOffPage(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMyLoanInformationPg, driver), "My loan information page is not displayed");
                extentTest.Pass("My loan information page is displayed", AttachScrenshot(driver, testContext, "MyLoanInformationPageDisplayed").Build());

                ClickButton(myLoanObj.RequestPayOffQuoteBtn, driver);
                extentTest.Info("Request pay off button is clicked");
                
                Assert.IsTrue(IsElementPresentUsingBy(pageObj.locatorforrequestpayOffPage, driver), "Request PayOff page was not displayed ");
                extentTest.Pass("Request PayOff page was displayed  ", AttachScrenshot(driver, testContext, "RequestPayOffPageDisplayed").Build());

                List<IWebElement> requestPayOffObj = new List<IWebElement>() {pageObj.emailRadioButton,pageObj.faxRadioButton,pageObj.USmailRadioButton,pageObj.emailTextbox,pageObj.RequestPayOffBtn[0]};

                List<String> fieldName = new List<String>() {"Eamil radio button","Fax radio button","US mail radio button", "Email address text box","Request pay off button"};
                
                Businesslogic.IsAllFieldsPresent(testContext, fieldName, requestPayOffObj, driver, myLoanObj.RequestPayOffQuotePage.Text);

                ClickButton(pageObj.USmailRadioButton,driver);
                extentTest.Info("US mail radio button is selected");

                Assert.IsTrue(IsElementInvisible(pageObj.locatorforemailTextbox, driver), "Email address text field was displayed on selecting US mail radio button ");
                extentTest.Pass("Email address text field was not displayed on selecting US mail radio button ", AttachScrenshot(driver, testContext, "emailAddressTxtBoxNotShown").Build());
                
                Assert.IsTrue(IsElementPresentUsingBy(pageObj.locatorforAlertMsg, driver), "alert message was not displayed ");
                extentTest.Pass("Alert message was displayed ", AttachScrenshot(driver, testContext, "emailAddressTxtBoxNotShown").Build());
                
                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }


            }


        }



        public static void ViewErrorMessageLastNameonLoanNotMatchingLSAMS(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            RequestPayOffPage pageObj = new RequestPayOffPage(driver);
            try
            {

                List<IWebElement> menuElements = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.MyLoanInformationMenu };

                List<By> menuObjests = new List<By>() { allMenusObj.locatorforMyBlueGreen, myLoanObj.LocatorforMyLoanInformationMenu };

                MenuLevel1(menuObjests, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(myLoanObj.LocatorforMortgageSecurityPg, driver), "Mortgage security page is not displayed");
                extentTest.Pass("Mortgage security page is displayed", AttachScrenshot(driver, testContext, "MortgageSecurityPgShown").Build());

                TypeInTextBox(myLoanObj.LastNameOnLoanTxtBox,driver,Constants.LastName);
                extentTest.Info("Invalid Last name on loan is entered");

                ClickButton(myLoanObj.ConfirmMyMortgageLoanBtn,driver);
                extentTest.Info("Confirm my mortgage loan button is clicked");
                
                Assert.IsTrue(IsElementPresent(myLoanObj.locatorforErrorMessage_MortgageSecurityPage, driver), "Error message is not displayed when Last Name on Loan doesnot Match with that on LSAMS ");
                extentTest.Pass("Error message is displayed when Last Name on Loan doesnot Match with that on LSAMS ", AttachScrenshot(driver, testContext, "ErrorMessageDisplayed").Build());

                String ErrorMsg=  myLoanObj.ErrorMessage_MortgageSecurityPage.Text;

                extentTest.Info("Error message displayed was..."+ ErrorMsg);

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }


            }


        }

        

    }

}


