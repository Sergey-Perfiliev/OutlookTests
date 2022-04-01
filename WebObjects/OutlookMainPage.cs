using OpenQA.Selenium;
using System;
using System.Threading;

namespace OutlookTests.WebObjects
{
    public class OutlookMainPage : BasePage
    {
        private static readonly By OutlookPageLbl = By.Id("owaBranding_container");
        private static readonly string receiverMailAdressMessage = "testreceivelook@outlook.com";
        private static readonly string subjectMailMessage = "Selenium PageObject, Grid";
        private static readonly string textMailMessage = "Hi, this is my first MSTest project using PageObject.";

        public OutlookMainPage() : base(OutlookPageLbl, "Outlook Main Page") { }

        private readonly BaseElement _newMessageButton = new BaseElement(By.XPath("//div[contains(@class,'ms-OverflowSet-item')][2]//button"));
        private readonly BaseElement _receiverMailAdressMessageInput = new BaseElement(By.XPath("//div[@class='ms-SelectionZone' and @role='presentation']//input"));
        private readonly BaseElement _subjectMailMessageInput = new BaseElement(By.XPath("//div[@class='ms-TextField-wrapper']/div/input"));
        private readonly BaseElement _textMailMessageInput = new BaseElement(By.XPath("//div[contains(@id,'virtualEditScroller')]/div"));
        private readonly BaseElement _closemessageButton = new BaseElement(By.XPath("//div[@title='Selenium PageObject, Grid']/button"));

        private readonly BaseElement _draftsButton = new BaseElement(By.XPath("//div[@title='Drafts'][1]/.."));
        private readonly BaseElement _selectDraftToDeleteSpan =
            new BaseElement(By.XPath("//div[@aria-label='Message list']//div[@role='listbox']//span[text()='" + subjectMailMessage + "']"));
        private readonly BaseElement _discardMessageButton = new BaseElement(By.XPath("//div[@id='docking_InitVisiblePart_0']//button[@aria-label='Discard']"));
        private readonly BaseElement _acceptDiscardMessageButton = new BaseElement(By.XPath("//div[contains(@class, 'ms-Dialog-main')]//button[contains(@id,'ok')]"));

        private readonly BaseElement _messageToSend = new BaseElement(By.XPath("//div[@aria-label='Message list']//div[@role='listbox']/div/div/div[2]"));
        private readonly BaseElement _sendMessageButton = new BaseElement(By.XPath("//div[@id='docking_InitVisiblePart_0']//button[@aria-label='Send']"));

        private readonly BaseElement _profileIcon = new BaseElement(By.XPath("//button[contains(@id, 'MainLink_Me')]"));
        private readonly BaseElement _signoutButton = new BaseElement(By.XPath("//div[@class='mectrl_currentAccount']/a"));

        private readonly BaseElement _draftsCountSpan = new BaseElement(By.XPath("//div[@title='Drafts'][1]/../div/span[2]/span/span[1]"));

        public void CreateNewDraft()
        {
            _newMessageButton.Click();

            FillInput(_receiverMailAdressMessageInput, receiverMailAdressMessage);
            FillInput(_subjectMailMessageInput, subjectMailMessage);
            FillInput(_textMailMessageInput, textMailMessage);

            _closemessageButton.Click();
        }

        public void NavigateToDraftComponent()
        {
            _draftsButton.Click();
        }

        public int GetDraftsCount()
        {
            Thread.Sleep(1000); //FIX:USE IMPLICIT DRIVER WAIT
            return Convert.ToInt32(_draftsCountSpan.GetText());
        }
         
        public void DeleteMessage()
        {
            NavigateToDraftComponent();

            _selectDraftToDeleteSpan.Click();
            _discardMessageButton.Click();
            _acceptDiscardMessageButton.Click();
        }

        public void SendMessage()
        {
            _draftsButton.Click();
            _messageToSend.Click();

            FillInput(_receiverMailAdressMessageInput, receiverMailAdressMessage);
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
