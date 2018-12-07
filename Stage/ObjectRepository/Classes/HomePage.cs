using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace BlueGreenOwner
{
    public class HomePage


    {
        public HomePage()
        {

        }

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//A[@class='btn btn-link js-skipchangepassword'][text()='Click here to continue without changing password']")]
        public IWebElement skipChangePassword;
        public By locatorForskipChangePassword = By.XPath("//A[@class='btn btn-link js-skipchangepassword'][text()='Click here to continue without changing password']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='ui-datepicker-div']//a[@title='Next']")]
        public IWebElement calenderNextArrow;
        public By locatorForcalenderNextArrow = By.XPath(".//div[@id='ui-datepicker-div']//a[@title='Next']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='ui-datepicker-div']//a[@title='Prev']")]
        public IWebElement calenderPrevArrow;
        public By locatorForcalenderPrevArrow = By.XPath(".//div[@id='ui-datepicker-div']//a[@title='Prev']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='ui-datepicker-group ui-datepicker-group-first']//span[@class='ui-datepicker-year']")]
        public IWebElement calenderYearLab;
        public By locatorForcalenderYearLab = By.XPath(".//div[@class='ui-datepicker-group ui-datepicker-group-first']//span[@class='ui-datepicker-year']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='ui-datepicker-group ui-datepicker-group-first']//span[@class='ui-datepicker-month']")]
        public IWebElement calenderMonthLab;
        public By locatorForcalenderMonthLab = By.XPath(".//div[@class='ui-datepicker-group ui-datepicker-group-first']//span[@class='ui-datepicker-month']");


        [FindsBy(How = How.XPath, Using = ".//INPUT[@id='CheckInDate']")]
        public IWebElement InputCheckInDate;
        public By locatorForInputCheckInDate = By.XPath(".//INPUT[@id='CheckOutDate']");

        [FindsBy(How = How.XPath, Using = ".//INPUT[@id='CheckOutDate']")]
        public IWebElement InputCheckOutDate;
        public By locatorForInputCheckOutDate = By.XPath(".//INPUT[@id='CheckOutDate']");

        [FindsBy(How = How.XPath, Using = "//a[.='my reservations']")]
        public IWebElement myReservation;
        public By locatorFormyReservation = By.XPath("//a[.='my reservations']");


        public By locatorForcalenderDay = By.XPath(".//div[@class='ui-datepicker-group ui-datepicker-group-first']//table[@class='ui-datepicker-calendar']//tr//td//a[contains(@class,'ui-state-default')and text()='"+TestBaseClass.day+"']");


        [FindsBy(How = How.XPath, Using = "//LABEL[@for='ReservationType_1'][text()='Points Reservation']")]
        public IWebElement LabelPointsRadioButton;
        public By locatorForLabelPointsButton = By.XPath("//LABEL[@for='ReservationType_1'][text()='Points Reservation']");

        [FindsBy(How = How.XPath, Using = ".//input[@class='js-search-rt js-reset-rt']")]
        public IWebElement PointsRadioButton;
        public By locatorForPointsButton = By.XPath(".//input[@class='js-search-rt js-reset-rt']");

        [FindsBy(How = How.XPath, Using = ".//LABEL[@for='rdoAccountList_0'][text()='Vacation Club']")]
        public IWebElement vactionClubAccount;
        public By locatorForvactionClubAccount = By.XPath(".//LABEL[@for='rdoAccountList_0'][text()='Vacation Club']");


        [FindsBy(How = How.XPath, Using = "//BUTTON[@class='btn btn-primary btn-block'][text()='Continue']")]
        public IWebElement ContinueButton;
        public By locatorForContinueButton = By.XPath("//BUTTON[@class='btn btn-primary btn-block'][text()='Continue']");

             
        [FindsBy(How = How.XPath, Using = ".//input[@class='js-search-rt js-reset-bt']")]
        public IWebElement BonusTimeRadioButton;
        public By locatorForBonusTimeRadioButton = By.XPath(".//input[@class='js-search-rt js-reset-bt']");


        [FindsBy(How = How.XPath, Using = "//LABEL[@for='ReservationType_2'][text()='Bonus Time Reservation']")]
        public IWebElement LabelBonusTimeRadioButton;
        public By locatorForLabelBonusTimeRadioButton = By.XPath("//LABEL[@for='ReservationType_2'][text()='Bonus Time Reservation']");

        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='text'])[1]")]
        public IWebElement AllDestinationsTextBox;
        public By locatorForAllDestinationsTextBox = By.XPath("(//INPUT[@type='text'])[1]");

        [FindsBy(How = How.XPath, Using = ".//button[@data-id='Destination']")]
        public IWebElement SelectedDestination;
        public By locatorForSelectedDestination = By.XPath(".//button[@data-id='Destination']");

        [FindsBy(How = How.XPath, Using = "//*[@id='site-content']//span[text()='All Destinations']")]
        public IWebElement AllDestinationsEle;
        public By locatorForAllDestinationsEle = By.XPath("//*[@id='site-content']//span[text()='All Destinations']");

        // secondary owner
        //div[@class='dropdown-menu open']
        //select[@id='Destination']//parent::*//parent::div

        [FindsBy(How = How.XPath, Using = "//div[@class='dropdown-menu open']/preceding-sibling::*")]
        public IWebElement SelectDestinationDropDown;
        public By locatorForSelectDestinationDropDown = By.XPath("//div[@class='dropdown-menu open']/preceding-sibling::*");

        [FindsBy(How = How.XPath, Using = "//*[@id='site-content']//span[text()='Select a destination']")]
        public IWebElement SelectDestination;
        public By locatorForSelectDestination = By.XPath("//*[@id='site-content']//span[text()='Select a destination']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//*[@title='Saved searches']")]
        public IWebElement SavedSearchesButton;
        public By locatorForSavedSearchesButtons = By.XPath(".//*[@id='site-content']//*[@title='Saved searches']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[text()='Manage Saved Searches']")]
        public IWebElement ManageSavedSearchesBtn;
        public By locatorForManageSavedSearchesBtn = By.XPath(".//*[@id='site-content']//a[text()='Manage Saved Searches']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//span[@class='input-group-addon']")]
        public IWebElement HyphenBtwnDate;
        public By locatorForHyphenBtwnDate = By.XPath(".//*[@id='site-content']//span[@class='input-group-addon']");




        [FindsBy(How = How.XPath, Using = ".//label[@for='CheckOutDate']")]
        public IWebElement CheckOutDate;
        public By locatorForCheckOutDate = By.XPath(".//label[@for='CheckOutDate']");


    
        [FindsBy(How = How.XPath, Using = ".//label[@for='CheckInDate']")]
        public IWebElement CheckInDate;
        public By locatorForCheckInDate = By.XPath(".//label[@for='CheckInDate']");



        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//span[@id='number-of-nights']")]
        public IWebElement NumNights;
        public By locatorForNumNights = By.XPath(".//*[@id='site-content']//span[@id='number-of-nights']");

        [FindsBy(How = How.XPath, Using = "//*[@name='btnSubmit']")]
        public IWebElement SearchButton;
        public By locatorForSearchButton = By.XPath("//*[@name='btnSubmit']");

        [FindsBy(How = How.XPath, Using = ".//div//input[@type='text'][@class='form-control']")]
        public IWebElement DestinationTextBox;
        public By locatorForDestinationTextBox = By.XPath(".//div//input[@type='text'][@class='form-control']");

        [FindsBy(How = How.XPath, Using = "*.//div[@class='dropdown-menu open']//ul[@class='dropdown-menu inner']//li[@class='active']/a")]
        public IWebElement ActiveLocation;
        public By locatorForActiveLocation = By.XPath("*.//div[@class='dropdown-menu open']//ul[@class='dropdown-menu inner']//li[@class='active']//a//span[@class='text']");

        [FindsBy(How = How.XPath, Using = "*.//div[@class='dropdown-menu open']//ul[@class='dropdown-menu inner']//li[@class='active']//a//span[@class='text']")]
        public IWebElement ActivePrimaryLocation;
        public By locatorForActivePrimaryLocation = By.XPath("*//ul[@class='dropdown-menu inner']//li[@class='selected active']/a");


        [FindsBy(How = How.XPath, Using = ".//div[@class='form-group is-required']//button[@title='month']")]
        public IWebElement MonthDropDown;
        public By locatorForMonthDropDown = By.XPath(".//div[@class='form-group is-required']//button[@title='month']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchselect open']//div[@class='dropdown-menu open']//ul//li[4]")]
        public IWebElement MonthEntry;
        public By locatorForMonthEntry = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchselect open']//div[@class='dropdown-menu open']//ul//li[4]");


        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchselect']//button[@data-id='monthsearch']")]
        public IWebElement SelectedMonth;
        public By locatorForSelectedMonth = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchselect']//button[@data-id='monthsearch']");


        [FindsBy(How = How.XPath, Using = ".//div[@class='form-group is-required']//button[@title='nights']")]
        public IWebElement nightsDropDown;
        public By locatorFornightsDropDown = By.XPath(".//div[@class='form-group is-required']//button[@title='nights']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchduration open']//div[@class='dropdown-menu open']//ul//li[3]")]
        public IWebElement nightsEntry;
        public By locatorFornightsEntry = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchduration open']//div[@class='dropdown-menu open']//ul//li[3]");

        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchduration']//button[@data-id='monthsearchduration']")]
        public IWebElement SelectedNightsEntry;
        public By locatorForSelectedNightsEntry = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchduration']//button[@data-id='monthsearchduration']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='location']//h1[@class='h1 text-none']//strong")]
        public IWebElement resortName;
        public By locatorforresortName = By.XPath(".//div[@id='location']//h1[@class='h1 text-none']//strong");

        [FindsBy(How = How.XPath, Using = "*//li[@id='js-my-bluegreen']")]
        public IWebElement logOffDiv;
        public By locatorForlogOffDiv = By.XPath("*//li[@id='js-my-bluegreen']");

        [FindsBy(How = How.XPath, Using = "*//a[contains(text(),'sign')]")]
        public IWebElement SignoutBtn;
        public By locatorForSignoutBtn = By.XPath("*//a[contains(text(),'sign')]");

        public By locatorLogOffDivByXpath = By.XPath(@"*//li[@id='js-my-bluegreen']");

        public By locatorSignoutBtnByXpath = By.XPath("*//a[contains(text(),'sign')]");

        [FindsBy(How = How.XPath, Using = "//a[.='choice privileges']")]
        public IWebElement choicePrivilegesLink;
        public By locatorForlogChoicePrivilegesLink = By.XPath("//a[.='choice privileges']");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'select')]/..")]
        public IWebElement selectAnAccountPg;
        public By locatorForSelectAnAccountPg = By.XPath("//strong[contains(text(),'select')]/..");

        //
        [FindsBy(How = How.XPath, Using = ".//*[@id='js-my-bluegreen']//span[@class='badge badge-default']")]////available points shown near blue green menu
        public IWebElement CurrentPoints;
        public By locatorForCurrentPoints = By.XPath(".//*[@id='js-my-bluegreen']//span[@class='badge badge-default']");

        //great escapes
        [FindsBy(How = How.XPath, Using = "//a[.='traveler plus']")]
        public IWebElement travelerPlusLink;
        public By locatorfortravelerPlusLink = By.XPath("//a[.='traveler plus']");

        [FindsBy(How = How.XPath, Using = "//a[.='resort stays']")]
        public IWebElement resortStaysLink;
        public By locatorforResortStaysLink = By.XPath("//a[.='resort stays']");

        [FindsBy(How = How.XPath, Using = "//a[.='Great Escapes']")]
        public IWebElement greatEscapesLink;
        public By locatorforGreatEscapesLink = By.XPath("//a[.='Great Escapes']");

        //resort details page
        [FindsBy(How = How.XPath, Using = "//a[.='association']")]
        public IWebElement associationLink;
        public By locatorforAssociationLink = By.XPath("//a[.='association']");

        [FindsBy(How = How.XPath, Using = "//strong[.='association']/..")]
        public IWebElement associationOwners;
        public By locatorforAssociationOwners = By.XPath("//strong[.='association']/..");

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Welcome to Oasis Lakes Condominium Association at The Fountains. We’ve integrated your association’s web page with www.bluegreenonline.com, where you can find everything you need to know about your vacation ownership, including amenities, photos, floor plans, virtual tours, maps, area information, and more! Feel free to contact Owner Services toll-free from the U.S. and Canada at 866.406.7266, toll-free from the U.K. at 00.800.4707.4707, or')]")]
        public IWebElement associationOwnersContent;
        public By locatorforAssociationOwnersContent = By.XPath("//p[contains(text(),'Welcome to Oasis Lakes Condominium Association at The Fountains. We’ve integrated your association’s web page with www.bluegreenonline.com, where you can find everything you need to know about your vacation ownership, including amenities, photos, floor plans, virtual tours, maps, area information, and more! Feel free to contact Owner Services toll-free from the U.S. and Canada at 866.406.7266, toll-free from the U.K. at 00.800.4707.4707, or')]");

        //Help/FAQsLink
        [FindsBy(How = How.XPath, Using = "//a[text()='Help/FAQs']")]
        public IWebElement HelpOrFAQsLink;
        public By locatorforHelpOrFAQsLink = By.XPath("//a[text()='Help/FAQs']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Contact Us']")]
        public IWebElement ContactUsLink;
        public By locatorforContactUsLink = By.XPath("//a[text()='Contact Us']");

        // in stage page title is different 
        //[FindsBy(How = How.XPath, Using = "//strong[contains(text(),'looking for')]")]
        //public IWebElement askBluegreen;
        //public By locatorforAskBluegreen = By.XPath("//strong[contains(text(),'looking for')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Ask Bluegreen')]")]
        public IWebElement askBluegreen;
        public By locatorforAskBluegreen = By.XPath("//h1[contains(text(),'Ask Bluegreen')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'question?')]")]
        public IWebElement HaveAQuestion;
        public By locatorforHaveAQuestion = By.XPath("//h1[contains(text(),'question?')]");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'contact')]")]
        public IWebElement ContactUs;
        public By locatorforContactUs = By.XPath("//strong[contains(text(),'contact')]");


        public string CurrentPointsVal = "null";//value of available points shown near blue green menu
        public string pagename = "Home Page";


        public string ValCheckindate = null;
        public string ValCheckoutdate = null;
        public string ValDestination = null;
        public string ValNumNights = null;
     
    }
}

