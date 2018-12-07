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

    public class BaseClass_VssaLogin
    {


        [TestInitialize()]
        public void Init()
        {

            Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Browser launched");
            Debug.WriteLine("Browser launched");

            LoginHelper.Goto_VSSA();
            Debug.WriteLine("Navigated to VSSA URL");

            LoginHelper.VSSA_EnterArvact(Pages.VSSAHomePage.locatorForArvactnumber, testContextInstance.DataRow["Arvact"].ToString());
            Debug.WriteLine("User entered ARVACT");

            LoginHelper.VSSA_Click_SearchButton(Pages.VSSAHomePage.locatorForSearchButton);
            Debug.WriteLine("Search result is displayed");

            LoginHelper.VSSA_Click_ArvactResultLink(Pages.VSSAHomePage.locatorForarvactlink);
            Debug.WriteLine("Search results displayed");

            LoginHelper.VSSA_Click_loginAsUser_btn(Pages.VSSAHomePage.locatorForloginAsUser);
            Debug.WriteLine("Navigated to BGO  Homepage");

        }


        [TestCleanup()]
        public void MyTestCleanup()
        {
            TestBaseClass.GenerateHTMLReport(this.testContextInstance);
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
