using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using BlueGreenOwner;
using Utilities;

namespace BlueGreenowner.TestCases
{
   public class FundSource
    {
        //public static bool FindTransactionInFundSource(IWebDriver driver,TestContext testContextInstance,string ValNameOnCard, string ValConfirmationAmount, string ValConfirmationNumber)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        FundSource.LoginToFundSource();
        //        //FundSourcePage fObj = new FundSourcePage();
        //        //PageFactory.InitElements(baseDriver, fObj);
        //        //baseDriver.Url = ConfigurationManager.AppSettings["UrlForFundSource"];
        //        //Assert.IsTrue(LoginToFundSource(fObj), "Login To FundSource was not successful");
        //        //printOutputAndCaptureImage(testContextInstance, baseDriver, "Login To FundSource was successful");

        //        ////navigate to transactions list page
        //        //baseDriver.Url = ConfigurationManager.AppSettings["UrlForFundSourceTransactionsPage"];
        //        //Assert.IsTrue(isElementVisible(fObj.locatorFortransactionsTable, Constants.shortLoadTime), "The transactions table  was not  displayed in FundSource");
        //        //printOutputAndCaptureImage(testContextInstance, baseDriver, "The transactions table  was displayed in FundSource");

        //        //List<IWebElement> ListCardHolder = new List<IWebElement>(fObj.transactions_CardholderCol);
        //        //List<IWebElement> ListAuth = new List<IWebElement>(fObj.transactions_AuthCol);
        //        //List<IWebElement> ListAmount = new List<IWebElement>(fObj.transactions_AmountCol);
        //        //List<IWebElement> ListExpiry = new List<IWebElement>(fObj.transactions_ExpiryCol);
        //        //Assert.IsTrue(ListCardHolder.Count > 0, "The transactions was empty");
        //        //printOutputAndCaptureImage(testContextInstance, baseDriver, "A list of transactions were shown in FundSource");

        //        //for (int i = 0; i < ListCardHolder.Count; i++)
        //        //{

        //        //    if ((ListAuth[i].Text.Replace(",", "").Equals(ValConfirmationNumber)) && (ListAmount[i].Text.Replace(",", "").Replace(".00", "").Equals(ValConfirmationAmount.Replace(",", "").Replace(".00", "").Replace("$", ""))))
        //        //    {
        //        //        flag = true;
        //        //        break;
        //        //    }

        //        //}
        //    }
        //    catch (Exception e)
        //    {
        //      //  logger.Trace(e.StackTrace);
        //        flag = false;

        //    }

        //    return flag;
        //}


        //public static bool LoginToFundSource()
        //{
        //    bool flag = false;
        //    try
        //    {
        //        GenericHelper.ClearValue(Pages.FundSourcePage.locatorforloginId,Pages.FundSourcePage.loginId,Constants.shortLoadTime);
        //        GenericHelper.ClearValue(Pages.FundSourcePage.locatorforpassword, Pages.FundSourcePage.password, Constants.shortLoadTime);
        //        GenericHelper.ClearValue(Pages.FundSourcePage.locatorforpassword, Pages.FundSourcePage.password, Constants.shortLoadTime);
        //        fObj.loginId.SendKeys(Constants.ValUserid1);
        //        fObj.password.SendKeys(Constants.ValPassword);
        //        fObj.loginButton.Click();

        //        if ((isElementVisible(fObj.locatorforlinkTransactions, Constants.shortLoadTime)))
        //        {
        //            flag = true;

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Trace(e.StackTrace);
        //        flag = false;

        //    }
        //    return flag;
        //}

    }
}
