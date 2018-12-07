using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Utilities
{
    public  class MenusTabs:LogoutHelper

    {
        public static string MenuLevel1(List<By> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsElementPresentUsingBy(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[0],driver)).Perform();
                act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[1],driver)).Click().Build().Perform();

            // GenericHelper.GetWebdriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(GenericHelper.GetElement(listofMenuobjects[1], driver, timeout)));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)Timeout.PageLoadTimeInSecond);

            return driver.Url;
        }

        public static string MenuLevel1(List<IWebElement> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsSingleELementVisible(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(listofMenuobjects[0]).Perform();
                act.MoveToElement(listofMenuobjects[1]).Click().Build().Perform();
            //GenericHelper.GetWebdriverWait(driver,TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(listofMenuobjects[1]));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);

            return driver.Url;
        }


        public static string MenuLevel2(List<By> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsElementPresentUsingBy(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[0],driver)).Perform();
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[1], driver)).Perform();
                act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[2],driver)).Click().Build().Perform();
            // GenericHelper.GetWebdriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(GenericHelper.GetElement(listofMenuobjects[2], driver, timeout)));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);

            return driver.Url;
        }

        public static string MenuLevel2(List<IWebElement> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsSingleELementVisible(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(listofMenuobjects[0]).Perform();
            act.MoveToElement(listofMenuobjects[1]).Perform();
                act.MoveToElement(listofMenuobjects[2]).Click().Build().Perform();
            // GenericHelper.GetWebdriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(listofMenuobjects[2]));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);


            return driver.Url;
        }


        public static string MenuLevel3(List<By> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsElementPresentUsingBy(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[0], driver)).Perform();
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[1], driver)).Perform();
            act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[2], driver)).Perform();
                act.MoveToElement(GenericHelper.GetElement(listofMenuobjects[3],driver)).Click().Build().Perform();
            // GenericHelper.GetWebdriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(GenericHelper.GetElement(listofMenuobjects[3], driver, timeout)));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);

            return driver.Url;
        }

        public static string MenuLevel3(List<IWebElement> listofMenuobjects, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (listofMenuobjects == null) throw new ArgumentNullException(nameof(listofMenuobjects));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var act = new Actions(driver);
            if (!GenericHelper.IsSingleELementVisible(listofMenuobjects[0],driver, timeout)) return null;
            act.MoveToElement(listofMenuobjects[0]).Perform();
            act.MoveToElement(listofMenuobjects[1]).Perform();
            act.MoveToElement(listofMenuobjects[2]).Perform();
            act.MoveToElement(listofMenuobjects[3]).Click().Build().Perform();
            //GenericHelper.GetWebdriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.StalenessOf(listofMenuobjects[3]));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Timeout.PageLoadTimeInSecond);

            return driver.Url;
        }
    }
}