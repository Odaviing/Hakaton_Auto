using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    public class BaseTestSettings : IDisposable
    {
        protected IWebDriver _driver;

        public IWebDriver StartDriverWithURL(string url)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
