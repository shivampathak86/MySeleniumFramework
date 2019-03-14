
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using System;

using System.IO;

namespace Utilities
{
    public  class Driver:ExcelUtility
    {
        public static IWebDriver WebDriver;
        private static FirefoxOptions GetFirefoxptions()
        {
            var option = new FirefoxOptions {AcceptInsecureCertificates = true};



            //profile = manager.GetProfile("default");
            return option;
        }
        private static ChromeOptions GetheadlessChromeOptions()
        {
            var option = new ChromeOptions();
            
            option.AddArgument("--headless");
            //option.AddArgument("start-maximized");
            option.AddArguments("--window-size=1920x1080","--disable-gpu");
             options.AddUserProfilePreference("Downloads",Directory.GetCurrentDirectory());

            option.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            option.AcceptInsecureCertificates = true;
            


            return option;
        }

        private static ChromeOptions GetChromeOptions()
        {
            var option = new ChromeOptions();

            option.AddArgument("--start-maximized");
           

            option.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            option.AcceptInsecureCertificates = true;



            return option;
        }

        private static InternetExplorerOptions GetIeOptions()
        {
            var options = new InternetExplorerOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept,

                //AcceptInsecureCertificates = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,

                RequireWindowFocus = true,

                EnsureCleanSession = true
            };


            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            var services = FirefoxDriverService.CreateDefaultService(Directory.GetCurrentDirectory());
            var ffDriver = new FirefoxDriver(services, GetFirefoxptions(), TimeSpan.FromSeconds((int)Timeout.PageLoadTimeInSecond));
            return ffDriver;
        }

        private static ChromeDriver GetChromeDriver()
        {


            var chromeDriver = new ChromeDriver(GetChromeOptions());
          
            return chromeDriver;
        }

        private static ChromeDriver GetHeadlessChromeDriver()
        {


            var headlesschromeDriver = new ChromeDriver(GetheadlessChromeOptions());

            return headlesschromeDriver;
        }

        private static InternetExplorerDriver GetIeDriver()
        {
            var ieDriver = new InternetExplorerDriver(GetIeOptions());
            return ieDriver;
        }

        public static bool Initialize(BrowserType type)
        {
            // change the return type boolean and use that in caller method to use Nlogger.
            //Overload method for taking string as paramter


            switch (type)
            {
                case BrowserType.Firefox:
                    WebDriver = GetFirefoxDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((int) Timeout.ShortwaitInSecond);
                    WebDriver.Manage().Cookies.DeleteAllCookies();
                    
                    BrowserHelper.BrowserMaximize(WebDriver);
                    return true;
                case BrowserType.Chrome:
                    WebDriver = GetChromeDriver();
                   
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((int) Timeout.ShortwaitInSecond);
                    WebDriver.Manage().Cookies.DeleteAllCookies();

                    //BrowserHelper.BrowserMaximize(driver);
                    return true;
                case BrowserType.Ie:
                    WebDriver = GetIeDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((int) Timeout.ShortwaitInSecond);
                    BrowserHelper.BrowserMaximize(WebDriver);
                    return true;
                case BrowserType.HeadlessChrome:

                    WebDriver = GetHeadlessChromeDriver();

                    return true;
                    
                default:
                    return false;
                   
            }

           
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.for
        }

        public  static bool TearDown(IWebDriver driver)
        {
            if (driver == null) return false;

            driver.Dispose();
            driver.Quit();
            return true;

        }
    }
}
