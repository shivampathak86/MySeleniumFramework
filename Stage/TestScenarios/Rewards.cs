using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace BlueGreenOwner.TestCases
{
    [TestClass]
    public class Rewards : LoginMethod
    {

        public static void inviteAFriend(string userName, TestContext testContextInstance)
        {

            try
            {
                LoginPage loginPageObj = new LoginPage(driver);
                HomePage homepageObj = new HomePage(driver);
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() {  topMenuobj.locatorforRewards, topMenuobj.locatorforInviteFriends };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() {  topMenuobj.Rewards, topMenuobj.InviteFriends };
                List<String> ListOfMenuNames = new List<String>() { "Rewards", "Invite Friends" };

                MenuLevel1(ListOfMenuLocators, driver);

                Assert.IsTrue(IsElementPresentUsingBy(topMenuobj.locatorforReferAFriendPage,driver), "The Invite A friends Page was not shown");
                extentTest.Pass("Invite A friends Page was shown", AttachScrenshot(driver, testContextInstance, "InviteAfriendPageDisplayed").Build());

                RewardsPage rewardsObj = new RewardsPage(driver);

                Assert.IsTrue((IsSingleELementVisible(rewardsObj.locatorforRegisteraReferralToday, driver)), "Regsiter A Referral Today Button was not present");
                rewardsObj.RegisteraReferralToday.Click();

                Assert.IsTrue((TestBaseClass.fillReferAFriendDetails(rewardsObj, testContextInstance)), "Register a friend was not successful");

                extentTest.Pass("Register a friend was successful", AttachScrenshot(driver, testContextInstance, "RegisterAfriendWasSuccessful").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");



            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }


        }




        public static void TabsForSamplerOwner(string userName, TestContext testContextInstance)
        {

            try
            {
                LoginPage loginPageObj = new LoginPage(driver);
                HomePage homepageObj = new HomePage(driver);
                //Navigate to Invite friends Page
                AllMenus topMenuobj = new AllMenus(driver);

                Assert.IsFalse((IsSingleELementVisible(topMenuobj.locatorforRewards, driver)), "The Rewards tab was present for SamplerOwner");
                extentTest.Info("Rewards Tab was not present for Sampler Owner");
                extentTest.Pass("Rewards Tab was not present for Sampler Owner", AttachScrenshot(driver, testContextInstance, "RewardsTabWasNotPresent").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.InnerException.ToString());
                }
                else
                {
                    extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

                    Assert.Fail(e.Message);
                }
            }



        }
    }
}