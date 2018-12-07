using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace BlueGreenOwner
{
    public class VSSAHomePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='txtARVACT']")]
        public IWebElement Arvactnumber;
        public By locatorForArvactnumber = By.XPath("//input[@id='txtARVACT']");

        [FindsBy(How = How.XPath, Using = ".//input[@id='btnSearch']")]
        public IWebElement SearchButton;
        public By locatorForSearchButton = By.XPath(".//input[@id='btnSearch']");

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),' - User not in good Standing / Not qualified for online access')]")]
        public IWebElement MsgGoodStanding;
        public By locatorForMsgGoodStanding = By.XPath("//span[contains(text(),' - User not in good Standing / Not qualified for online access')]");

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtEmail']")]
        public IWebElement Email;
        public By locatorForEmail = By.XPath(".//*[@id='txtEmail']");

        [FindsBy(How = How.XPath, Using = " .//*[@id='gvAccountHolders']/tbody")]
        public IWebElement ResultTable;
        public By locatorForResultTable = By.XPath(" .//*[@id='gvAccountHolders']/tbody");

        [FindsBy(How = How.XPath, Using = ".//*[@id='gvSearchResults_lbARVACT_0']")]
        public IWebElement arvactlink;
        public By locatorForarvactlink = By.XPath(".//*[@id='gvSearchResults_lbARVACT_0']");

        [FindsBy(How = How.Id, Using = "btnLoginasOwner")]
        public IWebElement loginAsuSer;
        public By locatorForloginAsUser = By.Id("btnLoginasOwner");

        public string pageName = "VSSA Home Page";

        //Elements declared by Fathima

        [FindsBy(How = How.XPath, Using = "//input[@id='txtcurrentEmail']")]
        public IWebElement EmailUpdate;
        public By locatorForEmailUpdate = By.XPath("//input[@id='txtcurrentEmail']");

        [FindsBy(How = How.XPath, Using = "//input[@id='btnUpdateEmail']")]
        public IWebElement EmailUpdateBtn;
        public By locatorForEmailUpdateBtn = By.XPath("//input[@id='btnUpdateEmail']");

        [FindsBy(How = How.Id, Using = "**First Name:")]
        public IWebElement FirstName;
        public By locatorForFirstName = By.Id("**First Name:");

        [FindsBy(How = How.Id, Using = "*Last Name:")]
        public IWebElement LastName;
        public By locatorForLastName = By.Id("*Last Name:");

        [FindsBy(How = How.Id, Using = "fvOwner_ddlCountry")]
        public IWebElement CountryDropDownList;
        public By locatorForCountryDropDownList = By.Id("fvOwner_ddlCountry");

        [FindsBy(How = How.Id, Using = "fvOwner_txtAddress1")]
        public IWebElement AddressLine1;
        public By locatorForAddressLine1 = By.Id("fvOwner_txtAddress1");

        [FindsBy(How = How.Id, Using = "fvOwner_txtCity")]
        public IWebElement CityTxtField;
        public By locatorForCityTxtField = By.Id("fvOwner_txtCity");

        [FindsBy(How = How.Id, Using = "fvOwner_ddlState")]
        public IWebElement StateDropDownList;
        public By locatorForStateDropDownList = By.Id("fvOwner_ddlState");

        [FindsBy(How = How.Id, Using = "fvOwner_txtZip")]
        public IWebElement ZipCodeTxtField;
        public By locatorForZipCodeTxtField = By.Id("fvOwner_txtZip");

        [FindsBy(How = How.Id, Using = "fvOwner_txtHomePhone")]
        public IWebElement PrimaryPhoneTxtField;
        public By locatorForPrimaryPhoneTxtField = By.Id("fvOwner_txtHomePhone");

        [FindsBy(How = How.Id, Using = "fvOwner_txtAltPhone")]
        public IWebElement AlternatePhoneTxtField;
        public By locatorForAlternatePhoneTxtField = By.Id("fvOwner_txtAltPhone");

        [FindsBy(How = How.Id, Using = "lblTPExp")]
        public IWebElement TPExpiration;
        public By locatorForTPExpiration = By.Id("lblTPExp");


        public VSSAHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public VSSAHomePage()
        {

        }
        //public VSSAHomePage(IWebDriver driver)
        //{
        //    PageFactory.InitElements(driver, this);

        //}

    


      //  public string UrlForVSSAHomePage = string.Empty;

        //public VSSAHomePage()
        //{
        //    if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("STAGE"))
        //        {

        //        UrlForVSSAHomePage = @"https://stg.vssa.bxgcorp.com/";
        //    }
        //    else if (ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("PRODUCTION"))
        //    {
        //        UrlForVSSAHomePage = @"https://vssa.bxgcorp.com/";

        //    }
        //}


        //stage
          public string UrlForVSSAHomePage = "https://stg.vssa.bxgcorp.com/";

        //prod
        // public string UrlForVSSAHomePage = "https://vssa.bxgcorp.com/";
    }
}
