using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using BlueGreenOwner;
using System.Configuration;

namespace BlueGreenOwner.TestCases
{
    public class Mortgage:LoginMethod
    {
      
        public static void ViewMortgageSummaryPageErrorLastNameonLoannotMatchingLSAMS(string userName, TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.PageLoadTimeInSecond);
                List<By> ListOfMenuLocators = new List<By>() { allMenusObj.locatorforMyBlueGreen, allMenusObj.locatorforLoanSummary, allMenusObj.locatorforMortgageViewHistory };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { allMenusObj.MyBlueGreenMenu, allMenusObj.LoanSummary, allMenusObj.MortgageViewHistory };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "LoanSummary", "Mortgage-Viewhistory" };

               string actual= MenuLevel2(ListOfMenuLocators, driver,(int)Utilities.Timeout.LongwaitInSecond);
                
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.PageLoadTimeInSecond);
                Assert.IsTrue(string.Compare( actual,ConfigurationManager.AppSettings["URLForMortgageViewHistoryPage"],StringComparison.OrdinalIgnoreCase)==0, "Mortgage Security Page was not displayed  on selecting the top menu");
                extentTest.Pass("Mortgage Security Page was displayed  on selecting the top menu", AttachScrenshot(driver, testContext, "MortgageSecurityPagedisplayed").Build());

                MortgageSecurityPage pageObj = new MortgageSecurityPage(driver);
               
                Assert.IsTrue(IsElementPresent(pageObj.locatorforlastNameTextBox,driver), "The Mortgage Security Page was not displayed");
                extentTest.Pass("The Mortgage Security Page was displayed", AttachScrenshot(driver, testContext, "MortgageSecurityPagedisplayed").Build());

                Assert.IsTrue(IsElementPresent(pageObj.locatorforlastNameTextBox,driver), "Last Name Text box was not Present in Morgage Security page");
                extentTest.Pass("Last Name Text box was Present in Morgage Security page", AttachScrenshot(driver, testContext, "LastNameTextBoxIsPresent").Build());

                Assert.IsTrue(IsElementPresent(pageObj.locatorforsubmitButton, driver), "Submit button was not Present in Morgage Security page");
                extentTest.Pass("Submit button was Present in Morgage Security page", AttachScrenshot(driver, testContext, "SubmitButtonIsPresent").Build());

                pageObj.lastNameTextBox.SendKeys(Constants.LastName);
                pageObj.submitButton.Click();

                Assert.IsTrue(IsElementPresent(pageObj.locatorforerrorMessageElement,driver), "Error message When Last Name on Loan doesnot Match with that on LSAMS was not displayed");
                extentTest.Pass("Error message When Last Name on Loan doesnot Match with that on LSAMS was displayed", AttachScrenshot(driver, testContext, "ErrorMessageDisplayed").Build());

                Assert.IsTrue(pageObj.errorMessageElement.Text.Replace(" ", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "").ToLower().Equals(Constants.ErrormessageNonMatchingLastName.Replace(" ", "").ToLower()), "Error message displayed was not" + Constants.ErrormessageNonMatchingLastName);
                extentTest.Pass("Error message displayed was " + Constants.ErrormessageNonMatchingLastName, AttachScrenshot(driver, testContext, "ErrorMessgae").Build());


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

