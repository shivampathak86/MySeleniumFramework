using OpenQA.Selenium.Support.PageObjects;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using Utilities;
using BlueGreenOwner;
using System.Configuration;
using System.Diagnostics;

namespace BlueGreenOwner.TestCases
{
    /// This class handles Sign with different user to BGO Home

    public class SignIn : LoginMethod
    {
        
        /// This method validates OwnerSignIn
        /// This method takes care of different types of owner sign in -
        /// Single account owner
        /// Multiple account owner : Club and Non Club
        /// 
        public static void OnwerSignIn(TestContext testContext)
        {

            SelectAnAccountPage selectaccountPageobj = new SelectAnAccountPage(driver);
            LoginPage loginPageObj = new LoginPage(driver);
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);


            //LoginHelper.Login_FromBGO(loginPageObj.UserName, loginPageObj.Password, loginPageObj.LoginButton, driver, testContext.DataRow["UserName"].ToString(), testContext.DataRow["Password"].ToString(), loginPageObj.continueBtn);
            var expected = ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToString();


            try
            {

                var actual = driver.Url;
                if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
                {

                    extentTest.Pass("Select an account page is displayed", AttachScrenshot(driver, testContext, "SelectAnAccountPageDisplayed").Build());

                    var NumberofAccounts = GetWebdriverWait(driver).Until(GetElementsFunc(selectaccountPageobj.LocatorforRadioButtonElement));



                    if (NumberofAccounts.Count > 1)
                    {

                        for (int i = 0; i < NumberofAccounts.Count; i++)
                        {

                            var AccountNumbers = GetWebdriverWait(driver).Until(GetElementsFunc(selectaccountPageobj.LocatorforRadioButtonElement));


                            var AccountName = AccountNumbers[i].Text;


                            if (AccountName.Contains("Vacation Club"))
                            {

                                ClickButton(selectaccountPageobj.locatorforcontinueBtn, driver);
                                Assert.IsTrue(IsElementPresentUsingBy(allMenusObj.locatorforBook, driver), "Vacaction Club Owner did not logged In");
                                extentTest.Pass("Vacaction Club Owner logged in to Home Page", AttachScrenshot(driver, testContext, "HomePage").Build());
                                driver.Navigate().Back();
                            }

                            else if (!AccountName.Contains("Vacation Club"))
                            {
                                ClickButton(AccountNumbers[i], driver);
                                ClickButton(selectaccountPageobj.locatorforcontinueBtn, driver);


                                Assert.IsTrue(GetElement(homePgObj.locatorforresortName, driver).Text.Contains(AccountName), " Non club ownwer should see resort name on homepage");
                                extentTest.Pass("Resort name is coming on homepage", AttachScrenshot(driver, testContext, "ResortNameVisisble").Build());
                                driver.Navigate().Back();
                            }

                        }


                    }
                    else
                    {
                        Assert.Fail("User Should not see Select an Account Page as they do not see radio button to choose account");
                        extentTest.Fail("User Should not see Select an Account Page as they do not see radio button to choose account" + "\r\n", AttachScrenshot(driver, testContext, "Failedstep").Build());
                    }


                }



                else if (IsSingleELementVisible(selectaccountPageobj.HomePagelocatorforNonClub, driver))
                {

                    Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforresortName, driver), "Non Vac club did not see resort name on home page");
                    extentTest.Pass("Resort name visible for NON VC" + "\r\n", AttachScrenshot(driver, testContext, "NonVCOnwer_Homepage").Build());

                }


                else if (IsElementPresentUsingBy(allMenusObj.locatorforBook, driver))
                {
                    Assert.IsTrue(IsElementPresentUsingBy(allMenusObj.locatorforBook, driver), "VC Club Owner not logged into to home Page");
                    extentTest.Pass("VC owner is logged in to homepage" + "\r\n", AttachScrenshot(driver, testContext, "VCowner_homepage").Build());

                }


                if (driver.Url.Contains(expected))
                {
                    ClickButton(selectaccountPageobj.locatorforcontinueBtn, driver);

                    LogOff(homePgObj.locatorForlogOffDiv, homePgObj.locatorForSignoutBtn, driver);
                    extentTest.Info("Logged of from BGO");
                }
                else
                {

                    LogOff(homePgObj.locatorForlogOffDiv, homePgObj.locatorForSignoutBtn, driver);
                    extentTest.Info("Logged of from BGO");

                }
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Error").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Error").Build());

                    Assert.Fail(e.Message);
                }
            }
           
        }

    }
}

#region Below code is written by Remya , we are not using it .

