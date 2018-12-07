using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueGreenOwner
{
    public class FundSourcePage
    {
        public FundSourcePage()
        {

        }

        public FundSourcePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@ id='login_name']")]
        public IWebElement loginId;
        public By locatorforloginId = By.XPath("//input[@ id='login_name']");

        [FindsBy(How = How.XPath, Using = "//input[@id='login_password']")]
        public IWebElement password;
        public By locatorforpassword = By.XPath("//input[@id='login_password']");

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        public IWebElement loginButton;
        public By locatorforloginButton = By.XPath("//input[@value='Login']");

        [FindsBy(How = How.XPath, Using = "//img[@alt='Home Page']")]
        public IWebElement FundSourceHomePg;
        public By locatorforFundSourceHomePg = By.XPath("//img[@alt='Home Page']");

        [FindsBy(How = How.XPath, Using = "//a[.='Advanced search']")]
        public IWebElement AdvanceSearch;
        public By locatorforAdvanceSearch = By.XPath("//a[.='Advanced search']");

        [FindsBy(How = How.XPath, Using = "//select[@id='search_field']")]
        public IWebElement SearchDropDown;
        public By locatorforSearchDropDown = By.XPath("//select[@id='search_field']");

        [FindsBy(How = How.XPath, Using = "//input[@id='advanced-search']")]
        public IWebElement AdvanceSearchTxtField;
        public By locatorforAdvanceSearchTxtField = By.XPath("//input[@id='advanced-search']");

        [FindsBy(How = How.XPath, Using = "//input[@id='advanced_search_button']")]
        public IWebElement AdvanceSearchBtn;
        public By locatorforAdvanceSearchBtn = By.XPath("//input[@id='advanced_search_button']");

        [FindsBy(How = How.XPath, Using = "//div[@class='middle']")]
        public IWebElement NoOfTransactions;
        public By locatorforNoOfTransactions = By.XPath("//div[@class='middle']");

        [FindsBy(How = How.XPath, Using = "//p[@id='transaction_audit-empty-message']")]
        public IWebElement NoTransactionFound;
        public By locatorforNoTransactionFound = By.XPath("//p[@id='transaction_audit-empty-message']");

        //[FindsBy(How = How.XPath, Using = "//strong[text()='846837']")]
        //public IWebElement TransactionDoneForArvact;
        //public By locatorforTransactionDoneForArvact = By.XPath("//strong[text()='846837']");

        [FindsBy(How = How.XPath, Using = "//strong[@class='highlight']")]
        public IWebElement TransactionFound;
        public By locatorforTransactionFound = By.XPath("//strong[@class='highlight']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Transactions']")]
        public IWebElement linkTransactions;
        public By locatorforlinkTransactions = By.XPath("//a[text()='Transactions']");

        [FindsBy(How = How.XPath, Using = "//input[@id='search']")]
        public IWebElement BasicSearchTextField;
        public By locatorforBasicSearchTextField= By.XPath("//input[@id='search']");

        [FindsBy(How = How.XPath, Using = "//input[@id='search_button']")]
        public IWebElement BasicSearchBtn;
        public By locatorforBasicSearchBtn = By.XPath("//input[@id='search_button']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-content']//table[@class='standard']/tbody[@id='transaction_audit-tbody']")]
        public IWebElement transactionsTable;
        public By locatorFortransactionsTable = By.XPath(".//*[@id='transaction_audit-content']//table[@class='standard']/tbody[@id='transaction_audit-tbody']");


        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-tbody']//td[2]")]
        public IList<IWebElement> transactions_CardholderCol { get; set; }
        public By locatorfortransactions_CardholderCol = By.XPath(".//*[@id='transaction_audit-tbody']//td[2]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-tbody']//td[4]")]
        public IList<IWebElement> transactions_AmountCol { get; set; }
        public By locatorfor_transactions_AmountCol = By.XPath(".//*[@id='transaction_audit-tbody']//td[4]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-tbody']//td[14]")]
        public IList<IWebElement> transactions_ExpiryCol { get; set; }
        public By locatorfor_transactions_ExpiryCol = By.XPath(".//*[@id='transaction_audit-tbody']//td[14]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-tbody']//td[11]")]
        public IList<IWebElement> transactions_AuthCol { get; set; }
        public By locatorfor_transactions_AuthCol = By.XPath(".//*[@id='transaction_audit-tbody']//td[11]");


        [FindsBy(How = How.XPath, Using = ".//*[@id='transaction_audit-tbody']//td[13]")]
        public IList<IWebElement> transactions_RefNo { get; set; }
        public By locatorfor_transactions_RefNo = By.XPath(".//*[@id='transaction_audit-tbody']//td[13]");

        [FindsBy(How = How.XPath, Using = "//*[@class='overlay']")]
        public IWebElement Overlay;
        public By LocatorforOverlay = By.XPath("//*[@class='overlay']");



    }
}
