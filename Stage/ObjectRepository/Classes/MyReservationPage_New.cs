using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
	public class MyReservationPage_New
	{

		[FindsBy(How = How.XPath, Using = "//li[@id='js-my-bluegreen']")]
		public IWebElement myBluegreen;
		public By locatorForMyBluegreen = By.XPath("//li[@id='js-my-bluegreen']");

		[FindsBy(How = How.XPath, Using = "//a[.='my reservations']")]
		public IWebElement myReservtaion;
		public By locatorForMReservtaion = By.XPath("//a[.='my reservations']");

		[FindsBy(How = How.XPath, Using = ".//*[@id='section-current-reservations-details']/table//td[@data-label='confirmation #']/a")]
		public  IList<IWebElement> CRTable_ListConfirmationNumber { get; set; }
		public  By locatorforCRTable_ListConfirmationNumber = By.XPath(".//*[@id='section-current-reservations-details']/table//td[@data-label='confirmation #']/a");

		[FindsBy(How = How.XPath, Using = "//strong[.='reservation']")]
		public IWebElement ReservationConfirmationPg;
		public By locatorForReservationConfirmationPg = By.XPath("//strong[.='reservation']");



		public MyReservationPage_New(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}


	}
}
