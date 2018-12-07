using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class LMAPage
    {
        public LMAPage()
        {

        }

        public LMAPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='last-minute-availability']//a[text()='make a reservation']")]
        public IWebElement makeAreservation;
        public By locatorformakeAreservation = By.XPath(".//*[@id='last-minute-availability']//a[text()='make a reservation']");

        [FindsBy(How = How.XPath, Using = "(.//a[@class='btn btn-primary' and text()='Explore Resort'])[1]")]
        public IWebElement exploreresort;
        public By locatorforexploreresort = By.XPath("(.//a[@class='btn btn-primary' and text()='Explore Resort'])[1]");


        [FindsBy(How = How.XPath, Using = ".//*[contains(@id,'tab')]")]
        public IList<IWebElement> monthLinks { get; set; }
        public By locatorformonthLinks = By.XPath(".//*[contains(@id,'tab')]");

        //dynamic 
        [FindsBy(How = How.XPath, Using = ".//*[@id='tab-june-2017']")]
        public IWebElement currentMonthlink;
        public By locatorforcurrentMonthLink = By.XPath(".//*[@id='tab-june-2017']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='tab-july-2017']")]
        public IWebElement nextMonthlink;
        public By locatorfornextMonthLink = By.XPath(".//*[@id='tab-july-2017']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='tab-august-2017']")]
        public IWebElement thirdMonthlink;
        public By locatorforthirdMonthlink = By.XPath(".//*[@id='tab-august-2017']");

        [FindsBy(How = How.XPath, Using = "(.//h2[@class='h2 resort-name']/a)[1]")]
        public IWebElement resortLink;
        public By locatorforresortLink = By.XPath("(.//h2[@class='h2 resort-name']/a)[1]");

        public string pageName = "LMA page";


        [FindsBy(How = How.XPath, Using = ".//*[@id='location']/h1/strong")]
        public IWebElement resortLinkOnResortPage;
        public By locatorforresortLinkOnResortPage = By.XPath(".//*[@id='location']/h1/strong");

    }
}