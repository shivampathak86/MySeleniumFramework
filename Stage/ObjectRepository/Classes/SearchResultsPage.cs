using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BlueGreenOwner
{
    public class SearchResultsPage
    {
		public SearchResultsPage()
		{

		}

        public SearchResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
		

        [FindsBy(How = How.Id, Using = "CheckInDate")]
        public IWebElement CheckInDate;
        public By locatorForCheckInDate = By.Id("CheckInDate");

        [FindsBy(How = How.XPath, Using = ".//div[@id='ui-datepicker-div']//a[@title='Next']")]
        public IWebElement calenderNextArrow;
        public By locatorForcalenderNextArrow = By.XPath(".//div[@id='ui-datepicker-div']//a[@title='Next']");

        [FindsBy(How = How.Id, Using = "CheckOutDate")]
        public IWebElement CheckOutDate;
        public By locatorForCheckOutDate = By.Id("CheckOutDate");

        [FindsBy(How = How.Id, Using = "number-of-nights")]
        public IWebElement NumberOfNights;
        public By locatorForNumberOfNights = By.Id("number-of-nights");

        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchselect js-monthsearchselect-result']//*[@data-id='monthsearch']")]
        public IWebElement MonthEntry;
        public By locatorForMonthEntry = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchselect js-monthsearchselect-result']//*[@data-id='monthsearch']");


        [FindsBy(How = How.XPath, Using = ".//div[@class='btn-group bootstrap-select js-monthsearchduration']//*[@data-id='monthsearchduration']")]
        public IWebElement nightsEntry;
        public By locatorFornightsEntry = By.XPath(".//div[@class='btn-group bootstrap-select js-monthsearchduration']//*[@data-id='monthsearchduration']");

        [FindsBy(How = How.XPath, Using = ".//button[@class='btn dropdown-toggle btn-default'][@data-id='Destination']//span")]
        public IWebElement SelectedDestination;
        public By locatorForSelectedDestination = By.XPath(".//button[@class='btn dropdown-toggle btn-default'][@data-id='Destination']//span");

        [FindsBy(How = How.XPath, Using = ".//div[@id='collapse-sidebar']//label[@for='accessibleOption']")]
        public IWebElement labelWheelChairAccess;
        public By locatorForLabelWheelChairAccess = By.XPath(".//div[@id='collapse-sidebar']//label[@for='accessibleOption']");


        [FindsBy(How = How.XPath, Using = ".//div[@id='collapse-sidebar']//input[@id='accessibleOption']")]
        public IWebElement CheckBoxWheelChairAccess;
        public By locatorForCheckBoxWheelChairAccess = By.XPath(".//div[@id='collapse-sidebar']//input[@id='accessibleOption']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='searchParameters_ReservationType' and @value='1']")]
        public IWebElement PointsRadioButton;
        public By locatorForPointsButton = By.XPath(".//*[@id='searchParameters_ReservationType' and @value='1']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchParameters_ReservationType' and @value='2']")]
        public IWebElement BonussRadioButton;
        public By locatorForBonussRadioButton = By.XPath(".//*[@id='searchParameters_ReservationType' and @value='2']");

      
    
        [FindsBy(How=How.XPath, Using = ".//div[@class='save-search filter-group js-savesearch']/div[@class='form-fields']/div[@class='form-group form-group-small text-center']/a")]
        public IWebElement LinkSaveSearch;
        public By locatorForLinkSaveSearch = By.XPath(".//div[@class='save-search filter-group js-savesearch']/div[@class='form-fields']/div[@class='form-group form-group-small text-center']/a");


        [FindsBy(How = How.XPath, Using = ".//div[@id='collapse-sidebar']//input[@id='search-name']")]
        public IWebElement TextBoxSearchName;
        public By locatorForTextBoxSearchName = By.XPath(".//div[@id='collapse-sidebar']//input[@id='search-name']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='collapse-sidebar']//a[@id='save-search']")]
        public IWebElement BtnSaveSearch;
        public By locatorForBtnSaveSearch = By.XPath(".//div[@id='collapse-sidebar']//a[@id='save-search']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='collapse-sidebar']//div[@id='save-search-info']//p")]
        public IWebElement MsgSearchSaved;
        public By locatorForMsgSearchSaved = By.XPath(".//div[@id='collapse-sidebar']//div[@id='save-search-info']//p");


    
       
        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']")]
        public IWebElement ResultsTab;
        public By locatorForResultsTab = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']");

        [FindsBy(How = How.XPath, Using = ".//div[@class='media-body']//h2//span[1]")]
        public IWebElement resultresortName;
        public By locatorForresultresortName = By.XPath(".//div[@class='media-body']//h2//span[1]");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[2]")]
        public IWebElement MaxOccup;
        public By locatorForMaxOccup = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[2]");


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[3]")]
        public IWebElement DailyRate;
        public By locatorForDailyRate = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[3]");


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]")]
        public IWebElement TotalPrice;
        public By locatorForTotalPrice = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]");


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[1]//div[@class='sub-details']")]
        public IWebElement villaType;
        public By locatorForvillaType = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[1]//div[@class='sub-details']");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[5]")]
        public IWebElement availability;
        public By locatorForAvailablity = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[5]");

        [FindsBy(How = How.XPath, Using = "(.//*[@id='site-content']//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//tr[1]/td[6]/a)[1]")]
        public IWebElement bookButton;
        public By locatorForbookButton = By.XPath("(.//*[@id='site-content']//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//tr[1]/td[6]/a)[1]");

        [FindsBy(How = How.XPath, Using = ".//A[@href='/owner/confirm-reservation'][text()='Continue']")]
        public IWebElement futurePointsContinue;
        public By locatorfuturePointsContinue = By.XPath(".//A[@href='/owner/confirm-reservation'][text()='Continue']");


        //Points Reservation  specific feilds


        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[2]")]
        public IWebElement Season;
        public By locatorForSeason = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[2]");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[3]")]
        public IWebElement PointsReservationMaxOccup;
        public By locatorForPointsReservationMaxOccup = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[3]");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]")]
        public IWebElement PointsReservationPoints;
        public By locatorForPointsReservationPoints = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]");

        [FindsBy(How = How.XPath, Using = "//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]/a")]
        public IWebElement PointsReservationPointsLink;
        public By locatorForPointsReservationPointsLink = By.XPath("//table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']//td[4]/a");


        public string pageName = "Search Results Page";

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='Other available check in dates are shown below.']")]
        public IWebElement MsgOtherAvailableDestinations;
        public By locatorForMsgOtherAvailableDestinations = By.XPath(".//*[@id='site-content']//p[text()='Other available check in dates are shown below.']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][1]//p/a")]
        public IWebElement btnFirstAlternateDate;
        public By locatorForbtnFirstAlternateDate = By.XPath(".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][1]//p/a");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][2]//a[@class='btn btn-primary-outline btn-block js-suggested']")]
        public IWebElement btnSecondAlternateDate;
        public By locatorForbtnbtnSecondAlternateDate = By.XPath(".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][2]//a[@class='btn btn-primary-outline btn-block js-suggested']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][3]//a[@class='btn btn-primary-outline btn-block js-suggested']//a")]
        public IWebElement btnThirdAlternateDate;
        public By locatorForThirdAlternateDate = By.XPath(".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][3]//a[@class='btn btn-primary-outline btn-block js-suggested']//a");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][4]//a[@class='btn btn-primary-outline btn-block js-suggested']//a")]
        public IWebElement btnFourthAlternateDate;
        public By locatorForbtnFourthAlternateDate = By.XPath(".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-2'][4]//a[@class='btn btn-primary-outline btn-block js-suggested']//a");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-3'][1]//a[@class='btn btn-primary-outline btn-block js-suggested']")]
        public IWebElement btnSeeMoreDates;
        public By locatorForbtnSeeMoreDates = By.XPath(".//*[@id='site-content']//div[@class='row row-thin row-centered'][1]//child::div[@class='col-xs-6 col-md-3'][1]//a[@class='btn btn-primary-outline btn-block js-suggested']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='search-results js-searchresultdisplay']//p[contains(text(),'one night')]")]
        public IWebElement MsgInightStay;
        public By locatorForMsgInightStay = By.XPath(".//*[@id='site-content']//div[@class='search-results js-searchresultdisplay']//p[contains(text(),'one night')]");



        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//div[@class='alert alert-success']")]
        public IWebElement MsgListOfDestinationMatchingOriginalCheckInAndDuration;
        public By locatorForMsgListOfDestinationMatchingOriginalCheckInAndDuration = By.XPath(".//*[@id='site-content']//div[@class='alert alert-success']");

        public string messageDestinationMatchingOriginalCheckInAndDuration = "We have provided a list of available destinations that match your original check in date and duration.";


        [FindsBy(How = How.XPath, Using = "(.//*[@id='tabs-content']//div[@class='alert alert-info js-updateSearchQuery']/p)[2]")]
        public IWebElement Msg7NightsStayAlternateDateCase;
        public By locatorForMsg7NightsStayAlternateDateCase = By.XPath("(.//*[@id='tabs-content']//div[@class='alert alert-info js-updateSearchQuery']/p)[2]");

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-info js-updateSearchQuery']/p[2]")]
        public IWebElement Msg7NightsStay;
        public By locatorForMsg7NightsStay = By.XPath("//div[@class='alert alert-info js-updateSearchQuery']/p[2]");

       

        public string XpathForAllAvailableResortsInSearchResults = "(.//*[@id='site-content']//div[@class='resort-preview-toggle js-destination-group']//a[@class='collapsed resort-preview-toggle-btn'])";


        //Locators and other defenition for multi resorts search results:Dymanic feild identification

        public string XpathForResortNames = "";
        public string XpathForResortNameLastpart = "//*[@class='h2 resort-name']/a[@itemprop='name']";
        public string XpathForResortNameFirstpart = ".//*[@id='collapse-";
        public string XpathForResortNameMiddlepart = "-available-resorts']";
        public string XpathForShowResortAvailabiltyLastPart = "//child::a[@class='btn btn-primary js-showAvailability'])[last()]";//takes the last show resort avaialblity button under the selected detsination
                                                                                                                                  // public string XpathForShowResortAvailabiltyFirstPart = "//child::a[@class='btn btn-primary js-showAvailability'])[1]";//takes the first show resort avaialblity button under the selected detsination

        public string XpathForSearchResultsTableLastPart = "//child::table[@class='table-collapse table-striped table-hover table-search-results js-resortdata']";

        //public string XpathForMultiResultBookButtonLastPart = "//child::tr[1]/td[6]/a)[1]";//select book button in t he first row results table
        //public string XpathForMultiResultPointsLinkLastPart = "//child::tr[1]/td[4]/a)[1]";//select book button in t he first row results table

        public string XpathForMultiResultBookButtonLastPart = "//child::tr[@data-handicap='" + TestBaseClass.HandiCapFlag+"']/td[6]/a)[1]";//select book button in t he first row results table
        public string XpathForMultiResultPointsLinkLastPart = "//child::tr[@data-handicap='" + TestBaseClass.HandiCapFlag +"']/td[4]/a)[1]";//select book button in t he first row results table


        public string XpathForMultiResultStandardPointsTableLastPart = "//child::div[contains(@id,'collapse-standard-points')])[1]";
        public string XpathForMultiResultPointsLink = "";
        public string XpathForMultiResultStandardPointsTable = "";
        public string XpathForSearchResultsTable = "";
        public string XpathForShowResortAvailalbilityButton = "";
        public By locatorForShowResortAvailalbilityButton = null;
        public By locatorForSearchResultsTable = null;
        public By locatorForMultiResultPointsLink = null;
        public By locatorForMultiResultStandardPointsTable = null;
        public string XpathForMultiResultBookButton = "";
        public By locatorForMultiResultBookButton = null;

        public IWebElement btnShowResortAvailability;
        public IWebElement lastResortNameElement;
        public IWebElement multiResultBookButton;
        public IWebElement multiResultPointsLink;
        public IWebElement multiResultStandardPointsTable;



        //SearchResultsPage Table fieldValues
        public string selectedAlternateCheckInDate = null;
        public string SRPVillaType = null;
        public string SRPSeason = null;
        public string SRPMaxOccupancy = null;
        public string SRPPoints = null;
        public string SRPAvialability = null;
        public string SRPResortName = null;
        public string ValCheckindate = null;
        public string ValCheckoutdate = null;
        public string ValNumNights = null;
        public string SRPDailyPrice = null;
        public string SRPTotalPrice = null;
        public string XpathForDailyRate = null;
        public By locatorForXpathForDailyRate = null;
        public string XpathForTotalPrice = null;
        public By locatorForXpathForTotalPrice = null;
        public string XpathForTotalPriceLastPart = "//child::tr[1]/td[4])[1]";//edit this
        public string XpathForDailyRateLastPart = "//child::tr[1]/td[3])[1]";//edit this
        public string ValDestination = null;
        public string Valtype = null;

        public By LocatorForDatesNotAvailable = By.XPath("//p[contains(text(),'Please select new dates, as there is no availability in the resorts for the number of nights selected.')]");

        
    }
}
