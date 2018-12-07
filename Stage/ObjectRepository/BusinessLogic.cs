using BlueGreenOwner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Utilities;

namespace POM.Classes
{
    public class Businesslogic : TestBaseClass
    {
        public static int PointsUsedForBooking = 0;

        public static int k = 0;

        public static bool PointBalanceLogic(int TotalPoints, int PointsForBooking, TestContext testContext, IWebDriver driver)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            MyPointsPage myPointsPageObj = new MyPointsPage(driver);
            HomePage homePageObj = new HomePage(driver);


            Thread.Sleep(10000);

            string MyAccountPageUrl = MenuLevel1(new List<By>() { allMenusObj.locatorforMyBlueGreen, allMenusObj.locatorforMyPoints }, driver);
            Assert.IsTrue(String.Compare(MyAccountPageUrl, ConfigurationManager.AppSettings["UrlMyPointsPage"], StringComparison.OrdinalIgnoreCase) == 0, "User did not reach MyAccount Page");
            extentTest.Pass("My account page is displayed", AttachScrenshot(driver, testContext, "My AccountPageDisplayed").Build());



            Assert.IsTrue(IsSingleELementVisible(homePageObj.CurrentPoints, driver, Constants.shortLoadTime));
            extentTest.Info($"Points displayed on HomePage top Navigation after booking : {homePageObj.CurrentPoints.Text}");


            myPointsPageObj.AvailablePointsBal = GetElement(myPointsPageObj.locatorForAvailablePoints, driver).Text.Replace(",", "").Replace("\r\npoints", "").Trim('\r', '\n');

            extentTest.Info("Available points :" + myPointsPageObj.AvailablePointsBal);
            //PointsForBooking = Convert.ToInt32(pointsUsed);
            int actualRemainingPoints = Convert.ToInt32(myPointsPageObj.AvailablePointsBal);
            int expectedRemainingPoints = TotalPoints - PointsForBooking;
            extentTest.Info("Remaining points:" + expectedRemainingPoints);
            if (actualRemainingPoints == expectedRemainingPoints)
            {
                extentTest.Info($"The points balance after booking is  {actualRemainingPoints}");
                return true;
            }
            else
            {
                extentTest.Info($"The points balance after booking should be {expectedRemainingPoints} but displayed {actualRemainingPoints}");
                return false;
            }
        }


