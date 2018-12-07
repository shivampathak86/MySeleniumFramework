using OpenQA.Selenium;

using System;

using System.Linq;


namespace Utilities
{
   public   class AutoSuggestHelper:AlertHelper
    {


        public static void SelectFromAutoSuggest(IWebDriver driver,By autoSuggesLocator, By autoSuggestistLocator, string intitialStr, string strToSelect, int timeout=(int) Timeout.ShortwaitInSecond)
        {
            if (autoSuggesLocator == null) throw new ArgumentNullException(nameof(autoSuggesLocator));
            if (autoSuggestistLocator == null) throw new ArgumentNullException(nameof(autoSuggestistLocator));

            TextBoxHelper.TypeInTextBox(autoSuggesLocator, driver,intitialStr, timeout);

            var wait =GenericHelper.GetWebdriverWait(driver,timeout);

            var itemList = wait.Until(GenericHelper.GetElementsFunc(autoSuggestistLocator));

            var itemTobeSelected = itemList.First((x) => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase));

            itemTobeSelected.Click();

        }

        
    }
}
