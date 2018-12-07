 using System;
using OpenQA.Selenium;

namespace Utilities
{
    public  class TextBoxHelper: RadioButtonHelper
	{
        private static IWebElement _element;


        public static void TypeInTextBox(By locator, IWebDriver driver,string text, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElement(locator,driver, timeout);
            _element.SendKeys(text);
        }

        public static void TypeInTextBox(IWebElement element,IWebDriver driver, string text,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _element = GenericHelper.WaitForElement(element,driver, timeout);
            _element.SendKeys(text);
        }


        public static void ClearTextBox(By locator,IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElement(locator,driver, timeout);
            _element.Clear();
        }


        public static void ClearTextBox(IWebElement element,IWebDriver driver,int timeout = (int) Timeout.ShortwaitInSecond)
        {
            _element = GenericHelper.WaitForElement(element,driver, timeout);
            _element.Clear();
        }
    }
}