using BlueGreenOwner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BlueGreenOwner.TestCases
{
    public class LMA : LoginMethod
    {

        public static void validateLMAPageForFixFlexOwner(string userName, TestContext testContext)
        {
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);


            try
            {
                List<string> fieldName;
                List<By> locatorForField;
                List<IWebElement> Objects;

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts };
                List<string> ListOfMenuNames = new List<string>() { "Book", "BlueGreenResorts" };

                fieldName = new List<string>() { "Points", "Bonus Time", "Saved Searches", "Last Minute Availability" };
                locatorForField = new List<By>() { topMenuobj.locatorforPoints, topMenuobj.locatorforBonusTime, topMenuobj.locatorforSavedSearches, topMenuobj.locatorforLastMinuteAvaialbility };

                Assert.IsTrue(TestBaseClass.IsSecondLevelMenudisplayedLogic(fieldName, locatorForField, ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, testContext), "Second Level Menu was displayed for BlueGreenResorts");
                extentTest.Pass("The submenus Points, Bonus Time, Saved Searches, Last Minute Availability  were not displayed for BlueGreenResorts", AttachScrenshot(driver, testContext, "Points,BonusTime,SavedSearch,LMA_NotDisplayedforBluegreenResorts").Build());

                //For  Vacation Planning tools
                fieldName.Clear();
                locatorForField.Clear();
                fieldName = new List<string>() { "Points Calculator", "Points Chart", "Reservation Reminder", "Vacation Week Calender" };

                locatorForField = new List<By>() { topMenuobj.locatorforPointCalculator, topMenuobj.locatorforPointChart, topMenuobj.locatorforReservationReminder, topMenuobj.locatorforVacationWeekCalender };
                ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.VacationPlanningTools };
                ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforVacationPlanningTools };
                ListOfMenuNames = new List<string>() { "Book", "Vacation Planning Tools" };

                Assert.IsTrue(TestBaseClass.IsSecondLevelMenudisplayedLogic(fieldName, locatorForField, ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, testContext), "Second Level Menu was displayed for Vacation Planning Tools");
                extentTest.Pass("The submenus Points Calculator, Points Chart, Reservation Reminder, Vacation Week Calender were not displayed for Vacation Planning Tools", AttachScrenshot(driver, testContext, "Points Calculator,Points Chart,ReservationReminder,VacationWeekCalender_NotDisplayedForVacationPlanningTools").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePgObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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

        public static void validateLMAPageForVCorSampler24Owner(string userName, TestContext testContext)
        {
            AllMenus topMenuobj = new AllMenus(driver);
            HomePage homePgObj = new HomePage(driver);
            LMAPage lmaObj = new LMAPage(driver);

            try
            {

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforBook, topMenuobj.locatorforBlueGreenResorts, topMenuobj.locatorforLastMinuteAvaialbility };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.Book, topMenuobj.BlueGreenResorts, topMenuobj.LastMinuteAvaialablity };
                List<String> ListOfMenuNames = new List<String>() { "Book", "BlueGreenResorts", "Last Minute Availablity" };

                List<string> fieldName;
                List<By> locatorForField;
                List<IWebElement> Objects;

                MenuLevel2(ListOfMenuLocators, driver);

                // Assert.IsTrue(TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["URlLMAPage"]), "Last Minute Availabilty Page was not selected");
                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforLMApage, driver), "Last Minute Availabilty Page is not displayed");
                extentTest.Pass("Last Minute Availabilty Page is displayed", AttachScrenshot(driver, testContext, "LMApageDisplayed").Build());

                fieldName = new List<string>() { "Make A reservation Button", "Future Month Links" };

                locatorForField = new List<By>() { lmaObj.locatorformakeAreservation, lmaObj.locatorformonthLinks };

                //prints the field display results
                Assert.IsTrue(TestBaseClass.IsAllInputFieldsDisplayed(testContext, fieldName, lmaObj.pageName, locatorForField), "The fields  Make A reservation Button, Future Month Links are not displayed");
                extentTest.Pass("The fields  Make A reservation Button, Future Month Links are  displayed", AttachScrenshot(driver, testContext, "MakeAReservationButton,FutureMonthLinks_Displayed").Build());

                List<string> Month = new List<string>() { };
                List<string> Year = new List<string>() { };
                List<string> xpathForLink = new List<string>() { };
                List<string> xpathForResortNames = new List<string>() { };
                List<bool> foundelement = new List<bool>() { };

                string m = "";
                string y = "";
                string lxpath = "";
                string rxpath = "";
                for (int i = 0; i < Constants.NoOfMonthsInLMA; i++)
                {
                    m = DateTime.Now.AddMonths(i).ToString("MMMM");
                    Month.Add(m);
                    y = DateTime.Now.AddMonths(i).ToString("yyyy");
                    Year.Add(y);
                    lxpath = @".//*[@id='tab-" + m.ToLower() + "-" + y + "']/..";
                    xpathForLink.Add(lxpath);
                    rxpath = lxpath = @".//*[@id='" + m.ToLower() + "-" + y + "']//h2/a[@itemprop='name']";
                    xpathForResortNames.Add(lxpath);
                }

                //  for(int i= 0;i < Constants.NoOfMonthsInLMA;i++)
                IWebElement parentEle = null;
                IReadOnlyCollection<IWebElement> ListResortNames;
                string resortsforMonth = "";
                int k = 0;
                int countLink = 0;
                foreach (IWebElement ele in lmaObj.monthLinks)
                {
                    resortsforMonth = "";
                    parentEle = TestBaseClass.FindAnElementUsingDriver("xpath", xpathForLink[k]);
                    if (k == 0)
                    {
                        Assert.IsTrue(parentEle.GetAttribute("class").Equals("active"), "Current month link " + Month[k] + " was  not defaultly displayed");
                        extentTest.Info("Current month link " + Month[k] + " was  defaultly displayed");

                    }
                    else
                    {
                        ele.Click();
                    }

                    ListResortNames = TestBaseClass.FindElementsUsingDriver("xpath", xpathForResortNames[k]);

                    // Changes done by Fathima
                    if (ListResortNames.Count > 0)
                    {
                        extentTest.Info("Resort names were not listed for the month link-" + Month[k] + "-" + Year[k]);
                    }
                    extentTest.Info("Resort names were listed for the month link-" + Month[k] + "-" + Year[k]);

                    foreach (IWebElement element in ListResortNames)
                    {
                        resortsforMonth = resortsforMonth + element.Text.ToString() + ",";
                    }
                    extentTest.Pass("The following Resorts  were displayed-" + "\n" + resortsforMonth, AttachScrenshot(driver, testContext, "FollowingResortsDisplayed").Build());

                    k++;
                    countLink++;
                }
                Assert.IsTrue(countLink.Equals(Constants.NoOfMonthsInLMA), "Resort names were not listed for all of the months links");
                extentTest.Pass("Resort names were listed for all of the months links", AttachScrenshot(driver, testContext, "ResortNames").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homePgObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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
