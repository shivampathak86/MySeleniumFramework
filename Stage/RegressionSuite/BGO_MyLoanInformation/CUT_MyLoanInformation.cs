using BlueGreenOwner;
using BlueGreenOwner.TestCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Configuration;
using Utilities;

namespace CodedUITestProject
{
 
    [CodedUITest]
    public class CUT_MyLoanInformation : BaseClass
    {
        public CUT_MyLoanInformation()
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


        [TestMethod]
        [TestCategory("Deployment")]
        [TestProperty("TestDescription", "PBI_103394 _Validate owner's loans display in the drop down menu ,regardless if they are active or inactive and Active loans are sorted by maturity date with the earliest maturity date appearing first")]

        public void PBI_103394_ValidateOwnersLoansDisplayInDropdownAndActiveLoansAreSortedByEarliestMaturityDate()
        {
            Login(TestContext, 29, "Arvact", "", "VSSA");
          
            MyLoanInformation.ValidateOwnersLoanSortedByEarliestMaturityDate(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103397 _Validate Update Borrower information link redirects to borrower information page and  Update automatic payment link redirects to manage auto-pay page")]

        public void PBI_103397_ValidateUpdateBorrowerInformationLinkAndUpdateAutomaticPaymentLinkRedirectsToTheirRespectivePage()
        {
            Login(TestContext, 30, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateUpdateBorrowerInformationAndUpdateAutomaticPaymentLink(TestContext);
        }

        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103399 _Validate Update Borrower information link and Update automatic payment link doesn’t display for Inactive loans")]

        public void PBI_103399_ValidateUpdateBorrowerInformationLinkAndUpdateAutomaticPaymentLinkDoesnotDisplayForInactiveLoan()
        {
            Login(TestContext, 31, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateUpdateBorrowerInformationAndUpdateAutomaticPaymentLink_InactiveLoan(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103403 _Validate the loan details and next payment details display for each loan selected(Active or Inactive)")]

        public void PBI_103403_ValidateLoanDetailsAndNextPaymentDetailsDisplayForEachLoanSelected_ActiveOrInactive()
        {
            Login(TestContext, 32, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateLoanDetailsAndNextPaymentDetails(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103410_Validate Download tax documents button ,Request a payoff quote button and Make a payment button navigates to their respective page")]

        public void PBI_103410_ValidatePageNavigationsOnMyLoanInformationPage()
        {
            Login(TestContext, 33, "Arvact", "", "VSSA");
            MyLoanInformation.ValidatePageNavigationsOnMyLoanInformationPage(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103405_Validate Data in transaction History table for owner with Active Loans having past one year Transaction history _Loan Information page")]

        public void PBI_103405_ValidateDataInTransactionHistoryTableForOwnerWithMultipleActivleLoanHavingPastOneYearTrasactionHistoryFromCurrentDate_MyLoanInformationPage()
        {
            Login(TestContext, 34, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateDataInTransactionHistoryTable_MultipleActiveLoan(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103809_Validate Data in transaction History table for owner with Inactive Loans having past one year Transaction history_Loan Information page")]

        public void PBI_103809_ValidateDataInTransactionHistoryTableForOwnerWithInactivleLoanHavingPastOneYearTrasactionHistoryFromCurrentDate_MyLoanInformationPage()
        {
            Login(TestContext, 35, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateDataInTransactionHistoryTable_InactiveLoan(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_103812_PBI_103965_Validate Mortgage Make a Payment page and Western Union Speedpay Page _Active Loan")]
    
        public void PBI_103812_PBI103965_ValidateMortgageMakeAPaymentPageAndWesternUnionSpeedpayPage_ActiveLoan()
        {
            Login(TestContext,36, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateMortgageMakeAPaymentPageAndWesternUnionSpeedpayPage(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_40200_Validating Request Payoff Page For Replacing US mail")]

        public void TC_40200_ValidateRequestPayOffPageForReplacingUSmail()
        {

            Login(TestContext, 106, "Arvact", "", "VSSA");
            MyLoanInformation.ValidateRequestPayOffPage(TestContext);
        }


        [TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_40203_Validating error message on Mortgage Security Page when Last Name On Loan Not Matches With LSAMS")]
        
        public void TC_40203_ValidateErrorMessageInMortgageSummaryPage_LastNameNotMatchingWithLsams()
        {
            Login(TestContext, 107, "Arvact", "", "VSSA");
            MyLoanInformation.ViewErrorMessageLastNameonLoanNotMatchingLSAMS( TestContext);
        }





    }

}