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
    public class PaymentReminder : LoginMethod
    {

        public static void ValidatePaymentReminderPage(TestContext testContext, OwnerType type)
        {

            AllMenus allMenusObj = new AllMenus(driver);
            PaymentReminderPage paymentReminderPageObj = new PaymentReminderPage(driver);
            HomePage homePageObj = new HomePage(driver);
            PaymentsPage paymentObj = new PaymentsPage(driver);
           

            try
            {

                switch (type)
                {
                    case OwnerType.NonVC_SingleAssociation:

                        var expected = ConfigurationManager.AppSettings["URlHomePage"];
                        var actual = driver.Url;

                        if (string.Compare(expected, actual, StringComparison.OrdinalIgnoreCase) == 0)
                        {

                            Assert.IsTrue(IsSingleELementVisible(paymentReminderPageObj.bgoHomePage, driver), "Payment reminder page is displayed for Non VC");
                            extentTest.Pass("Payment reminder page should not be displayed for Non VC", AttachScrenshot(driver, testContext, "Homepage").Build());

                        }

                        break;

                    case OwnerType.PastDue_TPexpired:

                        Assert.IsTrue(IsSingleELementVisible(paymentReminderPageObj.locatorforPaymentReminderAlert, driver), "Payment reminder page is not displayed for past due _TP expired user");
                        extentTest.Pass("Payment reminder page is displayed for past due _TP expired user", AttachScrenshot(driver, testContext, "PaymentRemiderPgShown").Build());

                        Assert.IsTrue(IsSingleELementVisible(paymentReminderPageObj.MakeApaymentButton, driver), "Make a payment button is not displayed in the payment reminder page");
                        extentTest.Pass("Make a payment button is displayed in the payment reminder page");

                        Assert.IsTrue(IsSingleELementVisible(paymentReminderPageObj.PayBalanceLaterLink, driver), "Pay balance later link is not displayed in the payment reminder page");
                        extentTest.Pass("Pay balance later link is displayed in the payment reminder page");

                        ClickButton(paymentReminderPageObj.MakeApaymentButton, driver);
                        extentTest.Info("Make a payment button is clicked");

                        Assert.IsTrue(IsSingleELementVisible(allMenusObj.locatorforMaintenanceFeesPageTxt, driver), "My maintenace fees and club dues page is not displayed");
                        extentTest.Pass("My maintenace fees and club dues page is displayed", AttachScrenshot(driver, testContext, "MyMaintenanceFeesPgDisplayed").Build());

                        driver.Navigate().Back();
                        extentTest.Pass("Navigating back to payment reminder page");

                        Assert.IsTrue(IsSingleELementVisible(paymentReminderPageObj.locatorforPaymentReminderAlert, driver), "Payment reminder page is not displayed");
                        extentTest.Pass("Payment reminder page is displayed", AttachScrenshot(driver, testContext, "PaymentRemiderPgShown").Build());

                        ClickLink(paymentReminderPageObj.locatorforPayBalanceLaterLink, driver);
                        extentTest.Info("Pay Balance Later Link is clicked");


                        Assert.IsTrue(IsElementInvisible(paymentReminderPageObj.locatorforPaymentReminderAlert, driver), "Payment reminder page doesnot dismiss on clciking Pay Balance Later Link ");
                        extentTest.Pass("Payment reminder page dismisses on clicking Pay Balance Later Link ", AttachScrenshot(driver, testContext, "PaymentRemiderPgNotShown").Build());

                        break;

                    case OwnerType.SamplerOrSampler24:

                        Assert.IsFalse(IsSingleELementVisible(paymentReminderPageObj.locatorforPaymentReminderAlert, driver), "Payment reminder page is displayed for sampler or sampler 24");
                        extentTest.Pass("Payment reminder page should not be displayed for sampler or sampler 24", AttachScrenshot(driver, testContext, "PaymentRemiderPgNotShown").Build());

                        Assert.IsFalse(IsSingleELementVisible(allMenusObj.MaintenanceFees, driver), "Maintenace fees and club dues option is present for sampler or sampler 24");
                        extentTest.Info("Maintenace fees and club dues option is not present for sampler or sampler 24");
                        
                        break;
                        
                }


                LogOff(allMenusObj.locatorforMyBlueGreen, homePageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
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
