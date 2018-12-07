using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Utilities;

namespace BlueGreenOwner.TestCases
{
	public  class LoginMethod_Old: Utilities.Screenshot
	{
		
		public static  IWebDriver driver;
		public  void Login(TestContext TestContext,string loginMethodName = "default")
		{
			try
			{
				switch (loginMethodName.ToLower())
				{
					case "vssa":

                        Assert.IsTrue(Initialize(BrowserType.HeadlessChrome), "Brower not launched");
                        driver =WebDriver;
					   extentTest.Pass("Browser Initiated");
						
						VSSAHomePage vssaPageObj = new VSSAHomePage(driver);
						Goto_VSSA();
						extentTest.Info("VSSA Home Page is open");
						
						VSSA_EnterArvact(vssaPageObj.locatorForArvactnumber, driver ,TestContext.DataRow["Arvact"].ToString());
						extentTest.Info("Arvact entered");
						
						VSSA_Click_SearchButton(vssaPageObj.locatorForSearchButton, driver);
						extentTest.Info("Click on search button ");
						
						VSSA_Click_ArvactResultLink(vssaPageObj.locatorForarvactlink, driver);
						extentTest.Info("Click on arvact");
						

						VSSA_Click_loginAsUser_btn(vssaPageObj.locatorForloginAsUser, driver);
						extentTest.Info("Login as  user");

                    //   driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                        LoginPage loginPageObj4 = new LoginPage(driver);
                        var expected = ConfigurationManager.AppSettings["loginSelectAccountUrl"];
                        var actual =driver.Url;

                        if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (loginPageObj4.continueBtn == null) throw new ArgumentNullException(nameof(loginPageObj4.continueBtn));
                           ClickButton(loginPageObj4.continueBtn, driver);

                        }

                        HomePage homePageObj1 = new HomePage(driver);
						Assert.IsTrue(IsUserLoggedIn(homePageObj1.logOffDiv, driver), "User not able to login to BGO");
						extentTest.Pass("BGO Home is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						
						break;

					case "bgo":
                        Assert.IsTrue(Utilities.Driver.Initialize(BrowserType.Chrome), "Brower not launched");
                        driver = Utilities.Driver.WebDriver;
						extentTest.Pass("Browser Initiated");
						

						LoginPage loginPageObj1 = new LoginPage(driver);

						Goto_BGO();
						extentTest.Info("BGO Login Page is open");

                        Login_FromBGO(loginPageObj1.UserName, loginPageObj1.Password, loginPageObj1.LoginButton, driver, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString(), loginPageObj1.continueBtn);
						extentTest.Info("Login information entered");
						
						HomePage homePageObj2 = new HomePage(driver);
						Assert.IsTrue(IsUserLoggedIn(homePageObj2.logOffDiv, driver), "User not able to login to BGO");
						extentTest.Pass("BGO Home is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						

						break;

					case "selectanaccount":
                        Assert.IsTrue(Utilities.Driver.Initialize(BrowserType.Chrome), "Brower not launched");
						extentTest.Pass("Browser Initiated");
                        driver = Utilities.Driver.WebDriver;
						

						LoginPage loginPageObj2 = new LoginPage(driver);

						Goto_BGO();
						extentTest.Info("BGO Login Page is open");
					    TypeInTextBox(loginPageObj2.UserName, driver ,TestContext.DataRow["UserName"].ToString());
						extentTest.Info("Username entered");
						TypeInTextBox(loginPageObj2.Password, driver, TestContext.DataRow["Password"].ToString());
						extentTest.Info("Password entered");
						ClickButton(loginPageObj2.LoginButton, driver);
						extentTest.Info("sign in clicked");

                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                        break;


                    case "default":

						Assert.IsTrue(TestBaseClass.SetUp(TestContext, Constants.Browser), "Brower is not launched");
						extentTest.Pass("Browser Initiated");
						driver = TestBaseClass. baseDriver;
						
						LoginPage loginPageObj3 = new LoginPage(driver);
						Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj3, TestContext.DataRow["UserName"].ToString()), "User not able to  Login");
						extentTest.Pass("BGO Home is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						
						break;
					

                    case "registration":

                        Assert.IsTrue(Utilities.Driver.Initialize(BrowserType.Chrome), "Brower not launched");
                        extentTest.Pass("Browser Initiated");
                        driver = Utilities.Driver.WebDriver;


                        LoginPage loginPageObj5 = new LoginPage(driver);

                        Goto_BGO();
                        extentTest.Info("BGO Login Page is open");

                        JavascriptClickElement(loginPageObj5.registerTodayLink, driver);
                        extentTest.Info("Register Today Link is clicked");

                        Assert.IsTrue(IsSingleELementVisible(loginPageObj5.locatorForregisterWithyBlueGreenVacationsPage, driver), " Register with bluegreen vacations page is not  displayed");
                        extentTest.Pass(" Register with bluegreen vacations page is displayed", AttachScrenshot(driver, TestContext, "RegisterWithBluegreenVacationsPageDisplayed").Build());


                        break;

                    case "AccountNumberValidation":
                        Assert.IsTrue(Utilities.Driver.Initialize(BrowserType.Chrome), "Brower not launched");
                        driver = Utilities.Driver.WebDriver;
                        extentTest.Pass("Browser Initiated");

                        VSSAHomePage vssaPageObj2 = new VSSAHomePage(driver);
                        Goto_VSSA();
                        extentTest.Info("VSSA Home Page is open");

                        VSSA_EnterArvact(vssaPageObj2.locatorForArvactnumber, driver, TestContext.DataRow["Arvact"].ToString());
                        extentTest.Info("Arvact entered");

                        VSSA_Click_SearchButton(vssaPageObj2.locatorForSearchButton, driver);
                        extentTest.Info("Click on search button ");

                        VSSA_Click_ArvactResultLink(vssaPageObj2.locatorForarvactlink, driver);
                        extentTest.Info("Click on arvact");


                        break;

                }
			}
			catch (Exception exception)
			{
				
				if (Utilities.Driver.WebDriver != null)
				{
                    Utilities.Driver.TearDown(Utilities.Driver.WebDriver);
                    extentTest.Error("Exception occured :"+"r\n"+ exception.Message, AttachScrenshot(Utilities.Driver.WebDriver, TestContext, "Error").Build());
                    EndTest(TestContext.CurrentTestOutcome);
					
					throw exception;
				}
				else if (TestBaseClass.baseDriver != null)
				{
                    Utilities.Driver.TearDown(TestBaseClass.baseDriver);
                    extentTest.Error("Exception occured :" + "r\n" + exception.Message, AttachScrenshot(TestBaseClass.baseDriver, TestContext, "Error").Build());
                    EndTest(TestContext.CurrentTestOutcome);
					throw exception;
					
					
				}

               
			}

		}




	}
}
