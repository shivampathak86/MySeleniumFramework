using BlueGreenOwner;
using BlueGreenOwner.TestCases;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Utilities;

namespace CodedUITestProject
{  
    [TestClass]
    public class BaseClass:LoginMethod
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testcontext)

		{
			//BaseClass baseClassObj = new BaseClass();
			ReportsHelper.ReportSetup(testcontext);
            Constants.InitializeEnvironmentSpecificConstants();
            PopulateInCollection(Constants.TestDataFile);
 
        }

		public BaseClass()
		{

		}
	    

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            
            ReportsHelper.PublishReport();
            
        }



        [TestInitialize]
        public void InitTest()
        {

            //LoginMethod loginMethod = new LoginMethod();
            //loginMethod.InitializeBrowser(BrowserType.Chrome);

            StartTest(TestContext.TestName);

        }


        [TestCleanup]
        public void EndTest()
        {
            EndTest(TestContext.CurrentTestOutcome);

            //TearDown(driver);
            //extentTest.Info("Tear down is called");


        }




        public TestContext TestContext
            {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}



