using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BlueGreenOwner
{
    public class SaveMyPointsPage
    {
        public SaveMyPointsPage()
        {

        }

        public SaveMyPointsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        //stage
        //[FindsBy(How = How.XPath, Using = "//p[text()='You have Points that need to be saved.']")]
        //public IWebElement savePointsAlert;
        //public By locatorforSavePointsAlert = By.XPath("//p[text()='You have Points that need to be saved.']");


        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'You have Annual Points')]")]
        public IWebElement savePointsAlert;
        public By locatorforSavePointsAlert = By.XPath("//p[contains(text(),'You have Annual Points')]");

        [FindsBy(How = How.XPath, Using = "//a[text()='save my points']")]
        public IWebElement SaveMyPointsAlertButton;
        public By locatorforSavePointsAlertButton = By.XPath("//a[text()='save my points']");

        [FindsBy(How = How.Id, Using = "CreditCard_Name")]
        public IWebElement NameOnCard;
        public By locatorForNameOnCard = By.Id("CreditCard_Name");

        [FindsBy(How = How.Id, Using = "CreditCard_Number")]
        public IWebElement CreditCardNumber;
        public By locatorForCreditCardNumber = By.Id("CreditCard_Number");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='CreditCard_ExpDateMonth']")]
        public IWebElement ExpirationMonth;
        public By locatorForExpirationMonth = By.XPath("//SELECT[@id='CreditCard_ExpDateMonth']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='CreditCard_ExpDateYear']")]
        public IWebElement ExpirationYear;
        public By locatorForExpirationYear = By.XPath("//SELECT[@id='CreditCard_ExpDateYear']");

        [FindsBy(How = How.Id, Using = "CreditCard_VerificationNumber")]
        public IWebElement CVV;
        public By locatorForCVV = By.Id("CreditCard_VerificationNumber");

        [FindsBy(How = How.Id, Using = "CreditCard_ZipCode")]
        public IWebElement ZipCode;
        public By locatorForZipCode = By.Id("CreditCard_ZipCode");

        [FindsBy(How = How.Id, Using = "CreditCard_InternationalZipCode")]
        public IWebElement InternationalZipCode;
        public By locatorForInternationalZipCode = By.Id("CreditCard_InternationalZipCode");

        [FindsBy(How = How.Id, Using = "confirm_toc_savePoints")]
        public IWebElement ChkBoxTermsAndConditions;
        public By locatorForChkBoxTermsAndConditions = By.Id("confirm_toc_savePoints");

        [FindsBy(How = How.XPath, Using = "//*[@id='save-points-form']//a[@class='btn btn-primary js-savemypoints']")]
        public IWebElement SaveMyPointsButton;
        public By locatorForSaveMyPointsButton = By.XPath("//*[@id='save-points-form']//a[@class='btn btn-primary js-savemypoints']");

        [FindsBy(How = How.XPath, Using = "//*[@id='save-points-form']//a[@class='js-click-me js-nothanks']")]
        public IWebElement NoThankYou;
        public By locatorForNoThankYou = By.XPath("//*[@id='save-points-form']//a[@class='js-click-me js-nothanks']");


        [FindsBy(How = How.XPath, Using = "//*[@id='save-points-form']//p[@class='callout']")]
        public IWebElement TotalPayment;
        public By locatorForTotalPayment = By.XPath("//*[@id='save-points-form']//p[@class='callout']");





        [FindsBy(How = How.XPath, Using = "//*[@id='detailsDiv']//p[text()='The eligible Points in your account(s) will be saved for an additional year of use in Red, White and Blue seasons. Thank you for electing to save your Points. ']")]
        public IWebElement SavePointsConfirmationMsg;
        public By locatorforSavePointsConfirmationMsg = By.XPath("//*[@id='detailsDiv']//p[text()='The eligible Points in your account(s) will be saved for an additional year of use in Red, White and Blue seasons. Thank you for electing to save your Points. ']");

        [FindsBy(How = How.XPath, Using = "//*[@id='detailsDiv']//*[text()='Your Payment Was Successful!']")]
        public IWebElement SavePointsSuccessMsg;

        [FindsBy(How = How.XPath, Using = "//*[@id='detailsDiv']//div[@class='js-AuthorizationNumber']")]
        public IWebElement SavePointsConfirmationNumber;

        public By locatorforSavePointsConfirmationNumber = By.XPath("//*[@id='detailsDiv']//div[@class='js-AuthorizationNumber']");




        public string pageName = "Save My Points Billing Info";

        public string currentUrlForSavePoints = "Save My Points Billing Info";

    }
}

