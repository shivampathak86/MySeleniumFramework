
using System;
using OpenQA.Selenium;


namespace Utilities
{
  
    public  class Buttonhelper:BrowserHelper
    {
        private static IWebElement _element;

        
        


        

       public static void ClickButton(By locator , IWebDriver driver ,int timeout= (int)Timeout.ShortwaitInSecond)
           {
               if (locator == null) throw new ArgumentNullException(nameof(locator));
               _element = GenericHelper.WaitForElement(locator,driver, timeout);
            _element.Click();
            
           }





        public static void ClickButton(IWebElement element, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _element = GenericHelper.WaitForElement(element,driver,timeout);
           _element.Click();
            
        }


       

        public static bool IsButtonEnabled(IWebElement element, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            _element = GenericHelper.WaitForElementToBeClickable(element, driver, timeout);
            if(GenericHelper.IsElementPresent(_element))
               return true;
            return false;

           
        }



        public static bool IsButtonEnabled(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElementToBeClickable(locator, driver, timeout);
            if (GenericHelper.IsElementPresent(_element))
                return true;
            return false;
        }



        public static string GetButtonText(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            _element = GenericHelper.WaitForElement(locator,driver,timeout);
            return _element.GetAttribute("value") ?? string.Empty;
        }
    }
}
