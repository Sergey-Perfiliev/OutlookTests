using OpenQA.Selenium;
using System;
using System.Threading;

namespace OutlookTests.WebObjects
{
    public class OutlookMainPage : BasePage
    {
        private static readonly By OutlookPageLbl = By.Id("owaBranding_container");

        public OutlookMainPage() : base(OutlookPageLbl, "Outlook Main Page") { }

        private readonly BaseElement _newMessageButton = new BaseElement(By.XPath("//div[contains(@class,'ms-OverflowSet-item')][2]//button"));
        private readonly BaseElement _receiverMailAdressMessageInput = new BaseElement(By.XPath("//div[@class='ms-SelectionZone' and @role='presentation']//input"));
        private readonly BaseElement _subjectMailMessageInput = new BaseElement(By.XPath("//div[@class='ms-TextField-wrapper']/div/input"));
        private readonly BaseElement _textMailMessageInput = new BaseElement(By.XPath("//div[contains(@id,'virtualEditScroller')]/div"));
        private BaseElement _closemessageButton;

        private readonly BaseElement _draftsButton = new BaseElement(By.XPath("//div[@title='Drafts'][1]/.."));
        private BaseElement _draftToDeleteSpan;
        private readonly BaseElement _discardMessageButton = new BaseElement(By.XPath("//div[@id='docking_InitVisiblePart_0']//button[@aria-label='Discard']"));
        private readonly BaseElement _acceptDiscardMessageButton = new BaseElement(By.XPath("//div[contains(@class, 'ms-Dialog-main')]//button[contains(@id,'ok')]"));

        private readonly BaseElement _messageToSend = new BaseElement(By.XPath("//div[@aria-label='Message list']//div[@role='listbox']/div/div/div[2]"));
        private readonly BaseElement _sendMessageButton = new BaseElement(By.XPath("//div[@id='docking_InitVisiblePart_0']//button[@aria-label='Send']"));

        private readonly BaseElement _profileIcon = new BaseElement(By.XPath("//button[contains(@id, 'MainLink_Me')]"));
        private readonly BaseElement _signoutButton = new BaseElement(By.XPath("//div[@class='mectrl_currentAccount']/a"));

        private readonly BaseElement _draftsCountSpan = new BaseElement(By.XPath("//div[@title='Drafts'][1]/../div/span[2]/span/span[1]"));

        public void CreateNewDraft(string messageReceiver, string messageSubject, string messageText)
        {
            _newMessageButton.Click();

            FillInput(_receiverMailAdressMessageInput, messageReceiver);
            FillInput(_subjectMailMessageInput, messageSubject);
            FillInput(_textMailMessageInput, messageText);

            CloseMessageButtonClick(messageSubject);
        }

        public void CloseMessageButtonClick(string messageSubject)
        {
            _closemessageButton = new BaseElement(By.XPath("//div[@title='" + messageSubject + "']/button"));
            _closemessageButton.Click();
        }

        public void NavigateToDraftComponent()
        {
            _draftsButton.Click();
        }

        public int GetDraftsCount()
        {
            Thread.Sleep(3000); //FIX:USE IMPLICIT DRIVER WAIT
            try
            {
                return Convert.ToInt32(_draftsCountSpan.GetText());
            }
            catch (FormatException)
            {
                return 0;
            }
        }
         
        public void DeleteMessage(string messageSubject)
        {
            NavigateToDraftComponent();

            GetDraftToDelete(messageSubject).Click();
            _discardMessageButton.Click();
            _acceptDiscardMessageButton.Click();
        }

        public BaseElement GetDraftToDelete(string messageSubject)
        {
            return _draftToDeleteSpan = new BaseElement(By.XPath("//div[@aria-label='Message list']//div[@role='listbox']//span[text()='" + messageSubject + "']"));
        }

        public void SendMessage(string messageReceiver)
        {
            _draftsButton.Click();
            _messageToSend.Click();

            FillInput(_receiverMailAdressMessageInput, messageReceiver);
            _messageToSend.Click();
            _sendMessageButton.Click();
        }

        public void SignOut()
        {
            _profileIcon.Click();
            _signoutButton.Click();
        }
    }
}
