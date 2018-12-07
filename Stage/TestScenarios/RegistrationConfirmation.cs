using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class RegistrationConfirmation:LoginMethod
    {
        
        public static void GoToRegisterWithBluegreenVacactionsPage(TestContext testContext,String ssn, String arvact, String username,String password)
        {

            LoginPage loginObj = new LoginPage(driver);
            RegisterOwnerPage regOwnerpageObj = new RegisterOwnerPage(driver);

            TypeInTextBox(regOwnerpageObj.locatorForssnTxtField, driver, ssn);
            extentTest.Info("SSN is entered");

            TypeInTextBox(regOwnerpageObj.locatorForownerNumberTxtField, driver, arvact);
            extentTest.Info("Owner number is entered");

            TypeInTextBox(regOwnerpageObj.locatorForemailAddressTxtField, driver, username);
            extentTest.Info("Email address is entered");

            TypeInTextBox(regOwnerpageObj.locatorForconfirmMailTxtField, driver, username);
            extentTest.Info("Confirm Email address is entered");

            TypeInTextBox(regOwnerpageObj.locatorForpasswordTxtField, driver, password);
            extentTest.Info("Password is entered");

            TypeInTextBox(regOwnerpageObj.locatorForconfirmPasswordTxtField, driver, password);
            extentTest.Info("Confirm Password is entered");

            WaitForElementToBeClickable(regOwnerpageObj.locatorForregisterButton, driver).Click();
            extentTest.Info("Register button is clicked");

            Assert.IsTrue(IsSingleELementVisible(loginObj.locatorForregistrationConfirmationPage, driver), " Registration confirmation page is not  displayed");
            extentTest.Pass(" Registration confirmation page is  displayed", AttachScrenshot(driver, testContext, "RegistrationConfirmationPageDisplayed").Build());

        }

       

        // For country = United States
        public static void VerifyErrorMsgInRegistationConfirmationPage(TestContext testContext)
        {
            
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            RegistrationConfirmationPage regConfPageObj = new RegistrationConfirmationPage(driver);


            try
            {
                var country = "United States";
                if (regConfPageObj.countryDropDownList.Text.Contains(country))
                {

                    List<IWebElement> ListOfRegConfPgObjects = new List<IWebElement>() {regConfPageObj.ownerNumberTxtField, regConfPageObj.firstNameTxtField,
                       regConfPageObj.lastNameTxtField, regConfPageObj.addressLine1TxtField,regConfPageObj.addressLine2TxtField,regConfPageObj.cityTxtField,regConfPageObj.postalOrZipcodeTxtField,
                     regConfPageObj.primaryPhoneTxtField,regConfPageObj.alternatePhoneTxtField,regConfPageObj.emailAddressTxtField};

                    foreach (IWebElement regConfObj in ListOfRegConfPgObjects)
                    {
                        if (regConfObj.Enabled)
                        {
                            regConfObj.Clear();
                            regConfObj.SendKeys("");
                        }

                    }

                   ClickButton( regConfPageObj.updateMyProfileBtn,driver);
                    extentTest.Info("Update my profile button is clicked");

                    var addressLine1 = regConfPageObj.addressLine1ErrorMsg.Text;
                    Assert.IsTrue(addressLine1.Contains("Address Line 1"), "Alert message for mandatory field-address Line1 is not displayed when it is left blank");
                    extentTest.Pass("Alert message for address Line1 is displayed", AttachScrenshot(driver, testContext, "AlertMessageforAddressLine1Displayed").Build());


                    var city = regConfPageObj.cityErrorMsg.Text;
                    Assert.IsTrue(city.Contains("City."), "Alert message for mandatory field-City is not displayed when it is left blank" );
                    extentTest.Info("Alert message for city Txt field is displayed");

                    var zipCode = regConfPageObj.zipCodeErrorMsg.Text;
                    Assert.IsTrue(zipCode.Contains("Zip/Postal code."), "Alert message for mandatory field-Zipcode is not displayed when it is left blank");
                    extentTest.Info("Alert message for zipcode Txt field is displayed");

                    var emailAddress = regConfPageObj.emailAddressErrorMsg.Text;
                    Assert.IsTrue(emailAddress.Contains("email address"), "Alert message for mandatory field-email address is not displayed when it is left blank");
                    extentTest.Info("Alert message for email address Txt field is displayed");

                    var primaryPhone = regConfPageObj.primaryPhoneErrorMsg.Text;
                    Assert.IsTrue(primaryPhone.Contains("primary"), "Alert message for mandatory field-primary phone is not displayed when it is left blank");
                    extentTest.Info("Alert message for primary phone Txt field is displayed");

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

        // For country other than US
        public static void VerifyErrorMsgInRegistationConfirmationPageForNonUS(TestContext testContext)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            RegistrationConfirmationPage regConfPageObj = new RegistrationConfirmationPage(driver);
            
            try
            {
                List<IWebElement> ListOfRegConfPgObjects = new List<IWebElement>() { regConfPageObj.ownerNumberTxtField, regConfPageObj.firstNameTxtField,
                       regConfPageObj.lastNameTxtField,regConfPageObj.addressLine1TxtField,regConfPageObj.addressLine2TxtField,regConfPageObj.addressLine3TxtField,
                     regConfPageObj.primaryPhoneTxtField,regConfPageObj.alternatePhoneTxtField,regConfPageObj.emailAddressTxtField};

                foreach (IWebElement regConfObj in ListOfRegConfPgObjects)
                {
                    if (regConfObj.Enabled)
                    {
                        regConfObj.Clear();
                        regConfObj.SendKeys("");
                    }
                }

                ClickButton(regConfPageObj.updateMyProfileBtn,driver);
                extentTest.Info("Update my profile button is clicked");

                var addressLine1 = regConfPageObj.addressLine1ErrorMsg.Text;
                Assert.IsTrue(addressLine1.Contains("Address Line 1"), "Alert message for mandatory field-address Line1 is not displayed when it is left blank");
                extentTest.Pass("Alert message for address Line1 is displayed", AttachScrenshot(driver, testContext, "AlertMessageforAddressLine1Displayed").Build());


                var primaryPhone = regConfPageObj.primaryPhoneErrorMsg.Text;
                Assert.IsTrue(primaryPhone.Contains("primary Phone"), "Alert message for mandatory field-primary phone is not displayed when it is left blank");
                extentTest.Info("Alert message for primary phone Txt field is displayed");


                var emailAddress = regConfPageObj.emailAddressErrorMsg.Text;
                Assert.IsTrue(emailAddress.Contains("email address"), "Alert message for mandatory field-email address is not displayed when it is left blank");
                extentTest.Info("Alert message for email address Txt field is displayed");

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


        //public static void VerifyautoPopulatedInfoInRegConfirmationPageSameAsVssa(TestContext testContext)
        //{

        //VSSAHomePage vssaObj = new VSSAHomePage();

        //    try
        //    {

        //         driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "\t");
        //         driver.SwitchTo().Window(driver.WindowHandles.Last());
        //driver.Navigate().GoToUrl(vssaObj.UrlForVSSAHomePage);

        //         LoginHelper.VSSA_EnterArvact(Pages.VSSAHomePage.locatorForArvactnumber, testContext.DataRow["Arvact"].ToString());
        //         LoginHelper.VSSA_Click_SearchButton(Pages.VSSAHomePage.locatorForSearchButton);
        //         LoginHelper.VSSA_Click_ArvactResultLink(Pages.VSSAHomePage.locatorForarvactlink);

        //        List<IWebElement> ListOfRegConfPgObjects = new List<IWebElement>() {regConfPageObj.ownerNumberTxtField, regConfPageObj.firstNameTxtField,
        //               regConfPageObj.lastNameTxtField, regConfPageObj.addressLine1TxtField,regConfPageObj.cityTxtField,regConfPageObj.postalOrZipcodeTxtField,
        //             regConfPageObj.primaryPhoneTxtField,regConfPageObj.alternatePhoneTxtField,regConfPageObj.emailAddressTxtField};

        //        List<IWebElement> ListOfVssaHomePgObjects = new List<IWebElement>() {vssaObj.Arvactnumber,vssaObj.FirstName,vssaObj.LastName,vssaObj.AddressLine1,
        //            vssaObj.CityTxtField,vssaObj.ZipCodeTxtField,vssaObj.PrimaryPhoneTxtField,vssaObj.AlternatePhoneTxtField,vssaObj.EmailUpdate };


        //        for (int i = 0; i < ListOfRegConfPgObjects.Count; i++)
        //        {

        //            driver.SwitchTo().Window(driver.WindowHandles.First());

        //            IWebElement regConfObj = ListOfRegConfPgObjects[i];
        //            var RegPageAttributeValue= regConfObj.GetAttribute("value");

        //            int j=0;

        //            while(j < ListOfVssaHomePgObjects.Count)
        //            {
        //                driver.SwitchTo().Window(driver.WindowHandles.Last());

        //                IWebElement vssaHomeObj = ListOfRegConfPgObjects[j];
        //                var VssaPageAttributeValue=vssaHomeObj.GetAttribute("value");
        //                Assert.IsTrue(RegPageAttributeValue.Contains(VssaPageAttributeValue));

        //            }

        //            j++;

        //        }


        //    }


        //    catch (Exception e)
        //    {
        //        TestBaseClass.printOutputAndCaptureImage(testContext, TestBaseClass.baseDriver, e.Message);
        //        Assert.Fail(e.Message);
        //    }

        

        //}


    }
}
