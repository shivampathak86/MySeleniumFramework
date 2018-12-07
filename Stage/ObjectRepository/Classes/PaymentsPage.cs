using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class PaymentsPage
    {

        public PaymentsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public PaymentsPage()
        {

        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='form1']//h3[text()='Your Maintenance Fee Dashboard']")]
        public IWebElement HeadingMaintenanceFeeDashBoard;
        public By locatorforHeadingMaintenanceFeeDashBoard = By.XPath(".//*[@id='form1']//h3[text()='Your Maintenance Fee Dashboard']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='form1']//span[text()='Payment Balance']")]
        public IWebElement PaymentBalanceText;
        public By locatorforPaymenBalanceText = By.XPath(".//*[@id='form1']//span[text()='Payment Balance']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='form1']//span[text()='Payment Balance']/strong")]
        public IWebElement PaymentBalance;
        public By locatorforPaymentBalance = By.XPath(".//*[@id='form1']//h3[text()='Your Maintenance Fee Dashboard']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']")]
        public IWebElement selectAYearDropDown;
        public By locatorforselectAYearDropDown = By.XPath(".//*[@id='dplFeeYears']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[1]")]
        public IWebElement ddlbOption0;
        public By locatorforddlbOption0 = By.XPath(".//*[@id='dplFeeYears']/option[1]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[2]")]
        public IWebElement ddlbOption1;
        public By locatorforddlbOption1 = By.XPath(".//*[@id='dplFeeYears']/option[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[3]")]
        public IWebElement ddlbOption2;
        public By locatorforddlbOption2 = By.XPath(".//*[@id='dplFeeYears']/option[3]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[4]")]
        public IWebElement ddlbOption3;
        public By locatorforddlbOption3 = By.XPath(".//*[@id='dplFeeYears']/option[4]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[5]")]
        public IWebElement ddlbOption4;
        public By locatorforddlbOption4 = By.XPath(".//*[@id='dplFeeYears']/option[5]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='dplFeeYears']/option[6]")]
        public IWebElement ddlbOption5;
        public By locatorforddlbOption5 = By.XPath(".//*[@id='dplFeeYears']/option[6]");

        [FindsBy(How = How.XPath, Using = "//strong[.='No Statements Available']")]
        public IWebElement noStatementsAvailable;
        public By locatorfornoStatementsAvailable = By.XPath("//strong[.='No Statements Available']");

        //Elements declared by Fathima
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'We apologize for the inconveience')]")]
        public IWebElement weApologiseMsg;
        public By locatorforweApologiseMsg = By.XPath("//span[contains(text(),'We apologize for the inconveience')] ");

        [FindsBy(How = How.XPath, Using = "//*[text()='View Transactions']")]
        public IWebElement viewTransactionBtn ;
        public By locatorforViewTransactionBtn = By.XPath("//*[text()='View Transactions']");

        [FindsBy(How =How.XPath,Using = "//*[text()='View Transactions']")]
        public IList<IWebElement> viewTransactionsBtnList { get; set; }
        public By locatorforViewTransactionsBtnList = By.XPath("//*[text()='View Transactions']");

        [FindsBy(How = How.XPath, Using = "//h1[text()=' Maintenance Fees Transactions']")]
        public IWebElement myMaintenaceFeeTransactionPage;
        public By locatorforMyMaintenaceFeeTransactionPage = By.XPath("//h1[text()=' Maintenance Fees Transactions']");

        [FindsBy(How = How.XPath, Using = "//li[@role='presentation']//a[contains(text(),'Statement History')]")]
        public IWebElement StatementHistoryLink;
        public By locatorforStatementHistoryLink = By.XPath("//li[@role='presentation']//a[contains(text(),'Statement History')]");

        [FindsBy(How = How.XPath, Using = "//*[text()='Make a Payment']")]
        public IWebElement makeAPaymentBtn;
        public By locatorforMakeAPaymentBtn = By.XPath("//*[text()='Make a Payment']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Make a Payment']")]
        public IWebElement makeAPaymentBtnForISowner;
        public By locatorforMakeAPaymentBtnForISowner = By.XPath("//a[text()='Make a Payment']");

        [FindsBy(How = How.XPath, Using = "//*[text()='update information later']")]
        public IWebElement updateInforLaterBtn_ISowner;
        public By locatorforUpdateInforLaterBtn_ISowner = By.XPath("//*[text()='update information later']");

        [FindsBy(How = How.XPath, Using = "//*[text()='update information later']")]
        public IWebElement updateInforLaterBtn_IDowner;
        public By locatorforUpdateInforLaterBtn_IDowner = By.XPath("//*[text()='update information later']");
        
        [FindsBy(How = How.XPath, Using = "//strong[text()='installment']/..")]
        public IWebElement InstallmentPlanPage;
        public By locatorforInstallmentPlanPage = By.XPath("//strong[text()='installment']/..");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'a Payment')]")]
        public IWebElement makeAPaymentPage;
        public By locatorforMakeAPaymentPage = By.XPath("//h1[contains(text(),'a Payment')]");
        
        [FindsBy(How = How.Id, Using = "btnPayment")]
        public IWebElement makeAPaymentBtn_MaintenaceFeesAndClubDues;
        public By locatorformakeAPaymentBtn_MaintenaceFeesAndClubDues = By.Id("btnPayment");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-Installment-Plan-Grid']")]
        public IWebElement InstallmentGrid;
        public By locatorforInstallmentGrid = By.XPath("//div[@id='section-Installment-Plan-Grid']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='Total Payment Authorized*']")]
        public IWebElement TotalAmountUnderSummary;
        public By locatorforTotalAmountUnderSummary = By.XPath("//td[@data-label='Total Payment Authorized*']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='Amount']")]
        public IList<IWebElement> AmountInGrid { get; set; }
        public By locatorforAmountInGrid = By.XPath("//td[@data-label='Amount']");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']")]
        public IWebElement alertMsgForISowner;
        public By locatorforalertMsgForISowner = By.XPath("//div[@class='col-sm-9 ']");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']//strong[1]")]
        public IWebElement DueDateForISowner;
        public By locatorforDueDateForISowner = By.XPath("//div[@class='col-sm-9 ']//strong[1]");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']//strong[2]")]
        public IWebElement SubmitByDateForISowner;
        public By locatorforSubmitByDateForISowner = By.XPath("//div[@class='col-sm-9 ']//strong[2]");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']//strong[1]")]
        public IWebElement DueDateForIDowner;
        public By locatorforDueDateForIDowner = By.XPath("//div[@class='col-sm-9 ']//strong[1]");


        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']")]
        public IWebElement alertMsgForIDowner;
        public By locatorforalertMsgForIDowner = By.XPath("//div[@class='col-sm-9 ']");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-9 ']")]
        public IWebElement alertMsgForIPowner;
        public By locatorforalertMsgForIPowner = By.XPath("//div[@class='col-sm-9 ']");

        [FindsBy(How = How.XPath, Using = "//a[.='View Summary']")]
        public IWebElement viewSummaryBtn;
        public By locatorforViewSummaryBtn = By.XPath("//a[.='View Summary']");

        public string pageName = "Maintenance Fee History Page";

        [FindsBy(How = How.XPath, Using = "//h1[text()=' is past due']")]
        public IWebElement pastDueMessage;
        public By locatorforPastDueMessage = By.XPath("//h1[text()=' is past due']");

        [FindsBy(How =How.XPath,Using = "//a[@aria-controls='#Current_Year_Transactions']")]
         public IWebElement CurrentYear;
        public By locatorforCurrentYear = By.XPath("//a[@aria-controls='#Current_Year_Transactions']");

        [FindsBy(How = How.XPath, Using = "//a[@aria-controls='#Last_Year_Transactions']")]
        public IWebElement LastYear;
        public By locatorforLastYear = By.XPath("//a[@aria-controls='#Last_Year_Transactions']");

        [FindsBy(How = How.XPath, Using = "//a[@aria-controls='#Last_Second_Year_Transactions']")]
        public IWebElement LastSecondYear;
        public By locatorforLastSecondYear = By.XPath("//a[@aria-controls='#Last_Second_Year_Transactions']");

        [FindsBy(How = How.XPath, Using = "//a[@aria-controls='#Last_Third_Year_Transactions']")]
        public IWebElement LastThirdYear;
        public By locatorforLastThirdYear = By.XPath("//a[@aria-controls='#Last_Third_Year_Transactions']");

        [FindsBy(How = How.XPath, Using = "//div[@class='col-xs-6']//h2")]
        public IWebElement CurrentYearHeader;
        public By locatorforCurrentYearHeader = By.XPath("//div[@class='col-xs-6']//h2");

        [FindsBy(How = How.Id, Using = "section-MaintenanceHistoryByYear-details")]
        public IWebElement CurrentYearTableDetails;
        public By locatorforCurrentYearTableDetails = By.Id("section-MaintenanceHistoryByYear-details");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-MaintenanceHistoryByYear-details']//td[@class='  c0']//strong//strong/..")]
        public IList<IWebElement> CurrentYearInTable { get; set; }
        public By locatorforCurrentYearInTable = By.XPath("//div[@id='section-MaintenanceHistoryByYear-details']//td[@class='  c0']//strong//strong/..");

        [FindsBy(How = How.XPath, Using = "//h2[text()='2017 transaction history']")]
        public IWebElement LastYearHeader;
        public By locatorforLastYearHeader = By.XPath("//h2[text()='2017 transaction history']");

        [FindsBy(How = How.Id, Using = "section-MaintenanceHistoryByYear-1-details")]
        public IWebElement LastYearTableDetails;
        public By locatorforLastYearTableDetails = By.Id("section-MaintenanceHistoryByYear-1-details");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-MaintenanceHistoryByYear-1-details']//td[@class='  c0']//strong//strong/..")]
        public IList<IWebElement> LastYearInTable { get; set; }
        public By locatorforLastYearInTable = By.XPath("//div[@id='section-MaintenanceHistoryByYear-1-details']//td[@class='  c0']//strong//strong/..");

        [FindsBy(How = How.XPath, Using = "//h2[text()='2016 transaction history']")]
        public IWebElement LastSecondHeader;
        public By locatorforLastSecondYearHeader = By.XPath("//h2[text()='2016 transaction history']");

        [FindsBy(How = How.Id, Using = "section-MaintenanceHistoryByYear-2-details")]
        public IWebElement LastSecondYearTableDetails;
        public By locatorforLastSecondYearTableDetails = By.Id("section-MaintenanceHistoryByYear-2-details");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-MaintenanceHistoryByYear-2-details']//td[@class='  c0']//strong//strong/..")]
        public IList<IWebElement> LastSecondYearInTable { get; set; }
        public By locatorforLastSecondYearInTable = By.XPath("//div[@id='section-MaintenanceHistoryByYear-2-details']//td[@class='  c0']//strong//strong/..");

        [FindsBy(How = How.XPath, Using = "//h2[text()='2015 transaction history']")]
        public IWebElement LastThirdHeader;
        public By locatorforLastThirdYearHeader = By.XPath("//h2[text()='2015 transaction history']");

        [FindsBy(How = How.Id, Using = "section-MaintenanceHistoryByYear-3-details")]
        public IWebElement LastThirdYearTableDetails;
        public By locatorforLastThirdYearTableDetails = By.Id("section-MaintenanceHistoryByYear-3-details");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-MaintenanceHistoryByYear-3-details']//td[@class='  c0']//strong//strong/..")]
        public IList<IWebElement> LastThirdYearInTable { get; set; }
        public By locatorforLastThirdYearInTable = By.XPath("//div[@id='section-MaintenanceHistoryByYear-3-details']//td[@class='  c0']//strong//strong/..");

        [FindsBy(How = How.XPath, Using = "//strong[text()='No Data Available.']")]
        public IWebElement NoDataAvailable;
        public By locatorforNoDataAvailable = By.XPath("//strong[text()='No Data Available.']");

        [FindsBy(How = How.XPath, Using = "//div[@id='Current_Year_Transactions']//tbody//tr//a[text()='View Breakdown']")]
        public IList<IWebElement> ViewBreakdownButton_CurrentYearTable { get; set; }
        public By locatorforViewBreakdownButton_CurrentYearTable = By.XPath("//div[@id='Current_Year_Transactions']//tbody//tr//a[text()='View Breakdown']");

        [FindsBy(How = How.XPath, Using = "//div[@id='Last_Year_Transactions']//tbody//tr//a[text()='View Breakdown']")]
        public IList<IWebElement> ViewBreakdownButton_LastYearTable { get; set; }
        public By locatorforViewBreakdownButton_LastYearTable = By.XPath("//div[@id='Last_Year_Transactions']//tbody//tr//a[text()='View Breakdown']");

        [FindsBy(How = How.XPath, Using = "//div[@id='Last_Second_Year_Transactions']//tbody//tr//a[text()='View Breakdown']")]
        public IList<IWebElement> ViewBreakdownButton_LastSecondYearTable { get; set; }
        public By locatorforViewBreakdownButton_LastSecondYearTable = By.XPath("//div[@id='Last_Second_Year_Transactions']//tbody//tr//a[text()='View Breakdown']");

        [FindsBy(How = How.XPath, Using = "//div[@id='Last_Third_Year_Transactions']//tbody//tr//a[text()='View Breakdown']")]
        public IList<IWebElement> ViewBreakdownButton_LastThirdYearTable { get; set; }
        public By locatorforViewBreakdownButton_LastThirdYearTable = By.XPath("//div[@id='Last_Third_Year_Transactions']//tbody//tr//a[text()='View Breakdown']");

        [FindsBy(How = How.XPath, Using = "//td//strong")]
        public IList<IWebElement> AssociationNameList { get; set; }
        public By locatorforAssociationNameList = By.XPath("//td//strong");

        [FindsBy(How = How.XPath, Using = "//span[@class='visible-xs-block visible-sm-block visible-md-inline-block visible-lg-inline-block']")]
        public IWebElement AssociationNameOnMaintenanceFeesTransactionPage;
        public By locatorforAssociationNameOnMaintenanceFeesTransactionPage = By.XPath("//span[@class='visible-xs-block visible-sm-block visible-md-inline-block visible-lg-inline-block']");

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'maintenance fee breakdown')]")]
        public IWebElement MaintenanceFeeBreakdown;
        public By locatorforMaintenanceFeeBreakdown = By.XPath("//h1[contains(text(),'maintenance fee breakdown')]");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-Statement-History-Grid']")]
        public IWebElement statementHistoryTable;
        public By locatorForstatementHistoryTable = By.XPath("//div[@id='section-Statement-History-Grid']");

        [FindsBy(How = How.XPath, Using = "//div[@id='section-Statement-History-Grid']//tbody//strong")]
        public IList<IWebElement> YearInStatementHistoryTable { get; set; }
        public By locatorForYearInStatementHistoryTable = By.XPath("//div[@id='section-Statement-History-Grid']//tbody//strong");

        [FindsBy(How = How.XPath, Using = "//a[@ class='getasPdf  btn btn-sm btn-block btn  btn-secondary']")]
        public IList<IWebElement> DownloadStatementBtnInTable { get; set; }
        public By locatorForDownloadStatementBtnInTable = By.XPath("//a[@ class='getasPdf  btn btn-sm btn-block btn  btn-secondary']");

        [FindsBy(How = How.XPath, Using = "//input[@value='Checking_Account']")]
        public IWebElement CheckingAccountRadioBtn;
        public By locatorForCheckingAccountRadioBtn = By.XPath("//input[@value='Checking_Account']");

        [FindsBy(How = How.XPath, Using = "//label[@class='control-label']//input[@value='Checking_Account']/../..")]
        public IWebElement CheckingAccountField;
        public By locatorForCheckingAccountField = By.XPath("//label[@class='control-label']//input[@value='Checking_Account']/../..");

        [FindsBy(How = How.XPath, Using = "//input[@value='Savings_Account']")]
        public IWebElement SavingsAccountRadioBtn;
        public By locatorForSavingsAccountRadioBtn = By.XPath("//input[@value='Savings_Account']");

        [FindsBy(How = How.XPath, Using = "//label[@class='control-label']//input[@value='Savings_Account']/../..")]
        public IWebElement SavingsAccountField;
        public By locatorForSavingsAccountField = By.XPath("//label[@class='control-label']//input[@value='Savings_Account']/../..");

        [FindsBy(How = How.XPath, Using = "//input[@value='Debit_Or_Credit_Card']/../..")]
        public IWebElement DebitOrCreditCardField;
        public By locatorForDebitOrCreditCardField = By.XPath("//input[@value='Debit_Or_Credit_Card']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[.='Payment Methods:']")]
        public IWebElement PaymentMethodsLabel;
        public By locatorForPaymentMethodsLabel = By.XPath("//strong[.='Payment Methods:']");

        [FindsBy(How = How.XPath, Using = "//input[@value='Debit_Or_Credit_Card']")]
        public IWebElement DebitOrCreditCardRadioBtn;
        public By locatorForDebitOrCreditCardRadioBtn = By.XPath("//input[@value='Debit_Or_Credit_Card']");

        [FindsBy(How = How.XPath, Using = "//input[@value='Mail']")]
        public IWebElement MailRadioBtn;
        public By locatorForMailRadioBtn = By.XPath("//input[@value='Mail']");

        [FindsBy(How = How.XPath, Using = "//input[@value='Installment_Plan']")]
        public IWebElement InstallmentPlanRadioBtn;
        public By locatorForInstallmentPlanRadioBtn = By.XPath("//input[@value='Installment_Plan']");

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]")]
        public IWebElement ACHpaymentConfirmationMsg;
        public By locatorForACHpaymentConfirmationMsg = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]");

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]")]
        public IWebElement PaymentConfirmationMsg_CreditOrDebitCard;
        public By locatorForPaymentConfirmationMsg_CreditOrDebitCard = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]");
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]")]
        public IWebElement PaymentConfirmationMsg_InstallmentPlan;
        public By locatorForPaymentConfirmationMsg_InstallmentPlan = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]");
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]")]
        public IWebElement Amount_ACHpaymentConfirmationMsg;
        public By locatorForAmount_ACHpaymentConfirmationMsg = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]");
       
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]//strong[1]")]
        public IWebElement Amount_PaymentConfirmationMsg_DebitOrCreditCard;
        public By locatorForAmount_PaymentConfirmationMsg_DebitOrCreditCard = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]//strong[1]");

        [FindsBy(How = How.XPath, Using = " //strong[contains(text(),'$')]")]
        public IWebElement Amount_PaymentConfirmationMsg_InstallmentPlan;
        public By locatorForAmount_PaymentConfirmationMsg_InstallmentPlan = By.XPath(" //strong[contains(text(),'$')]");

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Thank you for your payment in the amount of')]//strong[2]")]
        public IWebElement AuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard;
        public By locatorForAuthorisationNo_PaymentConfirmationMsg_DebitOrCreditCard = By.XPath("//p[contains(text(),'Thank you for your payment in the amount of')]//strong[2]");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'ET')]")]
        public IWebElement AuthorisationNo_ACHpayment;
        public By locatorForAuthorisationNo_ACHpayment = By.XPath("//strong[contains(text(),'ET')]");

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'ET')]")]
        public IWebElement AuthorisationNo_InstallmentPlan;
        public By locatorForAuthorisationNo_InstallmentPlan = By.XPath("//strong[contains(text(),'ET')]");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Association:']")]
        public IWebElement AssociationLabel_makeApaymentPg;
        public By locatorForAssociationLabel_makeApaymentPg = By.XPath("//strong[text()='Association:']");

        [FindsBy(How = How.XPath, Using = "//input[@id='association']")]
        public IWebElement AssociationName_makeApaymentPg;
        public By locatorForAssociationName_makeApaymentPg = By.XPath("//input[@id='association']");

        [FindsBy(How = How.XPath, Using = "//*[text()='View Payment Details']")]
        public IWebElement ViewPaymentDetailsBtn;
        public By locatorForViewPaymentDetailsBtn = By.XPath("//*[text()='View Payment Details']");

        [FindsBy(How = How.Id, Using = "account_UserPayInfoList_0__IsARDAAmount")]
        public IWebElement ArdaContributionCheckBox;
        public By locatorForArdaContributionCheckBox = By.Id("account_UserPayInfoList_0__IsARDAAmount");

        [FindsBy(How = How.XPath, Using = "//input[@data-val-required='The IsARDAAmount field is required.']")]
        public IList<IWebElement> ArdaContributionCheckBox_MultipleAccount { get; set; }
        public By locatorForArdaContributionCheckBox_MultipleAccount = By.XPath("//input[@data-val-required='The IsARDAAmount field is required.']");

        [FindsBy(How = How.Id, Using = "account_UserPayInfoList_0__PaymentAmount")]
        public IWebElement AmountDueTextField;
        public By locatorForAmountDueTextField = By.Id("account_UserPayInfoList_0__PaymentAmount");

        [FindsBy(How = How.XPath, Using = "//td//input[@data-val-required='The PaymentAmount field is required.']")]
        public IList<IWebElement> AmountDueTextField_MultipleAccount{ get; set; }
        public By locatorForAmountDueTextField_MultipleAccount = By.XPath("//td//input[@data-val-required='The PaymentAmount field is required.']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='past due']")]
        public IList<IWebElement> PastDue_MultipleAccount { get; set; }
        public By locatorForPastDue_MultipleAccount = By.XPath("//td[@data-label='past due']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='balance due']")]
        public IList<IWebElement> BalanceDue_MultipleAccount { get; set; }
        public By locatorForBalanceDue_MultipleAccount = By.XPath("//td[@data-label='balance due']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='past due']")]
        public IWebElement PastDue_SingleAccount;
        public By locatorForPastDue_SingleAccount = By.XPath("//td[@data-label='past due']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='balance due']")]
        public IWebElement BalanceDue_SingleAccount;
        public By locatorForBalanceDue_SingleAccount = By.XPath("//td[@data-label='balance due']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Amount Due ']")]
        public IWebElement AmountDue_Bottom;
        public By locatorForAmountDue_Bottom= By.XPath("//strong[text()='Amount Due ']");

        [FindsBy(How = How.XPath, Using = "//*[text()='All']")]
        public IWebElement AllLink;
        public By locatorForAllLink = By.XPath("//*[text()='All']");

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement MakeAPaymentBtn_MyMaintenanceFeesDetailsPage;
        public By locatorForMakeAPaymentBtn_MyMaintenanceFeesDetailsPaged = By.Id("btnSubmit");

        [FindsBy(How = How.Id, Using = "routingNumber_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}")]
        public IWebElement RoutingOrTransitNoTxtBox_Checkingaccount;
        public By locatorForRoutingOrTransitNoTxtBox_Checkingaccount = By.Id("routingNumber_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}");

        [FindsBy(How = How.XPath, Using = "//span[@id='routingNumber_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']")]
        public IWebElement RoutingOrTransitNumberError_Checkingaccount;
        public By locatorForRoutingOrTransitNumberError_Checkingaccount = By.XPath("//span[@id='routingNumber_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']");

        [FindsBy(How = How.XPath, Using = "//span[@id='routingNumber_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']")]
        public IWebElement RoutingOrTransitNumberError_Savingaccount;
        public By locatorForRoutingOrTransitNumberError_Savingaccount = By.XPath("//span[@id='routingNumber_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']");

        [FindsBy(How = How.XPath, Using = "//span[@id='bankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']")]
        public IWebElement BankAccountNumberError_Checkingaccount;
        public By locatorForBankAccountNumberError_Checkingaccount = By.XPath("//span[@id='bankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']");

        [FindsBy(How = How.XPath, Using = "//span[@id='bankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']")]
        public IWebElement BankAccountNumberError_Savingaccount;
        public By locatorForBankAccountNumberError_Savingaccount = By.XPath("//span[@id='bankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']");

        [FindsBy(How = How.XPath, Using = "//span[@id='rebankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']")]
        public IWebElement ReEnterBankAccountNumberError_Checkingaccount;
        public By locatorForReEnterBankAccountNumberError_Checkingaccount = By.XPath("//span[@id='rebankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}-error']");

        [FindsBy(How = How.XPath, Using = "//span[@id='rebankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']")]
        public IWebElement ReEnterBankAccountNumberError_Savingaccount;
        public By locatorForReEnterBankAccountNumberError_Savingaccount = By.XPath("//span[@id='rebankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}-error']");
        
        [FindsBy(How = How.Id, Using = "routingNumber_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement RoutingOrTransitNoTxtBox_Savingsaccount;
        public By locatorForRoutingOrTransitNoTxtBox_Savingsaccount = By.Id("routingNumber_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.Id, Using = "rebankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}")]
        public IWebElement ReEnterBankAccountNoTxtBox_Checkingaccount;
        public By locatorForReEnterBankAccountNoTxtBox_Checkingaccount = By.Id("rebankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}");

        [FindsBy(How = How.Id, Using = "rebankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement ReEnterBankAccountNoTxtBox__Savingsaccount;
        public By locatorForReEnterBankAccountNoTxtBox__Savingsaccount = By.Id("rebankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.Id, Using = "term_condition_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}")]
        public IWebElement AgreeToTermsAndConditionsCheckBox_Checkingaccount;
        public By locatorForAgreeToTermsAndConditionsCheckBox_Checkingaccount = By.Id("term_condition_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}");

        [FindsBy(How = How.Id, Using = "term_condition_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement AgreeToTermsAndConditionsCheckBox_Savingsaccount;
        public By locatorForAgreeToTermsAndConditionsCheckBox_Savingsaccount = By.Id("term_condition_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtNameOnTheCard']")]
        public IWebElement CardName_MakeAPaymentPage;
        public By locatorForCardName_MakeAPaymentPage = By.XPath("//input[@name='txtNameOnTheCard']");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtNameOnTheCard']/..")]
        public IWebElement CardNameField_DebitOrCreditCard;
        public By locatorForCardNameField_DebitOrCreditCard = By.XPath("//input[@name='txtNameOnTheCard']/..");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtCardNumber']")]
        public IWebElement CardNumber_MakeAPaymentPage;
        public By locatorForCardNumber_MakeAPaymentPage = By.XPath("//input[@name='txtCardNumber']");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtCardNumber']/../../../..")]
        public IWebElement CardNumberField_DebitOrCreditCard;
        public By locatorForCardNumberField_DebitOrCreditCard = By.XPath("//input[@name='txtCardNumber']/../../../..");

        [FindsBy(How = How.XPath, Using = "//i[@class='fa fa-fw fa-lg fa-credit-card-alt']")]
        public IWebElement Card_Image;
        public By locatorForCard_Image = By.XPath("//i[@class='fa fa-fw fa-lg fa-credit-card-alt']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*Name is a required field']")]
        public IWebElement CardNameError_DebitOrCreditCard;
        public By locatorForCardNameError_DebitOrCreditCard = By.XPath("//span[text()='*Name is a required field']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*Credit card number is a required field']")]
        public IWebElement CardNumberError_DebitOrCreditCard;
        public By locatorForCardNumberError_DebitOrCreditCard = By.XPath("//span[text()='*Credit card number is a required field']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*CVV is a required field']")]
        public IWebElement CVVError_DebitOrCreditCard;
        public By locatorForCVVError_DebitOrCreditCard = By.XPath("//span[text()='*CVV is a required field']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*Credit card expiration is a required field']")]
        public IWebElement ExpirationDateError_DebitOrCreditCard;
        public By locatorForExpirationDateError_DebitOrCreditCard = By.XPath("//span[text()='*Credit card expiration is a required field']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*Zip code is a required field']")]
        public IWebElement ZipcodeError_DebitOrCreditCard;
        public By locatorForZipcodeError_DebitOrCreditCard = By.XPath("//span[text()='*Zip code is a required field']");
        

        [FindsBy(How = How.XPath, Using = "//input[@name='txtCVV']")]
        public IWebElement CVV_MakeAPaymentPage;
        public By locatorForCVV_MakeAPaymentPage = By.XPath("//input[@name='txtCVV']");
        
        [FindsBy(How = How.XPath, Using = "//input[@name='txtCVV']/../../..")]
        public IWebElement CVVfield_DebitOrCreditCard;
        public By locatorForCVVfield_DebitOrCreditCard = By.XPath("//input[@name='txtCVV']/../../..");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtCardExpMonthYear']")]
        public IWebElement ExpirationDate_MakeAPaymentPage;
        public By locatorForExpirationDate_MakeAPaymentPage = By.XPath("//input[@name='txtCardExpMonthYear']");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtCardExpMonthYear']/../../..")]
        public IWebElement ExpirationDatefield_DebitOrCreditCard;
        public By locatorForExpirationDatefield_DebitOrCreditCard = By.XPath("//input[@name='txtCardExpMonthYear']/../../..");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtZipCode']")]
        public IWebElement BillingZipOrPostalcode_MakeAPaymentPage;
        public By locatorForBillingZipOrPostalcode_MakeAPaymentPage = By.XPath("//input[@name='txtZipCode']");

        [FindsBy(How = How.XPath, Using = "//input[@name='txtZipCode']/../../..")]
        public IWebElement BillingZipOrPostalcodeField_DebitOrCreditCard;
        public By locatorForBillingZipOrPostalcodeField_DebitOrCreditCard = By.XPath("//input[@name='txtZipCode']/../../..");

        [FindsBy(How = How.XPath, Using = "//input[@name='checkIsInternationalZipCode']")]
        public IWebElement InternationalPostalcodeCheckBox_MakeAPaymentPage;
        public By locatorForInternationalPostalcodeCheckBox_MakeAPaymentPage = By.XPath("//input[@name='checkIsInternationalZipCode']");

        [FindsBy(How = How.Id, Using = "TermsConditions_{5A96EA6C-8562-43A5-9EB7-42944033300D}")]
        public IWebElement AgreeToTermsAndConditionsCheckBox_DebitOrCreditCard;
        public By locatorForAgreeToTermsAndConditionsCheckBox_DebitOrCreditCard = By.Id("TermsConditions_{5A96EA6C-8562-43A5-9EB7-42944033300D}");

        [FindsBy(How = How.Id, Using = "amount_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement TotalPayment_SavingsAccount;
        public By locatorForTotalPayment_SavingsAccount = By.Id("amount_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.Id, Using = "amount_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}")]
        public IWebElement TotalPayment_CheckingAccount;
        public By locatorForTotalPayment_CheckingAccount = By.Id("amount_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}");

        [FindsBy(How = How.XPath, Using = "amount_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement TotalPaymentField_SavingsAccount;
        public By locatorForTotalPaymentField_SavingsAccount = By.XPath("amount_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.Id, Using = "amount_{5A96EA6C-8562-43A5-9EB7-42944033300D}")]
        public IWebElement TotalPayment_DebitOrCreditCard;
        public By locatorForTotalPayment_DebitOrCreditCard = By.Id("amount_{5A96EA6C-8562-43A5-9EB7-42944033300D}");

        [FindsBy(How = How.Id, Using = "amount_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement TotalPaymentTxtBox_InstallmentPlan;
        public By locatorForTotalPaymentTxtBox_InstallmentPlan = By.Id("amount_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.XPath, Using = "//*[text()='Submit payment and set up installment plan']")]
        public IWebElement SubmitPaymentAndSetupInstallmentPlanButton;
        public By locatorForSubmitPaymentAndSetupInstallmentPlanButton = By.XPath("//*[text()='Submit payment and set up installment plan']");

        [FindsBy(How = How.Id, Using = "section-Installment-Payment-details")]
        public IWebElement InstallmentPlanTable_makeAPaymentPage;
        public By locatorForInstallmentPlanTable_makeAPaymentPage = By.Id("section-Installment-Payment-details");

        [FindsBy(How = How.Id, Using = "section-Installment-Plan-Grid-details")]
        public IWebElement InstallmentPlanTable_ConfirmationMsg;
        public By locatorForInstallmentPlanTable_ConfirmationMsg = By.Id("section-Installment-Plan-Grid-details");
        
        [FindsBy(How = How.XPath, Using = "//td[@data-label='Due Date']")]
        public IList <IWebElement> DueDate_InstallmentPlanTable_ConfirmationMsg { get; set; }
        public By locatorForDueDate_InstallmentPlanTable_ConfirmationMsg = By.XPath("//td[@data-label='Due Date']");


        [FindsBy(How = How.XPath, Using = "//td[@data-label='Status']")]
        public IList<IWebElement> Status_InstallmentPlanTable_ConfirmationMsg { get; set; }
        public By locatorForStatus_InstallmentPlanTable_ConfirmationMsg = By.XPath("//td[@data-label='Status']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='Amount']")]
        public IList<IWebElement> Amount_InstallmentPlanTable_ConfirmationMsg { get; set; }
        public By locatorForAmount_InstallmentPlanTable_ConfirmationMsg = By.XPath("//td[@data-label='Amount']");

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),' Print My Payment Confirmation')]")]
        public IWebElement PrintMyConfirmation_InstallmentPlan;
        public By locatorForPrintMyConfirmation_InstallmentPlan = By.XPath("//*[contains(text(),' Print My Payment Confirmation')]");

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Return to Home')]")]
        public IWebElement ReturnToHome_InstallmentPlan;
        public By locatorForReturnToHome_InstallmentPlan = By.XPath("//*[contains(text(),'Return to Home')]");

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'View Installment Plan')]")]
        public IWebElement ViewInstallmentPlanBtn;
        public By locatorForViewInstallmentPlanBtn = By.XPath("//*[contains(text(),'View Installment Plan')]");
        
        [FindsBy(How = How.XPath, Using = "//*[text()='Payment Pending']")]
        public IWebElement PaymentPendingBtn;
        public By locatorForPaymentPendingBtn = By.XPath("//*[text()='Payment Pending']");
        
        [FindsBy(How = How.XPath, Using = "//*[.='Pay in Full Using the Card']")]
        public IWebElement PayInFullUsingCardBtn;
        public By locatorForPayInFullUsingCardBtn = By.XPath("//*[.='Pay in Full Using the Card']");

        [FindsBy(How = How.Id, Using = "amount_{4813E5CB-007A-4576-9E8B-6CBE183B5E9B}")]
        public IWebElement TotalPayment_IPowner;
        public By locatorForTotalPayment_IPowner = By.Id("amount_{4813E5CB-007A-4576-9E8B-6CBE183B5E9B}");

        [FindsBy(How = How.XPath, Using = "//td[@class='text-right font-size-medium']//strong")]
        public IWebElement TotalPaymentAuthorised_InstallmentPlan;
        public By locatorforTotalPaymentAuthorised_InstallmentPlan = By.XPath("//td[@class='text-right font-size-medium']//strong");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*Name is a required field')]")]
        public IWebElement CardNameErrorMsg_InstallmentPlan;
        public By locatorForCardNameErrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*Name is a required field')]");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*Credit card number is a required field')]")]
        public IWebElement CardNumberErrorMsg_InstallmentPlan;
        public By locatorForCardNumberErrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*Credit card number is a required field')]");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*CVV is a required field')]")]
        public IWebElement CVVerrorMsg_InstallmentPlan;
        public By locatorForCVVerrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*CVV is a required field')]");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*Credit card expiration is a required field')]")]
        public IWebElement ExpirationDateErrorMsg_InstallmentPlan;
        public By locatorForExpirationDateErrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*Credit card expiration is a required field')]");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*Zip code is a required field')]")]
        public IWebElement BillingZipOrPostalCodeErrorMsg_InstallmentPlan;
        public By locatorForBillingZipOrPostalCodeErrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*Zip code is a required field')]");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'*Please accept terms and conditions')]")]
        public IWebElement AgreeToTermsAndConditionsErrorMsg_InstallmentPlan;
        public By locatorForAgreeToTermsAndConditionsErrorMsg_InstallmentPlan = By.XPath("//span[contains(text(),'*Please accept terms and conditions')]");

        [FindsBy(How = How.XPath, Using = "//*[text()=' Print My Payment Confirmation']")]
        public IWebElement PrintMyConfirmationBtn;
        public By locatorForPrintMyConfirmationBtn = By.XPath("//*[text()=' Print My Payment Confirmation']");

        [FindsBy(How = How.XPath, Using = "//td[text()='Initial Payment']")]
        public IWebElement FirstPayment_InstallmentStatus_makeAPaymentPage;
        public By locatorForFirstPayment_InstallmentStatus_makeAPaymentPag = By.XPath("//td[text()='Initial Payment']");

        [FindsBy(How = How.XPath, Using = "//span[@class='show-password']")]
        public IWebElement showButton_BankAccountNo;
        public By locatorForshowButton_BankAccountNo = By.XPath("//span[@class='show-password']");

        [FindsBy(How = How.XPath, Using = "//span[@class='hide-password']")]
        public IWebElement hideButton_BankAccountNo;
        public By locatorForHideButton_BankAccountNo = By.XPath("//span[@class='hide-password']");

        [FindsBy(How = How.XPath, Using = "//span[@class='show-password hidden']")]
        public IWebElement ShowPassword_BankAccountNo;
        public By locatorForShowPassword_BankAccountNo = By.XPath("//span[@class='show-password hidden']");

        [FindsBy(How = How.XPath, Using = "//input[@id='association']")]
        public IWebElement AssociationName;
        public By locatorForAssociationName = By.XPath("//input[@id='association']");

        [FindsBy(How = How.XPath, Using = "//div[@class='widget widget-manage-account need-assistance']")]
        public IWebElement NeedAssistanceSection;
        public By locatorForNeedAssistanceSection = By.XPath("//div[@class='widget widget-manage-account need-assistance']");

        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),'Within the U.S.')]/..")]
        public IWebElement WithinUSdetails;
        public By locatorForWithinUSdetails = By.XPath("//dt[contains(text(),'Within the U.S.')]/..");

        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),'Within the U.K.')]/..")]
        public IWebElement WithinUKdetails;
        public By locatorForWithinUKdetails = By.XPath("//dt[contains(text(),'Within the U.K.')]/..");

        [FindsBy(How = How.XPath, Using = "//dt[contains(text(),' All other locations')]/..")]
        public IWebElement AllOtherLocations;
        public By locatorForAllOtherLocations = By.XPath("//dt[contains(text(),' All other locations')]/..");

        [FindsBy(How = How.Id, Using = "TermsConditions_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement AgreeToTermsAndConditionsCheckBox_InstallmentPlan;
        public By locatorForAgreeToTermsAndConditionsCheckBox_InstallmentPlan = By.Id("TermsConditions_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.Id, Using = "nameOnCard_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement CardNameTxtBox_InstallmentPlan;
        public By locatorForCardNameTxtBox_InstallementPlan = By.Id("nameOnCard_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.Id, Using = "CardNumber_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement CardNumberTxtBox_InstallmentPlan;
        public By locatorForCardNumberTxtBox_InstallemntPlan = By.Id("CardNumber_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.Id, Using = "ccv_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement CVVTxtBox_InstallmentPlan;
        public By locatorForCVVTxtBox_InstallmentPlan = By.XPath("ccv_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.Id, Using = "expirationDate_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement ExpirationDateTxtBox_InstallmentPlan ;
        public By locatorForExpirationDateTxtBox_InstallmentPlan = By.Id("expirationDate_{1E738550-3D3B-4D32-9A08-E3A580705D98}");

        [FindsBy(How = How.Id, Using = "ZipCode_{1E738550-3D3B-4D32-9A08-E3A580705D98}")]
        public IWebElement BillingZipOrPostalcodeTxtBox_InstallmentPlan;
        public By locatorForBillingZipOrPostalcodeTxtBox_InstallmentPlan = By.Id("ZipCode_{1E738550-3D3B-4D32-9A08-E3A580705D98}");


        // Getting multiple matching elements

        [FindsBy(How = How.XPath, Using = "//span[@id='AgreeToTermAndConditions-error']")]
        public IList<IWebElement> AgreeToTermsAndConditionsError_Checkingaccount { get; set; }
        public By locatorForAgreeToTermsAndConditionsError_Checkingaccount = By.XPath("//span[@id='AgreeToTermAndConditions-error']");

        [FindsBy(How = How.XPath, Using = "//span[text()='*Please accept terms and conditions']")]
        public IWebElement AgreeToTermsAndConditionsError_DebitOrCreditCard;
        public By locatorForAgreeToTermsAndConditionsError_DebitOrCreditCard = By.XPath("//span[text()='*Please accept terms and conditions']");

        [FindsBy(How = How.XPath, Using = "//span[@class='show-password']")]
        public IList<IWebElement> showButton_SavingAccount { get; set; }
        public By locatorForshowButton_SavingAccount = By.XPath("//span[@class='show-password']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='Status']")]
        public IList<IWebElement> InstallmentStatus_PaymentConfirmationPage { get; set; }
        public By locatorForInstallmentStatus_PaymentConfirmationPage = By.XPath("//td[@data-label='Status']");

        [FindsBy(How = How.XPath, Using = "//td[@data-label='Status']")]
        public IList<IWebElement> InstallmentStatus_makeAPaymentPage { get; set; }
        public By locatorForInstallmentStatus_makeAPaymentPage = By.XPath("//td[@data-label='Status']");

        [FindsBy(How = How.XPath, Using = "//td[text()='To Be Paid']")]
        public IList<IWebElement> SecondOrThirdPayment_InstallmentStatus_makeAPaymentPage { get; set; }
        public By locatorForSecondOrThirdPayment_InstallmentStatus_makeAPaymentPage = By.XPath("//td[text()='To Be Paid']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Total Payment']/../..")]
        public IList<IWebElement> TotalPaymentField { get; set; }
        public By locatorForTotalPaymentField = By.XPath("//strong[text()='Total Payment']/../..");

        [FindsBy(How = How.XPath, Using = "//input[@id='amount_{5A96EA6C-8562-43A5-9EB7-42944033300D}']/../..")]
        public IWebElement TotalPaymentField_DebitOrCreditCard;
        public By locatorForTotalPaymentField_DebitOrCreditCard = By.XPath("//input[@id='amount_{5A96EA6C-8562-43A5-9EB7-42944033300D}']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Total Payment']/../..")]
        public IList<IWebElement>  TotalPayment_InstallmentPlan { get; set; }
        public By locatorForTotalPayment_InstallmentPlan = By.XPath("//strong[text()='Total Payment']/../..");

        [FindsBy(How = How.XPath, Using = "//span[text()='$']")]
        public IList<IWebElement> DollarSymbol { get; set; }
        public By locatorForDollarSymbol = By.XPath("//span[text()='$']");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Routing/Transit Number']/../..")]
        public IList<IWebElement> RoutingOrTransitNoField { get; set; }
        public By locatorForRoutingOrTransitNoField = By.XPath("//strong[text()='Routing/Transit Number']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Bank Account Number']/../..")]
        public IList<IWebElement> BankAccountNoField { get; set; }
        public By locatorForBankAccountNoField = By.XPath("//strong[text()='Bank Account Number']/../..");

        [FindsBy(How = How.XPath, Using = "//strong[text()='Re-Enter Bank Account Number']/../..")]
        public IList<IWebElement> ReEnterBankAccountNoField { get; set; }
        public By locatorForReEnterBankAccountNoField = By.XPath("//strong[text()='Re-Enter Bank Account Number']/../..");

        [FindsBy(How = How.Id, Using = "bankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}")]
        public IWebElement BankAccountNoTxtBox_Checkingaccount;
        public By locatorForBankAccountNoTxtBox_Checkingaccount = By.Id("bankAcct_{15CA0A7C-2ECF-438A-A8C0-F7A23208624E}");

        [FindsBy(How = How.Id, Using = "bankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}")]
        public IWebElement BankAccountNoTxtBox_Savingsaccount;
        public By locatorForBankAccountNoTxtBox__Savingsaccount = By.Id("bankAcct_{0D3C103F-56E7-433A-9EC6-864555651CB9}");

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit Payment'][1]")]
        public IList<IWebElement> SubmitPaymentBtn_MakeAPaymentPage { get; set; }
        public By locatorForSubmitPaymentBtn_MakeAPaymentPage = By.XPath("//button[text()='Submit Payment'][1]");
        
        [FindsBy(How = How.XPath, Using = "//input[@id='txtNameOnTheCard']/..")]
        public IList<IWebElement> CardName_InstallmentPlan { get; set; }
        public By locatorForCardName_InstallementPlan = By.XPath("//input[@id='txtNameOnTheCard']/..");

        [FindsBy(How = How.XPath, Using = "//input[@id='txtCardNumber']/../../../..")]
        public IList<IWebElement> CardNumber_InstallmentPlan { get; set; }
        public By locatorForCardNumber_InstallmentPlan = By.XPath("//input[@id='txtCardNumber']/../../../..");
        
        [FindsBy(How = How.XPath, Using = "//input[@id='txtCVV']/../../..")]
        public IList<IWebElement> CVV_InstallmentPlan { get; set; }
        public By locatorForCVV_InstallmentPlan = By.XPath("//input[@id='txtCVV']/../../..");
        
        [FindsBy(How = How.XPath, Using = "//input[@id='txtCardExpMonthYear']/../../..")]
        public IList<IWebElement> ExpirationDate_InstallmentPlan { get; set; }
        public By locatorForExpirationDate_InstallmentPlan = By.XPath("//input[@id='txtCardExpMonthYear']/../../..");

       
        [FindsBy(How = How.XPath, Using = "//input[@id='txtZipCode']/../../..")]
        public IList<IWebElement> BillingZipOrPostalcode_InstallmentPlan { get; set; }
        public By locatorForBillingZipOrPostalcode_InstallmentPlan = By.XPath("//input[@id='txtZipCode']/../../..");





    }
}
