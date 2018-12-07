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
    public  class PageInitialize
    {


        public static MyAccountPage MyAccountPage
        {

            get
            {
                var myaccountPage = new MyAccountPage(Driver.driver);
                PageFactory.InitElements(Driver.driver, myaccountPage);
                return myaccountPage;
            }
        }

        public static HomePage HomePage
        {

            get
            {

                var homepage = new HomePage();
                PageFactory.InitElements(Driver.driver, homepage);
                return homepage;
            }
        }

            public static LoginPage LoginPage
        {
            get
            {
                var loginpage = new LoginPage();
                PageFactory.InitElements(Driver.driver, loginpage);
                return loginpage;
            }
        }
        public static VSSAHomePage VSSAHomePage
        {
            get
            {
                var vssahomepage = new VSSAHomePage();
                PageFactory.InitElements(Driver.driver, vssahomepage);
                return vssahomepage;
            }
        }
        public static AllMenus AllMenus
        {
            get
            {
                var allmenus = new AllMenus();
                PageFactory.InitElements(Driver.driver, allmenus);
                return allmenus;
            }
        }

        public static AdditionalMemberCardRequestPage AdditionalMemberCardRequestPage
        {
            get
            {
                var additionalcardmemberrequestObj = new AdditionalMemberCardRequestPage();
                PageFactory.InitElements(Driver.driver, additionalcardmemberrequestObj);
                return additionalcardmemberrequestObj;
            }
        }

        public static VSSAPremierOwnerReportPage VSSAPremierOwnerReportPage
        {
            get
            {
                var vssapremierownerreportObj = new VSSAPremierOwnerReportPage();
                PageFactory.InitElements(Driver.driver, vssapremierownerreportObj);
                return vssapremierownerreportObj;
            }
        }

        public static AdditionalCardMemberInformationPage AdditionalCardMemberInformationPage
        {
            get
            {
                var additionalcardmemberinformationObj = new AdditionalCardMemberInformationPage();
                PageFactory.InitElements(Driver.driver, additionalcardmemberinformationObj);
                return additionalcardmemberinformationObj;
            }
        }
        public static FundSourcePage FundSourcePage
        {
            get
            {
                var fundSourceObj = new FundSourcePage();
                PageFactory.InitElements(Driver.driver, fundSourceObj);
                return fundSourceObj;
            }
        }

        
       
    }

    
}


