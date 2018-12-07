using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Utilities;
using System.Configuration;

namespace BlueGreenOwner.TestCases
{
    public class PWL : LoginMethod
    {
        
        public static void CreatePWL(string userName, TestContext testContextInstance, string pagename)
        {
            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);

            try
            {
                //create pwl
                Assert.IsTrue(TestBaseClass.CreatePWLFromDashBoardOrBookMenu(testContextInstance, userName, pagename), "The PWL " + TestBaseClass.pwlreqId + " was not succesfully created");
                extentTest.Pass("The PWL " + TestBaseClass.pwlreqId + " was succesfully created", AttachScrenshot(driver, testContextInstance, "PWLsuccessfullyCreated").Build());

                Assert.IsTrue(TestBaseClass.validatePwlIsSuccesfullyCreated(testContextInstance, pagename, "add"), "The PWL Request  with Id" + TestBaseClass.pwlreqId + " was not succesfully listed in Pending Requests Table");
                extentTest.Pass("The PWL Request  with Id" + TestBaseClass.pwlreqId + " was succesfully listed in Pending Requests Table", AttachScrenshot(driver, testContextInstance, "PWLrequestListed").Build());

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


        public static void CancelPWL(string userName, TestContext testContextInstance, string pagename)
        {
           
            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);

            try
            {
                //create pwl
                Assert.IsTrue(TestBaseClass.CreatePWLFromDashBoardOrBookMenu(testContextInstance, userName, pagename), "The PWL " + TestBaseClass.pwlreqId + " was not succesfully created");
                extentTest.Pass("The PWL " + TestBaseClass.pwlreqId + " was succesfully created", AttachScrenshot(driver, testContextInstance, "PWLsuccessfullyCreated").Build());

                Assert.IsTrue(TestBaseClass.CancePwlFromDashBoardOrBookMenu(testContextInstance, pagename), "Cancel PWl was not successful");
                extentTest.Pass("The PWL Request  with Id" + TestBaseClass.pwlreqId + " was succesfully cancelled", AttachScrenshot(driver, testContextInstance, "PWLrequestCancelled").Build());

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



        //public static void ValidateSpecialRequestsOrNotesInVSSA(string userName,  TestContext testContextInstance, string pagename)
        //{
        //    try
        //    {
        //        //create pwl
        //        Assert.IsTrue(TestBaseClass.CreatePWLFromDashBoardOrBookMenu(testContextInstance, userName, pagename), "The PWL " + TestBaseClass.pwlreqId + " was not succesfully created");
        //        TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "The PWL " + TestBaseClass.pwlreqId + " was succesfully created");

        //        Assert.IsTrue(InsertNotesOrSpecialRequests(testContextInstance,"notes", TestBaseClass.pwlreqId, TestBaseClass.pwlresortName, TestBaseClass.pwlcheckindate, TestBaseClass.pwlcheckoutdate,"this is a new note"), "Insert Notes was not succesful");
        //        TestBaseClass.printOutputAndCaptureImage(testContextInstance, driver, "Insert Notes was succesful");
        //    }
        ////    catch (Exception e)
        ////    {

        ////      if (e.InnerException != null)
        //        {
        //            extentTest.Error(e.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

        //            Assert.Fail(e.InnerException.ToString());
        //        }
        //        else
        //        {
        //            extentTest.Error(e.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Exception").Build());

        //            Assert.Fail(e.Message);
        //        }
        //    }
        //    finally
        //    {
        //         TestBaseClass.LogOff(testContextInstance);
        //extentTest.Info("Logged off from BGO");
        //    }
        //}
        //

        public static void UpdatePWL(string userName, TestContext testContextInstance, string pagename)
        {
            
            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);
            try
            {
                //create pwl
                Assert.IsTrue(TestBaseClass.CreatePWLFromDashBoardOrBookMenu(testContextInstance, userName, pagename), "The PWL " + TestBaseClass.pwlreqId + " was not succesfully created");
                extentTest.Pass("The PWL Request  with Id" + TestBaseClass.pwlreqId + " was succesfully created", AttachScrenshot(driver, testContextInstance, "PWLrequestcreated").Build());


                Assert.IsTrue(TestBaseClass.UpdatePwlFromDashBoardOrBookMenu(testContextInstance, pagename), "The PWL Request  with Id" + TestBaseClass.pwlreqId + " was not succesfully updated");

                extentTest.Pass("The PWL Request  with Id" + TestBaseClass.pwlreqId + " was succesfully updated", AttachScrenshot(driver, testContextInstance, "PWLrequestupdated").Build());


                Assert.IsTrue(TestBaseClass.validatePwlIsSuccesfullyUpdated(testContextInstance, pagename, "edit"), "The Updated PWL Request  with Id" + TestBaseClass.pwlreqId + " was not listed in Pending Requests Table");
                extentTest.Pass("The PWL Request  with Id" + TestBaseClass.pwlreqId + " was is listed in Pending Requests Table ", AttachScrenshot(driver, testContextInstance, "PWLid_PendingrequestList").Build());


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


        public static bool InsertNotesOrSpecialRequests(TestContext testContextInstance, IWebDriver driver, string item, string pwlreqId, string resortname, string cin, string cout, string val)
        {
           
            HomePage homepageObj = new HomePage(driver);
            AllMenus topMenuobj = new AllMenus(driver);

            bool flag = false;
            try
            {
                PWLConfirmationPage confirmObj = new PWLConfirmationPage(driver);

                MyDashboardPage dbobj = new MyDashboardPage(driver);

                PWLRequestHistoryPage historyobj = new PWLRequestHistoryPage(driver);

                VSSAPremierOwnerReportPage vssaPremierObj = new VSSAPremierOwnerReportPage(driver);
               
                SelectElementByIndex(vssaPremierObj.PleaseSelect,driver,20);

                driver.Url = ConfigurationManager.AppSettings["UrlForVSSAPremierReportPage"];
                foreach (IWebElement ele in vssaPremierObj.ResortNameList)
                {
                    if (ele.Text.Equals(resortname))
                    {
                        ele.Click();
                        flag = true;
                        break;
                    }

                }

                //if (!(pagename.ToLower().Equals("dashboard")))
                //{
                //    confirmObj.pendingRequestHyperLink.Click();
                //    Assert.IsTrue((isElementVisible(historyobj.locatorforPendingRequestTable, Constants.shortLoadTime)), "On clicking See Pending and Serviced Request link ,Request History Page was not  displayed");
                //    Assert.IsTrue(CancelPWlLogic(testContextInstance, pagename), "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table");
                //    WriteTestResults(testContextInstance, "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table");
                //}
                //else
                //{
                //    AllMenus topMenuobj = new AllMenus();
                //    baseDriver.Url = ConfigurationManager.AppSettings["UrlMyDashBoardPage"];
                //    Assert.IsTrue(isElementVisible(dbobj.locatorforPWLTable, Constants.shortLoadTime), "PWL table was not shown in my DashBoard page");
                //    Assert.IsTrue(CancelPWlLogic(testContextInstance, pagename), "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                //    WriteTestResults(testContextInstance, "On Cancelling the PWL request " + pwlreqId + ", was removed from the Pending Request Table in My DashBoard Page");
                //}

                flag = true;

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
            return flag;
        }

    }
}
