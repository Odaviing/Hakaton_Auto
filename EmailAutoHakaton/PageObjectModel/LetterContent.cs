using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    class LetterContent : BaseTestSettings
    {
        public LetterContent()
        {
            _driver = DriverHolder.chrome;
        }

        private By _previousLink = By.XPath("//span[contains(.,'↑предыдущее')]");
        private By _letterSubject = By.XPath("//h3");
        private By _letterText = By.XPath("//div[3]/pre");

        public string GetPreviousLinkText()
        {
            return DriverHolder.chrome.FindElement(_previousLink).Text;
        }

        public string GetLetterSubject()
        {
            return DriverHolder.chrome.FindElement(_letterSubject).Text;
        }

        public string GetLetterText()
        {
            return DriverHolder.chrome.FindElement(_letterText).Text;
        }
    }
}
