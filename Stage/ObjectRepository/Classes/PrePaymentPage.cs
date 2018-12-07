using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
   public  class PrePaymentPage
    {
           [FindsBy(How = How.XPath, Using = ".//*[@id='gvOUTER_ctl02_TotalDue']")]
            public IWebElement prepaymentAmountTextBox;
            public By locatorforprepaymentAmountTextBox = By.XPath(".//*[@id='gvOUTER_ctl02_TotalDue']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='gvOUTER_ctl02_lblTotalDue']")]
            public IWebElement prepaymentAmountlabel;
            public By locatorforprepaymentAmountlabel = By.XPath(".//*[@id='gvOUTER_ctl02_lblTotalDue']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='gvOUTER_ctl02_lblPaymentMethod']")]
            public IWebElement paymentMethodLabel;
            public By locatorforpaymentMethodLabel = By.XPath(".//*[@id='gvOUTER_ctl02_lblPaymentMethod']");

            [FindsBy(How = How.XPath, Using = ".//label[text()='Credit/Debit Card']")]
            public IWebElement creditDebitRadioButton;
            public By locatorforcreditDebitRadioButton = By.XPath(".//label[text()='Credit/Debit Card']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='gvOUTER_ctl02_submitPayment']")]
            public IWebElement PayNowButton;
            public By locatorforPayNowButton = By.XPath(".//*[@id='gvOUTER_ctl02_submitPayment']");

            //credt card info page

            [FindsBy(How = How.XPath, Using = ".//*[@id='txtCCName']")]
            public IWebElement nameOnCard;
            public By locatorfornameOnCard = By.XPath(".//*[@id='gvOUTER_ctl02_submitPayment']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='cboCCType']")]
            public IWebElement cardType;
            public By locatorforcardType = By.XPath(".//*[@id='cboCCType']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='txtCCNum']")]
            public IWebElement cardNum;
            public By locatorforcardNum = By.XPath(".//*[@id='txtCCNum']");

            [FindsBy(How = How.Id, Using = "ddlExpMonth")]
            public IWebElement expMonth;
            public By locatorforexpMonth = By.Id("ddlExpMonth");


            [FindsBy(How = How.Id, Using = "ddlExpYear")]
            public IWebElement expYear;
            public By locatorforexpYear = By.Id("ddlExpYear");

            [FindsBy(How = How.XPath, Using = ".//*[@id='txtCCZipcode']")]
            public IWebElement zipCode;
            public By locatorforzipcode = By.XPath(".//*[@id='txtCCZipcode']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='lblTotal']")]
            public IWebElement labelTotal;
            public By locatorforlabelTotal = By.XPath(".//*[@id='lblTotal']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='chkTermsSavings']")]
            public IWebElement termsCheckbox;
            public By locatorfortermsCheckbox = By.XPath(".//*[@id='chkTermsSavings']");

            [FindsBy(How = How.XPath, Using = ".//*[@id='imgSubmit']")]
            public IWebElement submitPaymentButton;
            public By locatorforsubmitPaymentButton = By.XPath(".//*[@id='imgSubmit']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='lblAmount']")]
            public IWebElement ConfirmationAmount;
            public By locatorforConfirmationAmount = By.XPath(".//*[@id='lblAmount']");


            [FindsBy(How = How.XPath, Using = ".//*[@id='lblConfirmation']")]
            public IWebElement ConfirmationNumber;
            public By locatorforConfirmationNumber = By.XPath(".//*[@id='lblConfirmation']");


            public string prePaymentPage = "Make A Prepayment Page";
            public string ValNameOnCard = null;
            public string ValConfirmationNumber = null;
            public string ValConfirmationAmount = null;

        }
    }