        public static bool CurrentPPPStatus(string PPPStatus, TestContext testContextInstance)
        {
            bool flag = false;
            switch (currentPPPStatus.ToLower().Replace(" ", ""))
            {

                case "notprotected":
                    extentTest.Info("not protected text  was shown on  My Reservations Page for the booking" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Not_protected_text").Build());
                    flag = true;
                    break;
                case "buynow":
                    extentTest.Info("Buy now button was shown on  My Reservations Page for the booking" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "BuyNow_Button").Build());
                    flag = true;
                    break;
                case "protected":
                    extentTest.Info("The Protected status shown on My Reservations page was" + Constants.ProtectedStatus + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_PPPStatus").Build());

                    flag = true;
                    break;


            }

            return flag;
        }


        public static void GreatEscapeSearchInventory(TestContext testContext, IWebDriver driver, int i = 1)
        {
            GreatEscapesReservationPage greatEscapeResObj = new GreatEscapesReservationPage(driver);

            var allOptions = GetAllItem(greatEscapeResObj.destinationDropDown, driver);
            int destinationCount = allOptions.Count;

            int j = 5;

            while (i < destinationCount)
            {
                SelectElementByIndex(greatEscapeResObj.destinationDropDown, driver, i);
                extentTest.Info("Destination dropdown is selected");

                SelectElementByIndex(greatEscapeResObj.monthDropDown, driver, j);
                extentTest.Info("Month dropdown is selected");

                greatEscapeResObj.searchBtn.Click();
                extentTest.Info("Search button is clicked");
                
                if (IsElementPresent(greatEscapeResObj.locatorforNoInventoryAvailable, driver))
                {
                    extentTest.Info("No inventory available message is shown");

                    Assert.IsTrue(IsElementPresentUsingBy(greatEscapeResObj.locatorforGreatEscapesSearchPg, driver), "Great Escapes Search page is not displayed");
                    //  Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["GreatEscapesResultPage"]), "Great Escapes Search page is not displayed");
                    extentTest.Pass("Great Escapes search page is displayed", AttachScrenshot(driver, testContext, "GreatEscapeSearchPage").Build());

                     k = i + 1;
                    
                    i++;
                }

                else
                {
                    k = i + 1;

                    i = destinationCount + 1;
                  
                }

                if (i == destinationCount)
                {
                    j++;
                    i = 1;
                }

            }

        }


        public static void GreatEscapesSearchAgain(TestContext testContext, IWebDriver driver)
        {
            GreatEscapesReservationPage greatEscapeResObj = new GreatEscapesReservationPage(driver);

            if (IsAllElementsPresent(greatEscapeResObj.locatorforBookItBtn, driver))
            {
                ClickButton(greatEscapeResObj.bookItBtn, driver);
                extentTest.Info("Book button is clicked");

            }

            else
            {
                ClickButton(greatEscapeResObj.searchAgainBtn, driver);
                extentTest.Info("Search Again button is clicked");

                Businesslogic.GreatEscapeSearchInventory(testContext, driver, k);

                if (greatEscapeResObj.bookItBtn.Displayed)
                {
                    ClickButton(greatEscapeResObj.bookItBtn, driver);
                    extentTest.Info("Book button is clicked");
                }

            }
        }


        public static void DownloadStatementHistoryLogicForDifferentBrowsers(TestContext testContext, BrowserType type, IWebDriver driver)

        {
            switch (type)
            {

                case BrowserType.Chrome:

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    string DownloadsPath = ConfigurationManager.AppSettings["DownloadsFilePath"];

                    //failing to open chrome://downloads/
                    js.ExecuteScript("window.open('" + DownloadsPath + "'" + ")");

                    SwitchTochildWindow(driver, 1);
                    extentTest.Info(" Switched to Child window");

                    ClickDownloadLink_FromShadowDOMElements(driver);


                    break;


                case BrowserType.Firefox:



                    break;


                case BrowserType.Ie:


                    break;


                default:

                    break;

            }


        }


        public static void ValidateTransactionInFundSource_SearchByArvact(TestContext testContext, IWebDriver driver, String arvact)
        {
            try
            {
                FundSourcePage fundSourceObj = new FundSourcePage(driver);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string Url = ConfigurationManager.AppSettings["UrlForFundSource"];

                js.ExecuteScript("window.open('" + Url + "'" + ")");

                SwitchTochildWindow(driver, 1);
                extentTest.Info(" Switched to Child window");

                TypeInTextBox(fundSourceObj.locatorforloginId, driver, Constants.FundSourceId);
                extentTest.Info("Fundsource Login id is entered");

                TypeInTextBox(fundSourceObj.locatorforpassword, driver, Constants.FundSourcePassword);
                extentTest.Info("Fundsource Password is entered");

                ClickButton(fundSourceObj.locatorforloginButton, driver);
                extentTest.Info("Fundsource Login button is clicked");

                Assert.IsTrue(IsSingleELementVisible(fundSourceObj.FundSourceHomePg, driver), "Fundsource home page is not displayed");
                extentTest.Pass("Fundsource home page is displayed", AttachScrenshot(driver, testContext, "FundSourceHomePage").Build());

                ClickButton(fundSourceObj.linkTransactions, driver);
                extentTest.Info("Transaction link is clicked");

                TypeInTextBox(fundSourceObj.BasicSearchTextField, driver, arvact);
                extentTest.Info("Arvact is entered");

                ClickButton(fundSourceObj.BasicSearchBtn, driver);
                extentTest.Info("Basic Search button is clicked");

                Assert.IsFalse(fundSourceObj.NoTransactionFound.Text.Contains("No Transactions found."), "Transaction history is displayed");
                extentTest.Pass("Transaction history is not displayed", AttachScrenshot(driver, testContext, "TransactionHistory").Build());

                driver.Close();

                SwitchToParentWindow(driver);
                extentTest.Info(" Switched to parent window");
            }
            catch (Exception exception)
            {
                if (exception != null)
                {
                    extentTest.Error("Error occured on Child window , switching back to parent window");
                    SwitchToParentWindow(driver);
                    Assert.Fail(exception.Message);

                }

            }

        }



        public static void ValidateTransactionInFundSource_SearchByAuthorisationNumber(TestContext testContext, IWebDriver driver, String authorisationNumber)
        {
            try
            {

                FundSourcePage fundSourceObj = new FundSourcePage(driver);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string Url = ConfigurationManager.AppSettings["UrlForFundSource"];

                js.ExecuteScript("window.open('" + Url + "'" + ")");

                SwitchTochildWindow(driver, 1);
                extentTest.Info(" Switched to Child window");

                TypeInTextBox(fundSourceObj.locatorforloginId, driver, Constants.FundSourceId);
                extentTest.Info("Fundsource Login id is entered");

                TypeInTextBox(fundSourceObj.locatorforpassword, driver, Constants.FundSourcePassword);
                extentTest.Info("Fundsource Password is entered");

                ClickButton(fundSourceObj.locatorforloginButton, driver);
                extentTest.Info("Fundsource Login button is clicked");

                Assert.IsTrue(IsSingleELementVisible(fundSourceObj.FundSourceHomePg, driver), "Fundsource home page is not displayed");
                extentTest.Pass("Fundsource home page is displayed", AttachScrenshot(driver, testContext, "FundSourceHomePage").Build());

                ClickButton(fundSourceObj.linkTransactions, driver);
                extentTest.Info("Transaction link is clicked");

                ClickLink(fundSourceObj.AdvanceSearch, driver);
                extentTest.Info("Advanced search link is clicked");

                SelectElementByText(fundSourceObj.SearchDropDown, driver, Constants.SearchVisibleText);
                extentTest.Info("Authorisation is selected from search drop down");

                TypeInTextBox(fundSourceObj.AdvanceSearchTxtField, driver, authorisationNumber);
                extentTest.Info("Authorisation number is entered");

                ClickButton(fundSourceObj.AdvanceSearchBtn, driver);
                extentTest.Info("Advanced Search button is clicked");

                Assert.IsTrue(IsElementPresent(fundSourceObj.locatorforTransactionFound, driver), "Transaction history is not displayed");
                extentTest.Pass("Transaction history is displayed", AttachScrenshot(driver, testContext, "TransactionHistoryDisplayed").Build());

                driver.Close();

                SwitchToParentWindow(driver);
                extentTest.Info(" Switched to parent window");
            }

            catch (Exception exception)
            {
                if (exception != null)
                {
                    extentTest.Error("Error occured on Child window , switching back to parent window");
                    SwitchToParentWindow(driver);
                    Assert.Fail(exception.Message);

                }

            }

        }

        //validating if all fields are present in a page
        public static bool IsAllFieldsPresent(TestContext testContext, List<String> fieldName, List<By> locator, IWebDriver driver, String pageName)
        {
            try
            { 
            for (int i = 0; i < fieldName.Count; i++)
            {

                Assert.IsTrue(IsElementPresentUsingBy(locator[i], driver), fieldName[i] + " in " + pageName + " is missing");
                extentTest.Pass(fieldName[i] + " in " + pageName + " page is displayed ", AttachScrenshot(driver, testContext, "FieldNameDisplayed").Build());

            }

            return true;

             }
            catch (Exception e)
            {
                extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());
                return false;
            }


        }

