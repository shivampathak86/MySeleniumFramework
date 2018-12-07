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
    public class CUT_GreatEscapesReservation :BaseClass
    {
        public CUT_GreatEscapesReservation()
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
        [TestMethod]
        [TestProperty("TestDescription", "PBI 92486 _Verify the great escapes booking  is reflected in fund source page-visa")]
		
        public void PBI92486_VerifyGreatEscapesReservationIsReflectedInFundSource()
        {
            Login(TestContext,2, "Arvact","", "VSSA");

            GreatEscapesReservation.ValidateGreatEscapeBooking(TestContext);
        }

    }

}


