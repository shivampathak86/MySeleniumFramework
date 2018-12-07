using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Utilities;
using System.Collections.ObjectModel;
using System.Threading;

namespace BlueGreenOwner.TestCases
{
    public class ValidateAccountNoGrid : LoginMethod
    {

        //Validate AccountNoGrid in My Account Page
        public static void ValidateAccountNumberGrid(TestContext testContext)
        {
            MyAccountPage myAccountObj = new MyAccountPage(driver);
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            VSSAHomePage vssaObj = new VSSAHomePage(driver);
            LoginPage loginObj = new LoginPage(driver);
            PaymentReminderPage paymentReminderPageObj = new PaymentReminderPage(driver);

            try
            {

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.PageLoadTimeInSecond);

                int VSSA_NoOfAccounts_Data = myAccountObj.VSSATable_AccountNumber.Count;

                int b = myAccountObj.VSSATable_NoOfAccountNumber.Count - 1;

                List<IWebElement> VSSA_AccountNoList = new List<IWebElement>();

                for (int i = 0; i < VSSA_NoOfAccounts_Data; i++)
                {

                    if (i % 3 == 0)
                    {
                        extentTest.Info("  Account details in VSSA_Row wise : Project, Account, Description");
                    }
                    VSSA_AccountNoList.Add(myAccountObj.VSSATable_AccountNumber[i]);
                    extentTest.Info(VSSA_AccountNoList[i].Text);

                }

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);


                string Url = ConfigurationManager.AppSettings["URL"];


                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.open('" + Url + "'" + ")");

                Thread.Sleep(5000);

                ////  driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "t");
                //// driver.SwitchTo().Window(driver.WindowHandles.Last());
                ////driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

                ////Actions act = new Actions(driver);
                ////act.KeyDown(Keys.Control).SendKeys("t").Perform();

                SwitchTochildWindow(driver, 1);
                extentTest.Info("switched to child window");

                //// driver.SwitchTo().Window(driver.WindowHandles.Last());

