using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class ChoicePrivilegesPage
    {

        [FindsBy(How = How.XPath, Using = ".//a[text()='Convert Bluegreen Vacation Points to Choice Privileges points']")]
        public IWebElement CPlegacylink;
        public By locatorforCPlegacylink = By.XPath(".//a[text()='Convert Bluegreen Vacation Points to Choice Privileges points']");

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Jump To:')]")]
        public IWebElement HomePageNonClub;
        public By locatorforHomePageNonClub = By.XPath("//div[contains(text(),'Jump To:')]");

        //stage
        //[FindsBy(How = How.XPath, Using = "//b[.='Convert Bluegreen Vacation Points to Choice Privileges points']")]
        //public IWebElement convertPointsToCPLink;
        //public By locatorForConvertPointsToCPLink = By.XPath("//b[.='Convert Bluegreen Vacation Points to Choice Privileges points']");
       
        [FindsBy(How = How.XPath, Using = "//img[@src='images/pg-title-my_points.jpg']")]
        public IWebElement MyPointsPage;
        public By locatorForMyPointsPage = By.XPath("//img[@src='images/pg-title-my_points.jpg']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlOwner']")]
        public IWebElement selectOwnerDropDown;
        public By locatorforSelectOwnerDropDown = By.XPath("//select[@id='ddlOwner']");

        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Other')]")]
        public IWebElement otherOption_DropDown;
        public By locatorforOtherOption_DropDown = By.XPath("//option[contains(text(),'Other')]");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBvcToChcPts']")]
        public IWebElement NoOfPointsToConvert;
        public By locatorforNoOfPointsToConvert = By.XPath("//input[@id='txtBvcToChcPts']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtNameOnCard']")]
        public IWebElement NameOfCardHolder;
        public By locatorforNameOfCardHolder = By.XPath("//input[@id='txtNameOnCard']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCCtype']")]
        public IWebElement CardType;
        public By locatorforCardType = By.XPath("//select[@id='ddlCCtype']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxCCNumber']")]
        public IWebElement CardNumber;
        public By locatorforCardNumber = By.XPath("//input[@id='txtBxCCNumber']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlExpMonth']")]
        public IWebElement ExpDate_Month;
        public By locatorforExpDate_Month = By.XPath("//select[@id='ddlExpMonth']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlExpYear']")]
        public IWebElement ExpDate_Year;
        public By locatorforExpDate_Year = By.XPath("//select[@id='ddlExpYear']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtZipCode']")]
        public IWebElement ZipCode;
        public By locatorforZipCode = By.XPath("//input[@id='txtZipCode']");

        [FindsBy(How = How.XPath, Using = "//input[@id='ChkUs']")]
        public IWebElement CheckBoxForIntlZipCode;
        public By locatorforCheckBoxForIntlZipCode = By.XPath("//input[@id='ChkUs']");

        [FindsBy(How = How.XPath, Using = "//input[@id='chkAccept']")]
        public IWebElement AcceptConditionsCheckBox;
        public By locatorforAcceptConditionsCheckBox = By.XPath("//input[@id='chkAccept']");

        [FindsBy(How = How.XPath, Using = "//input[@id='btnCCsubmit']")]
        public IWebElement SumitBtn;
        public By locatorforSumitBtn = By.XPath("//input[@id='btnCCsubmit']");

        [FindsBy(How = How.XPath, Using = "//strong[.='Eligible Points to Convert:']")]
        public IWebElement EligiblePtsToConvert;
        public By locatorforEligiblePtsToConvert = By.XPath("//strong[.='Eligible Points to Convert:']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtFirstName']")]
        public IWebElement FirstName;
        public By locatorforFirstName = By.XPath("//input[@id='txtFirstName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtLastName']")]
        public IWebElement LastName;
        public By locatorforLastName = By.XPath("//input[@id='txtLastName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtChoiceId']")]
        public IWebElement ChoicePrivilegeMember;
        public By locatorforChoicePrivilegeMember = By.XPath("//input[@id='txtChoiceId']");

        [FindsBy(How = How.XPath, Using = "//h3[text()='Credit Card Information']")]
        public IWebElement CreditCardInfo;
        public By locatorforCreditCardInfo = By.XPath("//h3[text()='Credit Card Information']");

        [FindsBy(How = How.XPath, Using = "//b[.='Your Choice Privileges® points are now available in your Choice Privileges account.']")]
        public IWebElement YourPaymentWasApproved;
        public By locatorforYourPaymentWasApproved = By.XPath("//b[.='Your Choice Privileges® points are now available in your Choice Privileges account.']");

        [FindsBy(How = How.XPath, Using = "//span[@id='LblBvcPoints']/..")]
        public IWebElement BGPointsDeducted;
        public By locatorforBGPointsDeducted = By.XPath("//span[@id='LblBvcPoints']/..");

        [FindsBy(How = How.XPath, Using = "  //span[@id='LblChcPoints']/..")]
        public IWebElement CPPointsDeposited;
        public By locatorforCPPointsDeposited = By.XPath("  //span[@id='LblChcPoints']/..");

        [FindsBy(How = How.XPath, Using = "//table[@id='GrdConversion']")]
        public IWebElement CPConvertTable;
        public By locatorforCPConvertTable = By.XPath("//table[@id='GrdConversion']");

        [FindsBy(How = How.XPath, Using = "//*[@ when='::strings.cp.ptsPluralize']")]
        public IWebElement ChoiceHotelsCPCheck;
        public By locatorforChoiceHotelsCPCheck = By.XPath("//*[@ when='::strings.cp.ptsPluralize']");

        [FindsBy(How = How.XPath, Using = "//*[@class='overlay']")]
        public IWebElement Overlay;
        public By LocatorforOverlay = By.XPath("//*[@class='overlay']");

        public string SelectOwner = "fathima, nourain";
        public string points = "5";

        public string UrlForChoiceHotels = "https://replatformqa2.choicehotels.com/";

        public ChoicePrivilegesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

    }
}
