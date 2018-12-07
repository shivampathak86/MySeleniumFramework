using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace BlueGreenOwner.TestCases
{

    [TestClass]
    public class SavePoints :LoginMethod
    {
        public static void VerifySaveMyPointsFunctionalityInMyPointsPage(string userName, TestContext testContextInstance)
        {
           
            try
            {
                 
                LoginPage loginPageObj = new LoginPage(driver);
              
                //Functionality specific code starts here
                IReadOnlyCollection<IWebElement> ListPointsTypeColumn;
                IReadOnlyCollection<IWebElement> ListAvailablePointsColumn;
                IReadOnlyCollection<IWebElement> ListExpDateColumn;
                IReadOnlyCollection<IWebElement> ListActionColumn;

                List<string> PointsTypeValueList = new List<string>();
                List<string> AvailablePointsValueList = new List<string>();
                List<string> ExpirationDatesValueList = new List<string>();
                List<string> ActionValueList = new List<string>();
                int totalOccurencesOfPointsTobeSaved = 0;
                int totalOccurencesOfPointsInOtherStatus = 0;
                int totalOccurencesOfAllStatus = 0;

                //Navigate to My Points Page
                AllMenus topMenuobj = new AllMenus(driver);

                List<By> ListOfMenuLocators = new List<By>() { topMenuobj.locatorforMyBlueGreen, topMenuobj.locatorforMyDashBoard, topMenuobj.locatorforMyPoints };
                List<IWebElement> ListOfMenuobjects = new List<IWebElement>() { topMenuobj.MyBlueGreenMenu, topMenuobj.MyDashBoard, topMenuobj.MyPoints };
                List<String> ListOfMenuNames = new List<String>() { "My BlueGreen", "My Dashboard", "My Points" };

                MyPointsPage myPointObj = new MyPointsPage(driver);

                // Assert.IsTrue((TestBaseClass.traverseMenu(ListOfMenuLocators, ListOfMenuobjects, ListOfMenuNames, driver, ConfigurationManager.AppSettings["UrlMyPointsPage"])), "The My Points Page  was not shown");

                Assert.IsTrue(IsElementPresentUsingBy(myPointObj.locatorforMyPointsPage,driver), "The My Points Page  was not shown");
                extentTest.Pass("The My Points Page  was shown", AttachScrenshot(driver, testContextInstance, "MyPointsPage").Build());

                //Code to check Column 4 has points to be save in Current Points table in MyDashBoard Page                                     
                
               
                Boolean SavePointsFlag = false;
                String AlreadySavedPoints = myPointObj.ValueSavedPoints.Text.Trim();
                AlreadySavedPoints = AlreadySavedPoints.ToLower();
                string[] stringarray = new string[10];
                stringarray = AlreadySavedPoints.Split(',');
                string newVal = "";
                for (int m = 0; m < stringarray.Length; m++)
                {
                    if (stringarray != null)
                        newVal = newVal + stringarray[m];

                }
                AlreadySavedPoints = newVal;
                AlreadySavedPoints = AlreadySavedPoints.Replace("\n", " ").Replace("\r", " ").Replace("points", " ");
                AlreadySavedPoints = AlreadySavedPoints.Trim();
                int existingSavedPoints = Convert.ToInt32(AlreadySavedPoints);

                int tobeSavedPoints = 0;
                Assert.IsTrue(TestBaseClass.isElementVisible(myPointObj.locatorforAPTTable, Constants.medLoadTime), "The Available Points Table was not shown in My Points Page ");
                extentTest.Pass("The Available Points Table was shown in My Points Page ", AttachScrenshot(driver,testContextInstance, "MyPointsTableShown").Build());

                IReadOnlyCollection<IWebElement> AllRows = myPointObj.APTTable.FindElements(By.TagName("tr"));

                Assert.IsTrue(AllRows.Count > 0, "No  rows were not shown in Available Points Table");

                ListPointsTypeColumn = driver.FindElements(myPointObj.locatorforAPTPointsType);
                ListAvailablePointsColumn = driver.FindElements(myPointObj.locatorforAPTAvailablePoints);
                ListExpDateColumn = driver.FindElements(myPointObj.locatorforAPTExpirationDate);
                ListActionColumn = driver.FindElements(myPointObj.locatorforAPTAction);
                IEnumerator enumerable2 = ListPointsTypeColumn.GetEnumerator();

                IEnumerator enumerable3 = ListAvailablePointsColumn.GetEnumerator();
                IEnumerator enumerable4 = ListExpDateColumn.GetEnumerator();
                IEnumerator enumerable5 = ListActionColumn.GetEnumerator();
                IWebElement ele2 = null;
                IWebElement ele3 = null;
                IWebElement ele4 = null;
                IWebElement ele5 = null;
                List<string> fieldName;
                List<By> locatorForField;
                for (int m = 0; m < ListAvailablePointsColumn.Count; m++)
                {
                    enumerable2.MoveNext();
                    enumerable3.MoveNext();
                    enumerable4.MoveNext();
                    enumerable5.MoveNext();

                    var pointsTypeEle = enumerable2.Current;
                    ele2 = (IWebElement)pointsTypeEle;

                    var availablepointsEle = enumerable3.Current;
                    ele3 = (IWebElement)availablepointsEle;
                    var expirationdateEle = enumerable4.Current;
                    ele4 = (IWebElement)expirationdateEle;

                    var actionsEle = enumerable5.Current;
                    ele5 = (IWebElement)actionsEle;

                    if (ele5.Text.Equals("not saved"))
                    {
                        SavePointsFlag = true;
                        totalOccurencesOfPointsTobeSaved = totalOccurencesOfPointsTobeSaved + 1;
                        PointsTypeValueList.Add(ele2.Text.Trim());

                        string[] stringarray2 = new string[10];
                        stringarray2 = ele3.Text.Split(',');
                        string newVal2 = "";
                        for (int k = 0; k < stringarray2.Length; k++)
                        {
                            if (stringarray2 != null)
                                newVal2 = newVal2 + stringarray2[k];

                        }
                        newVal2 = newVal2.Replace("\n", " ").Replace("\r", " ");
                        newVal2 = newVal2.Trim();

                        AvailablePointsValueList.Add(newVal2);
                        ExpirationDatesValueList.Add(ele4.Text.Trim());
                        ActionValueList.Add(ele5.Text.Trim());
                        tobeSavedPoints = tobeSavedPoints + Convert.ToInt32(newVal2);
                    }
                }

                totalOccurencesOfAllStatus = ListAvailablePointsColumn.Count;
                totalOccurencesOfPointsInOtherStatus = totalOccurencesOfAllStatus - totalOccurencesOfPointsTobeSaved;
                Assert.IsTrue(SavePointsFlag, "There are no points to be saved for this user");
                extentTest.Pass("There are points that need to be saved for this user", AttachScrenshot(driver, testContextInstance, "SaveMyPointsAlertMessageDisplayed").Build());

                // Save MY pOints Code-To pay cash and save points 
                SaveMyPointsPage saveObj = new SaveMyPointsPage(driver);

                HomePage homepageObj = new HomePage(driver);


                Assert.IsTrue((IsSingleELementVisible(saveObj.locatorforSavePointsAlert, driver))
                   && (IsSingleELementVisible(saveObj.locatorforSavePointsAlertButton, driver)), "The SavePoints alert was not shown as required");
                extentTest.Pass("The SavePoints alert was shown", AttachScrenshot(driver, testContextInstance, "SaveMyPointsAlertMessageShown").Build());

                //saveObj.SaveMyPointsAlertButton.Click();
                ////verify the saving fees amount displayed
                //Assert.IsTrue((IsElementVisible(saveObj.locatorForTotalPayment, driver)), "The fees for saving Points was not  displayed");
                //extentTest.Pass("The fees for saving Points was not  displayed ", AttachScrenshot(driver, testContextInstance, "SaveMyPointsAlertMessageShown").Build());

                //string bbb = saveObj.TotalPayment.Text;

                ////Enter Billing Info in Save pOints
               // Assert.IsTrue(TestBaseClass.EnterSavePointFormDetails(testContextInstance, saveObj), "The Credit card details were not succesfully entered in Save My Points Page");
                //extentTest.Pass("The Credit card details were succesfully entered in Save My Points Page", AttachScrenshot(driver, testContextInstance, "CreditCardDetailsSuccessfullyEntered").Build());

                //Assert.IsTrue(TestBaseClass.isElementVisible(saveObj.locatorforSavePointsConfirmationMsg, Constants.longLoadTime), "Success Message was  not displayed for Save Points");
                //extentTest.Pass("Success Message was  displayed after Saving Points", AttachScrenshot(driver, testContextInstance, "SuccessfulMessageDisplayed").Build());

                //Assert.IsTrue(TestBaseClass.isElementVisible(saveObj.locatorforSavePointsConfirmationNumber, Constants.longLoadTime), "Confirmation Number was not shown after Saving Points");
                //string confirmationnumber = saveObj.SavePointsConfirmationNumber.Text;

                //Assert.IsTrue(!((String.IsNullOrEmpty(confirmationnumber)) && (String.IsNullOrWhiteSpace(confirmationnumber))), "A valid confirmation Number was not displayed");
                //extentTest.Pass("Confirmation Number " + confirmationnumber + " was shown after Saving Points", AttachScrenshot(driver, testContextInstance, "ConfirmationNumberShown").Build());

                ////"A valid confirmation Number should be displayed ";

                //driver.Url = ConfigurationManager.AppSettings["UrlMyPointsPage"];
                //Assert.IsTrue(TestBaseClass.isElementVisible(myPointObj.locatorforAPTTable, Constants.medLoadTime), "Available Points Table should be shown in My Points Page");
                //AllRows = myPointObj.APTTable.FindElements(By.TagName("tr"));
                //Assert.IsTrue((AllRows.Count > 0), "No Rows were shown in Available points Table in Avaiable Points Table in My Points Page");

                //ListPointsTypeColumn = driver.FindElements(myPointObj.locatorforAPTPointsType);
                //ListAvailablePointsColumn = driver.FindElements(myPointObj.locatorforAPTAvailablePoints);
                //ListExpDateColumn = driver.FindElements(myPointObj.locatorforAPTExpirationDate);
                //ListActionColumn = driver.FindElements(myPointObj.locatorforAPTAction);
                //enumerable2 = ListPointsTypeColumn.GetEnumerator();
                //enumerable3 = ListAvailablePointsColumn.GetEnumerator();
                //enumerable4 = ListExpDateColumn.GetEnumerator();
                //enumerable5 = ListActionColumn.GetEnumerator();

                //IEnumerator enumerable11 = PointsTypeValueList.GetEnumerator();
                //IEnumerator enumerable12 = AvailablePointsValueList.GetEnumerator();
                //IEnumerator enumerable13 = ExpirationDatesValueList.GetEnumerator();
                //IEnumerator enumerable14 = ActionValueList.GetEnumerator(); ;
                //bool AllPointsSaved = false;
                //int matchingItems = 0;
                //enumerable2.Reset();
                //enumerable3.Reset();
                //enumerable4.Reset();
                //enumerable5.Reset();
                //for (int m = 0; m < ListActionColumn.Count; m++)
                //{
                //    enumerable2.MoveNext();
                //    enumerable3.MoveNext();
                //    enumerable4.MoveNext();
                //    enumerable5.MoveNext();

                //    var pointsTypeEle = enumerable2.Current;
                //    ele2 = (IWebElement)pointsTypeEle;

                //    var availablepointsEle = enumerable3.Current;
                //    ele3 = (IWebElement)availablepointsEle;


                //    var expirationdateEle = enumerable4.Current;
                //    ele4 = (IWebElement)expirationdateEle;

                //    var actionsEle = enumerable5.Current;
                //    ele5 = (IWebElement)actionsEle;

                //    AllPointsSaved = true;
                //    if (!(ele5.Text.Trim().Equals("not saved")))
                //    {
                //        string[] stringarray3 = new string[10];
                //        string newVal3 = "";
                //        enumerable11.Reset();
                //        enumerable12.Reset();
                //        enumerable13.Reset();
                //        enumerable14.Reset();
                //        for (int h = 0; h < PointsTypeValueList.Count; h++)
                //        {
                //            enumerable11.MoveNext();
                //            enumerable12.MoveNext();
                //            enumerable13.MoveNext();
                //            enumerable14.MoveNext();


                //            stringarray3 = ele3.Text.Split(',');
                //            //string newVal3 = "";
                //            for (int k = 0; k < stringarray3.Length; k++)
                //            {
                //                if (stringarray3 != null)
                //                    newVal3 = newVal3 + stringarray3[k];

                //            }
                //            newVal3 = newVal3.Replace("\n", " ").Replace("\r", " ");
                //            newVal3 = newVal3.Trim();

                //            if ((enumerable11.Current.Equals(ele2.Text)) && (enumerable12.Current.Equals(newVal3)) && (enumerable13.Current.Equals(ele4.Text)))
                //            {
                //                if ((ele5.Text.ToLower().Trim().Equals("will be saved")))
                //                {
                //                    matchingItems = matchingItems + 1;
                //                }
                //            }
                //        }
                //    }// there exists some points in not saved status again
                //    else
                //    {
                //        AllPointsSaved = false;
                //    }
                //}//for (int m = 0; m < ListActionColumn.Count; m++)
                //Assert.IsTrue(AllPointsSaved, "The points ready to be saved were not saved succesfully");
                //extentTest.Pass("The points ready to be saved were saved succesfully", AttachScrenshot(driver, testContextInstance, "PointsReadyToBeSaved").Build());

                LogOff(topMenuobj.locatorforMyBlueGreen, homepageObj.locatorForSignoutBtn, driver, ((int)Utilities.Timeout.LongwaitInSecond));
                extentTest.Info("Logged off from BGO");

            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    extentTest.Fail(exception.InnerException.ToString() + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.InnerException.ToString());
                }
                if (exception.Message != null)
                {
                    extentTest.Fail(exception.Message + "\r\n", AttachScrenshot(driver, testContextInstance, "Error").Build());
                    Assert.Fail(exception.Message);
                }
            }
           

        }
    }
}

