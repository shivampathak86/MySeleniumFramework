using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueGreenOwner.TestCases;
using BlueGreenOwner;
using Utilities;
using System.IO;

namespace CodedUITestProject
{
    
    [CodedUITest]
    public class CUT_PointsReservation : BaseClass
    {
        
        public CUT_PointsReservation()
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
        

        [TestCategory("Points Reservation"),TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestCategory("Reservation"),TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "Sampler Owner_Create Points Reservation With Points Protection Plan And Verify The Reservation Details")]

        [Ignore]
        public void PBI_34019_SamplerPointReservationWithPPP()
        {
            Login(TestContext, 65, "Arvact", "", "default");

            PointsReservation.PointReservationWithOrWithOutPPP("", TestContext, true, "no", "no", "no");

        }

        [TestCategory("Reservation"), TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify Booking Points Reservation _Search By Dates")]

        [Ignore]
        public void PBI_60215_PointsReservationSearchByDatesNoPPP()
        {
            Login(TestContext, 66, "Arvact", "", "default");

            PointsReservation.PointReservationWithOrWithOutPPP("", TestContext, false, "no", "yes", "no");

        }

        [TestCategory("Reservation"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Create Points Reservation Such That An Error Message Is Thrown -  Not Enough Points Message")]
        public void PBI_34016_NotEnoughPointsErrorMessage()
        {
            Login(TestContext, 67, "Arvact", "", "default");

            PointsReservation.PointReservationErrorMessage("", TestContext);

        }

        [TestCategory("Reservation"), TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "Add PPP On My Reservation Page By Clicking On Buy Now Button On Points Reservation")]

        [Ignore]
        public void PBI_58986_BuyPPP()
        {
            Login(TestContext, 68, "Arvact", "", "default");

            PointsReservation.buyPPPFromMyReservationsPage("", TestContext, false);

        }

        [TestCategory("Reservation"), TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestMethod]
        [TestProperty("TestDescription", "Cancel Point Type Reservation Within Grace Period")]

        [Ignore]
        public void PBI_58996_CancelPointsReservation()
        {
            Login(TestContext, 69, "Arvact", "", "default");

            PointsReservation.CancelPointsReservationWithInGP("", TestContext, false);
        }


        [TestCategory("Reservation"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "Create Point Type Reservation With Minimum Of 7 Nights Stay")]
       
        public void PBI_60029_7NightsStay()
        {
            Login(TestContext, 70, "Arvact", "", "default");

            PointsReservation.PointReservationWithOrWithOutPPP("", TestContext, false, "no", "7NIGHTSTAY", "no");

        }


        [TestCategory("Reservation"), TestCategory("Full Regression")]
        [TestMethod]
        [TestProperty("TestDescription", "To Verify Booking Points Reservation With Wheel Chair Option")]
        
        public void PBI_85865_PointsReservationwithWheelChairNoPPP()
        {
            Login(TestContext, 71, "Arvact", "", "default");

            PointsReservation.PointReservationWithOrWithOutPPP("", TestContext, false, "no", "no", "yes");
            
        }

        
        [TestMethod]
        [TestCategory("Reservation"), TestCategory("Full Regression")]
        [TestProperty("TestDescription", "To Verify Pagination Option  Displayed In My Reservation Page")]

        public void PBI_59175_Pagination()
        {
            Login(TestContext, 72, "Arvact", "", "default");

            PointsReservation.Pagination("", TestContext);
        }


        [TestProperty("TestDescription", "To Verify Send Email With Itenary  for Points Reservation In Reservation Confirmation Page")]
        [TestMethod]
        [TestCategory("Reservation"), TestCategory("Full Regression")]

        public void PBI_59170_ResendPointsItinerary()
        {
            Login(TestContext, 73, "Arvact", "", "default");

            PointsReservation.ResendEmailforPointTypeReservation("", TestContext, false);
        }


        [Ignore]
        [TestMethod]
        
        [TestCategory("Reservation"), TestCategory("Full Regression"), TestCategory("Deployment")]
        [TestProperty("TestDescription", "Point Type Reservation_To Verify All Functionalities In Reservation Confirmation Page-VC Premier")]

        public void PBI_60317_ConfirmationPageFunctionalities()
        {
            Login(TestContext, 74, "Arvact", "", "default");

            PointsReservation.ValidateConfirmationPageForBonusOrPointsType("", TestContext, Constants.pointstype, Constants.VCP, false);
        }


        [TestMethod]
        [TestCategory("Points Reservation"), TestCategory("Full Regression")]
        [TestProperty("TestDescription", "Point Type Reservation_To Verify All Functionalities In Reservation Confirmation Page_Sampler Owner")]
        public void PBI_60326_ConfirmationPageFunctionalitiesForSampler()
        {
            Login(TestContext, 75, "Arvact", "", "default");

            PointsReservation.ValidateConfirmationPageForBonusOrPointsType("", TestContext, Constants.pointstype, Constants.SAMPLER, true);
        }


        [TestMethod]
        [TestCategory("Points Reservation"), TestCategory("Full Regression")]
        [TestProperty("TestDescription", "Submit Button is Removed Once Clicked for Save My Points")]
        public void PBI_34040_SubmitButtonRemoved()
        {
            Login(TestContext, 76, "Arvact", "", "default");

            PointsReservation.ValidateSavePointsButtonIsRemoved("", TestContext, false);
        }

        
    }

        
}
