using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;

namespace CodedUITestProject
{
    
    [CodedUITest]
    public class CUT_MyAccountPage: BaseClass
    {
        public CUT_MyAccountPage()
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



        [TestCategory("Full Regression"), TestCategory("My Account"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_84746_Verify Additional Member Card on My Account Page")]
		[TestProperty("TestType", "testwithnoaddtionalmembercard")]


		public void TC_84746_VerifyAdditionalCardMemberRequest()
		{
            Login(TestContext, 21, "Arvact", "", "default");
            
            MyAccount.AdditionalMemberCardLink(TestContext, TestContext.Properties["TestType"].ToString());

		}


        [TestCategory("Full Regression"), TestCategory("My Account")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_01_PBI 92103_Validate asterik for mandatory fields in My Account Page_For Country=US.")]
        public void TC01_PBI92103_ValidateMandatoryFieldsInMyAccountPageForUS()
        {
            Login(TestContext, 22, "Arvact", "", "VSSA");
            
            MyAccount.Navigate_To_MyAccountPage(TestContext);
            MyAccount.ValidateAsterikInMyAccountPage(TestContext);

        }

        [TestCategory("Full Regression"), TestCategory("My Account")]
        [TestMethod]
        [TestProperty("TestDescription", "TC_02_PBI 92103_Validate asterik for mandatory fields in My Account Page_For Country other than US.")]
        public void TC02_PBI92103_ValidateMandatoryFieldsInMyAccountPageForNonUS()
        {
            Login(TestContext, 23, "Arvact", "", "VSSA");
            
            MyAccount.Navigate_To_MyAccountPage(TestContext);
            MyAccount.ValidateAsterikInMyAccountPageForNonUS(TestContext);

        }

        

    }
}
