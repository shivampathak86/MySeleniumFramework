using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{
   
    [CodedUITest]
    public class CUT_PrePayment:BaseClass
    {
        public CUT_PrePayment()
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



        [Ignore]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BGO_PrePaymentPage\\DATA_TestCase_59410.csv", "DATA_TestCase_59410#csv", DataAccessMethod.Sequential), DeploymentItem("BGO_PrePaymentPage\\DATA_TestCase_59410.csv"), TestMethod]
        [TestProperty("TestDescription", "To Verify The Functionality In Make A Pre Payment Page")]
        public void TC_59410_MakePrePayment()
        {
            Login(TestContext, 84, "Arvact", "", "default");

            PrePayment.MakeAPrepayment("", TestContext);

        }

       
    }
}
