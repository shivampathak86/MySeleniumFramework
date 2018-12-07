using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using OpenQA.Selenium.Interactions;
using NLog;
using OpenQA.Selenium.Support.PageObjects;

using System.Threading;
using System.Configuration;
//using Microsoft.Expression.Encoder.ScreenCapture;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Globalization;

using POM.Classes;
using AventStack.ExtentReports;

namespace BlueGreenOwner
{
    //THIS IS THE TESTBASE CLASS USED BY TESTMETHODS.
    public class TestBaseClass : Utilities.Screenshot
    {


        // add code for browser factory here in setup

        public static IWebDriver baseDriver;
        public static string browser;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //#####################ERRORLOG#######################
        //this variable used to create log filename format "
        //for example filename : ErrorLogYYYYMMDD
        public static String sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        public static string sYear = DateTime.Now.Year.ToString();
        public static string sMonth = DateTime.Now.Month.ToString();
        public static string sDay = DateTime.Now.Day.ToString();
        public static string sErrorTime = sYear + sMonth + sDay;
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        //################################################################

        public static string Destination;
        public static string day;
        public static string SelectDates;
        public static string CheckInDate;
        public static string CheckoutDate;
        public static string ValMonthandYear;
        public static string WheeelChairAccess;
        public static string ValNumNights;
        //##############Excel Test Result fields

        public static string testResultsFolder = ConfigurationManager.AppSettings["TestResultsFolder"];
        public static string confirmationDetailsFolder = ConfigurationManager.AppSettings["ConfirmationDetailsFilePath"];
        public static string serialNumber = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
        public static string currentconfirmationNumber = "";
        public static string currentcheckInDate = "";
        public static string currentcheckOutDate = "";
        public static string currentAmount = "";
        public static string currentPPPStatus = "";
        public static string currentResortName = "";
        public static string currentType = "";
        public static string confirmationdate = "";
        public static bool WithPPP = true;
        public static int numberOfRowsInCurrentReservationsTable = 0;
        public static int SlNo = 1;
        public static int destnum = 1;
        public static int index = 0;



        public static string pwlcheckoutdate = "";
        public static string pwlresortName = "";
        public static string pwlcheckindate = "";
        public static string pwlreqId = "";
        public static string pwlguestsnum = "";
        public static string pwlroomtypeVal = "";
        public static string pwleditguestsnum = "";
        public static string pwleditroomtypeVal = "";
        public static string pwleditedreqId = "";
        public static string pwleditcheckindate = "";
        public static string pwleditcheckoutdate = "";

        public static string TestEnvironment = ConfigurationManager.AppSettings["ENVIRONMENT"];

        //Search from home page
        public static string availableLocations = null;
        public static string availableResortNames = null;
        public static string HandiCapFlag = "0";
        //save points list

        public static List<string> ListPointsToBeSaved = new List<string> { };
        public static List<string> ListPointTypeTobeSaved = new List<string> { };
        public static List<string> ListExpDatetobeSaved = new List<string> { };
        public static List<string> ListActionsToBeSaved = new List<string> { };
        public static string testcaseID = "";

        //list for storing confirmationDetails for cancel card
        public static List<string> confirmationDetailLine = new List<string>();
        public static DataTable tab = new DataTable();
        public static string guestCheckingName;
        private static string specialrequests;
        public static string UrlForCurrentReservation = "";

