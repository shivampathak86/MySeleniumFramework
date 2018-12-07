using BlueGreenOwner;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodedUITestProject
{
   
    public class BaseClass_BGOLogin
    {

        
        
    
        [TestInitialize()]
        public void Init()
        {
          
            Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Browser launched");

            Debug.WriteLine("Browser launched");

            LoginHelper.Goto_BGO(ConfigurationManager.AppSettings["URlHomePage"]);

            Debug.WriteLine("Navigated to BGO URL");

            LoginHelper.Login_FromBGO(PageInitialize.LoginPage.UserName, PageInitialize.LoginPage.Password, PageInitialize.LoginPage.LoginButton, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString(), PageInitialize.LoginPage.continueBtn);

            Debug.WriteLine("User entered User name and password");

           
            
        }


        [TestCleanup()]
        public void MyTestCleanup()
        {
            OldFwkHelperClass.GenerateHTMLReport(this.testContextInstance);
            Driver.TearDown();
            Debug.WriteLine("Brower instance closed");
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
