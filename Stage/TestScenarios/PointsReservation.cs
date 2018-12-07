using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NLog;
using POM.Classes;
using OpenQA.Selenium.Support.UI;

namespace BlueGreenOwner.TestCases
{
    public class PointsReservation : LoginMethod
    {

        public static void PointReservationWithOrWithOutPPP(string userName, TestContext testContextInstance, bool ProtectionType, string destination, string selectdates, string wheelchair)
        {

            GlobalObjects globalObjects = new GlobalObjects(driver);

            try
            {
                TestBaseClass.currentType = Constants.pointstype;


                TestBaseClass.initializeTestScripts(destination, selectdates, wheelchair, testContextInstance);


                LoginPage loginPageObj = new LoginPage(driver);



                //Navigate to Point Type Reservation Page
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.Points };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Points" };

                //flag to comapre the available points with points needed for booking
                bool compareFlag = false;
                Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URlHomePage"]), "Points menu was not selected");

                extentTest.Pass("Point radio button selected" + "\r\n", AttachScrenshot(driver, testContextInstance, "Radio_Button").Build());


                HomePage homePageObj = new HomePage(driver);


                // Initialize Home Page objects

                List<string> fieldName;
                List<IWebElement> Objects;
                int TotalPoints = 0;

                int PointsForBookinginSearchPage = 0;

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForPointsButton, driver, Constants.medLoadTime));
                extentTest.Info("Points radio button is visible");
                Assert.IsTrue(homePageObj.PointsRadioButton.Selected, "Points Radio Buttion was not selected");
                extentTest.Info("Points radio button selected");

