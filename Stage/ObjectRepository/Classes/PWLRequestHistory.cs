using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BlueGreenOwner
{
    public class PWLRequestHistoryPage
    {
        public PWLRequestHistoryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PWLRequestHistoryPage()
        {

        }
        [FindsBy(How = How.Id, Using = "gridPendingRequest")]
        public IWebElement PendingRequestTable;
        public By locatorforPendingRequestTable = By.Id("gridPendingRequest");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//tr[2]//td[1]")]
        public IWebElement PendingRequestTableSecondRow;
        public By locatorforPendingRequestTableSecondRow = By.XPath(".//*[@id='gridPendingRequest']//tr[2]//td[1]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[1]")]
        public IList<IWebElement> PRTable_ListRequestID { get; set; }
        public By locatorforPRTable_ListRequestID = By.XPath(".//*[@id='gridPendingRequest']//td[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[2]")]
        public IList<IWebElement> PRTable_ListResortName { get; set; }
        public By locatorforPRTable_ListResortName = By.XPath(".//*[@id='gridPendingRequest']//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[3]")]
        public IList<IWebElement> PRTable_ListGuest { get; set; }
        public By locatorforPRTable_ListGuest = By.XPath(".//*[@id='gridPendingRequest']//td[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[4]")]
        public IList<IWebElement> PRTable_ListCheckIn { get; set; }
        public By locatorforPRTable_ListCheckIn = By.XPath(".//*[@id='gridPendingRequest']//td[4]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[5]")]
        public IList<IWebElement> PRTable_ListCheckOut { get; set; }
        public By locatorforPRTable_ListCheckOut = By.XPath(".//*[@id='gridPendingRequest']//td[5]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[6]")]
        public IList<IWebElement> PRTable_RoomType { get; set; }
        public By locatorforPRTable_RoomType = By.XPath(".//*[@id='gridPendingRequest']//td[6]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[7]")]
        public IList<IWebElement> PRTable_DateEntered { get; set; }
        public By locatorforPRTable_DateEntered = By.XPath(".//*[@id='gridPendingRequest']//td[7]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='gridPendingRequest']//td[8]")]
        public IList<IWebElement> PRTable_Status { get; set; }
        public By locatorforStatus = By.XPath(".//*[@id='gridPendingRequest']//td[8]");

      //  public string UrlForConfirmationPage = String.Empty;

        //public PWLRequestHistoryPage()
        //{
        //    if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("STAGE"))
        //        UrlForConfirmationPage = @"https://stg.bluegreenowner.com/owner/PremierPending.aspx";
        //    else if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("PRODUCTION"))
        //        UrlForConfirmationPage = @"https://www.bluegreenowner.com/owner/PremierSearch.aspx";
        //}

        public string resortName = null;
        public string guestsnum = null;
        public string roomtype = null;
        public string checkindate = null;
        public string checkoutdate = null;

    }
}
