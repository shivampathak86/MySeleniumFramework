using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
   public class MyReservationPage
    {
        public MyReservationPage()
        {

        }
        public MyReservationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public IWebElement buyNow;


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@class='c0']/strong[@class='details']")]
        public IList<IWebElement> CRTable_ListAccomodations { get; set; }
        public By locatorforCRTable_ListAccomodations = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@class='c0']/strong[@class='details']");



        //past reservations
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-past-reservations-details']/table//td[@data-label='confirmation #']/a")]
        public IList<IWebElement> PRTable_ListConfirmationNumber { get; set; }
        public By locatorforPRTable_ListConfirmationNumber = By.XPath(".//*[@id='section-past-reservations-details']/table//td[@data-label='confirmation #']/a");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-past-reservations-details']/table/tbody/tr[not(@style = 'display: none;')]/td[2]")]
        public IList<IWebElement> PRTable_ListConfirmationNumberDisplayed { get; set; }
        public By locatorforPRTable_ListConfirmationNumberDisplayed = By.XPath(".//*[@id='section-past-reservations-details']/table/tbody/tr[not(@style = 'display: none;')]/td[2]");

        //current reservation
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table/tbody/tr[not(@style = 'display: none;')]/td[2]")]
        public IList<IWebElement> CRTable_ListConfirmationNumberDisplayed { get; set; }
        public By locatorforCRTable_ListConfirmationNumberDisplayed = By.XPath(".//*[@id='section-current-reservations-details']/table/tbody/tr[not(@style = 'display: none;')]/td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='confirmation #']/a")]
        public IList<IWebElement> CRTable_ListConfirmationNumber { get; set; }
        public By locatorforCRTable_ListConfirmationNumber = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='confirmation #']/a");


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='check-in']")]
        public IList<IWebElement> CRTable_ListCheckIn { get; set; }
        public By locatorforCRTable_ListCheckIn = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='check-in']");




        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='check-out']")]
        public IList<IWebElement> CRTable_ListCheckOut { get; set; }

        public By locatorforCRTable_ListCheckOut = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='check-out']");





        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='amount']")]
        public IList<IWebElement> CRTable_ListAmount { get; set; }
        public By locatorforCRTable_ListAmount = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='amount']");




        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='type']")]
        public IList<IWebElement> CRTable_ListType { get; set; }
        public By locatorforCRTable_ListType = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='type']");




        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='PPP status']")]
        public IList<IWebElement> CRTable_ListPPPStatus { get; set; }
        public By locatorforCRTable_ListPPPStatus = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='PPP status']");






        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table")]
        public IWebElement CurrentReservationTable;
        public By locatorforCurrentReservationTable = By.XPath(".//*[@id='section-current-reservations-details']/table");


        //[FindsBy(How = How.XPath, Using = "(.//*[@id='section-current-reservations']//div[@class='pager paging-nav tablesorter-pager'])//child::a[@class='view-all']")]
        //public IWebElement ViewAllLink;
        //public By locatorforViewAllLink = By.XPath("(.//*[@id='section-current-reservations']//div[@class='pager paging-nav tablesorter-pager'])//child::a[@class='view-all']");

        [FindsBy(How = How.XPath, Using = ".//div[@id='section-current-reservations-details']//a[contains(text(),'all')]")]
        public IWebElement ViewAllLink;
        public By locatorforViewAllLink = By.XPath(".//div[@id='section-current-reservations-details']//a[contains(text(),'all')]");

        [FindsBy(How = How.XPath, Using = "(.//*[@id='section-past-reservations-details']//div[@class='pager paging-nav tablesorter-pager'])//child::a[@class='view-all']")]
        public IWebElement ViewAllLinkForPastreservations;
        public By locatorforViewAllLinkForPastreservations = By.XPath("(.//*[@id='section-past-reservations-details']//div[@class='pager paging-nav tablesorter-pager'])//child::a[@class='view-all']");


        [FindsBy(How = How.XPath, Using = ".//a[@href='/mybluegreen/my-reservations']")]
        public IWebElement ViewMyReservation;
        public By locatorforViewMyReservation = By.XPath(".//a[@href='/mybluegreen/my-reservations']");






        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//a[@title='cancel reservation']")]
        public IWebElement CancelReservationLink;
        public By locatorforCancelReservationLink = By.XPath(".//*[@id='site-content']//a[@title='cancel reservation']");
        public IWebElement confirmationNumberLink = null;

                      
        public string confirmationNumber = null;

        public string pageName = "My Reservations";




        [FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations']//a[text()='make a reservation']")]
        public IWebElement makeAReservationButton;
        public By locatorformakeAReservationButton = By.XPath(".//*[@id='section-current-reservations']//a[text()='make a reservation']");
          
    }
}
