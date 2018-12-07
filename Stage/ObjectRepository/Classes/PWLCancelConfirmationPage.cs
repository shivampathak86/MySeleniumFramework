using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BlueGreenOwner
{
    public class PWLCancelConfirmationPage
    {


        [FindsBy(How = How.XPath, Using = ".//*[@id='lblCancelText']")]
        public IWebElement Canceltext;
        public By locatorforCancelText = By.XPath(".//*[@id='lblCancelText']");




        [FindsBy(How = How.XPath, Using = " .//*[@id='cancelConfirmationFieldSet']//b[text()='Request Id: ']")]
        public IWebElement LabelRequestId;
        public By locatorforLabelRequestId = By.XPath(" .//*[@id='cancelConfirmationFieldSet']//b[text()='Request Id: ']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='requestIdNumber']")]
        public IWebElement requestId;
        public By locatorforrequestId = By.XPath(".//*[@id='requestIdNumber']");

        [FindsBy(How = How.XPath, Using = ".//*[@id='cancelConfirmationFieldSet']//a[@href='PremierPending.aspx']")]
        public IWebElement pendingRequestHyperLink;
        public By locatorforpendingRequestHyperLink = By.XPath(".//*[@id='newRequestDiv']//a[@href='PremierPending.aspx']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='btnBackToWaitlist']")]
        public IWebElement BacktoWaitListButton;
        public By locatorforBacktoWaitListButton = By.XPath(".//*[@id='btnBackToWaitlist']");


        public string pageName = "Confirmation Page";

    }
}