                //Note down Available points 

                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForCurrentPoints, driver, Constants.medLoadTime), "Current Points was not displayed");
                extentTest.Pass("Points are visible" + "\r\n", AttachScrenshot(driver, testContextInstance, "Points").Build());

                homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();
                Assert.IsTrue(!(homePageObj.CurrentPointsVal.Equals("null")), "The avaiable points shown was null");
                extentTest.Info("Points available is not null");


                homePageObj.CurrentPointsVal = homePageObj.CurrentPointsVal.Replace("points", "").Replace(",", "").Trim();
                TotalPoints = Convert.ToInt32(homePageObj.CurrentPointsVal);


                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
                //Thread.Sleep(2000);
                //select the  destination, check in date,checkout date
                Assert.IsTrue(TestBaseClass.EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");
                extentTest.Pass("Search criteria entered" + "\r\n", AttachScrenshot(driver, testContextInstance, "Search").Build());

                ////Verify input check in date is selected in home page

                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForCheckInDate, driver, Constants.shortLoadTime), "Check In date was not present");
                extentTest.Info("CheckIn date present");

                homePageObj.ValCheckindate = homePageObj.CheckInDate.Text.Trim();
                string cin = DateTime.Parse(homePageObj.ValCheckindate).ToString("M/dd/yyyy");
                if ((TestBaseClass.SelectDates.ToLower().Equals("yes")) || (TestBaseClass.SelectDates.ToLower().Equals("7nightstay")))
                {
                    Assert.IsTrue(cin.Equals(TestBaseClass.CheckInDate.Trim()), "The selected  check in date was not correct in the home page");
                    extentTest.Info("CheckIn date selected");


                }

                //Verify input check out date is selected in home page
                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForCheckOutDate, driver, Constants.shortLoadTime));
                extentTest.Info("Checkout date present");
                homePageObj.ValCheckoutdate = homePageObj.CheckOutDate.Text.Trim();
                string cout = DateTime.Parse(homePageObj.ValCheckoutdate).ToString("M/dd/yyyy");
                if ((TestBaseClass.SelectDates.ToLower().Equals("yes")) || (TestBaseClass.SelectDates.ToLower().Equals("7nightstay")))
                {
                    Assert.IsTrue(cout.Equals(TestBaseClass.CheckoutDate.Trim()), "The selected  check out date was not correct in the home page");
                    extentTest.Info("Check out date selected");

                }
                ////Verify number of  nights in Home page

                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForNumNights, driver, Constants.shortLoadTime), "The number of nights field is not present in the home page");
                extentTest.Info("Number of nights present");
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
                extentTest.Pass("Number of nights correctly selected" + "\r\n", AttachScrenshot(driver, testContextInstance, "Selected_Nights").Build());

                homePageObj.SearchButton.Click();
                extentTest.Info("Search button is clicked");
                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage();
                PageFactory.InitElements(driver, SearchResultsObj);
                //for 7 nights stay verify the message

                if (TestBaseClass.SelectDates.ToLower().Equals("7nightstay"))
                {
                    Assert.IsTrue(IsSingleELementVisible(SearchResultsObj.locatorForMsg7NightsStay, driver, Constants.medLoadTime));
                    extentTest.Info("Selected 7 nights stay");
                    string msg = SearchResultsObj.Msg7NightsStay.Text.Trim();
                    string[] strarr = new string[3];
                    strarr = msg.Split('.');
                    msg = strarr[0].Replace(" ", "") + "." + strarr[1].Replace(" ", "") + "." + strarr[2].Replace(" ", "") + ".";
                    Assert.IsTrue(Constants.MessageFor7nightStaySearchResultsPage.Replace(" ", "").Equals(msg.Replace(" ", "")), "The 7 nights message was not shown on the search results page");
                    extentTest.Pass("Message for 7 nights message shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "7Nigts_stay").Build());
                }
                //Search Results page displayed with resort locations listed 

                ////Verify that the wheel chair if said to set
                if (TestBaseClass.WheeelChairAccess.ToLower().Equals("yes"))
                {

                    Assert.IsTrue((IsSingleELementVisible(SearchResultsObj.locatorForLabelWheelChairAccess, driver, Constants.shortLoadTime)), "Wheel Chair Box  was not present in the Search Results");
                    extentTest.Pass("Wheel chair option present" + "r\n", AttachScrenshot(driver, testContextInstance, "WheelChairoption").Build());
                    SearchResultsObj.labelWheelChairAccess.Click();
                    Assert.IsTrue(SearchResultsObj.CheckBoxWheelChairAccess.Selected, "On selecting the accessible option, Wheel Chair Access check  Box was not selected");
                    extentTest.Info("WheelChair option selected");

                }

                IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;
                ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);
                int IFlag = TestBaseClass.SearchFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);


                //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                Assert.IsTrue(((IFlag == 3) || (IFlag == 4)), "Unexpected alert");

                SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);

                #region update code by Shivam Pathak
                ClickButton(SearchResultsObj.btnShowResortAvailability, driver);
                extentTest.Info("Clicked on show resort availability");

                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver, Constants.medLoadTime);
                GetWebdriverWait(driver).Until(JsFunc(driver));
                #endregion

                Assert.IsTrue(IsSingleELementVisible(SearchResultsObj.locatorForResultsTab, driver, Constants.shortLoadTime), "Resort list not displayed");
                extentTest.Pass("Resort details expanded" + "\r\n", AttachScrenshot(driver, testContextInstance, "Resortdetails").Build());
                IReadOnlyCollection<IWebElement> rows = GetElement(SearchResultsObj.ResultsTab).FindElements(By.TagName("tr"));

                //Thread.Sleep(4000);
                Assert.IsTrue(rows.Count > 0, "Search Results table was empty");//Search results are displayed
                extentTest.Info("Resort datails present");

                //Check avaialble points is displayed in the serach results for first room of last resort
                Assert.IsTrue((TestBaseClass.isElementVisible(SearchResultsObj.locatorForMultiResultPointsLink, Constants.medLoadTime)), "The points required for the room were not shown in the serach details page");
                extentTest.Pass("Points for resort shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "Resort_Points").Build());
                SearchResultsObj.multiResultPointsLink = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultPointsLink);

                SearchResultsObj.multiResultPointsLink.Click();
                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);

                SearchResultsObj.SRPPoints = SearchResultsObj.multiResultPointsLink.Text.Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", "").Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();
                PointsForBookinginSearchPage = Convert.ToInt32(SearchResultsObj.SRPPoints);


                ////Verify the available points is greater than points needed for booking
                ////compare avaialble points is greater than or equal to points needed for reservation shown in search results page

                if (!((String.IsNullOrEmpty(homePageObj.CurrentPointsVal))) || ((String.IsNullOrEmpty(SearchResultsObj.SRPPoints))))
                {
                    //doing this to check book buuton is enabled for booking or  not
                    Assert.IsTrue(TotalPoints >= PointsForBookinginSearchPage, "The available points " + TotalPoints + "is not greater than that required for booking" + PointsForBookinginSearchPage);
                    extentTest.Pass("Available points are lesser then required" + "\r\n", AttachScrenshot(driver, testContextInstance, "Not Enough points").Build());

                    compareFlag = true;
                }
                else
                    compareFlag = false;

                //Check if book button is displayed and proceed with booking
                GetWebdriverWait(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(globalObjects.locatorforLoadingIcon));


                SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);


                JavascriptClickElement(SearchResultsObj.multiResultBookButton, driver);

                extentTest.Info("Book button is clicked");

                ConfirmReservationPointType confirmReservationPageObj = new ConfirmReservationPointType(driver);
                //SearchResultsObj.multiResultBookButton.Click();

                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);

                if (IsAllElementsPresent(SearchResultsObj.locatorfuturePointsContinue, driver) && IsButtonEnabled(SearchResultsObj.locatorfuturePointsContinue,driver))
                {
                    extentTest.Info("Future points option displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Futurepoints_buttton").Build());
                    ClickButton(SearchResultsObj.futurePointsContinue, driver);

                }
                else if (IsElementPresent(globalObjects.LocatorForGlobalError, driver))


                {
                    extentTest.Error("Error due to test account have come "+ "\r\n", AttachScrenshot(driver, testContextInstance, "Current_Status").Build());

                    throw  new Exception("Test data is not good");

                }

                else if (IsElementPresent(globalObjects.LocatorforSavePointsbtn, driver) && IsElementPresent(confirmReservationPageObj.locatorForMsg_NotEnoughPoints, driver))

                {

                    extentTest.Error("Save My points and not enough points alert is present" + "\r\n", AttachScrenshot(driver, testContextInstance, "Savepoints_Notenoughpoints").Build());

                   throw new Exception("Save My points and not enough points alert is present");

                }



                else if (GetElement(confirmReservationPageObj.locatorForBtn_SubmitReservation, driver).Displayed && (compareFlag))
                {
                    //Verify the check in date on confirm reservation page is matching with alterante date selected  from search results page


                    SubmitReservationPage(testContextInstance, ProtectionType, out fieldName, out Objects, TotalPoints, SearchResultsObj, confirmReservationPageObj);
                }
                else
                {
                    extentTest.Error("Not enough points to book or Submit  button not displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    throw new Exception("Not enough points to book or Submit  button not displayed");

                }

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

        private static void SubmitReservationPage(TestContext testContextInstance, bool ProtectionType, out List<string> fieldName, out List<IWebElement> Objects, int TotalPoints, SearchResultsPage SearchResultsObj, ConfirmReservationPointType confirmReservationPageObj)
        {
            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorForTableCoumn_CheckIn, driver));
            extentTest.Pass("Confirm reservation page displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Confirm_Reservation_Page").Build());
            confirmReservationPageObj.checkindate = confirmReservationPageObj.TableCoumn_CheckIn.Text.Trim();


            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorForTableColumn_CheckOut, driver));
            extentTest.Info("Checkout date is present");
            confirmReservationPageObj.checkoutdate = confirmReservationPageObj.TableColumn_CheckOut.Text.Trim();

            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorforLab_ResortName, driver));
            extentTest.Info("Resort name is present");
            confirmReservationPageObj.resortName = confirmReservationPageObj.Lab_ResortName.Text.Trim();

            //Compare Points with Points shown in Search results page
            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorForTableColumn_Amount, driver), "Points for resorts are not visible");
            extentTest.Info("Points are present");
            confirmReservationPageObj.points = confirmReservationPageObj.TableColumn_Amount.Text.Trim();
            confirmReservationPageObj.points = confirmReservationPageObj.points.Replace(",", "").Trim();
            confirmReservationPageObj.points = confirmReservationPageObj.points.Replace("Points", " ").Trim();
            SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", " ").Trim();
            SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();

            //Add Guest Details on confirm reservation page
            // TestBaseClass.ScrollUsingJavaScript("0", "document.body.scrollHeight");

            fieldName = new List<string> { "Guest Checking in", "Special Requests", "Check Box Near text  I have read, understand and agree to the reservation details above including important notes and the Points reservation Terms and Conditions.", "Confirm My reservation Button", "No of Guests", "Plus button to add guests" };
            Objects = new List<IWebElement> { confirmReservationPageObj.Select_GuestCheckingInDefaultBtn, confirmReservationPageObj.Feild_specialRequests, confirmReservationPageObj.Chk_Agreement, confirmReservationPageObj.Btn_SubmitResrvation, confirmReservationPageObj.Field_NumberOfGuests, confirmReservationPageObj.Btn_PlusNumberOfGuests };

            confirmReservationPageObj.Select_GuestCheckingInDefaultBtn.Click();
            fieldName.Clear();
            fieldName = new List<string>() { "Owner option1" };
            Objects = new List<IWebElement> { confirmReservationPageObj.Option_Owner1 };


            confirmReservationPageObj.guestCheckingName = confirmReservationPageObj.Option_Owner1.Text.Trim();
            confirmReservationPageObj.Option_Owner1.Click();
            confirmReservationPageObj.Feild_specialRequests.SendKeys(Constants.valSpecialRequest);
            confirmReservationPageObj.Chk_Agreement.Click();
            confirmReservationPageObj.specialrequests = confirmReservationPageObj.Feild_specialRequests.Text.Trim();

            int numGuests = Convert.ToInt16(2);
            int i = 0;
            while (i < numGuests)
            {
                confirmReservationPageObj.Btn_PlusNumberOfGuests.Click();
                //Thread.Sleep(1000);
                i++;

            }


            IJavaScriptExecutor executor = (IJavaScriptExecutor)TestBaseClass.baseDriver;
            var javaScriptNumGuests = executor.ExecuteScript("return window.document.getElementById('Guest_NumberOfGuest').getAttribute('aria-valuenow')");
            confirmReservationPageObj.numberOfGuests = javaScriptNumGuests.ToString();
            confirmReservationPageObj.Btn_SubmitResrvation.Submit();
            fieldName.Clear();
            fieldName = new List<string>() { "Owner option1", "No Of Requests", "Special Requests" };

            PointsProtectionPlanPage pppObj = new PointsProtectionPlanPage(driver);




            if (!ProtectionType)//WITH OUT PPP
            {

                //byepass ppp page
                TestBaseClass.WithPPP = false;
                IsElementPresent(pppObj.locatorforLink_PPPNoThankYou, driver);
                Assert.IsTrue(IsElementPresent(pppObj.locatorforLink_PPPNoThankYou, driver), "The No thank You Link was not present in the Protect points Page");
                extentTest.Pass("No thank you link present" + "\r\n", AttachScrenshot(driver, testContextInstance, "No_ThankYou_Link").Build());
                Assert.IsTrue(TestBaseClass.isElementClickable(pppObj.Link_PPPNoThankYou, Constants.medLoadTime), "The No thank You Link was not clickable in the Protect points Page");

                pppObj.Link_PPPNoThankYou.Click();

                extentTest.Info("No thank you link clicked ");

                Assert.IsTrue(IsSingleELementVisible(pppObj.locatorForBtn_IamNotInterested, driver, Constants.medLoadTime), "The Iam Not interested Button was not  displayed in protect Points Page");
                extentTest.Pass("Without PPP Button is present" + "\r\n", AttachScrenshot(driver, testContextInstance, "Iam_Not Intrested").Build());

                Assert.IsTrue(TestBaseClass.isElementClickable(pppObj.Btn_IamNotInterested, Constants.medLoadTime), "The Iam Not interested Button was not clickable in the Protect points Page");


                pppObj.Btn_IamNotInterested.Click();
                extentTest.Info("Without PPP Button is clicked");
            }
            else
            {
                //verifyu PPP page
                TestBaseClass.WithPPP = true;
                Assert.IsTrue(IsSingleELementVisible(pppObj.locatorfortextBox_CreditCardName, driver, Constants.medLoadTime));
                fieldName = new List<string> { "Name", "CardNumber", "CVV", "ExpirationMonth", "ExpirationYear", "BillingZip/PostalCode", "AgreementCheckBox", "ProtectMyPointsButton", "International ZipCode CheckBox" };
                Objects = new List<IWebElement> { pppObj.textBox_CreditCardName, pppObj.TextBox_CreditCardNumber, pppObj.TextBox_CVV, pppObj.Select_ExpirationMonth, pppObj.Select_ExpiratonYear, pppObj.TextBox_ZipCode, pppObj.ChkBox_PPPAgreement, pppObj.Btn_ProtectMyPoints, pppObj.ChkBox_InternationalZipCode };
                Assert.IsTrue(TestBaseClass.fillCreditCardDetailsPPPPage(pppObj, testContextInstance), "The PPP from filling  was not successful");
                extentTest.Pass("Credit card details filled" + "\r\n", AttachScrenshot(driver, testContextInstance, "Credicard_details_filled").Build());
                Assert.IsTrue(TestBaseClass.SubmitPPPForm(pppObj), " The PPP submission was not successful");
                extentTest.Pass("PPP submission successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPP_Successful").Build());

            }


            ReservationConfirmationPage rcObj = new ReservationConfirmationPage(driver);


            //Check that Confirmation Page is displayed on clciking Protect My Points Button.
            Assert.IsTrue(IsSingleELementVisible(rcObj.locatorForConfirmationNumber, driver, Constants.medLoadTime), "The Reservation Confirmation Page was not displayed");
            extentTest.Pass("Reservation Confirmation page displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "ConfirmationPage").Build());
            Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ConfirmationNumber.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ConfirmationNumber.Text)), "The Reservation Confirmation Number was not displayed");
            extentTest.Info("Reservation number displayed");
            TestBaseClass.currentconfirmationNumber = rcObj.ConfirmationNumber.Text;
            //Check Confimration Date
            Assert.IsTrue(IsElementPresent(rcObj.locatorForConfirmationDate, driver), "The confirmation date was not shown in Reservation Confirmation Page");


            Assert.IsTrue(rcObj.ConfirmationDate.Text.Equals(DateTime.Now.ToString("MM/dd/yyyy").ToString()));
            extentTest.Info("Today's confimration date displayed");


            //Validate resort  name

            Assert.IsTrue(IsElementPresent(rcObj.locatorForResortName, driver));


            Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ResortName.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ResortName.Text)));

            rcObj.CPResortName = rcObj.ResortName.Text.Trim();
            TestBaseClass.currentResortName = rcObj.CPResortName;
            Assert.IsTrue(rcObj.CPResortName.Equals(confirmReservationPageObj.resortName));
            extentTest.Info("Resort is same as selected");


            //Validate the Points are same in Confirmation Page as well

            Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ValPointsUsed.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ValPointsUsed.Text)));
            rcObj.pointsUsed = rcObj.ValPointsUsed.Text.Replace(",", "").Trim();
            TestBaseClass.currentAmount = rcObj.pointsUsed;
            Assert.IsTrue(rcObj.pointsUsed.Equals(confirmReservationPageObj.points));
            //TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The  resortname  on Confirmation page is same as that in the confirm reservation page");


            ////Validate Points Protected label

            if ((ProtectionType))//WITH OUT PPP
            {
                Assert.IsTrue(rcObj.Lab_ProtectedOrNot.Text.Equals("| points protected"));
                extentTest.Pass("PPP Status is shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPPStatus").Build());

            }




            rcObj.checkindate = rcObj.CheckInDate.Text.Trim();
            TestBaseClass.currentcheckInDate = rcObj.checkindate;

            Assert.IsTrue(rcObj.checkindate.Equals(confirmReservationPageObj.checkindate));
            extentTest.Info("CheckIn date is same as selected");


            //Check the check out  date is displayed in confirmation Page

            rcObj.checkoutdate = rcObj.CheckOutDate.Text.Trim();
            TestBaseClass.currentcheckOutDate = rcObj.checkoutdate;
            Assert.IsTrue(rcObj.checkoutdate.Equals(confirmReservationPageObj.checkoutdate));
            extentTest.Info("CheckOut date is same as selected");

            //Validate Guest Checking in
            Assert.IsTrue(rcObj.GuestCheckingIn.Text.Trim().Replace(",", "").Equals(confirmReservationPageObj.guestCheckingName.Replace(",", "")));
            extentTest.Pass("Guest name correctly shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "GuestName").Build());

            //// //Validate Guest Num

            Assert.IsTrue(rcObj.GuestCount.Text.Trim().Equals(Constants.NoOfGuests), "The number of Guests was not " + Constants.NoOfGuests);
            extentTest.Info("Number of guest shown");

            //Validate Special Requests
            Assert.IsTrue(rcObj.SpecialRequest.Text.Trim().Equals(Constants.valSpecialRequest), "The special request was not " + Constants.valSpecialRequest);
            extentTest.Info("special request was shown");


            Businesslogic.PointsUsedForBooking = Int32.Parse(TestBaseClass.currentAmount);

            Assert.IsTrue(Businesslogic.PointBalanceLogic(TotalPoints, Businesslogic.PointsUsedForBooking, testContextInstance, driver), "Correct point balance displayed wrongly");

            //extentTest.Pass("Correct points balance displayed :" + expectedRemainingPoints + "\r\n", AttachScrenshot(driver, testContextInstance, "Points_Balance").Build());
            Assert.IsTrue(TestBaseClass.validateReservationDetails(testContextInstance), "The Reservation details were not correctly shown in My Reservations Page"); // this line of code took more time.
            extentTest.Info("Correct reseravtion details shown");
        }

        public static void PointReservationErrorMessage(string userName, TestContext testContextInstance)
        {

            GlobalObjects globalObjects = new GlobalObjects(driver);

            try
            {

                TestBaseClass.initializeTestScripts("no", "no", "no", testContextInstance);

                LoginPage loginPageObj = new LoginPage(driver);

                //Navigate to Point Type Reservation Page
                AllMenus topMenuobj = new AllMenus(driver);


                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.Points };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Points" };

                //flag to comapre the available points with points needed for booking
                bool compareFlag = false;
                Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URlHomePage"]), "Points menu was not selected");
                extentTest.Pass("Point radio button selected" + "\r\n", AttachScrenshot(driver, testContextInstance, "Radio_Button").Build());


                HomePage homePageObj = new HomePage(driver);

                // Initialize Home Page objects

                int TotalPoints = 0;
                int PointsForBookinginSearchPage = 0;

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForPointsButton, driver, Constants.medLoadTime));
                Assert.IsTrue(homePageObj.PointsRadioButton.Selected, "Points Radio Buttion was not selected");
                extentTest.Info("Points radio button selected");

                //Note down Available points 

                Assert.IsTrue(IsElementPresent(homePageObj.locatorForCurrentPoints, driver), "Current Points was not displayed");
                extentTest.Pass("Points are visible" + "\r\n", AttachScrenshot(driver, testContextInstance, "Points").Build());


                homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();
                Assert.IsTrue(!(homePageObj.CurrentPointsVal.Equals("null")), "The avaiable points shown was null");
                extentTest.Info("Current points is not null");


                homePageObj.CurrentPointsVal = homePageObj.CurrentPointsVal.Replace("points", "").Replace(",", "").Trim();
                TotalPoints = Convert.ToInt32(homePageObj.CurrentPointsVal);


                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
                //Thread.Sleep(2000);
                //select the  destination, check in date,checkout date
                Assert.IsTrue(TestBaseClass.EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");
                extentTest.Pass("Search criteria entered" + "\r\n", AttachScrenshot(driver, testContextInstance, "Search_Criteria").Build());
                homePageObj.SearchButton.Click();
                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage(driver);
                //PageFactory.InitElements(driver, SearchResultsObj);

                //Search Results page displayed with resort locations listed 

                IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;
                ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);
                int IFlag = TestBaseClass.SearchFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);


                //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                Assert.IsTrue(((IFlag == 3) || (IFlag == 4)), "The Search Results was not displayed properly");
                extentTest.Pass("Search result displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "search_result").Build());

                SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);
                //check that the btnShowResortAvailability is not null elemet

                #region Updated code by Shivam Pathak

                ClickButton(SearchResultsObj.btnShowResortAvailability, driver);
                extentTest.Info("Show availability button is clicked");
                //Extends_TestBaseClass.ClickUsingJavaScript(SearchResultsObj.btnShowResortAvailability);

                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver, Constants.medLoadTime);
                JsFunc(driver);
                #endregion
                //SearchResultsObj.btnShowResortAvailability.Click();
                //Assert.IsTrue(IsElementVisible(SearchResultsObj.ResultsTab,driver, Constants.shortLoadTime), "Click on Show Resort Avaialblity button and check that avaialble resort details are displayed");
                extentTest.Info("Available resort displayed");

                IReadOnlyCollection<IWebElement> rows = GetElement(SearchResultsObj.ResultsTab).FindElements(By.TagName("tr"));
                //Thread.Sleep(4000);
                Assert.IsTrue(rows.Count > 0);//Search results are displayed
                extentTest.Info("Resort available for booking");
                //Check avaialble points is displayed in the serach results for first room of last resort
                Assert.IsTrue(IsElementPresent(SearchResultsObj.locatorForMultiResultPointsLink, driver), "The Points link was not displayed");
                extentTest.Info("Points linked was displayed");
                SearchResultsObj.multiResultPointsLink = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultPointsLink);



                JavascriptClickElement(SearchResultsObj.multiResultPointsLink, driver);
                extentTest.Info("Book button is clicked");

                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);




                SearchResultsObj.SRPPoints = SearchResultsObj.multiResultPointsLink.Text.Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", "").Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();
                PointsForBookinginSearchPage = Convert.ToInt32(SearchResultsObj.SRPPoints);


                ////Verify the available points is greater than points needed for booking
                ////compare avaialble points is greater than or equal to points needed for reservation shown in search results page

                if (!((String.IsNullOrEmpty(homePageObj.CurrentPointsVal))) || ((String.IsNullOrEmpty(SearchResultsObj.SRPPoints))))
                {
                    //doing this to check book buuton is enabled for booking or  not
                    if (TotalPoints < PointsForBookinginSearchPage)
                        extentTest.Info("Not enough points to book");

                    compareFlag = true;
                }
                else
                    compareFlag = false;

                //Check if book button is displayed and proceed with booking
                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);
                SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);


                #region Updated code by Shivam Pathak

                JavascriptClickElement(SearchResultsObj.multiResultBookButton, driver);
                extentTest.Info("Book button is clicked");


                IsElementInvisible(globalObjects.locatorforLoadingIcon, driver);
                #endregion
                //SearchResultsObj.multiResultBookButton.Click();
                ConfirmReservationPointType confirmReservationPageObj = new ConfirmReservationPointType(driver);




                Assert.IsTrue(IsSingleELementVisible(confirmReservationPageObj.locatorForMsg_NotEnoughPoints, driver, Constants.medLoadTime) && (compareFlag), "Click on Book Now button and the error  message was not shown when available points is less");
                extentTest.Pass("Not enough points message displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "Not_Enough_Points").Build());

                ////verify the eligible points in error m essage
                //Assert.IsTrue(TestBaseClass.isElementVisible(confirmReservationPageObj.locatorForLab_TotalEligiblePoints, Constants.medLoadTime), "The eligible points was not shown in the error message");

                //string totElgPoints = confirmReservationPageObj.Lab_TotalEligiblePoints.Text.Replace("total eligible points: ", "").Replace(",", "").Trim();
                //Assert.IsTrue(totElgPoints.Equals(homePageObj.CurrentPointsVal), "The total eligible points shown in error message" + homePageObj.CurrentPointsVal + " was same as the Current Points available");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "The total eligible points shown in error message" + homePageObj.CurrentPointsVal + " was same as the Current Points available");

                ////Check the required points

                //string totReqPoints = confirmReservationPageObj.Lab_TotalPointsRequired.Text.Replace("total points required: ", "").Replace(",", "").Trim();
                //Assert.IsTrue((totReqPoints.Equals(SearchResultsObj.SRPPoints)), "The total required points was not " + SearchResultsObj.SRPPoints);
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "The total required points was not " + SearchResultsObj.SRPPoints);

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



        public static void CancelPointsReservationWithInGP(string username, TestContext testContextInstance, bool protectionType)
        {

            try
            {
                HomePage homepageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                Assert.IsTrue(TestBaseClass.PointReservationLogic(username, testContextInstance, protectionType), "Points Reservation was not successful.Hence cannot continue execution");
                extentTest.Pass("Points reservation was successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Reservation_Success").Build());

                Assert.IsTrue(TestBaseClass.CancelPointsOrBonusReservation(testContextInstance, Constants.pointstype), "Cancel Points Reservation was not successful");
                extentTest.Pass("Points reservation cancelled" + "\r\n", AttachScrenshot(driver, testContextInstance, "Cancellation_Success").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.ShortwaitInSecond));
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



        public static void buyPPPFromMyReservationsPage(string username, TestContext testContextInstance, bool protectionType)
        {

            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);

            int index = 0;
            TestBaseClass.currentType = Constants.pointstype;
            try
            {

                Assert.IsTrue(TestBaseClass.PointReservationLogic(username, testContextInstance, protectionType), "Points Reservation was not successful.Hence cannot continue Execution");
                extentTest.Pass("PPP from MyReservation is successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPP_Success").Build());

                HomePage homePageObj = new HomePage(driver);

                //Capture the available point

                Assert.IsTrue(IsSingleELementVisible(homePageObj.locatorForCurrentPoints, driver), "Available points were not shown in HomePage");
                extentTest.Info("Available points shown on HomePage");
                homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();

                string cnum = TestBaseClass.currentconfirmationNumber;
                string cdate = TestBaseClass.confirmationdate;
                string checkin = TestBaseClass.currentcheckInDate;
                string checkout = TestBaseClass.currentcheckOutDate;
                string type = TestBaseClass.currentType;
                string amount = TestBaseClass.currentAmount;
                string pppstatus = TestBaseClass.currentPPPStatus;
                string resortname = TestBaseClass.currentResortName;
                string allConfirmationNumbers = null;
                bool foundelement = false;
                IWebElement buyNow = null;


                MyReservationPage myreservObj = new MyReservationPage(driver);



                allConfirmationNumbers = allConfirmationNumbers + cnum + ",";
                Assert.IsTrue(IsElementPresent(myreservObj.locatorforCurrentReservationTable, driver), "The Current Reservation Table was not displayed");
                extentTest.Pass("Reservation results shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "Reservations_Result").Build());

                TestBaseClass.numberOfRowsInCurrentReservationsTable = myreservObj.CRTable_ListConfirmationNumber.Count;
                Assert.IsTrue(myreservObj.CRTable_ListConfirmationNumber.Count > 0, "Current Reservations Table had no confrimation numbers listed");
                extentTest.Info("Reservation table  is present");

                //GetWebdriverWait(driver, TimeSpan.FromMilliseconds(Constants.shortLoadTime)).Until(WaitForJsExecute(driver));


                int numberofReservations = myreservObj.CRTable_ListConfirmationNumber.Count;

                if (numberofReservations > 10)

                {


                    WaitForElementToBeClickable(myreservObj.ViewAllLink, driver).Click();
                    if (IsElementPresent(myreservObj.locatorforViewAllLink, driver))
                    {
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, driver).Click();
                    }



                }

                var Reservationtable = GetListOfElements(myreservObj.locatorforCRTable_ListConfirmationNumber, driver);
                //GetWebdriverWait(driver, TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond)).
                //Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(myreservObj.locatorforCRTable_ListConfirmationNumber));

                //int numberofReservations = Reservationtable.Count;
                foreach (IWebElement confirmationNumberEle in Reservationtable)
                {
                    //string gg = confirmationNumberEle.Text;
                    if (confirmationNumberEle.Text.Equals(cnum.ToString()))
                    {
                        foundelement = true;

                        index = Reservationtable.IndexOf(confirmationNumberEle);
                        break;
                    }
                }


                Assert.IsTrue(foundelement, "The confirmation number was not found on the My Reservations Page");
                extentTest.Pass("Current reservation found: " + cnum + "\r\n", AttachScrenshot(driver, testContextInstance, "Current_Reservation").Build());


                // confimration page is displayed
                ReservationConfirmationPage rcObj = new ReservationConfirmationPage(driver);


                if (TestBaseClass.FindElementInsideAnotherUsingDriver(myreservObj.CRTable_ListPPPStatus[index], "tagname", "a").Displayed) // this needs to be changed 

                {
                    myreservObj.buyNow = TestBaseClass.FindElementInsideAnotherUsingDriver(myreservObj.CRTable_ListPPPStatus[index], "tagname", "a");
                    Assert.IsTrue((myreservObj.buyNow != null), "The Buy Now button was not displayed in MyReservations Page");
                    extentTest.Pass("BuyNow button is displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "BuyNow_Button").Build());



                    myreservObj.buyNow.Click();
                    extentTest.Info("BuyNow button clicked");
                    PointsProtectionPlanPage pppObj = new PointsProtectionPlanPage(driver);

                    Assert.IsTrue(IsSingleELementVisible(pppObj.locatorfortextBox_CreditCardName, driver, Constants.medLoadTime), "The PPP page was not displayed");
                    extentTest.Pass($"PPP page displayed for: {cnum}" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPP_Page").Build());

                    Assert.IsTrue(TestBaseClass.fillCreditCardDetailsPPPPage(pppObj, testContextInstance), "The PPP form filling  was not successful");
                    extentTest.Info("PPP card details filled");
                    Assert.IsTrue(TestBaseClass.SubmitPPPForm(pppObj), " The PPP submission was not successful");

                    TestBaseClass.WithPPP = true;
                    extentTest.Pass($"The  PPP purchase was successful for: {cnum}" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPP_Successful").Build());

                    //buy ppp
                    ////Validate Points Protected label
                    Assert.IsTrue(rcObj.Lab_ProtectedOrNot.Text.Equals("| points protected"));
                    extentTest.Pass($"PPP Status: {rcObj.Lab_ProtectedOrNot.Text} shown" + "\r\n", AttachScrenshot(driver, testContextInstance, "PPP_Status").Build());
                    Assert.IsTrue(TestBaseClass.validateReservationDetails(testContextInstance), "The Reservation details were not correctly shown in My Reservations Page");

                    extentTest.Info("Correct reseravation details shown");
                }

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }

            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Error(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Error(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }
            }

        }

        public static void Pagination(string userName, TestContext testContextInstance)
        {

            try
            {

                TestBaseClass.initializeTestScripts("no", "no", "no", testContextInstance);


                LoginPage loginPageObj = new LoginPage(driver);


                //Navigate to Point Type Reservation Page
                AllMenus topMenuobj = new AllMenus(driver);
                HomePage homepageObj = new HomePage(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMyDashBoard, topMenuobj.locatorforMyReservations };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MyDashBoard, topMenuobj.MyReservations };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen Resorts", "My Dashboard", "My Reservations" };

                Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["UrlMyReservations"]), "My Reservations page was not displayed");
                extentTest.Pass("My reservation page was displayed" + "\r\n", AttachScrenshot(driver, testContextInstance, "MyReservation_Page").Build());

                MyReservationPage myreservObj = new MyReservationPage(driver);

                //for current reservations
                IList<IWebElement> dummyListConfirmationNumber = myreservObj.CRTable_ListConfirmationNumber;
                By locatorfordummyListConfirmationNumber = myreservObj.locatorforCRTable_ListConfirmationNumber;

                IList<IWebElement> dummyListConfirmationNumberDisplayed = myreservObj.CRTable_ListConfirmationNumberDisplayed;
                By locatorfordummyListConfirmationNumberDisplayed = myreservObj.locatorforCRTable_ListConfirmationNumberDisplayed;
                string path1 = ".//*[@id='section-current-reservations-details']/div/span/a";
                string path2 = ".//*[@id='section-current-reservations-details']/div/span/a[text()='";
                string reservationscategory = "Current Reservations";
                Assert.IsTrue(TestBaseClass.Paginationlogic(path1, path2, reservationscategory, myreservObj.locatorforViewAllLink, myreservObj.ViewAllLink, dummyListConfirmationNumber, locatorfordummyListConfirmationNumber, dummyListConfirmationNumberDisplayed, locatorfordummyListConfirmationNumberDisplayed, testContextInstance), "The pagination for Current reservations in My Reservations does not work as expected");

                ////for past reservations
                dummyListConfirmationNumber = myreservObj.PRTable_ListConfirmationNumber;
                locatorfordummyListConfirmationNumber = myreservObj.locatorforPRTable_ListConfirmationNumber;
                dummyListConfirmationNumberDisplayed = myreservObj.PRTable_ListConfirmationNumberDisplayed;
                locatorfordummyListConfirmationNumberDisplayed = myreservObj.locatorforPRTable_ListConfirmationNumberDisplayed;
                path1 = ".//*[@id='section-past-reservations-details']/div/span/a";
                path2 = ".//*[@id='section-past-reservations-details']/div/span/a[text()='";
                reservationscategory = "Past Reservations";
                Assert.IsTrue(TestBaseClass.Paginationlogic(path1, path2, reservationscategory, myreservObj.locatorforViewAllLinkForPastreservations, myreservObj.ViewAllLinkForPastreservations, dummyListConfirmationNumber, locatorfordummyListConfirmationNumber, dummyListConfirmationNumberDisplayed, locatorfordummyListConfirmationNumberDisplayed, testContextInstance), "The pagination for Past reservations in My Reservations  does not work as expected");
                extentTest.Pass("Pagination for past reservation present" + "\r\n", AttachScrenshot(driver, testContextInstance, "Pagination").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    // Assert.Fail(exception.InnerException.ToString());
                }
                else
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    // Assert.Fail(exception.Message);
                }


            }

        }

        public static void ResendEmailforPointTypeReservation(string userName, TestContext testContextInstance, bool protectionType)
        {


            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);

            try
            {
                Assert.IsTrue(TestBaseClass.PointReservationLogic(userName, testContextInstance, protectionType), "Points Reservation was not successful.Hence cannot continue execution");
                extentTest.Pass("Points Reservation was successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Point_Reservation").Build());

                Assert.IsTrue(TestBaseClass.ResendEmailItenarary(testContextInstance, Constants.pointstype, TestBaseClass.currentconfirmationNumber), "Resend Email Itinerary was not successful for  Points Reservation");
                extentTest.Pass("Resend email for itinerary sent successfuly" + "\r\n", AttachScrenshot(driver, testContextInstance, "Resendemail_Successful").Build());
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "Resend Email Itinerary was successful for  Points Reservation");

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");


            }
            catch (Exception exception)
            {


                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    // Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }


            }

        }

        public static void ValidateConfirmationPageForBonusOrPointsType(string userName, TestContext testContextInstance, string reservationType, string userType, bool protectionType)
        {

            try
            {


                HomePage homepageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                if (reservationType.Equals(Constants.pointstype))
                {
                    Assert.IsTrue(TestBaseClass.PointReservationLogic(userName, testContextInstance, protectionType), "Points Reservation was not successful.Hence cannot continue execution");
                    extentTest.Pass("Points Reservation is successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Point_Reservation").Build());
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "Points Reservation was successful");
                }
                else
                {
                    Assert.IsTrue(TestBaseClass.BonusTimeReservationLogic(userName, testContextInstance, "no", "no", "no"), "Bonus Reservation was not successful.Hence cannot continue execution");

                    extentTest.Pass("Bonus Reservation is successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Bonus_Reservation").Build());
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "Bonus Reservation was successful");
                }
                Assert.IsTrue(TestBaseClass.ResendEmailItenarary(testContextInstance, reservationType, TestBaseClass.currentconfirmationNumber), "Resend Email Itinerary was not successful for " + reservationType + " Reservation");
                extentTest.Pass("Resend Email Itinerary was successful for  " + reservationType + " Reservation " + "\r\n", AttachScrenshot(driver, testContextInstance, "Resend_Itinerary").Build());

                ReservationConfirmationPage rcobj = new ReservationConfirmationPage(driver);

                Assert.IsTrue(TestBaseClass.editReservationDetails(testContextInstance, reservationType, userType, rcobj), "Update Reservation was not succesful for " + reservationType + " reservation");
                extentTest.Pass("Update Reservation was successful for " + reservationType + " reservation" + "\r\n", AttachScrenshot(driver, testContextInstance, "Update_Reservation").Build());
                Assert.IsTrue(TestBaseClass.validateLinksOnConfirmationPage(testContextInstance, reservationType, rcobj, protectionType), "Validating Links on Confirmation Page was not succesful for " + reservationType + " reservation");
                extentTest.Pass("Links validation on Confirmation Page is succesful for reservation" + "\r\n", AttachScrenshot(driver, testContextInstance, "Link_Validation").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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


        public static void ValidateSavePointsButtonIsRemoved(string userName, TestContext testContextInstance, bool protectionType)
        {

            try
            {
                HomePage homepageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                Assert.IsTrue(TestBaseClass.PointReservationWithSavePointsLogic(userName, testContextInstance, protectionType), "Points Reservation was not successful.Hence cannot continue execution");

                extentTest.Pass("Points Reservation was successful" + "\r\n", AttachScrenshot(driver, testContextInstance, "Point_Reservation").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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
