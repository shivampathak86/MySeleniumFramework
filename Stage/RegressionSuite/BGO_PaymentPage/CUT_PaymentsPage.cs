using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using System.Collections.Generic;
using Utilities;

namespace CodedUITestProject
{
    [CodedUITest]
    public class CUT_Payments:BaseClass
    {
        public CUT_Payments()
        {
        }

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            LoginMethod loginMethod = new LoginMethod();
            loginMethod.InitializeBrowser(BrowserType.HeadlessChrome);
        }

        [ClassCleanup]
        public static void ClassClean()
        {
            TearDown(driver);

        }


        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify Bgo Blocks Payment And Vssa Determines It As User Is Not In Good Standing For Collection Status Code")]
        
        public void TC_51974_VerifyAlertMessageDisplayedForOwnerWhoDoesnotQualifyForOnlinePaymentInBGO()
        {
            Login(TestContext, 40, "Arvact", "", "default");
            Payment.ValidateBGOBlocksPayment("", TestContext);

        }



        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate  Message _No Statements Available_ Upon clicking Statement History in my Maintenance Fees Transaction Page")]
        public void TC_43746_VerfyTheMessageInMyMaintenaceFeesTransactionPageUponSelectingStatementHistoryOption_NoStatementsAvailable()
        {
            Login(TestContext, 41, "Arvact", "", "default");
            Payment.ValidateNoStatementsAvailable("",TestContext);

        }


        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify my maintenanace fees and club dues page for an owner who is eligible for IP")]

        public void TC01_PBI_97624_VerifyMakeAPaymentPageFor_IP_eligibleOwner()
        {
            Login(TestContext, 42, "Arvact", "", "vssa");
            Payment.ValidateMaintenancefeesPage_IPeligible(TestContext);

        }

        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify my maintenance fees and club dues page for an IP Owner")]

        public void TC_02_PBI_97624_VerifyMyMaintenanceFeesAndClubDuesPageFor_IPOwner()
        {
            Login(TestContext, 43, "Arvact", "", "vssa");
            Payment.ValidateMaintenancefeesPage_IPowner(TestContext);

        }

     
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify alert message is displayed for an IP owner whose Installment payment did not process successfully")]

        public void PBI_101227_Verify_YourInstallmentPaymentDidNotProcessSuccessfully_MessageOnHomePageFor_IPowner()
        {
            Login(TestContext, 44, "Arvact", "", "vssa");
            Payment.ValidateAlertMessageOnHomePageFor_IPownerWhosePaymentDidnotProcess(TestContext);

        }


        [Ignore]
        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify alert message for IS owner on BGO homepage with a button to update information")]

        public void PBI_101639_VerifyAlertMessageOnBGOhomepageWithAButtonToUpdateInformation_ISowner()
        {
            Login(TestContext, 45, "Arvact", "", "vssa");
            Payment.ValidateAlertMessageForISownerOnBGOhomepage(TestContext);

        }


