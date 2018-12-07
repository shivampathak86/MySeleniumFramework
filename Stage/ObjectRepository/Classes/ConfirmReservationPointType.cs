using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BlueGreenOwner
{
   public class ConfirmReservationPointType
    {

             

        public ConfirmReservationPointType()
        {

        }

        public ConfirmReservationPointType(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//span[@itemprop='name']")]
            public IWebElement Lab_ResortName;
            public By locatorforLab_ResortName = By.XPath("  .//*[@id='site-content']//span[@itemprop='name']");



            [FindsBy(How = How.Id, Using = "confirm_toc")]
            public IWebElement Chk_Agreement;
            public By locatorforChk_Agreement = By.Id("confirm_toc");
            public string IdForconfirm_toc = "confirm_toc";

            [FindsBy(How = How.Id, Using = "submit-reservation")]
            public IWebElement Btn_SubmitResrvation;
            public string IdForBtn_SubmitResrvation = "submit-reservation";
            public By locatorForBtn_SubmitReservation = By.Id("submit-reservation");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[1]")]
            public IWebElement TableCoumn_VillaType;
            public By locatorForTableCoumn_VillaType = By.XPath("//table[@class='table-collapse table-striped']//td[1]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[2]")]
            public IWebElement TableCoumn_CheckIn;
            public By locatorForTableCoumn_CheckIn = By.XPath("//table[@class='table-collapse table-striped']//td[2]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[3]")]
            public IWebElement TableColumn_CheckOut;
            public By locatorForTableColumn_CheckOut = By.XPath("//table[@class='table-collapse table-striped']//td[3]");


            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[4]")]
            public IWebElement TableColumn_MaxOccup;
            public By locatorForTableColumn_MaxOccup = By.XPath("//table[@class='table-collapse table-striped']//td[4]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[5]")]
            public IWebElement TableColumn_Amount;
            public By locatorForTableColumn_Amount = By.XPath("//table[@class='table-collapse table-striped']//td[5]");

            //PointReservation-Confirm reservation Page


            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@class='btn btn-secondary js-add-guest']")]
            public IWebElement Btn_AddNewGuest;
            public By locatorforBtn_AddNewGuest = By.XPath(".//*[@id='site-content']//button[@class='btn btn-secondary js-add-guest']");


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



            [FindsBy(How = How.XPath, Using = ".//*[@id='text_SpecialRequests']")]
            public IWebElement Feild_specialRequests;
            public String xpathForFeild_specialRequests = ".//*[@id='text_SpecialRequests']";
            public By locatorforFieldSpecialRequests = By.XPath(".//*[@id='text_SpecialRequests']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_NumberOfGuest']")]
            public IWebElement Field_NumberOfGuests;
            public By locatorforFeild_NumberOfGuests = By.XPath(".//*[@id='Guest_NumberOfGuest']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='buttonadd']/i")]
            public IWebElement Btn_PlusNumberOfGuests;
            public By locatorforBtn_PlusNumberOfGuests = By.XPath(".//*[@id='buttonadd']/i");

            [FindsBy(How = How.XPath, Using = ".//*[@id='buttonremove']/i")]
            public IWebElement Btn_MinusNumberOfGuests;
            public By locatorforBtn_MinusNumberOfGuests = By.XPath(".//*[@id='buttonremove']/i");




            //AddGuest feilds
            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_FirstName']")]
            public IWebElement TextBox_GuestFirstName;
            public By locatorForTextBox_GuestFirstName = By.XPath(".//*[@id='Guest_FirstName']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_LastName']")]
            public IWebElement TextBox_GuestLastName;
            public By locatorForTextBox_GuestLastName = By.XPath(".//*[@id='Guest_LastName']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_Email']")]
            public IWebElement TextBox_GuestEmail;
            public By locatorForTextBox_GuestEmail = By.XPath(".//*[@id='Guest_Email']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_PhoneNumber']")]
            public IWebElement TextBox_GuestTelephoneNumber;
            public By locatorForTextBox_GuestTelephoneNumber = By.XPath(" .//*[@id='Guest_PhoneNumber']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_City']")]
            public IWebElement TextBox_GuestCity;
            public By locatorForTextBox_GuestCity = By.XPath(".//*[@id='Guest_City']");

            [FindsBy(How = How.XPath, Using = "(.//*[@id='site-content']//div[@class='col-border col-border-inverse js-totalrequiredpoint']//child::p[@class='text-center font-size-large'])[1]")]
            public IWebElement Lab_TotalPointsRequired;
            public By locatorForLab_TotalPointsRequired = By.XPath("(.//*[@id='site-content']//div[@class='col-border col-border-inverse js-totalrequiredpoint']//child::p[@class='text-center font-size-large'])[1]");

            [FindsBy(How = How.XPath, Using = "(.//*[@id='site-content']//div[@class='col-border col-border-inverse js-totalrequiredpoint']//child::p[@class='text-center font-size-large'])[2]")]
            public IWebElement Lab_TotalEligiblePoints;
            public By locatorForLab_TotalEligiblePoints = By.XPath("(.//*[@id='site-content']//div[@class='col-border col-border-inverse js-totalrequiredpoint']//child::p[@class='text-center font-size-large'])[2]");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='alert alert-danger']//child::p[@class='js-verif-globallerror']")]
            public IWebElement Msg_NotEnoughPoints;
            public By locatorForMsg_NotEnoughPoints = By.XPath(".//*[@id='site-content']//div[@class='alert alert-danger']//child::p[@class='js-verif-globallerror']");

            public string resortName = "null";
            public string points = "null";


            public string pageName = "Confirm Reservation";
            public string checkoutdate = "null";
            public string checkindate = "null";
            public string guestCheckingName = "null";
            public string specialrequests = "null";
            public string numberOfGuests = "null";

        }
    }
