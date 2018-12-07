using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
    public class AdditionalMemberCardRequestPage
    {

		public AdditionalMemberCardRequestPage()
		{ 
          }

		public AdditionalMemberCardRequestPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}
        [FindsBy(How = How.XPath, Using = "//INPUT[@id='TxtBxShiptoFirstName']")]
        public IWebElement FirstName;
        public By locatorforFirstName = By.XPath("//INPUT[@id='TxtBxShiptoFirstName']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='TxtBxShiptoLastName']")]
        public IWebElement LastName;
        public By locatorforLastName = By.XPath("//INPUT[@id='TxtBxShiptoLastName']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxShiptoAddress1']")]
        public IWebElement Address1;
        public By locatorforAddress1 = By.XPath("//INPUT[@id='txtbxShiptoAddress1']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxShiptoCity']")]
        public IWebElement City;
        public By locatorforCity = By.XPath("//INPUT[@id='txtbxShiptoCity']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='ddlShiptoState']")]
        public IWebElement State;
        public By locatorforState = By.XPath("//SELECT[@id='ddlShiptoState']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxShiptoZip']")]
        public IWebElement ZipCode;
        public By locatorforZipCode = By.XPath("//INPUT[@id='txtbxShiptoZip']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='ddlCountry']")]
        public IWebElement Country;
        public By locatorforCountry = By.XPath("//SELECT[@id='ddlCountry']");


        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxShiptoPhone']")]
        public IWebElement HomePhone;
        public By locatorforHomePhone = By.XPath("//INPUT[@id='txtbxShiptoPhone']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxShiptoemail']")]
        public IWebElement Email;
        public By locatorforEmail = By.XPath("//INPUT[@id='txtbxShiptoemail']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='ddlCreditCardType']")]
        public IWebElement CardType;
        public By locatorforCardType = By.XPath("//SELECT[@id='ddlCreditCardType']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='txtbxCreditCardNumber']")]
        public IWebElement CardNumber;
        public By locatorforCardNumber = By.XPath("//INPUT[@id='txtbxCreditCardNumber']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='ddlCreditCardMonth']")]
        public IWebElement ExpMonth;
        public By locatorforExpMonth = By.XPath("//SELECT[@id='ddlCreditCardMonth']");

        [FindsBy(How = How.XPath, Using = "//SELECT[@id='ddlCreditCardYear']")]
        public IWebElement ExpYear;
        public By locatorforExpYear = By.XPath("//SELECT[@id='ddlCreditCardYear']");

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='imgbtnSubmit']")]
        public IWebElement Submit;
        public By locatorforSubmit = By.XPath("//INPUT[@id='imgbtnSubmit']");
    }
}
