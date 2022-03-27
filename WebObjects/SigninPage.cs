using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookTests.WebObjects
{
    public class SigninPage : BasePage
    {
        private static readonly By SigninLbl = By.Id("loginHeader");
        private string email = "testpostlook@outlook.com";
        private string password = "test_login";

        public SigninPage() : base(SigninLbl, "Signin Page") { }

        private readonly BaseElement _signinEmailInput = new BaseElement(By.XPath("//input[@type='email']"));
        private readonly BaseElement _signinPasswordInput = new BaseElement(By.XPath("//input[@type='password']"));
        private readonly BaseElement _submitButton = new BaseElement(By.XPath("//input[@type='submit']"));
        private readonly BaseElement _backButton = new BaseElement(By.Id("idBtn_Back"));

        public void Signin()
        {
            _signinEmailInput.SendKeys(email);
            _submitButton.Click();

            _signinPasswordInput.SendKeys(password);
            _submitButton.Click();

            _backButton.Click();
        }
    }
}
