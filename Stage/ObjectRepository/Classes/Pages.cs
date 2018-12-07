using BlueGreenOwner;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BlueGreenOwner
{ 
    public  class Pages
    {
        public Pages()
        {

        }

        public Pages(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }



        public static MyAccountPage MyAccountPage
        {

            get
            {
                var myaccountPage = new MyAccountPage(Driver.WebDriver);
                PageFactory.InitElements(Driver.WebDriver, myaccountPage);
                return myaccountPage;
            }
        }

        public static HomePage HomePage
        {

            get
            {

                var homepage = new HomePage();
                PageFactory.InitElements(Driver.WebDriver, homepage);
                return homepage;
            }
        }

            public static LoginPage LoginPage
        {
            get
            {
                var loginpage = new LoginPage();
                PageFactory.InitElements(Driver.WebDriver, loginpage);
                return loginpage;
            }
        }
        public static VSSAHomePage VSSAHomePage
        {
            get
            {
                var vssahomepage = new VSSAHomePage();
                PageFactory.InitElements(Driver.WebDriver, vssahomepage);
                return vssahomepage;
            }
        }
        public static AllMenus AllMenus
        {
            get
            {
                var allmenus = new AllMenus();
                PageFactory.InitElements(Driver.WebDriver, allmenus);
                return allmenus;
            }
        }

        public static AdditionalMemberCardRequestPage AdditionalMemberCardRequestPage
        {
            get
            {
                var additionalcardmemberrequestObj = new AdditionalMemberCardRequestPage();
                PageFactory.InitElements(Driver.WebDriver, additionalcardmemberrequestObj);
                return additionalcardmemberrequestObj;
            }
        }

        public static VSSAPremierOwnerReportPage VSSAPremierOwnerReportPage
        {
            get
            {
                var vssapremierownerreportObj = new VSSAPremierOwnerReportPage();
                PageFactory.InitElements(Driver.WebDriver, vssapremierownerreportObj);
                return vssapremierownerreportObj;
            }
        }

        public static AdditionalCardMemberInformationPage AdditionalCardMemberInformationPage
        {
            get
            {
                var additionalcardmemberinformationObj = new AdditionalCardMemberInformationPage();
                PageFactory.InitElements(Driver.WebDriver, additionalcardmemberinformationObj);
                return additionalcardmemberinformationObj;
            }
        }
        public static FundSourcePage FundSourcePage
        {
            get
            {
                var fundSourceObj = new FundSourcePage();
                PageFactory.InitElements(Driver.WebDriver, fundSourceObj);
                return fundSourceObj;
            }
        }

        
       
    }

    
}


