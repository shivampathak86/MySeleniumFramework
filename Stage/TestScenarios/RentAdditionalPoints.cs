using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using POM.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class RentAdditionalPoints : LoginMethod
    {

        public static void ValidateRentAdditionalPoints(TestContext testContext)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            RentAdditionalPointsPage rentAdditionalObj = new RentAdditionalPointsPage(driver);
            FundSourcePage fundObj = new FundSourcePage(driver);

            try
            {

                ClickLink(rentAdditionalObj.travelerPlusLink, driver);
                extentTest.Info("Traveler plus menu is clicked");

                Assert.IsTrue(IsSingleELementVisible(rentAdditionalObj.travelerPlus, driver), "Traveler plus page is not displayed");
                extentTest.Pass("Traveler plus page is displayed", AttachScrenshot(driver, testContext, "TravelerPlusPage").Build());

                JavascriptClickElement(rentAdditionalObj.rentAdditionalPointsLink, driver);
                extentTest.Info("Rent additional points link is clicked");

                Assert.IsTrue(IsSingleELementVisible(rentAdditionalObj.RentAdditionalPointsImg, driver), "Rent Additional Points page is not displayed");
                extentTest.Pass("Rent Additional Points page is displayed", AttachScrenshot(driver, testContext, "RentAdditionalPointsPage").Build());

                SelectElementByIndex(rentAdditionalObj.pointsToRentDropDown, driver, Constants.Index_RentAdditional, 30);
                extentTest.Info("Points to rent dropdown is selected");

                List<IWebElement> ListOfRentAdditionalPgObjects = new List<IWebElement>() { rentAdditionalObj.firstNameTxtField,rentAdditionalObj.lastNameTxtField,
                rentAdditionalObj.cityTxtField,rentAdditionalObj.ZipcodeTxtField,rentAdditionalObj.phoneTxtField,rentAdditionalObj.emailTxtField };


                foreach (IWebElement rentPointsObj in ListOfRentAdditionalPgObjects)
                {
                    if (rentPointsObj.Enabled)
                    {
                        rentPointsObj.Clear();
                    }
                }

                TypeInTextBox(rentAdditionalObj.firstNameTxtField, driver, Constants.Firstname);
                extentTest.Info("First name is entered");

                TypeInTextBox(rentAdditionalObj.lastNameTxtField, driver, Constants.LastName);
                extentTest.Info("Last name is entered");

                TypeInTextBox(rentAdditionalObj.cityTxtField, driver, Constants.City);
                extentTest.Info("City name is entered");

                TypeInTextBox(rentAdditionalObj.ZipcodeTxtField, driver, Constants.zipcode);
                extentTest.Info("Zipcode is entered");

                TypeInTextBox(rentAdditionalObj.phoneTxtField, driver, Constants.Phone);
                extentTest.Info("Phone number is entered");

                TypeInTextBox(rentAdditionalObj.emailTxtField, driver, Constants.Email);
                extentTest.Info("Email is entered");

                SelectElementByIndex(rentAdditionalObj.stateDropDownList, driver, Constants.Index, 30);
                extentTest.Info("State dropdown is selected");

                JavascriptScrollTo(rentAdditionalObj.ZipcodeTxtField.Location.X.ToString(), rentAdditionalObj.ZipcodeTxtField.Location.Y.ToString(), driver);

                TypeInTextBox(rentAdditionalObj.CardNumber, driver, Constants.CardNumber);
                extentTest.Info("Card Number is entered");

                SelectElementByText(rentAdditionalObj.ExpDate_Month, driver, Constants.expirationMonthNumber, 30);
                extentTest.Info("Expiration month is selected from dropdown");

                SelectElementByText(rentAdditionalObj.ExpDate_Year, driver, Constants.expirationYear, 30);
                extentTest.Info("Expiration year is selected from dropdown");

                ClickButton(rentAdditionalObj.SumitBtn, driver);
                extentTest.Info("Submit button is clicked");

                Assert.IsTrue(IsSingleELementVisible(rentAdditionalObj.RentAdditionalWarningMessage, driver), "Alert message is not displayed");
                extentTest.Pass("Alert message is displayed", AttachScrenshot(driver, testContext, "AlertMessage").Build());

                ClickButton(rentAdditionalObj.SumitBtnInConfirmationPg, driver);
                extentTest.Info("Submit button in confirmation page is clicked");

                if (IsSingleELementVisible(rentAdditionalObj.SuccesfulMessage, driver))
                {
                    var text = rentAdditionalObj.SuccesfulMessage.Text;
                    var actual = "You have successfully rented 1000 Points and your card has been charged    $150.";
                    Assert.IsTrue(text.Contains(actual), "There was a problem adding points to your account");
                    extentTest.Pass("points has been successfully rented message displayed", AttachScrenshot(driver, testContext, "PointsSuccessfullyMessageDisplaye").Build());

                    Businesslogic.ValidateTransactionInFundSource_SearchByArvact(testContext, driver, Constants.Rentadditionalarvact);

                }

                else
                {
                    var text = rentAdditionalObj.AlertMessage.Text;
                    var actual = "Your credit card has been successfully charged, but there was a problem adding points to your account; please, contact customer service at 800.459.1597 ";

                    Assert.IsTrue(text.Contains(actual), "You have successfully rented points and card has been charged");
                    extentTest.Pass("there was a problem adding points to your account", AttachScrenshot(driver, testContext, "RentAdditionalPointsPage").Build());
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

    }
}



