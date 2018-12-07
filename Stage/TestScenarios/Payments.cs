using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Utilities;
using OpenQA.Selenium.Interactions;
using POM.Classes;
using System.Linq;

namespace BlueGreenOwner.TestCases
{
    
    public class Payment : LoginMethod
    {

        public static void ValidateBGOBlocksPayment(string userName, TestContext testContextInstance)
        {

            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            LoginPage loginPageObj = new LoginPage(driver);

            try
            {

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "MaintenanceFees" };

                MenuLevel1(ListOfMenuobjects, driver);

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URLForMaintenancefeeHistorypage"]), "The Maintenance fee History  page was not  displayed");
                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), " Maintenance fee History  page was not  displayed");
                extentTest.Pass("Maintenance fee History page was  displayed", AttachScrenshot(driver, testContextInstance, "MaintenaceHistoryDisplayed").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.locatorforweApologiseMsg, driver), "This account does not qualify for online payments message was not displayed in BGO Make A Payment page");
                extentTest.Pass("This account does not qualify for online payments message  was displayed in BGO Make a Payment Page", AttachScrenshot(driver, testContextInstance, "AlertMessgaeDisplayed").Build());

                VSSAHomePage vssaObj = new VSSAHomePage(driver);

                driver.Url = ConfigurationManager.AppSettings["UrlForVSSAHomePage"];
                Assert.IsTrue(IsElementPresentUsingBy(vssaObj.locatorForArvactnumber, driver), "In VSSA Search results showing Arvact details was not  displayed");
                Assert.IsTrue(TestBaseClass.SearchVssaByArvact(vssaObj, userName), "In VSSA ,Search results showing Arvact details was not  displayed");
                extentTest.Pass("Search results showing Arvact details was  displayed", AttachScrenshot(driver, testContextInstance, "SearchResultDisplayed").Build());


                Assert.IsTrue(IsElementPresent(vssaObj.locatorForMsgGoodStanding, driver), "The User Not In Good Standing  message was not  displayed in VSSA");
                extentTest.Pass("User Not In Good Standing  message was displayed in VSSA", AttachScrenshot(driver, testContextInstance, "UserNotInGoodStandingMessgaeDisplayed").Build());


            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            
        }



        public static void ValidateNoStatementsAvailable(string userName, TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "MaintenanceFees" };

                MenuLevel1(ListOfMenuobjects, driver);
                extentTest.Info("Traverse is successful");

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), " Maintenance fee History  page is  not  displayed");
                extentTest.Pass("Maintenance fee History page is   displayed", AttachScrenshot(driver, testContextInstance, "MaintenaceHistoryDisplayed").Build());

                paymentObj.viewTransactionBtn.Click();
                extentTest.Info("View transactions button is clicked");

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMyMaintenaceFeeTransactionPage, driver), "my  maintenance fees transactions  page is  not  displayed");
                extentTest.Pass("my  maintenance fees transactions page is  displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesTransactionsPageDisplayed").Build());

                ClickLink(paymentObj.StatementHistoryLink, driver);
                extentTest.Info("Statement History Link is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorfornoStatementsAvailable, driver), "On selecting Statement History_No statementsAvailable_ is  not displayed");
                extentTest.Pass("On selecting Statement History_No statementsAvailable_ is  displayed", AttachScrenshot(driver, testContextInstance, "AlertMessageDisplayed").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            
        }


        //Verify my maintenanace fees and club dues page for different types of owner: IP/IS/ID

        public static void ValidateMaintenancefeesPage_IPeligible(TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {
                List<By> ListOfMenuLocators1 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };
                List<IWebElement> ListOfMenuobjects1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };
                List<String> ListOfMenuNames1 = new List<String>() { "My BlueGreen", "MaintenanceFees" };

                MenuLevel1(ListOfMenuobjects1, driver);

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), " Maintenance fee History  page was not  displayed");
                extentTest.Pass("The Maintenance fee History page is  displayed", AttachScrenshot(driver, testContextInstance, "MaintenaceHistoryDisplayed").Build());

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMakeAPaymentBtn, driver), "make a payment button is not displayed for IP owner");
                extentTest.Pass("make a payment button is displayed for IP owner", AttachScrenshot(driver, testContextInstance, "MakeApaymentButtonShouldNotDisplayForIPowner").Build());


                if (paymentObj.makeAPaymentBtn.Enabled)
                {
                    ClickButton(paymentObj.makeAPaymentBtn, driver);
                    // Assert.Fail();
                }

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMakeAPaymentPage, driver), "make a payment page is not displayed for IP owner");
                extentTest.Pass("make a payment page is displayed for IP owner", AttachScrenshot(driver, testContextInstance, "MakeApaymentPageShouldNotDisplayforIPowner").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            
        }

        public static void ValidateMaintenancefeesPage_IPowner(TestContext testContextInstance)
        {

            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {

                List<By> ListOfMenuLocators1 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };
                List<IWebElement> ListOfMenuobjects1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };
                List<String> ListOfMenuNames1 = new List<String>() { "My BlueGreen", "MaintenanceFees" };

                MenuLevel1(ListOfMenuobjects1, driver);

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), " my maintenance fees and club dues page is not  displayed");
                extentTest.Pass("my maintenance fees and club dues page is  displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenaceFeesPageDisplayed").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.locatorForViewInstallmentPlanBtn, driver), "View installment plan button is not displayed for IP owner");
                extentTest.Pass("View installment plan button is displayed for IP owner", AttachScrenshot(driver, testContextInstance, "ViewInstallmentButtonDisplayed").Build());

                ClickButton(paymentObj.locatorForViewInstallmentPlanBtn, driver);
                extentTest.Info("View installment plan button is clicked");

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforInstallmentPlanPage, driver), "Installment Plan page is not displayed for IP owner");
                extentTest.Pass("Installment Plan page is displayed for IP owner", AttachScrenshot(driver, testContextInstance, "InstallmentPlanPageDisplayed").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.locatorforInstallmentGrid, driver), "Installment grid is not displayed for IP owner");
                extentTest.Pass("Installment grid is displayed for IP owner", AttachScrenshot(driver, testContextInstance, "InstallmentGridDisplayed").Build());

                Assert.IsTrue(IsAllElementsPresent(paymentObj.locatorforAmountInGrid, driver), "Amount details is not displayed");
                extentTest.Pass("Amount details is displayed", AttachScrenshot(driver, testContextInstance, "AmountDisplayed").Build());

                String[] amount = new String[paymentObj.AmountInGrid.Count];
                int i = 0;
                double sum = 0.00;
                foreach (IWebElement obj in paymentObj.AmountInGrid)
                {
                    amount[i] = obj.Text.TrimStart('$');
                    sum = sum + double.Parse(amount[i]);
                    i++;
                }

                extentTest.Info("Sum of amount in installment grid=" + sum);

                extentTest.Info("Total Payment Authorised displayed under summary=" + double.Parse(paymentObj.TotalAmountUnderSummary.Text.TrimStart('$')));

                Assert.IsTrue(sum.Equals(double.Parse(paymentObj.TotalAmountUnderSummary.Text.TrimStart('$'))), "Sum of amount in Installment grid is not equal to Total Payment Authorized under Summary");
                extentTest.Pass("Sum of amount in Installment grid is equal to Total Payment Authorized under Summary", AttachScrenshot(driver, testContextInstance, "SumOfAmountEqualToTotalPaymentAuthorised").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }

        }

        public static void ValidateAlertMessageOnHomePageFor_IPownerWhosePaymentDidnotProcess(TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {
                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforalertMsgForIPowner, driver), "Alert message_Your paymnet did not process successfully_ is not displayed for IP owner on Homepage");
                extentTest.Pass("Alert message is displayed on Homepage for IP owner whose installment payment didn't process successfully", AttachScrenshot(driver, testContextInstance, "AlertMessgaeDisplayedForIPowner").Build());

                Assert.IsTrue(IsElementPresent(topMenuobj.locatorforUpdateInfoLaterBtn, driver), "Update Information Later-Button is not  displayed");
                extentTest.Pass("Update Information Later-Button  is  displayed", AttachScrenshot(driver, testContextInstance, "UpdateInformationLaterButtonDisplayed").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }



        }



        public static void ValidateAlertMessageForISownerOnBGOhomepage(TestContext testContextInstance)
        {
           
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);


            try
            {

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforalertMsgForISowner, driver), "Alert message is not  displayed for IS owner on Homepage");
                extentTest.Pass("Alert message is displayed for IS owner on Homepage", AttachScrenshot(driver, testContextInstance, "AlertMessgaeDisplayedForISowner").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.DueDateForISowner), "Due date is not displayed for IS owner in alert message");
                extentTest.Pass("Due date is displayed for IS owner in alert message", AttachScrenshot(driver, testContextInstance, "DueDateDisplayedForISowner").Build());

                String dueDate = DateTime.Parse(paymentObj.DueDateForISowner.Text.Trim()).ToString("M/dd/yyyy");
                extentTest.Info("Due date displayed in alert message is " + dueDate);

                String dueDatePlus7 = DateTime.Parse(paymentObj.DueDateForISowner.Text.Trim()).AddDays(7).ToString("M/dd/yyyy");

                String submitByDate = DateTime.Parse(paymentObj.SubmitByDateForISowner.Text.Trim()).ToString("M/dd/yyyy");
                extentTest.Info("Submit date displayed in alert message is " + submitByDate);

                Assert.IsTrue(dueDatePlus7.Equals(submitByDate), "SubmitBy date should not be 7 days ahead of Due date");
                extentTest.Pass("SubmitBy date should be 7 days ahead of Due date", AttachScrenshot(driver, testContextInstance, "DueDate+7Days=SubmitByDate").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.updateInforLaterBtn_ISowner), "Update information button is not displayed in alert message for IS owner");
                extentTest.Pass("Update information button is displayed in alert message for IS owner", AttachScrenshot(driver, testContextInstance, "MakeApaymentButtonDisplayedForISowner").Build());

                paymentObj.updateInforLaterBtn_ISowner.Click();
                extentTest.Info("Update information later button is clicked ");

                Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URlHomePage"]), "Clicking Update information later button does not redirects to BGO homepage ");
                extentTest.Pass("Clicking Update information later button redirects to BGO homepage ", AttachScrenshot(driver, testContextInstance, "ClickingUpdateInformationButtonRedirectsToBGOhomePage").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }

        public static void ValidateAlertMessageForIDownerOnBGOhomepage(TestContext testContextInstance)
        {

            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);

            try
            {

                Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforalertMsgForIDowner, driver), "Alert message is not displayed for ID owner on Homepage");
                extentTest.Pass("Alert message is displayed for ID owner on Homepage", AttachScrenshot(driver, testContextInstance, "AlertMessgaeDisplayedForIDowner").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.DueDateForIDowner), "Due date is not displayed for ID owner in alert message");
                extentTest.Pass("Due date is displayed for ID owner in alert message", AttachScrenshot(driver, testContextInstance, "DueDateDisplayedForIDowner").Build());

                String dueDate = DateTime.Parse(paymentObj.DueDateForIDowner.Text.Trim()).ToString("M/dd/yyyy");
                extentTest.Info("Due date displayed in alert message is " + dueDate);

                Assert.IsTrue(IsElementPresent(paymentObj.updateInforLaterBtn_IDowner), "Update information button is not displayed in alert message for ID owner");
                extentTest.Pass("Update information button is displayed in alert message for ID owner", AttachScrenshot(driver, testContextInstance, "MakeApaymentButtonDisplayedForIDowner").Build());

                paymentObj.updateInforLaterBtn_IDowner.Click();
                extentTest.Info("Update information later button is clicked ");

                Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URlHomePage"]), "Clicking Update information later button does not redirects to BGO homepage ");
                extentTest.Pass("Clicking Update information later button redirects to BGO homepage ", AttachScrenshot(driver, testContextInstance, "ClickingUpdateInformationButtonRedirectsToBGOhomePage").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            
        }


        public static void ClickOnAnnualTabs(TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);

            GlobalObjects globalObj = new GlobalObjects(driver);

            try
            {

                List<By> YearObjects = new List<By>() { paymentObj.locatorforCurrentYear,paymentObj.locatorforLastYear,paymentObj.locatorforLastSecondYear,
                paymentObj.locatorforLastThirdYear};

                var YearElements = new List<IWebElement>() { paymentObj.CurrentYear,paymentObj.LastYear,paymentObj.LastSecondYear,
                paymentObj.LastThirdYear};

                List<By> TableObjects = new List<By>() {paymentObj.locatorforCurrentYearTableDetails,paymentObj.locatorforLastYearTableDetails,
                paymentObj.locatorforLastSecondYearTableDetails,paymentObj.locatorforLastThirdYearTableDetails};


                for (int k = 0; k < YearObjects.Count; k++)
                {
                    JavascriptClickElement(YearElements[k], driver);
                    extentTest.Info(YearElements[k].Text + "  tab is clicked");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));


                    if (IsElementPresent(TableObjects[k], driver))
                    {
                        Assert.IsTrue(IsSingleELementVisible(TableObjects[k], driver), "Table  for Corresponding year is not displayed");
                        extentTest.Pass("Table for " + YearElements[k].Text + " is displayed", AttachScrenshot(driver, testContextInstance, YearElements[k].Text + "TableDisplayed").Build());

                        switch (k)
                        {
                            case 0:
                                int NoOfRows_CurrentYear = paymentObj.CurrentYearInTable.Count;

                                for (int j = 0; j < NoOfRows_CurrentYear; j++)
                                {
                                    Assert.IsTrue(paymentObj.CurrentYearInTable[j].Text.Contains(DateTime.Now.Year.ToString()), "Year displayed  in " + (j + 1) + "..row is not matching with selected year" + DateTime.Now.Year.ToString());
                                    extentTest.Info(" Year displayed  in " + (j + 1) + ".. row is matching with selected year" + DateTime.Now.Year.ToString());

                                    Assert.IsTrue(IsElementPresent(paymentObj.ViewBreakdownButton_CurrentYearTable[j]), "View breakdown button is not displayed for" + (j + 1) + "..row against transaction date" + paymentObj.CurrentYearInTable[j].Text);
                                    extentTest.Info("View breakdown button is displayed for" + (j + 1) + "..row against transaction date" + paymentObj.CurrentYearInTable[j].Text);

                                    ClickButton(paymentObj.ViewBreakdownButton_CurrentYearTable[j], driver);
                                    extentTest.Info("View breakdown button is clicked");

                                    Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMaintenanceFeeBreakdown, driver), "My Maintenance Fee Breakdown page is not displayed when view Breakdown button of " + (j + 1) + " row is clicked");
                                    extentTest.Pass("My Maintenance Fee Breakdown page is displayed when View Breakdown button for " + (j + 1) + " row is clicked ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeeBreakdownPageDisplayedWhen" + (j + 1) + "rowIsClicked").Build());

                                    driver.Navigate().Back();
                                }
                                break;


                            case 1:
                                int NoOfRows_LasttYear = paymentObj.LastYearInTable.Count;

                                for (int j = 0; j < NoOfRows_LasttYear; j++)
                                {
                                    Assert.IsTrue(paymentObj.LastYearInTable[j].Text.Contains(DateTime.Now.AddYears(-1).Year.ToString()), "Year displayed  in  " + (j + 1) + "..row  is not matching with selected year" + DateTime.Now.AddYears(-1).Year.ToString());
                                    extentTest.Info("Year displayed  in " + (j + 1) + ".. row is matching with selected year" + DateTime.Now.AddYears(-1).Year.ToString());

                                    Assert.IsTrue(IsElementPresent(paymentObj.ViewBreakdownButton_LastYearTable[j]), "View breakdown button is not displayed for" + (j + 1) + "..row against transaction date" + paymentObj.LastYearInTable[j].Text);
                                    extentTest.Info("View breakdown button is displayed for" + (j + 1) + "..row  against transaction date" + paymentObj.LastYearInTable[j].Text);

                                    ClickButton(paymentObj.ViewBreakdownButton_LastYearTable[j], driver);
                                    extentTest.Info("View breakdown button is clicked");

                                    Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMaintenanceFeeBreakdown, driver), "My Maintenance Fee Breakdown page is not displayed when view Breakdown button of " + (j + 1) + " row is clicked");
                                    extentTest.Pass("My Maintenance Fee Breakdown page is displayed when View Breakdown button for " + (j + 1) + " row is clicked ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeeBreakdownPageDisplayedWhen" + (j + 1) + "rowIsClicked").Build());

                                    driver.Navigate().Back();


                                }
                                break;


                            case 2:
                                int NoOfRows_SecondLasttYear = paymentObj.LastSecondYearInTable.Count;

                                for (int j = 0; j < NoOfRows_SecondLasttYear; j++)
                                {
                                    Assert.IsTrue(paymentObj.LastSecondYearInTable[j].Text.Contains(DateTime.Now.AddYears(-2).Year.ToString()), "Year displayed  in  " + (j + 1) + "..row  is not matching with selected year" + DateTime.Now.AddYears(-2).Year.ToString());
                                    extentTest.Info("Year displayed  in " + (j + 1) + ".. row is matching with selected year" + DateTime.Now.AddYears(-2).Year.ToString());

                                    Assert.IsTrue(IsElementPresent(paymentObj.ViewBreakdownButton_LastSecondYearTable[j]), "View breakdown button is not displayed for" + (j + 1) + "..row against transaction date" + paymentObj.LastSecondYearInTable[j].Text);
                                    extentTest.Info("View breakdown button is displayed for" + (j + 1) + "..row against transaction date" + paymentObj.LastSecondYearInTable[j].Text);

                                    ClickButton(paymentObj.ViewBreakdownButton_LastSecondYearTable[j], driver);
                                    extentTest.Info("View breakdown button is clicked");

                                    Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMaintenanceFeeBreakdown, driver), "My Maintenance Fee Breakdown page is not displayed when view Breakdown button of " + (j + 1) + " row is clicked");
                                    extentTest.Pass("My Maintenance Fee Breakdown page is displayed when View Breakdown button for " + (j + 1) + " row is clicked ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeeBreakdownPageDisplayedWhen" + (j + 1) + "rowIsClicked").Build());

                                    driver.Navigate().Back();
                                }
                                break;


                            case 3:
                                int NoOfRows_ThirdLasttYear = paymentObj.LastThirdYearInTable.Count;

                                for (int j = 0; j < NoOfRows_ThirdLasttYear; j++)
                                {
                                    Assert.IsTrue(paymentObj.LastThirdYearInTable[j].Text.Contains(DateTime.Now.AddYears(-3).Year.ToString()), "Year displayed  in  " + (j + 1) + "..row  is not matching with selected year" + DateTime.Now.AddYears(-3).Year.ToString());
                                    extentTest.Info("Year displayed  in " + (j + 1) + ".. row is matching with selected year" + DateTime.Now.AddYears(-3).Year.ToString());

                                    Assert.IsTrue(IsElementPresent(paymentObj.ViewBreakdownButton_LastThirdYearTable[j]), "View breakdown button is not displayed for" + (j + 1) + "..row against transaction date" + paymentObj.LastThirdYearInTable[j].Text);
                                    extentTest.Info("View breakdown button is displayed for" + (j + 1) + "..row against transaction date" + paymentObj.LastThirdYearInTable[j].Text);

                                    ClickButton(paymentObj.ViewBreakdownButton_LastThirdYearTable[j], driver);
                                    extentTest.Info("View breakdown button is clicked");

                                    Assert.IsTrue(IsElementPresentUsingBy(paymentObj.locatorforMaintenanceFeeBreakdown, driver), "My Maintenance Fee Breakdown page is not displayed when view Breakdown button of " + (j + 1) + " row is clicked");
                                    extentTest.Pass("My Maintenance Fee Breakdown page is displayed when View Breakdown button for " + (j + 1) + " row is clicked ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeeBreakdownPageDisplayedWhen" + (j + 1) + "rowIsClicked").Build());

                                    driver.Navigate().Back();
                                }
                                break;


                            default:

                                break;

                        }
                    }


                    else
                    {
                        Assert.IsTrue(IsElementPresent(paymentObj.locatorforNoDataAvailable, driver), "Data is available for the selected year");
                        extentTest.Pass("Data is not available for the selected year", AttachScrenshot(driver, testContextInstance, "NoDataAvailableMessageShown").Build());

                    }


                }

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                };
                
            }

        }




        public static void ValidateAnnulTabsOnMaintenancePageDisplayCorrespondingTable(TestContext testContextInstance)
        {
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);

            try
            {

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforPastDueMessage, driver), "Payment is past due_message is not  displayed on BGO homepage ");
                extentTest.Pass("Payment is past due_message is displayed on BGO homepage ", AttachScrenshot(driver, testContextInstance, "PaymentIsPastDueMessageDisplayed").Build());

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesAndClubDuesPageDisplayed").Build());

                int associationCount = paymentObj.AssociationNameList.Count;
                extentTest.Info("Association count=" + associationCount);

                for (int i = 0; i < associationCount; i++)
                {

                    String associationName = paymentObj.AssociationNameList[i].Text;
                    extentTest.Info((i + 1) + "..Association name shown in my maintenace fees and club dues page is " + associationName);

                    ClickButton(paymentObj.viewTransactionsBtnList[i], driver);
                    extentTest.Info("View Transactions button is clicked");

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));


                    Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMyMaintenaceFeeTransactionPage, driver), "My maintenace fees transactions page is not displayed");
                    extentTest.Pass("My maintenace fees transactions page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenaceFeesTxnPgDisplayedFor" + (i + 1) + "Association").Build());

                    Assert.IsTrue(paymentObj.AssociationNameOnMaintenanceFeesTransactionPage.Text.Contains(associationName), "My maintenance fees transactions page for a selected Association is not displayed");
                    extentTest.Pass("My maintenance fees transactions page for a selected Association is displayed", AttachScrenshot(driver, testContextInstance, "MaintenanceFeesTxn_" + paymentObj.AssociationNameList[i].Text).Build());

                    ClickOnAnnualTabs(testContextInstance);

                    //driver.Navigate().Back();

                    driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["MyMaintenanceFeesAndClubDuesPage"]);


                }


                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }


        public static void ValidateStatementHistoryInMyMaintenanceFeesTransactionsPage(TestContext testContextInstance)
        {

            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            GlobalObjects globalObj = new GlobalObjects(driver);

            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesAndClubDuesPageDisplayed").Build());

                int associationCount = paymentObj.AssociationNameList.Count;
                extentTest.Info("Association count=" + associationCount);

                for (int i = 0; i < associationCount; i++)
                {

                    String associationName = paymentObj.AssociationNameList[i].Text;
                    extentTest.Info((i + 1) + "..Association name shown in my maintenace fees and club dues page is " + associationName);

                    
                    ClickButton(paymentObj.viewTransactionsBtnList[i], driver);
                    extentTest.Info("View Transactions button is clicked");

                    var wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));


                    


                    Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMyMaintenaceFeeTransactionPage, driver), "My maintenace fees transactions page is not displayed");
                    extentTest.Pass("My maintenace fees transactions page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenaceFeesTxnPageDisplayedFor" + (i + 1) + "Association").Build());

                    Assert.IsTrue(paymentObj.AssociationNameOnMaintenanceFeesTransactionPage.Text.Contains(associationName), "My maintenance fees transactions page for a selected Association is not displayed");
                    extentTest.Pass("My maintenance fees transactions page for a selected Association is displayed", AttachScrenshot(driver, testContextInstance, "AssocaitionNameDisplayed").Build());
                

                    JavascriptClickElement(paymentObj.StatementHistoryLink, driver);
                    extentTest.Info("Statement History link is clicked");

                    var wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                    wait2.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));

                    Assert.IsTrue(IsSingleELementVisible(paymentObj.statementHistoryTable, driver), "Statement History Table is not displayed");
                    extentTest.Pass("Statement History Table is displayed", AttachScrenshot(driver, testContextInstance, "StatementHistoryTableDisplayed").Build());

                    int TransactionYearCount = paymentObj.YearInStatementHistoryTable.Count;
                    extentTest.Info("Transaction year count= " + TransactionYearCount);

                    for (int j = 0; j < TransactionYearCount-1; j++)
                    {

                      //  Assert.IsTrue(Int32.Parse(paymentObj.YearInStatementHistoryTable[j].Text.Substring(6, 4)) > Int32.Parse(paymentObj.YearInStatementHistoryTable[j + 1].Text.Substring(6, 4)), "Newest statements are not displayed on the top");

                        Assert.IsTrue(DateTime.Parse(paymentObj.YearInStatementHistoryTable[j].Text )> DateTime.Parse(paymentObj.YearInStatementHistoryTable[j + 1].Text), "Newest statements are not displayed on the top");
                        extentTest.Pass("Newest statements are displayed on the top", AttachScrenshot(driver, testContextInstance, "NewestStatementHistoryDisplayedOnTop").Build());
                        extentTest.Info(paymentObj.YearInStatementHistoryTable[j].Text.Substring(6, 4) + "  statement history was displayed on" + (j + 1) + "..row");

                        Assert.IsTrue(IsElementPresent(paymentObj.YearInStatementHistoryTable[j]), "Statement History for " + (j + 1) + "..row is not displayed");
                        extentTest.Pass("Statement History for " + (j + 1) + "..row is displayed", AttachScrenshot(driver, testContextInstance, "StatementHistoryDisplayedFor" + (j + 1) + "..row").Build());

                        //***PDF document download pop up issue needs to be handled

                      //  Assert.IsTrue(IsElementPresent(paymentObj.DownloadStatementBtnInTable[j]), "Download statement button is not displayed for" + (j + 1) + "..row");
                      //  extentTest.Pass("Download statement button is  displayed for" + (j + 1) + "..row", AttachScrenshot(driver, testContextInstance, "DownloadStatementButtonDisplayedFor" + (j + 1) + " row").Build());

                      //  ClickButton(paymentObj.DownloadStatementBtnInTable[j], driver);
                      //  extentTest.Info("Download statement button of " + (j + 1) + "..row is clicked");


                      //  Businesslogic.DownloadStatementHistoryLogicForDifferentBrowsers(testContextInstance, BrowserType.Chrome, driver);

                      //***

                    }


                    driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["MyMaintenanceFeesAndClubDuesPage"]);


                }


                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");



            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }

            }



        }


        public static void ValidatePaymentConfirmation_ACHpaymentOption(TestContext testContextInstance, ACHpaymentOption PaymentMethod)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesAndClubDuesPageDisplayed").Build());

                ClickButton(paymentObj.locatorForViewPaymentDetailsBtn, driver);
                extentTest.Info("View payment details button is clicked");

                if (paymentObj.AmountDueTextField_MultipleAccount.Count > 1)
                {

                    if (IsElementPresent(paymentObj.locatorForAllLink, driver))
                    {
                        JavascriptClickElement(paymentObj.AllLink, driver);
                        extentTest.Info("All link is clicked");
                    }

                    int AccountNoCount = 0;

                    while (AccountNoCount < paymentObj.AmountDueTextField_MultipleAccount.Count)
                    {

                        CheckedCheckBox(paymentObj.ArdaContributionCheckBox_MultipleAccount[AccountNoCount], driver);
                        extentTest.Info("ARDA contribution check box is unchecked");

                        if (Double.Parse(paymentObj.PastDue_MultipleAccount[AccountNoCount].Text.TrimStart('$')) < 1.00 && Double.Parse(paymentObj.BalanceDue_MultipleAccount[AccountNoCount].Text.TrimStart('$')) < 1.00)
                        {
                            AccountNoCount++;
                            extentTest.Info("Past due is less than $1 for this account");
                        }

                        else
                        {
                            ClearTextBox(paymentObj.AmountDueTextField_MultipleAccount[AccountNoCount], driver);
                            extentTest.Info("amount due text field is cleared");

                            TypeInTextBox(paymentObj.AmountDueTextField_MultipleAccount[AccountNoCount], driver, Constants.Amount_ACHpayment);
                            extentTest.Info("amount is entered");


                            AccountNoCount++;
                        }

                    }

                }

                else
                {
                    CheckedCheckBox(paymentObj.ArdaContributionCheckBox, driver);
                    extentTest.Info("ARDA contribution check box is unchecked");

                    if (Double.Parse(paymentObj.PastDue_SingleAccount.Text.TrimStart('$')) > 1.00 || Double.Parse(paymentObj.BalanceDue_SingleAccount.Text.TrimStart('$')) > 1.00)
                    {
                        ClearTextBox(paymentObj.AmountDueTextField, driver);
                        extentTest.Info("amount due text field is cleared");

                        TypeInTextBox(paymentObj.AmountDueTextField, driver, Constants.Amount_ACHpayment);
                        extentTest.Info("amount is entered");
                    }

                    else
                    {
                        extentTest.Info(" past due is less than $1 for this account");
                    }

                }

                //handling mouse cursor movement
                paymentObj.AmountDue_Bottom.Click();

                WaitForElementToBeClickable(paymentObj.locatorForMakeAPaymentBtn_MyMaintenanceFeesDetailsPaged, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForAssociationName, driver), "Association name is not displayed in Make a payment page");
                extentTest.Pass("Association name is displayed in Make a payment page", AttachScrenshot(driver, testContextInstance, "AssociationNameDisplayed").Build());

                List<IWebElement> paymentObjects1 = new List<IWebElement>() {
                    paymentObj.PaymentMethodsLabel,paymentObj.CheckingAccountField,paymentObj.SavingsAccountField,paymentObj.DebitOrCreditCardField,
                paymentObj.TotalPaymentField[0],paymentObj.RoutingOrTransitNoField[0],paymentObj.BankAccountNoField[0],paymentObj.ReEnterBankAccountNoField[0],paymentObj.AgreeToTermsAndConditionsCheckBox_Checkingaccount,
                paymentObj.SubmitPaymentBtn_MakeAPaymentPage[0],paymentObj.NeedAssistanceSection,paymentObj.WithinUSdetails,paymentObj.WithinUKdetails,paymentObj.AllOtherLocations};

                List<String> fieldName1 = new List<String>() { "Payment Methods label", "Checking account radio button",
                "Savings account radio button","Debit or Credit Card radio button","Total Payment field ","Routing or Transit Number field",
                "Bank account number field ", "Re-enter bank account field","I agree to Payment terms and conditions check box" ,"Submit payment button","Need assistance section","Within the US","Within the UK","All other locations"};

                List<IWebElement> paymentObjects2 = new List<IWebElement>() {
                    paymentObj.PaymentMethodsLabel,paymentObj.CheckingAccountField,paymentObj.SavingsAccountField,paymentObj.DebitOrCreditCardField,paymentObj.TotalPaymentField[1],
                paymentObj.RoutingOrTransitNoField[1],paymentObj.BankAccountNoField[1],paymentObj.ReEnterBankAccountNoField[1],
                    paymentObj.AgreeToTermsAndConditionsCheckBox_Savingsaccount,paymentObj.SubmitPaymentBtn_MakeAPaymentPage[1],paymentObj.NeedAssistanceSection,paymentObj.WithinUSdetails,paymentObj.WithinUKdetails,paymentObj.AllOtherLocations};

                List<String> fieldName2 = new List<String>() { "Payment Methods label", "Checking account radio button",
                "Savings account radio button","Debit or Credit Card radio button","Total Payment field ","Routing or Transit field",
                "Bank account number field ", "Re-enter bank account field", "I agree to Payment terms and conditions check box","submit button","Need assistance section","Within the US","Within the UK","All other locations"};


                if (PaymentMethod.Equals(ACHpaymentOption.CheckingAccount))
                {

                    ClickRadioButton(paymentObj.locatorForCheckingAccountRadioBtn, driver);
                    extentTest.Info("Checking Account RadioBtn is clicked");

                    Businesslogic.IsAllFieldsPresent(testContextInstance, fieldName1, paymentObjects1, driver, Constants.makeAPaymentPage);

                    Assert.IsTrue(paymentObj.TotalPayment_CheckingAccount.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                    extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                    Assert.IsTrue(!paymentObj.TotalPayment_CheckingAccount.Text.Equals(null), "Total payment field is not populated with balance due");
                    extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                    Assert.IsTrue(IsSingleELementVisible(paymentObj.DollarSymbol[0], driver), "Dollar symbol is not displayed");
                    extentTest.Info("Dollar symbol is displayed");

                    TypeInTextBox(paymentObj.RoutingOrTransitNoTxtBox_Checkingaccount, driver, Constants.RoutingNo);
                    extentTest.Info("Routing or Transit Number is entered");

                    TypeInTextBox(paymentObj.BankAccountNoTxtBox_Checkingaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is entered");

                    TypeInTextBox(paymentObj.ReEnterBankAccountNoTxtBox_Checkingaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is re-entered");

                    CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_Checkingaccount, driver);
                    extentTest.Info("I Agree to Terms and Conditions check box is checked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[0], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                }

                else
                {
                    ClickRadioButton(paymentObj.locatorForSavingsAccountRadioBtn, driver);
                    extentTest.Info("Savings Account RadioBtn is clicked");

                    Businesslogic.IsAllFieldsPresent(testContextInstance, fieldName2, paymentObjects2, driver, Constants.makeAPaymentPage);

                    Assert.IsTrue(paymentObj.TotalPayment_SavingsAccount.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                    extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                    Assert.IsTrue(!paymentObj.TotalPayment_SavingsAccount.Text.Equals(null), "Total payment field is not populated with balance due");
                    extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                    Assert.IsTrue(IsSingleELementVisible(paymentObj.DollarSymbol[1], driver), "Dollar symbol is not displayed");
                    extentTest.Info("Dollar symbol is displayed");

                    TypeInTextBox(paymentObj.RoutingOrTransitNoTxtBox_Savingsaccount, driver, Constants.RoutingNo);
                    extentTest.Info("Routing or Transit Number is entered");

                    TypeInTextBox(paymentObj.BankAccountNoTxtBox_Savingsaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is entered");

                    TypeInTextBox(paymentObj.ReEnterBankAccountNoTxtBox__Savingsaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is re-entered");

                    CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_Savingsaccount, driver);
                    extentTest.Info("I Agree to Terms and Conditions check box is checked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[1], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                }

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForACHpaymentConfirmationMsg, driver), "Payment Confirmation message is not displayed");
                extentTest.Pass("Payment Confirmation message is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationMessageDisplayed").Build());

                Assert.IsFalse(IsElementPresent(paymentObj.AuthorisationNo_ACHpayment), "Authorisation Number is displayed in Payment Confirmation message for ACH payment");
                extentTest.Pass("Authorisation Number should not be displayed in Payment Confirmation message for ACH payment", AttachScrenshot(driver, testContextInstance, "AuthorisationNumberNotDisplayed").Build());

                Assert.IsTrue(paymentObj.Amount_ACHpaymentConfirmationMsg.Displayed, "Total Amount paid is not displayed in Payment Confirmation message");
                extentTest.Pass("Total Amount paid is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AmountPaidDisplayed").Build());

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing to my maintenace fees and club dues page is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForPaymentPendingBtn, driver), "Payment pending button is not displayed");
                extentTest.Info("Payment pending button is displayed in my maintenace fees and club dues page ");
                
                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }

            }



        }



        public static void ValidatePaymentConfirmation_DebitOrCreditCard(TestContext testContextInstance)
        {

            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                ClickButton(paymentObj.locatorForViewPaymentDetailsBtn, driver);
                extentTest.Info("View payment details button is clicked");

                //Logic for handling multiple accounts

                if (paymentObj.AmountDueTextField_MultipleAccount.Count > 1)
                {

                    if (IsElementPresent(paymentObj.locatorForAllLink, driver))
                    {
                        JavascriptClickElement(paymentObj.AllLink, driver);
                        extentTest.Info("All link is clicked");
                    }

                    int AccountNoCount = 0;

                    while (AccountNoCount < paymentObj.AmountDueTextField_MultipleAccount.Count)
                    {

                        CheckedCheckBox(paymentObj.ArdaContributionCheckBox_MultipleAccount[AccountNoCount], driver);
                        extentTest.Info("ARDA contribution check box is unchecked");

                        if (Double.Parse(paymentObj.PastDue_MultipleAccount[AccountNoCount].Text.TrimStart('$')) < 1.00 && Double.Parse(paymentObj.BalanceDue_MultipleAccount[AccountNoCount].Text.TrimStart('$')) < 1.00)
                        {
                            AccountNoCount++;
                            extentTest.Info("Past due is less than $1 for this account");
                        }

                        else
                        {
                            ClearTextBox(paymentObj.AmountDueTextField_MultipleAccount[AccountNoCount], driver);
                            extentTest.Info("amount due text field is cleared");

                            TypeInTextBox(paymentObj.AmountDueTextField_MultipleAccount[AccountNoCount], driver, Constants.Amount_ACHpayment);
                            extentTest.Info("amount is entered");


                            AccountNoCount++;
                        }

                    }

                }

                else
                {
                    CheckedCheckBox(paymentObj.ArdaContributionCheckBox, driver);
                    extentTest.Info("ARDA contribution check box is unchecked");

                    if (Double.Parse(paymentObj.PastDue_SingleAccount.Text.TrimStart('$')) > 1.00 || Double.Parse(paymentObj.BalanceDue_SingleAccount.Text.TrimStart('$')) > 1.00)
                    {
                        ClearTextBox(paymentObj.AmountDueTextField, driver);
                        extentTest.Info("amount due text field is cleared");

                        TypeInTextBox(paymentObj.AmountDueTextField, driver, Constants.Amount_ACHpayment);
                        extentTest.Info("amount is entered");
                    }

                    else
                    {
                        extentTest.Info(" past due is less than $1 for this account");
                    }

                }

                //handling mouse cursor movement
                paymentObj.AmountDue_Bottom.Click();

                WaitForElementToBeClickable(paymentObj.locatorForMakeAPaymentBtn_MyMaintenanceFeesDetailsPaged, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                ClickRadioButton(paymentObj.locatorForDebitOrCreditCardRadioBtn, driver);
                extentTest.Info("Debit or credit card RadioBtn is clicked");

                List<IWebElement> paymentObjects = new List<IWebElement>() {paymentObj.AssociationLabel_makeApaymentPg,paymentObj.AssociationName_makeApaymentPg ,
                    paymentObj.TotalPaymentField_DebitOrCreditCard,paymentObj.CardNameField_DebitOrCreditCard,paymentObj.CardNumberField_DebitOrCreditCard,
                paymentObj.CVVfield_DebitOrCreditCard,paymentObj.ExpirationDatefield_DebitOrCreditCard,paymentObj.BillingZipOrPostalcodeField_DebitOrCreditCard,
                paymentObj.InternationalPostalcodeCheckBox_MakeAPaymentPage,paymentObj.AgreeToTermsAndConditionsCheckBox_DebitOrCreditCard,paymentObj.SubmitPaymentBtn_MakeAPaymentPage[2]};

                List<String> fieldName = new List<String>() { "Association label", "Association Name", "Total Payment field","Name field","Card Number field",
                "CVV field ","Expiration Date field","Billing Zip or Postal code field","International postal code check box",
                "I Agree to terms and conditions check box","submit payment button"};

                // Validtaing if fields are displayed in make a payment page when Debit or credit card radio button  is selected

                Businesslogic.IsAllFieldsPresent(testContextInstance, fieldName, paymentObjects, driver, Constants.makeAPaymentPage);

                Assert.IsTrue(paymentObj.TotalPayment_DebitOrCreditCard.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                Assert.IsTrue(!paymentObj.TotalPayment_DebitOrCreditCard.Text.Equals(null), "Total payment field is not populated with balance due");
                extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.DollarSymbol[2], driver), "Dollar symbol is not displayed");
                extentTest.Info("Dollar symbol is displayed");

                List<IWebElement> mandatoryObjects = new List<IWebElement>() { paymentObj.TotalPaymentField_DebitOrCreditCard,paymentObj.CardNameField_DebitOrCreditCard,paymentObj.CardNumberField_DebitOrCreditCard,
                paymentObj.CVVfield_DebitOrCreditCard,paymentObj.ExpirationDatefield_DebitOrCreditCard,paymentObj.BillingZipOrPostalcodeField_DebitOrCreditCard };

                List<String> mandatoryField = new List<String>() {  "Total Payment field ","Name field","Card Number field",
                "CVV field ","Expiration Date field","Billing Zip or Postal code field" };


                // Validtaing AMount, Name, Card Number, CVV, Expiration Date, Billing Zip/Postal Code fields are marked mandatory in make a payment page 

                for (int k = 0; k < mandatoryObjects.Count; k++)
                {
                    Assert.IsTrue(mandatoryObjects[k].GetAttribute("class").Contains("is-required"), mandatoryField[k] + "  is not marked as mandatory in make a payment page");
                    extentTest.Info(mandatoryField[k] + "  is marked mandatory in make a payment page");
                }


                TypeInTextBox(paymentObj.CardName_MakeAPaymentPage, driver, Constants.NameOfCardHolder);
                extentTest.Info("Card Name is entered");

                TypeInTextBox(paymentObj.CardNumber_MakeAPaymentPage, driver, Constants.CardNumber);
                extentTest.Info("Card Number is entered");

                TypeInTextBox(paymentObj.CVV_MakeAPaymentPage, driver, Constants.cvv);
                extentTest.Info("CVV is entered");

                TypeInTextBox(paymentObj.ExpirationDate_MakeAPaymentPage, driver, Constants.expirationDate_MakeAPayment);
                extentTest.Info("Expiration Date is entered");

                TypeInTextBox(paymentObj.BillingZipOrPostalcode_MakeAPaymentPage, driver, Constants.zipcode);
                extentTest.Info("Billing Zip or Postal code is entered");

                CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_DebitOrCreditCard, driver);
                extentTest.Info("I Agree to Terms and Conditions check box is checked");

                WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[2], driver).Click();
                extentTest.Info("submit payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForPaymentConfirmationMsg_CreditOrDebitCard, driver), "Payment Confirmation message is not displayed");
                extentTest.Pass("Payment Confirmation message is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationMessageDisplayed").Build());

                Assert.IsTrue(paymentObj.Amount_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Total Amount paid is not displayed in Payment Confirmation message");
                extentTest.Pass("Total Amount paid is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AmountPaidDisplayed").Build());

                Assert.IsTrue(paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Authorisation Number is not displayed in Payment Confirmation message");
                extentTest.Pass("Authorisation Number is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AuthorisationNumberDisplayed").Build());

                String AuthorisationNumber = paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Text;

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing to my maintenace fees and club dues page is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed ", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForPaymentPendingBtn, driver), "Payment pending button is not displayed");
                extentTest.Info("Payment pending button is displayed in my maintenace fees and club dues page ");

                Businesslogic.ValidateTransactionInFundSource_SearchByAuthorisationNumber(testContextInstance, driver, AuthorisationNumber);

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }

            }



        }

        public static void CheckErrorMsgForMandatoryFields(TestContext testContextInstance)
        {
          
            PaymentsPage paymentObj = new PaymentsPage(driver);

            List<IWebElement> ErrorMsgObjests = new List<IWebElement>() { paymentObj.CardNameErrorMsg_InstallmentPlan,paymentObj.CardNumberErrorMsg_InstallmentPlan,
            paymentObj.ExpirationDateErrorMsg_InstallmentPlan,paymentObj.BillingZipOrPostalCodeErrorMsg_InstallmentPlan, paymentObj.AgreeToTermsAndConditionsErrorMsg_InstallmentPlan};

            List<String> FieldName1 = new List<String>() { "Name text field ","Card number text field  ","Expiration Date text field","Zip code text field ",
                "I agree to payment terms and conditions check box" };

            List<String> FieldName2 = new List<String>() { "Name text field ", "Card number text field  ", "CVV", "Expiration Date text field", "Zip code text field " };

            List<String> text = new List<String>() { Constants.Name, Constants.CardNumber, Constants.cvv, Constants.expirationDate_MakeAPayment, Constants.zipcode };

            List<IWebElement> textBoxObjests = new List<IWebElement>() {paymentObj.CardNameTxtBox_InstallmentPlan,paymentObj.CardNumberTxtBox_InstallmentPlan,
                paymentObj.CVVTxtBox_InstallmentPlan,paymentObj.ExpirationDateTxtBox_InstallmentPlan,paymentObj.BillingZipOrPostalcodeTxtBox_InstallmentPlan };

            JavascriptClickElement(paymentObj.SubmitPaymentAndSetupInstallmentPlanButton, driver);
            extentTest.Info("SubmitPaymentAndSetupInstallmentPlan Button is clicked without entering mandatory fields");


            for (int i = 0; i < ErrorMsgObjests.Count; i++)
            {
                int count = 0;

                if (count == 0)
                {
                    Assert.IsTrue(IsElementPresent(ErrorMsgObjests[i]), " Error message is not shown for the mandatory field_ " + FieldName1[i] + "_if left blank");
                    extentTest.Pass(FieldName1[i] + " is a mandatory field as error message is shown if it is not entered", AttachScrenshot(driver, testContextInstance, "MandatoryFieldDisplayed").Build());

                    extentTest.Info("Following error message is displayed when " + FieldName1[i] + " is not entered __" + ErrorMsgObjests[i].Text);

                    count = 1;

                }


            }

            extentTest.Info("Entering details one by one for mandatory fields and checking the error message for other mandatory fields whose details are not entered");

            ScrollToView(paymentObj.TotalPaymentTxtBox_InstallmentPlan, driver);


            for (int j = 0; j < text.Count; j++)
            {
                TypeInTextBox(textBoxObjests[j], driver, text[j]);
                extentTest.Info(FieldName2[j] + "  is entered");

                JavascriptClickElement(paymentObj.SubmitPaymentAndSetupInstallmentPlanButton, driver);
                extentTest.Info("SubmitPaymentAndSetupInstallmentPlan Button is clicked by entering details till  " + FieldName2[j] + " of make a payment page");

                Assert.IsTrue(IsElementPresent(paymentObj.locatorforMakeAPaymentPage, driver), "Payment is successfull without entering mandatory fields ");
                extentTest.Pass("All mandatory fields needs to be entered for successfull payment processing", AttachScrenshot(driver, testContextInstance, "MandatoryFieldsNeedsToBeEntered").Build());
            }


        }




        public static void ValidateAmountFieldIsNonUpdateableAndErrorMsgForRequiredFieldsInMakeAPaymentPg(TestContext testContextInstance)
        {
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                WaitForElementToBeClickable(paymentObj.locatorforMakeAPaymentBtn, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                ClickRadioButton(paymentObj.locatorForInstallmentPlanRadioBtn, driver);
                extentTest.Info("Installment Plan radio button is selected");

                Assert.IsTrue(IsElementPresent(paymentObj.locatorForInstallmentPlanTable_makeAPaymentPage, driver), "Installment table is not displayed");
                extentTest.Pass("Installment table is displayed", AttachScrenshot(driver, testContextInstance, "InstallemntTableDisplayed").Build());

                Assert.IsTrue(IsAllElementsPresent(paymentObj.locatorforAmountInGrid, driver), "Amount details is not displayed");
                extentTest.Pass("Amount details is displayed", AttachScrenshot(driver, testContextInstance, "AmountDetailsDisplayed").Build());

                String[] amount = new String[paymentObj.AmountInGrid.Count];
                int i = 0;
                double sum = 0.00;
                foreach (IWebElement obj in paymentObj.AmountInGrid)
                {
                    amount[i] = obj.Text.TrimStart('$');
                    sum = sum + double.Parse(amount[i]);
                    i++;
                }

                extentTest.Info("Sum of amount in installment grid=" + sum);

                extentTest.Info("Total Payment Authorised displayed in make a payment page =" + double.Parse(paymentObj.TotalPaymentAuthorised_InstallmentPlan.Text.TrimStart('$')));

                Assert.IsTrue(sum.Equals(double.Parse(paymentObj.TotalPaymentAuthorised_InstallmentPlan.Text.TrimStart('$'))), "Sum of amount in Installment grid is not equal to Total Payment Authorized");
                extentTest.Pass("Sum of amount in Installment grid is equal to Total Payment Authorized", AttachScrenshot(driver, testContextInstance, "SumOfAmountEqualToTotalPaymentAuthorised").Build());

                Assert.IsTrue(paymentObj.TotalPaymentTxtBox_InstallmentPlan.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                Assert.IsTrue(!paymentObj.TotalPaymentTxtBox_InstallmentPlan.Text.Equals(null), "Total payment field is not populated with balance due");
                extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                Assert.IsTrue(paymentObj.TotalPaymentTxtBox_InstallmentPlan.GetAttribute("value").Contains(paymentObj.AmountInGrid[0].Text.TrimStart('$')), "Amount in Total Payment text field is not matching with First payment Amount in Installment grid ");
                extentTest.Pass("Value in Total Payment text field is matching with First payment Amount in Installment grid", AttachScrenshot(driver, testContextInstance, "TotalPaymentMatchingWith1stPayment").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.DollarSymbol[3]), "Dollar symbol is not displayed");
                extentTest.Pass("Dollar symbol is displayed", AttachScrenshot(driver, testContextInstance, "DollarSymbolDisplayed").Build());

                // Checking error message for mandatory fields if left blank
                CheckErrorMsgForMandatoryFields(testContextInstance);

                CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_InstallmentPlan, driver);
                extentTest.Info("I Agree To Terms And Conditions CheckBox is checked");

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }



        public static void ValidateFirstPaymentStatusChangedToPaid_IPeligibleOwner(TestContext testContextInstance)

        {
           
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {
                ValidateAmountFieldIsNonUpdateableAndErrorMsgForRequiredFieldsInMakeAPaymentPg(testContextInstance);

                JavascriptClickElement(paymentObj.SubmitPaymentAndSetupInstallmentPlanButton, driver);
                extentTest.Info("SubmitPaymentAndSetupInstallmentPlan Button is clicked after entering all mandatory fields in Make a payment page");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForPaymentConfirmationMsg_CreditOrDebitCard, driver), "Payment Confirmation message is not displayed");
                extentTest.Pass("Payment Confirmation message is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationMsgDisplayed").Build());

                Assert.IsTrue(paymentObj.Amount_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Total Amount paid is not displayed in Payment Confirmation message");
                extentTest.Pass("Total Amount paid is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AmountPaidDisplayed").Build());

                Assert.IsTrue(paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Authorisation Number is not displayed in Payment Confirmation message");
                extentTest.Pass("Authorisation Number is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AuthorisationNumberDisplayed").Build());

                Assert.IsTrue(paymentObj.InstallmentStatus_PaymentConfirmationPage[0].Text.Contains(Constants.InstallmentStatus), "First payment status in Installment table is not changed to Paid");
                extentTest.Pass("First payment status in Installment table is changed to Paid", AttachScrenshot(driver, testContextInstance, "1stPaymentStatusIsPaid").Build());

                String AuthorisationNumber = paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Text;

                // validating transaction in Fundsource
                Businesslogic.ValidateTransactionInFundSource_SearchByAuthorisationNumber(testContextInstance, driver, AuthorisationNumber);

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }


        public static void ValidateRoutingAndBankAccountNumberFileds_ACHpaymentOption(TestContext testContextInstance, ACHpaymentOption PaymentMethod)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                WaitForElementToBeClickable(paymentObj.makeAPaymentBtn_MaintenaceFeesAndClubDues, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                if (PaymentMethod.Equals(ACHpaymentOption.CheckingAccount))
                {

                    ClickRadioButton(paymentObj.locatorForCheckingAccountRadioBtn, driver);
                    extentTest.Info("Checking Account RadioBtn is clicked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[0], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                    Assert.IsTrue(paymentObj.RoutingOrTransitNumberError_Checkingaccount.Text.Contains("enter the account routing transit number"), "Error message for routing number field is not displayed when left blank");
                    extentTest.Info("Error message for routing number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.BankAccountNumberError_Checkingaccount.Text.Contains("Please enter bank account number"), "Error message for Bank Account number field is not displayed when left blank");
                    extentTest.Info("Error message for Bank Account number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.ReEnterBankAccountNumberError_Checkingaccount.Text.Contains("Please re-enter bank account number"), "Error message for Re-enter Bank Account number field is not displayed when left blank");
                    extentTest.Info("Error message for Re-enter Bank Account number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.AgreeToTermsAndConditionsError_Checkingaccount[0].Text.Contains("Please select Terms and Conditions"), "Error message for Agree to terms & conditions check box is not displayed when left blank");
                    extentTest.Info("Error message for Agree to terms & conditions check box  is displayed when left blank");

                    TypeInTextBox(paymentObj.RoutingOrTransitNoTxtBox_Checkingaccount, driver, Constants.RoutingNo);
                    extentTest.Info("Routing or Transit Number is entered");

                    TypeInTextBox(paymentObj.BankAccountNoTxtBox_Checkingaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is entered");

                    Assert.IsTrue(IsElementInvisible(paymentObj.locatorForShowPassword_BankAccountNo, driver), "Bank account number is not masked");
                    extentTest.Info("Bank account number is masked");

                    ClickButton(paymentObj.showButton_BankAccountNo, driver);

                    Assert.IsTrue(paymentObj.hideButton_BankAccountNo.GetAttribute("class").Contains(Constants.hidePassword), "Bank account number is not displayed");
                    extentTest.Info("Bank account number is displayed");

                    TypeInTextBox(paymentObj.ReEnterBankAccountNoTxtBox_Checkingaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is re-entered");

                    Assert.IsTrue(IsElementInvisible(paymentObj.locatorForShowPassword_BankAccountNo, driver), "Bank account number is not masked");
                    extentTest.Info("Bank account number is masked");

                    ClickButton(paymentObj.showButton_BankAccountNo, driver);

                    Assert.IsTrue(paymentObj.hideButton_BankAccountNo.GetAttribute("class").Contains(Constants.hidePassword), "Bank account number is not displayed in Re-enter Bank account number field");
                    extentTest.Info("Bank account number is displayed in Re-enter Bank account number field");

                    CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_Checkingaccount, driver);
                    extentTest.Info("I Agree to Terms and Conditions check box is checked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[0], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                }

                else
                {
                    ClickRadioButton(paymentObj.locatorForSavingsAccountRadioBtn, driver);
                    extentTest.Info("Savings Account RadioBtn is clicked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[1], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                    Assert.IsTrue(paymentObj.RoutingOrTransitNumberError_Savingaccount.Text.Contains("enter the account routing transit number"), "Error message for routing number field is not displayed when left blank");
                    extentTest.Info("Error message for routing number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.BankAccountNumberError_Savingaccount.Text.Contains("Please enter bank account number"), "Error message for Bank Account number field is not displayed when left blank");
                    extentTest.Info("Error message for Bank Account number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.ReEnterBankAccountNumberError_Savingaccount.Text.Contains("Please re-enter bank account number"), "Error message for Re-enter Bank Account number field is not displayed when left blank");
                    extentTest.Info("Error message for Re-enter Bank Account number field is displayed when left blank");

                    Assert.IsTrue(paymentObj.AgreeToTermsAndConditionsError_Checkingaccount[0].Text.Contains("Please select Terms and Conditions"), "Error message for Agree to terms & conditions check box is not displayed when left blank");
                    extentTest.Info("Error message for Agree to terms & conditions check box  is displayed when left blank");

                    TypeInTextBox(paymentObj.RoutingOrTransitNoTxtBox_Savingsaccount, driver, Constants.RoutingNo);
                    extentTest.Info("Routing or Transit Number is entered");

                    TypeInTextBox(paymentObj.BankAccountNoTxtBox_Savingsaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is entered");

                    Assert.IsTrue(IsElementInvisible(paymentObj.locatorForShowPassword_BankAccountNo, driver), "Bank account number is not masked");
                    extentTest.Info("Bank account number is masked");

                    ClickButton(paymentObj.showButton_SavingAccount[2], driver);

                    Assert.IsTrue(paymentObj.hideButton_BankAccountNo.GetAttribute("class").Contains(Constants.hidePassword), "Bank account number is not displayed");
                    extentTest.Info("Bank account number is displayed");

                    TypeInTextBox(paymentObj.ReEnterBankAccountNoTxtBox__Savingsaccount, driver, Constants.BankAccountNo);
                    extentTest.Info("Bank Account Number is re-entered");

                    Assert.IsTrue(IsElementInvisible(paymentObj.locatorForShowPassword_BankAccountNo, driver), "Bank account number is not masked");
                    extentTest.Info("Bank account number is masked");

                    ClickButton(paymentObj.showButton_SavingAccount[2], driver);

                    Assert.IsTrue(paymentObj.hideButton_BankAccountNo.GetAttribute("class").Contains(Constants.hidePassword), "Bank account number is not displayed in Re-enter Bank account number field");
                    extentTest.Info("Bank account number is displayed in Re-enter Bank account number field");

                    CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_Savingsaccount, driver);
                    extentTest.Info("I Agree to Terms and Conditions check box is checked");

                    WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[1], driver).Click();
                    extentTest.Info("submit payment button is clicked");

                }

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForACHpaymentConfirmationMsg, driver), "Payment Confirmation message is not displayed");
                extentTest.Pass("Payment Confirmation message is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationMessageDisplayed").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }

            }



        }



        public static void ValidateTotalPaymentField_DebitOrCreditCard(TestContext testContextInstance)
        {
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                WaitForElementToBeClickable(paymentObj.locatorformakeAPaymentBtn_MaintenaceFeesAndClubDues, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                ClickRadioButton(paymentObj.locatorForDebitOrCreditCardRadioBtn, driver);
                extentTest.Info("Debit or credit card RadioBtn is clicked");

                List<IWebElement> paymentObjects = new List<IWebElement>() {paymentObj.AssociationLabel_makeApaymentPg,paymentObj.AssociationName_makeApaymentPg ,
                    paymentObj.TotalPaymentField_DebitOrCreditCard,paymentObj.CardNameField_DebitOrCreditCard,paymentObj.CardNumberField_DebitOrCreditCard,
                paymentObj.CVVfield_DebitOrCreditCard,paymentObj.ExpirationDatefield_DebitOrCreditCard,paymentObj.BillingZipOrPostalcodeField_DebitOrCreditCard,
                paymentObj.InternationalPostalcodeCheckBox_MakeAPaymentPage,paymentObj.AgreeToTermsAndConditionsCheckBox_DebitOrCreditCard,paymentObj.SubmitPaymentBtn_MakeAPaymentPage[2]};

                List<String> fieldName = new List<String>() { "Association label", "Association Name", "Total Payment field","Name field","Card Number field",
                "CVV field ","Expiration Date field","Billing Zip or Postal code field","International postal code check box",
                "I Agree to terms and conditions check box","submit payment button"};

                // Validtaing if fields are displayed in make a payment page when Debit or credit card radio button  is selected

                Businesslogic.IsAllFieldsPresent(testContextInstance, fieldName, paymentObjects, driver, Constants.makeAPaymentPage);

                Assert.IsTrue(paymentObj.TotalPayment_DebitOrCreditCard.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                Assert.IsTrue(!paymentObj.TotalPayment_DebitOrCreditCard.Text.Equals(null), "Total payment field is not populated with balance due");
                extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.DollarSymbol[2], driver), "Dollar symbol is not displayed");
                extentTest.Info("Dollar symbol is displayed");

                WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[2], driver).Click();
                extentTest.Info("submit payment button is clicked");

                Assert.IsTrue(paymentObj.CardNameError_DebitOrCreditCard.Text.Contains("*Name is a required field"), "Error message for Name field is not displayed when left blank");
                extentTest.Info("Error message for Name field is displayed when left blank");

                Assert.IsTrue(paymentObj.CardNumberError_DebitOrCreditCard.Text.Contains("*Credit card number is a required field"), "Error message for Card number field is not displayed when left blank");
                extentTest.Info("Error message for Card number field is displayed when left blank");

                Assert.IsTrue(paymentObj.ExpirationDateError_DebitOrCreditCard.Text.Contains("*Credit card expiration is a required field"), "Error message for Expiration Date field is not displayed when left blank");
                extentTest.Info("Error message for Expiration Date field is displayed when left blank");

                Assert.IsTrue(paymentObj.ZipcodeError_DebitOrCreditCard.Text.Contains("*Zip code is a required field"), "Error message for Zipcode field is not displayed when left blank");
                extentTest.Info("Error message for Zipcode field is displayed when left blank");

                Assert.IsTrue(paymentObj.AgreeToTermsAndConditionsError_DebitOrCreditCard.Text.Contains("*Please accept terms and conditions"), "Error message for I agree to Terms and conditions field is not displayed when left blank");
                extentTest.Info("Error message for I agree to Terms and conditions field  is displayed when left blank");

                TypeInTextBox(paymentObj.CardName_MakeAPaymentPage, driver, Constants.NameOfCardHolder);
                extentTest.Info("Card Name is entered");

                TypeInTextBox(paymentObj.CardNumber_MakeAPaymentPage, driver, Constants.CardNumber);
                extentTest.Info("Card Number is entered");

                TypeInTextBox(paymentObj.ExpirationDate_MakeAPaymentPage, driver, Constants.expirationDate_MakeAPayment);
                extentTest.Info("Expiration Date is entered");

                Assert.IsTrue(paymentObj.CVVError_DebitOrCreditCard.Text.Contains("*CVV is a required field"), "Error message for CVV field is not displayed when left blank");
                extentTest.Info("Error message for CVV field is displayed when left blank");

                TypeInTextBox(paymentObj.CVV_MakeAPaymentPage, driver, Constants.cvv);
                extentTest.Info("CVV is entered");

                TypeInTextBox(paymentObj.BillingZipOrPostalcode_MakeAPaymentPage, driver, Constants.zipcode);
                extentTest.Info("Billing Zip or Postal code is entered");

                CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_DebitOrCreditCard, driver);
                extentTest.Info("I Agree to Terms and Conditions check box is checked");

                WaitForElementToBeClickable(paymentObj.SubmitPaymentBtn_MakeAPaymentPage[2], driver).Click();
                extentTest.Info("submit payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForPaymentConfirmationMsg_CreditOrDebitCard, driver), "Payment Confirmation message is not displayed");
                extentTest.Pass("Payment Confirmation message is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationMessageDisplayed").Build());

                Assert.IsTrue(paymentObj.Amount_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Total Amount paid is not displayed in Payment Confirmation message");
                extentTest.Pass("Total Amount paid is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AmountPaidDisplayed").Build());

                Assert.IsTrue(paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Displayed, "Authorisation Number is not displayed in Payment Confirmation message");
                extentTest.Pass("Authorisation Number is displayed in Payment Confirmation message", AttachScrenshot(driver, testContextInstance, "AuthorisationNumberDisplayed").Build());

                String AuthorisationNumber = paymentObj.AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard.Text;

                Businesslogic.ValidateTransactionInFundSource_SearchByAuthorisationNumber(testContextInstance, driver, AuthorisationNumber);

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }


            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }

            }



        }




        public static void ValidateMakeApaymentPageForVCownerHavingSingleAccount_InstallmentPlan(TestContext testContextInstance)
        {
           
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                WaitForElementToBeClickable(paymentObj.locatorforMakeAPaymentBtn, driver).Click();
                extentTest.Info("make a payment button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforMakeAPaymentPage, driver), "Make a payment page is not displayed");
                extentTest.Pass("Make a payment page is displayed", AttachScrenshot(driver, testContextInstance, "MakeAPaymentPageDisplayed").Build());

                ClickRadioButton(paymentObj.locatorForInstallmentPlanRadioBtn, driver);
                extentTest.Info("Installment Plan radio button is selected");

                Assert.IsTrue(IsElementPresent(paymentObj.locatorForInstallmentPlanTable_makeAPaymentPage, driver), "Installment table is not displayed");
                extentTest.Pass("Installment table is displayed", AttachScrenshot(driver, testContextInstance, "InstallemntTableDisplayed").Build());

                Assert.IsTrue(IsAllElementsPresent(paymentObj.locatorforAmountInGrid, driver), "Amount details is not displayed");
                extentTest.Pass("Amount details is displayed", AttachScrenshot(driver, testContextInstance, "AmountDetailsDisplayed").Build());

                String[] amount = new String[paymentObj.AmountInGrid.Count];
                int i = 0;
                double sum = 0.00;
                foreach (IWebElement obj in paymentObj.AmountInGrid)
                {
                    amount[i] = obj.Text.TrimStart('$');
                    sum = sum + double.Parse(amount[i]);
                    i++;
                }

                extentTest.Info("Sum of amount in installment grid=" + sum);

                extentTest.Info("Total Payment Authorised displayed in make a payment page =" + double.Parse(paymentObj.TotalPaymentAuthorised_InstallmentPlan.Text.TrimStart('$')));

                Assert.IsTrue(sum.Equals(double.Parse(paymentObj.TotalPaymentAuthorised_InstallmentPlan.Text.TrimStart('$'))), "Sum of amount in Installment grid is not equal to Total Payment Authorized");
                extentTest.Pass("Sum of amount in Installment grid is equal to Total Payment Authorized", AttachScrenshot(driver, testContextInstance, "SumOfAmountEqualToTotalPaymentAuthorised").Build());

                Assert.IsTrue(paymentObj.TotalPaymentTxtBox_InstallmentPlan.GetAttribute("readonly").Contains("true"), "Amount field is editable");
                extentTest.Pass("Amount field is Non-editable", AttachScrenshot(driver, testContextInstance, "AmountFieldIsNonEditable").Build());

                Assert.IsTrue(!paymentObj.TotalPaymentTxtBox_InstallmentPlan.Text.Equals(null), "Total payment field is not populated with balance due");
                extentTest.Pass("Total payment field is populated with balance due ", AttachScrenshot(driver, testContextInstance, "AmountFieldIsPopulated").Build());

                Assert.IsTrue(paymentObj.TotalPaymentTxtBox_InstallmentPlan.GetAttribute("value").Contains(paymentObj.AmountInGrid[0].Text.TrimStart('$')), "Amount in Total Payment text field is not matching with First payment Amount in Installment grid ");
                extentTest.Pass("Value in Total Payment text field is matching with First payment Amount in Installment grid", AttachScrenshot(driver, testContextInstance, "TotalPaymentMatchingWith1stPayment").Build());

                Assert.IsTrue(IsElementPresent(paymentObj.DollarSymbol[3]), "Dollar symbol is not displayed");
                extentTest.Pass("Dollar symbol is displayed", AttachScrenshot(driver, testContextInstance, "DollarSymbolDisplayed").Build());

                List<String> text = new List<String>() { Constants.Name,Constants.CardNumber,Constants.cvv,Constants.expirationDate_MakeAPayment,
                Constants.zipcode};

                List<IWebElement> textBoxObjests = new List<IWebElement>() {paymentObj.CardNameTxtBox_InstallmentPlan,paymentObj.CardNumberTxtBox_InstallmentPlan,
                paymentObj.CVVTxtBox_InstallmentPlan,paymentObj.ExpirationDateTxtBox_InstallmentPlan,paymentObj.BillingZipOrPostalcodeTxtBox_InstallmentPlan };

                List<String> FieldName = new List<String>() { "Name text field ", "Card number text field  ", "CVV", "Expiration Date text field", "Zip code text field " };


                for (int j = 0; j < text.Count; j++)
                {
                    TypeInTextBox(textBoxObjests[j], driver, text[j]);
                    extentTest.Info(FieldName[j] + "  is entered");

                }

                CheckedCheckBox(paymentObj.AgreeToTermsAndConditionsCheckBox_InstallmentPlan, driver);
                extentTest.Info("I Agree To Terms And Conditions CheckBox is checked");

                JavascriptClickElement(paymentObj.SubmitPaymentAndSetupInstallmentPlanButton, driver);
                extentTest.Info("Submit Payment And Setup Installment Plan Button is clicked after entering all the payment details");

                Assert.IsTrue(IsElementPresent(paymentObj.locatorForPaymentConfirmationMsg_InstallmentPlan, driver), "Payment confirmation page is not displayed");
                extentTest.Pass("Payment confirmation page is displayed", AttachScrenshot(driver, testContextInstance, "PaymentConfirmationPageDisplayed").Build());

                Assert.IsTrue(paymentObj.Amount_PaymentConfirmationMsg_InstallmentPlan.Displayed, "Total Amount paid is not displayed in Payment Confirmation message");
                extentTest.Info("Total Amount paid is displayed in Payment Confirmation message");

                Assert.IsTrue(paymentObj.AuthorisationNo_InstallmentPlan.Displayed, "Authorisation Number is not displayed in Payment Confirmation message");
                extentTest.Info("Authorisation Number is displayed in Payment Confirmation message");

                Assert.IsTrue(paymentObj.Status_InstallmentPlanTable_ConfirmationMsg[0].Text.Contains("Paid"), "First payment status in Installment plan table is not changed to Paid in confirmation page ");
                extentTest.Info("First payment status in Installment plan table is changed to Paid in confirmation page");

                Assert.IsTrue(paymentObj.Status_InstallmentPlanTable_ConfirmationMsg[1].Text.Contains("To Be Paid"), "Second payment status in Installment plan table is not To be Paid");
                extentTest.Info("Second payment status in Installment plan table is To be Paid");

                Assert.IsTrue(paymentObj.Status_InstallmentPlanTable_ConfirmationMsg[2].Text.Contains("To Be Paid"), "Third payment status in Installment plan table is not To be Paid");
                extentTest.Info("Third payment status in Installment plan table is To be Paid");

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }




        public static void ValidateViewInstallmentPlanLinkIsDisplayedForVCSingleAccount_SalestypeAorU_IPsetUpOwner(TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorForViewInstallmentPlanBtn, driver), "View Installment Plan button is not displayed for an owner of Salestype A/U that have an IP plan set up");
                extentTest.Info("View Installment Plan button is displayed for an owner of Salestype A/U that have an IP plan set up");

                WaitForElementToBeClickable(paymentObj.locatorForViewInstallmentPlanBtn, driver).Click();
                extentTest.Info("View Installment plan button is clicked");

                Assert.IsTrue(IsSingleELementVisible(paymentObj.locatorforInstallmentPlanPage, driver), "Installment plan page is not displayed");
                extentTest.Pass("Installment plan page is displayed", AttachScrenshot(driver, testContextInstance, "InstallmentPlanPgDisplayed").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }


        public static void ValidateViewInstallmentPlanLinkIsHiddenForVCSingleAccountThatDoNotHaveIPplanSetup_SalestypeAorU(TestContext testContextInstance)
        {
            
            PaymentsPage paymentObj = new PaymentsPage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {

                List<IWebElement> menuObjests1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees };

                List<By> menuObjests2 = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees };

                MenuLevel1(menuObjests2, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsSingleELementVisible(topMenuobj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContextInstance, "MyMaintenanceFeesPgDisplayed").Build());

                Assert.IsFalse(IsSingleELementVisible(paymentObj.locatorForViewInstallmentPlanBtn, driver), "View Installment Plan button is displayed for an owner of Salestype A/U that do not have an IP plan set up");
                extentTest.Info("View Installment Plan button should not be displayed for an owner of Salestype A/U that do not have an IP plan set up");

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }


       







    }
}
