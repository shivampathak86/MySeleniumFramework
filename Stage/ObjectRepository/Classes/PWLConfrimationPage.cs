using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace BlueGreenOwner
{
    public class PWLConfirmationPage
    {
        public PWLConfirmationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PWLConfirmationPage()
        {

        }

        [FindsBy(How = How.Id, Using = "newRequestDiv")]
        public IWebElement confimationMessage;
        public By locatorforconfimationMessage = By.Id("newRequestDiv");

        [FindsBy(How = How.Id, Using = "requestIdNumber")]
        public IWebElement requestID;
        public By locatorforrequestID = By.Id("requestIdNumber");
        //locator changed
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'view all premier wait list requests')]")]
        public IWebElement pendingRequestHyperLink;
        public By locatorforpendingRequestHyperLink = By.XPath("//a[contains(text(),'view all premier wait list requests')]");

        //u[contains(text(),'See Pending and Serviced Requests')]

        [FindsBy(How = How.XPath, Using = "//u[contains(text(),'See Pending and Serviced Requests')]")]
        public IWebElement SeependingRequestLink;
        public By locatorforSeePendingRequestLink = By.XPath("//u[contains(text(),'See Pending and Serviced Requests')]");

        [FindsBy(How = How.Id, Using = "btnSubmitAnotherRequest")]
        public IWebElement submitAnotherRequestBtn;
        public By locatorforsubmitAnotherRequestBtn = By.Id("btnSubmitAnotherRequest");


        //Edit Request confirmation Page
        [FindsBy(How = How.Id, Using = "requestIdNumberUpdated")]
        public IWebElement requestIDUpdated;
        public By locatorforrequestIDUpdated = By.Id("requestIdNumberUpdated");

        [FindsBy(How = How.Id, Using = "updatedRequestDiv")]
        public IWebElement UpdateConfimationMessage;
        public By locatorforUpdateConfimationMessage = By.Id("updatedRequestDiv");

        [FindsBy(How = How.XPath, Using = ".//*[@id='updatedRequestDiv']//a[@href='PremierPending.aspx']")]
        public IWebElement PendingRequestHyperLinkinEdit;
        public By locatorforPendingRequestHyperLinkinEdit = By.XPath(".//*[@id='updatedRequestDiv']//a[@href='PremierPending.aspx']");

        public string reqId = null;


    }
}