                try
                {
                    Assert.IsTrue(driver.Url.Contains(Url), "Sign in page is not  displayed");
                    extentTest.Pass("Sign in page is displayed", AttachScrenshot(driver, testContext, "SignInPage").Build());
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

                Login_FromBGO(loginObj.locatorforUserName, loginObj.locatorforPassword, loginObj.locatorforLoginButton, driver, ReadData(4, "UserName"), ReadData(4, "Password"), homePageObj.locatorForContinueButton);

                if (IsElementPresent(paymentReminderPageObj.paymentReminderAlert) || IsElementPresent(loginObj.BluegreenVacations_header[0]))
                {
                    ClickLink(loginObj.BluegreenVacations_header[0], driver);
                    extentTest.Info("Bluegreen vacations header  is clicked so as to dismiss alert on home page");

                }

                Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URlHomePage"]), "BGO Homepage is not  displayed");
                extentTest.Pass("BGO Homepage is displayed", AttachScrenshot(driver, testContext, "BGOHomepage").Build());


                MyAccount.Navigate_To_MyAccountPage(testContext);

                int NoOfAccounts_Data = myAccountObj.Table_AccountNumber.Count;

                List<IWebElement> AccountNoList = new List<IWebElement>();
                for (int i = 0; i < NoOfAccounts_Data; i++)
                {
                    if (i % 3 == 0)
                    {
                        extentTest.Info("Account details in My Account page_Row wise : Sl .No, Account, Description");
                    }

                    AccountNoList.Add(myAccountObj.Table_AccountNumber[i]);
                    extentTest.Info(AccountNoList[i].Text);

                }


                int a = myAccountObj.Table_NoOfAccountNumber.Count;

                Assert.IsTrue(a == b, "Total no. of accounts in My account page isn't matching with that on VSSA homepage ");
                extentTest.Pass("Total no. of accounts in My account page is matching with that on VSSA homepage", AttachScrenshot(driver, testContext, "MyAccountPage").Build());

                int k = 0;
                while (k < NoOfAccounts_Data)
                {

                    if (k != 0 && k % 3 != 0)
                    {
                        foreach (IWebElement VSSA_Acc in VSSA_AccountNoList)
                        {

                            driver.SwitchTo().Window(driver.WindowHandles.First());

                            String VSSAAccountNo = VSSA_AccountNoList[k].Text;
                            extentTest.Info(VSSAAccountNo);


                            foreach (IWebElement Acc in AccountNoList)
                            {

                                driver.SwitchTo().Window(driver.WindowHandles.Last());

                                String AccountNo = AccountNoList[k].Text;
                                extentTest.Info(AccountNo);


                                Assert.IsTrue(VSSAAccountNo.Contains(AccountNo), "Account Details in My account page isn't matching with that on VSSA homepage ");
                                extentTest.Pass("Account Details in My account page is matching with that on VSSA homepage", AttachScrenshot(driver, testContext, "AccountDetails").Build());

                                break;

                            }
                            break;
                        }
                    }
                    k++;
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



        // Validate AccountNoGrid in Registration Confirmation Page

        public static void ValidateAccountNumberGrid_REgConfPage(TestContext testContext)
        {
            MyAccountPage myAccountObj = new MyAccountPage(driver);
            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePageObj = new HomePage(driver);
            VSSAHomePage vssaObj = new VSSAHomePage(driver);
            RegistrationConfirmationPage regObj = new RegistrationConfirmationPage(driver);
            LoginPage loginObj = new LoginPage(driver);


            try
            {
                ClearTextBox(vssaObj.locatorForEmailUpdate, driver);
                VSSA_EnterEmail(vssaObj.locatorForEmailUpdate, driver, ReadData(5, "UserName"));
                extentTest.Info("email address is  entered");

                VSSA_Click_UpdateButton(vssaObj.locatorForEmailUpdateBtn, driver);
                extentTest.Info("Update email address button clicked");

                int VSSA_NoOfAccounts_Data = myAccountObj.VSSATable_AccountNumber.Count;

                int b = myAccountObj.VSSATable_NoOfAccountNumber.Count - 1;

                List<IWebElement> VSSA_AccountNoList = new List<IWebElement>();

                for (int i = 0; i < VSSA_NoOfAccounts_Data; i++)
                {

                    if (i % 3 == 0)
                    {
                        extentTest.Info("Account details in VSSA_Row wise : Project, Account, Description");
                    }
                    VSSA_AccountNoList.Add(myAccountObj.VSSATable_AccountNumber[i]);
                    extentTest.Info(VSSA_AccountNoList[i].Text);

                }

                string Url = ConfigurationManager.AppSettings["URL"];


                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.open('" + Url + "'" + ")");

                Thread.Sleep(5000);

                // driver.Navigate().Refresh();

                // driver.SwitchTo().Window(driver.WindowHandles.Last());

                SwitchTochildWindow(driver, 1);
                extentTest.Info("switched to child window");

                try
                {
                    Assert.IsTrue(driver.Url.Contains(ConfigurationManager.AppSettings["URL"]), "Sign in page is not  displayed");
                    extentTest.Pass("Sign in page is displayed", AttachScrenshot(driver, testContext, "SignInPage").Build());
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

                JavascriptClickElement(loginObj.registerTodayLink, driver);
                extentTest.Info("Register today link is clicked");

                //Entering details in Register with Bluegreen vacations page
                RegistrationConfirmation.GoToRegisterWithBluegreenVacactionsPage(testContext, ReadData(5, "SSN"), ReadData(5, "Arvact"), ReadData(5, "UserName"), ReadData(5, "Password"));

                //Assert.IsTrue(driver.Url.Equals(ConfigurationManager.AppSettings["UrlRegistrationConfirmationPg"]), "Registration Confirmation page is not  displayed");

                Assert.IsTrue(IsElementPresentUsingBy(loginObj.locatorForregistrationConfirmationPage, driver), "Registration Confirmation page is not  displayed");
                extentTest.Pass("Registration Confirmation page is displayed", AttachScrenshot(driver, testContext, "RegistrationConfirmationPage").Build());

                int NoOfAccounts_Data = myAccountObj.Table_AccountNumber.Count;

                List<IWebElement> AccountNoList = new List<IWebElement>();

                for (int i = 0; i < NoOfAccounts_Data; i++)
                {
                    if (i % 3 == 0)
                    {
                        extentTest.Info("Account details in Registration Confirmation page_Row wise : Sl .No, Account, Description");
                    }

                    AccountNoList.Add(myAccountObj.Table_AccountNumber[i]);
                    extentTest.Info(AccountNoList[i].Text);

                }

                int a = myAccountObj.Table_NoOfAccountNumber.Count;
                Assert.IsTrue(a == b, "Total no. of accounts in Registartion confrimation page isn't matching with that on VSSA homepage ");
                extentTest.Pass("Total no. of accounts in Registartion confrimation page is matching with that on VSSA homepage", AttachScrenshot(driver, testContext, "NoOfAccounts_RegConfirmationPage").Build());


                int k = 0;
                while (k < NoOfAccounts_Data)
                {

                    if (k != 0 && k % 3 != 0)
                    {
                        foreach (IWebElement VSSA_Acc in VSSA_AccountNoList)
                        {
                            driver.SwitchTo().Window(driver.WindowHandles.First());
                            String VSSAAccountNo = VSSA_AccountNoList[k].Text;
                            extentTest.Info(VSSAAccountNo);

                            foreach (IWebElement Acc in AccountNoList)
                            {

                                driver.SwitchTo().Window(driver.WindowHandles.Last());
                                String AccountNo = AccountNoList[k].Text;
                                extentTest.Info(AccountNo);


                                Assert.IsTrue(VSSAAccountNo.Contains(AccountNo), "Account Details in Registartion confrimation page isn't matching with that on VSSA homepage ");
                                extentTest.Pass("Account Details in Registartion confrimation page is matching with that on VSSA homepage", AttachScrenshot(driver, testContext, "AccountDetails_RegConfirmationPage").Build());


                                break;

                            }
                            break;
                        }
                    }
                    k++;
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

