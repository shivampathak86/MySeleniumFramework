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
   public class RegistrationConfirmationPage
    {

        [FindsBy(How = How.Id, Using = "profile-ownerNumber")]
        public IWebElement ownerNumberTxtField;
        public By locatorForownerNumberTxtField = By.Id("profile-ownerNumber");

        [FindsBy(How = How.Id, Using = "profile-FirstName")]
        public IWebElement firstNameTxtField;
        public By locatorForfirstNameTxtField = By.Id("profile-FirstName");

        [FindsBy(How = How.Id, Using = "profile-LastName")]
        public IWebElement lastNameTxtField;
        public By locatorForlastNameTxtField = By.Id("profile-LastName");

        [FindsBy(How = How.Id, Using = "profile-AddressLine1")]
        public IWebElement addressLine1TxtField;
        public By locatorForaddressLine1TxtField = By.Id("profile-AddressLine1");

        [FindsBy(How = How.Id, Using = "profile-AddressLine2")]
        public IWebElement addressLine2TxtField;
        public By locatorForaddressLine2TxtField = By.Id("profile-AddressLine2");

        [FindsBy(How = How.Id, Using = "profile-AddressLine3")]
        public IWebElement addressLine3TxtField;
        public By locatorForaddressLine3TxtField = By.Id("profile-AddressLine3");

        [FindsBy(How = How.Id, Using = "profile-City")]
        public IWebElement cityTxtField;
        public By locatorForcityTxtField = By.Id("profile-City");

        [FindsBy(How = How.Id, Using = "profile-ZipCode")]
        public IWebElement postalOrZipcodeTxtField;
        public By locatorForpostalOrZipcodeTxtField = By.Id("profile-ZipCode");

        [FindsBy(How = How.Id, Using = "profile-HomePhone")]
        public IWebElement primaryPhoneTxtField;
        public By locatorForprimaryPhoneTxtField = By.Id("profile-HomePhone");

        [FindsBy(How = How.Id, Using = "profile-AltPhone")]
        public IWebElement alternatePhoneTxtField;
        public By locatorForalternatePhoneTxtField = By.Id("profile-AltPhone");

        [FindsBy(How = How.Id, Using = "profile-EmailAddress")]
        public IWebElement emailAddressTxtField;
        public By locatorForemailAddressTxtField = By.Id("profile-EmailAddress");

        [FindsBy(How = How.XPath, Using = "//input[@value='True']")]
        public IWebElement yesRadioBtn;
        public By locatorForyesRadioBtn = By.XPath("//input[@value='True']");

        [FindsBy(How = How.XPath, Using = "//input[@value='False']")]
        public IWebElement noRadioBtn;
        public By locatorFornoRadioBtn = By.XPath("//input[@value='False']");

        [FindsBy(How = How.XPath, Using = "//button[text()='update my profile']")]
        public IWebElement updateMyProfileBtn;
        public By locatorForupdateMyProfileBtn = By.XPath("//button[text()='update my profile']");

        [FindsBy(How = How.XPath, Using = "//span[.='United States'][@class='filter-option pull-left']")]
        public IWebElement countryDropDownList;
        public By locatorForcountryDropDownList = By.XPath("//span[.='United States'][@class='filter-option pull-left']");

        [FindsBy(How = How.XPath, Using = "//button[@data-id='profile-State']")]
        public IWebElement stateDropDownList;
        public By locatorForastateDropDownList = By.XPath("//button[@data-id='profile-State']");



        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Address Line 1')]")]
        public IWebElement addressLine1ErrorMsg;
        public By locatorForaddressLine1ErrorMsg = By.XPath("//li[contains(text(),'Address Line 1')]");

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'City')]")]
        public IWebElement cityErrorMsg;
        public By locatorForcityErrorMsg = By.XPath("//li[contains(text(),'City')]");

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),' Zip/Postal code')]")]
        public IWebElement zipCodeErrorMsg;
        public By locatorForzipCodeErrorMsg = By.XPath("//li[contains(text(),' Zip/Postal code')]");

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'email address')]")]
        public IWebElement emailAddressErrorMsg;
        public By locatoremailAddressErrorMsg = By.XPath("//li[contains(text(),'email address')]");

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'primary phone number')]")]
        public IWebElement primaryPhoneErrorMsg;
        public By locatoremailprimaryPhoneErrorMsg = By.XPath("//li[contains(text(),'primary phone number')]");


        public RegistrationConfirmationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        
        public RegistrationConfirmationPage()
        {

        }
    }
}
