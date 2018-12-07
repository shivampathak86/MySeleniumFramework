using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.Configuration;

namespace CodedUITestProject
{
  
    [CodedUITest]
    public class CUT_SignIn:BaseClass
    {
       
        public CUT_SignIn()
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


        [TestCategory("Full Regression"), TestCategory("Sign In"), TestCategory("Deployment")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BGO_SignIn\\PBI_89093.csv", "PBI_89093#csv", DataAccessMethod.Sequential), DeploymentItem("BGO_SignIn\\PBI_89093.csv"), TestMethod]
       // [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\stg-data.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'", "DATA_TestCase_PBI89093$", DataAccessMethod.Sequential), TestMethod]
        [TestProperty("TestDescription", "PBI_89093_Validate the BGO sign in.")]

        public void PBI_89093_ValidateBGOSignInForDifferentTypesOfOwner()

        {
            Login(TestContext, 0, "UserName", "Password", "signin");

            SignIn.OnwerSignIn(TestContext);
            
        }
        
    }
}
