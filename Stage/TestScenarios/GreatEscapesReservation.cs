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


namespace BlueGreenOwner.TestCases
{
    public class GreatEscapesReservation : LoginMethod
    {

        public static void ValidateGreatEscapeBooking(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            GreatEscapesReservationPage greatEscapeResObj = new GreatEscapesReservationPage(driver);
            HomePage homePageObj = new HomePage(driver);
            FundSourcePage fundSourceObj = new FundSourcePage(driver);

            try
            {
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() {  homePageObj.travelerPlusLink, homePageObj.resortStaysLink,
                 homePageObj.greatEscapesLink};

                MenuLevel2(ListOfMenuobjects, driver);
                extentTest.Info("Traversing is successfull");

                Assert.IsTrue(IsElementPresentUsingBy(greatEscapeResObj.locatorforGreatEscapesImg, driver), "Great Escapes page is not displayed");
                extentTest.Pass("Great Escapes page is displayed", AttachScrenshot(driver, testContext, "GreatEscapePage").Build());

                Businesslogic.GreatEscapeSearchInventory(testContext, driver);

                Businesslogic.GreatEscapesSearchAgain(testContext, driver);

                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["GreatEscapesPaymentPage"]), "Great Escapes payment page is not displayed");

                Assert.IsTrue(IsElementPresentUsingBy(greatEscapeResObj.locatorforGreatEscapesPaymentPg,driver), "Great Escapes payment page is not displayed");
                extentTest.Pass("Great Escapes payment page is displayed", AttachScrenshot(driver, testContext, "PaymentPage").Build());

                JavascriptScrollTo(greatEscapeResObj.memberInfo_CityLabel.Location.X.ToString(), greatEscapeResObj.memberInfo_CityLabel.Location.Y.ToString(), driver);


                List<IWebElement> ListOfGuestInfoObjects = new List<IWebElement>() { greatEscapeResObj.guestLastName, greatEscapeResObj.guestFirstName };

                foreach (IWebElement guestInfoObj in ListOfGuestInfoObjects)
                {
                    if (guestInfoObj.Enabled)
                    {
                        guestInfoObj.Clear();
                    }
                }

                TypeInTextBox(greatEscapeResObj.guestLastName, driver, Constants.GuestLastName);
                TypeInTextBox(greatEscapeResObj.guestFirstName, driver, Constants.GuestFirstName);

                List<IWebElement> ListOfBillingInfoObjects = new List<IWebElement>() { greatEscapeResObj.billingInfolastName,greatEscapeResObj.billingInfoFirstName,
               greatEscapeResObj.streetAddress,greatEscapeResObj.city,greatEscapeResObj.Zipcode,greatEscapeResObj.nameOfCardHolder,greatEscapeResObj.cardNumber };

                List<String> LabelName = new List<string>() { "Last Name", "First Name", "Street Address", "City", "Zipcode", "Name of CardHolder", "Card number" };

                List<String> text = new List<string>() { Constants.LastName , Constants.Firstname , Constants.StreetAddress , Constants.City ,Constants.zipcode,
                Constants.NameOfCardHolder,Constants.CardNumber};

                for (int x = 0; x < ListOfBillingInfoObjects.Count; x++)
                {
                    if (ListOfBillingInfoObjects[x].Enabled)
                    {
                        ListOfBillingInfoObjects[x].Clear();

                        TypeInTextBox(ListOfBillingInfoObjects[x], driver, text[x]);
                        extentTest.Info(LabelName[x] + "is entered");
                    }
                }

                SelectElementByText(greatEscapeResObj.stateDropDownList, driver, Constants.State);
                extentTest.Info("State dropdown is selected");

                SelectElementByText(greatEscapeResObj.countryDropDownList, driver, Constants.GreatEscapesCountry);
                extentTest.Info("country dropdown is selected");

                SelectElementByText(greatEscapeResObj.expDate_Month, driver, Constants.expirationMonthNumber);
                extentTest.Info("expiration month dropdown is selected");

                SelectElementByText(greatEscapeResObj.expDate_Year, driver, Constants.expirationYear);
                extentTest.Info("expiration year dropdown is selected");
                
                greatEscapeResObj.agreeToTermsCheckBox.Click();
                extentTest.Info("Agree to Great escapes terms & conditions check box is checked");

                extentTest.Pass("Guest Info and Billing Info is entered in Guest Escapes Payment Details Page", AttachScrenshot(driver, testContext, "GuestAndBillingInformation").Build());

                ClickButton(greatEscapeResObj.submitBtn, driver);
                extentTest.Info("Submit button is clicked");

                Assert.IsTrue(IsElementPresentUsingBy(greatEscapeResObj.locatorForGreatEscapeConfirmationMsg, driver), "Great escapes reservation Confirmation message is not displayed");
                extentTest.Pass("Great escapes reservation Confirmation message is displayed", AttachScrenshot(driver, testContext, "ConfirmationMessage").Build());

                Businesslogic.ValidateTransactionInFundSource_SearchByArvact(testContext, driver, Constants.GreateEscapesArvact);
                
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

