using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using BlueGreenOwner;
using POM.Classes;

namespace BlueGreenOwner.TestCases
{
    public class BonusReservation : LoginMethod
    {

        public static void BonusTimeReservation(string userName, TestContext testContextInstance, string destination, string selectdates, string wheelchair)
        {
            GlobalObjects globalObjects = new GlobalObjects(driver);

            try
            {
                //COMMON CODE FOR ALL TEST METHODS
                TestBaseClass.currentType = Constants.bonustype;
                TestBaseClass.initializeTestScripts(destination, selectdates, wheelchair, testContextInstance);


                LoginPage loginPageObj = new LoginPage(driver);
                //PageFactory.InitElements(driver, loginPageObj);


                //Navigate to Bonus Time Reservation Page
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforBonusTime };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.BonusTime };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Bonus Time" };

                MenuLevel2(ListOfMenuLocators, driver);
                extentTest.Info("Bonus time reservaton was selected");

                //flag to comapre the available points with points needed for booking
                // Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URlHomePageForBonusReservation"]), "Bonus Time menu was not selected");
               // extentTest.Info("Top Menu Navigation for Bonus time reservaton");

                HomePage homePageObj = new HomePage(driver);
                //.InitElements(driver, homePageObj);

                // Initialize Home Page objects,

                decimal TotalPriceForBooking = 0;
                decimal DailyPriceForBooking = 0;

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForBonusTimeRadioButton, driver, Constants.medLoadTime), "BonusTime Radio Buttion is not displayed or user did not reach homepage");
                Assert.IsTrue(homePageObj.BonusTimeRadioButton.Selected, "BonusTime Radio Buttion was not selected");
                extentTest.Pass("Bonus radio button select " + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonus_Radio_Button").Build());



                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
                //select the  destination, check in date,checkout date
                Assert.IsTrue(TestBaseClass.EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");
                extentTest.Pass("Entering search input" + "\r\n", AttachScrenshot(driver, testContextInstance, "Search_Input").Build());


                ////Verify input check in date is selected in home page

                Assert.IsTrue((IsElementPresentUsingBy(homePageObj.locatorForCheckInDate, driver, Constants.shortLoadTime)), "Check In date was not present");
                extentTest.Info("Check in date present ");

                homePageObj.ValCheckindate = homePageObj.CheckInDate.Text.Trim();
                string cin = DateTime.Parse(homePageObj.ValCheckindate).ToString("M/dd/yyyy");
                if (TestBaseClass.SelectDates.ToLower().Equals("yes"))
                {
                    Assert.IsTrue(cin.Equals(TestBaseClass.CheckInDate.Trim()), "The selected  check in date was not correct in the home page");
                    extentTest.Pass("Correct checkin date selected" + "\r\n", AttachScrenshot(driver, testContextInstance, "CheckIn_Date").Build());


                }



                //Verify input check out date is selected in home page
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForCheckOutDate, driver, Constants.shortLoadTime));
                extentTest.Info("Check out date present");

                homePageObj.ValCheckoutdate = homePageObj.CheckOutDate.Text.Trim();
                string cout = DateTime.Parse(homePageObj.ValCheckoutdate).ToString("M/dd/yyyy");
                if (TestBaseClass.SelectDates.ToLower().Equals("yes"))
                {
                    Assert.IsTrue(cout.Equals(TestBaseClass.CheckoutDate.Trim()), "The selected  check out date was not correct in the home page");
                    extentTest.Pass("Correct checkout date selected" + "\r\n", AttachScrenshot(driver, testContextInstance, "CheckOut_Date").Build());

                }
                ////Verify number of  nights in Home page

                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForNumNights, driver, Constants.shortLoadTime), "The number of nights field is not present in the home page");
                extentTest.Info("Number of night present");
                string[] dateSplit = new String[3];
                dateSplit = homePageObj.ValCheckindate.Split('/');
                DateTime cin1 = new DateTime(Convert.ToInt16(dateSplit[2]), Convert.ToInt16(dateSplit[0]), Convert.ToInt16(dateSplit[1]));
                dateSplit = homePageObj.ValCheckoutdate.Split('/');
                DateTime cout1 = new DateTime(Convert.ToInt16(dateSplit[2]), Convert.ToInt16(dateSplit[0]), Convert.ToInt16(dateSplit[1]));


                TimeSpan ts1 = cout1 - cin1;
                int diff1 = ts1.Days;
                homePageObj.ValNumNights = homePageObj.NumNights.Text;

                //compare the numbre of nights on homepage
                Assert.IsTrue(diff1.ToString().Equals(homePageObj.ValNumNights), "The number of nights shown is not correct");
                extentTest.Info("Correct number of nights shown :" + diff1.ToString());


                homePageObj.SearchButton.Click();
                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage(driver);

                //Search Results page displayed with resort locations listed 

                IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;
                ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);
                int IFlag = TestBaseClass.SearchBonusTimeFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);


                //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                Assert.IsTrue(((IFlag == 3) || (IFlag == 4)), "The Search Results Page was not displayed");
                extentTest.Pass("Search result page displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Search_Result_Page").Build());


                SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);


                ClickButton(SearchResultsObj.btnShowResortAvailability, driver);
                extentTest.Info("Show availablity button is clicked");

                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver, Constants.medLoadTime);

                GetWebdriverWait(driver, Constants.shortLoadTime).Until(JsFunc(driver));


                Assert.IsTrue(IsSingleELementVisible(SearchResultsObj.locatorForResultsTab, driver, Constants.shortLoadTime), "Avaialble resort details are not displayed");
                extentTest.Info("Available resorts are shown");
                IReadOnlyCollection<IWebElement> rows = SearchResultsObj.ResultsTab.FindElements(By.TagName("tr"));

                //Check total price is displayed is displayed in the serach results for first room .

                Assert.IsTrue(IsAllElementsVisible(SearchResultsObj.locatorForTotalPrice, driver, Constants.shortLoadTime), "The daily Price was not displayed");
                extentTest.Pass("Amount displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonus_Amount").Build());
                SearchResultsObj.TotalPrice = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForTotalPrice);
                SearchResultsObj.SRPTotalPrice = SearchResultsObj.TotalPrice.Text.Trim();
                SearchResultsObj.SRPTotalPrice = SearchResultsObj.SRPTotalPrice.Replace("$", "").Trim();
                SearchResultsObj.SRPTotalPrice = SearchResultsObj.SRPTotalPrice.Replace(",", "").Trim();
                TotalPriceForBooking = Convert.ToDecimal(SearchResultsObj.SRPTotalPrice.ToString());


                //Check daily price is dsiplayed is displayed in the serach results for first room .

                Assert.IsTrue(TestBaseClass.isElementVisible(SearchResultsObj.locatorForDailyRate, Constants.shortLoadTime), "The daily Price was not displayed");
                extentTest.Info("Daily rate is displayed");
                SearchResultsObj.DailyRate = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForDailyRate);
                SearchResultsObj.SRPDailyPrice = SearchResultsObj.DailyRate.Text.Trim();
                SearchResultsObj.SRPDailyPrice = SearchResultsObj.SRPDailyPrice.Replace("$", "").Trim();
                SearchResultsObj.SRPDailyPrice = SearchResultsObj.SRPDailyPrice.Replace(",", "").Trim();
                DailyPriceForBooking = Convert.ToDecimal(SearchResultsObj.SRPDailyPrice);

                //Check if book button is displayed and proceed with booking
                //IJavaScriptExecutor script = ((IJavaScriptExecutor)driver);
                //script.ExecuteScript("window.scrollBy(0,200)");
                SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);
                #region Updated code by Shivam Pathak
                JavascriptClickElement(SearchResultsObj.multiResultBookButton, driver);
                extentTest.Info("Book button is clicked");


                #endregion

                //SearchResultsObj.multiResultBookButton.Click();
                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);

                BonusTimeReservationPage confirmReservationPageObj = new BonusTimeReservationPage(driver);

                Assert.IsTrue(IsSingleELementVisible(confirmReservationPageObj.locatorforcardnum, driver, Constants.medLoadTime), "The BonusTime Reservation Page was not displayed");


                if (selectdates.ToLower().Equals("1night"))
                {
                    Assert.IsTrue(IsSingleELementVisible(confirmReservationPageObj.locatorForMsgInightStay, driver, Constants.medLoadTime), "The one night stay message was not displayed");
                    string msg = confirmReservationPageObj.MsgInightStay.Text.Trim();
                    Assert.IsTrue(msg.Equals(Constants.MessageForOnenightStayBonusTimeReservationPage), "The message" + Constants.MessageForOnenightStayBonusTimeReservationPage + "  was not displayed");
                    extentTest.Pass("The message" + Constants.MessageForOnenightStayBonusTimeReservationPage + "  was displayed", AttachScrenshot(driver, testContextInstance, "OneNight_Stay").Build());
                }

                //Verify the check in date on confirm reservation page is matching with alterante date selected  from search results page

                Assert.IsTrue(IsSingleELementVisible(confirmReservationPageObj.locatorForTableCoumn_CheckIn, driver, Constants.medLoadTime), "The check in date was not displayed in Bonus Time Reservation Page");
                extentTest.Info("CheckIn date displayed");
                confirmReservationPageObj.checkindate = confirmReservationPageObj.TableCoumn_CheckIn.Text.Trim();


                Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorForTableColumn_CheckOut, driver, Constants.medLoadTime), "The check out date was not displayed in Bonus Time Reservation Page");

                extentTest.Info("Checkout date displayed");
                confirmReservationPageObj.checkoutdate = confirmReservationPageObj.TableColumn_CheckOut.Text.Trim();

                Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorforLab_ResortName, driver, Constants.medLoadTime), "The resort name was not displayed in Bonus Time Reservation Page");
                confirmReservationPageObj.resortName = confirmReservationPageObj.Lab_ResortName.Text.Trim();

                //Compare Points with Points shown in Search results page

                if (!selectdates.ToUpper().Equals("1NIGHT"))
                {
                    Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorForTableColumn_Amount, driver, Constants.medLoadTime), "The amount was not displayed in Bonus Time Reservation Page");
                    confirmReservationPageObj.totalamount = confirmReservationPageObj.TableColumn_Amount.Text.Trim();
                    confirmReservationPageObj.totalamount = confirmReservationPageObj.totalamount.Replace(",", "").Trim();
                    confirmReservationPageObj.totalamount = confirmReservationPageObj.totalamount.Replace("$", "").Trim();
                    SearchResultsObj.SRPTotalPrice = SearchResultsObj.SRPTotalPrice.Replace("$", "").Trim();
                    SearchResultsObj.SRPTotalPrice = SearchResultsObj.SRPTotalPrice.Replace(",", "").Trim();

                }
                else
                {
                    Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorforLab_DailyRate, driver, Constants.medLoadTime), "The Daily rate was not displayed for the room in Bonus ReservationPage");
                    Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorforlocalTax, driver, Constants.medLoadTime), "The local tax was not displayed for the room in Bonus ReservationPage");
                    Assert.IsTrue(IsElementPresentUsingBy(confirmReservationPageObj.locatorfortotalPaymentAtTop, driver, Constants.medLoadTime), "The Total Payment was not displayed for the room in Bonus ReservationPage");
                    confirmReservationPageObj.dailyTax = confirmReservationPageObj.localTax.Text.Trim().Replace("$", "").Replace(",", "");
                    confirmReservationPageObj.dailyrate = confirmReservationPageObj.Lab_DailyRate.Text.Trim().Replace("$", "").Replace(",", "");
                    confirmReservationPageObj.totalamount = confirmReservationPageObj.totalPaymentAtTop.Text.Trim().Replace("$", "").Replace(",", "");
                    decimal dt = 0;
                    decimal dr = 0;
                    decimal tamt = 0;

                    dt = Convert.ToDecimal(confirmReservationPageObj.dailyTax);
                    dr = Convert.ToDecimal(confirmReservationPageObj.dailyrate);
                    decimal Val = Convert.ToDecimal(confirmReservationPageObj.totalamount);
                    tamt = 2 * (dt + dr);
                    tamt = Math.Truncate(tamt);
                    Val = Math.Truncate(Val);
                    Assert.IsTrue((tamt.Equals(Val)), "TotalPrice" + confirmReservationPageObj.totalPaymentAtTop.Text + " was not twice sum of daily rate and daily tax" + tamt + "in Bonus ReservationPage");
                    extentTest.Pass("TotalPrice" + confirmReservationPageObj.totalPaymentAtTop.Text + " was twice sum of daily rate and daily tax" + tamt + "in Bonus ReservationPage" + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonusrates").Build());
                }



                //Add all Details on confirm reservation page

                Assert.IsTrue(TestBaseClass.fillContactandCreditCardDetailsInBonusTimeReservationPage(testContextInstance, confirmReservationPageObj), "The reservation,billing information or the Payment Informations section are not filled up correctly ");

                ReservationConfirmationPage rcObj = new ReservationConfirmationPage(driver);


                ////Check that Confirmation Page is displayed .

                Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForConfirmationNumber, driver, Constants.medLoadTime), "The Reservation Confirmation Page was not displayed");
                Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ConfirmationNumber.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ConfirmationNumber.Text)), "The Reservation Confirmation Number was not displayed for Bonus Time Reservation");
                TestBaseClass.currentconfirmationNumber = rcObj.ConfirmationNumber.Text;
                //Check Confimration Date
                Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForConfirmationDate, driver, Constants.medLoadTime), "The confirmation date was not shown in Bonus time Reservation Confirmation Page");

                Assert.IsTrue(rcObj.ConfirmationDate.Text.Equals(DateTime.Now.ToString("MM/dd/yyyy").ToString()), "The confirmation date was not todays date  in Confirmation page");
                extentTest.Info("Today's confrimation displayed on confirmation page");

                ////Validate resort  name

                Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForResortName, driver, Constants.medLoadTime), "The Resort Name was not shown on Bonus type reservation page");

                Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ResortName.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ResortName.Text)));
                rcObj.CPResortName = rcObj.ResortName.Text.Trim();
                TestBaseClass.currentResortName = rcObj.CPResortName;
                Assert.IsTrue(rcObj.CPResortName.Equals(confirmReservationPageObj.resortName));
                extentTest.Info("Resortname is displayed on confirmation page");

                ////Check the check in   date is displayed in confirmation Page

                rcObj.checkindate = rcObj.CheckInDate.Text.Trim();
                TestBaseClass.currentcheckInDate = rcObj.checkindate;

                Assert.IsTrue(rcObj.checkindate.Equals(confirmReservationPageObj.checkindate));
                extentTest.Info("Checkin date is displayed on confirmation page");

                ////Check the check out  date is displayed in confirmation Page

                rcObj.checkoutdate = rcObj.CheckOutDate.Text.Trim();
                TestBaseClass.currentcheckOutDate = rcObj.checkoutdate;
                Assert.IsTrue(rcObj.checkoutdate.Equals(confirmReservationPageObj.checkoutdate));
                extentTest.Info("Checkout date is displayed on confirmation page");


                ////Validate Guest Checking in
                Assert.IsTrue(rcObj.GuestCheckingIn.Text.Trim().Replace(",", "").Equals(TestBaseClass.guestCheckingName.Replace(",", "")));
                extentTest.Info("Guest Checking in name is displayed on confirmation page");


                //// //Validate Guest Num

                Assert.IsTrue(rcObj.GuestCount.Text.Trim().Equals(Constants.NoOfGuests), "The number of Guests was not " + Constants.NoOfGuests);
                extentTest.Info("The number of Guests is " + Constants.NoOfGuests);

                //Validate Special Requests
                Assert.IsTrue(rcObj.SpecialRequest.Text.Trim().Equals(Constants.valSpecialRequest), "The special request was not " + Constants.valSpecialRequest);
                extentTest.Info("The special request is " + Constants.valSpecialRequest);

                
                // Check total price and daily price after booking

                rcObj.totalamount = rcObj.Amt.Text.Trim();
                rcObj.totalamount = rcObj.totalamount.Replace("$", "").Replace(",", "");
                TestBaseClass.currentAmount = rcObj.totalamount;
                decimal ConfimrmationTotAmount = 0;
                decimal BReservationTotAmount = 0;

                ConfimrmationTotAmount = Convert.ToDecimal(confirmReservationPageObj.totalamount);
                BReservationTotAmount = Convert.ToDecimal(rcObj.totalamount);


                //verify the total price displayed in confirmation page

                Assert.IsTrue((ConfimrmationTotAmount == BReservationTotAmount), "TotalPrice " + BReservationTotAmount + "in confirmation page is not matching" + ConfimrmationTotAmount);
                extentTest.Info("TotalPrice " + BReservationTotAmount + " in confirmation page is  matching " + ConfimrmationTotAmount + " shown in Confirmation page");


                Assert.IsTrue(TestBaseClass.validateReservationDetails(testContextInstance), "The Reservation details were not correctly shown in My Reservations Page");

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }
            }


        }

        //bonus time resend email itenary

        public static void ResendEmailforBonusTypeReservation(string userName, TestContext testContextInstance)
        {
            try
            {
                HomePage homePageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                Assert.IsTrue(TestBaseClass.BonusTimeReservationLogic(userName, testContextInstance, "no", "no", "no"), "Bonus Reservation was not successful.Hence cannot continue execution");
                extentTest.Pass("Bonus Reservation is successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonusreservation_Success").Build());

                Assert.IsTrue(TestBaseClass.ResendEmailItenarary(testContextInstance, Constants.bonustype, TestBaseClass.currentconfirmationNumber), "Resend Email Itinerary was not successful");
                extentTest.Pass("BResend Email Itinerary is not successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Resendemail").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }
            }


        }

        //cancel bonus time reservation

        public static void CancelBonusTimeReservationWithinGP(string userName, TestContext testContextInstance, string destination, string selectdates, string wheelchair)
        {
            try
            {
                HomePage homePageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                Assert.IsTrue(TestBaseClass.BonusTimeReservationLogic(userName, testContextInstance, "no", "no", "no"), "Bonus Reservation was not successful.Hence cannot continue execution");
                extentTest.Pass("Bonus Reservation is successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonusreservation").Build());
                
                Assert.IsTrue(TestBaseClass.CancelPointsOrBonusReservation(testContextInstance, Constants.bonustype), "Cancel Bonus Reservation was not successful");
                extentTest.Pass("Cancel Bonus Reservation was successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Cancel_Bonusreservation").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }

            }



        }

    }
}
