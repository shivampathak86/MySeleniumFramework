using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BlueGreenOwner
{
    public class MyDashboardPage
    {
        public MyDashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MyDashboardPage()
        {

        }
        [FindsBy(How = How.XPath, Using = "//*[@class='overlay']")]
        public IWebElement Overlay;
        public By LocatorforOverlay = By.XPath("//*[@class='overlay']");

        [FindsBy(How = How.XPath, Using = "//strong[.='premier']")]
        public IWebElement PWLtext;
        public By LocatorforPWLtext = By.XPath("//strong[.='premier']");

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'searches')]")]
        public IWebElement SavedSearchesTableHeader;
        public By LocatorforSavedSearchesTableHeader = By.XPath("//h2[contains(text(),'searches')]");

        [FindsBy(How = How.XPath, Using = "//div[@class='hidden loading']//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']")]
        public IWebElement Refresh;
        public By LocatorforRefresh = By.XPath("//div[@class='hidden loading']//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']");

        //Upcoming 
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//h2[@class='h2 first-word']/strong['upcoming']")]
        public IWebElement HeadingUpComing;
        public By locatorforHeadingUpComing = By.XPath("//*[@id='section-upcoming-reservations']//h2[@class='h2 first-word']/strong['upcoming']");

        //Reservations -Not detected
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//h2[@class='h2 first-word']/text()")]
        public IWebElement HeadingReservation;
        public By locatorforHeadingReservation = By.XPath("//*[@id='section-upcoming-reservations']//h2[@class='h2 first-word']/text()");


        //No Upcoming Reservation section
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//*[@aria-hidden='true']/following-sibling::p[1]")]
        public IWebElement MsgNoUpComingReservation;
        public By locatorforMsgNoUpComingReservation = By.XPath(".//*[@id='section-upcoming-reservations']//*[@aria-hidden='true']/following-sibling::p[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//*[@class='btn btn-default' and text()='explore bluegreen']")]
        public IWebElement ExploreBlueGreenButton;
        public By locatorforExploreBlueGreenButton = By.XPath(".//*[@id='section-upcoming-reservations']//*[@class='btn btn-default' and text()='explore bluegreen']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//div[@class='getting-started no-reservations']//a[text()='make a reservation']")]
        public IWebElement MakeAReservationButton;
        public By locatorforMakeAReservationButton = By.XPath(".//*[@id='section-upcoming-reservations']//div[@class='getting-started no-reservations']//a[text()='make a reservation']");

        //Upcoming Resevations Table

        //ColumnNames

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='accommodation']")]
        public IWebElement URColNameAccomodation;
        public By locatorforURColNameAccomodation = By.XPath(".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='accommodation']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='confirmation number']")]
        public IWebElement URColNameConfirmationNumber;
        public By locatorforURColNameConfirmationNumber = By.XPath(".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='confirmation number']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='check in']")]
        public IWebElement URColNameCheckIn;
        public By locatorforURColNameCheckIn = By.XPath(".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='check in']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='check out']")]
        public IWebElement URColNameCheckOut;
        public By locatorforURColNameCheckOut = By.XPath(".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='check out']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='total']")]
        public IWebElement URColNameTotal;
        public By locatorforURColNameTotal = By.XPath(".//*[@id='section-upcoming-reservations']/table//div[@class='tablesorter-header-inner' and text()='total']");


        //Upcoming Reservation Values

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//td[1]")]
        public IWebElement URColumn1;
        public By locatorforURColumn1 = By.XPath(".//*[@id='section-upcoming-reservations']/table//td[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//td[2]")]
        public IWebElement URColumn2;
        public By locatorforURColumn2 = By.XPath(".//*[@id='section-upcoming-reservations']/table//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//td[3]")]
        public IWebElement URColumn3;
        public By locatorforURColumn3 = By.XPath(".//*[@id='section-upcoming-reservations']/table//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//td[4]")]
        public IWebElement URColumn4;
        public By locatorforURColumn4 = By.XPath(".//*[@id='section-upcoming-reservations']/table//td[4]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']/table//td[5]")]
        public IWebElement URColumn5;
        public By locatorforURColumn5 = By.XPath(".//*[@id='section-upcoming-reservations']/table//td[5]");
        // Current  Reservation Tbale


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']//table//tbody//tr//td[2]")]
        public IWebElement ColConfirmationNum;
        public By locatorforColConfirmationNum = By.XPath(".//*[@id='section-current-reservations-details']//table//tbody//tr//td[2]");
        // Upcoming Reservation Tbale


        //View All My reservations Link

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-upcoming-reservations']//a[@class='text-lowercase'and text()='view all my reservations']")]
        public IWebElement URColNameViewAllMyReservations;
        public By locatorforURColNameViewAllMyReservations = By.XPath(".//*[@id='section-upcoming-reservations']//a[@class='text-lowercase'and text()='view all my reservations']");


        //HeadingFor CurrentPoints
        [FindsBy(How = How.XPath, Using = ".//*[@id='current-points']/strong[text()='Current']")]
        public IWebElement HeadingCurrent1;
        public By locatorforHeadingCurrent1 = By.XPath(".//*[@id='current-points']/strong[text()='Current']");
        //HeadingFor Points-may not work
        [FindsBy(How = How.XPath, Using = ".//*[@id='current-points']/text()")]
        public IWebElement HeadingPoints1;
        public By locatorforHeadingPoints1 = By.XPath(".//*[@id='current-points']/text()");

        //Annual Points

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='annual points']")]
        public IWebElement LabelAnnualPoints;
        public By locatorforLabelAnnualPoints = By.XPath(".//*[@id='site-content']//p[text()='annual points']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='annual points']/preceding-sibling::div[1]")]
        public IWebElement ValueAnnualPoints;
        public By locatorforValueAnnualPoints = By.XPath(".//*[@id='site-content']//p[text()='annual points']/preceding-sibling::div[1]");

        //Saved points
        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='saved points']")]
        public IWebElement LabelSavedPoints;
        public By locatorforLabelSavedPoints = By.XPath(".//*[@id='site-content']//p[text()='saved points']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='saved points']/preceding-sibling::div[1]")]
        public IWebElement ValueSavedPoints;
        public By locatorforValueSavedPoints = By.XPath(".//*[@id='site-content']//p[text()='saved points']/preceding-sibling::div[1]");


        //restricted Points

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='restricted points']")]
        public IWebElement LabelRestrictedPoints;
        public By locatorforLabelRestrictedPoints = By.XPath(".//*[@id='site-content']//p[text()='restricted points']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='restricted points']/preceding-sibling::div[1]")]
        public IWebElement ValueRestrictedPoints;
        public By locatorforValueRestrictedPoints = By.XPath(".//*[@id='site-content']//p[text()='restricted points']/preceding-sibling::div[1]");


        //AvailablePoints
        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='available points']")]
        public IWebElement LabelAvailablePoints;
        public By locatorforLabelAvaialablePoints = By.XPath(".//*[@id='site-content']//p[text()='available points']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='available points']/preceding-sibling::div[1]")]
        public IWebElement ValueAvailablePoints;
        public By locatorforValueAvailablePoints = By.XPath(".//*[@id='site-content']//p[text()='available points']/preceding-sibling::div[1]");

        //Heading Current Points Table

        //Current
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/h2[@class='h2 first-word']//strong['current']")]
        public IWebElement HeadingCurrent2;
        public By locatorforHeadingCurrent2 = By.XPath(".//*[@id='section-current-points-table']/h2[@class='h2 first-word']//strong['current']");


        //HeadingFor PointsTable
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']//h2[@class='h2 first-word']/text()")]
        public IWebElement HeadingPointsTable1;
        public By locatorforHeadingPointsTable1 = By.XPath(".//*[@id='section-current-points-table']//h2[@class='h2 first-word']/text()");


        //Current points Table Column Names
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='points type']")]
        public IWebElement CPTColNamePointsType;
        public By locatorforCPTColNamePointsType = By.XPath(".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='points type']");



        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='available points']")]
        public IWebElement CPTColNameAvailablePoints;
        public By locatorforCPTColNameAvailablePoints = By.XPath(".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='available points']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='expiration date']")]
        public IWebElement CPTExpirationDate;
        public By locatorforCPTExpirationDate = By.XPath(".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='expiration date']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='actions']")]
        public IWebElement CPTActions;
        public By locatorforCPTActions = By.XPath(".//*[@id='section-current-points-table']/table//div[@class='tablesorter-header-inner' and text()='actions']");


        //CPT Table

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table")]
        public IWebElement CPTTable;
        public By locatorforCPTTable = By.XPath(".//*[@id='section-current-points-table']/table");


        //CPT column Values

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//td[1]")]
        public IWebElement CPTColumn1;
        public By locatorforCPTColumn1 = By.XPath(".//*[@id='section-current-points-table']/table//td[1]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//td[2]")]
        public IWebElement CPTColumn2;
        public By locatorforCPTColumn2 = By.XPath(".//*[@id='section-current-points-table']/table//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//td[3]")]
        public IWebElement CPTColumn3;
        public By locatorforCPTColumn3 = By.XPath(".//*[@id='section-current-points-table']/table//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//td[4]")]
        public IWebElement CPTColumn4;
        public By locatorforCPTColumn4 = By.XPath(".//*[@id='section-current-points-table']/table//td[4]");





        //View All My Points Link
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-points-table']/table//a[@class='text-lowercase']")]
        public IWebElement ViewAllMyPointsLink;
        public By locatorforViewAllMyPointsLink = By.XPath(".//*[@id='section-current-points-table']/table//a[@class='text-lowercase']");

        //saved Searches Heading

        //Saved
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-saved-searches']/h2[@class='h2 first-word']//strong['saved']")]
        public IWebElement HeadingSaved;
        public By locatorforHeadingSaved = By.XPath(".//*[@id='section-saved-searches']/h2[@class='h2 first-word']//strong['saved']");


        //Searches
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-saved-searches']/h2[@class='h2 first-word']/text()")]
        public IWebElement HeadingSearches;
        public By locatorforHeadingSearches = By.XPath(".//*[@id='section-saved-searches']/h2[@class='h2 first-word']/text()");

        //No Saved Searches Message
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-saved-searches']/div[@class='getting-started no-reservations']//strong[text()='You currently have no saved searches']")]
        public IWebElement MsgNoSavedSearches;
        public By locatorforValue = By.XPath(".//*[@id='section-saved-searches']/div[@class='getting-started no-reservations']//strong[text()='You currently have no saved searches']");

        //SAved Searches Table-add this

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-saved-searches-details']//table//tbody")]
        public IWebElement SavedSearchesTable;
        public By locatorforSavedSearchesTable = By.XPath(".//*[@id='section-saved-searches-details']//table//tbody");


        //PWL

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']/h2[@class='h2 first-word']/strong['premier']")]
        public IWebElement HeadingPremier;
        public By locatorforHeadingPremier = By.XPath(".//*[@id='section-premier-wait-list']/h2[@class='h2 first-word']/strong['premier']");

        //No PWL message
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//*[@aria-hidden='true']/following-sibling::p[1]")]
        public IWebElement MsgNoPWL;
        public By locatorforMsgNoPWL = By.XPath(".//*[@id='section-premier-wait-list']//*[@aria-hidden='true']/following-sibling::p[1]");

        //PWl Table column Names
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='accommodations']")]
        public IWebElement PWLColNameAccomodation;
        public By locatorforPWLColNameAccomodation = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='accommodations']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='request id']")]
        public IWebElement PWLColNameRequestID;
        public By locatorforPWLColNameRequestID = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='request id']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='check in']")]
        public IWebElement PWLColNameCheckIn;
        public By locatorforPWLColNameCheckIn = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='check in']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='check out']")]
        public IWebElement PWLColNameCheckOut;
        public By locatorforPWLColNameCheckOut = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='check out']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='total']")]
        public IWebElement PWLColNameTotal;
        public By locatorforPWLColNameTotal = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='total']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='status']")]
        public IWebElement PWLColNameStatus;
        public By locatorforPWLColNameStatus = By.XPath(".//*[@id='section-premier-wait-list']//table//div[@class='tablesorter-header-inner' and text()='status']");

        //pWl column values
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[1]")]
        public IWebElement PWLColumn1;
        public By locatorforPWLColumn1 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[1]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody")]
        public IWebElement PWLTable;
        public By locatorforPWLTable = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody");



        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[2]")]
        public IWebElement PWLColumn2;
        public By locatorforPWLColumn2 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[3]")]
        public IWebElement PWLColumn3;
        public By locatorforPWlColumn3 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[4]")]
        public IWebElement PWLColumn4;
        public By locatorforPWLColumn4 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[4]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[5]")]
        public IWebElement PWLColumn5;
        public By locatorforPWLColumn5 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[5]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//table//tbody//td[6]")]
        public IWebElement PWLColumn6;
        public By locatorforPWLColumn6 = By.XPath(".//*[@id='section-premier-wait-list-details']//table//tbody//td[6]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-premier-wait-list-details']//a[text()='make a premier wait list request']")]
        public IWebElement MakeAPWL;
        public By locatorforMakeAPWL = By.XPath(".//*[@id='section-premier-wait-list-details']//a[text()='make a premier wait list request']");

        [FindsBy(How = How.XPath, Using = "//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']")]
        public IWebElement PgOverlay;
        public By locatorforPgOverlay = By.XPath("//i[@class='fa fa-refresh fa-spin fa-5x fa-fw']");

        //Account Summary section

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-sidebar']//a[text()='Available Points']")]
        public IWebElement ASMRYAvailablePointsLink;
        public By locatorforASMRYAvailablePointsLink = By.XPath(".//*[@id='site-sidebar']//a[text()='Available Points']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-sidebar']//a[text()='Available Points']/../following-sibling::dd[1]")]
        public IWebElement ASMRYAvailablePointsValue;
        public By locatorforASMRYAvailablePointsValue = By.XPath(".//*[@id='site-sidebar']//a[text()='Available Points']/../following-sibling::dd[1]");

        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),'Ownership Level')]")]
        public IWebElement OwnershipLevel;
        public By locatorforOwnershipLevel = By.XPath("//dt[contains(text(),'Ownership Level')]");

        [FindsBy(How = How.XPath, Using = "//dl//dt[contains(text(),'Ownership Level')]/..")]
        public IWebElement OwnershipLevelText;
        public By locatorforOwnershipLevelText = By.XPath("//dl//dt[contains(text(),'Ownership Level')]/..");


        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),'Traveler Plus')]")]
        public IWebElement TravelerPlus;
        public By locatorforTravelerPlus = By.XPath("//dt[contains(text(),'Traveler Plus')]");

        [FindsBy(How = How.XPath, Using = "//dl//dt[contains(text(),'Traveler Plus')]/..")]
        public IWebElement TravelerPlusText;
        public By locatorforTravelerPlusText = By.XPath("//dl//dt[contains(text(),'Traveler Plus')]/..");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Available Points')]/../..")]
        public IWebElement AvailablePointsText;
        public By locatorforAvailablePointsText = By.XPath("//a[contains(text(),'Available Points')]/../..");

        [FindsBy(How = How.XPath, Using = "//a[text()='Available Points']")]
        public IWebElement AvailablePoints;
        public By locatorforAvailablePoints = By.XPath("//a[text()='Available Points']");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'dashboard')]")]
        public IWebElement myDashboardPage;
        public By locatorforMyDashboardPage = By.XPath("//h1[contains(text(),'dashboard')]");


        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Future Points')]/../..")]
        public IWebElement FuturePointsText;
        public By locatorforFuturePointsText = By.XPath("//a[contains(text(),'Future Points')]/../..");

        [FindsBy(How = How.XPath, Using = "//a[text()='Future Points']")]
        public IWebElement FuturePoints;
        public By locatorforFuturePoints = By.XPath("//a[text()='Future Points']");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Bluegreen Rewards')]/../..")]
        public IWebElement BlueGreenRewardsText;
        public By locatorforBlueGreenRewardsText = By.XPath("//a[contains(text(),'Bluegreen Rewards')]/../..");

        [FindsBy(How = How.XPath, Using = "//a[text()='Bluegreen Rewards']")]
        public IWebElement BlueGreenRewards;
        public By locatorforBlueGreenRewards = By.XPath("//a[text()='Bluegreen Rewards']");


        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Payment Balance')]/../..")]
        public IWebElement PaymentBalanceText;
        public By locatorforPaymentBalanceText = By.XPath("//a[contains(text(),'Payment Balance')]/../..");

        [FindsBy(How = How.XPath, Using = "//a[text()='Payment Balance']")]
        public IWebElement PaymentBalance;
        public By locatorforPaymentBalance = By.XPath("//a[text()='Payment Balance']");

        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),'Vacation Week(s)')]/..")]
        public IWebElement VacationWeekText;
        public By locatorforVacationWeekText = By.XPath("//dt[contains(text(),'Vacation Week(s)')]/..");

    }
}

