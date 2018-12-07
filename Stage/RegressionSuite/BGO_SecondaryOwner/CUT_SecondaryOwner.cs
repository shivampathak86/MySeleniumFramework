using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.Diagnostics;

namespace CodedUITestProject
{
   
    [CodedUITest]
    public class CUT_SecondaryOwner : BaseClass
    {
        public CUT_SecondaryOwner()
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

        //[Ignore]
        //[TestProperty("TestDescription", "PBI_97637_Validate Resort Access for Secondary Owner")]
        //public void PBI97637_ValidateResortAccessForSecondaryOwner()
        //{
        //    Login(TestContext, 97, "Arvact", "", "VSSA");

        //    SecondaryOwner.ValidateResortAccessForSecondaryOwner(TestContext);
        //}


    }
}
