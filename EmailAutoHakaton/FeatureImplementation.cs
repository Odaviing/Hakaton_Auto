using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using EmailAutoHakaton;


namespace EmailAutoHakaton
{
    [Binding]
    public class FeatureImplementation : BaseTestSettings
    {
        private Homepage _homepage;
        private IncomingMessages _incomMess;
        private LetterContent _letterContent;
        private SendingConfirmation _sendConf;
        private SendLetter _sendLetter;

        [Given(@"user is on the homepage")]
        public void GivenUserIsOnTheHomepage()
        {
            DriverHolder.chrome = StartDriverWithURL("https://www.i.ua/?_rand=1644672157");
            _homepage = new Homepage();
        }
        
        [When(@"user enters ""(.*)"" into Login field")]
        public void WhenUserEntersIntoLoginField(string p0)
        {
            _homepage.EnterLogin(p0);
        }
        
        [When(@"user enters ""(.*)"" into Password field")]
        public void WhenUserEntersIntoPasswordField(string p0)
        {
            _homepage.EnterPassword(p0);
        }
        
        [When(@"user clicks on Sign in button")]
        public void WhenUserClicksOnSignInButton()
        {
            _homepage.LoginButtonClick();
            _incomMess = new IncomingMessages();
        }
        
        [When(@"user clicks on the Create letter link")]
        public void WhenUserClicksOnTheCreateLetterLink()
        {
            _incomMess.CreateLetterLinkClick();
            _sendLetter = new SendLetter();
        }
        
        [When(@"user enters ""(.*)"" into Recipient field")]
        public void WhenUserEntersIntoToWhomField(string p0)
        {
            _sendLetter.EnterRecipient(p0);
        }
        
        [When(@"user enters '(.*)' into Subject field")]
        public void WhenUserEntersTestIntoThemeField(string p0)
        {
            _sendLetter.EnterSubject(p0);
        }
        
        [When(@"user enters '(.*)' into content textbox")]
        public void WhenUserEntersIntoContentTextbox(string p0)
        {
            _sendLetter.EnterContent(p0);
        }
        
        [When(@"user clicks Send button")]
        public void WhenUserClicksSenButton()
        {
            _sendLetter.SendClick();
            _sendConf = new SendingConfirmation();
        }
        
        [When(@"user clicks on the Letters link")]
        public void WhenUserClicksOnTheLettersLink()
        {
            _sendConf.IncomingsClick();
            _incomMess = new IncomingMessages();
        }
        
        [When(@"user clicks on the letter")]
        public void WhenUserClicksOnTheLetter()
        {
            _incomMess.LetterClick();
            _letterContent = new LetterContent();
        }
        
        [Then(@"user is on the Incoming letters page")]
        public void ThenUserIsOnTheIncomingLettersPage()
        {
            Assert.Equal("Odaviing@i.ua", _incomMess.GetAccountName());
        }
        
        [Then(@"user is on the letter creation page")]
        public void ThenUserIsOnTheLetterCreationPage()
        {
            Assert.Equal("Отправить", _sendLetter.GetSendButtonText());
        }
        
        [Then(@"user on the sending confirmation page")]
        public void ThenUserOnTheSendingConfirmationPage()
        {
            Assert.Equal("Письмо успешно отправлено адресатам", _sendConf.ConfirmationText());
        }
        
        [Then(@"user sees the new letter")]
        public void ThenUserSeesTheNewLetter()
        {
            Assert.True(_incomMess.CheckIcon());
        }
        
        [Then(@"user is on the page with the letter's content")]
        public void ThenUserIsOnThePageWithTheLetterSContent()
        {
            Assert.Equal("↑предыдущее", _letterContent.GetPreviousLinkText());
        }
        
        [Then(@"user sees the text in the letter")]
        public void ThenUserSeesTheTextInTheLetter()
        {
            Assert.Equal("123", _letterContent.GetLetterText().Substring(0,3));
        }
    }
}
