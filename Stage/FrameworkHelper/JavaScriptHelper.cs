using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Utilities
{
    public  class JavaScriptHelper:ComboBoxHelper
    {
        public static object ExecuteScript(string script,IWebDriver driver)
        {
            if (script == null) throw new ArgumentNullException(nameof(script));
          
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            var executor = (IJavaScriptExecutor)driver;
            return executor.ExecuteScript(script);
        }

        public static object ExecuteScript(string script,IWebElement element,IWebDriver driver)
        {
            if (script == null) throw new ArgumentNullException(nameof(script));
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var executor = (IJavaScriptExecutor)driver;
            return executor.ExecuteScript(script,element);
        }

        public static void JavascriptScrollBy(string X, string Y, IWebDriver driver)
        {
            if (X == null) throw new ArgumentNullException(nameof(X));
            if (X == null) throw new ArgumentNullException(nameof(Y));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            ExecuteScript("window.scrollBy(" + X + "," + Y + ")", driver);
            
        }

        public static void JavascriptScrollTo(string X, string Y, IWebDriver driver)
        {
            if (X == null) throw new ArgumentNullException(nameof(X));
            if (Y == null) throw new ArgumentNullException(nameof(Y));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            ExecuteScript("window.scrollTo(" + X + "," + Y + ")", driver);

        }

        public static void JavascriptClickElement(IWebElement element,IWebDriver driver)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            ExecuteScript("arguments[0].click()", element, driver);
        }


        public static void JavascriptSendKeys(IWebElement element, string text, IWebDriver driver)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (driver==null) throw new ArgumentNullException(nameof(driver));

            ExecuteScript("arguments[0].value='" + text + "';" ,element ,driver);
        }

        public static void ScrollToView(IWebElement element, IWebDriver driver)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            ExecuteScript("arguments[0].scrollIntoView(true);", element, driver);
        }

        public static object JavascriptGetElementby(IWebDriver driver,string className)
        {
            return ExecuteScript("return document.getElementsByClassName('" + className + "')",driver);
           

        }


        public static  IWebElement ExpandRootElement(IWebElement element, IWebDriver driver)
        {
            IWebElement ShadowRootElement = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", element);

            return ShadowRootElement;
        }



        public static void  ClickDownloadLink_FromShadowDOMElements(IWebDriver driver)
        {

            IWebElement root1 = driver.FindElement(By.TagName("downloads-manager"));

            //Get shadow root element
            IWebElement shadowRoot1 = ExpandRootElement(root1,driver);

            IWebElement root2 = shadowRoot1.FindElement(By.CssSelector("iron-list"));
            IWebElement shadowRoot2 = ExpandRootElement(root2,driver);


            IWebElement root3 = shadowRoot2.FindElement(By.TagName("downloads-item"));  // root3 element getting null value here
            IWebElement shadowRoot3 = ExpandRootElement(root3, driver);

            shadowRoot3.FindElement(By.CssSelector("div[id=title-area]")).Click();

        }

       





















    }
}