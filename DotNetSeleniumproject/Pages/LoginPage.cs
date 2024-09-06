using OpenQA.Selenium;

namespace DotNetSeleniumproject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        IWebElement LoginLink => driver.FindElement(By.Id("loginlink"));
        IWebElement TxtUser => driver.FindElement(By.Id("username"));
        IWebElement TxtPass => driver.FindElement(By.Id("password"));
        IWebElement BtnLogin => driver.FindElement(By.Id(".btn"));

        public void ClickLogin()
        {
            LoginLink.Click();
        }
        public void Login(string username, string password)
        {
            //        TxtUser.EnterTextk(username);
            TxtPass.SendKeys(username);
            TxtPass.SendKeys(password);
            BtnLogin.Submit();
        }


    }
}
