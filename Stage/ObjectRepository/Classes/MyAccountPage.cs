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
    public class MyAccountPage
    {
		public MyAccountPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);

		}

		public MyAccountPage()
		{

		}

		// Elements declared by Ramya
		[FindsBy(How = How.XPath, Using = "//*[@class='alert alert-info']//child::a[contains(@href,'TravelerPlus/owner/additionalMember.aspx')]")]

        public IWebElement AddtionalMemberCardlink;
        public By LocatorforCardlink = By.XPath("//*[@class='alert alert-info']//child::a[contains(@href,'TravelerPlus/owner/additionalMember.aspx')]");

        [FindsBy(How = How.XPath, Using = "//*[@class='alert alert-info'][2]")]
        public IWebElement DivForAddtionalMemberCard;

        [FindsBy(How = How.XPath, Using = "//*[@class='alert alert-info']//child::a[contains(@href,'owner/mortgagechangeborrowerinfo.aspx')]")]

        public IWebElement MortgageInfomationPageLink;

        public static By MortgagePageLocator = By.XPath("//*[@class='alert alert-info']//child::a[contains(@href,'owner/mortgagechangeborrowerinfo.aspx')]");
        [FindsBy(How = How.XPath, Using = "//*[@class='alert alert-info '][1]")]
        public IWebElement DivForMortgageInfomationPageLink;


        // Elements declared by Fathima
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'account')]")]
        public IWebElement myAccountHeader;
        public By locatorFormyAccountHeader = By.XPath("//h1[contains(text(),'account')]");

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





        [FindsBy(How = How.XPath, Using = "//li[.='Please enter the Address Line 1.']")]
        public IWebElement addressLine1ErrorMsg;
        public By locatorForaddressLine1ErrorMsg = By.XPath("//li[.='Please enter the Address Line 1.']");

        [FindsBy(How = How.XPath, Using = "//li[.='Please enter the City.']")]
        public IWebElement cityErrorMsg;
        public By locatorForcityErrorMsg = By.XPath("//li[.='Please enter the City.']");

        [FindsBy(How = How.XPath, Using = "//li[.='Please enter the Zip/Postal code.']")]
        public IWebElement zipCodeErrorMsg;
        public By locatorForzipCodeErrorMsg = By.XPath("//li[.='Please enter the Zip/Postal code.']");

        [FindsBy(How = How.XPath, Using = "//li[.='You must enter your email address.']")]
        public IWebElement emailAddressErrorMsg;
        public By locatoremailAddressErrorMsg = By.XPath("//li[.='You must enter your email address.']");

        [FindsBy(How = How.XPath, Using = "//li[contains(.,'primary')]")]
        public IWebElement primaryPhoneErrorMsg;
        public By locatoremailprimaryPhoneErrorMsg = By.XPath("//li[contains(.,'primary')]");


        // xpath of whole text area of elements
        [FindsBy(How = How.XPath, Using = "//*[@id='profile-AddressLine1']//parent::div")]
        public IWebElement addressLine1TxtArea;
        public By locatorForaddressLine1TxtArea = By.XPath("//*[@id='profile-AddressLine1']//parent::div");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-City']//parent::div")]
        public IWebElement cityTxtArea;
        public By locatorForcityTxtArea = By.XPath("//*[@id='profile-City']//parent::div");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-ZipCode']//parent::div")]
        public IWebElement postalOrZipcodeTxtArea;
        public By locatorForpostalOrZipcodeTxtArea = By.XPath("//*[@id='profile-ZipCode']//parent::div");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-HomePhone']//parent::div")]
        public IWebElement primaryPhoneTxtArea;
        public By locatorForprimaryPhoneTxtArea = By.XPath("//*[@id='profile-HomePhone']//parent::div");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-EmailAddress']//parent::div")]
        public IWebElement emailAddressTxtArea;
        public By locatorForemailAddressTxtArea = By.XPath("//*[@id='profile-EmailAddress']//parent::div");

        [FindsBy(How = How.XPath, Using = "//input[@id='isPaperLessSelected']/../../..")]
        public IWebElement recievePaperlessBillingStatements;
        public By locatorForrecievePaperlessBillingStatements = By.XPath("//input[@id='isPaperLessSelected']/../../..");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-country']/../..")]
        public IWebElement countryTxtArea;
        public By locatorcountryTxtArea = By.XPath("//*[@id='profile-country']/../..");

        [FindsBy(How = How.XPath, Using = "//*[@id='profile-State']/../..")]
        public IWebElement stateTxtArea;
        public By locatorForstateTxtArea = By.XPath("//*[@id='profile-State']/../..");

        // validate accountNoGrid

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td")]
        public IList<IWebElement> Table_AccountNumber { get; set; }
        public By locatorforTable_AccountNumber = By.XPath(".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td[@data-label='Account Number']")]
        public IList<IWebElement> Table_NoOfAccountNumber { get; set; }
        public By locatorforTable_NoOfAccountNumber = By.XPath(".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td[@data-label='Account Number']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td[@data-label='Description']")]
        public IList<IWebElement> Table_Description { get; set; }
        public By locatorforTable_Description = By.XPath(".//*[@id='section-Owner-Contracts-Grid-Container-details']/table//td[@data-label='Description']");

        [FindsBy(How = How.XPath, Using = "//table[@id='gvContractInfo']//td")]
        public IList<IWebElement> VSSATable_AccountNumber { get; set; }
        public By locatorforVSSATable_AccountNumber = By.XPath("//table[@id='gvContractInfo']//td");

        [FindsBy(How = How.XPath, Using = "//table[@id='gvContractInfo']//tr")]
        public IList<IWebElement> VSSATable_NoOfAccountNumber { get; set; }
        public By locatorforVSSATable_NoOfAccountNumber = By.XPath("//table[@id='gvContractInfo']//tr");



        

    }

}
