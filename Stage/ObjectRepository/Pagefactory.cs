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
    public class Pages
    {


        public static MyAccountPage MyAccountPage
        {

            get
            {
                var myaccountPage = new MyAccountPage();
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

        }

    
}


