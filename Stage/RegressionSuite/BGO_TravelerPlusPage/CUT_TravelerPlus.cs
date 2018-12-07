using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.IO;

namespace CodedUITestProject
{
    
    [CodedUITest]
    public class CUT_TravelerPlus:BaseClass
    {
        public CUT_TravelerPlus()
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
            extentTest.Info("Tear down is called");

        }

        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify RCI Nightly Stays")]
        public void TC_59580_VerifyRCINightlyStaysForTravelerPlusOwner()
        {
            Login(TestContext, 99, "Arvact","", "default");
            TravelerPlus.ValidateRCINightlyStays("", TestContext);
        }


        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify RV  Resort Coast Link")]
        public void TC_59581_VerifyRVResortCoastlinkForTravelerPlusOwner()
        {
            Login(TestContext, 100, "Arvact", "", "default");
            TravelerPlus.ToVerifyRVResortCoastlink("", TestContext);
        }


        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify That Non Tp Owners  Should Not Get Hot Weeks, RCI Nightly Stays, Rv  Resort Coast Link And Great Escapes Menus")]
        public void TC_59582_VerifyNonTravelerPlusHomePage()
        {
            Login(TestContext, 101, "Arvact", "", "default");
            TravelerPlus.VerifyNoHotweeksForNonTpUsers("", TestContext);
        }


        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionality Of Car Rentals")]
        public void TC_59550_VerifyFunctionalityOfCarRentalsForTravelerPlusOwner()
        {
            Login(TestContext, 102, "Arvact", "", "default");
            TravelerPlus.validateTravelServicesWithCarRentals("", TestContext);
        }


        [TestCategory("Deployment"), TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify Direct Exchange Page")]
        public void TC_59579_VerifyDirectExchangePageForTravelerPlusOwner()
        {
            Login(TestContext, 103, "Arvact", "", "default");
            TravelerPlus.ValidateDirectExchangePage("", TestContext);
        }


    
        [ TestCategory("Traveler Plus"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI 97653_Verify renew your Traveler plus membership ")]

        public void PBI_97653_VerifyRenewMyTravelerPlusMembership()
        {
            Login(TestContext, 104, "Arvact", "", "AccountNumberValidation");
            TravelerPlus.ValidateRenewTPMembership(TestContext);

        }
    }
}
