using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class MyPointsPage
    {
        public MyPointsPage()
        {

        }

        public MyPointsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/div[@class='callout text-dark']")]
        public IWebElement AvailablePoints;
        public By locatorForAvailablePoints = By.XPath("//div[@class='callout text-dark']");

        //Available PoinsTable
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']/table")]
        public IWebElement APTTable;
        public By locatorforAPTTable = By.XPath(".//*[@id='section-available-points-summary']/table");


        //APT columns
        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']/table//td[1]")]
        public IWebElement APTAccount;
        public By locatorforAPTAccount = By.XPath(".//*[@id='section-available-points-summary']/table//td[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']/table//td[1]")]
        public IWebElement APTPointsType;
        public By locatorforAPTPointsType = By.XPath(".//*[@id='section-available-points-summary']/table//td[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points']/table//td[2]")]
        public IWebElement APTAvailablePoints;
        public By locatorforAPTAvailablePoints = By.XPath(".//*[@id='section-available-points-summary']/table//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points']/table//td[3]")]
        public IWebElement APTExpirationDate;
        public By locatorforAPTExpirationDate = By.XPath(".//*[@id='section-available-points-summary']/table//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']/table//td[4]")]
        public IWebElement APTAction;
        public By locatorforAPTAction = By.XPath(".//*[@id='section-available-points-summary']/table//td[4]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='show-current-points-details']")]
        public IWebElement detailsLink;
        public By locatorfordetailsLink = By.XPath(".//*[@id='show-current-points-details']");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Points')]")]
        public IWebElement myPointsPage;
        public By locatorforMyPointsPage = By.XPath("//h1[contains(text(),'Points')]");

        //Saved points

        [FindsBy(How = How.XPath, Using = ".//*[@id='site-content']//p[text()='saved points']/preceding-sibling::div[1]")]
        public IWebElement ValueSavedPoints;
        public By locatorforValueSavedPoints = By.XPath(".//*[@id='site-content']//p[text()='saved points']/preceding-sibling::div[1]");

        

        //APT columns by List


        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']//td[1]")]
        public IList<IWebElement> APTTable_ListPointType { get; set; }
        public By locatorforAPTTable_ListPointType = By.XPath(".//*[@id='section-available-points-summary']//td[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']//td[2]")]
        public IList<IWebElement> APTTable_ListPoints { get; set; }
        public By locatorforAPTTable_ListPoints = By.XPath(".//*[@id='section-available-points-summary']//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']//td[3]")]
        public IList<IWebElement> APTTable_ListExpirationDate { get; set; }
        public By locatorforAPTTable_ListExpirationDate = By.XPath(".//*[@id='section-available-points-summary']//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='section-available-points-summary']//td[4]")]
        public IList<IWebElement> APTTable_ListAction { get; set; }
        public By locatorforAPTTable_ListAction = By.XPath(".//*[@id='section-available-points-summary']//td[4]");

        public string AvailablePointsBal = "null";//value of available points shown near blue green menu
        public string pagename = "My Points Page";
    }
}
