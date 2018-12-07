
------This is Readme file for this project. Please go through each points for this file and make mentioned changes. In case of any doubt please reach out to admin of this project.------------

#Most of the test case are data driven using excel please install AccessDatabasengine program in your system before running test. You find the program version at below link. In case of any issues accessing below link reach out to admin of this group
https://bluegreenvacations.sharepoint.com/sites/QA-Automation/Shared%20Documents/Forms/AllItems.aspx?id=%2Fsites%2FQA%2DAutomation%2FShared%20Documents%2FReadingExcel%2FAccessDatabaseEngine%2Ezip&parent=%2Fsites%2FQA%2DAutomation%2FShared%20Documents%2FReadingExcel
#You need to make sure before running the scripts below things 
1. Check the enviorment configuration , which enviorment scripts are pointing. This can be done by chanding the <Environment>.config file to correct enviorment  where <Enviornment> means - Stage, Stag2 and Production.
2. Change the TestResult key path to your system's path in <Environment>.config.
3. Make sure you check the data before running in Production environment , that it should not be pointing to any real owner data.
4. When take latest changes from source control for the first time or mapping source control repository for the first time make sure you do "restore nuget" at solution level.
5. When adding Nuget or restoring nugeton VM make sure you have added proxy server adddress in IE otheriwse Nuget will not be added or restored.
#Change value of string variable <!--multipleEmailIds in Constant.cs under  Objectrepository Project--> to your email address.
#TestCase_60029_7NightsStay <!-- Make sure test data should have enough points and change check in to near date instead of farther date-->
#TestCase_60215_PointsReservationSearchByDatesNoPPP <!-- Make sure test data should have enough points and change check in date and check out date-->
6.Make sure you have added all production URL's before running in production environment
7.Make sure you have given valid credit card details in Constants.cs before running in production for the following test cases
                   i.PBI87926_ValidatePointsConversionToChoicePrivilegePoints
				   ii.PBI97024_VerifyRentAdditionalPoints
8.Make sure you have given valid fundsource credentials in Constants.cs and the arvact for which you are checking transaction before running in production for the following test cases
                    i.PBI97024_VerifyRentAdditionalPoints
					ii.PBI92486_VerifyGreatEscapesReservationIsReflectedInFundSource