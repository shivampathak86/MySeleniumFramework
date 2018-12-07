using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using BlueGreenOwner;
using System.Configuration;

namespace BlueGreenOwner.TestCases
{
    [TestClass]
    public class PrePayment 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void MakeAPrepayment(string userName, TestContext testContextInstance)
        {

            try
            {
                //Assert.IsTrue((TestBaseClass.SetUp(testContextInstance, Constants.Browser)), "BGO was not launched successfully");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "BGO was launched successfully");
                ////Login to BGO     
                LoginPage loginPageObj = new LoginPage();
                //PageFactory.InitElements(TestBaseClass.baseDriver, loginPageObj);
                //Assert.IsTrue((TestBaseClass.login_BlueGreenOwner(loginPageObj, userName, "")), "Login was not successful");
                //TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "Login was successful");

                ////Navigate to Invite friends Page
                AllMenus topMenuobj = new AllMenus();
                PageFactory.InitElements(TestBaseClass.baseDriver, topMenuobj);

                TestBaseClass.baseDriver.Url = ConfigurationManager.AppSettings["URlHomePage"];
               // Thread.Sleep(4000);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMaintenanceFees, topMenuobj.locatorforMakeAPrePayment };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MaintenanceFees, topMenuobj.MakeAPrePayment };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "Payments", "Make A Pre-Payment" };

                Assert.IsTrue((TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, TestBaseClass.baseDriver, ConfigurationManager.AppSettings["URLForMakeAPrePaymentPage"])), "The Make A PrePayment Page was not  shown");
                TestBaseClass.WriteTestResults(testContextInstance, "The Make A PrePayment Page was shown");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The Make A PrePayment Page was shown");


                PrePaymentPage pageObj = new PrePaymentPage();
                PageFactory.InitElements(TestBaseClass.baseDriver, pageObj);

                Assert.IsTrue(TestBaseClass.isElementVisible(pageObj.locatorforcreditDebitRadioButton, Constants.shortLoadTime), "The options to select the payment and entering amount were not shown");
                TestBaseClass.WriteTestResults(testContextInstance, "The options to select the payment and entering amount were shown");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The options to select the payment and entering amount was shown");


                Random rint = new Random();
                string AmountToPay = Constants.AmountToPrepay.ToString();

                Assert.IsTrue(fillMakeAPrePaymentPage(pageObj, AmountToPay), "On entering PrePayment Amount and  Selecting Credit or Debit card option ,Payments Credit Card Information Page was not displayed");
                TestBaseClass.WriteTestResults(testContextInstance, "The Payments Credit Card Information Page was shown");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The Payments Credit Card Information Page was shown");


                Assert.IsTrue(TestBaseClass.fillPrePaymentCreditCardInfo(pageObj), "Payment Confirmation Page was not displayed  on submitting the Credit Card details");
                TestBaseClass.WriteTestResults(testContextInstance, "The Payments Confirmation Page was shown");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The Payments Confirmation Page was shown");

                ////validate the amount in confrimation message
                Assert.IsTrue(!(String.IsNullOrEmpty(pageObj.ConfirmationNumber.Text))
                    && !(String.IsNullOrWhiteSpace(pageObj.ConfirmationNumber.Text)), "The confirmation Number displayed was " + pageObj.ValConfirmationNumber);
                TestBaseClass.WriteTestResults(testContextInstance, "The confirmation Number displayed was " + pageObj.ValConfirmationNumber);
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The confirmation Number displayed was " + pageObj.ValConfirmationNumber);

                ////validate the amount

                Assert.IsTrue(pageObj.ValConfirmationAmount.Replace(".00", "").Replace(",", "").Equals(Constants.currency + AmountToPay.Replace(",", "")), "The confirmation amount displayed was" + AmountToPay);
                TestBaseClass.WriteTestResults(testContextInstance, "The confirmation amount displayed was " + AmountToPay);
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The confirmation amount displayed was " + AmountToPay);

                //validate in fundsource
                Assert.IsTrue(TestBaseClass.FindTransactionInFundSource(testContextInstance, topMenuobj, pageObj.ValNameOnCard, pageObj.ValConfirmationAmount, pageObj.ValConfirmationNumber), "The prepayment transaction " + pageObj.ValConfirmationNumber + " was not found in fundSource");
                TestBaseClass.WriteTestResults(testContextInstance, "The prepayment transaction " + pageObj.ValConfirmationNumber + " was found in fundSource");
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, "The prepayment transaction was found in fundSource");
                TestBaseClass.baseDriver.Url = ConfigurationManager.AppSettings["URlHomePage"];
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace + "\r\n" + e.Message);
                TestBaseClass.printOutputAndCaptureImage(testContextInstance, TestBaseClass.baseDriver, e.Message);
                Assert.Fail(e.Message);
            }
            finally
            {
                TestBaseClass.LogOff(testContextInstance);
                TestBaseClass.EndExecutionRoutine();
            }


        }


        public static bool fillMakeAPrePaymentPage(PrePaymentPage pageObj, string amount)
        {
            bool flag = false;

            try
            {

                pageObj.prepaymentAmountTextBox.Clear();
                pageObj.prepaymentAmountTextBox.SendKeys(amount);
                pageObj.creditDebitRadioButton.Click();
                pageObj.PayNowButton.Click();

                if ((TestBaseClass.isElementVisible(pageObj.locatorforcardNum, Constants.shortLoadTime)))
                {
                    flag = true;

                }
            }
            catch (Exception e)
            {
                logger.Trace(e.StackTrace);
                flag = false;
            }
            return flag;
        }
    }
}
