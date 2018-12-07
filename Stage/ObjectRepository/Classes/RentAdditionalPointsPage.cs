using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class RentAdditionalPointsPage
    {

        [FindsBy(How = How.XPath, Using = "//a[.='traveler plus']")]
        public IWebElement travelerPlusLink;
        public By locatorfortravelerPlusLink = By.XPath("//a[.='traveler plus']");

        [FindsBy(How = How.XPath, Using = "//a[.='Rent Additional Points']")]
        public IWebElement rentAdditionalPointsLink;
        public By locatorforrentAdditionalPointsLink = By.XPath("//a[.='Rent Additional Points']");

        [FindsBy(How = How.Id, Using = "ddlPtsValues")]
        public IWebElement pointsToRentDropDown;
        public By locatorforPointsToRentDropDown = By.Id("ddlPtsValues");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxFirstName']")]
        public IWebElement firstNameTxtField;
        public By locatorForFirstNameTxtField = By.XPath("//input[@id='txtBxFirstName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxLastName']")]
        public IWebElement lastNameTxtField;
        public By locatorForLastNameTxtField = By.XPath("//input[@id='txtBxLastName']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxCity']")]
        public IWebElement cityTxtField;
        public By locatorForCityTxtField = By.XPath("//input[@id='txtBxCity']");

        [FindsBy(How = How.XPath, Using = "//select[@id='ddlState']")]
        public IWebElement stateDropDownList;
        public By locatorForStateDropDownList = By.XPath("//select[@id='ddlState']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxZip']")]
        public IWebElement ZipcodeTxtField;
        public By locatorForZipcodeTxtField = By.XPath("//input[@id='txtBxZip']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxPhone']")]
        public IWebElement phoneTxtField;
        public By locatorForPhoneTxtField = By.XPath("//input[@id='txtBxPhone']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxEmail']")]
        public IWebElement emailTxtField;
        public By locatorForEmailTxtField = By.XPath("//input[@id='txtBxEmail']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxBVC']")]
        public IWebElement ownerTxtField;
        public By locatorForOwnerTxtField = By.XPath("//input[@id='txtBxBVC']");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtBxPayment']")]
        public IWebElement paymentTxtField;
        public By locatorForPaymentTxtField = By.XPath("//input[@id='txtBxPayment']");

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

        [FindsBy(How = How.XPath, Using = "//input[@id='btnCCsubmit']")]
        public IWebElement SumitBtn;
        public By locatorforSumitBtn = By.XPath("//input[@id='btnCCsubmit']");

        [FindsBy(How = How.XPath, Using = "//p[text()='Please review and confirm the information below. Click ']")]
        public IWebElement RentAdditionalWarningMessage;
        public By locatorforRentAdditionalWarningMessage = By.XPath("//p[text()='Please review and confirm the information below. Click ']");

        [FindsBy(How = How.XPath, Using = "//input[@id='btnSubmit']")]
        public IWebElement SumitBtnInConfirmationPg;
        public By locatorforSumitBtnInConfirmationPg = By.XPath("//input[@id='btnSubmit']");

        [FindsBy(How = How.XPath, Using = "//input[@id='btnCancel']")]
        public IWebElement EditBtn;
        public By locatorforEditBtn = By.XPath("//input[@id='btnCancel']");

        [FindsBy(How = How.XPath, Using = "//font[.='Your credit card has been successfully charged, but there was a problem adding points to your account; please, contact customer service at 800.459.1597 ']")]
        public IWebElement AlertMessage;
        public By locatorforAlertMessage = By.XPath("//font[.='Your credit card has been successfully charged, but there was a problem adding points to your account; please, contact customer service at 800.459.1597 ']");

        [FindsBy(How = How.XPath, Using = "//strong[.='traveler']")]
        public IWebElement travelerPlus;
        public By locatorTravelerPlus = By.XPath("//strong[.='traveler']");

        [FindsBy(How = How.XPath, Using = "//img[@src='images/rent-additional-header.gif']")]
        public IWebElement RentAdditionalPointsImg;
        public By locatorRentAdditionalPointsImg = By.XPath("//img[@src='images/rent-additional-header.gif']");

        [FindsBy(How = How.XPath, Using = "//p[text()='You have successfully rented ']")]
        public IWebElement SuccesfulMessage;
        public By locatorForSuccessfullMessage = By.XPath("//p[text()='You have successfully rented ']");

        [FindsBy(How = How.XPath, Using = "//p[text()='You have successfully rented ']")]
        public IWebElement RentAdditionalPointsPg;
        public By locatorForRentAdditionalPointsImg = By.XPath("//p[text()='You have successfully rented ']");




        public RentAdditionalPointsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public RentAdditionalPointsPage()
        {

        }

    }
}