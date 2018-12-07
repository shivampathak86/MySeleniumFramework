using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class FooterLinks : LoginMethod
    {

        public static void ValidateFooterLinks_VCorNonVCmultiple(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);
            LoginPage loginObj = new LoginPage(driver);


            try
            {

                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToString()), "Select an account page is not displayed for VC/Non_Vc multiple owner");

                Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorForSelectAnAccountPg,driver), "Select an account page is not displayed for VC/Non_Vc multiple owner");
                extentTest.Pass("Select an account page is displayed for VC/Non_Vc multiple owner", AttachScrenshot(driver, testContext, "SelectAnAccountPage").Build());

                ClickButton(loginObj.locatorforcontinueBtn, driver);

                Assert.IsTrue(BGO_IsUserLoggedIn(homePgObj.locatorLogOffDivByXpath, driver), "User did not reach BGO homepage");
                extentTest.Pass("User reached to BGO home page", AttachScrenshot(driver, testContext, "HomePage").Build());

                Assert.IsTrue(IsElementPresent(homePgObj.locatorforHelpOrFAQsLink, driver), "Help/FAQs Link is not displayed ");
                extentTest.Pass("Help/FAQs Link is displayed" + "\r\n", AttachScrenshot(driver, testContext, "HelpFaqsLinkDisplayed").Build());

                ClickButton(homePgObj.locatorforHelpOrFAQsLink, driver);
                SwitchTochildWindow(driver, 1);
                extentTest.Info("Switched to ask bluegreen page");

                //driver.SwitchTo().Window(driver.WindowHandles.Last());

                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlAskBluegreen"].ToString()), "ask bluegreen page is not displayed");

                try
                {
                    Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforAskBluegreen, driver), "ask bluegreen page is not displayed");
                    extentTest.Pass("ask bluegreen page is displayed", AttachScrenshot(driver, testContext, "askBluegreenPage").Build());

                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);
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

                // driver.Close();

                SwitchToParentWindow(driver);
                extentTest.Info("Switched to BGO home page");
                // driver.SwitchTo().Window(driver.WindowHandles.First());

                Assert.IsTrue(IsElementPresent(homePgObj.locatorforContactUsLink, driver), "Contact us Link is not displayed ");
                extentTest.Pass("Contact us Link is displayed", AttachScrenshot(driver, testContext, "ContactUsLinkDisplayed").Build());

                ClickButton(homePgObj.locatorforContactUsLink, driver);
                SwitchTochildWindow(driver, 1);
                // driver.SwitchTo().Window(driver.WindowHandles.Last());
                extentTest.Info("Switched to contact us page");

                //Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlHaveAQuestion"].ToString()), "have a question? page is not displayed ");

                try
                {
                    Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforContactUs, driver), "contact us page is not displayed ");
                    extentTest.Pass("have a contact us is displayed", AttachScrenshot(driver, testContext, "HaveAQuestionPage").Build());

                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);
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
                // driver.Close();

                // driver.SwitchTo().Window(driver.WindowHandles.Last());
                SwitchToParentWindow(driver);
                extentTest.Info("Switched to BGO home page");

                LogOff(allMenusObj.locatorforMyBlueGreen, homePgObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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


        public static void ValidateFooterLinks_VCorNonVCsingle(TestContext testContext)
        {
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);
            PaymentReminderPage paymentReminderPageObj = new PaymentReminderPage(driver);
            LoginPage loginObj = new LoginPage(driver);

            try
            {

                Assert.IsTrue(BGO_IsUserLoggedIn(homePgObj.locatorLogOffDivByXpath, driver), "User did not reach BGO homepage");
                extentTest.Pass("User reached to BGO home page", AttachScrenshot(driver, testContext, "HomePage").Build());

                if (IsElementPresent(paymentReminderPageObj.paymentReminderAlert) || IsElementPresent(loginObj.BluegreenVacations_header[0]))
                {
                    ClickLink(loginObj.BluegreenVacations_header[0],driver);
                    extentTest.Info("Bluegreen vacations header  is clicked so as to dismiss alert on home page");
                    
                }


                Assert.IsTrue(IsElementPresent(homePgObj.locatorforHelpOrFAQsLink, driver), "Help/FAQs Link is not displayed ");
                extentTest.Pass("Help/FAQs Link is displayed", AttachScrenshot(driver, testContext, "HelpFaqsLinkDisplayed").Build());

                ClickButton(homePgObj.locatorforHelpOrFAQsLink, driver);


                SwitchTochildWindow(driver, 1);
                extentTest.Info("Switched to ask bluegreen page");

                // driver.SwitchTo().Window(driver.WindowHandles.Last());

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlAskBluegreen"].ToString()), "ask bluegreen page is not displayed");

                try
                {

                    Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforAskBluegreen, driver), "ask bluegreen page is not displayed");
                    extentTest.Pass("ask bluegreen page is displayed", AttachScrenshot(driver, testContext, "askBluegreenPage").Build());

                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

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
                //driver.Close();

                SwitchToParentWindow(driver);
                extentTest.Info("Switched to BGO home page");


                // driver.SwitchTo().Window(driver.WindowHandles.First());

                Assert.IsTrue(IsElementPresent(homePgObj.locatorforContactUsLink, driver), "Contact us Link is not displayed ");
                extentTest.Pass("Contact us Link is displayed", AttachScrenshot(driver, testContext, "ContactUsLinkDisplayed").Build());

                ClickButton(homePgObj.locatorforContactUsLink, driver);
                extentTest.Info("Contact us Link is Clicked");

                //driver.SwitchTo().Window(driver.WindowHandles.Last());
                SwitchTochildWindow(driver, 1);
                extentTest.Info("Switched to Contact us page");

                // Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["UrlHaveAQuestion"].ToString()), "have a question? page is not displayed ");

                try
                {
                    Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforContactUs, driver), "Contact us page is not displayed ");
                    extentTest.Pass("Contact us page is displayed", AttachScrenshot(driver, testContext, "HaveAQuestionPage").Build());

                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

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
                // driver.Close();

                // driver.SwitchTo().Window(driver.WindowHandles.Last());
                SwitchToParentWindow(driver);
                extentTest.Info("Switched to BGO home page");

                LogOff(allMenusObj.locatorforMyBlueGreen, homePgObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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

