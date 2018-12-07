using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class Dashboard : LoginMethod
    {

        public static void Savedsearches(string userName, TestContext testContext, string destination, string selectdates, string wheelchair, string reservationType)
        {
            
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            SearchResultsPage SearchResultsObj = new SearchResultsPage(driver);
            MyDashboardPage myDashboardPgObj = new MyDashboardPage(driver);
            
            try
            {
                TestBaseClass.currentType = Constants.pointstype;

                TestBaseClass.initializeTestScripts(destination, selectdates, wheelchair, testContext);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.Points };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Points" };

                //Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URlHomePage"]), "Points menu was not selected");

                MenuLevel2(ListOfMenuLocators, driver);
                extentTest.Info("Points menu was selected");

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForPointsButton, driver));
                extentTest.Pass("Points Radio Buttion is visible", AttachScrenshot(driver, testContext, "PointsRadioButtonDisplayed").Build());

                Assert.IsTrue(homePageObj.PointsRadioButton.Selected, "Points Radio Buttion was not selected");
                extentTest.Pass("Points Radio Buttion was  selected", AttachScrenshot(driver, testContext, "PointsRadioButtonSelected").Build());

                //select the  destination, check in date,checkout date
                Assert.IsTrue(TestBaseClass.EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");

                ClickButton(homePageObj.SearchButton, driver);
                extentTest.Info("Search button is clicked");

                SearchResultsObj.Valtype = reservationType;
                SearchResultsObj.ValDestination = destination;

                Assert.IsTrue(TestBaseClass.fillSavedSearch(testContext, SearchResultsObj), "The Search " + Constants.SavedSearchName1 + " was not successfully saved");
                extentTest.Pass("The Search " + Constants.SavedSearchName1 + " was successfully saved", AttachScrenshot(driver, testContext, "SearchResult").Build());

                driver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];

                Assert.IsTrue(TestBaseClass.VerifySavedSearchesInDashBoardPage(testContext, SearchResultsObj), "The Search Criteria for  Saved Search " + Constants.SavedSearchName1 + "  were not displayed properly in Search Results Page");
                extentTest.Pass("The Search Criteria for  Saved Search " + Constants.SavedSearchName1 + "  was displayed properly in Search Results Page", AttachScrenshot(driver, testContext, "SearchResultPage").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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


        //Verify account summary details in my Dashboard page for VC Single/Multiple club account
        public static void AccountSummaryForVC(TestContext testContext)
        {
            
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            MyDashboardPage myDashboardPgObj = new MyDashboardPage(driver);

            try
            {
                // List<IWebElement> MenuObjects1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MyDashBoard };
                List<By> MenuObjects = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMyDashBoard };

                MenuLevel1(MenuObjects, driver);

                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlMyDashBoardPage"]), " My Dashboard Page is not displayed");

                Assert.IsTrue(IsElementPresentUsingBy(myDashboardPgObj.locatorforMyDashboardPage,driver)," My Dashboard Page is not displayed");
                extentTest.Pass("My Dashboard Page is displayed", AttachScrenshot(driver, testContext, "MyDashboardPage").Build());
                
                List<IWebElement> AccountSummaryObjects = new List<IWebElement>() { myDashboardPgObj.AvailablePointsText,myDashboardPgObj.FuturePointsText,myDashboardPgObj.OwnershipLevelText,
                myDashboardPgObj.BlueGreenRewardsText,myDashboardPgObj.TravelerPlusText,myDashboardPgObj.PaymentBalanceText };

                List<String> fieldName = new List<String>() { "Available Points", "Future Points", "OwnershipLevel", "BlueGreen Rewards", "Traveler Plus", "PaymentBalance" };

                //List<By> AccountSummaryObjects = new List<By>() { myDashboardPgObj.locatorforAvailablePointsText,myDashboardPgObj.locatorforFuturePointsText,myDashboardPgObj.locatorforOwnershipLevelText,
                //myDashboardPgObj.locatorforBlueGreenRewardsText,myDashboardPgObj.locatorforTravelerPlusText,myDashboardPgObj.locatorforPaymentBalanceText };


                int i = 0, j = 0;
                while (i < fieldName.Count)
                {

                    while (j < AccountSummaryObjects.Count)
                    {
                        int count = 0;

                        if (count == 0)
                        {
                            Assert.IsTrue(IsElementPresent(AccountSummaryObjects[j]), fieldName[i] + " in account summary details is missing");
                            extentTest.Pass(fieldName[i] + " in account summary details is displayed", AttachScrenshot(driver, testContext, "AccountSummaryDetails").Build());

                            extentTest.Info("Actual text displayed was : " + AccountSummaryObjects[j].Text);
                            count = 1;
                        }
                        break;
                    }
                    i++;
                    j++;
                }

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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

        //Verify account summary details in my Dashboard page for Non-VC Single/Multiple club account
        public static void AccountSummaryForNonVC(TestContext testContext)
        {
           
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            MyDashboardPage myDashboardPgObj = new MyDashboardPage(driver);

            try
            {
                //  List<IWebElement> MenuObjects1 = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MyDashBoard };
                List<By> MenuObjects = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMyDashBoard };

                MenuLevel1(MenuObjects, driver);

                //  Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlMyDashBoardPage"]), " My Dashboard Page is not displayed");

                Assert.IsTrue(IsElementPresentUsingBy(myDashboardPgObj.locatorforMyDashboardPage, driver), " My Dashboard Page is not displayed");
                extentTest.Pass("My Dashboard Page is displayed", AttachScrenshot(driver, testContext, "MyDashboardPage").Build());


                List<IWebElement> AccountSummaryObjects = new List<IWebElement>() { myDashboardPgObj.VacationWeekText,
                myDashboardPgObj.BlueGreenRewardsText,myDashboardPgObj.TravelerPlusText,myDashboardPgObj.PaymentBalanceText };

                List<String> fieldName = new List<String>() { "Vacation Week", "BlueGreen Rewards", "Traveler Plus", "PaymentBalance" };

                //List<By> AccountSummaryObjects = new List<By>() { myDashboardPgObj.locatorforVacationWeekText,
                //myDashboardPgObj.locatorforBlueGreenRewardsText,myDashboardPgObj.locatorforTravelerPlusText,myDashboardPgObj.locatorforPaymentBalanceText };

                int i = 0, j = 0;
                while (i < fieldName.Count)
                {

                    while (j < AccountSummaryObjects.Count)
                    {
                        int count = 0;

                        if (count == 0)
                        {
                            Assert.IsTrue(IsElementPresent(AccountSummaryObjects[j]), fieldName[i] + " in account summary details is missing");
                            extentTest.Pass(fieldName[i] + " in account summary details is displayed", AttachScrenshot(driver, testContext, "AccountSummaryDetails").Build());

                            extentTest.Info("Actual text displayed was : " + AccountSummaryObjects[j].Text);
                            count = 1;
                        }
                        break;
                    }
                    i++;
                    j++;
                }

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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
