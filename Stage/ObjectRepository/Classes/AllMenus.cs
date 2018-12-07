using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Configuration;

namespace BlueGreenOwner
{
    public class AllMenus
    {
        //MyBlueGreenMenu
		public AllMenus()
		{
            
		}

		public AllMenus(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}
        //MyBlueGreenMenu

        public By locatorforLoading= By.XPath("//div[@class='hidden loading']");
        [FindsBy(How = How.XPath, Using = "//div[@class='hidden loading']")]
        public IWebElement Loading;

        [FindsBy(How = How.XPath, Using = "//*[text()='my loan information']")]
        public IWebElement MyLoanInformationMenu;
        public By LocatorforMyLoanInformationMenu = By.XPath("//*[text()='my loan information']");

        public By locatorforMyBlueGreen = By.XPath(".//ul[@class='nav navbar-nav navbar-menu navbar-right']//li[@id='js-my-bluegreen']");
        [FindsBy(How = How.XPath, Using = ".//ul[@class='nav navbar-nav navbar-menu navbar-right']//li[@id='js-my-bluegreen']")]
        public IWebElement MyBlueGreenMenu;
        
        public By locatorforMyDashBoard = By.XPath("//*[@id='js-my-bluegreen']//a[text()='my dashboard']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='my dashboard']")]
        public IWebElement MyDashBoard;

