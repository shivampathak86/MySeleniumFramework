using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class TravelerPlusPage
    {
        public TravelerPlusPage()
        {

        }

        public TravelerPlusPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ember676']//span[@class='active tabHotel_UIA search-heading left r_border pointer']/a[text()=' Car']")]
        public IWebElement link_CAR;
        public By locatorforlink_CAR = By.XPath(".//*[@id='ember676']//span[@class='active tabHotel_UIA search-heading left r_border pointer']/a[text()=' Car']");


        [FindsBy(How = How.XPath, Using = ".//strong[text()='Direct Exchange']")]
        public IWebElement link_DirectExchange;
        public By locatorforlink_DirectExchange = By.XPath(".//strong[text()='Direct Exchange']");

        //changes done by Fathima


        [FindsBy(How = How.XPath, Using = "//h2[@id='travelerplus-direct-exchange']")]
        public IWebElement DirectExchangePage;
        public By locatorforDirectExchangePage = By.XPath("//h2[@id='travelerplus-direct-exchange']");


        [FindsBy(How = How.XPath, Using = ".//ul[@class='list-unstyled list-item-space']//a[.='Direct Exchange']")]
        public IWebElement link_DirectExchangeonTpPage;
        public By locatorforlink_DirectExchangeonTpPage = By.XPath(".//ul[@class='list-unstyled list-item-space']//a[.='Direct Exchange']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='selectConnection']/h2[1]")]
        public IWebElement heading_MakeUrDirectExchange;
        public By locatorforheading_MakeUrDirectExchange = By.XPath(".//*[@id='selectConnection']/h2[1]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'plus')]")]
        public IWebElement travelerPlusPage;
        public By locatorforTravelerPlusPage = By.XPath("//h1[contains(text(),'plus')]");

        [FindsBy(How = How.XPath, Using = "//img[@src='images/becomeaBXGTPmbr.gif']")]
        public IWebElement BecomeTPpage;
        public By locatorforBecomeTPpage = By.XPath("//img[@src='images/becomeaBXGTPmbr.gif']");

        public static string MakeUrDirectExchangeContent = "Bluegreen collaborates with other hospitality companies to give you more resort choices and vacation options using your Points outside the Bluegreen resort network.You have the flexibility to search real-time availability for the dates you want to travel before you make your reservations.* Plus you'll enjoy lower exchange fees compared to traditional exchange companies. Click here for an overview of the Direct Exchange program, then browse our wide variety of resort destinations.";

        [FindsBy(How = How.XPath, Using = ".//*[@id='selectConnection']/p[1]/a[1]")]
        public IWebElement link_here;
        public By locatorforlink_here = By.XPath(".//*[@id='selectConnection']/p[1]/a[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='selectConnection']/p[1]/a[text()='resort destinations']")]
        public IWebElement link_resortDestinations;
        public By locatorforlink_resortDestinations = By.XPath(".//*[@id='selectConnection']/p[1]/a[text()='resort destinations']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='selectConnection']/table//img[@src='images/prizzma-logo-lrg.gif']")]
        public IWebElement IMG_prizzma;
        public By locatorforIMG_prizzma = By.XPath(".//*[@id='selectConnection']/table//img[@src='images/prizzma-logo-lrg.gif']");

        [FindsBy(How = How.XPath, Using = ".//h2[text()='Choice Ascend Collection']")]
        public IWebElement Heading_ChoiceascendCollection;
        public By locatorforHeading_ChoiceascendCollection = By.XPath(".//h2[text()='Choice Ascend Collection']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//img[@src='images/btn-img-ascend-logo.gif']")]
        public IWebElement Logo_AscendHotelcollection;
        public By locatorforLogo_AscendHotelcollection = By.XPath(".//*[@id='learn']/tbody//img[@src='images/btn-img-ascend-logo.gif']");

        [FindsBy(How = How.Id, Using = "choice-hotels-logo-svg")]
        public IWebElement ChoiceHotel;
        public By locatorforChoiceHotel = By.Id("choice-hotels-logo-svg");

        [FindsBy(How = How.XPath, Using = "//div[@class='prizzma-logo']")]
        public IWebElement Prizzma;
        public By locatorforPrizzma = By.XPath("//div[@class='prizzma-logo']");

        [FindsBy(How = How.XPath, Using = "//iframe[@id='__printingFrame']")]
        public IWebElement PrizzmaPageFrame;
        public By locatorforPrizzmaPageFrame = By.XPath("//iframe[@id='__printingFrame']");

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Account Management')]")]
        public IWebElement PrizzmaPage;
        public By locatorforPrizzmaPage = By.XPath("//div[contains(text(),'Account Management')]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//td[text()='Not yet a Choice Privileges® member? Signing up is easy. Click ']")]
        public IWebElement text_notYetMember;
        public By locatorfortext_notYetMember = By.XPath(".//*[@id='learn']/tbody//td[text()='Not yet a Choice Privileges® member? Signing up is easy. Click ']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//td[text()='Not yet a Choice Privileges® member? Signing up is easy. Click ']/a[text()='here']")]
        public IWebElement EnrollHereLink_Intext_notYetMember;
        public By locatorforEnrollHereLink_Intext_notYetMember = By.XPath(".//*[@id='learn']/tbody//td[text()='Not yet a Choice Privileges® member? Signing up is easy. Click ']/a[text()='here']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//img[@src='images/btn-search-now.gif']")]
        public IWebElement SearchNow;
        public By locatorforSearchNow = By.XPath(".//*[@id='learn']/tbody//img[@src='images/btn-search-now.gif']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//a[text()='Disclosures - Prizzma']")]
        public IWebElement LinkDisclosuresPrizzma;
        public By locatorforLinkDisclosuresPrizzma = By.XPath(".//*[@id='learn']/tbody//a[text()='Disclosures - Prizzma']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/tbody//a[text()='Disclosures - Select Connections']")]
        public IWebElement LinkDisclosuresSelectConnections;
        public By locatorforLinkDisclosuresSelectConnections = By.XPath(".//*[@id='learn']/tbody//a[text()='Disclosures - Select Connections']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='selectConnection']/table/tbody//img[@src='images/btn-book-now.gif']")]
        public IWebElement buttonBookNow;
        public By locatorforbuttonBookNow = By.XPath(".//*[@id='selectConnection']/table/tbody//img[@src='images/btn-book-now.gif']");

        [FindsBy(How = How.XPath, Using = " .//*[@id='learn']")]
        public IWebElement tableLearnMore;
        public By locatorfortableLearnMore = By.XPath(".//*[@id='learn']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']//a/strong[text()='Choice Privileges®']")]
        public IWebElement LinkChoicePrivilges;
        public By locatorforLinkChoicePrivilges = By.XPath(".//*[@id='learn']//a/strong[text()='Choice Privileges®']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']//a/strong[text()='Choice Ascend Collection']")]
        public IWebElement LinkChoiceAscendCollections;
        public By locatorforLinkChoiceAscendCollections = By.XPath(".//*[@id='learn']//a/strong[text()='Choice Ascend Collection']");

        [FindsBy(How = How.XPath, Using = ".//strong[text()='RCI Nightly Stays']")]
        public IWebElement LinkRCINightlyStays;
        public By locatorforLinkRCINightlyStays = By.XPath(".//strong[text()='RCI Nightly Stays']");

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'RCI Nightly Stays')]")]
        public IWebElement RCINightlyStaysPage;
        public By locatorforRCINightlyStaysPage = By.XPath("//h2[contains(text(),'RCI Nightly Stays')]");




        //changes done by Fathima
        [FindsBy(How = How.XPath, Using = ".//ul[@class='list-unstyled list-item-space']//a[contains(text(),'RCI Nightly Stays')]")]
        public IWebElement LinkRCINightlyStaysUnderHelpfulLinks;
        public By locatorforLinkRCINightlyStaysUnderHelpfulLinks = By.XPath(".//ul[@class='list-unstyled list-item-space']//a[contains(text(),'RCI Nightly Stays')]");


        //RCI nightly Stays

        [FindsBy(How = How.XPath, Using = ".//strong[text()='Benefits of RCI Nightly Stays include the following:']")]
        public IWebElement HeadingBenefitsOfNightlyStays;
        public By locatorforHeadingBenefitsOfNightlyStays = By.XPath(".//strong[text()='Benefits of RCI Nightly Stays include the following:']");

        [FindsBy(How = How.XPath, Using = ".//li[text()='View real-time availability and book your vacation online using your Bluegreen Vacation Points']")]
        public IWebElement BenefitsOfNightlyStaysContent1;
        public By locatorforBenefitsOfNightlyStaysContent1 = By.XPath(".//li[text()='View real-time availability and book your vacation online using your Bluegreen Vacation Points']");

        [FindsBy(How = How.XPath, Using = ".//li[text()='Flexibility — stay just a few nights or a full week']']")]
        public IWebElement BenefitsOfNightlyStaysContent2;
        public By locatorforBenefitsOfNightlyStaysContent2 = By.XPath(".//li[text()='Flexibility — stay just a few nights or a full week']");

        [FindsBy(How = How.XPath, Using = ".//li[text()='Access to more than 4,500 resorts worldwide in the RCI network*']")]
        public IWebElement BenefitsOfNightlyStaysContent3;
        public By locatorforBenefitsOfNightlyStaysContent3 = By.XPath(".//li[text()='Access to more than 4,500 resorts worldwide in the RCI network*']");

        [FindsBy(How = How.XPath, Using = ".//input[@src='images/btn_RCINightlyStays_GetStarted.gif']")]
        public IWebElement getStartedNowButton;
        public By locatorforgetStartedNowButton = By.XPath(".//input[@src='images/btn_RCINightlyStays_GetStarted.gif']");

        [FindsBy(How = How.XPath, Using = "//table//p[8]/a[1]")]
        public IWebElement LinkVisitOurExchangeFAQPage;
        public By locatorforLinkVisitOurExchangeFAQPage = By.XPath("//table//p[8]/a[1]");

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'RCI-BluegreenVacations.png')]")]
        public IWebElement RCI_Page;
        public By locatorforRCI_Page = By.XPath("//img[contains(@src,'RCI-BluegreenVacations.png')]");
        
        [FindsBy(How = How.XPath, Using = "//table//p[8]/a[2]")]
        public IWebElement LinkClickHoursOfOperation;
        public By locatorforLinkClickHoursOfOperation = By.XPath("//table//p[8]/a[2]");

        //NonTpUsers
        [FindsBy(How = How.XPath, Using = "//a[text()='Resort Hot Weeks']")]
        public IWebElement HotWeeksGetAways;
        public By locatorforHotWeeksGetAways = By.XPath("//a[text()='Resort Hot Weeks']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Great Escapes']")]
        public IWebElement GreatEscape;
        public By locatorforGreatEscape = By.XPath("//a[text()='Great Escapes']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Camping']")]
        public IWebElement Camping;
        public By locatorforCamping = By.XPath("//a[text()='Camping']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='page-title']//img[@src='images/becomeaBXGTPmbr.gif']")]
        public IWebElement tpImage;
        public By locatorfortpImage = By.XPath(".//*[@id='page-title']//img[@src='images/becomeaBXGTPmbr.gif']");

        [FindsBy(How = How.XPath, Using = ".//table[@class='tpPreRenewCompareChart']")]
        public IWebElement tpBenefitTable;
        public By locatorfortpBenefitTable = By.XPath(".//table[@class='tpPreRenewCompareChart']");


        //RVresort Coast links
        [FindsBy(How = How.XPath, Using = ".//ul[@class='subnav']//a[text()='Coast to Coast RV Resort Camping']")]
        public IWebElement LinkRVResortCamps;
        public By locatorforLinkRVResortCamps = By.XPath(".//ul[@class='subnav']//a[text()='Coast to Coast RV Resort Camping']");

        //changes done by Fathima
        [FindsBy(How = How.XPath, Using = ".//ul[@class='list-unstyled list-item-space']//a[text()='RV Resort Camping']")]
        public IWebElement LinkRVResortCampsonTp;
        public By locatorforLinkRVResortCampsonTp = By.XPath(".//ul[@class='list-unstyled list-item-space']//a[text()='RV Resort Camping']");

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'RV Resort Camping')]")]
        public IWebElement RVResortCampingPage;
        public By locatorforRVResortCampingPage = By.XPath("//h2[contains(text(),'RV Resort Camping')]");

        [FindsBy(How = How.XPath, Using = " .//*[@id='ImgBtnClickHereBookNow']")]
        public IWebElement BookButtonTop;
        public By locatorforBookButtonTop = By.XPath(" .//*[@id='ImgBtnClickHereBookNow']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='ImgBtnClickHere']")]
        public IWebElement BookButtonDown;
        public By locatorforBookButtonDown = By.XPath(".//*[@id='ImgBtnClickHere']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='Form1']//table[@id='rcorners']/..")]
        public IList<IWebElement> GoCampingText { get; set; }
        public By locatorforGoCampingText = By.XPath(".//*[@id='Form1']//table[@id='rcorners']/..");


        [FindsBy(How = How.XPath, Using = "//h2[text()='Member Renewal Confirmation']")]
        public IWebElement TPrenewalConfirmationPg;
        public By locatorforTPrenewalConfirmationPg = By.XPath("//h2[text()='Member Renewal Confirmation']");

        [FindsBy(How = How.XPath, Using = "//font[@color='red']")]
        public IWebElement TPConfirmationNumber;
        public By locatorforTPConfirmationNumber = By.XPath("//font[@color='red']");
        
        [FindsBy(How = How.XPath, Using = "(//strong[@class='orange-type'])[1]")]
        public IWebElement ConvertYourPointsText;
        public By locatorforConvertYourPointsText = By.XPath("(//strong[@class='orange-type'])[1]");


        [FindsBy(How = How.XPath, Using = "(.//*[@id='Form1']//strong[@class='orange-type'])[2]")]
        public IWebElement SaveYourPointsText;
        public By locatorforSaveYourPointsText = By.XPath("(.//*[@id='Form1']//strong[@class='orange-type'])[2]");




        //below has text, so no separet validatio needed

        [FindsBy(How = How.XPath, Using = "(.//*[@id='Form1']//strong[@class='orange-type'])[3]")]
        public IWebElement ClickHereLink;
        public By locatorforClickHereLink = By.XPath("(.//*[@id='Form1']//strong[@class='orange-type'])[3]");

        [FindsBy(How = How.XPath, Using = "//a[text()='booking guidelines']")]
        public IWebElement bookingGuidelinesLink;
        public By locatorforbookingGuidelinesLink = By.XPath("//a[text()='booking guidelines']");

        [FindsBy(How = How.XPath, Using = "//a[text()='participating RV resorts']")]
        public IWebElement participatingRVResortsLink;
        public By locatorforparticipatingRVResortsLink = By.XPath("//a[text()='participating RV resorts']");


        [FindsBy(How = How.XPath, Using = " //a[text()='temporary Coast to Coast membership card']")]
        public IWebElement temporaryCoastToCoastLink;
        public By locatorfortemporaryCoastToCoastLink = By.XPath(" //a[text()='temporary Coast to Coast membership card']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='cbTnC']")]
        public IWebElement TermsAndConditionsCheckBox;
        public By locatorforTermsAndConditionsCheckBox = By.XPath(".//*[@id='cbTnC']");

        public string nontravelerplushomepage = "Become A Bluegreen Traveler Plus Member Page";
        public string pageName = "Direct Exchanges Page";
        public string rvresortCampingPageName = "RV Resort Camping Page";

        //*****************************PROD URL*****************************************************************
        //public string URLForDirectExchange = "https://www.bluegreenowner.com/TravelerPlus/owner/DirectExchange.aspx";
        //public string URLForPrizzmaDirectExchange = @"https://www.prizzma.com/server/Clientsite.html?locale=en&ref=0#Search/Location/A";
        //public string URLForChoiceHotels = @"https://www.choicehotels.com/ascend";
        //public string URLForRCINightlyStaysHomePage = @"https://b2b.rci.com/club";
        //public string URLForTravelerPlusRCIPage = @"https://www.bluegreenowner.com/TravelerPlus/owner/RCINightlyStays.aspx";
        //*****************************PROD URL*****************************************************************

        //*****************************STAGE URL*****************************************************************

        //*****************************STAGE URL*****************************************************************

        //public string URLForDirectExchange = string.Empty;
        //public string URLForPrizzmaDirectExchange = string.Empty;
        //public string URLForChoiceHotels = string.Empty;
        //public string URLForRCINightlyStaysHomePage = string.Empty;
        //public string URLForTravelerPlusRCIPage = string.Empty;


        //public TravelerPlusPage()
        //{
        //    if (TestBaseClass.TestEnvironment.ToUpper().Equals("STAGE"))
        //    {

        //        //URLForDirectExchange = "https://stg.bluegreenowner.com/TravelerPlus/owner/DirectExchange.aspx";
        //        //URLForPrizzmaDirectExchange = @"https://test.holidayjuggle.net:8443/Clientsite.html?locale=en&ref=0#My Account&InactiveMem";
        //        //URLForChoiceHotels = @"https://www.choicehotels.com/ascend";
        //        //URLForRCINightlyStaysHomePage = @"https://testb2bb.rci.com/RCI/login/LoginController.jpf";
        //        //URLForTravelerPlusRCIPage = @"https://stg.bluegreenowner.com/TravelerPlus/owner/RCINightlyStays.aspx";
        //    }

        //    else if (TestBaseClass.TestEnvironment.ToUpper().Equals("PRODUCTION"))
        //    {
        //        URLForDirectExchange = "";
        //        URLForPrizzmaDirectExchange = @"";
        //        URLForChoiceHotels = @"";
        //        URLForRCINightlyStaysHomePage = @"";
        //        URLForTravelerPlusRCIPage = @"";

        //    }
        //}

    }
}
