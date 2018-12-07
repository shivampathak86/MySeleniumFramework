using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class GreatEscapesReservationPage
    {

        [FindsBy(How = How.Id, Using = "ddlRegion")]
        public IWebElement destinationDropDown;
        public By locatorforDestinationDropDown = By.Id("ddlRegion");

        [FindsBy(How = How.Id, Using = "GotMonth")]
        public IWebElement monthDropDown;
        public By locatorforMonthDropDown = By.Id("GotMonth");

        [FindsBy(How = How.Id, Using = "btnImgSearch")]
        public IWebElement searchBtn;
        public By locatorforSearchBtn = By.Id("btnImgSearch");

        [FindsBy(How = How.Id, Using = "LblNoResults")]
        public IWebElement noInventoryAvailable;
        public By locatorforNoInventoryAvailable = By.Id("LblNoResults");

        [FindsBy(How = How.XPath, Using = "//input[@name='submitimg']")]
        public IWebElement bookItBtn;
        public By locatorforBookItBtn = By.XPath("//input[@name='submitimg']");

        [FindsBy(How = How.XPath, Using = ".//td//a[@href='greatescapesSearch.aspx']")]
        public IWebElement searchAgainBtn;
        public By locatorforSearchAgainBtn = By.XPath(".//td//a[@href='greatescapesSearch.aspx']");

        [FindsBy(How = How.XPath, Using = "//h2[.='Great Escapes']")]
        public IWebElement greatEscapesImg;
        public By locatorforGreatEscapesImg = By.XPath("//h2[.='Great Escapes']");

        [FindsBy(How = How.XPath, Using = "//img[@src='images/btnSearchAgain.gif']")]
        public IWebElement greatEscapesSearchPg;
        public By locatorforGreatEscapesSearchPg = By.XPath("//img[@src='images/btnSearchAgain.gif']");

        [FindsBy(How = How.Id, Using = "great-escapes-pay")]
        public IWebElement greatEscapesPaymentPg;
        public By locatorforGreatEscapesPaymentPg = By.Id("great-escapes-pay");

        [FindsBy(How = How.Id, Using = "TxtBxGuesttoFirstName")]
        public IWebElement guestFirstName;
        public By locatorForGuestFirstName = By.Id("TxtBxGuesttoFirstName");

        [FindsBy(How = How.Id, Using = "TxtBxGuesttoLastName")]
        public IWebElement guestLastName;
        public By locatorForGuestLastName = By.Id("TxtBxGuesttoLastName");

        [FindsBy(How = How.XPath, Using = "//input[@id='TxtBxShiptoFirstName']")]
        public IWebElement billingInfoFirstName;
        public By locatorForBillingInfoFirstName = By.XPath("//input[@id='TxtBxShiptoFirstName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='TxtBxShiptoLastName']")]
        public IWebElement billingInfolastName;
        public By locatorForBillingInfoLastName = By.XPath("//input[@id='TxtBxShiptoLastName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtbxShiptoAddress1']")]
        public IWebElement streetAddress;
        public By locatorForStreetAddress = By.XPath("//input[@id='txtbxShiptoAddress1']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtbxShiptoCity']")]
        public IWebElement city;
        public By locatorForCity = By.XPath("//input[@id='txtbxShiptoCity']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlShiptoState']")]
        public IWebElement stateDropDownList;
        public By locatorForStateDropDownList = By.XPath("//select[@id='ddlShiptoState']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtbxShiptoZip']")]
        public IWebElement Zipcode;
        public By locatorForZipcode = By.XPath("//input[@id='txtbxShiptoZip']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlShipCountry']")]
        public IWebElement countryDropDownList;
        public By locatorForCountryDropDownList = By.XPath("//select[@id='ddlShipCountry']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtbxCcname']")]
        public IWebElement nameOfCardHolder;
        public By locatorforNameOfCardHolder = By.XPath("//input[@id='txtbxCcname']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCcinit']")]
        public IWebElement cardType;
        public By locatorforCardType = By.XPath("//select[@id='ddlCcinit']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtbxCcnum']")]
        public IWebElement cardNumber;
        public By locatorforCardNumber = By.XPath("//input[@id='txtbxCcnum']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCcmonth']")]
        public IWebElement expDate_Month;
        public By locatorforExpDate_Month = By.XPath("//select[@id='ddlCcmonth']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCcyear']")]
        public IWebElement expDate_Year;
        public By locatorforExpDate_Year = By.XPath("//select[@id='ddlCcyear']");

        [FindsBy(How = How.XPath, Using = "//input[@id='ddlCcp']")]
        public IWebElement totalPayment;
        public By locatorforTotalPayment = By.XPath("//input[@id='ddlCcp']");

        [FindsBy(How = How.XPath, Using = "//input[@id='AcceptTermsCheckBox']")]
        public IWebElement agreeToTermsCheckBox;
        public By locatorforAgreeToTermsCheckBox = By.XPath("//input[@id='AcceptTermsCheckBox']");

        [FindsBy(How = How.XPath, Using = "//input[@id='imgbtnSubmit']")]
        public IWebElement submitBtn;
        public By locatorforSubmitBtn = By.XPath("//input[@id='imgbtnSubmit']");

        [FindsBy(How = How.XPath, Using = "//input[@id='AcceptTermsCheckBox']")]
        public IWebElement sameAsMemberCheckBox;
        public By locatorforSameAsMemberCheckBox = By.XPath("//input[@id='AcceptTermsCheckBox']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='City:']")]
        public IWebElement memberInfo_CityLabel;
        public By locatorForMemberInfo_CityLabel = By.XPath("//strong[text()='City:']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Congratulations!']")]
        public IWebElement GreatEscapeConfirmationMsg;
        public By locatorForGreatEscapeConfirmationMsg = By.XPath("//strong[text()='Congratulations!']");
        

        public GreatEscapesReservationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public GreatEscapesReservationPage()
        {

        }
    }
}
