using System;
using System.Configuration;
using OpenQA.Selenium;

namespace Utilities
{
    public  class LoginHelper:LinkHelper
    {
        public static void Goto_BGO()
        {
            Utilities.Driver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }


        public static void Goto_VSSA()
        {
            Utilities.Driver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlForVSSAHomePage"]);
        }


        public static void Login_FromBGO(IWebElement UserName, IWebElement Password, IWebElement SignInbtn,IWebDriver driver,
            string username, string password,IWebElement continueButton, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (UserName == null) throw new ArgumentNullException(nameof(UserName));
            if (Password == null) throw new ArgumentNullException(nameof(Password));
            if (SignInbtn == null) throw new ArgumentNullException(nameof(SignInbtn));
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));
            TextBoxHelper.TypeInTextBox(UserName,driver, username, timeout);
            TextBoxHelper.TypeInTextBox(Password,driver, password, timeout);
            Buttonhelper.ClickButton(SignInbtn,driver);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

            var expected = ConfigurationManager.AppSettings["loginSelectAccountUrl"];
            var actual = Utilities.Driver.WebDriver.Url;

            if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (continueButton == null) throw new ArgumentNullException(nameof(continueButton));
                Buttonhelper.ClickButton(continueButton, driver);

            }
        }

        public static void Login_FromBGO(By UserName, By Password, By SignInbtn, IWebDriver driver,
           string username, string password, By continueButton, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            if (UserName == null) throw new ArgumentNullException(nameof(UserName));
            if (Password == null) throw new ArgumentNullException(nameof(Password));
            if (SignInbtn == null) throw new ArgumentNullException(nameof(SignInbtn));
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));
            TextBoxHelper.TypeInTextBox(UserName, driver, username, timeout);
            TextBoxHelper.TypeInTextBox(Password, driver, password, timeout);
            Buttonhelper.ClickButton(SignInbtn, driver);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

            var expected = ConfigurationManager.AppSettings["loginSelectAccountUrl"];
            var actual = Utilities.Driver.WebDriver.Url;

            if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (continueButton == null) throw new ArgumentNullException(nameof(continueButton));
                Buttonhelper.ClickButton(continueButton, driver);

            }
        }


        public static bool IsUserLoggedIn(IWebElement element,IWebDriver driver, int timeout = (int) Timeout.LongwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
            return GenericHelper.IsElementPresent(element);
        }

        public static bool BGO_IsUserLoggedIn(By locator, IWebDriver driver, int timeout = (int)Timeout.LongwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
            return GenericHelper.IsElementPresent(locator,driver);
        }

        public static void VSSA_Click_loginAsUser_btn(By vssaLoginAsUserBtn,IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (vssaLoginAsUserBtn == null) throw new ArgumentNullException(nameof(vssaLoginAsUserBtn));
            Buttonhelper.ClickButton(vssaLoginAsUserBtn,driver, timeout);
        }


        public static void Goto_VSSAPremierReportPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlForVSSAPremierReportPage"]);
        }


        public static void VSSA_Click_ArvactResultLink(By arvactResultLink, IWebDriver driver,
            int seconds = (int) Timeout.ShortwaitInSecond)

        {
            if (arvactResultLink == null) throw new ArgumentNullException(nameof(arvactResultLink));


            Buttonhelper.ClickButton(arvactResultLink,driver);
        }


        public static void VSSA_EnterArvact(By aarvactTextBoxlocator,IWebDriver  driver,string arvact,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (aarvactTextBoxlocator == null) throw new ArgumentNullException(nameof(aarvactTextBoxlocator));


            TextBoxHelper.TypeInTextBox(aarvactTextBoxlocator,driver, arvact, timeout);
        }


        public static void VSSA_Click_SearchButton(By searchButtonLocator, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (searchButtonLocator == null) throw new ArgumentNullException(nameof(searchButtonLocator));

            Buttonhelper.ClickButton(searchButtonLocator,driver, timeout);
        }

		public static void VSSA_EnterEmail(By emailTextBoxlocator, IWebDriver driver, string email,
			int timeout = (int)Timeout.ShortwaitInSecond)
		{
			if (emailTextBoxlocator == null) throw new ArgumentNullException(nameof(emailTextBoxlocator));


			TextBoxHelper.TypeInTextBox(emailTextBoxlocator,driver , email, timeout);
		}

		public static void VSSA_Click_UpdateButton(By updateButtonLocator,IWebDriver driver,
		   int timeout = (int)Timeout.ShortwaitInSecond)
		{
			if (updateButtonLocator == null) throw new ArgumentNullException(nameof(updateButtonLocator));

			Buttonhelper.ClickButton(updateButtonLocator,driver, timeout);
		}

		public static bool VSSA_IsArvactResultAvailable(By aarvactResultLocator,IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)

        {
            if (aarvactResultLocator == null) throw new ArgumentNullException(nameof(aarvactResultLocator));

            return GenericHelper.IsSingleELementVisible(aarvactResultLocator,driver, timeout);
        }
    }
}