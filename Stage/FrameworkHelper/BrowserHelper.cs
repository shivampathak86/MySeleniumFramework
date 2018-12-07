using OpenQA.Selenium;

namespace Utilities
{
    public  class BrowserHelper:AutoSuggestHelper
    {
        public static void BrowserMaximize(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void GoBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void ForwardI(IWebDriver driver)
        {
            Utilities.Driver.WebDriver.Navigate().Forward();
        }

        public static void RefreshPage(IWebDriver driver)
        {
           driver.Navigate().Refresh();
        }

        public static void SwitchTochildWindow(IWebDriver driver, int index = 0)
        {
            var windows = driver.WindowHandles;

            if (windows.Count - 1 < index) return;
            driver.SwitchTo().Window(windows[index]);

          //  BrowserMaximize(driver);

        }


        public static void SwitchToParentWindow(IWebDriver driver)
        {
            var windowids = driver.WindowHandles;


            for (var i = windowids.Count - 1; i > 0;)
            {
                driver.Close();
                i = i - 1;
                driver.SwitchTo().Window(windowids[i]);
            }

            driver.SwitchTo().Window(windowids[0]);
        }

        public static void SwitchToFrame(By locator,IWebDriver driver)
        {
            driver.SwitchTo().Frame(driver.FindElement(locator));
        }

        public static void SwitchToFrame(IWebElement element,IWebDriver driver)
        {
            driver.SwitchTo().Frame(element);
        }
    }
}