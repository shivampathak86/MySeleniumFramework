using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
   public class RequestPayOffPage
    {
        public RequestPayOffPage()
        {

        }

        public RequestPayOffPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='ProcessPayoff']")]
        //public IWebElement requestpayOffbutton;
        //public By locatorforrequestpayOffbutton = By.XPath(".//*[@id='ProcessPayoff']");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'request')]/..")]
        public IWebElement requestpayOffPage;
        public By locatorforrequestpayOffPage = By.XPath("//strong[contains(text(),'request')]/..");

        [FindsBy(How = How.XPath, Using = ".//*[@id='GotoSummary']']")]
        public IWebElement mortgageSummaryButton;
        public By locatorformortgageSummaryButton = By.XPath(".//*[@id='GotoSummary']");

        //payoff fields

        [FindsBy(How = How.XPath, Using = "//input[@id='Radio_C45B61CFF7AB4A0188ABABA277C8DC89']/..")]
        public IWebElement faxRadioButton;
        public By locatorforfaxRadioButton = By.XPath("//input[@id='Radio_C45B61CFF7AB4A0188ABABA277C8DC89']/..");

        [FindsBy(How = How.XPath, Using = "//input[@id='Radio_F64AEBCD4D3B469D9423BFF12F389170']/..")]
        public IWebElement emailRadioButton;
        public By locatorforemailRadioButton = By.XPath("//input[@id='Radio_F64AEBCD4D3B469D9423BFF12F389170']/..");

        [FindsBy(How = How.XPath, Using = "//input[@id='Radio_C6848C235A284361918A1C8126F99494']/..")]
        public IWebElement USmailRadioButton;
        public By locatorforUSmailRadioButton = By.XPath("//input[@id='Radio_C6848C235A284361918A1C8126F99494']/..");


        [FindsBy(How = How.XPath, Using = "//button[text()='Request pay off quote']")]
        public IList <IWebElement> RequestPayOffBtn { get; set; }
        public By locatorforRequestPayOffBtn = By.XPath("//button[text()='Request pay off quote']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtPayoffFax']")]
        public IWebElement faxTextBox;
        public By locatorforfaxTextBox = By.XPath(".//*[@id='txtPayoffFax']");

        [FindsBy(How = How.XPath, Using = ".//*[@name='txtEmail']")]
        public IWebElement emailTextbox;
        public By locatorforemailTextbox = By.XPath(".//*[@name='txtEmail']");
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'pay off quote sent by US Mail')]")]
        public IWebElement AlertMsg;
        public By locatorforAlertMsg = By.XPath("//p[contains(text(),'pay off quote sent by US Mail')]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='PayoffProcess']/tbody/tr[4]/td")]
        public IWebElement replaceTextForUsMail;
        public By locatorforreplaceTextForUsMail = By.XPath(".//*[@id='PayoffProcess']/tbody/tr[4]/td");

        public string pageName = "Request PayOff Page";
    }
}
