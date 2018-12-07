using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using Utilities;

namespace BlueGreenOwner.TestCases
{
    public class SecondaryOwner : LoginMethod
    {


        public static void ValidateResortAccessForSecondaryOwner(TestContext testContext)
        {


            AllMenus allMenusObj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);

            try
            {

                ClickButton(homePgObj.BonusTimeRadioButton, driver);

                IList<String> AllItems = ComboBoxHelper.GetAllItem(homePgObj.SelectDestinationDropDown, driver);
                extentTest.Info(AllItems.ToString());

                //SelectElement s = new SelectElement(homePgObj .SelectDestinationDropDown);
                //IList<IWebElement> AllItems = s.Options;

                //foreach (IWebElement item in AllItems)
                //{
                //    string text = item.Text;
                //    TestBaseClass.WriteTestResults(testContext, text);
                //}


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