        public static bool IsAllFieldsPresent(TestContext testContext, List<String> fieldName, List<IWebElement> element, IWebDriver driver, String pageName)
        {
            try
            {

            for (int i = 0; i < fieldName.Count; i++)
            {

                    Assert.IsTrue(IsElementPresent(element[i]), fieldName[i] + " in " + pageName + " is missing");
                    extentTest.Pass(fieldName[i] + " in " + pageName + " page is displayed ", AttachScrenshot(driver, testContext, "FieldNameDisplayed").Build());

                }

                return true;
            }

            catch (Exception e)
            {
                extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());
                return false;
            }

        }

        public static bool IsAllColumnValuesPresent(TestContext testContext, List<String> fieldName, List<By> locator, IWebDriver driver, String pageName)
        {
            try
            {
                for (int i = 0; i < fieldName.Count; i++)
                {

                    Assert.IsTrue(IsAllElementsPresent(locator[i], driver), fieldName[i] + " in " + pageName + " is missing");
                    extentTest.Pass(fieldName[i] + " in " + pageName + " page is displayed ", AttachScrenshot(driver, testContext, "ColumnValuesDisplayed").Build());

                }

                return true;
            }

            catch (Exception e)
            {
                extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());
                return false;
            }
        }

       

      
        
        

        

            

        [FindsBy(How = How.XPath, Using = "//button[@data-id='Guest_Selected']//following-sibling::div//ul//li[@data-optgroup='1']")]
        public IWebElement OwnerNameList;
        public static By LocatorForOwnerNameList = By.XPath("//button[@data-id='Guest_Selected']//following-sibling::div//ul//li[@data-optgroup='1']");

        [FindsBy(How = How.XPath, Using = "//button[@data-id='Guest_Selected']//following-sibling::div//ul//li[@data-optgroup='2']")]
        public IWebElement GuestNameList;
        public static By LocatorForGuestNameList = By.XPath("//button[@data-id='Guest_Selected']//following-sibling::div//ul//li[@data-optgroup='2']");

        [FindsBy(How = How.XPath, Using = "//button[@data-id='Guest_Selected']")]
        public IWebElement GuestNameButton;

        public static By LocatorForGuestNameButton = By.XPath("//button[@data-id='Guest_Selected']");
        
        public static By LocatoforGuestCheckingIn = By.XPath("//div[@class='btn-group bootstrap-select input-group-btn open']");
        public static readonly string Ownername = "Owner";
        public static readonly string GuestName = "Guest";
        public static readonly string Please_Select_Guests = "Please select a guest.";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add New Guest')]")]
        public static IWebElement AddnewGuestButton;
        public static By LocatorforAddnewGuestButton = By.XPath("//button[contains(text(),'Add New Guest')]");

        [FindsBy(How = How.XPath, Using = "//div[@id='collapse-add-new-guest']")]

        public static IWebElement HiddenAddnewguestsection;

        public static By LocatorfokonsarHiddenAddnewguestsection = By.XPath("//div[@id='collapse-add-new-guest']");
        public static void SelectGuest( GuestType guestType, IWebDriver driver, int GuestNameIndex=1)
        {

            switch (guestType)
            {
                case GuestType.Owner:

                    ClickButton(LocatorForGuestNameButton, driver);
                    IList<IWebElement> Ownerlist = GetListOfElements(LocatorForOwnerNameList, driver);

                    Assert.IsTrue(Ownerlist.Count >2, "Owner name does not exist");

                    for (int i = 0; i < Ownerlist.Count; i++)
                    {


                        if (Ownerlist[i].Text.ToLower().Contains(Ownername.ToLower()) || Ownerlist[i].Text.ToLower().Contains(Please_Select_Guests.ToLower()))
                        {
                            Ownerlist.Remove(Ownerlist[i]);
                            break;

                        }
                    }

                    ClickButton(Ownerlist[GuestNameIndex], driver);
                    break;

                case GuestType.Guest:
                    ClickButton(LocatorForGuestNameButton, driver);
                    IList<IWebElement> GuestList = GetListOfElements(LocatorForOwnerNameList, driver);
                    if(GuestList.Count>2)
                    {
                        for (int i = 0; i < GuestList.Count; i++)
                        {
                            if(GuestList[i].Text.ToLower().Contains(GuestName.ToLower()))
                            {
                                GuestList.Remove(GuestList[i]);
                                break;
                            }
                        }
                        ClickButton(GuestList[GuestNameIndex], driver);
                    }
                    break;


                ////case GuestType.AddNewGuest:
                ////    ClickButton(AddnewGuestButton, driver);
                ////    WaitForElement(LocatorforHiddenAddnewguestsection, driver);
                ////    TypeInTextBox(GuestFirstName, driver, Constants.GuestFirstName);
                ////    TypeInTextBox(GuestlastName, driver, Constants.GuestLastName);
                ////    TypeInTextBox(GuestEmail, driver, Constants.Email);
                ////    SelectElementByValue(GuestRelation, driver, GuestRelationship.Family.ToString());


                ////    break;

                 
                    
                       

                    
                    

            }



        }
    }
}
