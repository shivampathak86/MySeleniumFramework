using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

using System.Collections.Generic;
using POM.Classes;
using OpenQA.Selenium.Support.UI;

namespace BlueGreenOwner
{
    public class MyLoanInformationPage: Utilities.Screenshot
    {

        public MyLoanInformationPage()
        {

        }

        public MyLoanInformationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'unable to locate your loan with the information provided')]")]
        public IWebElement ErrorMessage_MortgageSecurityPage;
        public By locatorforErrorMessage_MortgageSecurityPage = By.XPath("//p[contains(text(),'unable to locate your loan with the information provided')]");

        [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-menu inner']/li ")]
        public IWebElement Loancheck;
        public By LocatorforLoancheck = By.XPath("//ul[@class='dropdown-menu inner']/li ");

        [FindsBy(How = How.XPath, Using = "//*[text()='my loan information']")]
        public IWebElement MyLoanInformationMenu;
        public By LocatorforMyLoanInformationMenu = By.XPath("//*[text()='my loan information']");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'loan information')]")]
        public IWebElement MyLoanInformationPg;
        public By LocatorforMyLoanInformationPg = By.XPath("//h1[contains(text(),'loan information')]");
        
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Security')]")]
        public IWebElement MortgageSecurityPg;
        public By LocatorforMortgageSecurityPg = By.XPath("//h1[contains(text(),'Security')]");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtLastName']")]
        public IWebElement LastNameOnLoanTxtBox;
        public By LocatorforLastNameOnLoanTxtBox = By.XPath("//input[@id='txtLastName']");

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Confirm my mortgage loan')]")]
        public IWebElement ConfirmMyMortgageLoanBtn;
        public By LocatorforConfirmMyMortgageLoanBtn = By.XPath("//button[contains(text(),'Confirm my mortgage loan')]");

        [FindsBy(How = How.XPath, Using = "//div[@class='btn-group bootstrap-select dropdown-toggle']")]
        public IWebElement LoanDropDown;
        public By LocatorforLoanDropDown = By.XPath("//div[@class='btn-group bootstrap-select dropdown-toggle']");

        [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-menu inner']//span[@class='text']")]
        public IList<IWebElement> LoanDropDownValues { get; set; }
        public By LocatorforLoanDropDownValues = By.XPath("//ul[@class='dropdown-menu inner']//span[@class='text']");

        [FindsBy(How = How.XPath, Using = "//span[@class='filter-option pull-left']")]
        public IWebElement LoanNo;
        public By LocatorforLoanNo = By.XPath("//span[@class='filter-option pull-left']");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Maturity Date')]/../..")]
        public IWebElement MaturityDate_Row;
        public By LocatorforMaturityDate_Row = By.XPath("//strong[contains(text(),'Maturity Date')]/../..");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'update borrower information')]")]
        public IWebElement UpdateBorrowerInformationLink;
        public By LocatorforUpdateBorrowerInformationLink = By.XPath("//a[contains(text(),'update borrower information')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Information')]")]
        public IWebElement BorrowerInformationPage;
        public By LocatorforBorrowerInformationPage= By.XPath("//h1[contains(text(),'Information')]");


        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Update automatic payment')]")]
        public IWebElement UpdateAutomaticPaymentLink;
        public By LocatorforUpdateAutomaticPaymentLink = By.XPath("//a[contains(text(),'Update automatic payment')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Auto-pay')]")]
        public IWebElement ManageAutoPayPage;
        public By LocatorforManageAutoPayPage = By.XPath("//h1[contains(text(),'Auto-pay')]");

        [FindsBy(How = How.XPath, Using = "//strong[.='Original Loan Amount']/../..")]
        public IWebElement OriginalLoanAmount;
        public By LocatorforOriginalLoanAmount = By.XPath("//strong[.='Original Loan Amount']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[.='Principal Balance*']/../..")]
        public IWebElement PrincipalBalance;
        public By LocatorforPrincipalBalance = By.XPath("//strong[.='Principal Balance*']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[.='Interest Paid in 2017']/../..")]
        public IWebElement InterstPaidInYear;
        public By LocatorforInterstPaidInYear = By.XPath("//strong[.='Interest Paid in 2017']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[.='Due Date']/../..")]
        public IWebElement DueDate;
        public By LocatorforDueDate = By.XPath("//strong[.='Due Date']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[.='Total Payment']/../..")]
        public IWebElement TotalPayment;
        public By LocatorforTotalPayment = By.XPath("//strong[.='Total Payment']/../..");

        [FindsBy(How = How.XPath, Using = "//h2[@id='nextPaymentDetails']/..")]
        public IWebElement NextPaymentDetails_Table;
        public By LocatorforNextPaymentDetails_Table = By.XPath("//h2[@id='nextPaymentDetails']/..");

        [FindsBy(How = How.XPath, Using = "//h2[@id='loanDetails']/..")]
        public IWebElement LoanDetails_Table;
        public By LocatorforLoanDetails_Table = By.XPath("//h2[@id='loanDetails']/..");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'download tax document')][@class=' btn  btn-secondary btn-block hidden-xs']")]
        public IWebElement DownloadTaxDocumentBtn;
        public By LocatorforDownloadTaxDocumentBtn = By.XPath("//a[contains(text(),'download tax document')][@class=' btn  btn-secondary btn-block hidden-xs']");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'forms')]")]
        public IWebElement TaxFormsPage;
        public By LocatorforTaxFormsPage = By.XPath("//h1[contains(text(),'forms')]");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Request Payoff Quote')]")]
        public IWebElement RequestPayOffQuoteBtn;
        public By LocatorforRequestPayOffQuoteBtn = By.XPath("//a[contains(text(),'Request Payoff Quote')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'pay off quote')]")]
        public IWebElement RequestPayOffQuotePage;
        public By LocatorforRequestPayOffQuotePage = By.XPath("//h1[contains(text(),'pay off quote')]");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Make a Payment')]")]
        public IWebElement MakeAPaymentBtn_MyLoanInfoPage;
        public By LocatorforMakeAPaymentBtn_MyLoanInfoPage = By.XPath("//a[contains(text(),'Make a Payment')]");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'a payment')]")]
        public IWebElement MakeAPaymentPage_LoanPayment;
        public By LocatorforMakeAPaymentPage_LoanPayment = By.XPath("//h1[contains(text(),'a payment')]");

        [FindsBy(How = How.XPath, Using = "//button[@data-id='ddlLoan']")]
        public IWebElement LoanNo_RequestPayOffPage;
        public By LocatorforLoanNo_RequestPayOffPage = By.XPath("//button[@data-id='ddlLoan']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Loan number:']/..")]
        public IWebElement LoanNo_MakeAPaymentPage;
        public By LocatorforLoanNo_MakeAPaymentPage = By.XPath("//strong[text()='Loan number:']/..");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'transaction history')]")]
        public IWebElement TransactionHistoryLink;
        public By LocatorforTransactionHistoryLink = By.XPath("//a[contains(text(),'transaction history')]");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-Transaction-History-Grid-Item']")]
        public IWebElement TransactionHistoryTable;
        public By LocatorforTransactionHistoryTable = By.XPath("//div[@id='section-Transaction-History-Grid-Item']");
        
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'description')]/..")]
        public IWebElement Description;
        public By LocatorforDescription = By.XPath("//div[contains(text(),'description')]/..");

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Payment')]")]
        public IList<IWebElement> DescriptionColumn_Values{ get; set; }
        public By LocatorforDescriptionColumn_Values= By.XPath("//td[contains(text(),'Payment')]");

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'received')]/..")]
        public IWebElement Recieved;
        public By LocatorforRecieved = By.XPath("//div[contains(text(),'received')]/..");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='received']")]
        public IList< IWebElement> RecievedColumn_Values { get; set; }
        public By LocatorforRecievedColumn_Values = By.XPath("//td[@data-label='received']");

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'effective ')]/..")]
        public IWebElement Effective;
        public By LocaxtorforEffective = By.XPath("//div[contains(text(),'effective ')]/..");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='effective']")]
        public IList< IWebElement> EffectiveColumn_Values { get; set; }
        public By LocatorforEffectiveColumn_Values = By.XPath("//td[@data-label='effective']");

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'total amount ')]/..")]
        public IWebElement TotalAmount;
        public By LocatorforTotalAmount = By.XPath("//div[contains(text(),'total amount ')]/..");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='total amount']")]
        public IList<IWebElement> TotalAmountColumn_Values { get; set; }
        public By LocatorforTotalAmountColumn_Values = By.XPath("//td[@data-label='total amount']");
        
        [FindsBy(How = How.XPath, Using = "//a[@class='view-all']")]
        public IWebElement ViewAllLink;
        public By LocatorforViewAllLink = By.XPath("//a[@class='view-all']");

        [FindsBy(How = How.XPath, Using = "//a[@id='popclipper']")]
        public IWebElement LoanNoHyperLink_MakeAPaymentPage;
        public By LocatorforLoanNoHyperLink_MakeAPaymentPage = By.XPath("//a[@id='popclipper']");

        [FindsBy(How = How.XPath, Using = "//a[contains(@data-content,' Copied to clipboard! ')]")]
        public IWebElement LoanNoToolTip_MakeAPaymentPage;
        public By LocatorforLoanNoToolTip_MakeAPaymentPage = By.XPath("//a[contains(@data-content,' Copied to clipboard! ')]");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Make a loan payment')]")]
        public IWebElement MakeALoanPaymentBtn;
        public By LocatorforMakeALoanPaymentBtn = By.XPath("//a[contains(text(),'Make a loan payment')]");

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Assistance?')]/../..")]
        public IWebElement NeedAssistance_MakeALoanPayment;
        public By LocatorforNeedAssistance_MakeALoanPayment = By.XPath("//h3[contains(text(),'Assistance?')]/../..");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Powered')]/../../..")]
        public IWebElement PoweredBy_MakeALoanPayment;
        public By LocatorforPoweredBy_MakeALoanPayment = By.XPath("//strong[contains(text(),'Powered')]/../../..");

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'logo-western-union-speedpay')]")]
        public IWebElement WesternUnionLogo;
        public By LocatorforWesternUnionLogo = By.XPath("//img[contains(@src,'logo-western-union-speedpay')]");

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Go Back')]")]
        public IWebElement GoBackLink;
        public By LocatorforGoBackLink = By.XPath("//a[contains(text(),'Go Back')]");

        [FindsBy(How = How.XPath, Using = "//input[@id='sp_account_number']")]
        public IWebElement AccountNumberTxtBox_WesternUnionSpeedpayPage;
        public By LocatorforAccountNumberTxtBox_WesternUnionSpeedpayPage = By.XPath("//input[@id='sp_account_number']");

        [FindsBy(How = How.XPath, Using = "//input[@id='sp_account_number']/../../..")]
        public IWebElement AccountNumberField_WesternUnionSpeedpayPage;
        public By LocatorforAccountNumberField_WesternUnionSpeedpayPage = By.XPath("//input[@id='sp_account_number']/../../..");

        [FindsBy(How = How.XPath, Using = "//input[@id='sp_zip_code']")]
        public IWebElement ZipcodeTextBox_WesternUnionSpeedpayPage;
        public By LocatorforZipcodeTextBox_WesternUnionSpeedpayPage = By.XPath("//input[@id='sp_zip_code']");

        [FindsBy(How = How.XPath, Using = "//input[@id='sp_zip_code']/../../..")]
        public IWebElement ZipcodeField_WesternUnionSpeedpayPage;
        public By LocatorforZipcodeField_WesternUnionSpeedpayPage = By.XPath("//input[@id='sp_zip_code']/../../..");

        [FindsBy(How = How.XPath, Using = "//input[@name='SUBMIT']")]
        public IWebElement SubmitButton_WesternUnionSpeedpayPage;
        public By LocatorforSubmitButton_WesternUnionSpeedpayPage = By.XPath("//input[@name='SUBMIT']");


        public  List<String> GetLoanNumber(IWebDriver driver, int count)
        {
            GlobalObjects globalObj = new GlobalObjects(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            List<string> loanItems = new List<string>();

            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    ClickButton(myLoanObj.LoanDropDown, driver);
                    extentTest.Info("Loan number drop down is clicked");
                   


                }

                myLoanObj.LoanDropDownValues[i].Click();
                extentTest.Info(i + " index of loan dropdown is clicked");

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));


                //ClickButton(myLoanObj.LoanDropDown, driver);
                //extentTest.Info("Loan number drop down is clicked");


                String loan = myLoanObj.LoanNo.Text;
                extentTest.Info("Loan  displayed in dropdown  on clicking " + i + "Index is " + loan);

                loanItems.Add(loan);




            }
            return loanItems;


        }

        public  List<String> GetMatuaritytyDate(IWebDriver driver, int count)
        {
            GlobalObjects globalObj = new GlobalObjects(driver);
            MyLoanInformationPage myLoanObj = new MyLoanInformationPage(driver);
            List<string> Matuaritydate = new List<string>();

            for (int i = 0; i < count; i++)
            {


                

                ClickButton(myLoanObj.LoanDropDown, driver);

                myLoanObj.LoanDropDownValues[i].Click();
                extentTest.Info(i + " index of loan dropdown is clicked");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.shortLoadTime));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforHiddenLoading));



                String matuaritydate = myLoanObj.MaturityDate_Row.Text.Substring(14);
                extentTest.Info("MatuarityDate  displayed in dropdown  on clicking " + i + "Index is " + matuaritydate);

                Matuaritydate.Add(matuaritydate);




            }
            return Matuaritydate;


        }



    }
}
