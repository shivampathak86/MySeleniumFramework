using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Utilities
{
    public  class ComboBoxHelper:CheckBoxHelper
    {
        private static SelectElement _select;


        public static void SelectElementByIndex(By locator, IWebDriver driver, int index, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _select = new SelectElement(GenericHelper.WaitForElement(locator,driver,timeout));
            _select.SelectByIndex(index);
        }

        public static void SelectElementByIndex(IWebElement element, IWebDriver driver, int index, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _select = new SelectElement(GenericHelper.WaitForElement(element,driver, timeout));
            _select.SelectByIndex(index);
        }

        public static void SelectElementByText(By locator, IWebDriver driver,string visibletext, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _select = new SelectElement(GenericHelper.WaitForElement(locator,driver,timeout));
            _select.SelectByText(visibletext);
        }

        public static void SelectElementByText(IWebElement element, IWebDriver driver, string visibletext,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _select = new SelectElement(GenericHelper.WaitForElement(element,driver, timeout));
            _select.SelectByText(visibletext);
        }

        public static void SelectElementByValue(By locator, IWebDriver driver,string valueTexts,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _select = new SelectElement(GenericHelper.WaitForElement(locator,driver,timeout));
            _select.SelectByValue(valueTexts);
        }

        public static void SelectElementByValue(string valueTexts, IWebElement element, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _select = new SelectElement(GenericHelper.WaitForElement(element,driver, timeout));
            _select.SelectByValue(valueTexts);
        }

        public static IList<string> GetAllItem(By locator, IWebDriver driver,int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _select = new SelectElement(GenericHelper.WaitForElement(locator,driver,timeout));
            return _select.Options.Select(x => x.Text).ToList();
        }

        public static IList<string> GetAllItem(IWebElement element, IWebDriver driver, int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _select = new SelectElement(GenericHelper.WaitForElement(element,driver));
            return _select.Options.Select(x => x.Text).ToList();
        }




    }
}