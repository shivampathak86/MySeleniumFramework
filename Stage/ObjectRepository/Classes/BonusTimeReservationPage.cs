using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BlueGreenOwner
{
    public class BonusTimeReservationPage
    {
        public BonusTimeReservationPage()
		{

		}
		
		public BonusTimeReservationPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}
		//Bonus Type Reservation Objects
        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//span[@itemprop='name']")]
        public IWebElement Lab_ResortName;
        public By locatorforLab_ResortName = By.XPath("  .//*[@id='site-content']//span[@itemprop='name']");



        [FindsBy(How = How.XPath, Using = "//input[@id='CreditCard_Number']")]
        public IWebElement cardnum;
        public By locatorforcardnum = By.XPath("//input[@id='CreditCard_Number']");

        [FindsBy(How = How.XPath, Using = "//input[@id='CreditCard_Name']")]
        public IWebElement name;
        public By locatorforname = By.XPath("//input[@id='CreditCard_Name']");

        [FindsBy(How = How.XPath, Using = "//input[@id='CreditCard_VerificationNumber']")]
        public IWebElement cvv;
        public By locatorforcvv = By.XPath("//input[@id='CreditCard_VerificationNumber']");

        [FindsBy(How = How.XPath, Using = "//input[@id='CreditCard_ZipCode']")]
        public IWebElement zipcode;
        public By locatorforzipcode = By.XPath("//input[@id='CreditCard_ZipCode']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='confirm_toc']")]
        public IWebElement checkBox;
        public By locatorforcheckBox = By.XPath(".//*[@id='confirm_toc']");

        [FindsBy(How = How.XPath, Using = "//A[@href='#'][text()='Confirm Reservation and Submit Payment']")]
        public IWebElement Submit;
        public By locatorforSubmit = By.XPath("//A[@href='#'][text()='Confirm Reservation and Submit Payment']");


        [FindsBy(How = How.XPath, Using = "//input[@class='form-control input-spinner ui-spinner-input']")]
        public IWebElement guestsNum;

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[2]")]
        public IWebElement CheckIn;

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[3]")]
        public IWebElement CheckOut;


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[4]")]
        public IWebElement MaxOccup;

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[5]")]
        public IWebElement Amt;

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[1]//div[@class='sub-details']")]
        public IWebElement VillaType;

        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select']//button[@title='January']//span[contains(text(),'January')]")]
        public IWebElement expMonth1;

        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select dropup open']//div[@class='dropdown-menu open']//ul[@class='dropdown-menu inner']//span[contains(text(),'December')]")]
        public IWebElement expMonth2;



        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select']//button[@title='2017']")]
        public IWebElement expYear;








        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select input-group-btn']//button[@class='btn dropdown-toggle btn-default'][@data-id='Guest_Selected']")]
        public IWebElement Select_GuestCheckingInDefaultBtn;
        public string XpathforSelect_GuestCheckingInDefaultBtn = "//div[@class='btn-group bootstrap-select input-group-btn']//button[@class='btn dropdown-toggle btn-default'][@data-id='Guest_Selected']";
        public By locatorforSelect_GuestCheckingInDefaultBtn = By.XPath("//div[@class='btn-group bootstrap-select input-group-btn']//button[@class='btn dropdown-toggle btn-default'][@data-id='Guest_Selected']");



        [FindsBy(How = How.XPath, Using = "//SPAN[@class='filter-option pull-left'][text()='Please select a guest.']")]
        public IWebElement Select_GuestCheckingInDefaultValue;
        public string XpathforSelect_GuestCheckingInDefaultValue = "//SPAN[@class='filter-option pull-left'][text()='Please select a guest.']";
        public By locatorforSelect_GuestCheckingInDefaultValue = By.XPath("//SPAN[@class='filter-option pull-left'][text()='Please select a guest.']");


        [FindsBy(How = How.XPath, Using = "//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]")]
        public IWebElement Option_Owner1;
        public string XpathforOwner1Xpath = "//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]";
        public By locatorforOption_Owner1 = By.XPath("//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]");



        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_FirstName']")]
        public IWebElement AddFirstName;
        public By locatorforAddFirstName = By.XPath(".//*[@id='Address_FirstName']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_LastName']")]
        public IWebElement AddLastName;
        public By locatorforAddLastName = By.XPath(".//*[@id='Address_LastName']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='profile-AddressLine1']")]
        public IWebElement AddressLIne1;
        public By locatorforAddressLIne1 = By.XPath(".//*[@id='profile-AddressLine1']");


        [FindsBy(How = How.Id, Using = "profile-City")]
        public IWebElement AddCity;
        public By locatorforAddCity = By.Id("profile-City");


        [FindsBy(How = How.Id, Using = "profile-ZipCode")]
        public IWebElement AddZip;
        public By locatorforAddZip = By.Id("profile-ZipCode");

        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_EmailAddress']")]
        public IWebElement AddEmail;
        public By locatorforAddEmail = By.XPath(".//*[@id='Address_EmailAddress']");



        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_PhoneNumber']")]
        public IWebElement AddPhoneNumber;
        public By locatorforAddPhoneNumber = By.XPath(".//*[@id='Address_PhoneNumber']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_NumberOfGuest']")]
        public IWebElement Field_NumberOfGuests;
        public By locatorforFeild_NumberOfGuests = By.XPath(".//*[@id='Guest_NumberOfGuest']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='buttonadd']/i")]
        public IWebElement Btn_PlusNumberOfGuests;
        public By locatorforBtn_PlusNumberOfGuests = By.XPath(".//*[@id='buttonadd']/i");

        [FindsBy(How = How.XPath, Using = ".//*[@id='text_SpecialRequests']")]
        public IWebElement Feild_specialRequests;
        public String xpathForFeild_specialRequests = ".//*[@id='text_SpecialRequests']";
        public By locatorforFieldSpecialRequests = By.XPath(".//*[@id='text_SpecialRequests']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='confirm_toc']")]
        public IWebElement Chk_Agreement;
        public By locatorforChk_Agreement = By.XPath(".//*[@id='confirm_toc']");



        [FindsBy(How = How.XPath, Using = "(.//*[@id='site-content']//div[@class='col-border col-border-default']//div[@class='row']//div[@class='col-xs-12 col-md-4']/p)[1]")]
        public IWebElement Lab_DailyRate;
        public By locatorforLab_DailyRate = By.XPath("(.//*[@id='site-content']//div[@class='col-border col-border-default']//div[@class='row']//div[@class='col-xs-12 col-md-4']/p)[1]");


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[5]")]
        public IWebElement TableColumn_Amount;
        public By locatorForTableColumn_Amount = By.XPath("//table[@class='table-collapse table-striped']//td[5]");

        [FindsBy(How = How.XPath, Using = "//div[@class='validation-summary-valid']//following-sibling::div[@class='col-border col-border-default']//child::div[@class='row']")]
        public IWebElement TableForBonusAmount;

        public By LocatorforTableForBonusAmount = By.XPath("//div[@class='validation-summary-valid']//following-sibling::div[@class='col-border col-border-default']//child::div[@class='row']");



        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[2]")]
        public IWebElement TableCoumn_CheckIn;
        public By locatorForTableCoumn_CheckIn = By.XPath("//table[@class='table-collapse table-striped']//td[2]");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[3]")]
        public IWebElement TableColumn_CheckOut;
        public By locatorForTableColumn_CheckOut = By.XPath("//table[@class='table-collapse table-striped']//td[3]");

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

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='col-border col-border-default']//child::p[contains(text(),'tax')]/preceding-sibling::p")]
        public IWebElement localTax;
        public By locatorforlocalTax = By.XPath(".//*[@id='site-content']//div[@class='col-border col-border-default']//child::p[contains(text(),'tax')]/preceding-sibling::p");


        [FindsBy(How = How.XPath, Using = "(.//*[@id='site-content']//div[@class='col-border col-border-default']//child::p[contains(text(),'total payment')]/preceding-sibling::p)[2]")]
        public IWebElement totalPaymentAtBottom;
        public By locatorfortotalPaymentAtBottom = By.XPath("(.//*[@id='site-content']//div[@class='col-border col-border-default']//child::p[contains(text(),'total payment')]/preceding-sibling::p)[2]");

        [FindsBy(How = How.XPath, Using = "//div[@class='validation-summary-valid']//following-sibling::div[@class='col-border col-border-default']//p[@class='callout text-dark']")]
        public IWebElement totalPaymentAtTop;
        public By locatorfortotalPaymentAtTop = By.XPath("//div[@class='validation-summary-valid']//following-sibling::div[@class='col-border col-border-default']//p[@class='callout text-dark']");


        [FindsBy(How = How.XPath, Using = " .//*[@id='site-content']//div[@class='alert alert-danger']//p[contains(text(),'night')]")]
        public IWebElement MsgInightStay;
        public By locatorForMsgInightStay = By.XPath(" .//*[@id='site-content']//div[@class='alert alert-danger']//p[contains(text(),'night')]");





        public string checkindate = "";
        public string checkoutdate = "";
        public string guestCheckingName = "";
        public string specialrequests = "";
        public string dailyrate = "";
        public string numberOfGuests = "";
        public string pageName = "Bonus time Reservation Page";
        public string resortName = "";
        public string totalamount = "";
        public string SRPTotalPrice = "";
        public string dailyTax = "";
      

    }
}
