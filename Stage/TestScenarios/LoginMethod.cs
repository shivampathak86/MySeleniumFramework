using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Utilities;

namespace BlueGreenOwner.TestCases
{
	public  class LoginMethod: Utilities.Screenshot
	{

        public static IWebDriver driver;
        
        public void InitializeBrowser(BrowserType browserType)
        {
            Assert.IsTrue(Initialize(browserType), "Browser not launched");
            driver = WebDriver;
            //extentTest.Pass("Browser Initiated");
        }
       
		public  void Login(TestContext TestContext,int RowNumber, string ColumnName1, string ColumnName2,string loginMethodName = "default")
		{
			try
			{
				switch (loginMethodName.ToLower())
				{
					case "vssa":

                       
						
						VSSAHomePage vssaPageObj = new VSSAHomePage(driver);
						Goto_VSSA();

						extentTest.Info("VSSA Home Page is open");
						
						VSSA_EnterArvact(vssaPageObj.locatorForArvactnumber, driver ,ReadData(RowNumber,ColumnName1));
						extentTest.Info("Arvact entered");
						
						VSSA_Click_SearchButton(vssaPageObj.locatorForSearchButton, driver);
						extentTest.Info("Click on search button ");
						
						VSSA_Click_ArvactResultLink(vssaPageObj.locatorForarvactlink, driver);
						extentTest.Info("Click on arvact link");
						

						VSSA_Click_loginAsUser_btn(vssaPageObj.locatorForloginAsUser, driver);
						extentTest.Info("Click on Login as  user button");

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
						extentTest.Pass("BGO Home page is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						
						break;

					case "bgo":
                        
						

						LoginPage loginPageObj1 = new LoginPage(driver);

						Goto_BGO();
						extentTest.Info("BGO Login Page is open");

                        Login_FromBGO(loginPageObj1.UserName, loginPageObj1.Password, loginPageObj1.LoginButton, driver, ReadData(RowNumber, ColumnName1), ReadData(RowNumber, ColumnName1), loginPageObj1.continueBtn);
						extentTest.Info("Login information entered");
						
						HomePage homePageObj2 = new HomePage(driver);
						Assert.IsTrue(IsUserLoggedIn(homePageObj2.logOffDiv, driver), "User not able to login to BGO");
						extentTest.Pass("BGO Home page is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						

						break;

					case "selectanaccount":
                        
						

						LoginPage loginPageObj2 = new LoginPage(driver);

						Goto_BGO();
						extentTest.Info("BGO Login Page is open");
                        TypeInTextBox(loginPageObj2.UserName, driver, ReadData(RowNumber, ColumnName1));
						extentTest.Info("Username entered");
						TypeInTextBox(loginPageObj2.Password, driver, ReadData(RowNumber, ColumnName2));
						extentTest.Info("Password entered");
						ClickButton(loginPageObj2.LoginButton, driver);
						extentTest.Info("sign in clicked");

                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                        break;

                    case "signin":



                        LoginPage loginPageObj6 = new LoginPage(driver);

                        Goto_BGO();
                        extentTest.Info("BGO Login Page is open");
                        TypeInTextBox(loginPageObj6.UserName, driver, TestContext.DataRow[ColumnName1].ToString());
                        extentTest.Info("Username entered");
                        TypeInTextBox(loginPageObj6.Password, driver, TestContext.DataRow[ColumnName2].ToString());
                        extentTest.Info("Password entered");
                        ClickButton(loginPageObj6.LoginButton, driver);
                        extentTest.Info("sign in clicked");

                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((double)Timeout.ShortwaitInSecond);

                        break;


                    case "default":

                        TestBaseClass.baseDriver = driver;

                        LoginPage loginPageObj3 = new LoginPage(driver);
						Assert.IsTrue(TestBaseClass.login_BlueGreenOwner(loginPageObj3, ReadData(RowNumber, ColumnName1)), "User not able to  Login");
						extentTest.Pass("BGO Home page is visible", AttachScrenshot(driver, TestContext, "BGO_HomePage").Build());
						
						break;
					

                    case "registration":
                        
                        LoginPage loginPageObj5 = new LoginPage(driver);

                        Goto_BGO();
                        extentTest.Info("BGO Login Page is open");

                        JavascriptClickElement(loginPageObj5.registerTodayLink, driver);
                        extentTest.Info("Register Today Link is clicked");

                        Assert.IsTrue(IsSingleELementVisible(loginPageObj5.locatorForregisterWithyBlueGreenVacationsPage, driver), " Register with bluegreen vacations page is not  displayed");
                        extentTest.Pass(" Register with bluegreen vacations page is displayed", AttachScrenshot(driver, TestContext, "RegisterWithBluegreenVacationsPageDisplayed").Build());


                        break;

                    case "accountnumbervalidation":
                        

                        VSSAHomePage vssaPageObj2 = new VSSAHomePage(driver);
                        Goto_VSSA();
                        extentTest.Info("VSSA Home Page is open");

                        VSSA_EnterArvact(vssaPageObj2.locatorForArvactnumber, driver, ReadData(RowNumber, ColumnName1));
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
                   
                    extentTest.Error("Exception occured"+"r\n"+ exception.Message, AttachScrenshot(Utilities.Driver.WebDriver, TestContext, "Error").Build());
                    EndTest(TestContext.CurrentTestOutcome);
                   // TearDown(WebDriver);
                   // throw exception;
                    Assert.Fail(exception.Message);

                }
				else if (TestBaseClass.baseDriver != null)
				{
                    
                    extentTest.Error("Exception occured" + "r\n" + exception.Message, AttachScrenshot(TestBaseClass.baseDriver, TestContext, "Error").Build());
                    EndTest(TestContext.CurrentTestOutcome);
                    //TearDown(TestBaseClass.baseDriver);
                    //throw exception;
                    Assert.Fail(exception.Message);
					
					
				}

               
			}

		}




	}
}
