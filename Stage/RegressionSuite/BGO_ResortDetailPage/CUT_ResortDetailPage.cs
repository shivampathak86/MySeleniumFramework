using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.Diagnostics;

namespace CodedUITestProject
{
   
    [CodedUITest]
    public class CUT_ResortDetailPage : BaseClass
    {
        public CUT_ResortDetailPage()
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
        [TestCategory("Full Regression"), TestCategory("Home Page"), TestCategory("Deployment")]
        [TestProperty("TestDescription", "TC 01_PBI 97635_Validate association menu is displayed on the resort detail page for oasis lakes owner")]
        public void TC_01_PBI_97635_ValidateAssociationMenuIsDisplayedForOasisLakeOwner()
        {
            Login(TestContext, 92, "Arvact", "", "VSSA");

            ResortDetails.ValidateResortDetails(TestContext);
        }


    }
}
