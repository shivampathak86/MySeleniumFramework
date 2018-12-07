using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{

    [CodedUITest]
    public class CUT_MyPointsPage:BaseClass
    {
        public CUT_MyPointsPage()
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

        [TestCategory("Deployment"),TestCategory("Full Regression"),TestCategory("Save My Points")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_61989_To Verify The Functionality Of Save My Points Button")]
        public void TC_61989_VerifyFunctionalityofSavePointsButton()
        {

            Login(TestContext, 38, "Arvact", "", "default");
            SavePoints.VerifySaveMyPointsFunctionalityInMyPointsPage(ReadData(38, "Arvact").ToString(), TestContext);
        }

        
    }
}