/* public static bool ValidateSelectAccountPageForOwnerType(TestContext testContext)
 {
     bool flag = true;
;

     try
     {

         switch (testContext.DataRow["OwnerType"].ToString().ToLower())
         {
             case "nonclubmultiple":
                 Assert.IsFalse(IsElementVisible(selectaccountPageobj.vacationClubRadioBtn), "Vacation club account were present in the select account page for Non Club Only owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Vacation club account was not present in the select account page for Non club Only owner");
                 Assert.IsTrue(IsElementVisible(selectaccountPageobj.HomePagelocatorforNonClub), "Non Vacation club account were not shown for NonClub Only owner in Select Account page");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Non Vacation club account were shown for NonClub Only owner in Select Account page");
                 // Assert.IsTrue(SelectRadioButtonsAndNavigate(selectAcctObj.nonClub.Count, homepageObj, testContext, selectAcctObj), "the Pages were shown correctly on selecting on selecting the non club accounts on select account page");
                 selectaccountPageobj.continueBtn.Click();
                 break;
             case "nonclubsingle":
                 Assert.IsFalse(IsElementVisible(selectaccountPageobj.HomePagelocatorforNonClub),"Select Account page was shown for NonClub Only Single association owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Select Account page was not  shown for NonClub Only Single association owner");
               //  Assert.IsTrue((SelectRadioButtonsAndNavigate(selectAcctObj.nonClub.Count, homepageObj, testContext, selectAcctObj)),"the Pages were shown correctly on selecting on selecting the non club accounts on select account page");
                 break;
             case "club":
               Assert.IsFalse(IsElementVisible(selectaccountPageobj.locatorforvacationClubRadioBtn), "Select account page was shown for Club Only owner");
               TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Select account page was not shown for Club Only owner");
                 Assert.IsTrue(IsElementVisible(allMenusObj.locatorforBook), "Home page was not shown On selecting the club radio button for Club Only owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Home page was shown On selecting the club radio button for Club Only owner");
                 break;
             case "sampler":
                 Assert.IsTrue(IsElementVisible(allMenusObj.locatorforBook, Constants.medLoadTime), "Login was not successful for Sampler owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Login was successful for Sampler owner");
                 break;
             case "mixed":
                 Assert.IsTrue(IsElementVisible(selectaccountPageobj.locatorforvacationClubRadioBtn), "Vacation Club  radio button was not shown on Select account page for Mixed owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Vacation Club radio button was shown on Select account page for Mixed owner");
                 selectaccountPageobj.continueBtn.Click();
                 Assert.IsTrue(IsElementVisible(allMenusObj.locatorforBook), "Home page was not shown On selecting the club radio button for mixed owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Home page was shown On selecting the club radio button for mixed owner");
                 driver.Navigate().Back();


                 //Assert.IsTrue(IsElementVisible(selectaccountPageobj.LocatorForNonVacationClub()), "Non Vacation club account were not shown for mixed owner in Select Account page");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Non Vacation club account were shown for mixed  owner in Select Account page");




                 Assert.IsTrue(IsElementVisible(selectaccountPageobj.HomePageNonClub), "Home page was not shown On selecting the club radio button for mixed owner");
                 TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Home page was shown On selecting the club radio button for mixed owner");
                 //Assert.IsTrue(SelectRadioButtonsAndNavigate(selectAcctObj.nonClub.Count, homepageObj, testContext, selectAcctObj), "the Pages were shown correctly on selecting on selecting the non club accounts on select account page");
                 break;
         }
     }
     catch (Exception e)
     {
         flag = false;
         logger.Trace(e.StackTrace + "\r\n" + e.Message);
         TestBaseClass.printOutputAndCaptureImage(testContext, driver, e.Message);
     }
     return flag;
 }

 public static bool SelectRadioButtonsAndNavigate(int numberOfNonClubAccnts, HomePage homepageObj, TestContext testContext, SelectAnAccountPage selectAcctObj)
 {
     bool flag = false; 
     IWebElement ele;
     string resortName = "";
     try
     {
         //for nonclub
         if (numberOfNonClubAccnts >= 1)
         {
             for (int i = 0; i < numberOfNonClubAccnts; i++)
             {
                 selectAcctObj.xpathForNonClub = "(//label[not(text()='Vacation Club')])[" + (i + 1).ToString() + "]";
                 ele = TestBaseClass.FindElementInsideAnotherUsingDriver(selectAcctObj.AccountsTable, "xpath", selectAcctObj.xpathForNonClub);
                 if (ele != null)
                 {
                     resortName = ele.Text;
                     ele.Click();
                     Assert.IsTrue(TestBaseClass.isElementVisible(homepageObj.locatorforresortName, Constants.medLoadTime), "Resort page was not shown.");
                     TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Resort page was shown.");
                     string bb = homepageObj.resortName.Text;
                     Assert.IsTrue(homepageObj.resortName.Text.ToLower().Replace(" ","").Contains(resortName.ToLower().Replace(" ","")), "Resort Name was not displayed for " + resortName);
                     TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Resort Name was displayed for " + resortName);
                     if (i < (numberOfNonClubAccnts - 1))
                         driver.Navigate().Back();
                     flag = true;
                 }
                 else
                     flag = false;
             }
         }
         else
         {
             Assert.IsTrue(TestBaseClass.isElementVisible(homepageObj.locatorforresortName, Constants.medLoadTime), "Resort page was not shown for."+homepageObj.resortName.Text);
             TestBaseClass.printOutputAndCaptureImage(testContext, driver, "Resort page was shown for."+ homepageObj.resortName.Text);
             flag = true;
         }
     }
     catch(Exception e)
     {
         logger.Trace(e.StackTrace + "\r\n" + e.Message);
         TestBaseClass.printOutputAndCaptureImage(testContext, driver, e.Message);
     }
     return flag;
 }
 */

#endregion
