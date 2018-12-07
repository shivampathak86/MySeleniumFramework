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
    public class CUT_RegistrationConfirmationPage : BaseClass
    {
        public CUT_RegistrationConfirmationPage()
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


        [TestCategory("Registration"), TestCategory("Full Regression")]
         [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\RegistrationConfirmation.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'", "TC01_PBI92121$", DataAccessMethod.Sequential), TestMethod]
      //  [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BGO_RegistrationConfirmationPage\\TC_01_PBI92121.csv", "TC_01_PBI92121#csv", DataAccessMethod.Sequential), DeploymentItem("BGO_RegistrationConfirmationPage\\TC_01_PBI92121.csv"), TestMethod]
        [TestProperty("TestDescription", "TC 01_PBI 92121 _Validate error message in Registration confirmation Page_For Country=US.")]
        public void TC_01_PBI92121_ValidateErrorMsgInRegistrationConfirmationPageForUS()
        {
            Login(TestContext, 0, "", "", "registration");

           RegistrationConfirmation.GoToRegisterWithBluegreenVacactionsPage(TestContext,TestContext.DataRow["SSN"].ToString(),TestContext.DataRow["Arvact"].ToString(),TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

           RegistrationConfirmation.VerifyErrorMsgInRegistationConfirmationPage(TestContext);

        }
        

        [TestCategory("Registration"), TestCategory("Full Regression")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BGO_RegistrationConfirmationPage\\TC 02_PBI 92121.csv", "TC 02_PBI 92121#csv", DataAccessMethod.Sequential), DeploymentItem("BGO_RegistrationConfirmationPage\\TC 02_PBI 92121.csv"), TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\RegistrationConfirmation.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'", "TC02_PBI92121$", DataAccessMethod.Sequential), TestMethod]
        [TestProperty("TestDescription", "TC 02_PBI 92121 _Validate error message in Registration confirmation Page_For Country other than US.")]

        public void TC_02_PBI92121_ValidateErrorMsgInRegistrationConfirmationPageForNonUS()
        {
            Login(TestContext, 0, "", "", "registration");

            RegistrationConfirmation.GoToRegisterWithBluegreenVacactionsPage(TestContext, TestContext.DataRow["SSN"].ToString(), TestContext.DataRow["Arvact"].ToString(), TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());
            RegistrationConfirmation.VerifyErrorMsgInRegistationConfirmationPageForNonUS(TestContext);

        }


        [TestCategory("Registration"), TestCategory("Full Regression")]
      // [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BGO_RegistrationConfirmationPage\\TC_03_PBI 92121.csv", "TC_03_PBI 92121#csv", DataAccessMethod.Sequential), DeploymentItem("BGO_RegistrationConfirmationPage\\TC_03_PBI 92121.csv"), TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\RegistrationConfirmation.xlsx;Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES'", "TC03_PBI_92121$", DataAccessMethod.Sequential), TestMethod]
        [TestProperty("TestDescription", "TC 03_PBI 92121 _Validate Registration confirmation for user in BGO")]
        public void TC03_PBI_92121_ValidateRegistrationConfirmationMsgForUserInBgo()
        {
            Login(TestContext, 0, "", "", "registration");

            RegistrationConfirmation.GoToRegisterWithBluegreenVacactionsPage(TestContext, TestContext.DataRow["SSN"].ToString(), TestContext.DataRow["Arvact"].ToString(), TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());
        }



    }


}

