using OpenQA.Selenium;

using static System.String;

namespace Utilities
{
   public  class AlertHelper:Driver
    {


        public static bool IsPopupPresent(IWebDriver driver)
        {
            try
            {

                 driver.SwitchTo().Alert();
                return true;
            }
            catch(NoAlertPresentException)
            {
                return false;
            }
        }
        public static string GetPopUpText(IWebDriver driver)
        {
            return !IsPopupPresent(driver) ? Empty : driver.SwitchTo().Alert().Text;
        }

        public static void AcceptPopup(IWebDriver driver)
        {
            if (!IsPopupPresent(driver))
                return;
            WebDriver.SwitchTo().Alert().Accept();
        }

        public static void DismissPopup(IWebDriver driver)
        {
            if (!IsPopupPresent(driver))
                return;
            WebDriver.SwitchTo().Alert().Dismiss();
        }


        public static void EntertextInPopup(string text, IWebDriver driver)
        {
            if (IsPopupPresent(driver)) return;
           WebDriver.SwitchTo().Alert().SendKeys(text);
        }

        public static void SendCredentialsInBrowserPopup(string userName, string passWord, BrowserType type)
        {
            if (type != BrowserType.Firefox) return;
            var browserAlert = WebDriver.SwitchTo().Alert();

            browserAlert.SetAuthenticationCredentials(userName, passWord);

        }
    }
}
