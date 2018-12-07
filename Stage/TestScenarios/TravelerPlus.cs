using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using POM.Classes;
using Utilities;
using System.Threading;

namespace BlueGreenOwner.TestCases
{
    public class TravelerPlus:LoginMethod
    {

        public static void ValidateRCINightlyStays(string userName, TestContext testContextInstance)
        {
            
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {

                LoginPage loginPageObj = new LoginPage(driver);

                AllMenus topMenuobj = new AllMenus(driver);
                
                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforTravelerPlusMain,  topMenuobj.locatorforTravlerPlusSub };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.TravelerPlusMain, topMenuobj.TravlerPlusSub };

                //changes done by Fathima 

                MenuLevel1(ListOfMenuLocators,driver);

                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                //Assert.IsTrue(driver.Url.Contains( ConfigurationManager.AppSettings["URLForTravelerPlusHomePage"]), "Traveler Plus Home Page was not displayed  on selecting the top menu");

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforTravelerPlusPage,driver), "Traveler Plus Home Page was not displayed  on selecting the top menu");
                extentTest.Pass("Traveler Plus Home Page was displayed  on selecting the top menu", AttachScrenshot(driver, testContextInstance, "TravelerPlusPageDisplayed").Build());
                
                //ScrollToView(tpObj.LinkRCINightlyStaysUnderHelpfulLinks, driver);

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforLinkRCINightlyStaysUnderHelpfulLinks, driver), "The Link for RCI NightlyStays was not displayed");
                extentTest.Pass("The Link for RCI NightlyStays was displayed ", AttachScrenshot(driver, testContextInstance, "RCIlinkDisplayed").Build());

                JavascriptClickElement(tpObj.LinkRCINightlyStaysUnderHelpfulLinks, driver);
               //IsElementClickable( tpObj.LinkRCINightlyStaysUnderHelpfulLinks,driver);

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforLinkRCINightlyStays, driver), "The Link for RCI NightlyStays was not displayed in Traveler Plus Home Page");
                extentTest.Pass("The Link for RCI NightlyStays was displayed in Traveler Plus Home Page", AttachScrenshot(driver, testContextInstance, "RCIlinkDisplayed").Build());

                WaitForElementToBeClickable(tpObj.locatorforLinkRCINightlyStays,driver).Click();
                
                //tpObj.LinkRCINightlyStays.Click();

                //Assert.IsTrue(driver.Url.Equals(ConfigurationManager.AppSettings["URLForTravelerPlusRCIPage"]), "On Clicking RCI Nightly Stays,RCI Nightly Stays page was not shown");
                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforRCINightlyStaysPage,driver), "On Clicking RCI Nightly Stays,RCI Nightly Stays page was not shown");
                extentTest.Pass("On Clicking RCI Nightly Stays,RCI Nightly Stays page was shown", AttachScrenshot(driver, testContextInstance, "RCINightlyStaysPageDisplayed").Build());

                List<string> fieldName;
                List<By> locatorForField;

                fieldName = new List<string> { "Benefits of RCI Nightly Stays", "The content -View real-time availability and book your vacation online using your Bluegreen Vacation Points", "The Content-Flexibility — stay just a few nights or a full week", "The content-Access to more than 4,500 resorts worldwide in the RCI network*", "Get Started now Button", "Link to Visit Our Exchange FAQ's page", "Link-Click for hours of operation" };

                locatorForField = new List<By>() { tpObj.locatorforHeadingBenefitsOfNightlyStays, tpObj.locatorforBenefitsOfNightlyStaysContent1, tpObj.locatorforBenefitsOfNightlyStaysContent2, tpObj.locatorforBenefitsOfNightlyStaysContent3, tpObj.locatorforgetStartedNowButton, tpObj.locatorforLinkVisitOurExchangeFAQPage, tpObj.locatorforLinkClickHoursOfOperation };

                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayed(testContextInstance, fieldName, tpObj.pageName, locatorForField), "Several essential fields were not displayed in the RCI nightly stays page");
                extentTest.Pass("The following fields were shown.Benefits of RCI Nightly Stays ,The content -View real-time availability and book your vacation online using your Bluegreen Vacation Points,The Content-Flexibility — stay just a few nights or a full week, The content-Access to more than 4,500 resorts worldwide in the RCI network*,Get Started now Button,Link to Visit Our Exchange FAQ's page,Link-Click for hours of operation", AttachScrenshot(driver, testContextInstance, "FiledsforRCINightlyStaysPageDisplayed").Build());

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforgetStartedNowButton, driver), "Get Started Now Button was not shown");

               ClickButton( tpObj.getStartedNowButton,driver);
                extentTest.Info("get started now button is clicked");

               // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                Thread.Sleep(5000);

                ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
                if (windowHandles.Count > 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                }

                //changes done by Fathima

                try
                {
                    Assert.IsTrue(driver.Url.ToLower().Contains(ConfigurationManager.AppSettings["URLForRCINightlyStaysHomePage"].ToLower()), " RCI Terms and Conditions Screen was not shown");
                  //  Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforRCI_Page,driver), "RCI Terms and Conditions Screen was not shown");
                    extentTest.Pass("RCI Terms and Conditions Screen was shown", AttachScrenshot(driver, testContextInstance, "GetStartedButtonandRCItermsDisplayed").Build());
                    
                }

                catch (Exception exception)
                {
                    if (exception != null)
                    {
                        extentTest.Error("Error occured on Child window , switching back to parent window");
                        driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
                        driver.SwitchTo().Window(driver.WindowHandles[0]);
                        Assert.Fail(exception.Message);

                    }

                }

                // driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);

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


        public static void ToVerifyRVResortCoastlink(string userName, TestContext testContextInstance)
        {
           
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            
            try
            {
                
                LoginPage loginPageObj = new LoginPage(driver);
               
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforTravelerPlusMain, topMenuobj.locatorforTravlerPlusSub };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.TravelerPlusMain, topMenuobj.TravlerPlusSub };

                //changes done by Fathima 

                MenuLevel1(ListOfMenuLocators, driver);

                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URLForTravelerPlusHomePage"]), "Traveler Plus Home Page was not displayed  on selecting the top menu");

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforTravelerPlusPage, driver), "Traveler Plus Home Page was not displayed  on selecting the top menu");
                extentTest.Pass("Traveler Plus Home Page was displayed  on selecting the top menu", AttachScrenshot(driver, testContextInstance, "TravelerPlusPageDisplayed").Build());
                
               // ScrollToView(tpObj.LinkRVResortCampsonTp, driver);

                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforLinkRVResortCampsonTp,driver), "The Link for RV Resort Camping was not displayed in Traveler Plus Home Page");
                extentTest.Pass("The Link for RV Resort Camping was displayed in Traveler Plus Home Page", AttachScrenshot(driver, testContextInstance, "RVResortCampingLinkDisplayed").Build());

                //Updated code Shivam Pathak
              JavascriptClickElement(tpObj.LinkRVResortCampsonTp, driver);

                //tpObj.LinkRVResortCampsonTp.Click();

                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforLinkRVResortCamps, driver), "The Link for RV Resort Camping was not displayed in Traveler Plus Page");
                extentTest.Pass("The Link for RV Resort Camping  was displayed in Traveler Plus Page", AttachScrenshot(driver, testContextInstance, "RVResortCampingDisplayed").Build());

                // Assert.IsTrue(driver.Url.Equals(ConfigurationManager.AppSettings["URLForCoastToCoastRV"]), "RV Resort Camping page was not shown");
                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforRVResortCampingPage,driver), "RV Resort Camping page was not shown");
                extentTest.Pass("RV Resort Camping page was shown", AttachScrenshot(driver, testContextInstance, "RVResortCampingPageDisplayed").Build());

                List<string> fieldName;
                List<By> locatorForField;

                fieldName = new List<string>() { "Book Now button on the right side of the page with a link Participating RV Resorts", "Book Now button", "Temporary Coast to Coast membership now link", "Save Your Vacation Points and Purchase Coast TripSetter points", "Convert Your Bluegreen Vacation Points to Coast Tripsetter Points", "Click Here Text", "Booking Guidelines link", "Participating RV Resorts Link" };

                locatorForField = new List<By>() { tpObj.locatorforBookButtonTop, tpObj.locatorforBookButtonDown, tpObj.locatorfortemporaryCoastToCoastLink, tpObj.locatorforSaveYourPointsText, tpObj.locatorforConvertYourPointsText, tpObj.locatorforClickHereLink, tpObj.locatorforbookingGuidelinesLink, tpObj.locatorforparticipatingRVResortsLink };

                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayed(testContextInstance, fieldName, tpObj.rvresortCampingPageName, locatorForField), "Several essential fields were not displayed in the Rv Resort Coast page");

                //GoCampingText
                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforGoCampingText, driver), "The text " + Constants.GoCampingText + "was not shown");
                string content = null;
                foreach (IWebElement ele in tpObj.GoCampingText)
                {
                    content = content + ele.Text;

                }
                content = content.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("ViewalistofParticipatingRVResorts", "");
                Assert.IsTrue(content.Equals(Constants.GoCampingText.Replace(" ", "")), "The text " + Constants.GoCampingText + "was not displayed correctly");

               extentTest.Info( "The text " + Constants.GoCampingText + "was displayed correctly");

                //save points text
                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforSaveYourPointsText, driver), "The text " + Constants.SaveYourPointsText + "was not shown");
                Assert.IsTrue(tpObj.SaveYourPointsText.Text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Equals(Constants.SaveYourPointsText.Replace(" ", "")), "The text " + Constants.SaveYourPointsText + "was not displayed correctly");
                extentTest.Info( "The text " + Constants.SaveYourPointsText + "was displayed correctly");

                //CONVERT POINTS text

                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforConvertYourPointsText, driver), "The text " + Constants.ConvertYourPointsText + "was not shown");
                Assert.IsTrue(tpObj.ConvertYourPointsText.Text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Equals(Constants.ConvertYourPointsText.Replace(" ", "")), "The text " + Constants.ConvertYourPointsText + " was not displayed correctly");
                extentTest.Info( "The text " + Constants.ConvertYourPointsText + " was displayed correctly");

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

        public static void VerifyNoHotweeksForNonTpUsers(string userName, TestContext testContextInstance)
        {
            
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {
                LoginPage loginPageObj = new LoginPage(driver);
               
                AllMenus topMenuobj = new AllMenus(driver);
                
                //changes done by Fathima
                Extends_TestBaseClass.ClickUsingJavaScript(topMenuobj.NonTravelerPlusMain);

               // topMenuobj.NonTravelerPlusMain.Click();
               // Thread.Sleep(3000);

                //var expected = ConfigurationManager.AppSettings["URLForNonTravelerPlusHomePage"];
                //var actual = driver.Url;
                
                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                // Assert.IsTrue(expected.Contains(actual));

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforBecomeTPpage, driver), "Become A Bluegreen Traveler Plus Member Page was not displayed on selecting the top menu");
                extentTest.Pass("Become A Bluegreen Traveler Plus Member Page was displayed  on selecting the top menu", AttachScrenshot(driver, testContextInstance, "BecomeATravelerPlusMemberPageDisplayed").Build());

                List<string> fieldName;
                List<By> locatorForField;

                fieldName = new List<string>() { "RCI Nighttly Stays", "RV  Resort Coast link" };
                locatorForField = new List<By>() { tpObj.locatorforLinkRCINightlyStays, tpObj.locatorforLinkRVResortCamps };
                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayedNegativeCase(testContextInstance, fieldName, tpObj.nontravelerplushomepage, locatorForField), "RCI Nighttly Stays and RV  Resort Coast links were displayed on Traveler Plus page for non Traveler plus owner");
                extentTest.Pass("RCI Nighttly Stays and RV  Resort Coast links should not be displayed on Traveler Plus page for non Traveler plus owner", AttachScrenshot(driver, testContextInstance, "RCInightStaysandResortCoastLinkNotDisplayed").Build());

                //verify below fields are not present but clicking brings to same page.
                fieldName = new List<string>() { "Resort Hot Weeks", "Great Escapes" };
                locatorForField = new List<By>() { tpObj.locatorforHotWeeksGetAways, tpObj.locatorforGreatEscape };
                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayed(testContextInstance, fieldName, tpObj.nontravelerplushomepage, locatorForField), "The Resort Hot Weeks and Great Escapes links were displayed on Traveler Plus page for non Traveler plus owner");
                extentTest.Pass("The Resort Hot Weeks and Great Escapes links shoulod not be displayed on Traveler Plus page for non Traveler plus owner", AttachScrenshot(driver, testContextInstance, "ResortHotWeeksandGretaEscapesLinkDisplayed").Build());


               ClickLink(tpObj.HotWeeksGetAways,driver);
                extentTest.Info("HotWeeksGetAways link is clicked");

                Assert.IsTrue(IsSingleELementVisible(tpObj.tpBenefitTable,driver), tpObj.nontravelerplushomepage + " was not displayed on clicking Resort Hotweeks Link");
                extentTest.Info(tpObj.nontravelerplushomepage + " was displayed on clicking Resort Hotweeks Link");

                ClickLink(tpObj.GreatEscape,driver);
                extentTest.Info("great escapes link is clicked");

                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorfortpBenefitTable, driver), tpObj.nontravelerplushomepage + " was not displayed on clicking Resort Hotweeks Link");
                extentTest.Info( tpObj.nontravelerplushomepage + " was displayed on clicking Resort Hotweeks Link");

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

        //

        public static void validateTravelServicesWithCarRentals(string userName, TestContext testContextInstance)
        {
           
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {
                LoginPage loginPageObj = new LoginPage(driver);

                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() {  topMenuobj.locatorforBook, topMenuobj.locatorforCarRentals };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() {  topMenuobj.Book, topMenuobj.CarRentals };
                List<String> ListOfMenuNames = new List<String>() { "Book", "Car Rentals" };

                MenuLevel1(ListOfMenuLocators, driver);

                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                //  Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URLForcarRentalsPage"]), "TravelServices Third Party site was not displayed  on selecting Car Rentals from top menu");

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforlink_CAR,driver), "TravelServices Third Party site was not displayed  on selecting Car Rentals from top menu");
                extentTest.Pass("TravelServices Third Party site was displayed  on selecting Car Rentals from top menu", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"PageDisplayed").Build());

               
               
                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforlink_CAR, driver), "Car rentals option was not enabled in the TravelServices Third Party site");
                extentTest.Pass("Car rentals option was enabled in the TravelServices Third Party site", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"CarRentals").Build());

                driver.Navigate().Back();

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            
        }



        public static void ValidateDirectExchangePage(string userName, TestContext testContextInstance)
        {
            
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            try
            {
                LoginPage loginPageObj = new LoginPage(driver);
                
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforTravelerPlusMain, topMenuobj.locatorforTravlerPlusSub };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.TravelerPlusMain, topMenuobj.TravlerPlusSub };

                //changes done by Fathima 

                MenuLevel1(ListOfMenuLocators, driver);
                
                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URLForTravelerPlusHomePage"]), "Traveler Plus Home Page was not displayed  on selecting the top menu");

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforTravelerPlusPage, driver), "Traveler Plus Home Page was not displayed  on selecting the top menu");
                extentTest.Pass("Traveler Plus Home Page was displayed  on selecting the top menu", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"TravelerPlusPage").Build());


                //changes done by Fathima
              //  ScrollToView(tpObj.link_DirectExchangeonTpPage, driver);
              
                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforlink_DirectExchangeonTpPage, driver), "The link for Direct exchanges was not present in Traveler Plus home page");
                extentTest.Pass("The link for Direct exchanges was present in Traveler Plus home page", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"DirectExchangeLink").Build());

                //tpObj.link_DirectExchangeonTpPage.Click();

               JavascriptClickElement(tpObj.link_DirectExchangeonTpPage, driver);

                Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforDirectExchangePage,driver), "Direct Exchanges Page was not shown on clicking DirectExchange link");
                extentTest.Pass("Direct Exchanges Page was shown on clicking DirectExchange link", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"DirectExchangePage").Build());

                List<string> fieldName;
                List<By> locatorForField;
                fieldName = new List<string> { "Heading Make your Direct Exchange reservations online--it's fast, easy and convenient.", "Resort Destinations Link", "Here Link to view Direct Exchange Program", "Book Now Button", "Prizzma Direct Logo", "Choice Ascend Collection Heading", "Learn More Table", "Choice Ascend Collection link", "Choice Privileges Link", "Ascend Collection Logo", " Link to Enroll for Choice Previliges", "Search Now button", "Link Disclosures-Prizzma", "Link Disclosures-Select Connections" };

                locatorForField = new List<By>() { tpObj.locatorforheading_MakeUrDirectExchange, tpObj.locatorforlink_resortDestinations, tpObj.locatorforlink_here, tpObj.locatorforbuttonBookNow, tpObj.locatorforIMG_prizzma, tpObj.locatorforHeading_ChoiceascendCollection, tpObj.locatorfortableLearnMore, tpObj.locatorforLinkChoiceAscendCollections, tpObj.locatorforLinkChoicePrivilges, tpObj.locatorforLogo_AscendHotelcollection, tpObj.locatorforEnrollHereLink_Intext_notYetMember, tpObj.locatorforSearchNow, tpObj.locatorforLinkDisclosuresPrizzma, tpObj.locatorforLinkDisclosuresSelectConnections };
                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayed(testContextInstance, fieldName, tpObj.pageName, locatorForField), "The essential fields were not displayed in Direct exchanges Page");
                /*
                 * upated code by Shivam
                 */
                //changes done by Fathima
                
               WaitForElementToBeClickable(tpObj.locatorforIMG_prizzma, driver).Click();
                extentTest.Info("Prizzma logo is clicked");

                
                driver.SwitchTo().Window(driver.WindowHandles[1]);

                Thread.Sleep(5000);
                // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                //GetWebdriverWait(driver).Until(GetElementFunc(tpObj.locatorforPrizzma));



                try
                {
                    Assert.IsTrue(IsSingleELementVisible(tpObj.locatorforPrizzma, driver), "Prizzma Direct Exchanges Screen was not shown On clicking Prizzma logo");
                   // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URLForPrizzmaDirectExchange"]), "Prizzma Direct Exchanges Screen was not shown On clicking Prizzma logo");
                    extentTest.Pass("Prizzma Direct Exchanges Screen was shown On clicking Prizzma logo", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"PrizzmaPage").Build());

                }

                catch (Exception exception)
                {
                    if (exception != null)
                    {
                        extentTest.Error("Error occured on Child window , switching back to parent window");
                        SwitchToParentWindow(driver);
                        throw new Exception("Error occured on Child window");

                    }

                }


                // driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
                driver.Close();

                driver.SwitchTo().Window(driver.WindowHandles[0]);

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond);

                // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

                ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
                windowHandles = driver.WindowHandles;


                //Ascend Hotel Collection Logo - should redirect the user to Choice Hotels Website

               WaitForElementToBeClickable(tpObj.locatorforLogo_AscendHotelcollection, driver).Click();
                //  tpObj.Logo_AscendHotelcollection.Click();
                
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                Thread.Sleep(5000);

                try
                {
                  //  Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforChoiceHotel, driver), "Choice Hotels Home Page was not shown On clicking  Ascend Hotel Collection logo");
                    Assert.IsTrue(driver.Url.ToLower().Contains(ConfigurationManager.AppSettings["URLForChoiceHotels"].ToLower()), "Choice Hotels Home Page was not shown On clicking  Ascend Hotel Collection logo");
                    extentTest.Pass("Choice Hotels Home Page was shown On clicking  Ascend Hotel Collection logo", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+ "ChoicePage").Build());
                }

                catch (Exception exception)
                {
                    if (exception != null)
                    {
                        extentTest.Error("Error occured on Child window , switching back to parent window");
                        SwitchToParentWindow(driver);
                        throw new Exception("Error occured on Child window");


                    }

                }

                //  driver.Close();

                driver.Close();
                // driver.SwitchTo().Window(driver.WindowHandles[0]).Close();

                driver.SwitchTo().Window(driver.WindowHandles[0]);

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
           
        }


        //verify Renew your Traveler Plus Membership page
        public static void ValidateRenewTPMembership(TestContext testContextInstance)
        {
          
            try
            {
                VSSAHomePage vssaPageObj = new VSSAHomePage(driver);

                string TPExpDate1 = DateTime.Parse(vssaPageObj.TPExpiration.Text.Trim()).ToString("M/dd/yyyy");

                VSSA_Click_loginAsUser_btn(vssaPageObj.locatorForloginAsUser, driver);
                extentTest.Info("Login as User button is clcicked");

                LoginPage loginPageObj = new LoginPage(driver);

                var expected = ConfigurationManager.AppSettings["loginSelectAccountUrl"];
                var actual = driver.Url;

                if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (loginPageObj.continueBtn == null) throw new ArgumentNullException(nameof(loginPageObj.continueBtn));
                    ClickButton(loginPageObj.continueBtn, driver);

                }

                HomePage homePageObj = new HomePage(driver);

                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorLogOffDivByXpath, driver), "User not able to login to BGO");
                extentTest.Pass("User logged into BGO", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"BGOHomePage").Build());


                AllMenus topMenuobj = new AllMenus(driver);

                List<IWebElement> ListOfMenuobjects1 = new List<IWebElement>() { topMenuobj.TravelerPlusMain, topMenuobj.TravlerPlusSub };
                List<IWebElement> ListOfMenuobjects2 = new List<IWebElement>() { topMenuobj.TravelerPlusMain, topMenuobj.RenewMemberShip };

                MenuLevel1(ListOfMenuobjects1, driver);

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["loginTPRenewUrl"]), "Renew your Traveler Plus Membership page is not displayed when Travel plus menu is selected");

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforRenewMyTPPage,driver), "Renew your Traveler Plus Membership page is not displayed when Travel plus menu is selected");
                extentTest.Pass("Renew your Traveler Plus Membership page is displayed when Travel plus menu is selected", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"RenewYourTPPage").Build());

                MenuLevel1(ListOfMenuobjects2, driver);

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["TPRenewUrl"]), "Renew your Traveler Plus Membership page is not displayed when Renew my membership menu is selected");

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforRenewMyTPPage, driver), "Renew your Traveler Plus Membership page is not displayed when Travel plus menu is selected");
                extentTest.Pass("Renew your Traveler Plus Membership page is displayed when Renew my membership menu  is selected", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"RenewYourTPPage").Build());

                List<IWebElement> ListOfTPRenewObj1 = new List<IWebElement>() { topMenuobj.PaymentOptionsFirstRadioBtn,topMenuobj.PaymentOptions,
                topMenuobj.PaymentOptionsSecondRadioBtn,topMenuobj.NameTxtField,topMenuobj.CardNumberTextField,topMenuobj.Zipcode,
                  topMenuobj.CheckForZipcode ,topMenuobj.SubmitButton};

                List<String> fieldName1 = new List<String>() { "Payment Options-RadioButton1 ","Payment Options label","Payment Options-RadioButton2","Name Text Field","Card Number Text Field",
                "Zipcode Text field","Check box for international zipcode","Submit Button"};

                int i = 0, j = 0;
                while (i < fieldName1.Count)
                {

                    while (j < ListOfTPRenewObj1.Count)
                    {
                        int count = 0;

                        if (count == 0)
                        {
                            Assert.IsTrue(IsSingleELementVisible(ListOfTPRenewObj1[j], driver), fieldName1[i] + " in Renew your Traveler Plus Membership page is missing");
                            extentTest.Pass(fieldName1[i] + " in Renew your Traveler Plus Membership page is displayed", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Fields").Build());

                            count = 1;
                        }
                        break;
                    }
                    i++;
                    j++;
                }

                List<IWebElement> ListOfTPRenewObj2 = new List<IWebElement>() { topMenuobj.CardType, topMenuobj.ExpMonth, topMenuobj.ExpYear };

                List<String> fieldName2 = new List<String>() { "Card Type", "Expiration Month dropdown List", "Expiration Year dropdown List" };

                int x = 0, y = 0;
                while (x < fieldName2.Count)
                {

                    while (y < ListOfTPRenewObj2.Count)
                    {
                        int count = 0;

                        if (count == 0)
                        {
                            Assert.IsTrue(IsSingleELementVisible(ListOfTPRenewObj2[y], driver), fieldName2[x] + " in Renew your Traveler Plus Membership page is missing");
                            extentTest.Pass(fieldName2[x] + " in Renew your Traveler Plus Membership page is displayed", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+x+"Fields").Build());

                            extentTest.Info(fieldName2[x] + "contains the following elements : " + ListOfTPRenewObj2[y].Text);
                            count = 1;
                        }
                        break;
                    }
                    x++;
                    y++;
                }


                TypeInTextBox(topMenuobj.NameTxtField, driver, Constants.Name);
                TypeInTextBox(topMenuobj.CardNumberTextField, driver, Constants.CardNumber);
                TypeInTextBox(topMenuobj.Zipcode, driver, Constants.zipcode);

                SelectElementByIndex(topMenuobj.ExpMonth, driver, Constants.RenewMyTPIndex);
                SelectElementByIndex(topMenuobj.ExpYear, driver, Constants.RenewMyTPIndex);

                ClickButton(topMenuobj.SubmitButton, driver);
                extentTest.Info("Submit button is clicked");

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["TPRenewConfirmationPage"]), "TP Member Renewal Confirmation page is not displayed");

                TravelerPlusPage tpObj = new TravelerPlusPage(driver);

                Assert.IsTrue(IsElementPresentUsingBy(tpObj.locatorforTPrenewalConfirmationPg,driver), "TP Member Renewal Confirmation page is not displayed");
                extentTest.Pass("TP Member Renewal Confirmation page is displayed", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"ConfirmationPage").Build());

                LogOff(homePageObj.logOffDiv, homePageObj.SignoutBtn, driver);
                extentTest.Info("Logged off from BGO");

                Goto_VSSA();
                extentTest.Info("VSSA home page is dispalyed");

                VSSA_EnterArvact(vssaPageObj.locatorForArvactnumber, driver, ReadData(104, "Arvact").ToString());
                VSSA_Click_SearchButton(vssaPageObj.locatorForSearchButton, driver);
                VSSA_Click_ArvactResultLink(vssaPageObj.locatorForarvactlink, driver);
                extentTest.Info("Arvact link is clicked");

                string TPExpDate2 = DateTime.Parse(vssaPageObj.TPExpiration.Text.Trim()).ToString("M/dd/yyyy");

                Assert.IsTrue(!TPExpDate1.Equals(TPExpDate2), "TP expiration is not updated in VSSA");
                extentTest.Pass("TP expiration is updated in VSSA", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"TPexpirationdate").Build());

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, DateTime.Now.ToString("MMddHHmmss_")+"Exception").Build());

                    Assert.Fail(e.Message);
                }
            }
            

        }

    }
}