        [TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Verify alert message for ID owner on BGO homepage with a button to update information")]

        public void PBI_101641_VerifyAlertMessageOnBGOhomepageWithAButtonToUpdateInformation_IDowner()
        {
            Login(TestContext, 46, "Arvact", "", "vssa");
            Payment.ValidateAlertMessageForIDownerOnBGOhomepage(TestContext);

        }

        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate the annual tabs on the My Maintenance Fees Transactions tabs display the corresponding table for VC single/Multiple associations with past due")]

        public void PBI_101875_ValidateAnnualTabsOnMyMaintenanceFeesTransactionsTabsDisplayCorrespondingTableForVCSingleorMultipleAssociation_PastDueAccount()
        {
            Login(TestContext, 47, "Arvact", "", "vssa");
            Payment.ValidateAnnulTabsOnMaintenancePageDisplayCorrespondingTable(TestContext);

        }


        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate statement history in My Maintenance Fees Transactions page for VC single/Multiple association with past due or current due having ARDA added")]

        public void PBI_102153_ValidateStatementHistoryInMyMaintenanceFeesTransactionsPageForVCSingleOrMultipleAssociation_WithPastOrCurrentDue_HavingARDAadded()
        {
            Login(TestContext, 48, "Arvact", "", "vssa");
            Payment.ValidateStatementHistoryInMyMaintenanceFeesTransactionsPage(TestContext);

        }

        
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate payment confirmation message for VC (type A & U and non-type A) owner having Single association,past due account _ACH payments option_Checking Account")]

        public void PBI_102424_PBI_103286_PBI_103282_PBI92365_ValidatePaymentConfirmationForVCOwnerPAstDueAccount__SingleAssociation_ACHpaymentsOption_CheckingAccount()
        {
            Login(TestContext, 49, "Arvact", "", "vssa");
            Payment.ValidatePaymentConfirmation_ACHpaymentOption(TestContext, ACHpaymentOption.CheckingAccount);

        }


        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate payment confirmation message for VC (type A & U and non-type A) owner having Single association,past due account _ACH payments option_Savings Account")]

        public void PBI_102486_PBI_103286_PBI_103282_PBI92365_ValidatePaymentConfirmationForVCOwnerPastDueAccount_SingleAssociation_ACHpaymentsOption_SavingsAccount()
        {
            Login(TestContext, 50, "Arvact", "", "vssa");
            Payment.ValidatePaymentConfirmation_ACHpaymentOption(TestContext, ACHpaymentOption.SavingsAccount);

        }

        
        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate payment confirmation message for VC (type A & U and non-type A) owner having Single association,past due account_payment options_Debit or Credit Card")]

        public void PBI_102804_PBI_103285_PBI92365_ValidatePaymentConfirmationMessageForVCOwnerPastDueAccount_SingleAssociation_PaymentOptions_DebitOrCreditCard()
        {
            Login(TestContext, 51, "Arvact", "", "vssa");
            Payment.ValidatePaymentConfirmation_DebitOrCreditCard(TestContext);

        }

        
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate Amount field is non-editable and error messages for mandatory fields if left blank in Make a payment page if Installment plan option is selected_VCowner_SalesTypeA_NonPastDueAccountOrCurrentBalance")]

        public void PBI_92430_ValidateAmountFieldIsNonUpdateableAndErrorMsgForMandatoryFieldsInMakeAPaymentPg_InstallmentPlanOptionSelected_VCowner_SalesTypeA_NonPastDue()
        {
            Login(TestContext, 52, "Arvact", "", "vssa");
            Payment.ValidateAmountFieldIsNonUpdateableAndErrorMsgForRequiredFieldsInMakeAPaymentPg(TestContext);

        }

        
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate First Installment payment status in payment confirmation page for IP eligible owner is changed to paid  _VC Owner_Sales Type A_ having current balance")]

        public void PBI_103235_ValidateFirstInstallmentStatusInPaymentConfirmationPgChangedToPaid_VCowner_SalesTypeA_NonPastDueAccount()
        {
            Login(TestContext, 53, "Arvact", "", "vssa");
            Payment.ValidateFirstPaymentStatusChangedToPaid_IPeligibleOwner(TestContext);
            
        }


       
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate Routing/Transit Number and Bank Account Number fields for VC (type A & U and non-type A) owner having Single association,past due account _ACH payments option_Checking Account")]

        public void TC_01_PBI_103284__ValidateRoutingOrTransitNumberAndBankAccountNumberFieldsForVCOwnerPAstDueAccount__SingleAssociation_ACHpaymentsOption_CheckingAccount()
        {
            Login(TestContext, 54, "Arvact", "", "vssa");
            Payment.ValidateRoutingAndBankAccountNumberFileds_ACHpaymentOption(TestContext, ACHpaymentOption.CheckingAccount);

        }

        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate Routing/Transit Number and Bank Account Number fields for VC (type A & U and non-type A) owner having Single association,past due account _ACH payments option_Checking Account")]

        public void TC02_PBI_103284_ValidateRoutingOrTransitNumberAndBankAccountNumberFieldsForVCOwnerPAstDueAccount__SingleAssociation_ACHpaymentsOption_SavingAccount()
        {
            Login(TestContext, 55, "Arvact", "", "vssa");
            Payment.ValidateRoutingAndBankAccountNumberFileds_ACHpaymentOption(TestContext, ACHpaymentOption.SavingsAccount);

        }



        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate Total payment field in Make a payment page when Credit/Debit card option is selected for VC (type A & U and non-type A) owner having Single association,past due account")]

        public void PBI_103281_ValidateTotalPaymentFieldInMakeApaymentPageForVCOwnerPAstDueAccount__SingleAssociation_PaymentOptions_DebitOrCreditCard()
        {
            Login(TestContext, 56, "Arvact", "", "vssa");
            Payment.ValidateTotalPaymentField_DebitOrCreditCard(TestContext);

        }


      
        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate Installment Plan payment page field validations")]

        public void PBI_103279_ValidateMakeAPaymentPageFieldsForVCownerHavingSingleAccount_InstallmentPlan()
        {
            Login(TestContext, 57, "Arvact", "", "vssa");
            Payment.ValidateMakeApaymentPageForVCownerHavingSingleAccount_InstallmentPlan(TestContext);

        }

        [ TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate View Installment Plan link is displayed to Eligible owners that have an IP plan set up- And U")]

        public void PBI_92412_ValidateViewInstallmentPlanLinkIsDisplayedForVCsingleAccount_SalestypeAorU_IP_planSetUp()
        {
            Login(TestContext, 58, "Arvact", "", "vssa");
            Payment.ValidateViewInstallmentPlanLinkIsDisplayedForVCSingleAccount_SalestypeAorU_IPsetUpOwner(TestContext);

        }


        [Ignore]
        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Validate View Installment Plan link is hidden for owners that do not have an IP plan set up- And salestype U")]

        public void PBI_92413_ValidateViewInstallmentPlanLinkIsHiddenForVCsingleAccountThatDoNotHaveIPplanSetup_SalestypeAorU()
        {
            Login(TestContext, 59, "Arvact", "", "vssa");
            Payment.ValidateViewInstallmentPlanLinkIsHiddenForVCSingleAccountThatDoNotHaveIPplanSetup_SalestypeAorU(TestContext);

        }
        

    }
}
