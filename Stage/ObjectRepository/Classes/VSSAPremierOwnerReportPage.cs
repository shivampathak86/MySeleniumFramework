using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class VSSAPremierOwnerReportPage
    {
        public VSSAPremierOwnerReportPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public VSSAPremierOwnerReportPage()
        {

        }

        [FindsBy(How = How.XPath, Using = "(//SPAN[@class='multiselect-selected-text'][text()='Please Select'][text()='Please Select'])[1]")]
        public IWebElement PleaseSelect;
        public By locatorforPleaseSelect = By.Id("(//SPAN[@class='multiselect-selected-text'][text()='Please Select'][text()='Please Select'])[1]");

        [FindsBy(How = How.Id, Using = "cboResortID")]
        public IList <IWebElement> ResortNameList { get; set; }
        public By locatorforResortNameList = By.Id("cboResortID");



    }
}
