using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace BlueGreenOwner.TestCases
{
	public class CancelAllReservations
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static void ClickUsingJavaScript(IWebElement element)
		{
			IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)Driver.driver);
			jsExecutor.ExecuteScript("arguments[0].click();", element);
		}

        //coding not yet completed 
		public static void ValidateCancelAllReservations(TestContext testContextInstance)
		{

			MyReservationPage_New myReservationPgObj = new MyReservationPage_New(Driver.driver);

			try
			{
				List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { myReservationPgObj.myBluegreen,myReservationPgObj.myReservtaion};

				MenusTabs.MeneuLevel1(ListOfMenuobjects, Driver.driver);


				var expected = ConfigurationManager.AppSettings["UrlMyReservations"];
				var actual = Driver.driver.Url;
				Assert.IsTrue(expected.Contains(actual), "My Reservation Page was not displayed");
				OldFwkHelperClass.printOutputAndCaptureImage(testContextInstance, OldFwkHelperClass.baseDriver, "My Reservation Page was displayed");


				int numOfReservations = myReservationPgObj.CRTable_ListConfirmationNumber.Count;

				for(int i=1; numOfReservations <= 10;i++)
				{
					//IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)Driver.driver);
					//jsExecutor.ExecuteScript("window.scrollTo(0,400)");
					//Thread.Sleep(5000);

					ClickUsingJavaScript(myReservationPgObj.CRTable_ListConfirmationNumber[i]);

					Assert.IsTrue(myReservationPgObj.ReservationConfirmationPg.Displayed, "Reservation Confirmation Page was not displayed");
					OldFwkHelperClass.printOutputAndCaptureImage(testContextInstance, OldFwkHelperClass.baseDriver, "Reservation Confirmation Page was displayed");




				}








			}


			catch (Exception e)
			{
				logger.Trace(e.StackTrace + "\r\n" + e.Message);
				OldFwkHelperClass.printOutputAndCaptureImage(testContextInstance, OldFwkHelperClass.baseDriver, e.Message);
				Assert.Fail(e.Message);
			}

			finally
			{

				LogoutHelper.LogOff(PageInitialize.HomePage.logOffDiv, PageInitialize.HomePage.SignoutBtn, Driver.driver);

			}

		}


	}

}

