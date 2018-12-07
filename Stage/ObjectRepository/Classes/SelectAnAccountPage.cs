using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class SelectAnAccountPage
    {

        public String xpathForNonClub;

        [FindsBy(How = How.XPath, Using = "//label[text()='Vacation Club']")]
        public IWebElement vacationClubRadioBtn;
        public By locatorforvacationClubRadioBtn = By.XPath("//label[text()='Vacation Club']");

      
       

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Jump To:')]")]
        public IWebElement HomePageNonClub;
        public By HomePagelocatorforNonClub = By.XPath("//div[contains(text(),'Jump To:')]");

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        public IWebElement continueBtn;
        public By locatorforcontinueBtn = By.XPath("//button[text()='Continue']");

        public IWebElement AccountsTable { get; set; }

        [FindsBy(How=How.XPath, Using = ".//label[contains(@for,'rbtn')]")]
        public IWebElement RadioButtonElement { get; set; }

        public By LocatorforRadioButtonElement = By.XPath(".//label[contains(@for,'rbtn')]");

        public SelectAnAccountPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


       


       
    }
}
