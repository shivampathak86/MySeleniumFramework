using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
   public  class ReservationConfirmationPage
    {

        public ReservationConfirmationPage()
        {

        }
        public ReservationConfirmationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[1]//div[@class='sub-details']")]
            public IWebElement VillaType;
            public By locatorForVillaType = By.XPath("//table[@class='table-collapse table-striped']//td[1]//div[@class='sub-details']");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[2]")]
            public IWebElement CheckInDate;
            public By locatorForCheckInDate = By.XPath("//table[@class='table-collapse table-striped']//td[2]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[3]")]
            public IWebElement CheckOutDate;
            public By locatorForCheckOutDate = By.XPath("//table[@class='table-collapse table-striped']//td[3]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[4]")]
            public IWebElement MaxOccup;
            public By locatorForMaxOccup = By.XPath("//table[@class='table-collapse table-striped']//td[4]");

            [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped']//td[5]")]
            public IWebElement Amt;
            public By locatorForAmt = By.XPath("//table[@class='table-collapse table-striped']//td[5]");



            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//child::table[@class='table-collapse table-striped']//child::i[@class='fa fa-wheelchair fa-2x fa-border']")]
            public IWebElement WheelChairAccess;
            public By locatorForWheelChairAccess = By.XPath(".//*[@id='site-content']//child::table[@class='table-collapse table-striped']//child::i[@class='fa fa-wheelchair fa-2x fa-border']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][1]//div[@class='callout']")]
            public IWebElement ConfirmationNumber;
            public By locatorForConfirmationNumber = By.XPath(".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][1]//div[@class='callout']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[@title='protect points now']")]
            public IWebElement Link_protectPointsNow;
            public By locatorForLink_protectPointsNow = By.XPath(".//*[@id='site-content']//a[@title='protect points now']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][2]//div[@class='callout']")]
            public IWebElement ValPointsUsed;
            public By locatorForValPointsUsed = By.XPath(".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][2]//div[@class='callout']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='col-xs-12 col-sm-12 col-md-4']//child::p/strong")]
            public IWebElement ConfirmationDate;
            public By locatorForConfirmationDate = By.XPath(".//*[@id='site-content']//div[@class='col-xs-12 col-sm-12 col-md-4']//child::p/strong");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//child::span[@itemprop='name']")]
            public IWebElement ResortName;
            public By locatorForResortName = By.XPath(".//*[@id='site-content']//child::span[@itemprop='name']");






            public string CPResortName = "null";
            public string pageName = "Reservation Confirmation Page";
            public string editreservationSectionName = "Edit Reservation Section in Confirmation Page";
            public string sendemailItinerraySectionName = "Send EmailItenarary section in Confirmation Page";
            public string pointsUsed = "null";

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][2]//div[@class='callout']/following-sibling::p/span")]
            public IWebElement Lab_ProtectedOrNot;
            public By locatorforLab_ProtectedOrNot = By.XPath(".//*[@id='site-content']//div[@class='col-xs-12 col-sm-6 col-md-4'][2]//div[@class='callout']/following-sibling::p/span");


            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestname']/p")]
            public IWebElement GuestCheckingIn;
            public By locatorforGuestCheckingIn = By.XPath(".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestname']/p");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestCount']")]
            public IWebElement GuestCount;
            public By locatorforGuestCount = By.XPath(".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestCount']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//strong[text()='Special Request']/../following-sibling::p")]
            public IWebElement SpecialRequest;
            public By locatorforSpecialRequest = By.XPath(".//*[@id='site-content']//strong[text()='Special Request']/../following-sibling::p");


            [FindsBy(How = How.Id, Using = "send-email")]
            public IWebElement sendEmailWithItenary;
            public By locatorforsendEmailWithItenary = By.Id("send-email");



            [FindsBy(How = How.Id, Using = "button")]
            public IWebElement addToCalender;
            public By locatorforaddToCalender = By.Id("button");


            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[text()='my reservations']")]
            public IWebElement myreservationButton;
            public By locatorformyreservationButton = By.XPath(".//*[@id='site-content']//a[text()='my reservations']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='event-calendar']/a[@href='javascript:window.print();']")]
            public IWebElement printreservationLink;
            public By locatorforprintreservationLink = By.XPath(".//*[@id='event-calendar']/a[@href='javascript:window.print();']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[text()='vacation profile']")]
            public IWebElement vacationProfileLink;
            public By locatorforvacationProfileLink = By.XPath(".//*[@id='site-content']//a[text()='vacation profile']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[text()='print this page']")]
            public IWebElement printThisPageLink;
            public By locatorforprintThisPageLink = By.XPath(".//*[@id='site-content']//a[text()='print this page']");

      
            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[text()='email']")]
            public IWebElement emailthisPageLink;
            public By locatorforemailthisPageLink = By.XPath(".//*[@id='site-content']//a[text()='email']");



            [FindsBy(How = How.XPath, Using = ".//*[@id='js-send-itinerary']//input[@name='email-reservation-to']")]
            public IWebElement toTextBox;
            public By locatorfortoTextBox = By.XPath(".//*[@id='js-send-itinerary']//input[@name='email-reservation-to']");



            [FindsBy(How = How.XPath, Using = ".//*[@id='js-submit']")]
            public IWebElement SendVacationReservationBtn;
            public By locatorforSendVacationReservationBth = By.XPath(".//*[@id='js-submit']");



            [FindsBy(How = How.Id, Using = "js-email-sent")]
            public IWebElement emailSentMessage;
            public By locatorforemailSentMessage = By.Id("js-email-sent");

            [FindsBy(How = How.XPath, Using = ".//*[@id='js-send-itinerary']//label[@class='control-label']//strong")]
            public IWebElement LabelTo;
            public By locatorforLabelTo = By.XPath(".//*[@id='js-send-itinerary']//label[@class='control-label']//strong");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[@title='cancel reservation']")]
            public IWebElement CancelReservationLink;
            public By locatorforCancelReservationLink = By.XPath(".//*[@id='site-content']//a[@title='cancel reservation']");
            public IWebElement confirmationNumberLink = null;


            public string checkoutdate = "null";
            public string checkindate = "null";
            public string totalamount = "";

            public int randomGeneratedGuestsNum = 0;

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-reservation-information']//A[text()='Edit Reservation Information']")]
            public IWebElement editReservationInformationLink;
            public By locatorforeditReservationInformationLink = By.XPath(".//*[@id='collapse-reservation-information']//A[text()='Edit Reservation Information']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//button[@class='btn btn-secondary js-add-guest']")]
            public IWebElement Btn_AddNewGuest;
            public By locatorforBtn_AddNewGuest = By.XPath(".//*[@id='site-content']//button[@class='btn btn-secondary js-add-guest']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='btn-group bootstrap-select input-group-btn']//button[@data-id='Guest_Selected']/span[@class='filter-option pull-left']")]
            public IWebElement Select_GuestCheckingInDefaultValue;
            public string XpathforSelect_GuestCheckingInDefaultValue = ".//*[@id='site-content']//div[@class='btn-group bootstrap-select input-group-btn']//button[@data-id='Guest_Selected']/span[@class='filter-option pull-left']";
            public By locatorforSelect_GuestCheckingInDefaultValue = By.XPath(".//*[@id='site-content']//div[@class='btn-group bootstrap-select input-group-btn']//button[@data-id='Guest_Selected']/span[@class='filter-option pull-left']");


            [FindsBy(How = How.XPath, Using = " .//*[@id='site-content']//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]")]
            public IWebElement Option_Owner1;
            public string XpathforOwner1Xpath = " .//*[@id='site-content']//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]";
            public By locatorforOption_Owner1 = By.XPath(".//*[@id='site-content']//span[@class='text' and text()='Owner']/../following-sibling::li[1]/a/span[1]");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//span[@class='text' and text()='Owner']/../following-sibling::li[2]/a/span[1]")]
            public IWebElement Option_Owner2;

            public By locatorforOption_Owner2 = By.XPath(".//*[@id='site-content']//span[@class='text' and text()='Owner']/../following-sibling::li[2]/a/span[1]");


            //
            [FindsBy(How = How.XPath, Using = ".//*[@id='Guest_NumberOfGuest']")]
            public IWebElement Field_NumberOfGuests;
            public By locatorforFeild_NumberOfGuests = By.XPath(".//*[@id='Guest_NumberOfGuest']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='buttonadd']/i")]
            public IWebElement Btn_PlusNumberOfGuests;
            public By locatorforBtn_PlusNumberOfGuests = By.XPath(".//*[@id='buttonadd']/i");

            [FindsBy(How = How.XPath, Using = ".//*[@id='buttonremove']/i")]
            public IWebElement Btn_MinusNumberOfGuests;
            public By locatorforBtn_MinusNumberOfGuests = By.XPath(".//*[@id='buttonremove']/i");

            public string numberOfGuests = "";


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

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//button[@class='btn dropdown-toggle btn-default' and @data-id='Guest_State']")]
            public IWebElement TextBox_GuestStateDefaultValue;
            public By locatorForTextBox_GuestStateDefaultValue = By.XPath(".//*[@id='collapse-add-new-guest']//button[@class='btn dropdown-toggle btn-default' and @data-id='Guest_State']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//div[@class='dropdown-menu open']//span[text()='Hawaii']")]
            public IWebElement TextBox_GuestStateHawaii;
            public By locatorForTextBox_GuestStateHawaii = By.XPath(".//*[@id='collapse-add-new-guest']//div[@class='dropdown-menu open']//span[text()='Hawaii']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//div[@class='dropdown-menu open']//span[text()='Indiana']")]
            public IWebElement TextBox_GuestStateIndiana;
            public By locatorForTextBox_GuestStateIndiana = By.XPath(".//*[@id='collapse-add-new-guest']//div[@class='dropdown-menu open']//span[text()='Indiana']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//button[@class='btn dropdown-toggle btn-default' and @data-id='Guest_Relationship']")]
            public IWebElement TextBox_GuestRelationDefaultValue;
            public By locatorForTextBox_GuestRelationDefaultValue = By.XPath(".//*[@id='collapse-add-new-guest']//button[@class='btn dropdown-toggle btn-default' and @data-id='Guest_Relationship']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//span[text()='Friend']")]
            public IWebElement GuestRelation_Friend;
            public By locatorForTextBox_GuestRelation_Friend = By.XPath(".//*[@id='collapse-add-new-guest']//span[text()='Friend']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//span[text()='Family']")]
            public IWebElement GuestRelation_Family;
            public By locatorForTextBox_GuestRelation_Family = By.XPath(".//*[@id='collapse-add-new-guest']//span[text()='Family']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='confirmationmessage']/p")]
            public IWebElement Msg_Updatereservation;
            public By locatorForMsg_Updatereservation = By.XPath(".//*[@id='confirmationmessage']/p");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-add-new-guest']//button[@data-id='Guest_Relationship']")]
            public IWebElement DDLB_GuestRelationShip;
            public By locatorForDDLB_GuestRelationShip = By.XPath(".//*[@id='collapse-add-new-guest']//button[@data-id='Guest_Relationship']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-edit-reservation-information']//a[text()='Update Reservation Information']")]
            public IWebElement DDLB_UpdateReservationInformation;
            public By locatorForDDLB_UpdateReservationInformation = By.XPath(".//*[@id='collapse-edit-reservation-information']//a[text()='Update Reservation Information']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestname']")]
            public IWebElement GuestCheckingInAfterUpdate;
            public By locatorForGuestCheckingInAfterUpdate = By.XPath(".//*[@id='collapse-reservation-information']//div[@class='js-DisplayGuestname']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='btn-group bootstrap-select input-group-btn']/button[@class='btn dropdown-toggle btn-default']/span")]
            public IWebElement Select_GuestCheckingInValueAfterUpdate;
            public By locatorforSelect_GuestCheckingInValueAfterUpdate = By.XPath(".//*[@id='site-content']//div[@class='btn-group bootstrap-select input-group-btn']/button[@class='btn dropdown-toggle btn-default']/span");


            //locators for objects on other pages
            [FindsBy(How = How.XPath, Using = " .//*[@id='myVacationProfile']")]
            public IWebElement myVacationProfileHeadingOnVPPage;
            public By locatorformyVacationProfileHeadingOnVPPage = By.XPath(" .//*[@id='myVacationProfile']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='location']/h1/strong")]
            public IWebElement resortNameOnresortpage;
            public By locatorForresortNameOnresortpage = By.XPath(".//*[@id='location']/h1/strong");

        }
    }
