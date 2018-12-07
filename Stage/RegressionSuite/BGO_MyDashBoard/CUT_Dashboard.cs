using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{
  
    [CodedUITest]
    public class CUT_Dashboard:BaseClass
    {
        public CUT_Dashboard()
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


        [TestCategory("Full Regression"), TestCategory("My Dashboard")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionality For Saved Searches")]

        public void TC_59160_VerifyFunctionalityOfSavedSearches()
        {
            Login(TestContext, 25, "Arvact", "", "default");

            Dashboard.Savedsearches("", TestContext, ReadData(25, "Destination").ToString(), "no", "no",Constants.pointstype);
        }

        [TestCategory("Full Regression"), TestCategory("My Dashboard"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_99740_Verify account summary details in my Dashboard page for VC Single/Multiple club account")]

        public void PBI_99740_VerifyAccountSummaryDetailsforVCsingleOrMultipleAccount()
        {
            Login(TestContext, 26, "Arvact", "", "default");

            Dashboard.AccountSummaryForVC(TestContext);
        }


        [TestCategory("Full Regression"), TestCategory("My Dashboard"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "PBI_97636_Verify account summary details in my Dashboard page for Non-VC Single/Multiple club account")]

        public void PBI_97636_VerifyAccountSummaryDetailsforNonVCsingleOrMultipleAccount()
        {
            Login(TestContext, 27, "Arvact", "", "default");

            Dashboard.AccountSummaryForNonVC(TestContext);
        }


       
        
       
    }
}
