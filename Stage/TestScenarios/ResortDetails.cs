using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class ResortDetails : LoginMethod
    {


        public static void ValidateResortDetails(TestContext testContext)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);

            try
            {

                Assert.IsTrue(IsElementPresentUsingBy(homePgObj.locatorforAssociationLink, driver), " association link is not displayed");
                extentTest.Pass("association link is displayed", AttachScrenshot(driver, testContext, "AssociationLink").Build());

                WaitForElementToBeClickable(homePgObj.associationLink, driver).Click();
                // ClickLink(homePgObj.associationLink,driver);
                extentTest.Info("Association link is clicked");

                Assert.IsTrue(IsSingleELementVisible(homePgObj.associationOwners, driver), " association owners section is not displayed in resort details page");
                extentTest.Pass("association owners section is displayed in resort details page", AttachScrenshot(driver, testContext, "AssociationOwnersSection").Build());

                Assert.IsTrue(IsSingleELementVisible(homePgObj.associationOwnersContent, driver), " association owners content is not displayed in resort details page");
                extentTest.Pass("association owners content is displayed in resort details page", AttachScrenshot(driver, testContext, "AssociationOwnersContent").Build());

                LogOff(allMenusObj.locatorforMyBlueGreen, homePgObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContext, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }

    }
}
