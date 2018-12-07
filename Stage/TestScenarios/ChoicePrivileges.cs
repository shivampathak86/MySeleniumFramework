using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class ChoicePrivileges : LoginMethod
    {

        public static void ValidateConvertChoicePoints(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            ChoicePrivilegesPage choicePrivilegesObj = new ChoicePrivilegesPage(driver);
            HomePage homePageObj = new HomePage(driver);

            try
            {
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { homePageObj.logOffDiv, homePageObj.choicePrivilegesLink };

                MenuLevel1(ListOfMenuobjects, driver);
                extentTest.Info("Choice Priviledges Menu selected from top menu");

                Assert.IsTrue(IsElementPresentUsingBy(choicePrivilegesObj.locatorforCPlegacylink, driver), "Link to reach to legacy CP page is not present");
                extentTest.Pass("Choice Privileges legacy link displayed", AttachScrenshot(driver, testContext, "LegacyLink").Build());

                JavascriptClickElement(choicePrivilegesObj.CPlegacylink, driver);
                extentTest.Info("Choice Priviledges link to reach legacy page is clicked");

                 Assert.IsTrue(IsElementPresentUsingBy(choicePrivilegesObj.locatorForMyPointsPage, driver), "My Points page is not displayed");
                extentTest.Pass("My Points page is displayed", AttachScrenshot(driver, testContext, "MyPointsPage").Build());
                
                 ////legacy page 

                //Assert.IsTrue(IsElementVisible(choicePrivilegesObj.locatorForConvertPointsToCPLink, driver), "Choice Privileges page is not displayed");
                //extentTest.Pass("Choice Privileges page is displayed", AttachScrenshot(driver, testContext, "ChoicePrivilegePage").Build());

                //ClickButton(choicePrivilegesObj.locatorForConvertPointsToCPLink, driver);
                //extentTest.Info("Choice Priviledges button clicked");

                //SelectElementByIndex(choicePrivilegesObj.locatorforSelectOwnerDropDown, driver, 1);
                //extentTest.Info("Owner option is selected from select an owner drop down");

                ////

                SelectElementByText(choicePrivilegesObj.locatorforSelectOwnerDropDown, driver, "Other");
                extentTest.Info("Other option is selected from select an owner drop down");

                List<IWebElement> cpMemberDetails = new List<IWebElement> { choicePrivilegesObj.FirstName,choicePrivilegesObj.LastName,
                choicePrivilegesObj.ChoicePrivilegeMember};

                List<String> cpMemberDetails_Txt = new List<String> { Constants.Firstname_CP, Constants.LastName_CP,Constants.CpMemberID };

                List<String> label = new List<String> { "First name", "last name", "CP id" };

                for (int i=0;i<cpMemberDetails.Count;i++)
                {
                    TypeInTextBox(cpMemberDetails[i], driver, cpMemberDetails_Txt[i]);
                    extentTest.Info(label[i]+"is entered");
                }


                if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                {
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    TypeInTextBox(choicePrivilegesObj.NoOfPointsToConvert, driver, choicePrivilegesObj.points);
                    extentTest.Info("Points to be converted entered");
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                        JavascriptSendKeys(choicePrivilegesObj.NameOfCardHolder, Constants.NameOfCardHolder, driver);
                    extentTest.Info("Card Holder Name entered");
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                        JavascriptSendKeys(choicePrivilegesObj.CardNumber, Constants.CardNumber, driver);
                    extentTest.Info("Card number entered");
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                    {
                        SelectElementByValue(choicePrivilegesObj.locatorforExpDate_Month, driver, Constants.expirationMonthNumber);
                        
                        extentTest.Info("Expiry Month selected");


                    }
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                    {
                        SelectElementByValue(choicePrivilegesObj.locatorforExpDate_Year, driver, Constants.expirationYear);
                        extentTest.Info("Expiry Year selected");

                    }
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                    {
                        JavascriptSendKeys(choicePrivilegesObj.ZipCode, Constants.zipcode, driver);
                        extentTest.Info("Zip code entered");
                    }
                    GetWebdriverWait(driver).Until(JsFunc(driver));

                    if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                    {
                        ClickButton(choicePrivilegesObj.AcceptConditionsCheckBox, driver);
                        extentTest.Info("Terms and condition check box clicked");
                        ClickButton(choicePrivilegesObj.locatorforSumitBtn, driver);
                        extentTest.Info("Submit button clicked");

                    }


                }

                else
                {
                    extentTest.Info("No overlay was available after selecting owner from drop down option need to check the code for visibility of Overlay element");
                    Assert.Fail("Overlay did not display after selecting the owner, need to change the code logic");

                }


                if (IsElementInvisible(choicePrivilegesObj.LocatorforOverlay, driver))
                {


                    Assert.IsTrue(IsSingleELementVisible(choicePrivilegesObj.YourPaymentWasApproved, driver), "User did not reach Choice Conversion Confirmation page");
                    extentTest.Pass("User reached Choice Conversion Confirmation page", AttachScrenshot(driver, testContext, DateTime.Now.ToString("MMddHHss_") +"CPConfirmationPage").Build());


                    extentTest.Info($"User reached to Confirmation and approval message is displayed");

                    extentTest.Info("Your payment was approved.Your Choice Privileges points are now available in your Choice Privileges account.");
                    extentTest.Info(choicePrivilegesObj.BGPointsDeducted.Text);
                    extentTest.Info(choicePrivilegesObj.CPPointsDeposited.Text);
                }


                else
                {
                    extentTest.Info("No overlay was not available after clicking on Submit button, need to check the code for visibility of Overlay element");
                    Assert.Fail("Overlay did not display after clicking on Submit button,hence need to change the code logic");

                }

                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }


            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, DateTime.Now.ToString("MMddHHss_") +"Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, DateTime.Now.ToString("MMddHHss_") +"Exception").Build());

                    Assert.Fail(e.Message);
                }


            }

        }

    }
}


