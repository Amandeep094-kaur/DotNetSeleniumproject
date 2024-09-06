using DotNetSeleniumproject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotNetSeleniumproject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*    [Test]
            public void Test1()
            {

                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.linkedin.com/feed/");
                driver.Manage().Window.Maximize();
                IWebElement webElement = driver.FindElement(By.Id("username"));
                webElement.SendKeys("amancheema094@gmail.com");
                webElement.SendKeys(Keys.Return);

            }*/
        [Test]
        public void Locators()
        {
            IWebDriver driver = new ChromeDriver();                                    // create a new instance of selenium web driver
            driver.Navigate().GoToUrl("https://www.linkedin.com/feed/");               // navigate to URL
            driver.Manage().Window.Maximize();                                         // maximize the window
                                                                                       //     IWebElement username = driver.FindElement(By.Name("session_key"));
            SeleniumCustomMethod.Click(driver, By.Name("session_key"));
            SeleniumCustomMethod.EnterTextk(driver, By.Name("session_key"), "amancheema094@gmail.com");  //find the username and sending the text

                                                                                                         //      username.SendKeys("amancheema094@gmail.com");                             // sending the text
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("cheema@12");
            IWebElement signin = driver.FindElement(By.XPath("//button[@class = 'btn__primary--large from__button--floating']"));
            signin.Click();
            driver.Close();

        }

        [Test]
        public void AdvancedControls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:7080/drag_and_drop");
            driver.Manage().Window.Maximize();
            SelectElement selectelement = new SelectElement(driver.FindElement(By.Id("dropdown")));    // creating object of selectelement class
            selectelement.SelectByText("option 1");                                                    // selecting the drop down value using bytext method
            SeleniumCustomMethod.SelectDropDownByText(driver, By.Id("dropdown"), "option 1");
            SelectElement multiselect = new SelectElement(driver.FindElement(By.Id("dropdown")));
            multiselect.SelectByValue("option 1");

            SeleniumCustomMethod.MultiSelectElements(driver, By.Id("dropdwon"), ["option 1", "option 2"]);   // using custom emthod

            IList<IWebElement> selectedoption = multiselect.AllSelectedOptions;                        // selecting multiple values in the drop down
            foreach (IWebElement option in selectedoption)
            {
                Console.WriteLine(option.Text);
            }
            SeleniumCustomMethod.Click(driver, By.Id("Input"));                                        // calling the custom method

            List<string> getSelectoptions = SeleniumCustomMethod.GetAllSelectedLsits(driver, By.Id("multiselect"));   // calling custom method
            foreach (string selectoption in getSelectoptions)
            {
                Console.WriteLine(selectoption);
            }
            driver.Close();

        }

        [Test]
        public void TestWithPOM()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:7080/drag_and_drop");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.ClickLogin();
            loginpage.Login("admin", "password");
        }
    }
}