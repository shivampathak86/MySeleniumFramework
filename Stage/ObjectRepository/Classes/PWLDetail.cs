using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;


namespace BlueGreenOwner
{
    public class PWLRequestDetailPage
    {
        public PWLRequestDetailPage()
        {
        }

        public PWLRequestDetailPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


      
        [FindsBy(How = How.XPath, Using = ".//div[@id='divStatusDependentTop']//input[@id='imgEditButtonTop']")]
        public IWebElement btnEditRequest;
        public By locatorforbtnEditRequest = By.XPath(".//div[@id='divStatusDependentTop']//input[@id='imgEditButtonTop']");

        [FindsBy(How = How.XPath, Using = "//div[@id='pnlResDetail']//*[@id='hlResortName']")]
        public IWebElement linkResortname;
        public By locatorforlinkResortname = By.XPath("//div[@id='pnlResDetail']//*[@id='hlResortName']");


        [FindsBy(How = How.Id, Using = "imgCancelButtonTop")]
        public IWebElement btnCancelrequest;
        public By locatorforbtnCancelrequest = By.Id("imgCancelButtonTop");

        [FindsBy(How = How.XPath, Using = ".//*[@id='imgEditButtonBottom']")]

        public IWebElement btnEditRequestBottom;
        public By locatorforbtnEditRequestBottom = By.XPath(".//*[@id='imgEditButtonBottom']");


        [FindsBy(How = How.Id, Using = "imgCancelButtonDown")]
        public IWebElement btnCancelrequestBottom;
        public By locatorforbtnCancelrequestBottom = By.Id("imgCancelButtonDown");

        [FindsBy(How = How.Id, Using = "imgBackButtonupper")]
        public IWebElement btnBacktoWaitList;
        public By locatorforbtnBacktoWaitList = By.Id("imgBackButtonupper");


        [FindsBy(How = How.Id, Using = "lblRequestId")]
        public IWebElement lblRequestId;
        public By locatorforlblRequestId = By.Id("lblRequestId");

        [FindsBy(How = How.Id, Using = "lblConfirmationStatus")]
        public IWebElement lblConfirmationStatus;
        public By locatorforlblConfirmationStatus = By.Id("lblConfirmationStatus");


        [FindsBy(How = How.Id, Using = "lblCheckIn")]
        public IWebElement lblCheckIn;
        public By locatorforlblCheckIn = By.Id("lblCheckIn");


        [FindsBy(How = How.Id, Using = "lblCheckOut")]
        public IWebElement lblCheckOut;
        public By locatorforlblCheckOut = By.Id("lblCheckOut");


        [FindsBy(How = How.Id, Using = "lblDateEntered")]
        public IWebElement lblDateEntered;
        public By locatorforlblDateEntered = By.Id("lblDateEntered");


        [FindsBy(How = How.Id, Using = "lblGuestName")]
        public IWebElement lblGuestName;
        public By locatorforlblGuestName = By.Id("lblGuestName");


        [FindsBy(How = How.Id, Using = "lblNumofAdults")]
        public IWebElement lblNumofAdults;
        public By locatorforlblNumofAdults = By.Id("lblNumofAdults");


        [FindsBy(How = How.Id, Using = "lblEstimatedPoints")]
        public IWebElement lblEstimatedPoints;
        public By locatorforlblEstimatedPoints = By.Id("lblEstimatedPoints");


        [FindsBy(How = How.Id, Using = "lblConfNum")]
        public IWebElement lblConfNum;
        public By locatorforlblConfNum = By.Id("lblConfNum");


        [FindsBy(How = How.Id, Using = "lblSpecialRequest")]
        public IWebElement lblSpecialRequest;
        public By locatorforlblSpecialRequest = By.Id("lblSpecialRequest");



        public string pageName = "RequestDetails";
        public string cancelPopupName = "Cancel Request Popup";



        public string reqId = null;

        public string resortName = null;

        public string guestsnum = null;

        public string checkindate = null;

        public string checkoutdate = null;


        public string roomtypeVal = null;
        public string CurrentDate = null;
        public string PWLPendingStatus = "Request Pending";

        public string javascriptCommandForEditButtonTop = "return document.getElementById('imgEditButtonTop').click();";

        public string javascriptCommandForEditButtonBottom = "return document.getElementById('imgEditButtonBottom').click();";

        public string javascriptCommandForCancelButtonTop = "return document.getElementById('imgCancelButtonTop').click();";

        public string javascriptCommandForCancelButtonBottom = "return document.getElementById('imgCancelButtonDown').click();";

        //For Cancelling PWL

        [FindsBy(How = How.XPath, Using = ".//*[@id='ui-id-1']")]
        public IWebElement popupCancel;
        public By locatorforpopupCancel = By.XPath(".//*[@id='ui-id-1']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dialog']/p")]
        public IWebElement warningMessage;
        public By locatorforwarningMessage = By.XPath(".//*[@id='dialog']/p");


        [FindsBy(How = How.XPath, Using = ".//div[@class='ui-dialog-buttonset']//span[text()='Yes']")]
        public IWebElement YesButton;
        public By locatorforYesButton = By.XPath(".//div[@class='ui-dialog-buttonset']//span[text()='Yes']");


        [FindsBy(How = How.XPath, Using = ".//div[@class='ui-dialog-buttonset']//span[text()='No']")]
        public IWebElement NoButton;
        public By locatorforNoButton = By.XPath(".//div[@class='ui-dialog-buttonset']//span[text()='No']");
    }
}
