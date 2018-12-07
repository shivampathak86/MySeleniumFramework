using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{
   
    [CodedUITest]
    public class AcountNumberValidations:BaseClass
    {
        public AcountNumberValidations()
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
        [TestProperty("TestDescription", "TC01_PBI_97625_Validate account no grid  in My Account Page")]

        public void TC01_PBI97625_ValidateAccountNoGridInMyAccountPage()
        {
            Login(TestContext, 4, "Arvact","", "AccountNumberValidation");

            ValidateAccountNoGrid.ValidateAccountNumberGrid(TestContext);
        }


        [TestMethod]
        [TestProperty("TestDescription", "TC02_PBI_97625_Validate account no grid  in Registration confirmation Page")]
		public void TC02_PBI_97625_ValidateAccountNoGridInRegistrationConfirmationPage()
        {
            Login(TestContext, 5, "Arvact", "", "AccountNumberValidation");

            ValidateAccountNoGrid.ValidateAccountNumberGrid_REgConfPage(TestContext);
        }

        
    }
}
