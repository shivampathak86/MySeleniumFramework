using System;
using OpenQA.Selenium;

namespace Utilities
{
    public  class LinkHelper:JavaScriptHelper
    {
        private static IWebElement _element;

        public static void ClickLink(By locator,IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            _element = GenericHelper.WaitForElement(locator,driver, timeout);

            _element.Click();
        }

        public static void ClickLink(IWebElement element, IWebDriver driver,int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            _element = GenericHelper.WaitForElement(element,driver, timeout);

            _element.Click();
        }
    }
}