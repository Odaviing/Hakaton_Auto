using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    class Homepage : BaseTestSettings
    {
        public Homepage()
        {
            _driver = DriverHolder.chrome;
        }

        private By _loginField = By.Name("login");
        private By _passwordField = By.Name("pass");
        private By _loginButton = By.XPath("//input[@value='Войти']");

        public void EnterLogin(string login)
        {
            DriverHolder.chrome.FindElement(_loginField).SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            DriverHolder.chrome.FindElement(_passwordField).SendKeys(password);
        }

        public void LoginButtonClick()
        {
            DriverHolder.chrome.FindElement(_loginButton).Click();
        }
    }
}
