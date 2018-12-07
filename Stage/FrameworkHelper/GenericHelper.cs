using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Utilities
{
    public class GenericHelper : TextBoxHelper
    {
        #region Functions
/// <summary>
/// This is customized method fo Webdriver wait class
/// </summary>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>WebDriverWait</returns>
        public static WebDriverWait GetWebdriverWait(IWebDriver driver,int timeout=(int)Timeout.ShortwaitInSecond)
            
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)Timeout.ImplicitWaitInSecond);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds((double)Timeout.TimeoutInMilSecond)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
           // ReportsHelper.extentTest.Info("Wait object created");
            return wait;
        }


/// <summary>
/// This method check presence of element
/// using By locator
/// </summary>
/// <param name="locator"></param>
/// <param name="driver"></param>
/// <returns>bool</returns>
        public static bool IsElementPresent(By locator, IWebDriver driver)
        {
            try
            {

                ReportsHelper.extentTest.Info("Checking for single the element with locator  " + locator);
                return driver.FindElements(locator).Count == 1;

            }

            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception occured");
                return false;
            }
        }
/// <summary>
/// This method use explicit wait
/// for checking visibility of element
/// using By locator and inbuilt method
/// </summary>
/// <param name="element"></param>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>bool</returns>
        public static bool IsSingleELementVisible(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            try
            {
                ReportsHelper.extentTest.Info("Waiting for single element to be visible  with locator " + locator);
                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).Count == 1;
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception occured");
                return false;
            }
        }

 /// <summary>
 /// This method use explicit wait
 /// for checking visibility of element
 /// using IWebelement and GetElementFuncbool
 /// </summary>
 /// <param name="element"></param>
 /// <param name="driver"></param>
 /// <param name="timeout"></param>
 /// <returns>bool</returns>
            public static bool IsSingleELementVisible(IWebElement element, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
            {
                try
                {
                    ReportsHelper.extentTest.Info($"Waiting for single element to be visible  with locator { element.Text}");
                    var wait = GetWebdriverWait(driver, timeout);
                    return wait.Until(GetElementFuncbool(element));
                }
                catch (Exception e)
                {
                    ReportsHelper.extentTest.Info($"Exception occured ");
                    return false;
                }

            }


        /// <summary>
        /// This method uses Selenium Inbuilt function
        /// VisibilityOfAllElementsLocatedBy(locator)
        /// to check visibility of element on screen
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>

        public static bool IsAllElementsVisible(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            try
            {

                ReportsHelper.extentTest.Info("Waiting for all elements to be visible  with locator " + locator);

                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).Count > 0;
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception occured ");
                return false;
            }
        }
    

        /// <summary>
        ///This method checks the presence
        ///of element on page using
        ///IWebelement
        /// </summary>
        /// <param name="element"></param>
        /// <returns>IWebElement</returns>
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                ReportsHelper.extentTest.Info($"Checking for the element with { element.Text}");
                return element.Displayed;
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception occured");
                return false;
            }

        }
        /// <summary>
        /// This method use customized logic to
        /// check presence fo all element By locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <returns>bool</returns>
        public static bool IsAllElementsPresent(By locator, IWebDriver driver)
        {
            try
            {

                ReportsHelper.extentTest.Info($"Checking for all the elements with {locator}");
                return driver.FindElements(locator).Count > 0;

            }

            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception occured ");
                return false;
            }
        }

/// <summary>
///This method will Get th element on page by using 
///IWebelement
///to be completed on page
/// </summary>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>IWebElement</returns>
        public static IWebElement GetElement(By locator, IWebDriver driver)
        {

            if (IsElementPresent(locator, driver))
                return driver.FindElement(locator);
            else

                throw new NoSuchElementException($"Element not found");



        }

/// <summary>
///This method will Get th element on page by using 
///IWebelement
///to be completed on page
/// </summary>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>IWebElement</returns>
        public static IWebElement GetElement(IWebElement element)
        {

            if (IsElementPresent(element))
                return element;
            else

                throw new NoSuchElementException("Element not found ");


        }

        
/// <summary>
///This is func delegate
///which wait for any Jscript /Ajaxj call to completed on page
/// </summary>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>bool</returns>

        public static Func<IWebDriver, bool> JsFunc(IWebDriver driver)
        {
            bool IsAjaxFinished = (bool)((IJavaScriptExecutor)driver).
            ExecuteScript("return jQuery.active == 0");
            bool IsjsLoaded = ((IJavaScriptExecutor)driver).
            ExecuteScript("return document.readyState").ToString().Equals("complete");
            return x => IsAjaxFinished || IsjsLoaded;
        }
