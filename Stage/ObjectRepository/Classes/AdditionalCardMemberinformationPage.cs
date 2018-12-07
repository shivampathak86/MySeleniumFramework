using BlueGreenOwner;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueGreenOwner
{
    public class AdditionalCardMemberInformationPage
    {

		public AdditionalCardMemberInformationPage()
		{
		}
			public AdditionalCardMemberInformationPage(IWebDriver driver)
			{
			PageFactory.InitElements(driver, this);
			}
		
        public static By SuccessMessageLocator = By.Id("LblResponseReason')]");
        [FindsBy(How = How.Id, Using = "LblResponseReason")]
        public IWebElement SuccessMessage;

    }

}
