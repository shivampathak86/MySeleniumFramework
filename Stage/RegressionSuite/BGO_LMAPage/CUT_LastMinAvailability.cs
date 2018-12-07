using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{


    [CodedUITest]
    public class CUT_LastMinAvailability:BaseClass
    {
        public CUT_LastMinAvailability()
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

        [TestCategory("Full Regression"),TestCategory("LMA")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionalities In LMA Page-FixFlexOwner")]
        public void TC_59773_VerifyLMAPageForFixFlexUser()
        {
            Login(TestContext, 18, "Arvact", "", "default");

            LMA.validateLMAPageForFixFlexOwner("", TestContext);

        }

        [TestCategory("Full Regression"),TestCategory("LMA")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionalities In LMA Page-VCPremierOwnerOrSampler24Owner")]
        public void TC_59768_VerifyLMAPageForVCpremierOrSampler24Owner()
        {
            Login(TestContext, 19, "Arvact", "", "default");

            LMA.validateLMAPageForVCorSampler24Owner("", TestContext);
        }
       
        
    }
}




