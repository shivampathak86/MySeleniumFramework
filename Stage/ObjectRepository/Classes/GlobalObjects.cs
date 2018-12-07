using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Classes
{
    public class GlobalObjects
    {
        public GlobalObjects()
        { }
        public GlobalObjects(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//p[@class='js - verif - globallerror']")]
        public IWebElement GlobalError;
        public By LocatorForGlobalError = By.XPath(".//p[@class='js-verif-globallerror']");

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Due to the current status of one or more of your accounts, we cannot allow online reservations at this time. Please call 800.456.CLUB(2582) for further assistance')]")]
        public IWebElement AlertforAccount;
        public By LocatorForAlertforAccount = By.XPath("//p[contains(text(),'Due to the current status of one or more of your accounts, we cannot allow online reservations at this time. Please call 800.456.CLUB(2582) for further assistance')]");

        [FindsBy(How = How.XPath, Using = ".//a[@role='button'][contains(text(),'save')]")]
        public IWebElement SavePointsbtn;
        public By LocatorforSavePointsbtn = By.XPath(".//a[@role='button'][contains(text(),'save')]");

        [FindsBy(How = How.XPath, Using = "//div[@id='loading-overlay']//i[@class='fa fa-refresh fa-spin']")]
        public IWebElement LoadingIcon;
        public By locatorforLoadingIcon = By.XPath("//div[@id='loading-overlay']//i[@class='fa fa-refresh fa-spin']");


        [FindsBy(How = How.XPath, Using = "//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']")]
        public IWebElement HiddenLoading;
        public By locatorforHiddenLoading = By.XPath("//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']");


        [FindsBy(How = How.XPath, Using = "//i[@class='fa fa-refresh fa-spin fa-lg fa-fw']")]
        public IWebElement ReferAfriendloading;
        public By locatorforReferAfriendloading = By.XPath("//i[@class='fa fa-refresh fa-spin fa-lg fa-fw']");

    }
}
