using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    class IncomingMessages: BaseTestSettings
    {
        public IncomingMessages()
        {
            _driver = DriverHolder.chrome;
        }

        private By _accountName = By.XPath("//span[contains(.,'Odaviing@i.ua')]");
        private By _createLetter = By.LinkText("Создать письмо");
        private By _letterLink = By.XPath("//span[3]/span");
        private By _unreadIcon = By.XPath("(//i[@onclick='I_Mbox.ctrlMarkRead(this);'])[2]");

        public string GetAccountName()
        {
            return DriverHolder.chrome.FindElement(_accountName).Text;
        }

        public void CreateLetterLinkClick()
        {
            DriverHolder.chrome.FindElement(_createLetter).Click();
        }

        public void LetterClick()
        {
            DriverHolder.chrome.FindElement(_letterLink).Click();
        }

        public bool CheckIcon()
        {
            return DriverHolder.chrome.FindElements(_unreadIcon).Count != 0;
        }
    }
    
}
