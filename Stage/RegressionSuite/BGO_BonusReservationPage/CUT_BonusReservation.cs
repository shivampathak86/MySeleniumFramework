using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;

namespace CodedUITestProject
{
	
	[CodedUITest]
	public class CUT_BonusReservation : BaseClass
	{
		public CUT_BonusReservation()
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

        [TestCategory("Deployment"),TestCategory("Full Regression"), TestCategory("Reservations")]
        [TestMethod]
        [TestProperty("TestDescription", "Create Bonus Time Reservation And Validate The Confirmation Details ")]

        [Ignore]
        public void TC_59635_BonustimeReservation()
		{
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

            Login(TestContext, 7, "Arvact", "", "default");

            BonusReservation.BonusTimeReservation("", TestContext, "no", "no", "no");
		}


        [TestCategory("Full Regression"),TestCategory("Reservation")]
        [TestMethod]
        [TestProperty("TestDescription", "Create Bonus Time Reservation With Two Nights Min Charge For Single Night")]

		public void TC_60028_OneNightBonusTimereservation()
		{

            Login(TestContext, 8, "Arvact", "", "default");

            BonusReservation.BonusTimeReservation("", TestContext, "no", "1night", "no");
	 	}

        [TestCategory("Deployment"),TestCategory("Full Regression"),TestCategory("Reservations")]
        [TestMethod]
		[TestProperty("TestDescription", "Cancel Bonus Time Reservation  With In 24 Hours From My Reservation")]

        [Ignore]
        public void TC_58997_CancelBonusReservation()
		{

            Login(TestContext, 9, "Arvact", "", "default");

            BonusReservation.CancelBonusTimeReservationWithinGP("", TestContext, "no", "no", "no");
		}

        [TestCategory("Deployment"),TestCategory("Full Regression"),TestCategory("Reservation")]
        [TestMethod]
		[TestProperty("TestDescription", "Verify Resend Email For Bonus Type Reservation")]

        [Ignore]
        public void TC_59116_ResendBonusItinerary()
		{

            Login(TestContext, 10, "Arvact", "", "default");

            BonusReservation.ResendEmailforBonusTypeReservation("", TestContext);
		}


        [TestCategory("Full Regression"),TestCategory("Reservation")]
        [TestMethod]
		[TestProperty("TestDescription", "To Verify All Functionalities In Reservation Confirmation Page-VC Non Premier Owner")]
        
        public void TC_85863_ConfirmationPageFunctionalitiesForBonusReservation()
        {
            Login(TestContext, 11, "Arvact", "", "default");

            PointsReservation.ValidateConfirmationPageForBonusOrPointsType("", TestContext, Constants.bonustype, Constants.VCNP, false);
		}



	}   
        
}
