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
    public class CUT_PaymentReminderPage : BaseClass
    {
        public CUT_PaymentReminderPage()
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
        [TestProperty("TestDescription", "TC 01_PBI 89030_Validate Payment Reminder Page for NVC only single association owner -FlexFix with PastDue and Collection codes allowing payment.")]

        public void TC01_PBI89030_ValidatePaymentReminderForNVCsingleAssociationOwner()
        {
            Login(TestContext, 61, "Arvact", "", "VSSA");
            PaymentReminder.ValidatePaymentReminderPage(TestContext, OwnerType.NonVC_SingleAssociation);
            
        }


        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI 89030: TC13_Validate Payment Reminder Page_PastDue")]

        public void PBI_92252_ValidatePaymentReminderPageVCowner_PastDue()
        {
            Login(TestContext, 62, "Arvact", "", "VSSA");
            PaymentReminder.ValidatePaymentReminderPage(TestContext, OwnerType.PastDue_TPexpired);

        }

        [TestCategory("Deployment"), TestCategory("Payment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI 89030: TC06_Validate Payment Reminder Page is not shown for owner_ Value Sampler and Sampler 24")]

        public void PBI_92253_ValidatePaymentReminderPage_ValueSamplerAndSampler24()
        {
            Login(TestContext, 63, "Arvact", "", "VSSA");
            PaymentReminder.ValidatePaymentReminderPage(TestContext, OwnerType.SamplerOrSampler24);

        }

        

    }


}