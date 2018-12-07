using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using Utilities;
using System.Collections.Generic;

namespace BlueGreenOwner
{
    public class PaymentReminderPage
    {

        public PaymentReminderPage()
        {
        }
        public PaymentReminderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //change the xpath of all elements

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'is past due')]")]
        public IWebElement paymentReminderAlert;
        public By locatorforPaymentReminderAlert = By.XPath("//h1[contains(text(),'is past due')]");

        [FindsBy(How = How.XPath, Using = "//div[.='Jump To:']")]
        public IWebElement bgoHomePage;
        public By locatorforBgoHomePage = By.XPath("//div[.='Jump To:']");

        public String paymentAlert = "Payment Reminder";


        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'make payment now')]")]
        public IWebElement MakeApaymentButton;
        public By locatorformakeApaymentButton = By.XPath("//*[contains(text(),'make payment now')]");

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'make a payment later')]")]
        public IWebElement PayBalanceLaterLink;
        public By locatorforPayBalanceLaterLink = By.XPath("//*[contains(text(),'make a payment later')]");

        





    }
}
