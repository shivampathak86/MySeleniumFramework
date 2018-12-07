using BlueGreenOwner;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueGreenOwner
{
    public class RegisterOwnerPage
    {

        [FindsBy(How = How.XPath, Using = "//input[@name='txtSSN']")]
        public IWebElement ssnTxtField;
        public By locatorForssnTxtField = By.XPath("//input[@name='txtSSN']");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtPhone']")]
        public IWebElement primaryPhoneTxtField;
        public By locatorForprimaryPhoneTxtField = By.XPath("//input[@name='txtPhone']");

        [FindsBy(How = How.XPath, Using = "//input[@id='user-account-number']")]
        public IWebElement ownerNumberTxtField;
        public By locatorForownerNumberTxtField = By.XPath("//input[@id='user-account-number']");

        [FindsBy(How = How.XPath, Using = "//input[@id='user-email-address']")]
        public IWebElement emailAddressTxtField;
        public By locatorForemailAddressTxtField = By.XPath("//input[@id='user-email-address']");

        [FindsBy(How = How.XPath, Using = "//input[@id='user-email-address2']")]
        public IWebElement confirmMailTxtField;
        public By locatorForconfirmMailTxtField = By.XPath("//input[@id='user-email-address2']");

        [FindsBy(How = How.XPath, Using = "//input[@id='user-password']")]
        public IWebElement passwordTxtField;
        public By locatorForpasswordTxtField = By.XPath("//input[@id='user-password']");

        [FindsBy(How = How.XPath, Using = "//input[@id='user-password2']")]
        public IWebElement confirmPasswordTxtField;
        public By locatorForconfirmPasswordTxtField = By.XPath("//input[@id='user-password2']");

        [FindsBy(How = How.XPath, Using = "//button[text()='Register']")]
        public IWebElement registerButton;
        public By locatorForregisterButton = By.XPath("//button[text()='Register']");

        [FindsBy(How = How.XPath, Using = "//strong[.='registration']")]
        public IWebElement registrationConfirmationPage;
        public By locatorForregistrationConfirmationPage = By.XPath("//strong[.='registration']");

        public RegisterOwnerPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

    }
}

