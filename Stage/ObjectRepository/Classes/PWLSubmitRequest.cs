using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;

namespace BlueGreenOwner
{
    public class PWLSubmitRequestPage

        
    {

        public PWLSubmitRequestPage()
        {

        }
        public PWLSubmitRequestPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "(.//*[@name='rbtndivVillaSize'])[1]")]
        public IWebElement roomType;
        public By locatorforroomType = By.XPath("(.//*[@name='rbtndivVillaSize'])[1]");

        [FindsBy(How = How.Id, Using = "lblSubmitNewRequestLegend")]
        public IWebElement SubmitNewRequest;
        public By locatorforSubmitNewRequest = By.Id("lblSubmitNewRequestLegend");

        [FindsBy(How = How.XPath, Using = "(.//*[@name='rbtndivVillaSize'])[2]")]
        public IWebElement roomType2;
        public By locatorforroomType2 = By.XPath("(.//*[@name='rbtndivVillaSize'])[2]");


        [FindsBy(How = How.XPath, Using = "(.//*[@name='rbtndivVillaSize'])[1]//following-sibling::label[1]")]
        public IWebElement Label_roomType;
        public By locatorforLabel_roomType = By.XPath("(.//*[@name='rbtndivVillaSize'])[1]//following-sibling::label[1]");

        [FindsBy(How = How.XPath, Using = "(.//*[@name='rbtndivVillaSize'])[1]//following-sibling::label[2]")]
        public IWebElement Label_roomType2;
        public By locatorforLabel_roomType2 = By.XPath("(.//*[@name='rbtndivVillaSize'])[1]//following-sibling::label[2]");


        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement FirstName;
        public By locatorforFirstName = By.Id("firstname");



        [FindsBy(How = How.Id, Using = "lastname")]

        public IWebElement LastName;
        public By locatorforLastName = By.Id("lastname");

        [FindsBy(How = How.Id, Using = "guestPhone")]
        public IWebElement GuestPhone;
        public By locatorforGuestPhone = By.Id("guestPhone");


        [FindsBy(How = How.Id, Using = "guestEmail")]
        public IWebElement Email;
        public By locatorforEmail = By.Id("guestEmail");


        [FindsBy(How = How.XPath, Using = ".//*[@id='drpdwnNumberOfGuests']")]
        public IWebElement NumberOfGuests;
        public By locatorforNumberOfGuests = By.XPath(".//*[@id='drpdwnNumberOfGuests']");


        [FindsBy(How = How.Id, Using = "specialRequest")]
        public IWebElement SpecialRequest;
        public By locatorforSpecialRequest = By.Id("specialRequest");

        [FindsBy(How = How.Id, Using = "toggle")]
        public IWebElement IAgreeCheckBox;
        public By locatorforIAgreeCheckBox = By.Id("toggle");

        [FindsBy(How = How.Id, Using = "submitRequest")]
        public IWebElement Submit;
        public By locatorforSubmit = By.Id("submitRequest");



        [FindsBy(How = How.Id, Using = "lblResortNameDisplay")]
        public IWebElement Lab_resortName;
        public By locatorforLab_resortName = By.Id("lblResortNameDisplay");

        [FindsBy(How = How.Id, Using = "lblCheckInDate")]
        public IWebElement Lab_checkInDate;
        public By locatorforLab_checkInDate = By.Id("lblCheckInDate");


        [FindsBy(How = How.Id, Using = "lblCheckOutDate")]
        public IWebElement Lab_checkOutDate;
        public By locatorforLab_checkOutDate = By.Id("lblCheckOutDate");


        public string pageName = "Submit New Request";
        public string EditPageName = "Submit Request Edit";
        public string resortName = null;
        public string guestsnum = null;
        public string roomtypeVal = null;
        public string checkindate = null;
        public string checkoutdate = null;

       // public string UrlForConfirmationPage = String.Empty;
      
        //public PWLSubmitRequestPage()
        //{
        //    if (ConfigurationManager.AppSettings["ENVIRONMENT"].ToUpper().Equals("STAGE"))
        //    {

        //        UrlForConfirmationPage = @"https://stg.bluegreenowner.com/owner/PremierSearch.aspx";
        //    }
        //    else if (ConfigurationManager.AppSettings["ENVIRONMENT"].ToUpper().Equals("PRODUCTION"))
        //    {
        //        UrlForConfirmationPage = @"https://www.bluegreenowner.com/owner/PremierSearch.aspx";

        //    }
        //}
    }
}
