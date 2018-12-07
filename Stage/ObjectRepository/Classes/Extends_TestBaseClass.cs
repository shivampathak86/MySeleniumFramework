using BlueGreenOwner;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace POM.Classes
{/// <summary>
/// This class extends TestBaseClass.
/// All the logic this will be needed to write for existing TestBaseClass will be written in this class.
/// </summary>
    public class Extends_TestBaseClass : TestBaseClass
    {

        public static void ClickUsingJavaScript(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = ((IJavaScriptExecutor)baseDriver);
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }



        public static object ExecuteScript(string script, IWebDriver baseDriver)
        {
            if (script == null) throw new ArgumentNullException(nameof(script));

            if (baseDriver == null) throw new ArgumentNullException(nameof(baseDriver));

            var executor = (IJavaScriptExecutor)baseDriver;
            return executor.ExecuteScript(script);
        }

        public static void ScrollTo(string X, string Y, IWebDriver baseDriver)
        {
            if (X == null) throw new ArgumentNullException(nameof(X));
            if (Y == null) throw new ArgumentNullException(nameof(Y));
            if (baseDriver == null) throw new ArgumentNullException(nameof(baseDriver));
            ExecuteScript("window.scrollTo(" + X + "," + Y + ")", baseDriver);

        }

       
        public static string MeneuLevel(List<IWebElement> listofMenuobjects, IWebDriver baseDriver, int timeout = (int)Timeout.ShortwaitInSecond)
        {
            var act = new Actions(baseDriver);
            act.MoveToElement(listofMenuobjects[0]).Perform();
            act.MoveToElement(listofMenuobjects[1]).Click().Build().Perform();
            return baseDriver.Url;
        }

       public static WebDriverWait ExplicitWait(By Locator, int timeout=0)
        {
            WebDriverWait wait = new WebDriverWait(baseDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(Locator));
            return wait;
        }

    }
}
