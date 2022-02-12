using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailAutoHakaton
{
    class SendLetter : BaseTestSettings
    {
        public SendLetter()
        {
            _driver = DriverHolder.chrome;
        }

        private By _toWhomField = By.Id("to");
        private By _subjectField = By.Name("subject");
        private By _contentTextBox = By.Id("text");
        private By _sendButton = By.Name("send");

        public void EnterRecipient(string email)
        {
            DriverHolder.chrome.FindElement(_toWhomField).SendKeys(email);
        }

        public void EnterSubject(string subj)
        {
            DriverHolder.chrome.FindElement(_subjectField).SendKeys(subj);
        }

        public void EnterContent(string text)
        {
            DriverHolder.chrome.FindElement(_contentTextBox).SendKeys(text);
        }

        public void SendClick()
        {
            DriverHolder.chrome.FindElement(_sendButton).Click();
        }

        public string GetSendButtonText()
        {
            return DriverHolder.chrome.FindElement(_sendButton).GetAttribute("value");
        }
    }
}
