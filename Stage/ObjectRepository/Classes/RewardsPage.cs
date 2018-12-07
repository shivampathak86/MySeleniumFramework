using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace BlueGreenOwner
{
    public class RewardsPage
    {
        public RewardsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public RewardsPage()
        {

        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-first-name']")]
        public IWebElement firstName;
        public By locatorforfirstName = By.XPath(".//*[@id='referral-first-name']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-last-name']")]
        public IWebElement lastName;
        public By locatorforlastName = By.XPath(".//*[@id='referral-last-name']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-email-address']")]
        public IWebElement emailAddress;
        public By locatorforemailAddress = By.XPath(".//*[@id='referral-email-address']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-telephone']")]
        public IWebElement telephone;
        public By locatorfortelephone = By.XPath(".//*[@id='referral-telephone']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-city']")]
        public IWebElement city;
        public By locatorforCity = By.XPath(".//*[@id='referral-city']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='referral-message']")]
        public IWebElement messageInput;
        public By locatorformessageInput = By.XPath(".//*[@id='referral-message']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='js-referFriend']")]
        public IWebElement registerButton;
        public By locatorforregisterButton = By.XPath(".//*[@id='js-referFriend']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='confirm_toc']")]
        public IWebElement checkBox;
        public By locatorforcheckBox = By.XPath(".//*[@id='confirm_toc']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-state']")]
        public IWebElement state;
        public By locatorforstate = By.XPath(".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-state']");

        //[FindsBy(How = How.XPath, Using = ".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-state' and title='Florida']")]
        //public IWebElement floridaState;
        //public By locatorfofloridaState = By.XPath(".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-state' and title='Florida']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-destination']")]
        public IWebElement destination;
        public By locatorfordestination = By.XPath(".//*[@id='refer-a-referral-form']//button[@class='btn dropdown-toggle btn-default' and @data-id='referral-destination']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-refer-a-referral-button-step-1']//a[text()='Register a Referral Today']")]
        public IWebElement RegisteraReferralToday;
        public By locatorforRegisteraReferralToday = By.XPath(".//*[@id='collapse-refer-a-referral-button-step-1']//a[text()='Register a Referral Today']");

        [FindsBy(How = How.XPath, Using = " .//*[@id='refer-a-referral-form']//div[@class='bs-searchbox']/input")]
        public IWebElement stateTextBox;
        public By locatorforstateTextbox = By.XPath(" .//*[@id='refer-a-referral-form']//div[@class='bs-searchbox']/input");




        //public string pageUrl = string.Empty;

        //*****************************PROD URL*****************************************************************
        //public string pageUrl ="https://sc.bluegreenowner.com/rewards/bluegreen-rewards";
        //*****************************PROD URL*****************************************************************

        //*****************************STAGE URL*****************************************************************
        //public string pageUrl = "https://stg.sitecore.bluegreenowner.com/rewards/bluegreen-rewards";

        //*****************************STAGE URL*****************************************************************


        public string pageName = "Register A Referal";


        [FindsBy(How = How.XPath, Using = ".//*[@id='refer-a-referral-form']//div[@class='alert alert-success js-ConfirmationMessage']")]
        public IWebElement ConfirmatonMessage;
        public By locatorforConfirmatonMessage = By.XPath(".//*[@id='refer-a-referral-form']//div[@class='alert alert-success js-ConfirmationMessage']");


        //public RewardsPage()
        //{
        //    if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("STAGE"))
        //    {

        //        pageUrl = @"https://stg.sitecore.bluegreenowner.com/rewards/bluegreen-rewards";
        //    }
        //    else if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("PRODUCTION"))
        //    {
        //        pageUrl = @"https://sc.bluegreenowner.com/rewards/bluegreen-rewards";

        //    }
        //}


    }
}
