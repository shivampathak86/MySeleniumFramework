//using Microsoft.VisualStudio.TestTools.UITesting;

using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static System.String;

namespace Utilities
{
    public  class Screenshot:ReportsHelper
    {
        #region static variables

        private static readonly string SerialNumber = DateTime.Now.ToString("yyyy-dd-MM");
		public static int screenShotNameLength = 250;

		#endregion

		#region Functions 

		public static string TakeImage(IWebDriver driver, TestContext TestContext, string stepName = "Screen")
		{
            string TestResultDirectory = ConfigurationManager.AppSettings["TestResultsFolder"] + @"\Screenshots" + SerialNumber;
				//include code for other types as well.
				ImageFormat format = ImageFormat.Png;
				OpenQA.Selenium.Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				string substr = "1";

				if (stepName.Length >= screenShotNameLength)
					substr = stepName.Substring(0,screenShotNameLength);
				else
					substr = stepName;
				//Create directory to save screenshots            
				if (!Directory.Exists(TestResultDirectory+@"\"+TestContext.TestName))
				{
					Directory.CreateDirectory(TestResultDirectory + @"\" + TestContext.TestName);
					Directory.SetCurrentDirectory(TestResultDirectory + @"\" + TestContext.TestName);
					ss.SaveAsFile(substr + "." + format);


				}
				else
				{
				Directory.SetCurrentDirectory(TestResultDirectory + @"\" + TestContext.TestName);
				ss.SaveAsFile(substr + "." + format);
				}

			return TestResultDirectory + @"\" + TestContext.TestName + @"\" + substr + "." + format;

			}
			
		public static MediaEntityBuilder AttachScrenshot(IWebDriver driver,TestContext TestContext, string ScreenshotName="Screen")
		{
			MediaEntityBuilder.CreateScreenCaptureFromPath(TakeImage(driver, TestContext, ScreenshotName));
			return new MediaEntityBuilder();
		}


        //public static void HighLighterMethod(IWebElement element)
        //{
        //    if (element == null) throw new ArgumentNullException(nameof(element));
        //    var js = (IJavaScriptExecutor) Driver.driver;
        //    js.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;');",
        //        element);
        //}

        #endregion
    }
}