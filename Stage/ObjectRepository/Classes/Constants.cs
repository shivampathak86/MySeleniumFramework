

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace BlueGreenOwner
{
    public static class Constants
    {

        public static string CardNumber = string.Empty;
        public static string cvv = string.Empty;

        public static string Firstname_CP = string.Empty;
        public static string LastName_CP = string.Empty;
        public static string CpMemberID = string.Empty;

        //changes done by Fathima
        public static string expirationMonthNumber = string.Empty;

        public static string expirationMonthNumber_RentAdditional = "2";
        public static string expirationYear = string.Empty;

        public static string expirationDate_MakeAPayment= string.Empty;

        public static string RoutingNo = string.Empty;
        public static string BankAccountNo = string.Empty;

        //public static string[] FundSourceId= {};
        //public static string[] FundSourcePassword= {};

        public static string FundSourceId = string.Empty;
        public static string FundSourcePassword = string.Empty;

        //public string[] FundSourceStageID = { "Bluegree963", "Bluegree564" };
        //public  string[] FundSourceStagePwd = { "Bluegree@963", "Bluegreen@564" };

        public static string FundSourceStageID = "Bluegree963";
        public static string FundSourceStagePwd = "Bluegree@963";

        //public static string[] FundSourceProdID = { "mravisha" };
        //public static string[] FundSourceProdPwd = {"Dec_1967"};

        public static string FundSourceProdID = "spathak" ;
        public static string FundSourceProdPwd = "Bluegreen@5555" ;

        public static List<String> Locationswith7Nights = new List<String>() {"Montana","Big Sky","Alabama","GulfShores",""};
        public static string SevenNights = "7";
        //PROD variable1
        //public static string ProdCardNumber = "4398820004102995";
        //public static string ProdCvv = "273";

        public static string VCP = "VCPREMIER";
        public static string VCNP = "VCNONPREMIER";
        public static string SAMPLER = "SAMPLER";

        public static string WesternUnionSpeedpayPage = "WesternUnionSpeedPayPage";
        public static string makeAPaymentPage = "Make a payment Page";


        public static string InstallmentStatus = "Paid";
        public static string LoanType = "Inactive";

        public static string Arvact = "41496";

        public static string GreateEscapesArvact = "41496";

        public static string StgRoutingNo = "021000021";
        public static string StgBankAccountNo = "459879801223";

        public static string ProdRoutingNo = "0000000";
        public static string ProdBankAccountNo = "124356789";

        public static string Amount_ACHpayment = "1.00";

        public static int  NoOfMonthsInLMA = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfMonthsInLMA"]);
        public static int screenShotNameLength = 250;

        public static string StageTestDateExcel = Directory.GetCurrentDirectory() + @"\TestData.xlsx";
        public static string ProdTestDateExcel = Directory.GetCurrentDirectory() + @"\ProdTestData.xlsx";

        public static string TestDataFile = string.Empty;
        public static void InitializeEnvironmentSpecificConstants()
        {
            if (ConfigurationManager.AppSettings["ENVIRONMENT"].Contains("STAGE")|| ConfigurationManager.AppSettings["ENVIRONMENT"].Contains("STAGE_INT"))
            {

                CardNumber = StageCardNumber;
                cvv = StageCVV;
                FundSourceId = FundSourceStageID;
                FundSourcePassword = FundSourceStagePwd;

                //changes done by Fathima
                expirationMonthNumber = StageExpirationMonthNumber;
                expirationYear = StageExpirationYear;
                expirationDate_MakeAPayment = StgExpirationDate_MakeAPayment;

                RoutingNo = StgRoutingNo;
                BankAccountNo = StgBankAccountNo;
                TestDataFile = StageTestDateExcel;

                Firstname_CP = StgFirstname_CP;
                LastName_CP = StgLastName_CP;
                CpMemberID = StgCpMemberID;

            }
            else if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("PRODUCTION"))
            {
                CardNumber = ProdCardNumber;
                cvv = ProdCvv;
                FundSourceId = FundSourceProdID;
                FundSourcePassword = FundSourceProdPwd;

                //changes done by Fathima
                expirationMonthNumber = ProdexpirationMonthNumber;
                expirationYear = ProdexpirationYear;
                expirationDate_MakeAPayment = ProdExpirationDate_MakeAPayment;

                RoutingNo = ProdRoutingNo;
                BankAccountNo = ProdBankAccountNo;
                TestDataFile = ProdTestDateExcel;

                Firstname_CP = ProdFirstname_CP;
                LastName_CP = ProdLastName_CP;
                CpMemberID = ProdCpMemberID;


            }


        }


        public static string StgFirstname_CP = "Test";
        public static string StgLastName_CP = "AutomationUser";
        public static string StgCpMemberID = "AutomationUser";

        public static string ProdFirstname_CP = "Fathima";
        public static string ProdLastName_CP = "Test";
        public static string ProdCpMemberID = "FXT78910";


        //  //////PROD variable2
        public static string ProdCardNumber = "4398820004103001";
        public static string ProdCvv = "336";
        public static string ProdexpirationMonthNumber = "02";
        public static string ProdexpirationYear = "2020";

        public static string expirationMonthNumber_ChoicePrivilege = "2";

        //  ////PROD variable3
        //  // public static string CardNumber = "4398820004102987";
        //  //public static string cvv = "587";

        //  //PROD variable4
        ////  public static string CardNumber = "4398820004103019";
        // // public static string cvv = "63";

        //  //   stage variable
        public static string StageCardNumber = "4111111111111111";
        public static string StageCVV = "444";
                       
        public static int AmountToPrepay = 1;
        public static int veryshortLoadTime = 20;
        public static int shortLoadTime = 20;
        public static int medLoadTime = 40;
        public static int longLoadTime = 100;
        public static int veryLongLoadTime = 120;
        public static string screenshotImageType = ".jpeg";
        public static string movieType = ".wmv";
        public static string FullName = "Automation";
        public static string Name = "Automation";

        public static string password = "hut44#";

        public static int Num_Records_PWl_Dashboard = 5;
        public static int Num_Records_PWl_RequestHistory = 5;
        public static int Index = 3;
        public static int Index_RentAdditional = 1;
        public static string RequestCancelled = "request cancelled";


        public static string StgExpirationDate_MakeAPayment = "10/22";

        public static string ProdExpirationDate_MakeAPayment = "02/20";


        public static int RenewMyTPIndex = 10;
        public static string zipcode = "33324";
        public static string expirationMonth = "February";

        //changes done by Fathima

        // public static string expirationMonthNumber = "12";
        public static string StageExpirationMonthNumber = "12";

        //public static string expirationYear = "2028";
        public static string StageExpirationYear = "2028";

        public static string feeForSavingPoints = "50.00";
        public static string currency = "$";
        public static string StepFailed = "Failed- ";
        public static string StepNA = "NA- ";
        public static string Error = "ExceptionOccured-";
        public static string valSpecialRequest = "This is the input for Special Request";
        public static string MsgCancellationWarning = "Cancellations without the Points Protection Plan will result in a $75 fee or a loss of Points used for your reservation.";
        public static string MsgnotEnoughPoints = "You don't have enough eligible points for this reservation. Please update your search or consider borrowing points.";
        public static string CardType = "Visa";
        public static string MsgCancellationConfirmation = "The reservation below has been cancelled.You will also receive an email confirmation of your cancellation.";
        public static string KeyOutputDetailsFileName = "/KeyDataOuput.txt";

        public static string ConfirmationDetailsFileName = "/ConfirmationDetails.txt";

        public static string InfoMsgForCancelOutsideGracePeriod = "This reservation is subject to cancellation fee. Once payment is provided, the Points used for this reservation will be returned to your account. Please provide payment information below.No cancellation will be processed without payment of fee and Points will be forfeited if your reservation is not cancelled, even if it is not used.";
        public static string InfoMsgForCancelWithInGracePeriodWithOutPPP = "This cancellation is within one day from when you made your reservation and therefore will not be subject to any cancellation fees. All Points/funds will be returned to your account if you cancel it now.";

        public static string InfoMsgForCancelWithInGracePeriodWithPPP = " This reservation is being canceled within the 24 hour grace period.You may cancel this reservation at no charge, all Points used for the reservation and the cost of the Points Protection Plan will be refunded.";

        public static string Browser = "Chrome";
        public static string One = "1";

        public static string Seven = "7";
        public static string Two = "2";
        public static string CancelWithInGracePeriodPointsReservationInputFile = @"\InputForPointTypeCancelWithInGracePeriod.txt";
        public static string CancelWithInGracePeriodBonusReservationInputFile = @"\InputForBonusTypeCancelWithInGracePeriod.txt";

        public static string Booked = "BOOKED";
        public static string Address = "Address";

        public static string City = "FortLauderDale";
        public static string EditCity = "Munster";
        public static string Email = "Email@Email.com";
        public static string Firstname = "Test";
        public static string LastName = "AutomationUser";
        public static string NoOfGuests = "2";

        public static string GuestFirstName = "TestGuest";
        public static string GuestLastName = "AutomationUser";

        public static string StreetAddress = "SouthEast 17th street";

        public static string Phone = "1231234567";

        public static string MessageForOnenightStay = "Several resorts offer one night Bonus Time stays, but require payment for two nights. Please adjust your search to at least two nights to see more vacation options.";

        public static string MessageForOnenightStayBonusTimeReservationPage = "One night stays are accepted at this resort/destination but there is a two night minimum charge.";
        public static string MessageFor7nightStaySearchResultsPage = "The resort or destination you selected requires a 7 night stay.Your search has been updated automatically.We have provided a list of available destinations that match your original check in date and duration.";


        public static string PWLConfirmationMessage = "Congratulations your request has been submitted. You will receive a booking confirmation email if your requested vacation is available 11 months from your requested check in date. If your requested reservation is not available you will see the status updated 11 months from your requested check-in date.";
        public static string UpdatePWLConfirmationMessage = "Congratulations your request has been updated.";

        public static string PWLPendingStatus = "Request Pending";

        public static string CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");

        public static string ProtectedStatus = "protected";

        public static string pointstype = "points";
        public static string bonustype = "bonus time";


        public static string multipleEmailIds = "Shivam.Pathak@bluegreenavcations.com;Shivam.Pathak@bluegreencorp.com";

        public static string EmailSentMsg = "Email was sent.";

         public static string Country = "UNITED STATES";
        public static string GreatEscapesCountry = "United States of America";

        public static string EditGuestFirstName = "1stEdited4";
        public static string EditGuestLastName = "Lstnameedited4";
        public static string EditPhone = "5673451234";
        public static string EditEmail = "emailedited1@email.com";
        public static string EditvalSpecialRequest = "Edited";
        public static string identifierForParentinLMAPage = "";

        public static int numberOfMonthsToBeDisplayed = 3;

        public static string State = "Florida";
        public static string StateCode = "CT";
        public static string EditState = "Indiana";
        public static string Hawaii = "Hawaii";
        public static string Friend = "Friend";
        public static string Family = "Family";
        public static string MessageInputForReferAFriend = "Greetings.You are referred to recieve some rewards";
        public static string EmailForReferAFriend = "Shivam.Pathak@gmail.com";
        public static string ThankyouMessageRewards = "Thank you! Your Qualified Referral has been successfully registered with the Bluegreen Rewards program. When you are ready to send them a special vacation offer, simply go to the Account Activity tab and check their name to send your registered friend a special offer!";

        public static string SavedSearchName1 = "Automation-SS1";

        public static string SavedSearchName2 = "Automation-SS2";

        public static string ErrormessageNonMatchingLastName = "UNFORTUNATELY WE ARE UNABLE TO LOCATE YOUR LOAN WITH THE INFORMATION PROVIDED.PLEASE CONTACT 800-456-2582 FOR MORE INFO ABOUT YOUR MORTGAGE.";
        public static string headingmaintenaceFeeDashboard = "Your Maintenance Fee Dashboard";

        public static string ZeroDollar = "$0.00";
        public static string NoActvityMsg = " You do not have any account activity to track for the year selected";

        public static string WeapologizeMessagePaymentsPage = "We apologize for the inconvenience, but your account does not qualify for online payments at this time.Please contact us at 800.456.CLUB (2582) to learn how to enable your account.";

        public static string NotInGoodStandingMsg = "- User not in good Standing / Not qualified for online access";

        public static string SaveYourPointsText = "Save Your Vacation Points and Purchase Coast Tripsetter Points";

        public static string ConvertYourPointsText = "Convert Your Bluegreen Vacation Points to Coast Tripsetter Points3";

        public static string GoCampingText = "Go camping under the stars with Coast to Coast,the leading network of membership RV Resort campgrounds in North America!";

        public static string WithPPP = "WITHPPP";
        public static string WithOUTPPP = "WITHOUTPPP";

        public static string NameOfCardHolder = "test";
        public static string FundSourceLoginId = "Bluegree963";
      //  public static string FundSourcePassword = "Bluegreen@963";
        public static string SearchVisibleText = "Authorization";
        public static string Rentadditionalarvact = "775700";

        //public static string hidePassword = "show-password";
        public static string hidePassword = "hide-password";


    }
}