/// <summary>
///This method wait for Java/Ajax call 
///to be completed on page
/// </summary>
/// <param name="driver"></param>
/// <param name="timeout"></param>
/// <returns>bool</returns>
        public static bool IsJavascriptCompleted(IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            try
            {

                ReportsHelper.extentTest.Info("Waiting for javascript to complete");

                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(JsFunc(driver));
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info($"Exception :{e} occured while waiting for javascript to compelete");
                return false;
            }
        }


/// <summary>
///This is func delegate
///which retruns webelement
///find By locator
/// </summary>
/// <param name="locator"></param>
/// <returns>WebElement</returns>
        public static Func<IWebDriver, IWebElement> GetElementFunc(By locator)
        {
            return
             (
                (x) =>
             {
                 if (x.FindElements(locator).Count == 1)
                     return x.FindElement(locator);
                 return null;
             }
             );
        }

        public static Func<IWebDriver, IWebElement> GetElementFunc(IWebElement element)
        {
            return
             (
                (x) =>
                {
                    
                        return element.Displayed ? element:null;
                    
                }
             );
        }
/// <summary>
///This is func delegate
///which retruns bool and check elements is displayed 
/// </summary>
/// <param name="element"></param>
/// <returns>bool</returns>
public static Func<IWebDriver, bool> GetElementFuncbool(IWebElement element)
{
    return
     (
        (x) =>
        {

            return element.Displayed ? true : false;

        }
     );
}

/// <summary>
///This is func delegate
///which retruns List of webelements
///find By locator
/// </summary>
/// <param name="locator"></param>
/// <returns>List</returns>
public static Func<IWebDriver, IList<IWebElement>> GetElementsFunc(By locator)
        {

            return
               (
                  (x) =>
                {
                    return x.FindElements(locator);
                }
               );
        }



        /// <summary>
        /// This method uses Selenium in built method
        /// ElementToBeClickable(element) to check element is clickable
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElementToBeClickable(IWebElement element, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            try
            {
                ReportsHelper.extentTest.Info($"Waiting for element to clickable for { element.Text}");
                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));

            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return null;
            }
        }
        /// <summary>
        /// This method uses Selenium in built method
        /// ElementToBeClickable(locator) to check element is clickable
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElementToBeClickable(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {

            try
            {
                ReportsHelper.extentTest.Info($"Waiting for element to clickable for {locator}");
                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return null;
            }
        }

        /// <summary>
        ///This method uses Selenium in built method
        ///InvisibilityOfElementLocated(locator) to check 
        ///invisibility of element By locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public static bool IsElementInvisible(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            try
            {
                ReportsHelper.extentTest.Info($"Waiting for element to be invisible for {locator}");
                var wait = GetWebdriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return false;
            }
        }

        /// <summary>
        /// This method uses customized method
        /// for To check presence of all the elements
        /// present By locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>IList</returns>
        public static IList<IWebElement> GetListOfElements(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {

            try
            {
                ReportsHelper.extentTest.Info($"Waiting for all elements to be present on page for {locator}");
                var wait = GetWebdriverWait(driver, timeout);

                return wait.Until(GetElementsFunc(locator));
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return null;
            }
        }
        /// <summary>
        ///This method uses cutomized logic for
        ///waiting for element to be present on screen
        ///using By Locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>IWebElement</returns>
            public static IWebElement WaitForElement(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
            {

                try
                {
                    ReportsHelper.extentTest.Info($"Waiting for single element to be present on page for {locator}");
                    var wait = GetWebdriverWait(driver, timeout);

                return wait.Until(GetElementFunc(locator));
                }
                catch (Exception e)
                {
                    ReportsHelper.extentTest.Info(e.Message);
                    return null;
                }


            }
        /// <summary>
        ///This method uses cutomized logic for
        ///waiting for element to be present on screen
        ///using element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElement(IWebElement element, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {

            try
            {
                ReportsHelper.extentTest.Info($"Waiting for single element to be present on page for {element.Text }");
                var wait = GetWebdriverWait(driver, timeout);

                return wait.Until(GetElementFunc(element));
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return null;
            }


        }
        /// <summary>
        /// This method uses customized logic 
        /// for checking element presence using By locator
        /// It uses custom func delegate
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="driver"></param>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public static bool IsElementPresentUsingBy(By locator, IWebDriver driver, int timeout = (int)Timeout.ShortwaitInSecond)
        {

            try
            {
                ReportsHelper.extentTest.Info($"Waiting for single element to be present on page for {locator}");
                
                var wait = GetWebdriverWait(driver, timeout);
               return wait.Until(GetElementsFunc(locator)).Count == 1;
                
            }
            catch (Exception e)
            {
                ReportsHelper.extentTest.Info(e.Message);
                return false;
            }


        }
        #endregion
    }

    }

