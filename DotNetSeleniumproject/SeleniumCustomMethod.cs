using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSeleniumproject
{
    public static class SeleniumCustomMethod
    {
        //1. Method should get the locator
        //2. Start getting the type of identifier
        //3. Perform operation on the locator

        public static void Click(this IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterTextk(this IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void SelectDropDownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public static void MultiSelectElements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiselect = new SelectElement(driver.FindElement(locator));
            foreach (var value in values)
            {
                multiselect.SelectByValue((string)value);
            }
        }

        public static List<string> GetAllSelectedLsits(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            SelectElement multiselect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selectedoption = multiselect.AllSelectedOptions;                        // selecting multiple values in the drop down
            foreach (IWebElement option in selectedoption)
            {
                options.Add(option.Text);
            }
            return options;


        }
    }

}
}
