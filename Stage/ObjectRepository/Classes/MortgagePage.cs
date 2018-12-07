using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
    public class MortgageSecurityPage
    {
        public MortgageSecurityPage()
        {

        }

        public MortgageSecurityPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='LastName']")]
        public IWebElement lastNameTextBox;
        public By locatorforlastNameTextBox = By.XPath(".//*[@id='LastName']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='Submit']")]
        public IWebElement submitButton;
        public By locatorforsubmitButton = By.XPath(".//*[@id='Submit']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='Span1']")]
        public IWebElement errorMessageElement;
        public By locatorforerrorMessageElement = By.XPath(".//*[@id='Span1']");

        public string pageName = "Mortgage Security Page";
    }
}
