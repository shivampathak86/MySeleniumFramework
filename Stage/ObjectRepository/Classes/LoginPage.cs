using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
//using BlueGreenOwner.webDriver_Extensions;
using System.Configuration;
using System;
using System.Threading;
using BlueGreenOwner;
using System.Collections.Generic;
//using BlueGreenOwner.Utils;

namespace BlueGreenOwner
{


    public class LoginPage
    {


        [FindsBy(How = How.XPath, Using = "//input[@id='txtEmail']")]
        public IWebElement UserName;
        public By locatorforUserName = By.XPath("//input[@id='txtEmail']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Bluegreen Vacations']")]
        public IList <IWebElement> BluegreenVacations_header { get; set; }
        public By locatorforBluegreenVacations_header = By.XPath("//a[text()='Bluegreen Vacations']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtPassword']")]
        public IWebElement Password;
        public By locatorforPassword = By.XPath("//input[@id='txtPassword']");

        [FindsBy(How = How.XPath, Using = "//button[text()='Sign In']")]
        public IWebElement LoginButton;
        public By locatorforLoginButton = By.XPath("//button[text()='Sign In']");

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        public IWebElement continueBtn;
        public By locatorforcontinueBtn = By.XPath("//button[text()='Continue']");


        public string loginSuccessUrlForFlexFixUser = String.Empty;
        public string loginSuccessUrlForSpecialcase = String.Empty;
        public string loginSuccessUrlPaymentBalance = String.Empty;
        public string loginSelectAccountUrl = String.Empty;
        public string loginTPRenewUrl = String.Empty;
        public string loginMyPoints = String.Empty;
        public string loginChangePassword = String.Empty;

        [FindsBy(How = How.XPath, Using = " //a[.='back to sign in']")]
        public IWebElement backToSignInLink;
        public By locatorForbackToSignInLink = By.XPath(" //a[.='back to sign in']");

        [FindsBy(How = How.XPath, Using = " //a[.='Register Today']")]
        public IWebElement registerTodayLink;
        public By locatorForregisterTodayLink = By.XPath("//a[.='Register Today']");

        [FindsBy(How = How.XPath, Using = "//strong[.='Register']")]
        public IWebElement registerWithyBlueGreenVacationsPage;
        public By locatorForregisterWithyBlueGreenVacationsPage = By.XPath("//strong[.='Register']");


        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'confirmation')]")]
        public IWebElement registrationConfirmationPage;
        public By locatorForregistrationConfirmationPage = By.XPath("//h1[contains(text(),'confirmation')]");

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public LoginPage()
        {

        }


        //*********************************************************Constructor************************************************************************************



        //**************Login functionality*************************************************************************************************************************

        //public bool login_BlueGreenOwner(LoginPage loginPage, string username, string password)
        //{
        //    bool val = false;
        //    try
        //    {

        //        if ((WebElementExtensions.isElementClickable(loginPage.UserName, Constants.medLoadTime)
        //            && (WebElementExtensions.isElementClickable(loginPage.Password, Constants.medLoadTime))
        //            && (WebElementExtensions.isElementClickable(loginPage.LoginButton, Constants.medLoadTime))))
        //        {
        //            loginPage.UserName.SendKeys(username);
        //            loginPage.Password.SendKeys(password);

        //            loginPage.LoginButton.Submit();
        //            Thread.Sleep(5000);
        //            HomePage homepageObj = new HomePage();
        //            PageFactory.InitElements(TestBaseClass.baseDriver, homepageObj);


        //            if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginTPRenewUrl))
        //            {

        //                val = true;
        //            }
        //            else if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginSelectAccountUrl))
        //            {
        //                val = true;
        //PROD
        //                TestBaseClass.baseDriver.Url = @"https://sc.bluegreenowner.com/home";
        //STAGE
        // TestBaseClass.baseDriver.Url = @"https://stg.sitecore.bluegreenowner.com/home";
        //            }

        //            else if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginSuccessUrlForSpecialcase))
        //                val = true;
        //            else if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginSuccessUrlForFlexFixUser))
        //                val = true;
        //            else if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginSuccessUrlPaymentBalance))
        //                val = true;
        //            else if (TestBase.TestBaseClass.baseDriver.Url.Equals(loginMyPoints))
        //                val = true;



        //            else if (WebElementExtensions.isElementVisible(homepageObj.locatorForskipChangePassword, Constants.medLoadTime))
        //            {
        //                homepageObj.skipChangePassword.Click();
        //                val = true;
        //            }

        //            else if (WebElementExtensions.isElementVisible(homepageObj.locatorForPointsButton, Constants.medLoadTime))
        //                val = true;

        //            else if (WebElementExtensions.isElementVisible(homepageObj.locatorForvactionClubAccount, Constants.medLoadTime))
        //            {
        //                homepageObj.vactionClubAccount.Click();
        //                val = true;
        //            }





        //        }

        //        return val;

        //    }
        //    catch (Exception E)
        //    {
        //        ErrorLog Err = new ErrorLog();
        //        Err.LogError(TestBaseClass.resultsFolderpath, E.Message, "login_BlueGreenOwner");
        //        return false;

        //    }


        //}


        //vssa home page

        //public bool login_BlueGreenOwner(LoginPage loginPage, string username, string password)
        //{
        //    bool val = false;
        //    try
        //    {
        //        if (login_fromVSSA(username))
        //        {
        //            Thread.Sleep(5000);
        //            HomePage homepageObj = new HomePage();
        //            PageFactory.InitElements(TestBaseClass.baseDriver, homepageObj);

        //            AllMenus allMenuObj = new AllMenus();
        //            PageFactory.InitElements(TestBaseClass.baseDriver, allMenuObj);

        //            //if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["URlHomePage"].ToLower()))

        //            //    val = true;
        //            //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToLower()))
        //            //{
        //            //  // homepageObj.ContinueButton.Click();
        //            //    val = true;
        //            //}
        //            //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSuccessUrlForFlexFixUser"].ToLower()))
        //            //    val = true;
        //            //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSuccessUrlPaymentBalance"].ToLower()))
        //            //    val = true;
        //            //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginMyPoints"].ToLower()))
        //            //    val = true;

        //            //else if (TestBaseClass.isElementVisible(homepageObj.locatorForskipChangePassword, Constants.shortLoadTime))
        //            //{
        //            //    homepageObj.skipChangePassword.Click();

        //            //}
        //            if (TestBaseClass.isElementVisible(allMenuObj.locatorforBook, Constants.veryLongLoadTime))
        //                val = true;

        //            else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToLower()))
        //            {
        //                homepageObj.vactionClubAccount.Click();
        //                val = true;
        //            }
        //            else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["URlHomePage"].ToLower()))
        //            {
        //                val = true;
        //            }
        //        }

        //        return val;
        //    }
        //    catch (Exception E)
        //    {
        //        // ErrorLog Err = new ErrorLog();
        //        //Err.LogError(TestBaseClass.resultsFolderpath, E.Message, "login_BlueGreenOwner");
        //        return false;
        //    }
        //}



        public bool login_fromVSSA(string username)
        {
            bool flag = false;
            VSSAHomePage vssaObj = new VSSAHomePage(TestBaseClass.baseDriver);
            //PageFactory.InitElements(TestBaseClass.driver, vssaObj);

            TestBaseClass.baseDriver.Url = ConfigurationManager.AppSettings["UrlForVSSAHomePage"];

            try
            {
                if (TestBaseClass.isElementVisible(vssaObj.locatorForArvactnumber, Constants.veryLongLoadTime))
                {

                    if (TestBaseClass.SearchVssaByArvact(vssaObj, username))
                    {
                        vssaObj.EmailUpdate.SendKeys(username+"bxgcorp.com");
                        vssaObj.EmailUpdateBtn.Click();
                        if ((TestBaseClass.isElementClickable(vssaObj.loginAsuSer, Constants.veryLongLoadTime)))
                        {
                            vssaObj.loginAsuSer.Click();
                            flag = true;

                        }


                        //   flag = true;


                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {

                    flag = false;

                }
            }
            catch (Exception E)
            {
                //  ErrorLog Err = new ErrorLog();
                //  Err.LogError(TestBaseClass.resultsFolderpath, E.Message, "login_fromVSSA");
                flag = false;


            }
            return flag;

        }

    }
}

