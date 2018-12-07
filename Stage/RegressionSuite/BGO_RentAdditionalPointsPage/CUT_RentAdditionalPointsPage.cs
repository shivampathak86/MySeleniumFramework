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
    public class CUT_RentAdditionalPointsPage :BaseClass
    {
        public CUT_RentAdditionalPointsPage()
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

        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "TC 01_PBI 97024 _Verify rent additional points.")]
        public void TC01_PBI97024_VerifyRentAdditionalPoints()
        {
            Login(TestContext, 90, "Arvact", "", "VSSA");

            RentAdditionalPoints.ValidateRentAdditionalPoints(TestContext);

        }

        
    }


}
