using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Utilities
{
    public  class ReportsHelper:GenericHelper
    {

        private static ExtentHtmlReporter _htmlReports;
        public static ExtentTest extentTest { get; set; }
       
        private static  ExtentReports _extentReports;
       // public  TestContext testContext;

        public ReportsHelper Current { get; set; }
      

        public static void ReportSetup(TestContext TestContext)
        {
            string Directorypath = ConfigurationManager.AppSettings["ExtentReportsPath"].ToString()+@"\Reports";
            string Date = DateTime.Now.ToString("MM-dd-yy--HH-mm-ss");
            Directory.CreateDirectory(Directorypath);
           
            if(!File.Exists(Directorypath + @"\TestRun_" + Date + ".html"))
            {
              var reportfile=  File.Create(Directorypath + @"\TestRun_"+Date+".html");
                reportfile.Close();
                
            }
            _htmlReports = new ExtentHtmlReporter(Directorypath + @"\TestRun_" + Date + ".html");
            _htmlReports.LoadConfig(Directory.GetCurrentDirectory() + @"\extent-config.xml");

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_htmlReports);
            _extentReports.AddSystemInfo("Machine", TestContext.Properties["AgentName"].ToString());
            _extentReports.AddSystemInfo("Environment", ConfigurationManager.AppSettings["Environment"].ToString());

           

        }
        public static void StartTest(string TestName)
        {
            extentTest = _extentReports.CreateTest(TestName);
            
            
        }
        public static void EndTest(UnitTestOutcome outcome)
        {
            switch (outcome)
            {

				
                case UnitTestOutcome.Passed:
                    extentTest.Log(Status.Pass, "Test Passed");
                    break;
                case UnitTestOutcome.Failed:
                    extentTest.Log(Status.Fail, "Test Failed");
                    break;
                case UnitTestOutcome.Aborted:
                    extentTest.Log(Status.Skip, "Test Skipped");
					break;
			   case UnitTestOutcome.Timeout:
					extentTest.Log(Status.Fail, "Test Failed");

					break;
				case UnitTestOutcome.Unknown:
					extentTest.Log(Status.Fail, "Test Failed");

					break;

				default:
					extentTest.Log(Status.Fail, "Test Failed");

					break;


				



            }
        }

        public static void PublishReport()
        {

            _extentReports.Flush();

           
        }

    }
}
