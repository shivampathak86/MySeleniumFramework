using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject.BGO_PremierWaitListPage
{
   
    [CodedUITest]
    public class CUT_PremierWaitList:BaseClass
    {
        public CUT_PremierWaitList()
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

        [ TestCategory("Full Regression"), TestCategory("Premier Wait List")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Add Premier Wait List In My DashBoard Page")]

        public void TC_59167_AddPwlFromDashboard()
        {
            Login(TestContext, 78, "Arvact", "", "default");

            PWL.CreatePWL("", TestContext,"dashboard");
        }


        [TestCategory("Full Regression"), TestCategory("Premier Wait List")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify the Add Premier Wait List in Book Main Menu")]

        public void TC_59464_AddPWLFromBookMenu()
        {
            Login(TestContext, 79, "Arvact", "", "default");

            PWL.CreatePWL("", TestContext,"book");
        }


        [ TestCategory("Full Regression"), TestCategory("Premier Wait List")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify the Cancel Premier Wait List in Book Main Menu")]

        public void TC_59469_CancelPWLFromBookMenu()
        {
            Login(TestContext, 80, "Arvact", "", "default");
            PWL.CancelPWL("", TestContext, "book");
        }

        [TestCategory("Full Regression"), TestCategory("Premier Wait List")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Cancel Premier Wait List In My DashBoard Page")]

        public void TC_59167_CancelPWLFromDashBaord()
        {
            Login(TestContext, 81, "Arvact", "", "default");
            PWL.CancelPWL("", TestContext, "dashboard");
        }



        [TestCategory("Full Regression"), TestCategory("Premier Wait List")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify Update Premier Wait List in My DashBoard Page")]

        public void TC_59469_UpdatePWLFromDashBoard()
        {
            Login(TestContext, 82, "Arvact", "", "default");
            PWL.UpdatePWL("", TestContext, "dashboard");
        }

        
    }
}
