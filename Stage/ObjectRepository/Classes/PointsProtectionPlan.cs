using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace BlueGreenOwner
{
   public  class PointsProtectionPlanPage
    {
        public PointsProtectionPlanPage()
        {

        }

        public PointsProtectionPlanPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='CreditCard_Name']")]
        public IWebElement textBox_CreditCardName;
        public By locatorfortextBox_CreditCardName = By.XPath(".//*[@id='CreditCard_Name']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='CreditCard_Number']")]
        public IWebElement TextBox_CreditCardNumber;
        public By locatorforTextBox_CreditCardNumber = By.XPath(".//*[@id='CreditCard_Number']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='CreditCard_VerificationNumber']")]
        public IWebElement TextBox_CVV;
        public By locatorforTextBox_CVV = By.XPath(".//*[@id='CreditCard_VerificationNumber']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateMonth']")]
        public IWebElement Select_ExpirationMonth;
        public By locatorforSelect_ExpirationMonth = By.XPath(".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateMonth']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateMonth']/following-sibling::div[@class='dropdown-menu open']//span[text()='February']")]
        public IWebElement Select_MonthDecember;
        public By locatorforSelect_MonthDecember = By.XPath(".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateMonth']/following-sibling::div[@class='dropdown-menu open']//span[text()='February']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateYear']")]
        public IWebElement Select_ExpiratonYear;
        public By locatorforExpirationYear = By.XPath(".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateYear']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateYear']/following-sibling::div[@class='dropdown-menu open']//span[text()='2020']")]
        public IWebElement Select_ExpiratonYearCurrent;
        public By locatorforSelect_ExpiratonYearCurrent = By.XPath(".//*[@id='site-content']//button[@data-id='CreditCard_ExpDateYear']/following-sibling::div[@class='dropdown-menu open']//span[text()='2020']");


        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select']//button[@title='January']//span[contains(text(),'January')]")]
        public IWebElement expMonth1;

        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select dropup open']//div[@class='dropdown-menu open']//ul[@class='dropdown-menu inner']//span[contains(text(),'December')]")]
        public IWebElement expMonth2;


        [FindsBy(How = How.XPath, Using = ".//*[@id='CreditCard_ZipCode']")]
        public IWebElement TextBox_ZipCode;
        public By locatorforTextBox_ZipCode = By.XPath(".//*[@id='CreditCard_ZipCode']");

        [FindsBy(How = How.Id, Using = "CreditCard_InternationalZipCode")]
        public IWebElement ChkBox_InternationalZipCode;
        public By locatorforChkBox_InternationalZipCode = By.Id("CreditCard_InternationalZipCode");


        [FindsBy(How = How.XPath, Using = ".//*[@id='confirm_toc']")]
        public IWebElement ChkBox_PPPAgreement;
        public By locatorforChkBox_PPPAgreement = By.XPath(".//*[@id='confirm_toc']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-ppp-purchase-step-1']//a[@class='btn btn-primary check-toc js-showloading']")]
        public IWebElement Btn_ProtectMyPoints;
        public By locatorforBtn_ProtectMyPoints = By.XPath(".//*[@id='collapse-ppp-purchase-step-1']//a[@class='btn btn-primary check-toc js-showloading']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-ppp-purchase-step-1']//A[text()='No Thank You, continue with checkout']")]
        public IWebElement Link_PPPNoThankYou;
        public By locatorforLink_PPPNoThankYou = By.XPath(".//*[@id='collapse-ppp-purchase-step-1']//A[text()='No Thank You, continue with checkout']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='alert alert-warning']//BUTTON[text()='I am Not Interested']")]
        public IWebElement Btn_IamNotInterested;
        public By locatorForBtn_IamNotInterested = By.XPath(".//div[@class='alert alert-warning']//BUTTON[text()='I am Not Interested']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='Total Payment']/preceding-sibling::p[@class='callout dark']")]
        public IWebElement Val_PPPFee;
        public By locatorForVal_Val_PPPFee = By.XPath(".//*[@id='site-content']//p[text()='Total Payment']/preceding-sibling::p[@class='callout dark']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-ppp-purchase-step-2']//div[@class='alert alert-warning']/p")]
        public IWebElement Msg_CancellationFee;
        public By locatorForMsg_CancellationFee = By.XPath(".//*[@id='collapse-ppp-purchase-step-2']//div[@class='alert alert-warning']/p");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='Points Protected']/preceding-sibling::p[@class='callout']")]
        public IWebElement Val_PointsInPPPPage;
        public By locatorForVal_PointsInPPPPage = By.XPath(".//*[@id='site-content']//p[text()='Points Protected']/preceding-sibling::p[@class='callout']");

        public string pageName = "Points Protection Plan Page";


    }
}
