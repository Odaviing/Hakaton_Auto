using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    class SendingConfirmation : BaseTestSettings
    {
        public SendingConfirmation()
        {
            _driver = DriverHolder.chrome;
        }

        private By _incomingsLink = By.XPath("//div[2]/div[2]/div[3]/ul/li/a");
        private By _confirmationMessage = By.XPath("//div[@class='content clear']");

        public void IncomingsClick()
        {
            DriverHolder.chrome.FindElement(_incomingsLink).Click();
        }

        public string ConfirmationText()
        {
            return DriverHolder.chrome.FindElement(_confirmationMessage).Text;
        }
    }
}
