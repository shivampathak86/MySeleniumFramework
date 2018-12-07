using System;
using OpenQA.Selenium;

namespace Utilities
{
    public  class RadioButtonHelper: MenusTabs
	{
        private static IWebElement _element;

        public static void ClickRadioButton(By locator, IWebDriver driver ,int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElement(locator,driver, timeout);
            _element.Click();
        }

        public static void ClickRadioButton(IWebElement element, IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            element = GenericHelper.WaitForElement(element,driver, timeout);
            element.Click();
        }

        public static bool IsRadioButtonSelected(By locator, IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElement(locator,driver, timeout);
            var flag = _element.GetAttribute("checked");

            return flag != null && (flag.Equals("true") || flag.Equals("checked"));
        }

        public static bool IsRadioButtonSelected(IWebElement element, IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            element = GenericHelper.WaitForElement(element,driver, timeout);
            var flag = element.GetAttribute("checked");

            return flag != null && (flag.Equals("true") || flag.Equals("checked"));
        }
    }
}