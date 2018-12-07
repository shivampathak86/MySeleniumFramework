using BlueGreenOwner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodedUITestProject
{
	public  class LoginMethod
	{
		//public LoginMethod(TestContext testcontext)
		//{
		//	TestContext = testcontext;
		//}

		public  void Login(TestContext TestContext,string loginMethodName = "default")
		{
			try
			{
				switch (loginMethodName.ToLower())
				{
					case "vssa":

						Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Brower not launched");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Brower Was Launched");
						VSSAHomePage vssaPageObj = new VSSAHomePage(Driver.driver);
						LoginHelper.Goto_VSSA();
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "VSSA URL is launched");
						LoginHelper.VSSA_EnterArvact(vssaPageObj.locatorForArvactnumber, Driver.driver, TestContext.DataRow["Arvact"].ToString());
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Entered Arvact");
						LoginHelper.VSSA_Click_SearchButton(vssaPageObj.locatorForSearchButton, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Search button is clicked");
						LoginHelper.VSSA_Click_ArvactResultLink(vssaPageObj.locatorForarvactlink, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Click on Arvact link");

						LoginHelper.VSSA_Click_loginAsUser_btn(vssaPageObj.locatorForloginAsUser, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Click on Login As User button");
						HomePage homePageObj1 = new HomePage(Driver.driver);
						Assert.IsTrue(LoginHelper.BGO_IsUserLoggedIn(homePageObj1.logOffDiv, Driver.driver), "User not able to login to BGO");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "User reached to BGO home page");
						break;

					case "bgo":
						Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Brower not launched");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Brower Was Launched");

						LoginPage loginPageObj1 = new LoginPage(Driver.driver);

						LoginHelper.Goto_BGO();
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "BGO URL is launched");
						LoginHelper.Login_FromBGO(loginPageObj1.UserName, loginPageObj1.Password, loginPageObj1.LoginButton, Driver.driver, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString(), loginPageObj1.continueBtn);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "User enter UserName,Password and click on Sign Button");
						HomePage homePageObj2 = new HomePage(Driver.driver);
						Assert.IsTrue(LoginHelper.BGO_IsUserLoggedIn(homePageObj2.logOffDiv, Driver.driver), "User not able to login to BGO");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "User reached to BGO home page");

						break;

					case "selectanaccount":
						Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Brower not launched");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Brower Was Launched");

						LoginPage loginPageObj2 = new LoginPage(Driver.driver);

						LoginHelper.Goto_BGO();
						TextBoxHelper.TypeInTextBox(loginPageObj2.UserName, Driver.driver, TestContext.DataRow["UserName"].ToString());
						TextBoxHelper.TypeInTextBox(loginPageObj2.Password, Driver.driver, TestContext.DataRow["Password"].ToString());
						Buttonhelper.ClickButton(loginPageObj2.LoginButton, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "User enter UserName,Password and click on Sign Button");

						break;
					case "default":

						Assert.IsTrue(TestBaseClass.SetUp(TestContext, Constants.Browser), "Brower is not launched");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, //TestBaseClass.baseDriver, "Brower Was Launched");
						LoginPage loginPageObj3 = new LoginPage(TestBaseClass.baseDriver);
						Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj3, TestContext.DataRow["UserName"].ToString()), "User not able to  Login");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, TestBaseClass.baseDriver, "User reached to BGO home page");
						break;
					case "registration":
						Assert.IsTrue(Driver.Initialize(BrowserType.Chrome), "Brower not launched");
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Brower Was Launched");
						VSSAHomePage vssaPageObj2 = new VSSAHomePage(Driver.driver);
						LoginHelper.Goto_VSSA();
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "VSSA URL is launched");
						LoginHelper.VSSA_EnterArvact(vssaPageObj2.locatorForArvactnumber, Driver.driver, TestContext.DataRow["Arvact"].ToString());
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Entered Arvact");
						LoginHelper.VSSA_Click_SearchButton(vssaPageObj2.locatorForSearchButton, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Search button is clicked");
						LoginHelper.VSSA_Click_ArvactResultLink(vssaPageObj2.locatorForarvactlink, Driver.driver);
						//TestBaseClass.printOutputAndCaptureImage(TestContext, Driver.driver, "Click on Arvact link");

						break;
				}
			}
			catch (Exception exception)
			{
				
				if (exception.Message != null && Driver.driver != null)
				{
					Driver.TearDown(Driver.driver);
					ReportsHelper.EndTest(TestContext.CurrentTestOutcome);
					
					throw exception;
				}
				else if (exception.Message != null && TestBaseClass.baseDriver != null)
				{
					Driver.TearDown(TestBaseClass.baseDriver);
					ReportsHelper.EndTest(TestContext.CurrentTestOutcome);
					throw exception;
					
					
				}
			}

		}




	}
}
