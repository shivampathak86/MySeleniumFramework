
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Utilities;
using System.Configuration;


namespace BlueGreenOwner.TestCases
{
    public class MyAccount : LoginMethod
    {

        public static void AdditionalMemberCardLink(TestContext testContext, string TestType)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            MyAccountPage myaccountPageObj = new MyAccountPage(driver);
            AdditionalCardMemberInformationPage additionalcardpageObj = new AdditionalCardMemberInformationPage(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);

                string MyAccountPageUrl = MenuLevel1(new List<By>() { allMenusObj.locatorforMyBlueGreen, allMenusObj.locatorforMyAccount }, driver);
                extentTest.Info("Navigation action is perfomed from TopMenu");

                //if (String.Compare(MyAccountPageUrl, ConfigurationManager.AppSettings["URLForMyAccountsPage"], StringComparison.OrdinalIgnoreCase) == 0)

              if (IsElementPresentUsingBy(myaccountPageObj.locatorFormyAccountHeader,driver))
               {
                    extentTest.Pass("My account page is displayed", AttachScrenshot(driver, testContext, "My AccountPageDisplayed").Build());
                    
               }

                else
                {
                    extentTest.Error("My Account page is not visible", AttachScrenshot(driver, testContext, "MyAccount_Not_Visible").Build());

                    Assert.Fail("My Account page is not visibl");
                }
                switch (TestType.ToLower())
                {

                    case "testwithadditonalmembercard":
                        Assert.IsTrue(IsElementPresent(myaccountPageObj.LocatorforCardlink, driver), "Additional Member Card Link is not available");
                        extentTest.Pass("CreditCard link is present", AttachScrenshot(driver, testContext, "CreditCard_Link").Build());

                        ClickLink(myaccountPageObj.LocatorforCardlink, driver);

                        Assert.IsTrue(FillBillingInformation(testContext, driver), "Credit card details not submitted");

                        Assert.IsTrue(IsSingleELementVisible(additionalcardpageObj.SuccessMessage, driver), "Success Message was not displayed after requesting new Card");
                        extentTest.Pass("Successful message is displayed", AttachScrenshot(driver, testContext, "SuccessfulMessage").Build());


                        break;

                    case "testwithnoaddtionalmembercard":

                        Assert.IsFalse(IsSingleELementVisible(myaccountPageObj.LocatorforCardlink, driver, 5), "Additional card member link  was present in My Accounts page ");
                        extentTest.Pass("CreditCard link is not  present", AttachScrenshot(driver, testContext, "No_CreditCard_Link").Build());


                        break;

                }

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.VeryShortWaitInSecond));
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




        public static bool FillBillingInformation(TestContext testContext, IWebDriver driver)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            MyAccountPage myaccountPageObj = new MyAccountPage(driver);
            AdditionalCardMemberInformationPage additionalcardpageObj = new AdditionalCardMemberInformationPage(driver);
            AdditionalMemberCardRequestPage additionalmembercardrequestpage = new AdditionalMemberCardRequestPage(driver);
            HomePage homePageObj = new HomePage(driver);


            try
            {
                Assert.IsTrue(IsSingleELementVisible(additionalmembercardrequestpage.FirstName, driver, Constants.medLoadTime), "The Additional Member Card Request page was not displayed");
                extentTest.Pass("The Additional Member Card Request page was displayed", AttachScrenshot(driver, testContext, "AdditionalMemberCardRequestPageDisplayed").Build());

                additionalmembercardrequestpage.FirstName.SendKeys(Constants.Firstname);
                additionalmembercardrequestpage.LastName.SendKeys(Constants.LastName);
                additionalmembercardrequestpage.Address1.SendKeys(Constants.Address);
                additionalmembercardrequestpage.City.SendKeys(Constants.City);

                SelectElementByText(additionalmembercardrequestpage.State, driver, Constants.StateCode, 20);

                additionalmembercardrequestpage.ZipCode.SendKeys(Constants.zipcode);

                SelectElementByText(additionalmembercardrequestpage.Country, driver, Constants.Country, 20);

                additionalmembercardrequestpage.HomePhone.SendKeys(Constants.Phone);
                additionalmembercardrequestpage.Email.SendKeys(Constants.Email);

                //credit card information section
                SelectElementByText(additionalmembercardrequestpage.CardType, driver, Constants.CardType.ToUpper(), 20);

                additionalmembercardrequestpage.CardNumber.SendKeys(Constants.CardNumber);

                SelectElementByText(additionalmembercardrequestpage.ExpMonth, driver, Constants.expirationMonthNumber, 20);

                SelectElementByText(additionalmembercardrequestpage.ExpYear, driver, Constants.expirationYear, 20);


                ClickButton(additionalmembercardrequestpage.locatorforSubmit, driver);


                return true;
            }
            catch (Exception exception)
            {

                extentTest.Error(exception.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());
                throw exception;
            }

        }


        public static void Navigate_To_MyAccountPage(TestContext testContext)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            MyAccountPage myaccountPageObj = new MyAccountPage(driver);
            HomePage homePageObj = new HomePage(driver);

            string MyAccountPageUrl = MenuLevel1(new List<By> { allMenusObj.locatorforMyBlueGreen, allMenusObj.locatorforMyAccount }, driver);

            if (String.Compare(MyAccountPageUrl, ConfigurationManager.AppSettings["URLForMyAccountsPage"], StringComparison.OrdinalIgnoreCase) == 0)
            {
                Assert.IsTrue(IsElementPresent(myaccountPageObj.locatorFormyAccountHeader, driver), "Unable to get the element my-account ");
                extentTest.Pass("My account page is displayed", AttachScrenshot(driver, testContext, "MyAccountPage").Build());

            }
            else
            {
                Assert.Fail("User did not reach on MyAccount Page");
                extentTest.Fail("User did not reach on MyAccount Page", AttachScrenshot(driver, testContext, "MyAccountPageNotDisplayed").Build());

            }
        }

        // For country = United States
        public static void ValidateAsterikInMyAccountPage(TestContext testContext)
        {


            AllMenus allMenusObj = new AllMenus(driver);
            MyAccountPage myaccountPageObj = new MyAccountPage(driver);

            HomePage homePageObj = new HomePage(driver);
            try
            {
                var country = "United States";
                if (GetElement(myaccountPageObj.locatorForcountryDropDownList, driver).Text.Contains(country))
                {

                    List<IWebElement> ListOfMyAccountPgObjects = new List<IWebElement>() { myaccountPageObj.ownerNumberTxtField, myaccountPageObj.firstNameTxtField,
                       myaccountPageObj.lastNameTxtField, myaccountPageObj.addressLine1TxtField,myaccountPageObj.addressLine2TxtField,myaccountPageObj.cityTxtField,myaccountPageObj.postalOrZipcodeTxtField,
                     myaccountPageObj.primaryPhoneTxtField,myaccountPageObj.alternatePhoneTxtField,myaccountPageObj.emailAddressTxtField};

                    foreach (IWebElement myAccountObj in ListOfMyAccountPgObjects)
                    {
                        if (myAccountObj.Enabled)
                        {
                            myAccountObj.Clear();
                            myAccountObj.SendKeys("");
                        }

                    }

                    ClickButton(myaccountPageObj.updateMyProfileBtn, driver);
                    extentTest.Info("Update my profile button is clicked");


                    var addressLine1 = myaccountPageObj.addressLine1ErrorMsg.Text;
                    Assert.IsTrue(addressLine1.Contains("Please enter the Address Line 1"), "Alert message for mandatory field-address Line1 is not displayed when it is left blank");
                    extentTest.Pass("Alert message for address Line1 is displayed", AttachScrenshot(driver, testContext, "AlertMessageforAddressLine1Displayed").Build());

                    var addressLine1Value = myaccountPageObj.addressLine1TxtArea.GetAttribute("class");
                    Assert.IsTrue(addressLine1Value.Contains("is-required"), " Required field_address Line1_ doesn't have * on my account page ");
                    extentTest.Info(" Required field_address Line1_ has * on my account page");

                    var city = myaccountPageObj.cityErrorMsg.Text;
                    Assert.IsTrue(city.Contains("Please enter the City."), "Alert message for mandatory field-City is not displayed when it is left blank");
                    extentTest.Info("Alert message for city Txt field is displayed");

                    var cityValue = myaccountPageObj.cityTxtArea.GetAttribute("class");
                    Assert.IsTrue(cityValue.Contains("is-required"), " Required field_City_ doesn't have * on my account page");
                    extentTest.Info(" Required field_City_ has * on my account page");

                    var zipCode = myaccountPageObj.zipCodeErrorMsg.Text;
                    Assert.IsTrue(zipCode.Contains("Please enter the Zip/Postal code."), "Alert message for mandatory field-zipcode is not displayed when it is left blank");
                    extentTest.Info("Alert message for zipcode Txt field is displayed");

                    var zipCodeValue = myaccountPageObj.postalOrZipcodeTxtArea.GetAttribute("class");
                    Assert.IsTrue(zipCodeValue.Contains("is-required"), "Required field_Zipcode_ doesn't have * on my account page");
                    extentTest.Info("Required field_Zipcode_ has * on my account page");

                    var primaryPhone = myaccountPageObj.primaryPhoneErrorMsg.Text;
                    Assert.IsTrue(primaryPhone.Contains("primary"), "Alert message for mandatory field-primary phone is not displayed when it is left blank");
                    extentTest.Info("Alert message for primary phone Txt field is displayed");

                    var primaryPhoneValue = myaccountPageObj.primaryPhoneTxtArea.GetAttribute("class");
                    Assert.IsTrue(primaryPhoneValue.Contains("is-required"), "Required field_Primary phone_ doesn't have * on my account page");
                    extentTest.Info("Required field_Primary phone_ has * on my account page");

                    var emailAddress = myaccountPageObj.emailAddressErrorMsg.Text;
                    Assert.IsTrue(emailAddress.Contains("You must enter your email address."), "Alert message for mandatory field-email address is not displayed when it is left blank");
                    extentTest.Info("Alert message for email address Txt field is displayed");

                    var emailAddressValue = myaccountPageObj.emailAddressTxtArea.GetAttribute("class");
                    Assert.IsTrue(emailAddressValue.Contains("is-required"), "Required field_Email address_ doesn't have * on my account page");
                    extentTest.Info("Required field_Email address_ has * on my account page");

                    IsCheckBoxChecked(myaccountPageObj.locatorForyesRadioBtn, driver, 20);
                    extentTest.Info("Yes-Radio button is selected");

                    var radioBtnValue = myaccountPageObj.recievePaperlessBillingStatements.GetAttribute("class");
                    Assert.IsTrue(radioBtnValue.Contains("is-required"), "Required field_Recieve paperless billing statements_ doesn't have * on my account page");
                    extentTest.Info("Required field_Recieve paperless billing statements_ has * on my account page");

                    var stateDropDownValue = myaccountPageObj.stateDropDownList.GetAttribute("title");
                    if (stateDropDownValue == "")
                    {
                        extentTest.Info("Dropdown list is not selected");
                    }
                    else
                    {
                        extentTest.Info("Dropdown list is selected");
                    }

                    var stateValue = myaccountPageObj.stateTxtArea.GetAttribute("class");
                    Assert.IsTrue(stateValue.Contains("is-required"), "Required field_State_ doesn't have * on my account page");
                    extentTest.Info("Required field_State_ has * on my account page");
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
        public static void ValidateAsterikInMyAccountPageForNonUS(TestContext testContext)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            MyAccountPage myaccountPageObj = new MyAccountPage(driver);

            HomePage homePageObj = new HomePage(driver);

            try
            {
                List<IWebElement> ListOfMyAccountPgObjects = new List<IWebElement>() { myaccountPageObj.ownerNumberTxtField, myaccountPageObj.firstNameTxtField,
                       myaccountPageObj.lastNameTxtField, myaccountPageObj.addressLine1TxtField,myaccountPageObj.addressLine2TxtField,myaccountPageObj.addressLine3TxtField,
                     myaccountPageObj.primaryPhoneTxtField,myaccountPageObj.alternatePhoneTxtField,myaccountPageObj.emailAddressTxtField};

                foreach (IWebElement myAccountObj in ListOfMyAccountPgObjects)
                {
                    if (myAccountObj.Enabled)
                    {
                        myAccountObj.Clear();
                        myAccountObj.SendKeys("");
                    }
                }

                ClickButton(myaccountPageObj.updateMyProfileBtn, driver);
                extentTest.Info("Update my profile button is clicked");

                var addressLine1 = myaccountPageObj.addressLine1ErrorMsg.Text;
                Assert.IsTrue(addressLine1.Contains("Please enter the Address Line 1"), "Alert message for mandatory field-address Line1 is not displayed when it is left blank");
                extentTest.Pass("Alert message for address Line1 is displayed", AttachScrenshot(driver, testContext, "AlertMessageforAddressLine1Displayed").Build());

                var addressLine1Value = myaccountPageObj.addressLine1TxtArea.GetAttribute("class");
                Assert.IsTrue(addressLine1Value.Contains("is-required"), "Required field_Address line1_ doesn't have * on my account page");
                extentTest.Info("Required field_Address line1_ has * on my account page");

                var primaryPhone = myaccountPageObj.primaryPhoneErrorMsg.Text;
                Assert.IsTrue(primaryPhone.Contains("primary"), "Alert message for mandatory field-primary phone is not displayed when it is left blank");
                extentTest.Info("Alert message for primary phone Txt field is displayed");

                var primaryPhoneValue = myaccountPageObj.primaryPhoneTxtArea.GetAttribute("class");
                Assert.IsTrue(primaryPhoneValue.Contains("is-required"), "Required field_primary phone_ doesn't have * on my account page");
                extentTest.Info("Required field_primary phone_ has * on my account page");

                var emailAddress = myaccountPageObj.emailAddressErrorMsg.Text;
                Assert.IsTrue(emailAddress.Contains("You must enter your email address."), "Alert message for mandatory field-email address is not displayed when it is left blank");
                extentTest.Info("Alert message for email address Txt field is displayed");

                var emailAddressValue = myaccountPageObj.emailAddressTxtArea.GetAttribute("class");
                Assert.IsTrue(emailAddressValue.Contains("is-required"), "Required field_Email address_ doesn't have * on my account page");
                extentTest.Info("Required field_Email address_ has * on my account page");

                IsCheckBoxChecked(myaccountPageObj.locatorForyesRadioBtn, driver, 20);
                extentTest.Info("Yes-Radio button is selected");

                var radioBtnValue = myaccountPageObj.recievePaperlessBillingStatements.GetAttribute("class");
                Assert.IsTrue(radioBtnValue.Contains("is-required"), "Required field_recieve paperless billing statement radio btn_ doesn't have * on my account page");
                extentTest.Info("Required field_recieve paperless billing statement radio btn_ has * on my account page");

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
