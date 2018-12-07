using System;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using static System.String;

namespace Utilities
{
    public  class LogoutHelper:LoginHelper
    {
        public static bool LogOff(IWebElement myBlueGreenMenu, IWebElement signOutBtn, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (myBlueGreenMenu == null) throw new ArgumentNullException(nameof(myBlueGreenMenu));
            if (signOutBtn == null) throw new ArgumentNullException(nameof(signOutBtn));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var url = MenusTabs.MenuLevel1(new List<IWebElement> {myBlueGreenMenu, signOutBtn}, driver, timeout);


            return Compare(url, ConfigurationManager.AppSettings["UrlForLogOff"],
                       StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool LogOff(By myBlueGreenMenu, By signOutBtn, IWebDriver driver,
            int timeout = (int) Timeout.ShortwaitInSecond)
        {
            if (myBlueGreenMenu == null) throw new ArgumentNullException(nameof(myBlueGreenMenu));
            if (signOutBtn == null) throw new ArgumentNullException(nameof(signOutBtn));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            var url = MenusTabs.MenuLevel1(new List<By> {myBlueGreenMenu, signOutBtn}, driver, timeout);


            return Compare(url, ConfigurationManager.AppSettings["UrlForLogOff"],
                       StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}