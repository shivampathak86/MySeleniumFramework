using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
    public class PWLSearchPage
    {
        public PWLSearchPage()
            {
            }
        public PWLSearchPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "cboResortID")]
        public IWebElement ResortName;
        public By locatorforResortName = By.Id("cboResortID");



        [FindsBy(How = How.XPath, Using = "//*[@id='UpdatePanel3']//*[@id='CheckInDate']")]
        public IWebElement CheckInDate;
        public By locatorforCheckInDate = By.XPath("//*[@id='UpdatePanel3']//*[@id='CheckInDate']");




        [FindsBy(How = How.XPath, Using = "//input[@name='CheckOutDate']")]
        public IWebElement CheckOutDate;
        public By locatorforCheckOutDate = By.XPath("//input[@name='CheckOutDate']");




        [FindsBy(How = How.XPath, Using = ".//*[@id='imgCheckAvailability']")]
        public IWebElement Search;
        public By locatorforSearch = By.XPath(".//*[@id='imgCheckAvailability']");

        public string pageName = "Premier Search Page";

        public string editRequestPageName = "Edit Request Page";

        [FindsBy(How = How.XPath, Using = ".//td[@class='ajax__calendar_active']/div/preceding::td[@class=''][last()]")]
        public IWebElement date_EditReq_Calender;
        public By locatorfordate_EditReq_Calender = By.XPath("(.//td[@class='ajax__calendar_active']/div/preceding::td[@class=''])[last()]");

        [FindsBy(How = How.XPath, Using = ".//td[@class='ajax__calendar_active']")]
        public IWebElement SelectDate;
        public By locatorforSelectDate = By.XPath("//td[@class='ajax__calendar_active']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='CalendarExtenderCheckIn_prevArrow']")]
        public IWebElement PrevArrow;
        public By locatorforPrevArrow = By.XPath(".//*[@id='CalendarExtenderCheckIn_prevArrow']");


        By locatorforEle = By.XPath("(.//td[@class='ajax__calendar_active']/div/preceding::td[@class=''])[last()]");
        [FindsBy(How = How.XPath, Using = ".//*[@id='pnlPoints1']//a[@href='PremierPending.aspx']")]
        public IWebElement pendingReqLink;
        public By locatorforpendingReqLink = By.XPath(".//*[@id='pnlPoints1']//a[@href='PremierPending.aspx']");

        [FindsBy(How = How.XPath, Using = "//*[@id='UpdatePanel3']//*[@id='lblResortName']")]
        public IWebElement labResortname;
        public By locatorforlabResortname = By.XPath("//*[@id='UpdatePanel3']//*[@id='lblResortName']");

        public string ValResortName = "";

    }
}
