using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.Diagnostics;

namespace CodedUITestProject
{
    
    [CodedUITest]
    public class CUT_FooterLinks : BaseClass
    {
        public CUT_FooterLinks()
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



        [TestCategory("Footer"),TestCategory("Deployment"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_01_PBI97630_PBI97631_Validate Footer Links For VC or Non_VC Multiple Account")]
        public void TC_01_PBI97630_PBI97631_ValidateFooterLinksForVCorNonVCMultipleAccount()
        {
            Login(TestContext, 15, "UserName", "Password", "SelectAnAccount");

            FooterLinks.ValidateFooterLinks_VCorNonVCmultiple(TestContext);
        }


        [TestCategory("Footer"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_02_PBI97630_PBI97631_Validate Footer Links For VC or Non_VC single Account")]
        public void TC_02_PBI97630_PBI97631_ValidateFooterLinksForVCorNonVCsingleAccount()
        {
            Login(TestContext, 16, "UserName", "Password", "SelectAnAccount");

            FooterLinks.ValidateFooterLinks_VCorNonVCsingle(TestContext);
        }


    }
}
