using BlueGreenOwner;
using BlueGreenOwner.TestCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using Utilities;

namespace CodedUITestProject
{

    [CodedUITest]
    public class CUT_ChoicePrivilegesPage: BaseClass
    {
        public CUT_ChoicePrivilegesPage()
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
        [TestCategory("Deployment")]
        [TestProperty("TestDescription", "TC01_PBI87926_Verify the Bluegreen vacation points are getting converted to Choice Privileges points.")]

        public void TC01_PBI87926_ValidatePointsConversionToChoicePrivilegePoints()
        {
            Login(TestContext, 13, "Arvact", "", "VSSA");

            ChoicePrivileges.ValidateConvertChoicePoints(TestContext);

        }



    }


}