        public By locatorforMyAccount = By.XPath("//*[@id='js-my-bluegreen']//a[text()='my account']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='my account']")]
        public IWebElement MyAccount;

        public By locatorforChoicePrivileges = By.XPath("//*[@id='js-my-bluegreen']//a[text()='choice privileges']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='choice privileges']")]
        public IWebElement ChoicePrivileges;

        public By locatorforPayments = By.XPath("//*[@id='js-my-bluegreen']//a[text()='payments']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='payments']")]
        public IWebElement Payments;

        public By locatorforLoanSummary = By.XPath("//*[@id='js-my-bluegreen']//a[text()='loan summary']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='loan summary']")]
        public IWebElement LoanSummary;

        public By locatorforMyPoints = By.XPath("//*[@id='js-my-bluegreen']//a[text()='my points']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='my points']")]
        public IWebElement MyPoints;

        public By locatorforMyReservations = By.XPath("*//li[@id='js-my-bluegreen']//a[text()='my reservations']");
        [FindsBy(How = How.XPath, Using = @"*//li[@id='js-my-bluegreen']//a[text()='my reservations']")]
        public IWebElement MyReservations;

        //Book Menu
        public By locatorforBook = By.XPath("//*[@id='navbar-menu-primary']//a[text()='book']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='book']")]
        public IWebElement Book;

        public By locatorforPremierWaitList = By.XPath("//*[@id='navbar-menu-primary']//a[text()='premier wait list']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='premier wait list']")]
        public IWebElement PremierWaitList;

        public By locatorforRCIExchanges = By.XPath("//*[@id='navbar-menu-primary']//a[text()='rci exchanges']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='rci exchanges'")]
        public IWebElement RCIExchanges;

        public By locatorforChoiceHotelsVipRate = By.XPath("//*[@id='navbar-menu-primary']//a[text()='choice hotels vip rate']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='choice hotels vip rate']")]
        public IWebElement ChoiceHotelsVipRate;

        public By locatorforCruises = By.XPath("//*[@id='navbar-menu-primary']//a[text()='cruises']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='cruises']")]
        public IWebElement Cruises;

        public By locatorforHotels = By.XPath("//*[@id='navbar-menu-primary']//a[text()='hotels']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='hotels']")]
        public IWebElement Hotels;

        public By locatorforCarRentals = By.XPath("//*[@id='navbar-menu-primary']//a[text()='car rentals']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='car rentals']")]
        public IWebElement CarRentals;

        public By locatorforFlights = By.XPath("//*[@id='navbar-menu-primary']//a[text()='flights']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='flights'")]
        public IWebElement Flights;

        public By locatorforOwnerAdventures = By.XPath("//*[@id='navbar-menu-primary']//a[text()='owner adventures']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='owner adventures']")]
        public IWebElement OwnerAdventures;

        //Blue green Resorts Menu 
        public By locatorforBlueGreenResorts = By.XPath("//*[@id='navbar-menu-primary']//a[text()='bluegreen resorts']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//a[text()='bluegreen resorts']")]
        public IWebElement BlueGreenResorts;

        public By locatorforPoints = By.XPath(".//*[@id='navbar-menu-primary']//a[text()='points']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//a[text()='points']")]
        public IWebElement Points;

        public By locatorforBonusTime = By.XPath(".//*[@id='navbar-menu-primary']//a[text()='bonus time']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//a[text()='bonus time']")]
        public IWebElement BonusTime;

        public By locatorforSavedSearches = By.XPath(".//*[@id='navbar-menu-primary']//a[text()='saved searches']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//a[text()='saved searches']")]
        public IWebElement SavedSearches;

        public By locatorforLastMinuteAvaialbility = By.XPath(".//*[@id='navbar-menu-primary']//a[text()='last minute availability']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//a[text()='last minute availability']")]
        public IWebElement LastMinuteAvaialablity;

        public By locatorforLMApage = By.XPath("//strong[contains(text(),'Last')]");
        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Last')]")]
        public IWebElement LMApage;

        //Vacation Planning Tools
        public By locatorforVacationPlanningTools = By.XPath("//*[@id='navbar-menu-primary']//a[text()='vacation planning tools']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='vacation planning tools']")]
        public IWebElement VacationPlanningTools;

        public By locatorforPointCalculator = By.XPath("//*[@id='navbar-menu-primary']//a[text()='points calculator']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='points calculator']")]
        public IWebElement PointCalculator;

        public By locatorforPointChart = By.XPath("//*[@id='navbar-menu-primary']//a[text()='points chart']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='points chart']")]
        public IWebElement PointChart;

        public By locatorforReservationReminder = By.XPath("//*[@id='navbar-menu-primary']//a[text()='reservation reminder']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='reservation reminder']")]
        public IWebElement ReservationReminder;

        public By locatorforVacationWeekCalender = By.XPath("//*[@id='navbar-menu-primary']//a[text()='vacation week calendar']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='vacation week calendar']")]
        public IWebElement VacationWeekCalender;
        //Learn menu

        public By locatorforLearn = By.XPath("//*[@id='navbar-menu-primary']//a[text()='learn']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='learn']")]
        public IWebElement Learn;

        public By locatorforGettingStarted = By.XPath("//*[@id='navbar-menu-primary']//a[text()='getting started']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='getting started']")]
        public IWebElement GettingStarted;

        public By locatorforAskBlueGreen = By.XPath("//*[@id='navbar-menu-primary']//a[text()='ask bluegreen']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='ask bluegreen']")]
        public IWebElement AskBlueGreen;

        public By locatorforTuitorials = By.XPath("//*[@id='navbar-menu-primary']//a[text()='tutorials & webinars']");
        [FindsBy(How = How.XPath, Using = @"//[@id='navbar-menu-primary']//a[text()='tutorials & webinars']")]
        public IWebElement Tuitorials;

        public By locatorforHowPointsWork = By.XPath("//*[@id='navbar-menu-primary']//a[text()='how points work']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='how points work']")]
        public IWebElement HowPointsWork;

        //Get Inspired
        public By locatorforGetInspired = By.XPath("//*[@id='navbar-menu-primary']//a[text()='get inspired']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='get inspired']")]
        public IWebElement GetInspired;

        public By locatorforResortLocator = By.XPath("//*[@id='navbar-menu-primary']//a[text()='resort locator']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='resort locator']")]
        public IWebElement ResortLocator;

        public By locatorforOwnerUpdate = By.XPath("//*[@id='navbar-menu-primary']//a[text()='owner update']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='owner update']")]
        public IWebElement OwnerUpdate;

        public By locatorforDestinationGuide = By.XPath("//*[@id='navbar-menu-primary']//a[text()='destination guide']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='resort locator']")]
        public IWebElement DestinationGuide;

        public By locatorforPowerOfVacationMagazine = By.XPath("//*[@id='navbar-menu-primary']//a[text()='power of vacation magazine']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='resort locator']")]
        public IWebElement PowerOfVacationMagazine;

        //Rewards
        public By locatorforRewards = By.XPath("//*[@id='navbar-menu-primary']//a[text()='rewards']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='rewards']")]
        public IWebElement Rewards;

        public By locatorforReferAFriendPage = By.XPath("//span[contains(text(),'a friend')]");
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'a friend')]")]
        public IWebElement ReferAFriendPage;

        public By locatorforInviteFriends = By.XPath("//*[@id='navbar-menu-primary']//a[text()='invite friends']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='invite friends']")]
        public IWebElement InviteFriends;

        public By locatorforReferralActivity = By.XPath("//*[@id='navbar-menu-primary']//a[text()='referral activity']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='referral activity']")]
        public IWebElement ReferralActivity;

        public By locatorforRewardsActivity = By.XPath("//*[@id='navbar-menu-primary']//a[text()='rewards activity']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='rewards activity']")]
        public IWebElement RewardsActivity;

        public By locatorforRedeemRewards = By.XPath(".//*[@id='navbar-menu-primary']//ul[@class='nav navbar-nav navbar-menu']//a[text()='redeem rewards']");
        [FindsBy(How = How.XPath, Using = @".//*[@id='navbar-menu-primary']//ul[@class='nav navbar-nav navbar-menu']//a[text()='redeem rewards']")]
        public IWebElement RedeemRewards;

        public By locatorforRewardsCheckOut = By.XPath("//*[@id='navbar-menu-primary']//a[text()='rewards check out']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='rewards check out']")]
        public IWebElement RewardsCheckOut;


        public By locatorforSweepStakes = By.XPath("//*[@id='navbar-menu-primary']//a[text()='sweepstakes']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='sweepstakes']")]
        public IWebElement SweepStakes;

        //Traveler Plus
        public By locatorforTravelerPlusMain = By.XPath("//*[@id='navbar-menu-primary']//li[@class=' has-flyout open-right ']/a[text()='traveler plus']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//li[@class=' has-flyout open-right ']/a[text()='traveler plus']")]
        public IWebElement TravelerPlusMain;

        public By locatorforNonTravelerPlusMain = By.XPath("//*[@id='navbar-menu-primary']//A[text()='traveler plus']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//A[text()='traveler plus']")]
        public IWebElement NonTravelerPlusMain;

        //A[text()='traveler plus']

        public By locatorforTravlerPlusSub = By.XPath("*//*[@id='navbar-menu-primary']//li[@class=' has-flyout open-right ']//ul[@class='navbar-menu-flyout open-right']//li//a[text()='traveler plus home']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//li[@class=' has-flyout open-right ']//ul[@class='navbar-menu-flyout open-right']//li//a[text()='traveler plus home']")]
        public IWebElement TravlerPlusSub;

        public By locatorforRenewMemberShip = By.XPath("//*[@id='navbar-menu-primary']//a[text()='renew my membership']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='renew my membership']")]
        public IWebElement RenewMemberShip;
        
        public By locatorforRenewMyTPPage = By.Id("frmRenewal");
        [FindsBy(How = How.Id, Using = "frmRenewal")]
        public IWebElement RenewMyTPPage;

        public By locatorforPaymentOptionsFirstRadioBtn = By.XPath("//input[@id='rdlPaymentOptions_Plus_0']");
        [FindsBy(How = How.XPath, Using = "//input[@id='rdlPaymentOptions_Plus_0']")]
        public IWebElement PaymentOptionsFirstRadioBtn;

        public By locatorforPaymentOptionsSecondRadioBtn = By.XPath("//input[@id='rdlPaymentOptions_Plus_1']");
        [FindsBy(How = How.XPath, Using = "//input[@id='rdlPaymentOptions_Plus_1']")]
        public IWebElement PaymentOptionsSecondRadioBtn;

        public By locatorforFirstRadioButtonText = By.XPath("//label[contains(text(),' 1 Year - $49.00 plus one time $20.00 reinstatement fee with ')]");
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),' 1 Year - $49.00 plus one time $20.00 reinstatement fee with ')]")]
        public IWebElement FirstRadioButtonText;

        public By locatorforSecondRadioButtonText = By.XPath("//label[contains(text(),'1 Year - $59.00 plus one time $20.00 reinstatement fee')]");
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'1 Year - $59.00 plus one time $20.00 reinstatement fee')]")]
        public IWebElement PaymentOptionsSecondRadioBtnText;

        public By locatorforPaymentOptions = By.XPath("//table[@id='rdlPaymentOptions_Plus']");
        [FindsBy(How = How.XPath, Using = "//table[@id='rdlPaymentOptions_Plus']")]
        public IWebElement PaymentOptions;

        public By locatorforNameTxtField = By.Id("txtbxCcname");
        [FindsBy(How = How.Id, Using = "txtbxCcname")]
        public IWebElement NameTxtField;

        public By locatorforCardNumberTxtField = By.Id("txtbxCcnum");
        [FindsBy(How = How.Id, Using = "txtbxCcnum")]
        public IWebElement CardNumberTextField;

        public By locatorforCardType = By.Id("ddlCcinit");
        [FindsBy(How = How.Id, Using = "ddlCcinit")]
        public IWebElement CardType;

        public By locatorforExpMonth = By.Id("ddlCcmonth");
        [FindsBy(How = How.Id, Using = "ddlCcmonth")]
        public IWebElement ExpMonth;

        public By locatorforExpYear = By.Id("ddlCcyear");
        [FindsBy(How = How.Id, Using = "ddlCcyear")]
        public IWebElement ExpYear;

        public By locatorforZipcode = By.Id("txtZipCode");
        [FindsBy(How = How.Id, Using = "txtZipCode")]
        public IWebElement Zipcode;

        public By locatorforCheckForZipcode = By.Id("chkInternationalZipCode");
        [FindsBy(How = How.Id, Using = "chkInternationalZipCode")]
        public IWebElement CheckForZipcode;

        public By locatorforSubmitButton = By.Id("btntpRenewSubmit");
        [FindsBy(How = How.Id, Using = "btntpRenewSubmit")]
        public IWebElement SubmitButton;

        public By locatorforConfirmationNumber = By.Id("//font[contains(text(),'Your Confirmation Number is ')]");
        [FindsBy(How = How.Id, Using = "//font[contains(text(),'Your Confirmation Number is ')]")]
        public IWebElement ConfirmationNumber;

        //My Account
        public By locatorforVacationProfile = By.XPath("//*[@id='navbar-menu-primary']//a[text()='vacation profile']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='vacation profile']")]
        public IWebElement VacationProfile;

        public By locatorforChangePassword = By.XPath("//*[@id='navbar-menu-primary']//a[text()='change password']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='change password']")]
        public IWebElement ChangePassword;

        public By locatorforGoGreen = By.XPath("//*[@id='navbar-menu-primary']//a[text()='go green']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='go green']")]
        public IWebElement GoGreen;

        public By locatorforPremierGuestProfile = By.XPath("//*[@id='navbar-menu-primary']//a[text()='premier guest profile']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='navbar-menu-primary']//a[text()='premier guest profile']")]
        public IWebElement PremierGuestProfile;

        //Payments
        public By locatorforMaintenanceFees = By.XPath("//*[@id='js-my-bluegreen']//a[text()='maint. fees and club dues']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='maint. fees and club dues']")]
        public IWebElement MaintenanceFees;

        public By locatorforMaintenanceFeesPageTxt = By.XPath("//h1[contains(text(),'maintenance fees and club dues')]");
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'maintenance fees and club dues')]")]
        public IWebElement MaintenanceFeesPageTxt;
        
        public By locatorforUpdateInfoLaterBtn = By.XPath("//*[text()='update information later']");
        [FindsBy(How = How.XPath, Using = "//*[text()='update information later']")]
        public IWebElement UpdateInfoLaterBtn;

        public By locatorforMakeAPayment = By.XPath("//*[@id='js-my-bluegreen']//a[text()='make a payment']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='make a payment']")]
        public IWebElement MakeAPayment;

        public By locatorforMakeAPrePayment = By.XPath("//*[@id='js-my-bluegreen']//a[text()='make a pre payment']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='make a pre payment']")]
        public IWebElement MakeAPrePayment;

        public By locatorforMakeRedeemRewards = By.XPath("//*[@id='js-my-bluegreen']//a[text()='view history']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='view history']")]
        public IWebElement MakeRedeemRewards;

        public By locatorforMaintenanceViewHistory = By.XPath("//*[@id='js-my-bluegreen']//a[text()='view history' and contains(@href,'MaintenanceFeeHistory')]");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='view history' and contains(@href,'MaintenanceFeeHistory')]")]
        public IWebElement MaintenanceViewHistory;

        public By locatorforMortgage = By.XPath("//*[@id='js-my-bluegreen']//a[text()='mortgage']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='mortgage']")]
        public IWebElement Mortgage;

        public By locatorforBorowwerInformation = By.XPath("//*[@id='js-my-bluegreen']//a[text()='borrower information']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='borrower information']")]
        public IWebElement BorowwerInformation;

        public By locatorforManageAutoPay = By.XPath("//*[@id='js-my-bluegreen']//a[text()='manage auto pay']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='manage auto pay']")]
        public IWebElement ManageAutoPay;

        public By locatorforMortgageViewHistory = By.XPath("//*[@id='js-my-bluegreen']//a[text()='view history' and contains(@href,'mortgagetransactionhistory')]");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='view history' and contains(@href,'mortgagetransactionhistory')]")]
        public IWebElement MortgageViewHistory;

        public By locatorforPaymentServices = By.XPath("//*[@id='js-my-bluegreen']//a[text()='payment services']");
        [FindsBy(How = How.XPath, Using = @"//*[@id='js-my-bluegreen']//a[text()='payment services']")]
        public IWebElement PaymentServices;

        public By locatorforPayOffQuote = By.XPath(".//ul[@class='navbar-menu-flyout open-right']//a[contains(text(),'pay off quote')]");
        [FindsBy(How = How.XPath, Using = ".//ul[@class='navbar-menu-flyout open-right']//a[contains(text(),'pay off quote')]")]
        public IWebElement PayOffQuote;
 
        
    }
}