        public static int SearchFromHomePage(IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults, SearchResultsPage SearchResultsObj, string InputDestination)
        {
            //actually determines which button should be to proceed based on the inventory displayed
            availableLocations = null;
            //List<string> availableResortNames = new List<string>();
            availableResortNames = null;
            int executeSearchResults = 0;
            int indexnum = 0;

            Random rnd = new Random();
            if (ListAvailableDestinationsInSearchResults.Count > 0)
                destnum = rnd.Next(1, ListAvailableDestinationsInSearchResults.Count);


            try
            {
                if ((ListAvailableDestinationsInSearchResults.Count > 0))
                {
                    //Serach Results displayed for all destinations/states
                    foreach (IWebElement resortLocationElement in ListAvailableDestinationsInSearchResults)
                    {
                        //All destinations
                        if (InputDestination.ToLower().Replace(" ", "").Equals("alldestinations"))
                        {
                            if ((destnum.Equals(indexnum + 1)))
                            {
                                resortLocationElement.Click();
                                baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.shortLoadTime);

                                // Thread.Sleep(2000);

                                availableLocations = availableLocations + "," + resortLocationElement.Text.Trim();

                                //Identify dynamically generated resort names and show resort availablity button
                                string resortId = resortLocationElement.Text.Replace(" ", "").Trim().ToLower();
                                int index = resortId.IndexOf("resorts");
                                int l = resortId.Length - 1;
                                resortId = resortId.Remove(index);
                                SearchResultsObj.XpathForResortNames = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForResortNameLastpart;


                                IReadOnlyCollection<IWebElement> ListResortNames = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForResortNames);
                                if (ListResortNames.Count > 0)
                                {
                                    foreach (IWebElement resortNameElement in ListResortNames)
                                    {
                                        availableResortNames = availableResortNames + "," + resortNameElement.Text.Trim();
                                        SearchResultsObj.lastResortNameElement = resortNameElement;
                                        SearchResultsObj.SRPResortName = SearchResultsObj.lastResortNameElement.Text.Trim();
                                    }
                                    SearchResultsObj.XpathForShowResortAvailalbilityButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForShowResortAvailabiltyLastPart;
                                    SearchResultsObj.locatorForShowResortAvailalbilityButton = By.XPath(SearchResultsObj.XpathForShowResortAvailalbilityButton);
                                    SearchResultsObj.XpathForSearchResultsTable = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart;
                                    SearchResultsObj.locatorForSearchResultsTable = By.XPath(SearchResultsObj.XpathForSearchResultsTable);
                                    SearchResultsObj.XpathForMultiResultBookButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultBookButtonLastPart;
                                    SearchResultsObj.locatorForMultiResultBookButton = By.XPath(SearchResultsObj.XpathForMultiResultBookButton);
                                    SearchResultsObj.XpathForMultiResultPointsLink = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultPointsLinkLastPart;
                                    SearchResultsObj.locatorForMultiResultPointsLink = By.XPath(SearchResultsObj.XpathForMultiResultPointsLink);
                                    SearchResultsObj.XpathForMultiResultStandardPointsTable = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultStandardPointsTableLastPart;
                                    SearchResultsObj.locatorForMultiResultStandardPointsTable = By.XPath(SearchResultsObj.XpathForMultiResultStandardPointsTable);

                                    executeSearchResults = 3;// resort names and location displayed
                                    break;
                                }
                            }

                        }//Endif//All Destination
                        else
                        {    //ex:search by other than all destinations

                            availableLocations = availableLocations + "," + resortLocationElement.Text.Trim();
                            string resortId = resortLocationElement.Text.Replace(" ", "").Trim().ToLower();
                            int index = resortId.IndexOf("resorts");
                            int l = resortId.Length - 1;
                            resortId = resortId.Remove(index);
                            SearchResultsObj.XpathForResortNames = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForResortNameLastpart;
                            IReadOnlyCollection<IWebElement> ListResortNames = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForResortNames);

                            if (ListResortNames.Count > 0)
                            {

                                foreach (IWebElement resortNameElement in ListResortNames)
                                {

                                    availableResortNames = availableResortNames + "," + resortNameElement.Text.Trim();
                                    SearchResultsObj.lastResortNameElement = resortNameElement;
                                    SearchResultsObj.SRPResortName = SearchResultsObj.lastResortNameElement.Text.Trim();
                                }
                                SearchResultsObj.XpathForShowResortAvailalbilityButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForShowResortAvailabiltyLastPart;
                                SearchResultsObj.locatorForShowResortAvailalbilityButton = By.XPath(SearchResultsObj.XpathForShowResortAvailalbilityButton);
                                SearchResultsObj.XpathForSearchResultsTable = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart;
                                SearchResultsObj.locatorForSearchResultsTable = By.XPath(SearchResultsObj.XpathForSearchResultsTable);
                                SearchResultsObj.XpathForMultiResultBookButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultBookButtonLastPart;
                                SearchResultsObj.locatorForMultiResultBookButton = By.XPath(SearchResultsObj.XpathForMultiResultBookButton);
                                SearchResultsObj.XpathForMultiResultPointsLink = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultPointsLinkLastPart;
                                SearchResultsObj.locatorForMultiResultPointsLink = By.XPath(SearchResultsObj.XpathForMultiResultPointsLink);
                                SearchResultsObj.XpathForMultiResultStandardPointsTable = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultStandardPointsTableLastPart;
                                SearchResultsObj.locatorForMultiResultStandardPointsTable = By.XPath(SearchResultsObj.XpathForMultiResultStandardPointsTable);
                                executeSearchResults = 4;
                                break;

                            }
                        }
                        ++indexnum;
                    }//for each
                }
            }
            catch (Exception e)
            {

                executeSearchResults = 0;

                throw e;

            }
            return executeSearchResults;
        }


        //write test results to file
        public static void WriteTestResults(TestContext testContextInstance, string msg)
        {
            msg = myTI.ToTitleCase(msg);
            int row = testContextInstance.DataRow.Table.Rows.IndexOf(testContextInstance.DataRow);
            string path = System.Configuration.ConfigurationManager.AppSettings["TestResultsFolder"] + @"\TestResults" + serialNumber + @"\" + testContextInstance.TestName + "_Iteration_" + row.ToString() + @"\TestResult.txt";
            var directory = Path.GetDirectoryName(path);

            Directory.CreateDirectory(directory);
            StreamWriter sw = new StreamWriter(directory + @"/TestResult.txt", true);
            try
            {
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                sw.Close();
                logger.Error(e.StackTrace);


            }
        }
        // INITIALIZES TEST METHODS with browser,url and title
        public static bool SetUp(TestContext testContextInstance, string Browser)
        {
            bool flag = false;
            Constants.InitializeEnvironmentSpecificConstants();
            try
            {


                switch (Browser.ToLower())
                {

                    case "chrome":
                        var ChromeOptions = new ChromeOptions();
                        ChromeOptions.AddArgument("start-maximized");
                        ChromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                        ChromeOptions.AcceptInsecureCertificates = true;
                        baseDriver = new ChromeDriver(ChromeOptions);
                        // baseDriver.Manage().Cookies.DeleteAllCookies();


                        break;
                    case "firefox":
                        baseDriver = new FirefoxDriver();
                        // baseDriver.Manage().Window.Maximize();
                        break;
                        //case "IE":
                        //    baseDriver = new InternetExplorerDriver();
                        //    //System.Set("webbaseDriver.ie.baseDriver", "pathofchromebaseDriver\\IEDriverServer.exe");
                        //    baseDriver.Manage().Window.Maximize();
                        //    break;
                }

                baseDriver.Manage().Cookies.DeleteAllCookies();

                flag = true;
            }
            catch (Exception e)
            {


                throw e;

            }
            return flag;

        }
        public static bool fillCreditCardDetailsPPPPage(PointsProtectionPlanPage PPPObj, TestContext testContextInstance)
        {
            try
            {
                Assert.IsTrue(isElementClickable(PPPObj.textBox_CreditCardName, Constants.medLoadTime), "The Credit Card Name was not shown on PPP page");
                //Thread.Sleep(2000);
                PPPObj.textBox_CreditCardName.SendKeys(Constants.FullName);
                //Thread.Sleep(2000);
                PPPObj.TextBox_CreditCardNumber.SendKeys(Constants.CardNumber);
                PPPObj.TextBox_CVV.SendKeys(Constants.cvv);
                PPPObj.Select_ExpirationMonth.Click();
                PPPObj.Select_MonthDecember.Click();
                PPPObj.Select_ExpiratonYear.Click();
                PPPObj.Select_ExpiratonYearCurrent.Click();
                PPPObj.TextBox_ZipCode.SendKeys(Constants.zipcode);
                PPPObj.ChkBox_InternationalZipCode.Click();
                printOutputAndCaptureImage(testContextInstance, baseDriver, "The details were succesfully entered in PPP page");
                PPPObj.ChkBox_PPPAgreement.Click();
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }

        }


        public static bool PickdateUsingSendKeys(string dpath, string date)
        {
            bool Val = false;

            IWebElement hypehen = FindAnElementUsingDriver("xpath", ".//*[@id='site-content']//span[@class='input-group-addon']");

            try
            {
                IWebElement dateBox = FindAnElementUsingDriver("xpath", dpath);
                //dateBox.Click();
                // dateBox.Clear();
                Thread.Sleep(2000);
                date = Convert.ToDateTime(date).ToString("MM/dd/yyyy");
                dateBox.Click();
                dateBox.SendKeys(date);
                hypehen.Click();
                Thread.Sleep(5000);

                Val = true;


            }
            catch (Exception e)
            {
                Val = false;
                // //ErrorLog Err = new //ErrorLog();
                ////Err.LogError(resultsFolderpath, e.Message, "TestBase:PickdateUsingSendKeys");
            }
            return Val;
        }




        public static void printOutputAndCaptureImage(TestContext testContextInstance, IWebDriver baseDriver, string stepName)
        {
            try
            {
                TakeImage(testContextInstance, baseDriver, stepName);
                WriteTestResults(testContextInstance, stepName);

            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace + "\r\n" + e.Message);

            }

        }

        public static void initializeTestScripts(string destination, string selectdates, string wheelchair, TestContext testContextInstance)
        {
            //clear confirmation deatils from each test case.
            TestBaseClass.currentconfirmationNumber = "";
            TestBaseClass.currentcheckInDate = "";
            TestBaseClass.currentcheckOutDate = "";
            TestBaseClass.currentPPPStatus = "";
            TestBaseClass.Destination = "";

            switch (destination.ToLower())
            {
                case "no":
                    TestBaseClass.Destination = "AllDestinations";
                    break;

                case "alldestinations":
                    TestBaseClass.Destination = "AllDestinations";
                    break;

                default:
                    TestBaseClass.Destination = destination;
                    break;

            }

            switch (selectdates.ToLower())
            {
                case "no":
                    TestBaseClass.SelectDates = "no";
                    break;

                case "yes":
                    TestBaseClass.SelectDates = "yes";
                    TestBaseClass.CheckInDate = Convert.ToDateTime(ReadData(66, "CheckInDate")).ToString("M /dd/yyyy");
                    TestBaseClass.CheckoutDate = Convert.ToDateTime(ReadData(66, "CheckOutDate")).ToString("M/dd/yyyy");
                    break;

                case "1night":
                    TestBaseClass.SelectDates = "yes";
                    TestBaseClass.CheckInDate = Convert.ToDateTime(ReadData(66, "CheckInDate")).ToString("M/dd/yyyy");
                    TestBaseClass.CheckoutDate = Convert.ToDateTime(TestBaseClass.CheckInDate).AddDays(1).ToString("M/dd/yyyy");
                    break;

                case "7nightstay":
                    TestBaseClass.SelectDates = "yes";
                    TestBaseClass.CheckInDate = Convert.ToDateTime(ReadData(70, "CheckInDate")).ToString("M/dd/yyyy");
                    TestBaseClass.CheckoutDate = Convert.ToDateTime(TestBaseClass.CheckInDate).AddDays(7).ToString("M/dd/yyyy");
                    break;

            }


            switch (wheelchair.ToLower())
            {
                case "no":
                    TestBaseClass.WheeelChairAccess = "no";
                    break;
                case "yes":
                    TestBaseClass.WheeelChairAccess = "yes";
                    break;
            }

        }



        public static bool EnterSearchCriteriaFromHomePage2(string selectdates, string wheelchairaccess, HomePage homePageObj, string startDate, string endDate, string location)

        {
            bool flag = false;
            try
            {


                // Thread.Sleep(2000);// this nees to  be removed 
                bool flag1 = false;//for select destination
                bool flag2 = false;//flag for select dates
                bool locFound = false;
                switch (wheelchairaccess.ToLower())
                {
                    case "yes":
                        TestBaseClass.HandiCapFlag = "1";
                        break;
                }

                switch (location.ToLower())
                {
                    case "alldestinations":
                        //Thread.Sleep(4000);

                        homePageObj.SelectDestination.Click(); //this needs to be changed to combox
                        homePageObj.AllDestinationsEle.Click();
                        extentTest.Info("All destinations is clicked");
                        flag1 = true;
                        break;

                    default:
                        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                        homePageObj.SelectDestination.Click();
                        location = location.Trim();
                        homePageObj.DestinationTextBox.SendKeys(myTI.ToTitleCase(location));
                        homePageObj.DestinationTextBox.SendKeys(Keys.Return);

                        homePageObj.MonthDropDown.Click();

                        if (IsElementPresent(homePageObj.locatorForMonthEntry, baseDriver))
                            homePageObj.MonthEntry.Click();
                        extentTest.Info("Month is selected");

                        homePageObj.nightsDropDown.Click();
                        extentTest.Info("Nights is selected");

                        if (IsElementPresent(homePageObj.locatorFornightsEntry, baseDriver))
                            homePageObj.nightsEntry.Click();
                        extentTest.Info("Nights is selected");

                        TestBaseClass.ValMonthandYear = homePageObj.SelectedMonth.Text.Replace("\r", "").Replace("\n", "").Trim();

                        foreach (string loc in Constants.Locationswith7Nights)
                        {

                            if (location.ToLower().Equals(loc.ToLower()))
                            {
                                locFound = true;
                                break;
                            }
                        }
                        if (locFound)
                            TestBaseClass.ValNumNights = Constants.SevenNights;
                        else
                            TestBaseClass.ValNumNights = homePageObj.SelectedNightsEntry.Text.Replace("\r", "").Replace("\n", "").Trim();
                        flag1 = true;
                        break;
                }

                //select dates
                if ((selectdates.ToLower().Equals("yes")))
                {

                    if ((TestBaseClass.Pickdate(homePageObj.InputCheckInDate, startDate, homePageObj.calenderYearLab, homePageObj.calenderMonthLab, homePageObj.calenderNextArrow, homePageObj.calenderPrevArrow))
                    && (TestBaseClass.Pickdate(homePageObj.InputCheckOutDate, endDate, homePageObj.calenderYearLab, homePageObj.calenderMonthLab, homePageObj.calenderNextArrow, homePageObj.calenderPrevArrow)))
                        flag2 = true;
                }
                else
                    flag2 = true;

                if (flag1 && flag2)//select dates and select location is success
                    flag = true;
                else
                    flag = false;
                return flag;
            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    //extentTest.Fail(exception.InnerException.ToString());
                    // Assert.Fail(exception.InnerException.ToString());
                }
                else
                {


                    //extentTest.Error(exception.Message);
                    throw exception;

                }

            }

            return flag;

        }


        //Capture image and capture output results

        public static void TakeImage(TestContext testContextInstance, IWebDriver baseDriver, string stepName)
        {


            stepName = myTI.ToTitleCase(stepName);

            int row = testContextInstance.DataRow.Table.Rows.IndexOf(testContextInstance.DataRow);
            string TestResultDirectory = System.Configuration.ConfigurationManager.AppSettings["TestResultsFolder"] + @"\TestResults" + serialNumber + @"\" + testContextInstance.TestName + "_Iteration_" + row.ToString() + @"\Screenshots";
            try
            {
                //include code for other types as well.
                ImageFormat format = ImageFormat.Jpeg;
                OpenQA.Selenium.Screenshot ss = ((ITakesScreenshot)baseDriver).GetScreenshot();
                string substr = "1";

                if (stepName.Length >= Constants.screenShotNameLength)
                    substr = stepName.Substring(0, Constants.screenShotNameLength);
                else
                    substr = stepName;
                //Create directory to save screenshots            
                if (!System.IO.Directory.Exists(TestResultDirectory))
                {
                    System.IO.Directory.CreateDirectory(TestResultDirectory);
                    Directory.SetCurrentDirectory(TestResultDirectory);
                    ss.SaveAsFile(substr + "." + format);


                }
                else
                {
                    ss.SaveAsFile(substr + "." + format);
                }

                //baseDriver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Exception").Build());


            }




        }



        //*************************************************************************************************************************************************************************
        public static bool IsAllInputFieldsDisplayedNegativeCase(TestContext testContext, List<string> fieldName, string pageName, List<By> locatorForField)
        {
            //Used to do feild validation.Checks whther fields are diplayed and prints out put
            bool flag = true;
            try
            {
                for (int i = 0; i < fieldName.Count; i++)
                {
                    if (!(isElementVisible(locatorForField[i], Constants.veryshortLoadTime)))
                    {
                        extentTest.Info("The field " + fieldName[i] + " was not present on " + pageName);
                    }
                    else
                    {
                        flag = false;
                        extentTest.Info("The field " + fieldName[i] + " was present on " + pageName);

                    }
                }

            }
            catch (Exception e)
            {
                // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContext, "Exception").Build());

                flag = false;
                throw e;
            }

            return flag;

        }
        //**********************************************************************************************************************************************************************************

        public static bool IsAllInputFieldsDisplayed(TestContext testContext, List<string> fieldName, string pageName, List<By> locatorForField)
        {
            bool flag = true;

            try
            {
                for (int i = 0; i < fieldName.Count; i++)
                {
                    if (!(isElementVisible(locatorForField[i], Constants.medLoadTime)))
                    {
                        flag = false;
                        extentTest.Info("The " + fieldName[i] + " was not displayed in " + pageName);

                    }
                    else
                    {
                        extentTest.Info("The " + fieldName[i] + " was  displayed in " + pageName);
                    }
                }

            }
            catch (Exception e)
            {
                flag = false;
                throw e;
                // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContext, "Exception").Build());

            }
            return flag;
        }





        public static IWebElement FindAnElementUsingDriver(String IdorXpathorTagName, string identifierstring)
        {
            IWebElement ele = null;
            IdorXpathorTagName = IdorXpathorTagName.ToLower().Trim();
            try
            {
                if (IdorXpathorTagName.Equals("xpath"))
                    ele = baseDriver.FindElement(By.XPath(identifierstring));

                else if (IdorXpathorTagName.Equals("id"))
                    ele = baseDriver.FindElement(By.Id(identifierstring));

                else if (IdorXpathorTagName.Equals("tagname"))
                    ele = baseDriver.FindElement(By.TagName(identifierstring));

                return ele;
            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString());
                    throw exception.InnerException;
                    // Assert.Fail(exception.InnerException.ToString());
                }
                else
                {
                    extentTest.Fail(exception.Message);
                    throw exception;
                    // Assert.Fail(exception.Message);
                }
            }
        }




        public static IReadOnlyCollection<IWebElement> FindElementsUsingDriver(String IdorXpath, string identifierstring)
        {
            IReadOnlyCollection<IWebElement> ListOfElements;
            IdorXpath = IdorXpath.ToLower().Trim();
            try
            {
                if (IdorXpath.Equals("xpath"))

                    ListOfElements = baseDriver.FindElements(By.XPath(identifierstring));
                else

                    ListOfElements = baseDriver.FindElements(By.Id(identifierstring));
                return ListOfElements;
            }
            catch (Exception e)
            {
                //ErrorLog Err = new //ErrorLog();
                //Err.LogError(resultsFolderpath, e.Message.ToString(), "TestBase:FindAnElementusingDriver");
                return null;
                throw e;
                // extentTest.Error(e.Message);

                // log an error

            }
        }

        public static ReadOnlyCollection<IWebElement> FindElementsUsingDriverUpdated(String IdorXpath, string identifierstring)
        {
            ReadOnlyCollection<IWebElement> ListOfElements;
            IdorXpath = IdorXpath.ToLower().Trim();
            try
            {
                if (IdorXpath.Equals("xpath"))

                    ListOfElements = baseDriver.FindElements(By.XPath(identifierstring));
                else

                    ListOfElements = baseDriver.FindElements(By.Id(identifierstring));
                return ListOfElements;
            }
            catch (Exception e)
            {
                //ErrorLog Err = new //ErrorLog();
                //Err.LogError(resultsFolderpath, e.Message.ToString(), "TestBase:FindAnElementusingDriver");
                //return null;
                extentTest.Error(e.Message);
                throw e;


            }
        }


        public static IReadOnlyCollection<IWebElement> FindElementsInsideAnotherUsingDriver(IWebElement parentEle, String IdorXpathorTagName, string identifierstring)
        {
            IReadOnlyCollection<IWebElement> ListOfElements = null;
            IdorXpathorTagName = IdorXpathorTagName.ToLower().Trim();
            try
            {
                if (IdorXpathorTagName.Equals("xpath"))

                    ListOfElements = parentEle.FindElements(By.XPath(identifierstring));

                else if (IdorXpathorTagName.Equals("id"))

                    ListOfElements = parentEle.FindElements(By.Id(identifierstring));

                else if (IdorXpathorTagName.Equals("tagname"))

                    ListOfElements = parentEle.FindElements(By.TagName(identifierstring));

                return ListOfElements;
            }
            catch (Exception e)
            {
                //ErrorLog Err = new //ErrorLog();
                //Err.LogError(resultsFolderpath, e.Message.ToString(), "TestBase:FindAnElementusingDriver");
                return null;


            }
        }

        public static ReadOnlyCollection<IWebElement> FindElementsInsideAnotherUsingDriverUpdated(IWebElement parentEle, String IdorXpathorTagName, string identifierstring)
        {
            ReadOnlyCollection<IWebElement> ListOfElements = null;
            IdorXpathorTagName = IdorXpathorTagName.ToLower().Trim();
            try
            {
                if (IdorXpathorTagName.Equals("xpath"))

                    ListOfElements = parentEle.FindElements(By.XPath(identifierstring));

                else if (IdorXpathorTagName.Equals("id"))

                    ListOfElements = parentEle.FindElements(By.Id(identifierstring));

                else if (IdorXpathorTagName.Equals("tagname"))

                    ListOfElements = parentEle.FindElements(By.TagName(identifierstring));

                return ListOfElements;
            }
            catch (Exception e)
            {
                
                throw e;
                

                
            }


        }

        public static IWebElement FindElementInsideAnotherUsingDriver(IWebElement parentEle, String IdorXpathorTagName, string identifierstring)
        {
            IWebElement Element = null;
            try
            {
               
                IdorXpathorTagName = IdorXpathorTagName.ToLower().Trim();
                if (IdorXpathorTagName.ToLower().Equals("xpath"))
                {
                    Element = parentEle.FindElement(By.XPath(identifierstring));
                    return Element;
                }
                else if (IdorXpathorTagName.ToLower().Equals("id"))
                {

                    Element = parentEle.FindElement(By.Id(identifierstring));
                    return Element;
                }

                else if (IdorXpathorTagName.ToLower().Equals("tagname"))
                {

                    Element = parentEle.FindElement(By.TagName(identifierstring));
                    return Element;

                }

                return null;
            }
            catch(NullReferenceException)
            {
                return Element;
            }
        }
            
            
        public static bool LogOff(TestContext testContextInstance)
        {
            bool flag = false;
            //  Thread.Sleep(10000);
            Actions act = new Actions(baseDriver);
            HomePage obj = new HomePage();
            PageFactory.InitElements(baseDriver, obj);
            try
            {
                if (isElementClickable(obj.logOffDiv, 20))
                {

                    act.MoveToElement(obj.logOffDiv).Perform();


                    if (isElementVisible(obj.locatorLogOffDivByXpath,Constants.shortLoadTime))
                    {


                        act.MoveToElement(obj.logOffDiv).Perform();

                        if (isElementVisible(obj.locatorSignoutBtnByXpath, Constants.shortLoadTime))
                        {


                            act.MoveToElement(obj.SignoutBtn).Perform();
                            obj.SignoutBtn.Click();
                            extentTest.Info("Sign out button is clicked");
                            baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond);

                            //Thread.Sleep(2000);
                            if (baseDriver.Url.Contains(ConfigurationManager.AppSettings["UrlForLogOff"]))
                            {
                                flag = true;
                                extentTest.Pass("LogOff was succesful", AttachScrenshot(baseDriver, testContextInstance, "LogOffSuccessfull").Build());

                            }
                        }
                    }
                }


                return flag;

            }
            catch (Exception e)
            {
                throw e;
                
            }
        }

        public static void EndExecutionRoutine()
        {
            try
            {
                baseDriver.Quit();

            }
            catch (Exception e)
            {
                extentTest.Info(e.Message);

            }
        }



        public static bool fillReferAFriendDetails(RewardsPage rewObj, TestContext testContextInstance)
        {
            GlobalObjects globalObj = new GlobalObjects(baseDriver);

            try
            {

                if ((isElementClickable(rewObj.firstName, Constants.shortLoadTime)))
                {
                    Random rnd = new Random();
                    int randomPhoneNum = 0000000000;
                    rewObj.firstName.SendKeys(Constants.FullName);
                    rewObj.lastName.SendKeys(Constants.LastName);
                    rewObj.emailAddress.SendKeys(rnd.Next().ToString() + Constants.EmailForReferAFriend);
                    Random r = new Random();

                    randomPhoneNum = r.Next(100000000, 999999999);
                    rewObj.telephone.Clear();
                    rewObj.telephone.SendKeys(randomPhoneNum.ToString() + "1");
                    rewObj.city.SendKeys(Constants.City);
                    rewObj.state.Click();
                    rewObj.stateTextBox.SendKeys(Constants.State);
                    rewObj.messageInput.SendKeys(Constants.MessageInputForReferAFriend);
                    rewObj.checkBox.Click();


                    // Thread.Sleep(2000);
                    extentTest.Info( "The details were entered in Invite A friend Page");
                    extentTest.Pass("Details were entered in Invite A friend Page", AttachScrenshot(baseDriver, testContextInstance, "DetailsEnteredinInviteAfriendPage").Build());

                   ClickButton( rewObj.registerButton,baseDriver);
                   extentTest.Info("Register button is clicked");

                    var wait = GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(ExpectedConditions.InvisibilityOfElementLocated(globalObj.locatorforReferAfriendloading));

                    if (IsElementPresentUsingBy(rewObj.locatorforConfirmatonMessage,baseDriver, Constants.medLoadTime))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception e)
            {
                extentTest.Info(e.Message);
                throw e;
               
            }
        }


        public static bool executeJavaScriptCommand(string javascriptCommand)
        {
            bool flag = true;
            try
            {
                IJavaScriptExecutor exe = ((IJavaScriptExecutor)baseDriver);
                var obj = exe.ExecuteScript(javascriptCommand);


            }
            catch (Exception e)

            {
                throw e;


            }
            return flag;
        }
        //************************************************************************************************************************************************************************************
        public static bool validateReservationDetails(TestContext testContextInstance)

        {

            int index = 0;
            bool flag = false;
            bool found = false;
            try
            {
                ReservationConfirmationPage rcObj = new ReservationConfirmationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, rcObj);

                MyReservationPage myreservObj = new MyReservationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, myreservObj);


               HomePage homePgObj = new HomePage(baseDriver);
                //PageFactory.InitElements(baseDriver, homePgObj);

                // Changes done by Fathima
               // var act = new Actions(baseDriver);
               // act.MoveToElement(homePgObj.logOffDiv).Perform();
               //act .MoveToElement(homePgObj.myReservation).Click().Build().Perform();

                List<IWebElement> listOfMenuObj = new List<IWebElement>() { homePgObj.logOffDiv, homePgObj.myReservation };
                MenuLevel1(listOfMenuObj, baseDriver);

                // baseDriver.Url = ConfigurationManager.AppSettings["UrlMyReservations"];

                //Thread.Sleep(50000);
                GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                int numberofReservations = myreservObj.CRTable_ListConfirmationNumber.Count;
                extentTest.Info("Current Reservations Table is present");

                if (numberofReservations > 10)

                {


                    WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    if (IsElementPresentUsingBy(myreservObj.locatorforViewAllLink, baseDriver))
                    {
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    }



                }





                Assert.IsTrue(IsElementPresentUsingBy(myreservObj.locatorforCurrentReservationTable,baseDriver, Constants.medLoadTime), "Current Reservations Table was not visible");

                GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));
                foreach (IWebElement confirmationNumberEle in myreservObj.CRTable_ListConfirmationNumber)
                {
                    //extentTest.Info("Looping through resrvation table ");
                    if (confirmationNumberEle.Text.Equals(TestBaseClass.currentconfirmationNumber))
                    {
                        found = true;
                        index = myreservObj.CRTable_ListConfirmationNumber.IndexOf(confirmationNumberEle);
                        extentTest.Info("Confirmation number found");
                        break;
                    }
                }

                Assert.IsTrue(found, "The confirmation number was found on My reservations page");
                extentTest.Info("The confirmation number " + TestBaseClass.currentconfirmationNumber + " listed on  My Reservations Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Reservation_Number").Build());
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation number" + TestBaseClass.currentconfirmationNumber + "was listed on  My Reservations Page");


                //check for the check in date
                Assert.IsTrue((myreservObj.CRTable_ListCheckIn[index].Text) == TestBaseClass.currentcheckInDate, "The check in date shown was correct in My Reservations");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The check In date was listed on  My Reservations Page");
                extentTest.Info("The check In date was listed on  My Reservations Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_CheckInDate").Build());

                //check out date

                Assert.IsTrue((myreservObj.CRTable_ListCheckOut[index].Text) == TestBaseClass.currentcheckOutDate, "The check out date shown was correct in My Reservations");
                // TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The check Out date was listed on the My Reservations Page");
                extentTest.Info("The check Out date was listed on the My Reservations Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_CheckOutDate").Build());

                //points/ amount
                Assert.IsTrue((myreservObj.CRTable_ListAmount[index].Text.Replace(",", "").Replace(Constants.currency, "")) == TestBaseClass.currentAmount, "The amount was correct on My Reservations page");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The Amount was listed on  My Reservations Page");
                extentTest.Info("The Amount was listed on  My Reservations Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_Amount").Build());

               

                Assert.IsTrue((myreservObj.CRTable_ListType[index].Text.ToLower()) == TestBaseClass.currentType);
               
                extentTest.Info("The type shown on My Reservations page was " + TestBaseClass.currentType+ "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_ResvType").Build());

                TestBaseClass.currentPPPStatus = myreservObj.CRTable_ListPPPStatus[index].Text;
                
                if ((!WithPPP && (currentType.Equals(Constants.pointstype))))//not protected case and not bonus reservation
                { 
                   flag=Businesslogic.CurrentPPPStatus(currentPPPStatus,testContextInstance);              
                }
                else if ((WithPPP && (currentType.Equals(Constants.pointstype))))//protected type
                {
                  flag= Businesslogic.CurrentPPPStatus(currentPPPStatus,testContextInstance);
                }
                else if ((currentType.Equals(Constants.bonustype)))//bonus type
                {
                 Assert.IsFalse(Businesslogic.CurrentPPPStatus(currentPPPStatus,testContextInstance),"Bonus time reservation should not see any status in PPPStatus column");
                 extentTest.Info("The points protected status is blank for Bonus Reservation"+ "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservation_PPPForBonus").Build());                  
                 flag = true;
                }

            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    // extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    throw exception.InnerException;
                    
                }
                if (exception.Message != null)
                {
                    throw exception;
                    //extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    
                }
            }
            return flag;
        }
        //************************************************************************
        public static bool SearchVssaByEmail(VSSAHomePage searchObj, string username)
        {
            bool flag = false;

            try
            {

                if ((isElementClickable(searchObj.Email, Constants.shortLoadTime))
                    && (isElementClickable(searchObj.SearchButton, Constants.shortLoadTime)))
                {

                    searchObj.Email.SendKeys(username);
                    searchObj.SearchButton.Click();

                    if ((isElementVisible(searchObj.locatorForarvactlink, Constants.shortLoadTime)))
                    {
                        searchObj.arvactlink.Click();

                        if ((isElementVisible(searchObj.locatorForResultTable, Constants.shortLoadTime)))
                        {
                            flag = true;

                        }
                    }
                }

                return flag;
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                return false;

            }

        }


        //*****************************************************************************
        public static bool SearchVssaByArvact(VSSAHomePage searchObj, string username)
        {
            bool flag = false;
            try
            {

                searchObj.Arvactnumber.SendKeys(username);
                searchObj.SearchButton.Click();
                extentTest.Info("Search button is clicked");

                if ((isElementVisible(searchObj.locatorForarvactlink, Constants.veryshortLoadTime)))
                {
                    searchObj.arvactlink.Click();
                    extentTest.Info("Arvact link is clicked");

                    if ((isElementVisible(searchObj.locatorForloginAsUser, Constants.veryshortLoadTime)))
                    {
                  
                        flag = true;

                    }
                    
                }

                return flag;
            }
            catch (Exception e)
            {
                throw e;
                

            }

        }


        public static bool isElementClickable(IWebElement element, int seconds)
        {
            try
            {


                WebDriverWait wait = new WebDriverWait(baseDriver, TimeSpan.FromSeconds(seconds));

                wait.Until(ExpectedConditions.ElementToBeClickable(element));


                return true;
            }
            catch (Exception e)
            {

                //ErrorLog Err = new //ErrorLog();
                //Err.LogError(resultsFolderpath, e.Message.ToString(), "WebElementExtensions.isElementClickable");
                return false;
            }

        }


        public static bool isElementVisible(By locator, int seconds)
        {

            try
            {
               WebDriverWait wait = new WebDriverWait(baseDriver, TimeSpan.FromSeconds(seconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
               
                return true;
            }
            catch (Exception e)
            {


                //  Logger.Error(testContextInstance, e.StackTrace, testContextInstance.TestName);
                return false;
                throw e;
            }


        }


        public static void isPageLoading(IWebDriver baseDriver)
        {

            bool loadingImage = isElementClickable(TestBaseClass.baseDriver.FindElement(By.XPath("//div[@id='loading-overlay']")), Constants.shortLoadTime);
            // while (loadingImage)
            if (loadingImage)

                loadingImage = isElementClickable(TestBaseClass.baseDriver.FindElement(By.XPath("//div[@id='loading-overlay']")), Constants.longLoadTime);


        }

        public static bool WaitForAnElement(String strxpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(baseDriver, System.TimeSpan.FromSeconds(2000));
                IWebElement LastLoadedElmt = wait.Until(baseDriver => baseDriver.FindElement(By.XPath(strxpath)));
                return true;
            }

            catch (TimeoutException timeout)
            {
                return false;
                throw timeout;

            }

        }

        public static string Hover()
        {

            try
            {
                //  Thread.Sleep(4000);
                Actions mouseHover = new Actions(baseDriver);
                mouseHover.MoveToElement(baseDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse']//a[contains(text(),'book')]"))).Perform();
                Thread.Sleep(2000);
                mouseHover.MoveToElement(baseDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse']//a[contains(text(),'bluegreen resorts')]"))).Perform();
                Thread.Sleep(2000);
                mouseHover.MoveToElement(baseDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse']//a[contains(text(),'bonus time')]"))).Perform();
                Thread.Sleep(2000);
                mouseHover.MoveToElement(baseDriver.FindElement(By.XPath("//div[@class='collapse navbar-collapse']//a[contains(text(),'bonus time')]"))).Click();
                Thread.Sleep(2000);

                return baseDriver.Url;
            }
            catch (NoSuchElementException)
            {

                return baseDriver.Url;
            }


        }


        ///
        public static void GenerateHTMLReport(TestContext testcontextInstance)
        {

            string testCaseId = testcontextInstance.TestName.ToLower().Replace("testcase_", "");// correct this
            string testCaseName = testcontextInstance.TestName;
            string overAllStatus = testcontextInstance.CurrentTestOutcome.ToString();
            string testDesc = testcontextInstance.Properties["TestDescription"].ToString(); ;
            string FontColor = "green";
            string TestResultDirectory = System.Configuration.ConfigurationManager.AppSettings["TestResultsFolder"] + @"\TestResults" + serialNumber + @"\HtmlReport";
            int row = testcontextInstance.DataRow.Table.Rows.IndexOf(testcontextInstance.DataRow);
            string screenshotpath = System.Configuration.ConfigurationManager.AppSettings["TestResultsFolder"] + @"\TestResults" + serialNumber + @"\" + testCaseName + "_Iteration_" + Convert.ToString(row) + @"\screenshots";
            if (!(testcontextInstance.CurrentTestOutcome.ToString().ToUpper().Equals("PASSED")))
                FontColor = "red";

            try
            {

                string html = "";
                if (SlNo == 1)
                {
                    html = @"<body bgcolor='#FFFFFF'>";

                    html += "<table table-layout:'fixed'; width:'90px'; word-break:'break-all';  border='1' style='color:black;border:1;-moz-border-radius:6px;border-collapse:collapse;border:1px solid black;text-align: center; background-color:#99ddff'>";
                    html += "<tr style='color:blue'><b>TestResultsReport</b></tr>";
                    html += "<tr><td ><b>SlNo</b></td><td><b>TestCaseName</b></td><td ><b>Description</b></td><td><b>Status</b></td><td ><b>TestData</b><td ><b>Screenshots</b></td></tr>";

                }

                if (testcontextInstance.CurrentTestOutcome.ToString().ToLower().Equals("failed"))
                    FontColor = "red";
                html += "<tr><td >" + SlNo + "</td>";
                html += "<td >" + testCaseName + "_Iteration_" + Convert.ToString(row) + "</td>";
                html += "<td >" + testDesc + "</td>";
                html += "<b><td style='color:" + FontColor + "'>" + overAllStatus + "</b></td>";
                html += "<td >" + testcontextInstance.DataRow["UserName"] + "</td>";
                html += "<td><a href='" + screenshotpath + "'>screenshotpath</a></td>";
                html += "</tr>";


                SlNo++;

                System.IO.Directory.CreateDirectory(TestResultDirectory);

                if (!System.IO.File.Exists(TestResultDirectory + @"\HtmlReport.html"))
                {
                    var myFile = File.Create(TestResultDirectory + @"\HtmlReport.html");

                    myFile.Close();
                    File.WriteAllText(TestResultDirectory + @"\HtmlReport.html", html);
                }
                else
                {
                    File.AppendAllText(TestResultDirectory + @"\HtmlReport.html", html);

                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);

            }

        }

        ///logic only for booking ppp reservation
        ///
        public static bool PointReservationLogic(string userName, TestContext testContextInstance, bool ProtectionType)
        {

           GlobalObjects globalObjects = new GlobalObjects(baseDriver);
            bool flag = false;
            try
            {

                ConfirmReservationPointType confirmReservationPageObj = new ConfirmReservationPointType(baseDriver);
               // PageFactory.InitElements(baseDriver, confirmReservationPageObj);

                //COMMON CODE FOR ALL TEST METHODS

                TestBaseClass.initializeTestScripts("no", "no", "no", testContextInstance);
               //Assert.IsTrue((TestBaseClass.SetUp(testContextInstance, Constants.Browser)), "BGO was not launched successfully");  //Login to BGO   
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "BGO was launched successfully");


                LoginPage loginPageObj = new LoginPage();
                PageFactory.InitElements(baseDriver, loginPageObj);
                //Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj, userName, Constants.password), "Login was not succesful");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Login was succesful");


                //Navigate to Point Type Reservation Page
                AllMenus topMenuobj = new AllMenus();
                PageFactory.InitElements(baseDriver, topMenuobj);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.Points };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Points" };

                //flag to comapre the available points with points needed for booking
                bool compareFlag = false;
                Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, baseDriver, ConfigurationManager.AppSettings["URlHomePage"]), "Points menu was not selected");


                HomePage homePageObj = new HomePage();
                PageFactory.InitElements(baseDriver, homePageObj);

                // Initialize Home Page objects

                List<string> fieldName;
                List<IWebElement> Objects;
                int TotalPoints = 0;
                int PointsForBooking = 0;
                int PointsForBookinginSearchPage = 0;

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForPointsButton,baseDriver, Constants.medLoadTime));
                Assert.IsTrue(homePageObj.PointsRadioButton.Selected, "Points Radio Buttion was not selected");
                extentTest.Info("Points Radio Buttion is  selected" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Points_Radion_Button").Build());
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Points Radio Buttion was  selected");
                //Note down Available points 

                Assert.IsTrue((IsElementPresentUsingBy(homePageObj.locatorForCurrentPoints, baseDriver,Constants.medLoadTime)), "Current Points was not displayed");

                homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();
                extentTest.Info($"Total number of points : {homePageObj.CurrentPointsVal}");
                Assert.IsTrue(!(homePageObj.CurrentPointsVal.Equals("null")), "The available points shown was null");
				

                homePageObj.CurrentPointsVal = homePageObj.CurrentPointsVal.Replace("points", "").Replace(",", "").Trim();
                TotalPoints = Convert.ToInt32(homePageObj.CurrentPointsVal);


                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
                //Thread.Sleep(2000);// this needs to be removed 
                //select the  destination, check in date,checkout date
                Assert.IsTrue(EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");

                ////Verify input check in date is selected in home page

                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForCheckInDate,baseDriver, Constants.shortLoadTime), "Check In date was not present n Home Page");

                homePageObj.ValCheckindate = homePageObj.CheckInDate.Text.Trim();
                string cin = DateTime.Parse(homePageObj.ValCheckindate).ToString("M/d/yyyy");// there is no need to use datetime.parse here.


                //Verify input check out date is selected in home page
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForCheckOutDate,baseDriver, Constants.shortLoadTime), "The check Out Date was not present in Home page");
                homePageObj.ValCheckoutdate = homePageObj.CheckOutDate.Text.Trim();
                string cout = DateTime.Parse(homePageObj.ValCheckoutdate).ToString("M/d/yyyy");

                homePageObj.SearchButton.Click();
                extentTest.Info("Clicked on search button");

                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage();
                PageFactory.InitElements(baseDriver, SearchResultsObj);

                if (!IsElementPresentUsingBy(SearchResultsObj.LocatorForDatesNotAvailable, baseDriver, Constants.shortLoadTime))
                {
                    //Search Results page displayed with resort locations listed 
                    IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;

                    ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);


                    int IFlag = TestBaseClass.SearchFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);

                    //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                    Assert.IsTrue(((IFlag == 3) || (IFlag == 4)), "The Search Result was not displayed properly");
                    extentTest.Pass("Search result page displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Searchresult").Build());

                    SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);
                    //check that the btnShowResortAvailability is not null elemet
                 
                    ClickButton(SearchResultsObj.btnShowResortAvailability, baseDriver);
                    extentTest.Info("Show availability button is clicked");
                    
                    IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver);

                    GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                    Assert.IsTrue(IsSingleELementVisible(SearchResultsObj.locatorForResultsTab, baseDriver, (int)Utilities.Timeout.LongwaitInSecond), "The Search Results table was not displayed.");
                    extentTest.Info("Search result table displayed");
                    IReadOnlyCollection<IWebElement> rows = SearchResultsObj.ResultsTab.FindElements(By.TagName("tr"));
                    //Thread.Sleep(4000);// this needs to be removed
                    Assert.IsTrue(rows.Count > 0, "Search Results was empty");//Search results are displayed

                    //Check avaialble points is displayed in the serach results for first room of last resort
                    Assert.IsTrue(IsElementPresentUsingBy(SearchResultsObj.locatorForMultiResultPointsLink, baseDriver, Constants.medLoadTime), "The Points link was not displayed in Search Results");
                    SearchResultsObj.multiResultPointsLink = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultPointsLink);
                    Assert.IsTrue(IsSingleELementVisible(SearchResultsObj.locatorForMultiResultPointsLink, baseDriver, Constants.shortLoadTime), "The Points link was not displayed");
                    SearchResultsObj.multiResultPointsLink.Click();

                    IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver, (int)Utilities.Timeout.LongwaitInSecond);
                    //thread.Sleep(3000);
                    SearchResultsObj.SRPPoints = SearchResultsObj.multiResultPointsLink.Text.Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", "").Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();
                    PointsForBookinginSearchPage = Convert.ToInt32(SearchResultsObj.SRPPoints);


                    ////Verify the available points is greater than points needed for booking
                    ////compare avaialble points is greater than or equal to points needed for reservation shown in search results page

                    if (!((String.IsNullOrEmpty(homePageObj.CurrentPointsVal))) || ((String.IsNullOrEmpty(SearchResultsObj.SRPPoints))))
                    {
                        //doing this to check book buuton is enabled for booking or  not
                        Assert.IsTrue(TotalPoints >= PointsForBookinginSearchPage, "The available points " + TotalPoints + " is not greater than that required for booking" + PointsForBookinginSearchPage);
                        extentTest.Info("The available points is greater than that required for booking");
                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The available points is greater than that required for booking");

                        compareFlag = true;
                    }
                    else
                        compareFlag = false;

                    //Check if book button is displayed and proceed with booking

                    //IJavaScriptExecutor script = ((IJavaScriptExecutor)TestBaseClass.baseDriver);
                    //script.ExecuteScript("window.scrollBy(0,200)");
                    SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);


                    
                    JavascriptClickElement(SearchResultsObj.multiResultBookButton, baseDriver);
                    extentTest.Info("Book button is clicked");
                    
                    IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver);

                    if (IsElementPresent(SearchResultsObj.locatorfuturePointsContinue, baseDriver))
                    {
                        extentTest.Info("Future points option displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Futurepoints_buttton").Build());
                        ClickButton(SearchResultsObj.futurePointsContinue, baseDriver);
                    }
                    else if (IsElementPresent(globalObjects.LocatorForAlertforAccount, baseDriver))


                    {
                        extentTest.Error("Account is not in good standing and is blocked from booking due one of its account activity" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Current_Status").Build());
                        flag = false;
                        Assert.Fail("Account is not in good standing and is blocked from booking due one of its account activity");

                    }

                    else if (IsElementPresent(globalObjects.LocatorforSavePointsbtn, baseDriver) && IsElementPresent(confirmReservationPageObj.locatorForMsg_NotEnoughPoints, baseDriver))

                    {

                        extentTest.Error("Save My points and not enough points alert is present" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Savepoints_Notenoughpoints").Build());
                        flag = false;
                        Assert.Fail("Save My points and not enough points alert is present");

                    }






                   
               else if( IsElementPresentUsingBy(confirmReservationPageObj.locatorForBtn_SubmitReservation, baseDriver))

                    { 
                    extentTest.Info("Confirm reservation page displayed");
                    confirmReservationPageObj.checkindate = confirmReservationPageObj.TableCoumn_CheckIn.Text.Trim();



                    //Assert.IsTrue(TestBaseClass.isElementVisible(confirmReservationPageObj.locatorForTableColumn_CheckOut, Constants.medLoadTime));
                    confirmReservationPageObj.checkoutdate = confirmReservationPageObj.TableColumn_CheckOut.Text.Trim();

                    //Assert.IsTrue(TestBaseClass.isElementVisible(confirmReservationPageObj.locatorforLab_ResortName, Constants.medLoadTime));
                    confirmReservationPageObj.resortName = confirmReservationPageObj.Lab_ResortName.Text.Trim();

                    ////Compare Points with Points shown in Search results page
                    //Assert.IsTrue(isElementVisible(confirmReservationPageObj.locatorForTableColumn_Amount, Constants.medLoadTime));
                    confirmReservationPageObj.points = confirmReservationPageObj.TableColumn_Amount.Text.Trim();
                    confirmReservationPageObj.points = confirmReservationPageObj.points.Replace(",", "").Trim();
                    confirmReservationPageObj.points = confirmReservationPageObj.points.Replace("Points", " ").Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", " ").Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();

                    //Add Guest Details on confirm reservation page
                    //         TestBaseClass.ScrollUsingJavaScript("0", "document.body.scrollHeight");
                    fieldName = new List<string> { "Guest Checking in", "Special Requests", "Check Box Near text  I have read, understand and agree to the reservation details above including important notes and the Points reservation Terms and Conditions.", "Confirm My reservation Button", "No of Guests", "Plus button to add guests" };
                    Objects = new List<IWebElement> { confirmReservationPageObj.Select_GuestCheckingInDefaultBtn, confirmReservationPageObj.Feild_specialRequests, confirmReservationPageObj.Chk_Agreement, confirmReservationPageObj.Btn_SubmitResrvation, confirmReservationPageObj.Field_NumberOfGuests, confirmReservationPageObj.Btn_PlusNumberOfGuests };

                    confirmReservationPageObj.Select_GuestCheckingInDefaultBtn.Click();

                    fieldName.Clear();
                    fieldName = new List<string>() { "Owner option1" };
                    Objects = new List<IWebElement> { confirmReservationPageObj.Option_Owner1 };


                    confirmReservationPageObj.guestCheckingName = confirmReservationPageObj.Option_Owner1.Text.Trim();
                    confirmReservationPageObj.Option_Owner1.Click();
                    extentTest.Info("GuestList displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "GuestList").Build());

                    confirmReservationPageObj.Feild_specialRequests.SendKeys(Constants.valSpecialRequest);
                    confirmReservationPageObj.Chk_Agreement.Click();
                    confirmReservationPageObj.specialrequests = confirmReservationPageObj.Feild_specialRequests.Text.Trim();

                    int numGuests = Convert.ToInt16(2);
                    int i = 0;
                    while (i < numGuests)
                    {
                        confirmReservationPageObj.Btn_PlusNumberOfGuests.Click();
                        //Thread.Sleep(1000);
                        i++;

                    }


                    IJavaScriptExecutor executor = (IJavaScriptExecutor)baseDriver;
                    var javaScriptNumGuests = executor.ExecuteScript("return window.document.getElementById('Guest_NumberOfGuest').getAttribute('aria-valuenow')");
                    confirmReservationPageObj.numberOfGuests = javaScriptNumGuests.ToString();
                    confirmReservationPageObj.Btn_SubmitResrvation.Submit();
                    fieldName.Clear();
                    fieldName = new List<string>() { "Owner option1", "No Of Requests", "Special Requests" };
                    PointsProtectionPlanPage pppObj = new PointsProtectionPlanPage();
                    PageFactory.InitElements(baseDriver, pppObj);

                    if (!ProtectionType)//WITH OUT PPP
                    {
                        //byepass ppp page
                        TestBaseClass.WithPPP = false;
                        IsElementPresent(pppObj.locatorforLink_PPPNoThankYou, baseDriver);
                        Assert.IsTrue(IsElementPresent(pppObj.locatorforLink_PPPNoThankYou, baseDriver), "The No thank You Link was not present in the Protect points Page");
                        Assert.IsTrue(isElementClickable(pppObj.Link_PPPNoThankYou, Constants.medLoadTime), "The No thank You Link was not clickable in the Protect points Page");
                        pppObj.Link_PPPNoThankYou.Click();

                        Assert.IsTrue(IsElementPresentUsingBy(pppObj.locatorForBtn_IamNotInterested, baseDriver, Constants.medLoadTime), "The Iam Not interested Button was not  displayed in protect Points Page");
                        Assert.IsTrue(isElementClickable(pppObj.Btn_IamNotInterested, Constants.medLoadTime), "The Iam Not interested Button was not clickable in the Protect points Page");
                        pppObj.Btn_IamNotInterested.Click();

                    }
                    else
                    {
                        //verify PPP page
                        TestBaseClass.WithPPP = true;
                        Assert.IsTrue(isElementVisible(pppObj.locatorfortextBox_CreditCardName, Constants.medLoadTime));
                        fieldName = new List<string> { "Name", "CardNumber", "CVV", "ExpirationMonth", "ExpirationYear", "BillingZip/PostalCode", "AgreementCheckBox", "ProtectMyPointsButton", "International ZipCode CheckBox" };
                        Objects = new List<IWebElement> { pppObj.textBox_CreditCardName, pppObj.TextBox_CreditCardNumber, pppObj.TextBox_CVV, pppObj.Select_ExpirationMonth, pppObj.Select_ExpiratonYear, pppObj.TextBox_ZipCode, pppObj.ChkBox_PPPAgreement, pppObj.Btn_ProtectMyPoints, pppObj.ChkBox_InternationalZipCode };
                        Assert.IsTrue(TestBaseClass.fillCreditCardDetailsPPPPage(pppObj, testContextInstance), "The PPP from filling  was not successful");
                        Assert.IsTrue(TestBaseClass.SubmitPPPForm(pppObj), " The PPP submission was not successful");
                    }

                    ReservationConfirmationPage rcObj = new ReservationConfirmationPage();
                    PageFactory.InitElements(baseDriver, rcObj);

                    //Check that Confirmation Page is displayed on clciking Protect My Points Button.
                    Assert.IsTrue(TestBaseClass.isElementVisible(rcObj.locatorForConfirmationNumber, Constants.medLoadTime), "The confirmation  number was not displayed");
                    Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ConfirmationNumber.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ConfirmationNumber.Text)), "The confirmation  number was not correct");
                    TestBaseClass.currentconfirmationNumber = rcObj.ConfirmationNumber.Text;
                    TestBaseClass.UrlForCurrentReservation = baseDriver.Url;
                    //Check Confimration Date
                    //  Assert.IsTrue(TestBaseClass.isElementVisible(rcObj.locatorForConfirmationDate, Constants.medLoadTime));

                    Assert.IsTrue(rcObj.ConfirmationDate.Text.Equals(DateTime.Now.ToString("MM/dd/yyyy").ToString()));
                    TestBaseClass.confirmationdate = DateTime.Now.ToString("MM/dd/yyyy").ToString();
                    extentTest.Info("The confirmation date on Confirmation page is same as that in the confirm reservation page");
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation date on Confirmation page is same as that in the confirm reservation page");

                    //Validate resort  name

                    // Assert.IsTrue(TestBaseClass.isElementVisible(rcObj.locatorForResortName, Constants.medLoadTime));

                    //  Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ResortName.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ResortName.Text)));

                    rcObj.CPResortName = rcObj.ResortName.Text.Trim();
                    Assert.IsTrue(rcObj.CPResortName.Equals(confirmReservationPageObj.resortName));
                    TestBaseClass.currentResortName = rcObj.CPResortName;
                    extentTest.Info("The  resortname  on Confirmation page is same as that in the confirm reservation page");
                    // TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The  resortname  on Confirmation page is same as that in the confirm reservation page");

                    //Validate the Points are same in Confirmation Page as well

                    // Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ValPointsUsed.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ValPointsUsed.Text)));
                    rcObj.pointsUsed = rcObj.ValPointsUsed.Text.Replace(",", "").Trim();
                    Assert.IsTrue(rcObj.pointsUsed.Equals(confirmReservationPageObj.points), " The points used on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentAmount = rcObj.pointsUsed;
                    extentTest.Info("The points used on Confirmation page is same as that in the confirm reservation page");
                    // TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, " The points used on Confirmation page is same as that in the confirm reservation page");

                    ////Validate Points Protected label

                    if ((ProtectionType))//WITH OUT PPP
                    {
                        Assert.IsTrue(rcObj.Lab_ProtectedOrNot.Text.Equals("| points protected"));
                        TestBaseClass.currentPPPStatus = rcObj.Lab_ProtectedOrNot.Text;
                    }


                    //check in date
                    rcObj.checkindate = rcObj.CheckInDate.Text.Trim();
                    Assert.IsTrue(rcObj.checkindate.Equals(confirmReservationPageObj.checkindate), "The check in date on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentcheckInDate = rcObj.checkindate;
                    extentTest.Info("The   check in date  on Confirmation page is same as that in the confirm reservation page");
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check in date  on Confirmation page is same as that in the confirm reservation page");

                    //Check the check out  date is displayed in confirmation Page

                    rcObj.checkoutdate = rcObj.CheckOutDate.Text.Trim();
                    Assert.IsTrue(rcObj.checkoutdate.Equals(confirmReservationPageObj.checkoutdate), "The check out date on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentcheckOutDate = rcObj.checkoutdate;
                    extentTest.Info("The   check out date  on Confirmation page is same as that in the confirm reservation page");
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check out date  on Confirmation page is same as that in the confirm reservation page");


                    // Check  available points after booking

                    MyReservationPage myreserObj = new MyReservationPage();
                    PageFactory.InitElements(baseDriver, myreserObj);
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyReservations"];

                    baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.medLoadTime);
                       // MenuLevel1( new List<By> {homePageObj.locatorLogOffDivByXpath,all}

                    Assert.IsTrue(TestBaseClass.isElementVisible(homePageObj.locatorForCurrentPoints, Constants.shortLoadTime));
                    homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text;
                    homePageObj.CurrentPointsVal = homePageObj.CurrentPointsVal.Replace("points", "").Replace(",", "").Trim();
                    PointsForBooking = Convert.ToInt32(rcObj.pointsUsed);
                    int actualRemainingPoints = Convert.ToInt32(homePageObj.CurrentPointsVal);
                    int expectedRemainingPoints = TotalPoints - PointsForBooking;
                        //if (actualRemainingPoints == expectedRemainingPoints)
                        //{
                        //    extentTest.Info("The avaialble points after booking is correct");

                        //    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The avaialble points after booking is correct");

                        //    flag = true;
                        //}
                        //else
                        //{
                        //    extentTest.Info("The available point after booking is incorrect");

                        //    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The available point after booking is incorrect");
                        //    flag = false;
                        //}
                        flag = true;
                }


                else
                {

                    extentTest.Error("Unexpected error" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Unexpectederror").Build());
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Something went wrong , please screenshots and debug the code after clicking book button");
                    flag = false;
                    Assert.Fail("Unexpected error has occured");

                }





                }

                //}
                else
                {
                    extentTest.Fail("No Inventory Available" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "NoInventory").Build());
                    flag = false;
                    Assert.Fail("No Inventory available for any resort for specified dates");
                }

                return flag;

            }



            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                    //logger.Trace(e.StackTrace + "\r\n" + e.InnerException.ToString()); ;
                    //extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, e.InnerException.ToString());
                   throw e.InnerException;
                }

                else
                {
                    //logger.Trace(e.StackTrace + "\r\n" + e.Message);
                   
                    //extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());

					throw e;

                }



                

            }


        }


        //

        public static bool IsSecondLevelMenudisplayedLogic(List<string> fieldName, List<By> locatorForField, List<By> ListOfMenuLocators, List<IWebElement> ListOfMenuobjects, List<string> menuName, TestContext testContext)
        {
            Actions act = new Actions(baseDriver);
            bool flag;
            try
            {
                Assert.IsTrue((isElementVisible(ListOfMenuLocators[0], Constants.veryshortLoadTime)), "The menu " + menuName[0] + " was not displayed");
                act.MoveToElement(ListOfMenuobjects[0]).Build().Perform();
                Assert.IsTrue((isElementVisible(ListOfMenuLocators[1], Constants.veryshortLoadTime)), "The sub menu " + menuName[1] + "was not displayed");
                act.MoveToElement(ListOfMenuobjects[1]).Build().Perform();
                flag = IsAllInputFieldsDisplayedNegativeCase(testContext, fieldName, "Home Page", locatorForField);
                Assert.IsTrue(flag, "The sub menus were shown for " + menuName[1]);
                extentTest.Pass(" submenus shown", AttachScrenshot(baseDriver, testContext, "SubmenusDisplayed").Build());

            }
            catch (Exception e)
            {
               // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContext, "Error").Build());

                flag = false;
				throw e;
            }
            return flag;

        }

        //to select payment option and entering amount in make a prepayement page



        //Enter credit card info in Make a prepayment page

        public static bool fillPrePaymentCreditCardInfo(PrePaymentPage pageObj)
        {
            bool flag = false;
            try
            {


                SelectElement cardType = new SelectElement(pageObj.cardType);

                pageObj.ValNameOnCard = pageObj.nameOnCard.GetAttribute("value");

                cardType.SelectByText(Constants.CardType);

                pageObj.cardNum.SendKeys(Constants.CardNumber);

                SelectElement expMonth = new SelectElement(pageObj.expMonth);
                expMonth.SelectByText(Constants.Two);

                SelectElement expYear = new SelectElement(pageObj.expYear);
                expYear.SelectByText(Constants.expirationYear);

                pageObj.zipCode.SendKeys(Constants.zipcode);

                pageObj.termsCheckbox.Click();

                pageObj.submitPaymentButton.Click();

                if ((IsElementPresentUsingBy(pageObj.locatorforConfirmationAmount,baseDriver, Constants.shortLoadTime))
                    && (isElementVisible(pageObj.locatorforConfirmationNumber, Constants.shortLoadTime)))
                {
                    pageObj.ValConfirmationNumber = pageObj.ConfirmationNumber.Text;
                    pageObj.ValConfirmationAmount = pageObj.ConfirmationAmount.Text;
                    flag = true;
                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                flag = false;
            }
            return flag;
        }

        // login to fund source

        public static bool LoginToFundSource(FundSourcePage fObj, string userId, string password)
        {
            bool flag = false;
            try
            {
                fObj.loginId.Clear();
                fObj.password.Clear();
                fObj.loginId.SendKeys(userId);
                fObj.password.SendKeys(password);
                fObj.loginButton.Click();

                if ((IsElementPresentUsingBy(fObj.locatorforlinkTransactions,baseDriver, Constants.shortLoadTime)))
                {
                    flag = true;

                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                flag = false;

            }
            return flag;
        }

        //find a transaction in fundosurce

        public static bool FindTransactionInFundSource(TestContext testContextInstance, AllMenus topMenuobj, string ValNameOnCard, string ValConfirmationAmount, string ValConfirmationNumber)
        {
            bool flag = false;
            try
            {
                FundSourcePage fObj = new FundSourcePage();
                PageFactory.InitElements(baseDriver, fObj);
                baseDriver.Url = ConfigurationManager.AppSettings["UrlForFundSource"];
                for (int k = 0; k < Constants.FundSourceId.Length; k++)
                {

                    Assert.IsTrue(LoginToFundSource(fObj, Constants.FundSourceId, Constants.FundSourcePassword), "Login To FundSource was not successful");
                    printOutputAndCaptureImage(testContextInstance, baseDriver, "Login To FundSource was successful");

                    //navigate to transactions list page
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlForFundSourceTransactionsPage"];
                    Assert.IsTrue(isElementVisible(fObj.locatorFortransactionsTable, Constants.shortLoadTime), "The transactions table  was not  displayed in FundSource");
                    printOutputAndCaptureImage(testContextInstance, baseDriver, "The transactions table  was displayed in FundSource");

                    List<IWebElement> ListCardHolder = new List<IWebElement>(fObj.transactions_CardholderCol);
                    List<IWebElement> ListAuth = new List<IWebElement>(fObj.transactions_AuthCol);
                    List<IWebElement> ListAmount = new List<IWebElement>(fObj.transactions_AmountCol);
                    List<IWebElement> ListExpiry = new List<IWebElement>(fObj.transactions_ExpiryCol);
                    Assert.IsTrue(ListCardHolder.Count > 0, "The transactions was empty");
                    printOutputAndCaptureImage(testContextInstance, baseDriver, "A list of transactions were shown in FundSource");

                    for (int i = 0; i < ListCardHolder.Count; i++)
                    {

                        if ((ListAuth[i].Text.Replace(",", "").Equals(ValConfirmationNumber)) && (ListAmount[i].Text.Replace(",", "").Replace(".00", "").Equals(ValConfirmationAmount.Replace(",", "").Replace(".00", "").Replace("$", ""))))
                        {
                            flag = true;
                            break;
                        }

                    }
                    if (flag)
                        break;
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlForFundSource"];
                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                flag = false;

            }

            return flag;
        }

        //to fill details in save my points page

        public static bool EnterSavePointFormDetails(TestContext testContextInstance, SaveMyPointsPage saveObj)
        {
            try
            {

                Assert.IsTrue(IsElementPresentUsingBy(saveObj.locatorForNameOnCard,baseDriver, Constants.medLoadTime), "The Name On Card Text Box was not present in Save My Points Page");
                saveObj.NameOnCard.SendKeys(Constants.FullName);
                saveObj.CreditCardNumber.SendKeys(Constants.CardNumber);
                saveObj.CVV.SendKeys(Constants.cvv);
                SelectElement dropdown1 = new SelectElement(saveObj.ExpirationMonth);
                dropdown1.SelectByText(Constants.expirationMonthNumber);
                SelectElement dropdown2 = new SelectElement(saveObj.ExpirationYear);
                dropdown2.SelectByText(Constants.expirationYear);
                saveObj.ZipCode.SendKeys(Constants.zipcode);
                saveObj.InternationalZipCode.Click();
                saveObj.ChkBoxTermsAndConditions.Click();
                extentTest.Pass("The Credit Card Details were succesfully entered in My Points Page", AttachScrenshot(baseDriver, testContextInstance, "CreditCardDetailsSuccessfullyEntered").Build());
                saveObj.SaveMyPointsButton.Click();
                return true;
            }
            catch (Exception e)
            {
                extentTest.Info(e.Message);
                return false;
            }
        }
        //search bonus time reservation
        public static int SearchBonusTimeFromHomePage(IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults, SearchResultsPage SearchResultsObj, string InputDestination)
        {

            availableLocations = null;
            availableResortNames = null;
            int executeSearchResults = 0;
            int indexnum = 0;
            destnum = 1;

            Random rnd = new Random();
            if (ListAvailableDestinationsInSearchResults.Count > 0)
                destnum = rnd.Next(1, ListAvailableDestinationsInSearchResults.Count);

            try
            {
                if ((ListAvailableDestinationsInSearchResults.Count > 0))
                {
                    //Serach Results displayed for all destinations/states
                    foreach (IWebElement resortLocationElement in ListAvailableDestinationsInSearchResults)
                    {
                        //All destinations
                        if (InputDestination.ToLower().Replace(" ", "").Equals("alldestinations"))
                        {
                            if ((destnum.Equals(indexnum + 1)))
                            {
                                resortLocationElement.Click();
								//Thread.Sleep(2000);
								baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.medLoadTime);
                                availableLocations = availableLocations + "," + resortLocationElement.Text.Trim();

                                //Identify dynamically generated resort names and show resort availablity button
                                string resortId = resortLocationElement.Text.Replace(" ", "").Trim().ToLower();
                                int index = resortId.IndexOf("resorts");
                                int l = resortId.Length - 1;
                                resortId = resortId.Remove(index);
                                SearchResultsObj.XpathForResortNames = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForResortNameLastpart;


                                IReadOnlyCollection<IWebElement> ListResortNames = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForResortNames);
                                if (ListResortNames.Count > 0)
                                {
                                    foreach (IWebElement resortNameElement in ListResortNames)
                                    {
                                        availableResortNames = availableResortNames + "," + resortNameElement.Text.Trim();
                                        SearchResultsObj.lastResortNameElement = resortNameElement;
                                        SearchResultsObj.SRPResortName = SearchResultsObj.lastResortNameElement.Text.Trim();
                                    }
                                    SearchResultsObj.XpathForShowResortAvailalbilityButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForShowResortAvailabiltyLastPart;
                                    SearchResultsObj.locatorForShowResortAvailalbilityButton = By.XPath(SearchResultsObj.XpathForShowResortAvailalbilityButton);
                                    SearchResultsObj.XpathForSearchResultsTable = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart;
                                    SearchResultsObj.locatorForSearchResultsTable = By.XPath(SearchResultsObj.XpathForSearchResultsTable);
                                    SearchResultsObj.XpathForMultiResultBookButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultBookButtonLastPart;
                                    SearchResultsObj.locatorForMultiResultBookButton = By.XPath(SearchResultsObj.XpathForMultiResultBookButton);
                                    SearchResultsObj.XpathForTotalPrice = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForTotalPriceLastPart;
                                    SearchResultsObj.XpathForDailyRate = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForDailyRateLastPart;
                                    SearchResultsObj.locatorForXpathForTotalPrice = By.XPath(SearchResultsObj.XpathForTotalPrice);
                                    SearchResultsObj.locatorForXpathForDailyRate = By.XPath(SearchResultsObj.XpathForDailyRate);

                                    executeSearchResults = 3;// resort names and location displayed for all destinations
                                    break;
                                }

                            }//some location links were expandable
                        }//Endif//All Destination
                        else
                        {    //ex:search by florida                    

                            availableLocations = availableLocations + "," + resortLocationElement.Text.Trim();
                            string resortId = resortLocationElement.Text.Replace(" ", "").Trim().ToLower();
                            int index = resortId.IndexOf("resorts");
                            int l = resortId.Length - 1;
                            resortId = resortId.Remove(index);
                            SearchResultsObj.XpathForResortNames = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForResortNameLastpart;
                            IReadOnlyCollection<IWebElement> ListResortNames = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForResortNames);

                            if (ListResortNames.Count > 0)
                            {

                                foreach (IWebElement resortNameElement in ListResortNames)
                                {

                                    availableResortNames = availableResortNames + "," + resortNameElement.Text.Trim();
                                    SearchResultsObj.lastResortNameElement = resortNameElement;
                                    SearchResultsObj.SRPResortName = SearchResultsObj.lastResortNameElement.Text.Trim();
                                }
                                SearchResultsObj.XpathForShowResortAvailalbilityButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForShowResortAvailabiltyLastPart;
                                SearchResultsObj.locatorForShowResortAvailalbilityButton = By.XPath(SearchResultsObj.XpathForShowResortAvailalbilityButton);
                                SearchResultsObj.XpathForSearchResultsTable = SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart;
                                SearchResultsObj.locatorForSearchResultsTable = By.XPath(SearchResultsObj.XpathForSearchResultsTable);
                                SearchResultsObj.XpathForMultiResultBookButton = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultBookButtonLastPart;
                                SearchResultsObj.locatorForMultiResultBookButton = By.XPath(SearchResultsObj.XpathForMultiResultBookButton);
                                SearchResultsObj.XpathForMultiResultPointsLink = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultPointsLinkLastPart;
                                SearchResultsObj.locatorForMultiResultPointsLink = By.XPath(SearchResultsObj.XpathForMultiResultPointsLink);
                                SearchResultsObj.XpathForMultiResultStandardPointsTable = "(" + SearchResultsObj.XpathForResortNameFirstpart + resortId + SearchResultsObj.XpathForResortNameMiddlepart + SearchResultsObj.XpathForSearchResultsTableLastPart + SearchResultsObj.XpathForMultiResultStandardPointsTableLastPart;
                                SearchResultsObj.locatorForMultiResultStandardPointsTable = By.XPath(SearchResultsObj.XpathForMultiResultStandardPointsTable);
                                executeSearchResults = 4;
                            }

                        }
                        ++indexnum;
                    }//for each
                }//if serach results are shown  if (ListAvailableDestinationsInSearchResults.Count > 0)
                else if (isElementVisible(SearchResultsObj.locatorForResultsTab, Constants.medLoadTime))
                {
                    executeSearchResults = 5;//search results page with book button
                }//if serach results are shown  if (ListAvailableDestinationsInSearchResults.Count > 0)
                else if (isElementVisible(SearchResultsObj.locatorForbtnFirstAlternateDate, Constants.medLoadTime))
                {
                    executeSearchResults = 6;//search results page with alternate date
                }//if (WebElementExtensions.isElementVisible(SearchResultsObj.locatorForbtnFirstAlternateDate, Constants.medLoadTime))
                else
                {
                    executeSearchResults = 1;
                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                executeSearchResults = 0;
            }
            return executeSearchResults;
        }

        // fill contact details and payment information details in bonus time reservationPage

        public static bool fillContactandCreditCardDetailsInBonusTimeReservationPage(TestContext testContextInstance, BonusTimeReservationPage bonusPageObj)
        {
            bool flag = false;
            try
            {


               
                //select reservation information section
                bonusPageObj.Select_GuestCheckingInDefaultBtn.Click();
                guestCheckingName = bonusPageObj.Option_Owner1.Text.Trim();
                bonusPageObj.Option_Owner1.Click();
                //Businesslogic.SelectGuest("Owner", baseDriver);

                bonusPageObj.Feild_specialRequests.SendKeys(Constants.valSpecialRequest);
              
            
                int numGuests = Convert.ToInt16(2);
                int i = 0;
                while (i < numGuests)
                {
                    bonusPageObj.Btn_PlusNumberOfGuests.Click();
				
                    //Thread.Sleep(1000);
                    i++;

                }

                //set billing Information section
                //clear values
                bonusPageObj.AddFirstName.Clear();
                bonusPageObj.AddLastName.Clear();
                bonusPageObj.AddressLIne1.Clear();
                if (IsElementPresent(bonusPageObj.AddCity))
                {
                    bonusPageObj.AddCity.Clear();
                }
                bonusPageObj.AddEmail.Clear();
                if(IsElementPresent(bonusPageObj.AddZip))
                {
                    bonusPageObj.AddZip.Clear();
                }
                
                bonusPageObj.AddPhoneNumber.Clear();

                //SET values
                bonusPageObj.AddFirstName.SendKeys(Constants.Firstname);
                bonusPageObj.AddLastName.SendKeys(Constants.LastName);
                bonusPageObj.AddressLIne1.SendKeys(Constants.Address);
                if(IsElementPresent(bonusPageObj.AddCity))
                {
                    bonusPageObj.AddCity.SendKeys(Constants.City);
                }

                if (IsElementPresent(bonusPageObj.AddZip))
                {
                    bonusPageObj.AddZip.SendKeys(Constants.zipcode);
                }
               
                bonusPageObj.AddEmail.SendKeys(Constants.Email);
                bonusPageObj.AddPhoneNumber.SendKeys(Constants.Phone);

                //set payment information section
                bonusPageObj.name.SendKeys(Constants.Firstname + Constants.LastName);
                bonusPageObj.cardnum.SendKeys(Constants.CardNumber);
                bonusPageObj.cvv.SendKeys(Constants.cvv);
                bonusPageObj.zipcode.SendKeys(Constants.zipcode);
                bonusPageObj.Select_ExpirationMonth.Click();
                bonusPageObj.Select_MonthDecember.Click();
                bonusPageObj.Select_ExpiratonYear.Click();
                bonusPageObj.Select_ExpiratonYearCurrent.Click();
                bonusPageObj.checkBox.Click();
                bonusPageObj.Submit.Submit();
                extentTest.Info("The details were correctly entered in  Contact,Billing,Payment info section in Bonus Time Reservation Page");
                flag = true;


            }
           
				catch (Exception exception)
			{
               
				if (exception.InnerException != null)
				{
					extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    throw exception.InnerException;
				}
				else 
				{
					extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    throw exception;
				}
			}
            return flag;

        }

        public static bool SubmitPPPForm(PointsProtectionPlanPage PPPPObj)
        {
            bool flag = false;
            try
            {
                PPPPObj.Btn_ProtectMyPoints.Click();
                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                throw e;
              

            }

        }
        public static bool Paginationlogic(string xpath, string pagenumxpath, string reservationstype, By locatorViewAll, IWebElement ViewAll, IList<IWebElement> dummyListConfirmationNumber, By locatorfordummyListConfirmationNumber, IList<IWebElement> dummyListConfirmationNumberDisplayed, By locatorfordummyListConfirmationNumberDisplayed, TestContext testContextInstance)
        {
            string confirmationnumberList = null;
            string confirmationnumberListPerPage = null;
            int numberOfPages = 1;
            int numberOfPages2 = 1;
            int remainder = 0;


            //Navigate to Point Type Reservation Page
            MyReservationPage myreservObj = new MyReservationPage();
            PageFactory.InitElements(baseDriver, myreservObj);
            bool flag = false;
            bool found = false;
            int Val = 0;
            try
            {
                if (IsElementPresentUsingBy(locatorViewAll,baseDriver, Constants.shortLoadTime))
                {
                    JavascriptClickElement(ViewAll,baseDriver);

                }
                if (IsElementPresentUsingBy(locatorfordummyListConfirmationNumber,baseDriver, Constants.shortLoadTime))
                {
                    numberOfRowsInCurrentReservationsTable = dummyListConfirmationNumber.Count;
                    foreach (IWebElement ele in dummyListConfirmationNumber)
                    {
                        confirmationnumberList = confirmationnumberList + "," + ele.Text;

                    }
                    found = true;

                }

                Assert.IsTrue(found, "The  reservations of type" + reservationstype + "were not listed in My Reservations");
                extentTest.Pass("The  reservations of type " + reservationstype + " were listed in My Reservations" + "r\n", AttachScrenshot(baseDriver, testContextInstance, "Reservation_Number").Build());
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The  reservations of type " + reservationstype + " were listed in My Reservations");

                //calculate expected number of pages based on total number of records shwon
                numberOfPages = (numberOfRowsInCurrentReservationsTable / 10);
                remainder = (numberOfRowsInCurrentReservationsTable % 10);
                if (remainder > 0)
                {
                    numberOfPages = numberOfPages + 1;
                }


                baseDriver.Url = ConfigurationManager.AppSettings["UrlMyReservations"];
                int[] numberofRecords = new int[10];

                Assert.IsTrue(IsElementPresentUsingBy(locatorfordummyListConfirmationNumber,baseDriver, Constants.shortLoadTime), "locatorfordummyListConfirmationNumber was not displayed");

                //find out actual number of page number links shown-numberOfPages

                ReadOnlyCollection<IWebElement> pageNumLinks = FindElementsUsingDriverUpdated("xpath", xpath);

                if (pageNumLinks.Count == 0)
                    numberOfPages2 = 1;
                else
                {
                    numberOfPages2 = pageNumLinks.Count;
                }

                Assert.IsTrue((numberOfPages == numberOfPages2), "Number of pages required to display " + numberOfRowsInCurrentReservationsTable + " rows in " + reservationstype + " was not" + numberOfPages);
				extentTest.Info("Number of pages required to display " + numberOfRowsInCurrentReservationsTable + " rows in " + reservationstype + " is " + numberOfPages);


                //get all confrimation numbers and compare with master list

                int i;
                for (i = 0; i < numberOfPages; i++)
                {
                    IWebElement link = FindAnElementUsingDriver("xpath", pagenumxpath + ((i + 1).ToString()) + "']");
                    if (link != null)
                    {
                        link.Click();
                    }

                    if (IsElementPresentUsingBy(locatorfordummyListConfirmationNumberDisplayed,baseDriver, Constants.shortLoadTime))
                    {
                        numberofRecords[i] = dummyListConfirmationNumberDisplayed.Count;
                        foreach (IWebElement ele in dummyListConfirmationNumberDisplayed)
                            confirmationnumberListPerPage = confirmationnumberListPerPage + "," + ele.Text;
                    }
                }

                //verify number of records per page is 10
                for (i = 0; i < (numberOfPages - 1); i++)
                {
                    Assert.IsTrue(numberofRecords[i] == 10, "Number of records in  page number " + (i + 1).ToString() + " was 10");
					extentTest.Info("Number of records in  page number " + (i + 1).ToString() + " is 10");
                }

                if (!(remainder > 0))
                {
                    remainder = 10;
                }

                //for last apge
                Assert.IsTrue(((numberofRecords[numberOfPages - 1]) == remainder), "Number of records in  page  " + numberOfPages.ToString() + " was not" + remainder);

				extentTest.Info("Number of records in  page  " + numberOfPages.ToString() + " is  " + remainder);

                //verify the confirmation numbers listed
                Assert.IsTrue((confirmationnumberList.Replace(",", "").Equals(confirmationnumberListPerPage.Replace(",", ""))), "The list of confirmation numbers shown across all the pages was not same as master list " + confirmationnumberListPerPage);
				extentTest.Info("The list of confirmation numbers shown across all the pages was same as master list " + confirmationnumberListPerPage);
                flag = true;
            }
			catch (Exception exception)
			{

				if (exception.InnerException != null)
				{
                   


                    throw exception.InnerException;

				}
				if (exception.Message != null)
				{
					throw exception;
				}
			}
			return flag;
        }//function

        //Bonus reservation Logic only//This gfuntion b ooks a bonus time reservation

        public static bool BonusTimeReservationLogic(string userName, TestContext testContextInstance, string destination, string selectdates, string wheelchair)
        {
            bool flag = false;
           GlobalObjects globalObjects = new GlobalObjects(baseDriver);

            try
            {


                TestBaseClass.currentType = Constants.bonustype;
                TestBaseClass.initializeTestScripts(destination, selectdates, wheelchair, testContextInstance);
                //Assert.IsTrue((TestBaseClass.SetUp(testContextInstance, Constants.Browser)), "BGO was not launched successfully");  //Login to BGO   
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "BGO was launched successfully");


                LoginPage loginPageObj = new LoginPage(baseDriver);
                //PageFactory.InitElements(baseDriver, loginPageObj);
                //Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj, userName, Constants.password), "Login was not succesful");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Login was succesful");


                //Navigate to Bonus Time Reservation Page
                AllMenus topMenuobj = new AllMenus(baseDriver);
               // PageFactory.InitElements(baseDriver, topMenuobj);

                //@@@@@@@@@@
                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforBonusTime };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.BonusTime };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Bonus Time" };

                string bb = ConfigurationManager.AppSettings["URlHomePageForBonusReservation"];
              //  Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, baseDriver, ConfigurationManager.AppSettings["URlHomePageForBonusReservation"]), "Bonus Time menu was not selected");

                MenuLevel2(ListOfMenuLocators, baseDriver);
                extentTest.Info("Bonus time reservaton was selected");
                
                HomePage homePageObj = new HomePage(baseDriver);
               // PageFactory.InitElements(baseDriver, homePageObj);
                


                //Verify bonus radio button should be defaultly selected
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForBonusTimeRadioButton,baseDriver, Constants.medLoadTime), "BonusTime Radio Buttion is not displayed or user did not reach homepage");
                Assert.IsTrue(homePageObj.BonusTimeRadioButton.Selected, "BonusTime Radio Buttion was not selected");
				extentTest.Info("BonusTime Radio Buttion is selected");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Bonus Time Radio Buttion was  selected");
                //Note down Available points 


                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
                //select the  destination, check in date,checkout date
                Assert.IsTrue(EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");

                ////Verify input check in date is selected in home page

                Assert.IsTrue((IsElementPresentUsingBy(homePageObj.locatorForCheckInDate, baseDriver,Constants.shortLoadTime)), "Check In date was not present");

                homePageObj.ValCheckindate = homePageObj.CheckInDate.Text.Trim();
                string cin = DateTime.Parse(homePageObj.ValCheckindate).ToString("M/d/yyyy");
                if (TestBaseClass.SelectDates.ToLower().Equals("yes"))
                {
                    Assert.IsTrue(cin.Equals(TestBaseClass.CheckInDate.Trim()), "c");
					extentTest.Info("The selected  check in date was correct in the home page");

					//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The selected  check in date was correct in the home page");

                }
                //Verify input check out date is selected in home page
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForCheckOutDate,baseDriver, Constants.shortLoadTime));
                homePageObj.ValCheckoutdate = homePageObj.CheckOutDate.Text.Trim();
                string cout = DateTime.Parse(homePageObj.ValCheckoutdate).ToString("M/d/yyyy");
                if (TestBaseClass.SelectDates.ToLower().Equals("yes"))
                {
                    Assert.IsTrue(cout.Equals(TestBaseClass.CheckoutDate.Trim()), "The selected  check out date was not correct in the home page");
					extentTest.Info("The selected  check out date was correct in the home page");
					//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The selected  check out date was correct in the home page");
                }
                ////Verify number of  nights in Home page


                homePageObj.SearchButton.Click();
                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage(baseDriver);
                //PageFactory.InitElements(baseDriver, SearchResultsObj);

                //Search Results page displayed with resort locations listed 

                IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;
                ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);
                int IFlag = TestBaseClass.SearchBonusTimeFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);


                //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                if ((IFlag == 3) || (IFlag == 4))
                {
                    extentTest.Info("Search result displayed");

                    SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);


                   

                    ClickButton(SearchResultsObj.btnShowResortAvailability, baseDriver);
                    extentTest.Info("Show availablity buttton is clicked");

                    GetWebdriverWait(baseDriver).Until(ExpectedConditions.InvisibilityOfElementLocated(globalObjects.locatorforLoadingIcon));

                    GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));


                    //Assert.IsTrue(IsElementVisible(SearchResultsObj.locatorForResultsTab, baseDriver, Constants.shortLoadTime), "Click on Show Resort Avaialblity button and check that avaialble resort details are displayed");
                    IReadOnlyCollection<IWebElement> rows = SearchResultsObj.ResultsTab.FindElements(By.TagName("tr"));


                    //IJavaScriptExecutor script = ((IJavaScriptExecutor)TestBaseClass.baseDriver);
                    //script.ExecuteScript("window.scrollBy(0,200)");
                    SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);
                 

                    JavascriptClickElement(SearchResultsObj.multiResultBookButton, baseDriver);
                    //Extends_TestBaseClass.ClickUsingJavaScript(SearchResultsObj.multiResultBookButton);
                    extentTest.Info("Book button is clicked");

                   // baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Constants.shortLoadTime);

                    //SearchResultsObj.multiResultBookButton.Click();

                    BonusTimeReservationPage confirmReservationPageObj = new BonusTimeReservationPage();
                    PageFactory.InitElements(baseDriver, confirmReservationPageObj);


                    GetWebdriverWait(baseDriver).Until(ExpectedConditions.InvisibilityOfElementLocated(globalObjects.locatorforLoadingIcon));

                    GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                    

                    if (IsElementPresent(globalObjects.LocatorForAlertforAccount, baseDriver))


                    {
                        extentTest.Error("Account is not in good standing and is blocked from booking due one of its account activity" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Current_Status").Build());
                        flag = false;
                        Assert.Fail("Account is not in good standing and is blocked from booking due one of its account activity");

                    }

                   else if (IsElementPresentUsingBy(confirmReservationPageObj.LocatorforTableForBonusAmount, baseDriver, Constants.medLoadTime))
                    {
                        extentTest.Info("Bonus time reservation page is displayed");


                        //Verify the check in date on confirm reservation page is matching with alterante date selected  from search results page

                        Assert.IsTrue((IsElementPresent(confirmReservationPageObj.locatorForTableCoumn_CheckIn, baseDriver)), "The check in date was not displayed in Bonus Time Reservation Page");
                        confirmReservationPageObj.checkindate = confirmReservationPageObj.TableCoumn_CheckIn.Text.Trim();


                        Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorForTableColumn_CheckOut, baseDriver));
                        confirmReservationPageObj.checkoutdate = confirmReservationPageObj.TableColumn_CheckOut.Text.Trim();

                        Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorforLab_ResortName, baseDriver));
                        confirmReservationPageObj.resortName = confirmReservationPageObj.Lab_ResortName.Text.Trim();

                        //Compare Points with Points shown in Search results page

                        if (!selectdates.ToUpper().Equals("1NIGHT"))
                        {
                            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorForTableColumn_Amount, baseDriver),"Amount table not displayed");
                            confirmReservationPageObj.totalamount = confirmReservationPageObj.TableColumn_Amount.Text.Trim();
                            confirmReservationPageObj.totalamount = confirmReservationPageObj.totalamount.Replace(",", "").Trim();
                            confirmReservationPageObj.totalamount = confirmReservationPageObj.totalamount.Replace("$", "").Trim();

                        }
                        else
                        {
                            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorforLab_DailyRate, baseDriver), "The Daily rate was not displayed for the room in Bonus ReservationPage");
                            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorforlocalTax, baseDriver), "The local tax was not displayed for the room in Bonus ReservationPage");
                            Assert.IsTrue(IsElementPresent(confirmReservationPageObj.locatorfortotalPaymentAtTop, baseDriver), "The Total Payment was not displayed for the room in Bonus ReservationPage");
                            confirmReservationPageObj.dailyTax = confirmReservationPageObj.localTax.Text.Trim().Replace("$", "").Replace(",", "");
                            confirmReservationPageObj.dailyrate = confirmReservationPageObj.Lab_DailyRate.Text.Trim().Replace("$", "").Replace(",", "");
                            confirmReservationPageObj.totalamount = confirmReservationPageObj.totalPaymentAtTop.Text.Trim().Replace("$", "").Replace(",", "");
                            decimal dt = 0;
                            decimal dr = 0;
                            decimal tamt = 0;

                            dt = Convert.ToDecimal(confirmReservationPageObj.dailyTax);
                            dr = Convert.ToDecimal(confirmReservationPageObj.dailyrate);
                            decimal Val = Convert.ToDecimal(confirmReservationPageObj.totalamount);
                            tamt = 2 * (dt + dr);
                            tamt = Math.Truncate(tamt);
                            Val = Math.Truncate(Val);
                            Assert.IsTrue((tamt.Equals(Val)), "TotalPrice" + confirmReservationPageObj.totalPaymentAtTop.Text + " was not twice sum of daily rate and daily tax" + tamt + "in Bonus ReservationPage");
                            extentTest.Info("TotalPrice" + confirmReservationPageObj.totalPaymentAtTop.Text + " was twice sum of daily rate and daily tax" + tamt + "in Bonus ReservationPag");
                            //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "TotalPrice" + confirmReservationPageObj.totalPaymentAtTop.Text + " was twice sum of daily rate and daily tax" + tamt + "in Bonus ReservationPage");
                        }



                        //Add all Details on confirm reservation page

                        Assert.IsTrue(fillContactandCreditCardDetailsInBonusTimeReservationPage(testContextInstance, confirmReservationPageObj), "The reservation,billing information or the Payment Informations section are not filled up correctly ");

                        ReservationConfirmationPage rcObj = new ReservationConfirmationPage(baseDriver);
                        //PageFactory.InitElements(baseDriver, rcObj);

                        ////Check that Confirmation Page is displayed .

                        Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForConfirmationNumber, baseDriver, Constants.medLoadTime), "The Reservation Confirmation Page was not displayed");
                        Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ConfirmationNumber.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ConfirmationNumber.Text)), "The Reservation Confirmation Number was not displayed for Bonus Time Reservation");
                        TestBaseClass.currentconfirmationNumber = rcObj.ConfirmationNumber.Text;
                        TestBaseClass.UrlForCurrentReservation = baseDriver.Url;
                        //Check Confimration Date
                        Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForConfirmationDate, baseDriver, Constants.medLoadTime), "The confirmation date was not shown in Bonus time Reservation Confirmation Page");

                        Assert.IsTrue(rcObj.ConfirmationDate.Text.Equals(DateTime.Now.ToString("MM/dd/yyyy").ToString()), "The confirmation date was not todays date  in Confirmation page");
                        extentTest.Info("The confirmation date on Confirmation page was todays date for Bonus Type Reservation");

                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation date on Confirmation page was todays date for Bonus Type Reservation");

                        ////Validate resort  name

                        Assert.IsTrue(IsElementPresent(rcObj.locatorForResortName, baseDriver), "The Resort Name was not shown on Bonus type reservation page");

                        Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ResortName.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ResortName.Text)));
                        rcObj.CPResortName = rcObj.ResortName.Text.Trim();
                        TestBaseClass.currentResortName = rcObj.CPResortName;
                        Assert.IsTrue(rcObj.CPResortName.Equals(confirmReservationPageObj.resortName));
                        extentTest.Info("The  resortname  on Confirmation page " + rcObj.CPResortName + "is same as that in the confirm reservation page");
                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The  resortname  on Confirmation page " + rcObj.CPResortName + "is same as that in the confirm reservation page");

                        ////Check the check in   date is displayed in confirmation Page

                        rcObj.checkindate = rcObj.CheckInDate.Text.Trim();
                        TestBaseClass.currentcheckInDate = rcObj.checkindate;

                        Assert.IsTrue(rcObj.checkindate.Equals(confirmReservationPageObj.checkindate));
                        extentTest.Info("The check in date  on Confirmation page is same as that in the confirm reservation page");
                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check in date  on Confirmation page is same as that in the confirm reservation page");

                        ////Check the check out  date is displayed in confirmation Page

                        rcObj.checkoutdate = rcObj.CheckOutDate.Text.Trim();
                        TestBaseClass.currentcheckOutDate = rcObj.checkoutdate;
                        Assert.IsTrue(rcObj.checkoutdate.Equals(confirmReservationPageObj.checkoutdate));
                        extentTest.Info("The check out date  on Confirmation page is same as that in the confirm reservation page");

                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check out date  on Confirmation page is same as that in the confirm reservation page");

                        // Check total price and daily price after booking

                        rcObj.totalamount = rcObj.Amt.Text.Trim();
                        rcObj.totalamount = rcObj.totalamount.Replace("$", "").Replace(",", "");
                        TestBaseClass.currentAmount = rcObj.totalamount;
                        decimal ConfimrmationTotAmount = 0;
                        decimal BReservationTotAmount = 0;

                        ConfimrmationTotAmount = Convert.ToDecimal(confirmReservationPageObj.totalamount);
                        BReservationTotAmount = Convert.ToDecimal(rcObj.totalamount);


                        //verify the total price displayed in confirmation page

                        Assert.IsTrue((ConfimrmationTotAmount == BReservationTotAmount), "TotalPrice " + BReservationTotAmount + "in confirmation page is not matching" + ConfimrmationTotAmount);
                        extentTest.Info("TotalPrice " + BReservationTotAmount + "in Bonus Reservation Page is matching" + ConfimrmationTotAmount + "shown in Confirmation page");

                        //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "TotalPrice " + BReservationTotAmount + "in Bonus Reservation Page is  matching" + ConfimrmationTotAmount + "shown in Confirmation page");
                        flag = true;
                    }
                }



            }
            catch (Exception exception)
            {
				if (exception.InnerException != null)
				{
					throw exception.InnerException;
					
				}
				else
				{
					throw exception;
				}
			}
            return flag;

        }


        //Cancel Reservation logic only -This function cancels a point reservationor bonus reservation
        public static bool CancelPointsOrBonusReservation(TestContext testContextInstance, string reservationType)
        {
			bool flag = false;
            try
            {
                HomePage homePageObj = new HomePage(baseDriver);
                //Capture the available point
                if (reservationType.Equals(Constants.pointstype))
                {
                    Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForCurrentPoints,baseDriver, Constants.shortLoadTime), "Available points were not shown in HomePage");
                    homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();
                }

                string cnum = TestBaseClass.currentconfirmationNumber;
                string cdate = TestBaseClass.confirmationdate;
                string checkin = TestBaseClass.currentcheckInDate;
                string checkout = TestBaseClass.currentcheckOutDate;
                string type = TestBaseClass.currentType;
                string amount = TestBaseClass.currentAmount;
                string resortname = TestBaseClass.currentResortName;
                string allConfirmationNumbers = null;
                bool foundelement = false;
                string pppstatus = TestBaseClass.currentPPPStatus;

				MyReservationPage myreservObj = new MyReservationPage(baseDriver);
                // baseDriver.Url = ConfigurationManager.AppSettings["UrlMyReservations"];

                MenuLevel1(new List<IWebElement> { homePageObj.logOffDiv, homePageObj.myReservation }, baseDriver);
                //var act = new Actions(baseDriver);
                //act.MoveToElement(homePageObj.logOffDiv).Perform();
                //act.MoveToElement(homePageObj.myReservation).Click().Build().Perform();


                allConfirmationNumbers = allConfirmationNumbers + cnum + ",";
                Assert.IsTrue(IsElementPresentUsingBy(myreservObj.locatorforCurrentReservationTable,baseDriver, Constants.medLoadTime), "The Current Reservation Table was not displayed");

                numberOfRowsInCurrentReservationsTable = myreservObj.CRTable_ListConfirmationNumber.Count;
                Assert.IsTrue(myreservObj.CRTable_ListConfirmationNumber.Count > 0, "Current Reservations Table had no confrimation numbers listed");
                extentTest.Info("Reseravtion table is present");

                //Changes done by Fathima
                //IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)baseDriver);
                //jsExecutor.ExecuteScript("window.scrollTo(0,400)");
                //Thread.Sleep(5000);
                GlobalObjects globaclObjects = new GlobalObjects(baseDriver);

                
                GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));
                // baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.shortLoadTime);



                if (myreservObj.CRTable_ListConfirmationNumber.Count >10)

                {
                    WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    if (IsElementPresentUsingBy(myreservObj.locatorforViewAllLink, baseDriver))
                    {
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    }
                    

                }



              //  var Reservationtable = GetElements(myreservObj.locatorforCRTable_ListConfirmationNumber, baseDriver);

                foreach (IWebElement confirmationNumberEle in myreservObj.CRTable_ListConfirmationNumber)
                {
                   
                    //string gg = confirmationNumberEle.Text;
                    if (confirmationNumberEle.Text.Equals(cnum.ToString()))
                    {
                      JavascriptClickElement(confirmationNumberEle,baseDriver);
                       foundelement = true;
                        extentTest.Info("Reservation confirmation number found");
                       break;
                    }
                }
               
                Assert.IsTrue(foundelement, "The confirmation number was not found on the My Reservations Page");
				extentTest.Info("The confirmation number " + cnum + " was found on the My Reservations Page");

                // confimration page is displayed
                ReservationConfirmationPage rcObj = new ReservationConfirmationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, rcObj);

                Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorForConfirmationNumber,baseDriver, Constants.medLoadTime), "Click on the confirmation number Link and the Reservation Confirmation Page was not shown ");


                Assert.IsTrue(rcObj.ConfirmationNumber.Text.Equals(cnum), "The Confirmation number shown on the Confirmation Page was not correct" + cnum);
				extentTest.Pass("Reservation confirmation page displated for"+cnum+"\r\n",AttachScrenshot(baseDriver,testContextInstance,"Reservation_confirm_page").Build());


                //CHECK CANCEL RESERVATIONS LINK
                Assert.IsTrue(IsElementPresent(rcObj.locatorforCancelReservationLink,baseDriver), "The Cancel reservation Link was not present in the Confirmation Page");
                rcObj.CancelReservationLink.Click();
                extentTest.Info("Cancel reservation link text is clicked");

                CancelReservationsPage cancelObj = new CancelReservationsPage(baseDriver);
               // PageFactory.InitElements(baseDriver, cancelObj);


                //verify confirmation number on Reservation Cancellation Request Page 
                Assert.IsTrue(IsElementPresentUsingBy(cancelObj.locatorforreservationConfirmationNumber,baseDriver, Constants.veryLongLoadTime), "The  Reservation Cancellation Request page was not shown");
                Assert.IsTrue(cancelObj.reservationConfirmationNumber.Text.Equals(cnum), "The reservation number  in   Reservation Cancellation Request page   was not " + cnum);
				extentTest.Pass("Reservation cancellation request page is shown for " + cnum + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Reservation_Canc_page").Build());

                //Cancel the reservation

                Assert.IsTrue(IsElementPresent(cancelObj.locatorforBtnCancelReservation,baseDriver), "Cancel reservation button was not  present in Reservation Cancellation Request page");

                cancelObj.BtnCancelReservation.Click();
                extentTest.Info("Cancel reservation button is clicked");

                //Compare Confirmation Number on Cancellation Confirmed Page  after cancellation
                Assert.IsTrue(IsElementPresentUsingBy(cancelObj.locatorforCancelPageConfirmationNumber,baseDriver, Constants.veryLongLoadTime), "Cancellation Confirmed Page was not shown" + cnum);

				extentTest.Pass("Cancellation confirmed page is shown for " + cnum+"\r\n",AttachScrenshot(baseDriver,testContextInstance,"Cancellation_Confirm_Page").Build());

                Assert.IsTrue(cnum.Equals(cancelObj.CancelPageConfirmationNumber.Text), "Confirmation Number on Cancellation Confirmed Page was not " + cnum);
                //Capture Cancellation Date in Cancellation Confirmed Page

                Assert.IsTrue(DateTime.Now.ToString("M/d/yyyy").ToString().Equals(cancelObj.CancelPageCancelledDate.Text), "The cancellation date on the cancellation confirmtaion page was incorrect.");
				extentTest.Info("The cancellation date on the cancellation confirmation page is correct");
                //Click on Back to Reservation Button

                Assert.IsTrue(IsElementPresent(cancelObj.locatorforBtnBacktoReservationInCancellationConfirmedPage,baseDriver), "Back to Reservation Button was not present in the Cancellation Confirmed Page");

                
                cancelObj.BtnBacktoReservationInCancellationConfirmedPage.Click();
                extentTest.Info("Back to reservation page button is present and clicked");


                MyReservationPage obj = new MyReservationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, obj);


                bool elementremoved = true; ;
                if ( IsAllElementsVisible(myreservObj.locatorforCRTable_ListConfirmationNumber, baseDriver))
                {
                    Assert.IsTrue(IsElementPresentUsingBy(obj.locatorforCurrentReservationTable,baseDriver, Constants.veryLongLoadTime), "Current Reservation Table was not shown in the MyReservations page");

                   // GetWebdriverWait(baseDriver, TimeSpan.FromMilliseconds(Constants.shortLoadTime)).Until(WaitForJsExecute(baseDriver));

                   

                    if (myreservObj.CRTable_ListConfirmationNumber.Count > 10)

                    {
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                        if (IsElementPresentUsingBy(myreservObj.locatorforViewAllLink, baseDriver))
                        {
                            WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                        }

                    }

                    foreach (IWebElement confirmationNumberEle in myreservObj.CRTable_ListConfirmationNumber)
                    {
                        //string gg = confirmationNumberEle.Text;
                        if (confirmationNumberEle.Text.Equals(cnum.ToString()))
                        {

                            elementremoved = false;

                        }
                    }
                }
                else
                {
                    Assert.IsFalse(IsElementPresentUsingBy(obj.locatorforCurrentReservationTable,baseDriver, Constants.medLoadTime), "Current Reservation Table should not be shown as there was only one reservation");
                    elementremoved = true;
                }
                Assert.IsTrue(elementremoved, "After Cancelling, Confirmation Number" + cnum + " was removed from  Current reservations ");
				extentTest.Info("After Cancelling, Confirmation Number" + cnum + " is removed from  Current reservations");
                //include code to check the available points
                flag = true;
                //include code to check the available points for pints type reservation
            }
            catch (Exception exception)
            {
				

					if (exception.InnerException != null)
					{
						
			            throw exception.InnerException;
					}
				else
				{ 
					throw exception;
				}
				
			}
				
            return flag;


        }


		//resend email itenary for bonus reservation
		public static bool ResendEmailItenarary(TestContext testContextInstance, string reservationType, string cnum)
		{
			bool flag = false;
			bool foundelement = false;
			try
			{


				foundelement = FindConfirmationNumberFromCurrentReservations(testContextInstance, TestBaseClass.currentconfirmationNumber);
				Assert.IsTrue(foundelement, "The confirmation number was not found on the My Reservations Page");
				extentTest.Info("The confirmation number " + cnum + " was found on the My Reservations Page");
				//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation number " + cnum + " was found on the My Reservations Page");

				ReservationConfirmationPage rcObj = new ReservationConfirmationPage(baseDriver);
				// PageFactory.InitElements(baseDriver, rcObj);

				Assert.IsTrue(IsElementPresent(rcObj.locatorforsendEmailWithItenary, baseDriver), "The Send Email With Itinerary Button was not present");
				extentTest.Pass("Send email button is present" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Sendemail_Button").Build());
                // TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The Send Email With Itinerary Button was present");
                // rcObj.sendEmailWithItenary.Click();
                ClickButton(rcObj.sendEmailWithItenary, baseDriver);

                GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));
                
				Assert.IsTrue(IsSingleELementVisible(rcObj.locatorfortoTextBox, baseDriver, Constants.medLoadTime), "The Text box to enter Email was not present");
				extentTest.Pass("Email text box is present" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "textbox_field").Build());

				//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The Text box to enter Email was present");

				Assert.IsTrue(IsSingleELementVisible(rcObj.locatorforSendVacationReservationBth, baseDriver, Constants.medLoadTime), "The Send Vacation Reservation Information button was not present");
				extentTest.Pass("Send email button is present" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Sendemail_button").Build());


				// TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The Send Vacation Remainder button was present");

				rcObj.toTextBox.SendKeys(Constants.multipleEmailIds); // 
				rcObj.SendVacationReservationBtn.Click();

				Assert.IsTrue(IsSingleELementVisible(rcObj.locatorforemailSentMessage, baseDriver, Constants.medLoadTime), "On entering email ids and submitting,The message " + Constants.EmailSentMsg + "was not shown.");
				extentTest.Pass("The message " + Constants.EmailSentMsg + "was shown." + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Emailsent_Message").Build());


				// TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "On entering email ids and submitting,The message " + Constants.EmailSentMsg + "was shown.");


				flag = true;
				
				
			}
			catch (Exception exception)
			{

				if (exception.InnerException != null)
				{
					throw exception.InnerException;
					
				}
				else
				{
					throw exception;					
					
				}
			}
            return flag;
		}
			//fillSaved Search
			public static bool fillSavedSearch(TestContext testContextInstance, SearchResultsPage searchObj)
        {
            bool flag = false;
            try
            {
                Random rnd = new Random();
                int snum = rnd.Next(100, 999);
                IJavaScriptExecutor js = (IJavaScriptExecutor)baseDriver;


                Constants.SavedSearchName1 = Constants.SavedSearchName1 + snum.ToString();
 				baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.medLoadTime);
				//Assert.IsTrue(isElementVisible(searchObj.locatorForcalenderNextArrow, Constants.medLoadTime), "The page load was not complete");
				searchObj.LinkSaveSearch.Click();
                extentTest.Info("Save search link is clicked");

				baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.medLoadTime);
				
                searchObj.TextBoxSearchName.SendKeys(Constants.SavedSearchName1);
				baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.medLoadTime);
				searchObj.BtnSaveSearch.Click();
                extentTest.Info("Save search button is clicked");

                if (IsElementPresentUsingBy(searchObj.locatorForMsgSearchSaved,baseDriver, Constants.shortLoadTime))
                    flag = true;
            }
			catch (Exception exception)
			{

				if (exception.InnerException != null)
				{
					throw exception.InnerException;
					
				}
				else
				{
					throw exception;
					
				}
			}
			return flag;
        }


        public static DataTable copySavedSearchesTableToDataTableForDashBoard(IReadOnlyCollection<IWebElement> AllRows)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Destination");
            dt.Columns.Add("MonthandYear");
            dt.Columns.Add("Nights");

            string[] td1Val = new string[5];
            try
            {

                if (AllRows.Count > 0)
                {
                    int j = 0;
                    foreach (IWebElement tr in AllRows)
                    {
                        IReadOnlyCollection<IWebElement> AllTD = FindElementsInsideAnotherUsingDriver(tr, "tagname", "td");


                        if (AllTD != null)
                        {
                            int i = 0;
                            foreach (IWebElement td in AllTD)
                            {
                                if (i == 0)
                                    td1Val[0] = td.Text;

                                else if (i == 1)
                                    td1Val[1] = td.Text;

                                else if (i == 2)
                                    td1Val[2] = td.Text;

                                else if (i == 3)
                                    td1Val[3] = td.Text;

                                else if (i == 4)
                                    td1Val[4] = td.Text;


                                i++;
                            }// foreach(IWebElement td  in AllTD)

                        }// if (AllTD.Count > 0)

                        //  if(td1Val1[0]!=null)
                        dt.Rows.Add(td1Val[0], td1Val[1], td1Val[2], td1Val[3], td1Val[4]);


                    }//foreach (IWebElement tr in AllRows)


                }//if (AllRows.Count > 0)
            }
			catch (Exception exception)
			{

				if (exception.InnerException != null)
				{
					throw exception.InnerException;


				}
				else
				{
					throw exception;

				}
			}
			return dt;
        }//function


        public static bool VerifySavedSearchesInDashBoardPage(TestContext testContextInstance, SearchResultsPage searchObj)
        {
            int index = -1;
            bool found = false;
            int found1 = 0;
            bool flag = false;

            IWebElement savedSearchRow = null;
            IWebElement savedSearchLink = null;

            try
            {
                MyDashboardPage dbObj = new MyDashboardPage();
                PageFactory.InitElements(baseDriver, dbObj);

                //changes done by Fathima
                //IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)baseDriver);
                //jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

                IsElementInvisible(dbObj.LocatorforRefresh, baseDriver);
                extentTest.Info("Overlay not displayed");


                ReadOnlyCollection<IWebElement> AllRows = FindElementsInsideAnotherUsingDriverUpdated(dbObj.SavedSearchesTable, "tagname", "tr");

                Assert.IsTrue(AllRows != null, "There were no rows in Saved Searches Section in My Dashboard Page");


				extentTest.Pass("Save search is present in MyDashboard page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Save_Searches").Build());
                
                //changes made by Fathima
                ScrollToView(dbObj.SavedSearchesTableHeader, baseDriver);

                DataTable dt = copySavedSearchesTableToDataTableForDashBoard(AllRows);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Name"].Equals(Constants.SavedSearchName1))
                    {
                        found = true;
						//search name
						extentTest.Info("Saved Search Name displayed is " + Constants.SavedSearchName1);
                        index = i;


                        //type
                        if ((dt.Rows[i]["Type"].ToString().ToLower().Trim().Contains(searchObj.Valtype)))
                        {
							extentTest.Info("In My Dashboard Page,Reservation Type shown in Saved Search  is " + dt.Rows[i]["Type"]);

                            found1 = ++found1;
                        }
                        else
                            found1 = --found1;


                        //destination
                        if ((dt.Rows[i]["Destination"].ToString().ToLower().Trim().Equals(searchObj.ValDestination.ToLower())))
                        {
							extentTest.Info("n My Dashboard Page,Destination shown in Saved Search is " + dt.Rows[i]["Destination"]);
                            found1 = ++found1;
                        }
                        else
                            found1 = --found1;

                        //MonthandYear
                        if ((dt.Rows[i]["MonthandYear"].ToString().ToLower().Replace(",", "").Trim().Equals(TestBaseClass.ValMonthandYear.ToLower())))
                        {
							extentTest.Info("In My Dashboard Page,Month and Year shown in Saved Search is " + dt.Rows[i]["MonthandYear"]);
                            found1 = ++found1;
                        }
                        else
                            found1 = --found1;


                        //Number of Nights
                        string a = (dt.Rows[i]["Nights"].ToString().ToLower().Trim());
                        string bb = TestBaseClass.ValNumNights.ToLower().Replace("nights", "").Replace(" ", "");
                        if ((dt.Rows[i]["Nights"].ToString().ToLower().Trim()).Equals(TestBaseClass.ValNumNights.ToLower().Replace("nights", "").Replace(" ", "")))
                        {

							extentTest.Info("In My Dashboard Page,Number of Nights shown in Saved Search is " + dt.Rows[i]["Nights"]);
                            found1 = ++found1;
                        }
                        else
                            found1 = --found1;
                        break;
                    }
                }
                //  baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond);
                
				//baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.shortLoadTime);
                Assert.IsTrue(found, "The Saved Search -" + Constants.SavedSearchName1 + "was not displayed in Saved Searches Table in MY DashBoard Page");
				extentTest.Pass("Save searches" + Constants.SavedSearchName1 + "is displayed " + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Save_Searches").Build());

                Assert.IsTrue((found1 == 4), "In My Dashboard Page,The details of Saved Search-" + Constants.SavedSearchName1 + "are not correct");
				extentTest.Info("In My Dashboard Page, the details of Saved Search - " + Constants.SavedSearchName1 + " are correct");


                savedSearchRow = AllRows[index];
                Assert.IsTrue(index >= 0, "The search " + Constants.SavedSearchName1 + " was not shown in MyDashBoard page");

                IWebElement savedSearchCol = FindElementInsideAnotherUsingDriver(savedSearchRow, "tagname", "td");
                if (savedSearchCol != null)
                    savedSearchLink = FindElementInsideAnotherUsingDriver(savedSearchCol, "tagname", "a");

                if (savedSearchLink != null)
                {

                    savedSearchLink.Click();

                }


				baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.medLoadTime);
				
                Assert.IsTrue(IsElementPresentUsingBy(searchObj.locatorForPointsButton,baseDriver, Constants.medLoadTime), "On Clicking the saved search Name from DashBoard page,The Search Results Page was not shown");

				extentTest.Pass("On Clicking the saved search, search results page is shown" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Searchresult_Page").Build());



				string b = searchObj.SelectedDestination.Text;
                Assert.IsTrue(searchObj.SelectedDestination.Text.Trim().Replace(" ", "").Replace(@"\r", "").Replace("\n", "").ToLower().ToString().Equals(searchObj.ValDestination.Replace(" ", "").Trim().ToLower()), "The Destination was not " + searchObj.ValDestination + " in Search Results");

				extentTest.Info("In Search Results page the destination  " + searchObj.ValDestination + "is selected");



                Assert.IsTrue((searchObj.MonthEntry.Text.ToString().ToLower().Replace(",", "").Trim().Equals(TestBaseClass.ValMonthandYear.ToLower())), "The Month and Year shown  was not correct in Search Results");
				extentTest.Info("The Month and Year" + searchObj.MonthEntry.Text + " in Search Results");



                Assert.IsTrue((searchObj.nightsEntry.Text.ToLower().Replace("\r", "").Replace("\n", "").Replace("nights", "").Replace(" ", "").Equals(TestBaseClass.ValNumNights.ToLower().Replace("nights", "").Replace(" ", ""))), "In Search Results page the Month and Year shown was" + searchObj.nightsEntry.Text.ToLower().Replace("\r", "").Replace("\n", "").Replace("nights", "").Replace(" ", ""));
				extentTest.Info("In Search Results page the Month and Year shown was" + searchObj.MonthEntry.Text);


                flag = true;
            }
			catch (Exception exception)
			{

				if (exception.InnerException != null)
				{
					throw exception.InnerException;
                    extentTest.Error(exception.Message);

				}
				else
				{
					throw exception;
                    extentTest.Error(exception.Message);


                }
            }
			return flag;

        }//function


        public static bool compareActualAndExpectedValues(TestContext testContextInstance, List<By> locatorForField, string[] expectedValue, string[] actualValue, string[] fieldName, string pageName)
        {
            bool flag = true;
            try
            {
                for (int i = 0; i < expectedValue.Length; i++)
                {
                    if (IsElementPresent(locatorForField[i], baseDriver))
                    {
                        actualValue[i] = actualValue[i].Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "");
                        expectedValue[i] = expectedValue[i].Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "");

                        if (expectedValue[i].ToLower().Equals(actualValue[i].ToLower()))
                        {

                            extentTest.Info("The " + fieldName[i] + " was shown as  " + actualValue[i]);
                        }
                        else
                        {
                            extentTest.Info("The " + fieldName[i] + " was shown as  " + actualValue[i]);
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

            catch(Exception exception)
            {
                throw exception;
            }
            return flag;
        }//end of function


        public static bool SearchPWL(TestContext testContextInstance, string action)
        {
            bool flag = false;
            PWLSubmitRequestPage pwlsubmitobj = new PWLSubmitRequestPage(baseDriver);
            PWLSearchPage pwlSearchObj = new PWLSearchPage(baseDriver);

           // PageFactory.InitElements(baseDriver, pwlsubmitobj);

            try
            {
                Actions act = new Actions(baseDriver);
                //select search date
                if (action.ToLower().Equals("add"))
                {
                    Assert.IsTrue(IsElementPresentUsingBy(pwlSearchObj.locatorforResortName,baseDriver, Constants.shortLoadTime), "PWL Search Page  was not displayed");
                    extentTest.Info( "PWL Search Page  was displayed");

                    SelectElement dropdown1 = new SelectElement(pwlSearchObj.ResortName);
                  //  pwlSearchObj.ResortName.Click();
                    dropdown1.SelectByIndex(Constants.Index);
                    baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.PageLoadTimeInSecond);

                   // Thread.Sleep(5000);

                }
                else
                {
                    Assert.IsTrue(IsElementPresentUsingBy(pwlSearchObj.locatorforlabResortname,baseDriver), "On Clicking  the Edit request button for " + pwlreqId + ",Edit Request Page was not displayed");
                    extentTest.Info("On Clicking  the Edit request button for" + pwlreqId + ",Edit Request Page was displayed");

                    GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                    pwlSearchObj.CheckInDate.Click();
                    Assert.IsTrue(IsElementPresentUsingBy(pwlSearchObj.locatorfordate_EditReq_Calender, baseDriver), "Check in Date was not selectable in Edit Request Page");

                    act.MoveToElement(pwlSearchObj.SelectDate).Click().Perform();
                    
                    extentTest.Info("Check in date was selected");

                   

                }
                
                pwleditcheckindate = GetElement(pwlSearchObj.locatorforCheckInDate, baseDriver).GetAttribute("value");
                extentTest.Info($"Checkin date : {pwleditcheckindate}");

                pwleditcheckoutdate =GetElement(pwlSearchObj.locatorforCheckOutDate,baseDriver).GetAttribute("value");
                extentTest.Info($"Checkout date : {pwleditcheckoutdate}");

                GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                WaitForElementToBeClickable(pwlSearchObj.locatorforSearch, baseDriver).Click();
                //SearchButton.Click();

               // baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


               // PWLSubmitRequestPage submitObj = new PWLSubmitRequestPage();
                if (action.ToLower().Equals("add"))
                {
                   
                    // GetWebdriverWait(baseDriver, TimeSpan.FromSeconds(Constants.shortLoadTime)).Until(GetElementsFunc(submitObj.locatorforSubmitNewRequest));
                    Assert.IsTrue(IsSingleELementVisible(pwlsubmitobj.locatorforSubmitNewRequest, baseDriver), "On Searching from PWL Search Page,Submit New Request Page was not displayed");
                    extentTest.Info( "On Searching from PWL Search Page,Submit New Request Page was displayed");
                }
                else
                {
                    Assert.IsTrue(IsSingleELementVisible(pwlsubmitobj.locatorforSubmitNewRequest, baseDriver), "On Searching from PWL Edit Request Page,Submit Request Edit Page was not displayed");
                    extentTest.Info( "On Searching from PWL Search Page,Submit Request Edit Page was displayed");

                }
                flag = true;
            }
            catch (Exception e)
            {
               // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());

                throw e;
               
               
            }

            return flag;

        }

        public static bool fillPWLSubmitNewRequestPage(TestContext testContextInstance, PWLSubmitRequestPage submitObj, string action)
        {
            bool flag = false;
            try
            {

                submitObj.FirstName.Clear();
                submitObj.LastName.Clear();
                submitObj.GuestPhone.Clear();
                submitObj.Email.Clear();
                submitObj.SpecialRequest.Clear();
                SelectElement dropdown1 = new SelectElement(submitObj.NumberOfGuests);

                if (action.ToLower().Equals("add"))
                {
                    //IJavaScriptExecutor script = ((IJavaScriptExecutor)baseDriver);
                    //script.ExecuteScript("window.scrollBy(0,-100)");
                    JavascriptClickElement(submitObj.roomType, baseDriver);
                    //Click();
                    submitObj.FirstName.SendKeys(Constants.Firstname);
                    submitObj.LastName.SendKeys(Constants.LastName);
                    submitObj.GuestPhone.SendKeys(Constants.Phone);
                    submitObj.Email.SendKeys(Constants.Email);
                    dropdown1.SelectByIndex(1);
                    pwlguestsnum = submitObj.NumberOfGuests.GetAttribute("value");
                    pwlroomtypeVal = submitObj.Label_roomType.Text.Trim();

                }
                else
                {
                    if (IsSingleELementVisible(submitObj.locatorforroomType2,baseDriver, Constants.shortLoadTime))
                    {
                        IJavaScriptExecutor script = ((IJavaScriptExecutor)baseDriver);
                        script.ExecuteScript("window.scrollBy(0,-100)");
                        JavascriptClickElement(submitObj.roomType2, baseDriver);
                        //submitObj.roomType2.Click();
                        pwleditroomtypeVal = submitObj.Label_roomType2.Text.Trim();
                    }
                    else
                        pwleditroomtypeVal = pwlroomtypeVal;

                    dropdown1.SelectByIndex(2);
                    submitObj.FirstName.SendKeys(Constants.EditGuestFirstName);
                    submitObj.LastName.SendKeys(Constants.EditGuestLastName);
                    submitObj.GuestPhone.SendKeys(Constants.EditPhone);
                    submitObj.Email.SendKeys(Constants.EditEmail);
                    submitObj.SpecialRequest.SendKeys(Constants.EditvalSpecialRequest);

                    pwleditguestsnum = submitObj.NumberOfGuests.GetAttribute("value");

                }

                //capture values

                submitObj.IAgreeCheckBox.Click();

                submitObj.Submit.Click();

                PWLConfirmationPage confirmObj = new PWLConfirmationPage();
                PageFactory.InitElements(baseDriver, confirmObj);

                if (action.ToLower().Equals("add"))
                    Assert.IsTrue(IsSingleELementVisible(confirmObj.locatorforrequestID,baseDriver, Constants.shortLoadTime), "After adding a new request,The PWL confirmation number was not shown");
                else
                    Assert.IsTrue(IsSingleELementVisible(confirmObj.locatorforrequestIDUpdated,baseDriver, Constants.shortLoadTime), "After editing the request,The PWL confirmation number was not shown");
                flag = true;
            }
            catch (Exception e)
            {
               // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                
            }
            return flag;
        }

        //validate confirmation number and message
        public static bool validatePwlIsSuccesfullyCreated(TestContext testContextInstance, string pagename, string action)
        {
            bool flag = false;
            try
            {
                PWLConfirmationPage confirmObj = new PWLConfirmationPage();
                PageFactory.InitElements(baseDriver, confirmObj);

                MyDashboardPage dbobj = new MyDashboardPage();
                PageFactory.InitElements(baseDriver, dbobj);

                PWLRequestHistoryPage historyobj = new PWLRequestHistoryPage();
                PageFactory.InitElements(baseDriver, historyobj);


                if (!(pagename.ToLower().Equals("dashboard")))
                {

                    if (IsElementPresent(confirmObj.locatorforSeePendingRequestLink, baseDriver))
                    {
                        extentTest.Info("Pending request link is visible");
                        ClickButton(confirmObj.locatorforSeePendingRequestLink, baseDriver);
                        extentTest.Info("pending request link is clicked");
                    }

                   // confirmObj.pendingRequestHyperLink.Click();

                    
                    baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                       Assert.IsTrue((IsSingleELementVisible(historyobj.locatorforPendingRequestTable, baseDriver)), "On clicking See Pending and Serviced Request link ,Request History Page was not  displayed");
                        IReadOnlyCollection<IWebElement> AllRows = historyobj.PendingRequestTable.FindElements(By.TagName("tr"));
                        DataTable dt = copyHtmlTableToDatTableForPWL(AllRows);
                        Assert.IsTrue(VerifyPWLRequestHistoryPendingRequestTableContents(testContextInstance, dt, pwlreqId, pwlresortName, pwlguestsnum, pwlcheckindate, pwlcheckoutdate, pwlroomtypeVal), "The Added PWL details were not properly shown  in PWL Request History page");
                        extentTest.Info("The PWL details were properly shown  in PWL Request History page");
                    
                }
                else
                {
                    AllMenus topMenuobj = new AllMenus();
                    // baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];

                    List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMyDashBoard };

                    MenuLevel1(ListOfMenuLocators, baseDriver);

                   // ScrollToView(dbobj.PWLtext, baseDriver);
                   baseDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)Utilities.Timeout.ImplicitWaitInSecond);

                    if (!IsSingleELementVisible(dbobj.locatorforMakeAPWL, baseDriver))
                    {

                        extentTest.Info("PWL table is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbobj.LocatorforRefresh, baseDriver);
                        Assert.IsTrue(IsSingleELementVisible(dbobj.PWLTable, baseDriver), "PWL table was not shown in my DashBoard page");
                        extentTest.Pass("The PWL table was shown in My Dashboard page", AttachScrenshot(baseDriver, testContextInstance, "PWLsuccessfullyCreated").Build());

                    }

                    else
                    {

                        Assert.IsTrue(IsSingleELementVisible(dbobj.PWLTable, baseDriver), "PWL table was not shown in my DashBoard page");
                        extentTest.Pass("The PWL table was shown in My Dashboard page", AttachScrenshot(baseDriver, testContextInstance, "PWLsuccessfullyCreated").Build());

                    
                    }
                        
                    

                 
                   

                    IReadOnlyCollection<IWebElement> AllRows = FindElementsInsideAnotherUsingDriverUpdated(dbobj.PWLTable, "tagname", "tr");
                    DataTable dt = copyHtmlTableToDataTableForDashBoard(AllRows);
                    Assert.IsTrue(VerifyPWLInDashBoardPage(testContextInstance, dt, pwlreqId, pwlcheckindate, pwlcheckoutdate, pwlroomtypeVal, pwlresortName), "The PWL details were not properly shown  in PWL section in My Dashboard page");
                   extentTest.Info("The PWL details were properly shown  in PWL section in My Dashboard page");
                }

                flag = true;
            }
            catch (Exception e)
            {
               //// extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                throw e;
                
            }
            return flag;
        }

        //
        public static DataTable copyHtmlTableToDatTableForPWL(IReadOnlyCollection<IWebElement> AllRows)
        {
            //   try
            //   { 
            DataTable dt = new DataTable();
            dt.Columns.Add("RequestID");
            dt.Columns.Add("ResortName");
            dt.Columns.Add("Guest");
            dt.Columns.Add("CheckInDate");
            dt.Columns.Add("CheckOutDate");
            dt.Columns.Add("UnitEstimatedPoints");
            dt.Columns.Add("DateEntered");
            dt.Columns.Add("Status");
            string[] td1Val = new string[8];

            if (AllRows.Count > 0)
            {
                int j = 0;
                foreach (IWebElement tr in AllRows)
                {
                    IReadOnlyCollection<IWebElement> AllTD = FindElementsInsideAnotherUsingDriver(tr, "tagname", "td");

                    if ((j >= 1) && (j <= Constants.Num_Records_PWl_RequestHistory))
                    {
                        if (AllTD.Count > 0)
                        {
                            int i = 0;
                            foreach (IWebElement td in AllTD)
                            {
                                if (i == 0)
                                    td1Val[0] = td.Text;

                                else if (i == 1)
                                    td1Val[1] = td.Text;

                                else if (i == 2)
                                    td1Val[2] = td.Text;

                                else if (i == 3)
                                    td1Val[3] = td.Text;

                                else if (i == 4)
                                    td1Val[4] = td.Text;

                                else if (i == 5)
                                    td1Val[5] = td.Text;

                                else if (i == 6)
                                    td1Val[6] = td.Text;

                                else if (i == 7)
                                    td1Val[7] = td.Text;

                                i++;
                            }// foreach(IWebElement td  in AllTD)

                        }// if (AllTD.Count > 0)

                        //  if(td1Val1[0]!=null)
                        dt.Rows.Add(td1Val[0], td1Val[1], td1Val[2], td1Val[3], td1Val[4], td1Val[5], td1Val[6], td1Val[7]);
                    }
                    j++;
                }//foreach (IWebElement tr in AllRows)
            }//if (AllRows.Count > 0)
            return dt;
        }//function

        //

        public static bool VerifyPWLRequestHistoryPendingRequestTableContents(TestContext testContextInstance, DataTable dt, string reqid, string resortname, string guestsnum, string cin, string cout, string unit)
        {
            bool flag = false;

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    flag = false;
                    if (dt.Rows[i]["RequestID"].Equals(reqid))
                    {
                        flag = true;
                        //requset id
                        extentTest.Info(testContextInstance+"RequestID " + dt.Rows[i]["RequestID"] + " was shown in Pending Requests table");

                        string[] arr = new string[3];
                        arr = resortname.Split(',');
                        //resortname
                        string resortname1 = dt.Rows[i]["ResortName"].ToString().Trim().ToLower();
                        string resortname2 = arr[0].ToString().Trim().ToLower();
                        if ((arr[0].Equals(dt.Rows[i]["ResortName"])))
                        {
                         extentTest.Info( "ResortName " + dt.Rows[i]["ResortName"] + " was shown in Pending Requests table");

                        }
                        else
                            flag = false;

                        //Guest
                        if ((dt.Rows[i]["Guest"].ToString().Trim().Equals(guestsnum)))
                        {
                            extentTest.Info( "Guest " + dt.Rows[i]["Guest"] + " was shown in Pending Requests table");

                        }
                        else
                            flag = false;

                        //CheckInDate
                        if ((dt.Rows[i]["CheckInDate"].ToString().Trim().Equals(cin)))
                        {
                        extentTest.Info( "CheckInDate " + dt.Rows[i]["CheckInDate"] + " was shown in Pending Requests table");


                        }
                        else
                            flag = false;

                        //CheckOutDate
                        if ((dt.Rows[i]["CheckOutDate"].ToString().Trim().Equals(cout)))
                        {
                            extentTest.Info( "CheckOutDate " + dt.Rows[i]["CheckOutDate"] + " was shown in Pending Requests table");

                        }
                        else
                            flag = false;

                        //UnitEstimatedPoints
                        if ((dt.Rows[i]["UnitEstimatedPoints"].ToString().Trim().Equals(unit)))
                        {
                           extentTest.Info( "UnitEstimatedPoints " + dt.Rows[i]["UnitEstimatedPoints"] + " was shown in Pending Requests table");

                        }
                        else
                            flag = false;
                        //DateEntered
                        if ((dt.Rows[i]["DateEntered"].ToString().Trim().Equals(Constants.CurrentDate)))
                        {
                            extentTest.Info( "DateEntered " + dt.Rows[i]["DateEntered"] + " was shown in Pending Requests table");
                        }
                        else
                            flag = false;
                        //Status
                        if ((dt.Rows[i]["Status"].ToString().ToLower().Equals(Constants.PWLPendingStatus.ToLower())))
                        {
                            extentTest.Info( "Status " + dt.Rows[i]["Status"] + " was shown in Pending Requests table");
                        }
                        else
                            flag = false;

                        break;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
               

            }
            return flag;
        }//function


        //create pwl

        public static bool CreatePWLFromDashBoardOrBookMenu(TestContext testContextInstance, string userName, string pagename)
        {
            bool flag = true;
            try
            {
                LoginPage loginPageObj = new LoginPage(baseDriver   );
                //PageFactory.InitElements(baseDriver, loginPageObj);

                PWLSearchPage pwlSearchObj = new PWLSearchPage(baseDriver);

                AllMenus topMenuobj = new AllMenus(baseDriver);
                //PageFactory.InitElements(baseDriver, topMenuobj);

                if (pagename.ToLower().Equals("dashboard"))
                {
                    List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen,  topMenuobj.locatorforMyDashBoard };
                    List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu,  topMenuobj.MyDashBoard };
                    List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "My BlueGreen", "My Dashboard" };

                    // Changes done by Fathima
                    
                    MenuLevel1(ListOfMenuLocators, baseDriver);

                    MyDashboardPage dbobj = new MyDashboardPage(baseDriver);

                    baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond);

                    //var expected = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];
                    //var actual = baseDriver.Url;

                    //Assert.IsTrue(expected.Contains(actual), "My DashBoard page was not displayed on selecting the top menu");

                    Assert.IsTrue(IsElementPresentUsingBy(dbobj.locatorforMyDashboardPage,baseDriver), "My DashBoard page was not displayed on selecting the top menu");
                    extentTest.Pass("My DashBoard page was displayed on selecting the top menu", AttachScrenshot(baseDriver, testContextInstance, "MyDashboardPageDisplayed").Build());
                    
                    // Assert.IsTrue(IsElementVisible(dbobj.locatorforMakeAPWL, baseDriver, Constants.shortLoadTime), "Make Premier Wait List Link was not present in my Dashboards page");
                    //  extentTest.Pass("Make Premier Wait List Link was present in my Dashboards page", AttachScrenshot(baseDriver, testContextInstance, "MakeaPWLlink_Present").Build());

                    //   ClickonElement(dbobj.locatorforMakeAPWL, baseDriver);


                    if (!IsSingleELementVisible(dbobj.locatorforMakeAPWL, baseDriver))
                    {

                        extentTest.Info("Make Pwl link is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbobj.LocatorforRefresh, baseDriver);
                        WaitForElementToBeClickable(dbobj.locatorforMakeAPWL, baseDriver).Click();
                    }
                    else
                    {
                        extentTest.Info("Make Pwl link is visible");

                       
                        WaitForElementToBeClickable(dbobj.locatorforMakeAPWL, baseDriver).Click();
                        extentTest.Info("Make Pwl link is clicked");
                    }
                     


                    
                        
                    
                        
                    
                }
                else
                {
                    List<By> ListOfMenuLocators = new List<By>() {  topMenuobj.locatorforBook, topMenuobj.locatorforPremierWaitList };
                    List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.PremierWaitList };
                    List<String> ListOfMenuNames = new List<String>() { "Book", "PremierWaitList" };

                    MenuLevel1(ListOfMenuLocators, baseDriver);

                    Assert.IsTrue(IsElementPresentUsingBy(pwlSearchObj.locatorforResortName, baseDriver, Constants.shortLoadTime), "PWL Search Page  was not displayed");
                    extentTest.Pass("The Search PWL page was shown", AttachScrenshot(baseDriver, testContextInstance, "PWLsearchPageDisplayed").Build());

                    //Assert.IsTrue((TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, baseDriver, ConfigurationManager.AppSettings["URlPWLPage"])), "The Search PWL page was not shown");
                    //extentTest.Pass("The Search PWL page was shown", AttachScrenshot(baseDriver, testContextInstance, "PWLsearchPageDisplayed").Build());

                }

                //$$

               //PWLSearchPage pwlSearchObj = new PWLSearchPage(baseDriver);
                //PageFactory.InitElements(baseDriver, pwlSearchObj);

                Assert.IsTrue(SearchPWL(testContextInstance, "add"), "The Search from PWL Search Page was not succesful");
                extentTest.Pass("The Search from PWL Search Page was succesful", AttachScrenshot(baseDriver, testContextInstance, "PWLsearchPageDisplayed").Build());

                PWLSubmitRequestPage pwlsubmitobj = new PWLSubmitRequestPage(baseDriver);
               // PageFactory.InitElements(baseDriver, pwlsubmitobj);

                //checkin date
                Assert.IsTrue(IsElementPresentUsingBy(pwlsubmitobj.locatorforLab_checkInDate,baseDriver,   Constants.shortLoadTime), "Check In Date was not displayed in PWL Submit request Page");
                pwlcheckindate = pwlsubmitobj.Lab_checkInDate.Text.Trim();
                //checkout date

                Assert.IsTrue(IsElementPresentUsingBy(pwlsubmitobj.locatorforLab_checkOutDate,baseDriver, Constants.shortLoadTime), "Check Out Date was not displayed in PWL Submit request Page");
                pwlcheckoutdate = pwlsubmitobj.Lab_checkOutDate.Text.Trim();

                //resortname
                Assert.IsTrue(IsElementPresentUsingBy(pwlsubmitobj.locatorforLab_resortName,baseDriver, Constants.shortLoadTime), "Resort Name was not displayed in PWL Submit request Page");
                pwlresortName = pwlsubmitobj.Lab_resortName.Text.Trim();

                Assert.IsTrue(fillPWLSubmitNewRequestPage(testContextInstance, pwlsubmitobj, "add"), "The PWl Submit Request was not succesful");


                PWLConfirmationPage confirmObj = new PWLConfirmationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, confirmObj);

                pwlreqId = confirmObj.requestID.Text;

                Assert.IsTrue(confirmObj.confimationMessage.Text.Trim().Contains(Constants.PWLConfirmationMessage.Trim()), "Confirmation Message was not" + Constants.PWLConfirmationMessage.Trim());
                extentTest.Info( "The confirmation message was " + Constants.PWLConfirmationMessage);

                Assert.IsTrue((!((String.IsNullOrEmpty(pwlreqId)) || (String.IsNullOrWhiteSpace(pwlreqId)))), "The PWL confirmation number was not valid");
                extentTest.Info( "The PWL confirmation number was " + pwlreqId);

                flag = true;
            }
            catch (Exception e)
            {
                
               // extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());

                throw e;
            }
            return flag;
        }

        //
        public static DataTable copyHtmlTableToDataTableForDashBoard(IReadOnlyCollection<IWebElement> AllRows)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Accomodation");
            dt.Columns.Add("RequestID");
            dt.Columns.Add("RequestDate");
            dt.Columns.Add("CheckInDate");
            dt.Columns.Add("CheckOutDate");
            dt.Columns.Add("Total");
            dt.Columns.Add("Status");
            string[] td1Val = new string[7];

            if (AllRows.Count > 0)
            {
                int j = 0;
                foreach (IWebElement tr in AllRows)
                {
                    IReadOnlyCollection<IWebElement> AllTD = FindElementsInsideAnotherUsingDriver(tr, "tagname", "td");


                    if (AllTD != null)
                    {
                        int i = 0;
                        foreach (IWebElement td in AllTD)
                        {
                            if (i == 0)
                                td1Val[0] = td.Text;

                            else if (i == 1)
                                td1Val[1] = td.Text;

                            else if (i == 2)
                                td1Val[2] = td.Text;

                            else if (i == 3)
                                td1Val[3] = td.Text;

                            else if (i == 4)
                                td1Val[4] = td.Text;

                            else if (i == 5)
                                td1Val[5] = td.Text;

                            else if (i == 6)
                                td1Val[6] = td.Text;

                            //else if (i == 7)
                            //    td1Val[7] = td.Text;

                            i++;
                        }// foreach(IWebElement td  in AllTD)

                    }// if (AllTD.Count > 0)

                    dt.Rows.Add(td1Val[0], td1Val[1], td1Val[2], td1Val[3], td1Val[4], td1Val[5], td1Val[6]);


                }//foreach (IWebElement tr in AllRows)


            }//if (AllRows.Count > 0)

            return dt;
        }

        //
        public static bool VerifyPWLInDashBoardPage(TestContext testContextInstance, DataTable dt, string reqid, string cin, string cout, string roomtypeval, string resortname)
        {

            bool flag = false;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    flag = false;
                    if (dt.Rows[i]["RequestID"].Equals(reqid))
                    {
                        flag = true;
                        extentTest.Info("RequestID " + reqid + "was shown in Premier wait List Section In My DashBoard Page");

                        string[] arr = new string[3];
                        arr = resortname.Split(',');
                        //resortname
                        string resortname1 = dt.Rows[i]["Accomodation"].ToString().Trim().ToLower();
                        string resortname2 = arr[0].ToString().Trim().ToLower();
                        if (resortname1.Equals(resortname2))
                            extentTest.Info("ResortName " + resortname + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;

                        //CheckInDate
                        if ((dt.Rows[i]["CheckInDate"].ToString().Trim().Equals(cin)))
                            extentTest.Info("CheckInDate " + cin + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;

                        //CheckOutDate
                        if ((dt.Rows[i]["CheckOutDate"].ToString().Trim().Equals(cout)))
                            extentTest.Info("CheckOutDate " + cout + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;

                        //UnitEstimatedPoints
                        if ((dt.Rows[i]["Total"].ToString().Trim().Equals(roomtypeval)))
                            extentTest.Info("RoomType " + roomtypeval + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;
                        //DateEntered
                        if ((dt.Rows[i]["RequestDate"].ToString().Trim().Equals(Constants.CurrentDate)))
                            extentTest.Info("RequestDate " + dt.Rows[i]["RequestDate"] + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;

                        //Status
                        if ((dt.Rows[i]["Status"].ToString().ToLower().Equals(Constants.PWLPendingStatus.ToLower())))
                            extentTest.Info("Status " + dt.Rows[i]["Status"] + "was shown in Premier wait List Section In My DashBoard Page");
                        else
                            flag = false;

                        break;
                    }
                }
            }
            catch (Exception e)
            {
               extentTest.Error(e.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                throw e;

            }
            return flag;
        }

        //

        public static bool CancePwlFromDashBoardOrBookMenu(TestContext testContextInstance, string pagename)
        {
            bool flag = false;
            try
            {
                PWLConfirmationPage confirmObj = new PWLConfirmationPage();
                PageFactory.InitElements(baseDriver, confirmObj);

                MyDashboardPage dbobj = new MyDashboardPage();
                PageFactory.InitElements(baseDriver, dbobj);

                PWLRequestHistoryPage historyobj = new PWLRequestHistoryPage();
                PageFactory.InitElements(baseDriver, historyobj);


                if (!(pagename.ToLower().Equals("dashboard")))
                {
                   WaitForElementToBeClickable(confirmObj.locatorforSeePendingRequestLink,baseDriver).Click();

                    Assert.IsTrue((IsSingleELementVisible(historyobj.locatorforPendingRequestTable,baseDriver, Constants.shortLoadTime)), "On clicking See Pending and Serviced Request link ,Request History Page was not  displayed");
                    extentTest.Pass("Request History Page was not  displayed", AttachScrenshot(baseDriver, testContextInstance, "RequestHistoryPageDisplayed").Build());

                    Assert.IsTrue(CancelPWlLogic(testContextInstance, pagename), "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table");
                   extentTest.Info( "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table");
                }
                else
                {
                    AllMenus topMenuobj = new AllMenus();
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];



                    if(!IsSingleELementVisible(dbobj.locatorforPWLTable, baseDriver))
                    {

                        extentTest.Info("PWL table is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbobj.LocatorforRefresh, baseDriver);
                        IsSingleELementVisible(dbobj.locatorforPWLTable, baseDriver);
                        Assert.IsTrue(CancelPWlLogic(testContextInstance, pagename), "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                        extentTest.Info("On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                    }
                    else
                    {
                        extentTest.Info("Pwl table is visible");
                        IsSingleELementVisible(dbobj.locatorforPWLTable, baseDriver);
                        Assert.IsTrue(CancelPWlLogic(testContextInstance, pagename), "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                        extentTest.Info("On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                    }

                    

                  //  Assert.IsTrue(IsElementVisible(dbobj.locatorforPWLTable,baseDriver, Constants.shortLoadTime), "PWL table was not shown in my DashBoard page");
                    
                }

                flag = true;
            }
            catch (Exception e)
            {
                throw e;
                //extentTest.Info(e);
               
            }
            return flag;
        }


        public static bool CancelPWlLogic(TestContext testContextInstance, string pagename)
        {
            bool flag = false;
            try
            {
                MyDashboardPage dbObj = new MyDashboardPage();
                PageFactory.InitElements(baseDriver, dbObj);
                bool elementFound = false;
                int numberOfRowsPresent = 0;

                PWLRequestHistoryPage historyObj = new PWLRequestHistoryPage();
                PageFactory.InitElements(baseDriver, historyObj);

                string pendingstatus = Constants.PWLPendingStatus.ToLower();

                if (!(pagename.ToLower().Equals("dashboard")))
                {
                    ReadOnlyCollection<IWebElement> AllRows1 = FindElementsInsideAnotherUsingDriverUpdated(historyObj.PendingRequestTable, "tagname", "tr");
                    numberOfRowsPresent = AllRows1.Count;
                    Assert.IsTrue(AllRows1.Count > 0, "PWL table was empty in Request History Page");
                    int k = 1;
                    foreach (IWebElement r1 in AllRows1)
                    {
                        if (k > 1)
                        {
                            ReadOnlyCollection<IWebElement> ListTd = FindElementsInsideAnotherUsingDriverUpdated(r1, "tagname", "a");

                            if (ListTd[0].Text.ToString().Equals(pwlreqId))
                            {
                                elementFound = true;
                                ListTd[0].Click();
                                break;
                            }
                        }
                        k++;
                    }//  foreach (IWebElement r1 in AllRows)           
                }
                else
                {
                    ReadOnlyCollection<IWebElement> AllRows1 = dbObj.PWLTable.FindElements(By.TagName("tr"));
                    elementFound = false;
                    numberOfRowsPresent = AllRows1.Count;

                    Assert.IsTrue(isElementVisible(dbObj.locatorforPWLTable, Constants.shortLoadTime), "PWL table was not shown in Request History Page");
                    if (AllRows1.Count > 1)
                    {
                        foreach (IWebElement r1 in AllRows1)
                        {
                            ReadOnlyCollection<IWebElement> ListTd = FindElementsInsideAnotherUsingDriverUpdated(r1, "tagname", "td");
                            if (ListTd != null)
                            {
                                if (((ListTd[6].Text.ToString().ToLower()).Equals(pendingstatus)) && (ListTd[1].Text.ToString().Equals(pwlreqId)))
                                {

                                    IWebElement ele = FindElementInsideAnotherUsingDriver(ListTd[1], "tagname", "a");
                                    if (ele != null)
                                    {
                                        elementFound = true;
                                        ele.Click();
                                        break;
                                    }
                                }
                            }


                        }
                    }
                }
                bool executeFlag = false;
                PWLRequestDetailPage detailobj = new PWLRequestDetailPage();
                PageFactory.InitElements(baseDriver, detailobj);

                if (IsElementPresentUsingBy(detailobj.locatorforlinkResortname,baseDriver, Constants.shortLoadTime))
                {
                    detailobj.resortName = detailobj.linkResortname.Text.ToString();
                    detailobj.resortName = detailobj.resortName.ToLower();

                }

                if (IsElementPresentUsingBy(detailobj.locatorforlblCheckIn,baseDriver, Constants.shortLoadTime))
                {
                    detailobj.checkindate = detailobj.lblCheckIn.Text.Trim().ToLower();

                }


                if (IsElementPresentUsingBy(detailobj.locatorforlblCheckOut,baseDriver, Constants.shortLoadTime))
                {
                    detailobj.checkoutdate = detailobj.lblCheckOut.Text.Trim().ToLower();

                }
                //select the cancel button
                if (IsElementPresentUsingBy(detailobj.locatorforbtnCancelrequest,baseDriver, Constants.shortLoadTime))
                    executeJavaScriptCommand(detailobj.javascriptCommandForCancelButtonTop);
                else if (IsElementPresentUsingBy(detailobj.locatorforbtnCancelrequestBottom,baseDriver, Constants.shortLoadTime))
                    executeJavaScriptCommand(detailobj.javascriptCommandForCancelButtonBottom);


                Assert.IsTrue(IsElementPresentUsingBy(detailobj.locatorforpopupCancel, baseDriver, Constants.shortLoadTime), "On Clicking Cancel button,Cancel Popup   was not  displayed");
                extentTest.Pass("On Clicking Cancel button, Cancel Popup  was displayed", AttachScrenshot(baseDriver, testContextInstance, "CancelPopUpDisplayed").Build());

                PWLConfirmationPage confirmObj = new PWLConfirmationPage();
                PageFactory.InitElements(baseDriver, confirmObj);

                Assert.IsTrue(IsElementPresentUsingBy(detailobj.locatorforYesButton, baseDriver, Constants.shortLoadTime), "Yes button was not shown in Cancel Popup");
                extentTest.Info( "Yes button was shown in Cancel Popup");

                detailobj.YesButton.Click();
                PWLCancelConfirmationPage confirmationObj = new PWLCancelConfirmationPage();
                PageFactory.InitElements(baseDriver, confirmationObj);

                Assert.IsTrue(IsElementPresentUsingBy(confirmationObj.locatorforrequestId, baseDriver, Constants.shortLoadTime), "The request id  " + pwlreqId + " was not shown in cancellation confirmation page");
               extentTest.Info( "The request id  " + pwlreqId + " was shown in cancellation confirmation page");

                Assert.IsTrue(IsElementPresentUsingBy(confirmationObj.locatorforBacktoWaitListButton, baseDriver, Constants.shortLoadTime), "The Back To Wait list button was not present in Cancellation Confirmation Page");
               extentTest.Info( "The Back To Wait list button was present in Cancellation Confirmation Page");

                confirmationObj.BacktoWaitListButton.Click();

                Assert.IsTrue(IsElementPresentUsingBy(historyObj.locatorforPendingRequestTable,baseDriver, Constants.medLoadTime), "PWL table was not shown in Request History Page");
                bool removedFlag = true;
                if (!(pagename.ToLower().Equals("dashboard")))
                {
                    ReadOnlyCollection<IWebElement> AllRows = FindElementsInsideAnotherUsingDriverUpdated(historyObj.PendingRequestTable, "tagname", "tr");

                    if (AllRows.Count > 1)
                    {
                        int k = 0;
                        foreach (IWebElement r1 in AllRows)
                        {
                            if (k > 1)
                            {
                                IWebElement td = FindElementInsideAnotherUsingDriver(r1, "tagname", "td");
                                if (td != null)
                                {
                                    if (td.Text == pwlreqId)
                                    {
                                        removedFlag = false;
                                        break;
                                    }
                                    else
                                        removedFlag = true;
                                }
                            }
                            k++;
                        }//  foreach (IWebElement r1 in AllRows)
                    }
                }
                else
                {
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];


                    if (!IsSingleELementVisible(dbObj.locatorforPWLTable, baseDriver))
                    {

                        extentTest.Info("PWL table  is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbObj.LocatorforRefresh, baseDriver);
                        IsSingleELementVisible(dbObj.locatorforPWLTable, baseDriver);
                    }
                    else
                    {
                        

                        IsSingleELementVisible(dbObj.locatorforPWLTable, baseDriver);

                        extentTest.Info("PWL table is present");
                    }

                   
                    

                    //Assert.IsTrue(IsElementVisible(dbObj.locatorforPWLTable,baseDriver, Constants.shortLoadTime), "The PWL locator table was not displayed in My DashBoard Page");
                    //extentTest.Pass("The PWL locator table was displayed in My DashBoard Page", AttachScrenshot(baseDriver, testContextInstance, "PWLlocatorTableDisplayed").Build());

                    ReadOnlyCollection<IWebElement> AllRows = dbObj.PWLTable.FindElements(By.TagName("tr"));
                    removedFlag = true;
                    foreach (IWebElement r1 in AllRows)
                    {
                        ReadOnlyCollection<IWebElement> ListTd = FindElementsInsideAnotherUsingDriverUpdated(r1, "tagname", "td");
                        if (ListTd != null)
                        {
                            if (ListTd[1].Text.ToString().Equals(pwlreqId))
                            {
                                if (ListTd[6].Text.ToString().Equals(Constants.RequestCancelled))
                                {
                                    removedFlag = true;
                                    break;
                                }
                                else
                                {
                                    removedFlag = false;
                                }
                            }
                        }
                    }
                }
                if (removedFlag)
                    flag = true;
                else flag = false;
            }
            catch (Exception e)
            {
                throw e;
                // extentTest.Info(e.Message+"\r\n",AttachScrenshot(baseDriver,testContextInstance,"Error").Build());
                //flag = false;
            }
            return flag;
        }


        public static bool UpdatePwlFromDashBoardOrBookMenu(TestContext testContextInstance, string pagename)
        {
            bool flag = false;
            try
            {
                PWLConfirmationPage confirmObj = new PWLConfirmationPage(baseDriver);

                MyDashboardPage dbobj = new MyDashboardPage(baseDriver);

                PWLRequestHistoryPage historyobj = new PWLRequestHistoryPage(baseDriver);


                if (!(pagename.ToLower().Equals("dashboard")))
                {
                    WaitForElementToBeClickable(confirmObj.SeependingRequestLink,baseDriver).Click();
                    Assert.IsTrue((IsElementPresentUsingBy(historyobj.locatorforPendingRequestTable, baseDriver)), "On clicking See Pending and Serviced Request link ,Request History Page was not  displayed");
                    Assert.IsTrue(UpdatePWlLogic(testContextInstance, pagename), "Update PWL was not successful for request " + pwlreqId);
                    extentTest.Info( "Update PWL was successful for request " + pwlreqId);
                }
                else
                {
                    AllMenus topMenuobj = new AllMenus();
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];



                    if (!IsSingleELementVisible(dbobj.locatorforPWLTable, baseDriver))
                    {

                        extentTest.Info("PWL table is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbobj.LocatorforRefresh, baseDriver);

                        Assert.IsTrue(UpdatePWlLogic(testContextInstance, pagename), "Update PWL was not successful for request " + pwlreqId);
                        extentTest.Info("Update PWL was successful for request " + pwlreqId);
                    }

                    else
                    {
                        IsSingleELementVisible(dbobj.PWLTable, baseDriver);
                        extentTest.Info("PWL table is visible");

                        Assert.IsTrue(UpdatePWlLogic(testContextInstance, pagename), "Update PWL was not successful for request " + pwlreqId);
                        extentTest.Info("Update PWL was successful for request " + pwlreqId);

                    }

                  
                  
                   
                    // Assert.IsTrue(isElementVisible(dbobj.locatorforPWLTable, Constants.shortLoadTime), "PWL table was not shown in my DashBoard page");
                   
                }

                flag = true;
            }
            catch (Exception e)
            {
                throw e;
                //extentTest.Info(e.StackTrace);
                //flag = false;
            }
           
            return flag;
        }


        public static bool UpdatePWlLogic(TestContext testContextInstance, string pagename)
        {
            bool flag = false;
            try
            {
                MyDashboardPage dbObj = new MyDashboardPage(baseDriver);
              
                bool elementFound = false;
                int numberOfRowsPresent = 0;
                PWLRequestHistoryPage historyObj = new PWLRequestHistoryPage(baseDriver);
             
                string pendingstatus = Constants.PWLPendingStatus.ToLower();

                if (!(pagename.ToLower().Equals("dashboard")))
                {
                    ReadOnlyCollection<IWebElement> AllRows1 = FindElementsInsideAnotherUsingDriverUpdated(historyObj.PendingRequestTable, "tagname", "tr");
                    numberOfRowsPresent = AllRows1.Count;
                    Assert.IsTrue(AllRows1.Count > 0, "PWL table was empty in Request History Page");
                    int k = 1;
                    foreach (IWebElement r1 in AllRows1)
                    {
                        if (k > 1)
                        {
                            ReadOnlyCollection<IWebElement> ListTd = FindElementsInsideAnotherUsingDriverUpdated(r1, "tagname", "a");

                            if (ListTd[0].Text.ToString().Equals(pwlreqId))
                            {
                                elementFound = true;
                                ListTd[0].Click();
                                break;
                            }
                        }
                        k++;
                    }//  foreach (IWebElement r1 in AllRows)           
                }
                else
                {
                    ReadOnlyCollection<IWebElement> AllRows1 = dbObj.PWLTable.FindElements(By.TagName("tr"));
                    elementFound = false;
                    numberOfRowsPresent = AllRows1.Count;
                    Assert.IsTrue(isElementVisible(dbObj.locatorforPWLTable, Constants.shortLoadTime), "PWL table was not shown in Request History Page");
                    if (AllRows1.Count > 1)
                    {
                        foreach (IWebElement r1 in AllRows1)
                        {
                            ReadOnlyCollection<IWebElement> ListTd = FindElementsInsideAnotherUsingDriverUpdated(r1, "tagname", "td");
                            if (ListTd != null)
                            {
                                if (((ListTd[6].Text.ToString().ToLower()).Equals(pendingstatus)) && (ListTd[1].Text.ToString().Equals(pwlreqId)))
                                {

                                    IWebElement ele = FindElementInsideAnotherUsingDriver(ListTd[1], "tagname", "a");
                                    if (ele != null)
                                    {
                                        elementFound = true;
                                        ele.Click();
                                        break;
                                    }
                                }
                            }


                        }
                    }
                }
                bool executeFlag = false;
                PWLRequestDetailPage detailobj = new PWLRequestDetailPage(baseDriver);

                //if (isElementVisible(detailobj.locatorforlinkResortname, Constants.shortLoadTime))
                //{
                //    detailobj.resortName = detailobj.linkResortname.Text.ToString();
                //    detailobj.resortName = detailobj.resortName.ToLower();

                //}

                //if (isElementVisible(detailobj.locatorforlblCheckIn, Constants.shortLoadTime))
                //{
                //    detailobj.checkindate = detailobj.lblCheckIn.Text.Trim().ToLower();

                //}


                //if (isElementVisible(detailobj.locatorforlblCheckOut, Constants.shortLoadTime))
                //{
                //    detailobj.checkoutdate = detailobj.lblCheckOut.Text.Trim().ToLower();

                //}
                //select the cancel button
                if (IsElementPresentUsingBy(detailobj.locatorforbtnEditRequestBottom, baseDriver))
                    executeJavaScriptCommand(detailobj.javascriptCommandForEditButtonBottom);
                else if (IsElementPresentUsingBy(detailobj.locatorforbtnEditRequest, baseDriver))
                    executeJavaScriptCommand(detailobj.javascriptCommandForEditButtonTop);

                PWLSearchPage pwlSearchObj = new PWLSearchPage(baseDriver);
                // PageFactory.InitElements(baseDriver, pwlSearchObj);

               GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                Assert.IsTrue(IsElementPresentUsingBy(pwlSearchObj.locatorforlabResortname,baseDriver), "On Clicking Edit button,PWL Edit Request  page was not  displayed");
                pwlSearchObj.ValResortName = pwlSearchObj.labResortname.Text;
                extentTest.Pass("On Clicking Edit button,PWL Edit Request  page was displayed", AttachScrenshot(baseDriver, testContextInstance, "askBluegreenPage").Build());

                Assert.IsTrue((pwlSearchObj.ValResortName.Contains(pwlresortName)), "Resort Name in PWL Edit Request  page  was not " + pwlresortName);
                extentTest.Pass("Resort Name in PWL Edit Request  page  was " + pwlresortName, AttachScrenshot(baseDriver, testContextInstance, "ResortNameinPWLRequestEditpage").Build());

                string[] arr = new string[3];
                arr = pwlSearchObj.CheckInDate.GetAttribute("Value").Split(' ');
                //check in date
                string din = Convert.ToDateTime(pwlcheckindate).ToString("M/dd/yyyy");
                Assert.IsTrue((Convert.ToDateTime(arr[0]).ToString("M/dd/yyyy")).Equals(din), "check in date in PWL Edit Request  page  was not " + pwlcheckindate);
                extentTest.Pass("check in date in PWL Edit Request  page  was " + pwlcheckindate, AttachScrenshot(baseDriver, testContextInstance, "CheckInDateinPWLRequestEditpage").Build());

                //chevkout date
                arr = pwlSearchObj.CheckOutDate.GetAttribute("Value").Split(' ');
                string dout = Convert.ToDateTime(pwlcheckoutdate).ToString("M/dd/yyyy");
                Assert.IsTrue((Convert.ToDateTime(arr[0]).ToString("M/dd/yyyy")).Equals(dout), "CheckOut date in PWL Edit Request  page  was not " + pwlcheckoutdate);
                extentTest.Pass("check out date in PWL Edit Request  page  was " + pwlcheckindate, AttachScrenshot(baseDriver, testContextInstance, "CheckOutDateinPWLRequestEditpage").Build());

                Assert.IsTrue(SearchPWL(testContextInstance, "edit"), "The Search from PWL Edit Request Page was not succesful");
                extentTest.Pass("The Search from PWL Edit  Request Page was succesful " + pwlcheckindate, AttachScrenshot(baseDriver, testContextInstance, "PWLeditRequestSuccessful").Build());

                PWLSubmitRequestPage pwlsubmitobj = new PWLSubmitRequestPage(baseDriver);

                Assert.IsTrue(fillPWLSubmitNewRequestPage(testContextInstance, pwlsubmitobj, "edit"), "The edit was not succesful for request id" + pwlreqId);
                extentTest.Pass("The edit was succesful for request id" + pwlreqId, AttachScrenshot(baseDriver, testContextInstance, "EditSuccessful").Build());

                PWLConfirmationPage confirmObj = new PWLConfirmationPage(baseDriver);

                pwleditedreqId = confirmObj.requestIDUpdated.Text;

                Assert.IsTrue(confirmObj.UpdateConfimationMessage.Text.Trim().Contains(Constants.UpdatePWLConfirmationMessage.Trim()), "Confirmation Message for Edit PWL was not" + Constants.UpdatePWLConfirmationMessage.Trim());
               extentTest.Info( "The confirmation message for Edit PWL was " + Constants.UpdatePWLConfirmationMessage);

                Assert.IsTrue((!String.IsNullOrEmpty(pwleditedreqId)) && !(String.IsNullOrWhiteSpace(pwleditedreqId)), "The PWL confirmation number after PWL update was not valid");
                extentTest.Info( "The PWL confirmation number was " + pwleditedreqId);
                flag = true;

            }
            catch (Exception e)
            {
                throw e;
              
            }
            return flag;
        }


        public static bool validatePwlIsSuccesfullyUpdated(TestContext testContextInstance, string pagename, string action)
        {
            bool flag = false;
            try
            {
                PWLConfirmationPage confirmObj = new PWLConfirmationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, confirmObj);

                MyDashboardPage dbobj = new MyDashboardPage(baseDriver);
               // PageFactory.InitElements(baseDriver, dbobj);

                PWLRequestHistoryPage historyobj = new PWLRequestHistoryPage(baseDriver);
               // PageFactory.InitElements(baseDriver, historyobj);


                if (!(pagename.ToLower().Equals("dashboard")))
                {
                    WaitForElementToBeClickable(confirmObj.locatorforSeePendingRequestLink, baseDriver).Click();
                    Assert.IsTrue((IsElementPresentUsingBy(historyobj.locatorforPendingRequestTable, baseDriver)), "On clicking See Pending and Serviced Request link ,Request History Page was not  displayed");
                    IReadOnlyCollection<IWebElement> AllRows = historyobj.PendingRequestTable.FindElements(By.TagName("tr"));
                    DataTable dt = copyHtmlTableToDatTableForPWL(AllRows);

                    Assert.IsTrue(VerifyPWLRequestHistoryPendingRequestTableContents(testContextInstance, dt, pwleditedreqId, pwlresortName, pwleditguestsnum, pwleditcheckindate, pwleditcheckoutdate, pwleditroomtypeVal), "The Updated PWL details were not properly shown  in PWL Request History page");
                    extentTest.Info("The updated PWL details were properly shown  in PWL Request History page");
                }
                else
                {
                    AllMenus topMenuobj = new AllMenus();
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];


                    if (!IsSingleELementVisible(dbobj.locatorforPWLTable, baseDriver))
                    {

                        extentTest.Info("PWL table is not visible, wait for loading icon to disable");

                        IsElementInvisible(dbobj.LocatorforRefresh, baseDriver);
                        IsSingleELementVisible(dbobj.PWLTable, baseDriver);
                        IReadOnlyCollection<IWebElement> AllRows = FindElementsInsideAnotherUsingDriverUpdated(dbobj.PWLTable, "tagname", "tr");
                        DataTable dt = copyHtmlTableToDataTableForDashBoard(AllRows);
                        Assert.IsTrue(VerifyPWLInDashBoardPage(testContextInstance, dt, pwleditedreqId, pwleditcheckindate, pwleditcheckoutdate, pwleditroomtypeVal, pwlresortName), "The PWL details were not properly shown  in PWL section in My Dashboard page");
                        extentTest.Info("The updated PWL details were properly shown  in PWL section in My Dashboard page");
                    }
                    else
                    {
                       
                        IsSingleELementVisible(dbobj.PWLTable, baseDriver);
                        extentTest.Info("PWL table is visible");
                        IReadOnlyCollection<IWebElement> AllRows = FindElementsInsideAnotherUsingDriverUpdated(dbobj.PWLTable, "tagname", "tr");
                        DataTable dt = copyHtmlTableToDataTableForDashBoard(AllRows);
                        Assert.IsTrue(VerifyPWLInDashBoardPage(testContextInstance, dt, pwleditedreqId, pwleditcheckindate, pwleditcheckoutdate, pwleditroomtypeVal, pwlresortName), "The PWL details were not properly shown  in PWL section in My Dashboard page");
                        extentTest.Info("The updated PWL details were properly shown  in PWL section in My Dashboard page");



                       
                    }
                   
                }

                flag = true;
            }
            catch (Exception exception)
            {

                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    //Assert.Fail(exception.InnerException.ToString());
                }
                else
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
                    // Assert.Fail(exception.Message);
                }


            }
            return flag;
        }


        public static bool AddGuestDetails(TestContext testContextInstance, string reservationType, string userType, ReservationConfirmationPage rcobj)
        {
            bool flag = false;
            Actions act = new Actions(baseDriver);
            try
            {

                baseDriver.Url = TestBaseClass.UrlForCurrentReservation;
                Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorforeditReservationInformationLink, baseDriver, Constants.shortLoadTime), "Edit Reservation Link was not present in Confirmation Page");
                extentTest.Info("Edit reservation link is present");

                // ClickelementUsingMouseByActionsClass(rcobj.editReservationInformationLink);
                ClickButton(rcobj.editReservationInformationLink, baseDriver);
                if ((userType.Equals(Constants.SAMPLER)) || (reservationType.Equals(Constants.bonustype)))
                {
                    Assert.IsFalse(isElementVisible(rcobj.locatorforBtn_AddNewGuest, Constants.shortLoadTime), "Add Guest Button was present in Edit Reservation Section in Confirmation Page");
                    //printOutputAndCaptureImage(testContextInstance, baseDriver, "Add Guest Button was not present in Edit Reservation Section in Confirmation Page");
                    extentTest.Info("Add guest button is present");
                }
                else
                {
                    Assert.IsTrue(fillAddGuestDetailsInConfirmationPage(rcobj), "The details were not succesfully entered in add Guest Details Page");
                    extentTest.Pass("The details were succesfully entered in add Guest Details Page", AttachScrenshot(baseDriver, testContextInstance, "DetailsSuccessfullyAddedinGuestDetailsPage").Build());

                }

                flag = true;
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    //extentTest.Fail(exception.InnerException.ToString() );
                    throw exception.InnerException;
                }
                if (exception.Message != null)
                {
                    //extentTest.Fail(exception.Message);
                    throw exception;
                }

            }
            return flag;
        }
        public static bool fillAddGuestDetailsInConfirmationPage(ReservationConfirmationPage rcObj)
        {
            bool flag = true;
            try
            {
                Assert.IsTrue(IsElementPresentUsingBy(rcObj.locatorforBtn_AddNewGuest,baseDriver, Constants.shortLoadTime), "Add Guest Button was not present in Edit Reservation Section in Confirmation Page");
                rcObj.Btn_AddNewGuest.Click();

                rcObj.TextBox_GuestFirstName.SendKeys(Constants.Firstname);
                rcObj.TextBox_GuestLastName.SendKeys(Constants.LastName);
                rcObj.TextBox_GuestEmail.SendKeys(Constants.Email);
                rcObj.TextBox_GuestTelephoneNumber.SendKeys(Constants.Phone);
                rcObj.TextBox_GuestCity.SendKeys(Constants.City);
                rcObj.TextBox_GuestStateDefaultValue.Click();
                rcObj.TextBox_GuestStateHawaii.Click();
                rcObj.TextBox_GuestRelationDefaultValue.Click();
                rcObj.GuestRelation_Friend.Click();

                //code to generate random guest numbers and check guests numbers
                Random r = new Random();
                int rInt = r.Next(2, 5);
                rcObj.randomGeneratedGuestsNum = rInt;

                int currentnumOfGuests = Convert.ToInt16(rcObj.GuestCount.Text.Trim());
                int i = currentnumOfGuests;

                if (currentnumOfGuests < rInt)
                {
                    while (i < rInt)
                    {
                        rcObj.Btn_PlusNumberOfGuests.Click();
                        //Thread.Sleep(1000);
                        i++;

                    }
                }
                else if (currentnumOfGuests > rInt)
                {
                    while (i > rInt)
                    {
                        rcObj.Btn_MinusNumberOfGuests.Click();
                        //Thread.Sleep(1000);
                        i--;

                    }
                }

                rcObj.DDLB_UpdateReservationInformation.Click();


                flag = true;
            }
            catch (Exception exception)
            {



				if (exception.InnerException != null)
				{
					//extentTest.Fail(exception.InnerException.ToString() );
					throw exception.InnerException;
				}
				if (exception.Message != null)
				{
					//extentTest.Fail(exception.Message);
					throw exception;
				}
				

			}
			return flag;

        }


        public static bool FindConfirmationNumberFromCurrentReservations(TestContext testContextInstance, string cnum)
        {

            bool foundelement = false;
            bool flag = false;
            //
            try
            {

                MyReservationPage myreservObj = new MyReservationPage();
                PageFactory.InitElements(baseDriver, myreservObj);

                //baseDriver.Url = ConfigurationManager.AppSettings["UrlMyReservations"];
               
                //changes done by Fathima

                HomePage homePageObj = new HomePage();
                PageFactory.InitElements(baseDriver, homePageObj);

                List<IWebElement> listOfMenuObj = new List<IWebElement>() { homePageObj.logOffDiv, homePageObj.myReservation};
                MenuLevel1(listOfMenuObj, baseDriver);

                //var act = new Actions(baseDriver);
                //act.MoveToElement(homePageObj.logOffDiv).Perform();
                //act.MoveToElement(homePageObj.myReservation).Click().Build().Perform();
               
                Assert.IsTrue(IsElementPresentUsingBy(myreservObj.locatorforCurrentReservationTable,baseDriver, Constants.medLoadTime), "The Current Reservation Table was not displayed");

                numberOfRowsInCurrentReservationsTable = myreservObj.CRTable_ListConfirmationNumber.Count;
                Assert.IsTrue(myreservObj.CRTable_ListConfirmationNumber.Count > 0, "Current Reservations Table had no confrimation numbers listed");



                // Extends_TestBaseClass.ScrollTo("0", "400", baseDriver);
                //Thread.Sleep(5000);

                //IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)baseDriver);
                //jsExecutor.ExecuteScript("window.scrollTo(0,400)");
                //Thread.Sleep(5000);
                GetWebdriverWait(baseDriver,Constants.shortLoadTime).Until(JsFunc(baseDriver));

                int numberofReservations = myreservObj.CRTable_ListConfirmationNumber.Count;

                if (numberofReservations > 10)

                {

                    
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    if (IsElementPresentUsingBy(myreservObj.locatorforViewAllLink, baseDriver))
                    {
                        WaitForElementToBeClickable(myreservObj.ViewAllLink, baseDriver).Click();
                    }
                      
                    

                }

              
                foreach (IWebElement confirmationNumberEle in myreservObj.CRTable_ListConfirmationNumber)
                {
                    if (confirmationNumberEle.Text.Equals(cnum.ToString()))
                    {
                          GetWebdriverWait(baseDriver, Constants.shortLoadTime).Until(JsFunc(baseDriver));

                         JavascriptClickElement(confirmationNumberEle, baseDriver);

                        ReservationConfirmationPage rcObj = new ReservationConfirmationPage(baseDriver);
                       // PageFactory.InitElements(baseDriver, rcObj);
                        if (IsElementPresentUsingBy(rcObj.locatorForConfirmationNumber,baseDriver, Constants.medLoadTime))
                            foundelement = true;
                        break;
                    }
                }
                Assert.IsTrue(foundelement, "The confirmation page was not  displayed for " + cnum);
                extentTest.Pass("The confirmation page is  displayed for " + cnum + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Confirmation_Page").Build());
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation page was displayed for " + cnum);
                flag = true;
            }
            catch (Exception exception)
            {


                if (exception.InnerException != null)
                {
                   
					throw exception.InnerException; 
                }
                else
                {
                   
					throw exception;
                }


            }
            return flag;

        }

        public static bool editReservationDetails(TestContext testContextInstance, string reservationType, string userType, ReservationConfirmationPage rcobj)
        {
            List<By> locatorForField;
            bool flag = false;
			try
			{

				Assert.IsTrue(AddGuestDetails(testContextInstance, reservationType, userType, rcobj), "Edit Guest Details was not successful for  Points Reservation");

				if (((!userType.Equals(Constants.SAMPLER))) && (!reservationType.Equals(Constants.bonustype)))
				{
					Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorForMsg_Updatereservation, baseDriver, Constants.shortLoadTime), "The Update reservation Message after Adding Guest was not displayed");
					extentTest.Pass("The Update reservation Message after Adding Guest was displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Updatereservation_Message").Build());
					baseDriver.Navigate().Refresh();
					ClickelementUsingMouseByActionsClass(rcobj.editReservationInformationLink);

					locatorForField = new List<By>() { rcobj.locatorForTextBox_GuestFirstName, rcobj.locatorForTextBox_GuestLastName, rcobj.locatorForTextBox_GuestEmail, rcobj.locatorForTextBox_GuestTelephoneNumber, rcobj.locatorForTextBox_GuestCity, rcobj.locatorForTextBox_GuestStateDefaultValue, rcobj.locatorForTextBox_GuestRelationDefaultValue, rcobj.locatorforFeild_NumberOfGuests, rcobj.locatorForGuestCheckingInAfterUpdate, rcobj.locatorforGuestCount };
					string[] expectedValue = { Constants.Firstname, Constants.LastName, Constants.Email, Constants.Phone, Constants.City, Constants.Hawaii, Constants.Friend, rcobj.randomGeneratedGuestsNum.ToString(), Constants.LastName + Constants.Firstname, rcobj.randomGeneratedGuestsNum.ToString() };
					string[] fields = { "Guest First Name", "Guest Last Name", "Guest Email", "Guest Telephone Number", "Guest City", "Guest State", "Guest RelationShip", "Number of Guests textbox ", "Guest Check In label", "Number of Guests Label" };
					string[] actualValue = { rcobj.TextBox_GuestFirstName.GetAttribute("value").ToString(), rcobj.TextBox_GuestLastName.GetAttribute("value").ToString(), rcobj.TextBox_GuestEmail.GetAttribute("value").ToString(), rcobj.TextBox_GuestTelephoneNumber.GetAttribute("value").ToString(), rcobj.TextBox_GuestCity.GetAttribute("value").ToString(), rcobj.TextBox_GuestStateDefaultValue.GetAttribute("title").ToString(), rcobj.TextBox_GuestRelationDefaultValue.GetAttribute("title").ToString(), rcobj.Field_NumberOfGuests.GetAttribute("value"), rcobj.GuestCheckingInAfterUpdate.Text.Replace(",", "").Replace(" ", ""), rcobj.GuestCount.Text.Trim().ToString() };

					Assert.IsTrue(compareActualAndExpectedValues(testContextInstance, locatorForField, expectedValue, actualValue, fields, "ReservationConfirmationPage"), "The added  guest details were not succesfully shown in Edit Reservation section");
					extentTest.Info("The added  guest details were succesfully shown in Edit Reservation section");
					//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The added  guest details were succesfully shown in Edit Reservation section");
				}
				
				baseDriver.Navigate().Refresh();
				ClickelementUsingMouseByActionsClass(rcobj.editReservationInformationLink);
				Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorforSelect_GuestCheckingInDefaultValue,baseDriver, Constants.medLoadTime), "Select_GuestChecking  was not selectable");
				rcobj.Select_GuestCheckingInDefaultValue.Click();

				string val = "";

				if (IsElementPresent(rcobj.locatorforOption_Owner2, baseDriver))
				{
					val = rcobj.Option_Owner2.Text.ToString();
					rcobj.Option_Owner2.Click();

				}
				else if (IsElementPresent(rcobj.locatorforOption_Owner1, baseDriver))
				{

					val = rcobj.Option_Owner1.Text.ToString();
					rcobj.Option_Owner1.Click();
				}


				Random r = new Random();
				int rInt = r.Next(1, 2);
				rcobj.randomGeneratedGuestsNum = rInt;
				rcobj.Field_NumberOfGuests.Clear();
				rcobj.Field_NumberOfGuests.SendKeys(rInt.ToString());

				rcobj.DDLB_UpdateReservationInformation.Click();
				Assert.IsTrue(IsSingleELementVisible(rcobj.locatorForMsg_Updatereservation, baseDriver, Constants.shortLoadTime), "The Update reservation Message after Adding Guest was not displayed");
				extentTest.Pass("The Update reservation Message after Adding Guest was displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Updatereservation_Message").Build());
				// printOutputAndCaptureImage(testContextInstance, baseDriver, "The Update reservation Message after Adding Guest was displayed");

				//click the edit reservation link

				baseDriver.Navigate().Refresh();
				GetElement(rcobj.locatorforeditReservationInformationLink, baseDriver);
				//Extends_TestBaseClass.ExplicitWait(rcobj.locatorforeditReservationInformationLink);

				ClickelementUsingMouseByActionsClass(rcobj.editReservationInformationLink);

				//Changes done by Fathima
				locatorForField = new List<By>() { rcobj.locatorforFeild_NumberOfGuests, rcobj.locatorforSelect_GuestCheckingInDefaultValue, rcobj.locatorforGuestCheckingIn, rcobj.locatorforGuestCount };
				string guestname = "";

				Assert.IsTrue(IsElementPresent(rcobj.locatorforSelect_GuestCheckingInDefaultValue,baseDriver), "The Guest checking in name  was not shown");


				guestname = rcobj.Select_GuestCheckingInDefaultValue.Text.Trim();

				string[] expectedValue1 = { rcobj.randomGeneratedGuestsNum.ToString(), val, val, rcobj.randomGeneratedGuestsNum.ToString() };

				string[] actualValue1 = { rcobj.Field_NumberOfGuests.GetAttribute("aria-valuenow"), guestname, guestname, rcobj.GuestCount.Text.Trim().ToString() };

				string[] fields1 = { "Number of Guests textbox ", "Value in Guest Check In dropdown ", "Guest Check In label", "Number of Guests Label" };

				Assert.IsTrue(compareActualAndExpectedValues(testContextInstance, locatorForField, expectedValue1, actualValue1, fields1, "ReservationConfirmationPage"), "The updated  guest details were not succesfully shown in Edit Reservation section");
				extentTest.Pass("Guest detail updated successfully in My Reservation Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Guestdetails_Updated").Build());

				//TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The updated  guest details were succesfully shown in Edit Reservation section");
				flag = true;
			}

			catch (Exception exception)
			{
				if (exception.InnerException != null)
				{
					//extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
					throw exception.InnerException;
				}
				else
				{
					//extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Error").Build());
					throw exception;
				}
			}
			return flag;

        }


        public static bool validateLinksOnConfirmationPage(TestContext testContextInstance, string reservationType, ReservationConfirmationPage rcobj, bool protectionType)
        {
            bool flag = false;
            try
            {
                baseDriver.Url = TestBaseClass.UrlForCurrentReservation;
                //protect points link
                if ((!protectionType) && (reservationType.Equals(Constants.pointstype)))
                {
                    PointsProtectionPlanPage pObj = new PointsProtectionPlanPage(baseDriver);
                   

                    Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorForLink_protectPointsNow, baseDriver, Constants.shortLoadTime), "Protect points Link was not present in Confirmation Page");
                    extentTest.Pass("Protect points Link is present in Confirmation Page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "PPPlink_ConfirmationPage").Build());
                    // printOutputAndCaptureImage(testContextInstance, baseDriver, "Protect points Link was present in Confirmation Page");
                    JavascriptClickElement(rcobj.Link_protectPointsNow, baseDriver);
                    Assert.IsTrue(IsElementPresentUsingBy(pObj.locatorforTextBox_CreditCardNumber, baseDriver, Constants.shortLoadTime), "On Clicking points protection plan link,The PPP page was not displayed");
                    extentTest.Pass("PPP page is displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "PPPpage").Build());

                    //printOutputAndCaptureImage(testContextInstance, baseDriver, "On Clicking points protection plan link,The PPP page was displayed");
                }
                else
                {
                    Assert.IsFalse(IsElementPresentUsingBy(rcobj.locatorForLink_protectPointsNow,baseDriver, Constants.shortLoadTime), "Protect points Link was present in Confirmation Page");
                    extentTest.Pass("Protect points Link is not present in Confirmation Pag" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "NoPPPlink_ConfirmationPage").Build());

                    //printOutputAndCaptureImage(testContextInstance, baseDriver, "Protect points Link was not present in Confirmation Page");
                }

                //resort name
                baseDriver.Url = TestBaseClass.UrlForCurrentReservation;
                Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorForResortName,baseDriver, Constants.shortLoadTime), "Resort Name Link was not present in Confirmation Page");

                extentTest.Info("Resort Name Link is present in Confirmation Page");
                //printOutputAndCaptureImage(testContextInstance, baseDriver, "Resort Name Link was present in Confirmation Page");
                rcobj.CPResortName = rcobj.ResortName.Text.ToString().Trim().ToLower();
                rcobj.ResortName.Click();
                Assert.IsTrue((rcobj.resortNameOnresortpage.Text.ToString().ToLower()).Equals(rcobj.CPResortName), "On Clicking resort name link,The resort page was not displayed");
                extentTest.Pass("Resort details page is displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Resortdetailpage").Build());
               // printOutputAndCaptureImage(testContextInstance, baseDriver, "On Clicking resort name link,The resort page was  displayed");

                //vacation profile
                baseDriver.Url = TestBaseClass.UrlForCurrentReservation;
                Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorforvacationProfileLink,baseDriver, Constants.shortLoadTime), "Vacation Profile link was not present in Confirmation Page");
                extentTest.Info("Vacation Profile link was present in Confirmation Page");
                //printOutputAndCaptureImage(testContextInstance, baseDriver, "Vacation Profile link was present in Confirmation Page");
                rcobj.vacationProfileLink.Click();
                Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorformyVacationProfileHeadingOnVPPage,baseDriver, Constants.shortLoadTime), "On Clicking vacation profile link,My Vacation Profile Page was not shown");
                extentTest.Pass("Vacation profile page is displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Vacationprofilepage").Build());

               // printOutputAndCaptureImage(testContextInstance, baseDriver, "On Clicking vacation profile link,My Vacation Profile Page was shown");

                //see all reservations
                baseDriver.Url = TestBaseClass.UrlForCurrentReservation;
                MyReservationPage mrobj = new MyReservationPage(baseDriver);
                //PageFactory.InitElements(baseDriver, mrobj);
                Assert.IsTrue(IsElementPresentUsingBy(rcobj.locatorformyreservationButton,baseDriver, Constants.shortLoadTime), "My reservation button was not present in Confirmation Page");
                extentTest.Info("My resevation button is present in Confirmation Page");

                

               
                //printOutputAndCaptureImage(testContextInstance, baseDriver, "My resevation button was present in Confirmation Page");
                rcobj.myreservationButton.Click();

                GetWebdriverWait(baseDriver,Constants.shortLoadTime).Until(JsFunc(baseDriver));
                Assert.IsTrue(IsElementPresentUsingBy(mrobj.locatorforCurrentReservationTable,baseDriver, Constants.shortLoadTime), "On Clicking My resevation button,My Reservations Page was not shown");
                extentTest.Pass("My Reservations page is displayed" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "MyReservationspage").Build());

               // printOutputAndCaptureImage(testContextInstance, baseDriver, "On Clicking My resevation button,My Reservations Page was shown");
                flag = true;
            }
            catch (Exception exception)
            {


                if (exception.InnerException != null)
                {
                    
					throw exception.InnerException;
                }
              else
                {
                   
					throw exception;   
                }


            }

            return flag;
        }

        //
        public static void ClickelementUsingMouseByActionsClass(IWebElement ele)
        {

            Actions act = new Actions(baseDriver);
            act.MoveToElement(ele).Perform();
            ele.Click();

        }



        public static bool isTherePointsToBeSaved()
        {

            bool flag = false;
            string stepDesc = null;
            string expectedResult = null;
            string actualResult = null;
            string status = null;

            //Code to check Column 4 has points to be save in Current Points table in MyDashBoard Page                                     
            MyPointsPage myPointObj = new MyPointsPage();
            PageFactory.InitElements(baseDriver, myPointObj);

            AllMenus topMenuObj = new AllMenus();
            PageFactory.InitElements(baseDriver, topMenuObj);

            //baseDriver.Url = topMenuObj.UrlMyPointsPage;
            baseDriver.Url = ConfigurationManager.AppSettings["UrlMyPointsPage"];
            try
            {
                Assert.IsTrue(isElementVisible(myPointObj.locatorforAPTTable, Constants.shortLoadTime), "Available Points Table was not displayed");
                for (int i = 0; i < myPointObj.APTTable_ListAction.Count; i++)
                {
                    string n = myPointObj.APTTable_ListAction[i].Text;
                    if (myPointObj.APTTable_ListAction[i].Text.ToLower().Equals("not saved"))
                    {
                        ListPointsToBeSaved.Add(myPointObj.APTTable_ListPoints[i].Text);
                        ListPointTypeTobeSaved.Add(myPointObj.APTTable_ListPointType[i].Text);
                        ListExpDatetobeSaved.Add(myPointObj.APTTable_ListExpirationDate[i].Text);
                        ListActionsToBeSaved.Add(myPointObj.APTTable_ListAction[i].Text);
                        flag = true;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Trace(e.Message);
                flag = false;
            }
            return flag;
        }

        public static bool PointReservationWithSavePointsLogic(string userName, TestContext testContextInstance, bool ProtectionType)
        {
            GlobalObjects globalObjects = new GlobalObjects(baseDriver);

            bool flag = false;
            try
            {


                //COMMON CODE FOR ALL TEST METHODS

                TestBaseClass.initializeTestScripts("no", "no", "no", testContextInstance);
                //Assert.IsTrue((TestBaseClass.SetUp(testContextInstance, Constants.Browser)), "BGO was not launched successfully");  //Login to BGO   
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "BGO was launched successfully");


                LoginPage loginPageObj = new LoginPage();
                PageFactory.InitElements(baseDriver, loginPageObj);
                //Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj, userName, Constants.password), "Login was not succesful");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Login was succesful");


                //Navigate to Point Type Reservation Page
                AllMenus topMenuobj = new AllMenus();
                PageFactory.InitElements(baseDriver, topMenuobj);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.Points };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Points" };

                //flag to comapre the available points with points needed for booking
                bool compareFlag = false;
                Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, baseDriver, ConfigurationManager.AppSettings["URlHomePage"]), "Points menu was not selected");


                HomePage homePageObj = new HomePage(baseDriver);
                //PageFactory.InitElements(baseDriver, homePageObj);

                // Initialize Home Page objects

                List<string> fieldName;
                List<IWebElement> Objects;
                int TotalPoints = 0;
                int PointsForBookinginSearchPage = 0;

                //Verify Points radio button should be defaultly selected
                Assert.IsTrue(IsElementPresentUsingBy(homePageObj.locatorForPointsButton,baseDriver));
                Assert.IsTrue(homePageObj.PointsRadioButton.Selected, "Points Radio Buttion was not selected");
                extentTest.Info("Points Radio Buttion is not selected");
                //Note down Available points 

                Assert.IsTrue((IsElementPresent(homePageObj.locatorForCurrentPoints,baseDriver)), "Current Points was not displayed");

                homePageObj.CurrentPointsVal = homePageObj.CurrentPoints.Text.Trim();
                Assert.IsTrue(!(homePageObj.CurrentPointsVal.Equals("null")), "The available points shown was null");


                homePageObj.CurrentPointsVal = homePageObj.CurrentPointsVal.Replace("points", "").Replace(",", "").Trim();
                TotalPoints = Convert.ToInt32(homePageObj.CurrentPointsVal);


                //verify the elements Points radio button,checkindate,checkout date,All destinations option in destinations  and search button is shown
               // Thread.Sleep(2000);
                //select the  destination, check in date,checkout date
                Assert.IsTrue(EnterSearchCriteriaFromHomePage2(TestBaseClass.SelectDates, TestBaseClass.WheeelChairAccess, homePageObj, TestBaseClass.CheckInDate, TestBaseClass.CheckoutDate, TestBaseClass.Destination), "There is some error in entering search criteria in homepage");

                ////Verify input check in date is selected in home page

                Assert.IsTrue((TestBaseClass.isElementVisible(homePageObj.locatorForCheckInDate, Constants.shortLoadTime)), "Check In date was not present n Home Page");

                homePageObj.ValCheckindate = homePageObj.CheckInDate.Text.Trim();
                string cin = DateTime.Parse(homePageObj.ValCheckindate).ToString("M/d/yyyy");


                //Verify input check out date is selected in home page
                Assert.IsTrue(TestBaseClass.isElementVisible(homePageObj.locatorForCheckOutDate, Constants.shortLoadTime), "The check Out Date was not present in Home page");
                homePageObj.ValCheckoutdate = homePageObj.CheckOutDate.Text.Trim();
                string cout = DateTime.Parse(homePageObj.ValCheckoutdate).ToString("M/d/yyyy");
                homePageObj.SearchButton.Click();
                string url = baseDriver.Url;
                //@@@@@@@@@@@@@@@@@@@@@@@@@@@
                Assert.IsTrue(isTherePointsToBeSaved(), "There are no points to be saved in My Points Page for this user");

                baseDriver.Url = url;
                Assert.IsTrue(SavePointsFunctionality(testContextInstance), "Save points  from Search Results page was not successful");

                //Initialize search page                                    
                SearchResultsPage SearchResultsObj = new SearchResultsPage();
                PageFactory.InitElements(baseDriver, SearchResultsObj);

                //Search Results page displayed with resort locations listed 

                IReadOnlyCollection<IWebElement> ListAvailableDestinationsInSearchResults;
                ListAvailableDestinationsInSearchResults = TestBaseClass.FindElementsUsingDriver("xpath", SearchResultsObj.XpathForAllAvailableResortsInSearchResults);
                int IFlag = TestBaseClass.SearchFromHomePage(ListAvailableDestinationsInSearchResults, SearchResultsObj, TestBaseClass.Destination);

                //Serach Results displayed for all destinations.in this case show resort availablity button will work or //serach results for single result destinations like  Florida/in this case show resort availablity button will work
                Assert.IsTrue(((IFlag == 3) || (IFlag == 4)), "The Search Result was not displayed properly");

                SearchResultsObj.btnShowResortAvailability = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForShowResortAvailalbilityButton);
                //check that the btnShowResortAvailability is not null elemet

                
                ClickButton(SearchResultsObj.btnShowResortAvailability, baseDriver);

                IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver);

                Assert.IsTrue(TestBaseClass.isElementVisible(SearchResultsObj.locatorForResultsTab, Constants.shortLoadTime), "The Search Results table was not displayed.");
                IReadOnlyCollection<IWebElement> rows = SearchResultsObj.ResultsTab.FindElements(By.TagName("tr"));
                //Thread.Sleep(4000);
                Assert.IsTrue(rows.Count > 0, "Search Results was empty");//Search results are displayed

                //Check avaialble points is displayed in the serach results for first room of last resort
                Assert.IsTrue((TestBaseClass.isElementVisible(SearchResultsObj.locatorForMultiResultPointsLink, Constants.medLoadTime)), "The Points link was not displayed in Search Results");
                SearchResultsObj.multiResultPointsLink = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultPointsLink);
                Assert.IsTrue(TestBaseClass.isElementVisible(SearchResultsObj.locatorForMultiResultPointsLink, Constants.shortLoadTime), "The Points link was not displayed");
                SearchResultsObj.multiResultPointsLink.Click();
                IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver);
                //Thread.Sleep(3000);
                SearchResultsObj.SRPPoints = SearchResultsObj.multiResultPointsLink.Text.Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", "").Trim();
                SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();
                PointsForBookinginSearchPage = Convert.ToInt32(SearchResultsObj.SRPPoints);


                ////Verify the available points is greater than points needed for booking
                ////compare avaialble points is greater than or equal to points needed for reservation shown in search results page

                if (!((String.IsNullOrEmpty(homePageObj.CurrentPointsVal))) || ((String.IsNullOrEmpty(SearchResultsObj.SRPPoints))))
                {
                    //doing this to check book buuton is enabled for booking or  not
                    Assert.IsTrue(TotalPoints >= PointsForBookinginSearchPage, "The available points " + TotalPoints + "is not greater than that required for booking" + PointsForBookinginSearchPage);
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The available points is greater than that required for booking");

                    compareFlag = true;
                }
                else
                    compareFlag = false;

                //Check if book button is displayed and proceed with booking

                IsElementInvisible(globalObjects.locatorforLoadingIcon, baseDriver);

                SearchResultsObj.multiResultBookButton = TestBaseClass.FindAnElementUsingDriver("xpath", SearchResultsObj.XpathForMultiResultBookButton);

                JavascriptClickElement(SearchResultsObj.multiResultBookButton, baseDriver);

                //TestBaseClass.ScrollUsingJavaScript("0", "200", SearchResultsObj.multiResultBookButton);
                ConfirmReservationPointType confirmReservationPageObj = new ConfirmReservationPointType();
                PageFactory.InitElements(baseDriver, confirmReservationPageObj);
                if (TestBaseClass.isElementVisible(confirmReservationPageObj.locatorForBtn_SubmitReservation, Constants.medLoadTime) && (compareFlag))
                {
                    //Verify the check in date on confirm reservation page is matching with alterante date selected  from search results page


                    confirmReservationPageObj.checkindate = confirmReservationPageObj.TableCoumn_CheckIn.Text.Trim();
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Select the resort and Click On Book.The Confirm Reservation Page was displayed");


                    confirmReservationPageObj.checkoutdate = confirmReservationPageObj.TableColumn_CheckOut.Text.Trim();

                    confirmReservationPageObj.resortName = confirmReservationPageObj.Lab_ResortName.Text.Trim();

                    ////Compare Points with Points shown in Search results page
                    confirmReservationPageObj.points = confirmReservationPageObj.TableColumn_Amount.Text.Trim();
                    confirmReservationPageObj.points = confirmReservationPageObj.points.Replace(",", "").Trim();
                    confirmReservationPageObj.points = confirmReservationPageObj.points.Replace("Points", " ").Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace("Points", " ").Trim();
                    SearchResultsObj.SRPPoints = SearchResultsObj.SRPPoints.Replace(",", "").Trim();

                    //Add Guest Details on confirm reservation page

                    //  TestBaseClass.ScrollUsingJavaScript("0", "document.body.scrollHeight");
                    fieldName = new List<string> { "Guest Checking in", "Special Requests", "Check Box Near text  I have read, understand and agree to the reservation details above including important notes and the Points reservation Terms and Conditions.", "Confirm My reservation Button", "No of Guests", "Plus button to add guests" };
                    Objects = new List<IWebElement> { confirmReservationPageObj.Select_GuestCheckingInDefaultBtn, confirmReservationPageObj.Feild_specialRequests, confirmReservationPageObj.Chk_Agreement, confirmReservationPageObj.Btn_SubmitResrvation, confirmReservationPageObj.Field_NumberOfGuests, confirmReservationPageObj.Btn_PlusNumberOfGuests };

                    confirmReservationPageObj.Select_GuestCheckingInDefaultBtn.Click();
                    fieldName.Clear();
                    fieldName = new List<string>() { "Owner option1" };
                    Objects = new List<IWebElement> { confirmReservationPageObj.Option_Owner1 };


                    confirmReservationPageObj.guestCheckingName = confirmReservationPageObj.Option_Owner1.Text.Trim();
                    confirmReservationPageObj.Option_Owner1.Click();
                    confirmReservationPageObj.Feild_specialRequests.SendKeys(Constants.valSpecialRequest);
                    confirmReservationPageObj.Chk_Agreement.Click();
                    confirmReservationPageObj.specialrequests = confirmReservationPageObj.Feild_specialRequests.Text.Trim();

                    int numGuests = Convert.ToInt16(2);
                    int i = 0;
                    while (i < numGuests)
                    {
                        confirmReservationPageObj.Btn_PlusNumberOfGuests.Click();
                        //Thread.Sleep(1000);
                        i++;

                    }


                    IJavaScriptExecutor executor = (IJavaScriptExecutor)baseDriver;
                    var javaScriptNumGuests = executor.ExecuteScript("return window.document.getElementById('Guest_NumberOfGuest').getAttribute('aria-valuenow')");
                    confirmReservationPageObj.numberOfGuests = javaScriptNumGuests.ToString();
                    confirmReservationPageObj.Btn_SubmitResrvation.Submit();
                    fieldName.Clear();
                    fieldName = new List<string>() { "Owner option1", "No Of Requests", "Special Requests" };
                    PointsProtectionPlanPage pppObj = new PointsProtectionPlanPage();
                    PageFactory.InitElements(baseDriver, pppObj);

                    if (!ProtectionType)//WITH OUT PPP
                    {
                        //byepass ppp page
                        TestBaseClass.WithPPP = false;
                        TestBaseClass.isElementVisible(pppObj.locatorforLink_PPPNoThankYou, Constants.medLoadTime);
                        Assert.IsTrue(TestBaseClass.isElementVisible(pppObj.locatorforLink_PPPNoThankYou, Constants.medLoadTime), "The No thank You Link was not present in the Protect points Page");
                        Assert.IsTrue(TestBaseClass.isElementClickable(pppObj.Link_PPPNoThankYou, Constants.medLoadTime), "The No thank You Link was not clickable in the Protect points Page");
                        pppObj.Link_PPPNoThankYou.Click();

                        Assert.IsTrue(TestBaseClass.isElementVisible(pppObj.locatorForBtn_IamNotInterested, Constants.medLoadTime), "The Iam Not interested Button was not  displayed in protect Points Page");
                        Assert.IsTrue(TestBaseClass.isElementClickable(pppObj.Btn_IamNotInterested, Constants.medLoadTime), "The Iam Not interested Button was not clickable in the Protect points Page");
                        pppObj.Btn_IamNotInterested.Click();
                    }
                    else
                    {
                        //verifyu PPP page
                        TestBaseClass.WithPPP = true;
                        Assert.IsTrue(TestBaseClass.isElementVisible(pppObj.locatorfortextBox_CreditCardName, Constants.medLoadTime));
                        fieldName = new List<string> { "Name", "CardNumber", "CVV", "ExpirationMonth", "ExpirationYear", "BillingZip/PostalCode", "AgreementCheckBox", "ProtectMyPointsButton", "International ZipCode CheckBox" };
                        Objects = new List<IWebElement> { pppObj.textBox_CreditCardName, pppObj.TextBox_CreditCardNumber, pppObj.TextBox_CVV, pppObj.Select_ExpirationMonth, pppObj.Select_ExpiratonYear, pppObj.TextBox_ZipCode, pppObj.ChkBox_PPPAgreement, pppObj.Btn_ProtectMyPoints, pppObj.ChkBox_InternationalZipCode };
                        Assert.IsTrue(TestBaseClass.fillCreditCardDetailsPPPPage(pppObj, testContextInstance), "The PPP from filling  was not successful");
                        Assert.IsTrue(TestBaseClass.SubmitPPPForm(pppObj), " The PPP submission was not successful");
                    }

                    ReservationConfirmationPage rcObj = new ReservationConfirmationPage();
                    PageFactory.InitElements(baseDriver, rcObj);

                    //Check that Confirmation Page is displayed on clciking Protect My Points Button.
                    Assert.IsTrue(TestBaseClass.isElementVisible(rcObj.locatorForConfirmationNumber, Constants.medLoadTime), "The confirmation  number was not displayed");
                    Assert.IsTrue(!(String.IsNullOrEmpty(rcObj.ConfirmationNumber.Text)) && !(String.IsNullOrWhiteSpace(rcObj.ConfirmationNumber.Text)), "The confirmation  number was not correct");
                    TestBaseClass.currentconfirmationNumber = rcObj.ConfirmationNumber.Text;
                    TestBaseClass.UrlForCurrentReservation = baseDriver.Url;
                    //Check Confimration Date
                    //  Assert.IsTrue(TestBaseClass.isElementVisible(rcObj.locatorForConfirmationDate, Constants.medLoadTime));

                    Assert.IsTrue(rcObj.ConfirmationDate.Text.Equals(DateTime.Now.ToString("MM/dd/yyyy").ToString()));
                    TestBaseClass.confirmationdate = DateTime.Now.ToString("MM/dd/yyyy").ToString();

                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The confirmation date on Confirmation page is same as that in the confirm reservation page");

                    //Validate resort  name

                    rcObj.CPResortName = rcObj.ResortName.Text.Trim();
                    Assert.IsTrue(rcObj.CPResortName.Equals(confirmReservationPageObj.resortName));
                    TestBaseClass.currentResortName = rcObj.CPResortName;
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The  resortname  on Confirmation page is same as that in the confirm reservation page");

                    //Validate the Points are same in Confirmation Page as well

                    rcObj.pointsUsed = rcObj.ValPointsUsed.Text.Replace(",", "").Trim();
                    Assert.IsTrue(rcObj.pointsUsed.Equals(confirmReservationPageObj.points), " The points used on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentAmount = rcObj.pointsUsed;
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, " The points used on Confirmation page is same as that in the confirm reservation page");

                    ////Validate Points Protected label

                    if ((ProtectionType))//WITH OUT PPP
                    {
                        Assert.IsTrue(rcObj.Lab_ProtectedOrNot.Text.Equals("| points protected"));
                        TestBaseClass.currentPPPStatus = rcObj.Lab_ProtectedOrNot.Text;
                    }


                    //check in date
                    rcObj.checkindate = rcObj.CheckInDate.Text.Trim();
                    Assert.IsTrue(rcObj.checkindate.Equals(confirmReservationPageObj.checkindate), "The check in date on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentcheckInDate = rcObj.checkindate;
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check in date  on Confirmation page is same as that in the confirm reservation page");

                    //Check the check out  date is displayed in confirmation Page

                    rcObj.checkoutdate = rcObj.CheckOutDate.Text.Trim();
                    Assert.IsTrue(rcObj.checkoutdate.Equals(confirmReservationPageObj.checkoutdate), "The check out date on Confirmation page is not same as that in the confirm reservation page");
                    TestBaseClass.currentcheckOutDate = rcObj.checkoutdate;
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "The   check out date  on Confirmation page is same as that in the confirm reservation page");

                    //  baseDriver.Url = topMenuobj.UrlMyPointsPage;
                    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyPointsPage"];
                    Assert.IsTrue(isAllEligiblePointsSaved(testContextInstance), "All Eligible points were not  saved for this user");
                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "All Eligible points were saved for this user");
                    flag = true;
                }
                else
                {

                    TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Unhandelled Alert has come due to which user is not able to reach to Confirm Reservation Page");
                    Assert.Fail("Unexpected Alert has come , not able to reach to Confirm Reservation page . Please logs ");

                    flag = false;
                }

                return flag;

            }

            catch (Exception e)
            {

                logger.Trace(e.StackTrace + "\r\n" + e.Message);
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, e.Message);
                return flag;
                throw e;
            }


        }

        //public static bool EnterSavePointFormDetails(TestContext testContextInstance)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        SaveMyPointsPage saveObj = new SaveMyPointsPage();
        //        PageFactory.InitElements(baseDriver, saveObj);
        //        saveObj.NameOnCard.SendKeys(Constants.FullName);
        //        saveObj.CreditCardNumber.SendKeys(Constants.CardNumber);
        //        saveObj.CVV.SendKeys(Constants.cvv);
        //        SelectElement dropdown1 = new SelectElement(saveObj.ExpirationMonth);
        //        dropdown1.SelectByText(Constants.expirationMonth);
        //        SelectElement dropdown2 = new SelectElement(saveObj.ExpirationYear);
        //        dropdown2.SelectByText(Constants.expirationYear);
        //        saveObj.ZipCode.SendKeys(Constants.zipcode);
        //        saveObj.InternationalZipCode.Click();
        //        saveObj.ChkBoxTermsAndConditions.Click();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Trace(e.StackTrace + "\r\n" + e.Message);
        //        TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, e.Message);
        //        flag = false;
        //    }
        //    return flag;

        //}


        public static bool SavePointsFunctionality(TestContext testContextInstance)
        {
            bool flag = false;
            List<string> fieldName;
            List<By> locatorForField;
            List<IWebElement> Objects;

            MyPointsPage myPointObj = new MyPointsPage();
            PageFactory.InitElements(baseDriver, myPointObj);

            AllMenus topMenuObj = new AllMenus();
            PageFactory.InitElements(baseDriver, topMenuObj);

            SaveMyPointsPage saveObj = new SaveMyPointsPage();
            PageFactory.InitElements(baseDriver, saveObj);

            try
            {
                Assert.IsTrue((isElementVisible(saveObj.locatorforSavePointsAlert, Constants.shortLoadTime))
                  && (isElementVisible(saveObj.locatorforSavePointsAlertButton, Constants.shortLoadTime)), "Save points alert was not shown with the save points button in the Search results page");
                extentTest.Pass("Save points alert is shown on search result page" + "\r\n", AttachScrenshot(baseDriver, testContextInstance, "Savepoints_button").Build());
                //  printOutputAndCaptureImage(testContextInstance, baseDriver, "Save points alert was shown with the save points button in the Search results page");
                saveObj.SaveMyPointsAlertButton.Click();
                Assert.IsTrue(EnterSavePointFormDetails(testContextInstance, saveObj), "Credit Card Details were not succesfully entered in Save Points form");

                Assert.IsTrue((isElementVisible(saveObj.locatorforSavePointsConfirmationNumber, Constants.longLoadTime)), "The Confirmation number was not shown after saving points");
                printOutputAndCaptureImage(testContextInstance, baseDriver, "The Confirmation number was shown after saving points");

                string confirmationnumber = saveObj.SavePointsConfirmationNumber.Text;
                Assert.IsTrue(!((String.IsNullOrEmpty(confirmationnumber)) && (String.IsNullOrWhiteSpace(confirmationnumber))), "The confirmation number was null or empty");
                printOutputAndCaptureImage(testContextInstance, baseDriver, "The Save points Confirmation Number was " + confirmationnumber);
                flag = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;

        }

        public static bool isAllEligiblePointsSaved(TestContext testContextInstance)
        {

            bool flag = false;
            string pointSaved = null;
            //Code to check Column 4 has points to be save in Current Points table in MyDashBoard Page                                     
            MyPointsPage myPointObj = new MyPointsPage();
            PageFactory.InitElements(baseDriver, myPointObj);
            try
            {
                Assert.IsTrue(isElementVisible(myPointObj.locatorforAPTTable, Constants.shortLoadTime), "Available Points Table was not shown in My Points Page");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, "Available Points Table was shown in My Points Page");

                if (myPointObj.APTTable_ListPoints.Count > 0)
                {
                    for (int k = 0; k < ListPointsToBeSaved.Count; k++)
                    {
                        for (int i = 0; i < myPointObj.APTTable_ListPoints.Count; i++)
                        {
                            if ((myPointObj.APTTable_ListPoints[i].Text.ToLower().Equals(ListPointsToBeSaved[k]))
                                && (myPointObj.APTTable_ListPointType[i].Text.ToLower().Equals(ListPointTypeTobeSaved[k]))
                                 && (myPointObj.APTTable_ListExpirationDate[i].Text.ToLower().Equals(ListExpDatetobeSaved[k]))
                                  && (myPointObj.APTTable_ListAction[i].Text.ToLower().Replace(" ", "").Equals("willbesaved")))
                            {
                                pointSaved = pointSaved + "," + myPointObj.APTTable_ListPoints[i].Text;
                                flag = true;
                                break;
                            }

                        }
                    }
                }
                return flag;
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace + "\r\n" + e.Message);
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, baseDriver, e.Message);
                flag = false;
            }
            return flag;
        }


        public static bool traverseMenu(List<By> ListOfMenuLocators, List<IWebElement> ListOfMenuobjects, List<String> ListOfMenuNames, IWebDriver baseDriver, string expectedpageUrl)
        {
            Actions act = new Actions(baseDriver);
            bool flag = false;


            if (TestBaseClass.isElementVisible(ListOfMenuLocators[0], Constants.shortLoadTime))
            {
                act.MoveToElement(ListOfMenuobjects[0]).Perform();
                if (TestBaseClass.isElementVisible(ListOfMenuLocators[1], Constants.shortLoadTime))
                {
                    act.MoveToElement(ListOfMenuobjects[1]).Perform();
                    if (TestBaseClass.isElementVisible(ListOfMenuLocators[2], Constants.shortLoadTime))
                    {
                        act.MoveToElement(ListOfMenuobjects[2]).Perform();
                        act.MoveToElement(ListOfMenuobjects[2]).Click(ListOfMenuobjects[2]).Perform();
                        // added code by Shivam Pathak
                        TestBaseClass.baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                        if (baseDriver.Url.Equals(expectedpageUrl))
                            flag = true;

                    }

                }
            }


            return flag;
        }

        public static bool login_BlueGreenOwner(LoginPage loginPage, string username)
        {
            bool val = false;
            try
            {
                if (login_fromVSSA(username))
                {
                    //Thread.Sleep(5000);// this needs to be removed 
                    HomePage homepageObj = new HomePage();
                    PageFactory.InitElements(TestBaseClass.baseDriver, homepageObj);

                    AllMenus allMenuObj = new AllMenus();
                    PageFactory.InitElements(TestBaseClass.baseDriver, allMenuObj);

                    //if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["URlHomePage"].ToLower()))

                    //    val = true;
                    //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToLower()))
                    //{
                    //  // homepageObj.ContinueButton.Click();
                    //    val = true;
                    //}
                    //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSuccessUrlForFlexFixUser"].ToLower()))
                    //    val = true;
                    //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSuccessUrlPaymentBalance"].ToLower()))
                    //    val = true;
                    //else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginMyPoints"].ToLower()))
                    //    val = true;

                    //else if (TestBaseClass.isElementVisible(homepageObj.locatorForskipChangePassword, Constants.shortLoadTime))
                    //{
                    //    homepageObj.skipChangePassword.Click();

                    //}

                  TestBaseClass.baseDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Utilities.Timeout.ShortwaitInSecond);


                    if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["loginSelectAccountUrl"].ToLower()))
                    {
                        homepageObj.ContinueButton.Click();
                        val = true;
                    }
                    else if (TestBaseClass.baseDriver.Url.ToLower().Equals(ConfigurationManager.AppSettings["URlHomePage"].ToLower()))
                    {
                        val = true;
                    }
                    else if (TestBaseClass.isElementVisible(allMenuObj.locatorforBook, Constants.veryshortLoadTime))
                        val = true;



                }

                return val;
            }
            catch (Exception E)
            {
				
				throw E;
            }
			
        }



        public static bool login_fromVSSA(string username)
        {
            
            VSSAHomePage vssaObj = new VSSAHomePage();
            PageFactory.InitElements(TestBaseClass.baseDriver, vssaObj);

            TestBaseClass.baseDriver.Url = ConfigurationManager.AppSettings["UrlForVSSAHomePage"];

            try
            {
                if (TestBaseClass.isElementVisible(vssaObj.locatorForArvactnumber, Constants.veryshortLoadTime))
                {

                    if (TestBaseClass.SearchVssaByArvact(vssaObj, username))
                    {
                        vssaObj.loginAsuSer.Click();
                        extentTest.Info("Login as a user button is clicked");
                        
                    }

                }
                return true;
            }
            catch (Exception E)
            {
                
				throw E;
            }
            

        }

        /// DATE HANDLING FUNCTIONS
        public static string pickMonthFromNum(string month)
        {

            switch (month)
            {
                case "1":
                    System.Console.WriteLine("January");
                    month = "January";
                    break;


                case "2":
                    System.Console.WriteLine("February");
                    month = "February";
                    break;

                case "3":
                    System.Console.WriteLine("March");
                    month = "March";
                    break;

                case "4":
                    System.Console.WriteLine("April");
                    month = "April";
                    break;


                case "5":
                    System.Console.WriteLine("May");
                    month = "May";
                    break;

                case "6":
                    System.Console.WriteLine("June");
                    month = "June";
                    break;

                case "7":
                    System.Console.WriteLine("July");
                    month = "July";
                    break;

                case "8":
                    System.Console.WriteLine("August");
                    month = "August";
                    break;

                case "9":
                    System.Console.WriteLine("September");
                    month = "September";
                    break;

                case "10":
                    System.Console.WriteLine("October");
                    month = "October";
                    break;

                case "11":
                    System.Console.WriteLine("November");
                    month = "November";
                    break;

                case "12":
                    System.Console.WriteLine("December");
                    month = "December";
                    break;
            };

            return month;


        }



        public static string pickNumFromMonth(string month)
        {

            switch (month)
            {
                case "January":

                    month = "1";
                    break;


                case "February":

                    month = "2";
                    break;

                case "March":
                    month = "3";
                    break;

                case "April":
                    month = "4";
                    break;


                case "May":
                    month = "5";
                    break;

                case "June":
                    month = "6";
                    break;

                case "July":
                    month = "7";
                    break;

                case "August":
                    month = "8";
                    break;

                case "September":
                    month = "9";
                    break;

                case "October":
                    month = "10";
                    break;

                case "November":
                    month = "11";
                    break;

                case "December":
                    month = "12";
                    break;
            };

            return month;
        }



        public static bool Pickdate(IWebElement dateBox, string date, IWebElement yearLabel, IWebElement monthLabel, IWebElement next, IWebElement prev)
        {
            //Thread.Sleep(4000);
            bool Val = false;
            string[] arr;
            arr = date.Split('/');
            string m = arr[0].TrimStart('0');
            string d = arr[1].TrimStart('0');
            string y = arr[2];
            TestBaseClass.day = d;
            try
            {
                Actions act = new Actions(baseDriver);
                act.MoveToElement(dateBox).Perform();
                dateBox.Click();

                int nextday = (Convert.ToInt32(d)) + 1;
                string anotherday = nextday.ToString();

                int diff = 0;
                if (Convert.ToInt32(y) != Convert.ToInt32(yearLabel.Text))
                {
                    diff = Convert.ToInt32(y) - Convert.ToInt32(yearLabel.Text);
                    while (yearLabel.Text != y)
                    {
                        if (diff > 0)
                        {
                            next.Click();
                        }
                        else if (diff < 0)
                        {
                            prev.Click();
                        }
                    }
                }

                string month = TestBaseClass.pickMonthFromNum(m);

                diff = Convert.ToInt32(pickNumFromMonth(monthLabel.Text)) - Convert.ToInt32(m);

                while (monthLabel.Text != month)
                {

                    if (diff < 0)
                    {
                        next.Click();
                    }
                    else if (diff > 0)
                    {
                        prev.Click();

                    }

                }

                string path = ".//div[@class='ui-datepicker-group ui-datepicker-group-first']//table[@class='ui-datepicker-calendar']//tr//td//a[contains(@class,'ui-state-default')and text()='" + d + "']";
                IWebElement day = FindAnElementUsingDriver("xpath", path);

                if (IsElementPresent(By.XPath(path),baseDriver))
                {
                    day.Click();
                    Val = true;
                }
                
            }
            catch (Exception e)
            {
                Val = false;
                throw e;

            }
            //Thread.Sleep(4000);
            return Val;
        }


        public static void ScrollUsingJavaScript(string x, string y,IWebElement ele)
        {
            bool flag = false;
            try
            {
                       
                flag = true;
            }
            catch (Exception E)
            {
                flag = false;
                throw E;
            }

        }

    }
}
