using OpenQA.Selenium;
using OutlookTests.Entities;
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

        public SigninPage() : base(SigninLbl, "Signin Page") { }

        private readonly BaseElement _signinEmailInput = new BaseElement(By.XPath("//input[@type='email']"));
        private readonly BaseElement _signinPasswordInput = new BaseElement(By.XPath("//input[@type='password']"));
        private readonly BaseElement _submitButton = new BaseElement(By.XPath("//input[@type='submit']"));
        private readonly BaseElement _backButton = new BaseElement(By.Id("idBtn_Back"));

        public void ClickSubmitButton() => _submitButton.Click();
        public void ClickBackButton() => _backButton.Click();
        
        public void Signin(User user)
        {
            var email = user.DataUser[0];
            var password = user.DataUser[1];

            FillInput(_signinEmailInput, email);
            ClickSubmitButton();

            FillInput(_signinPasswordInput, password);
            ClickSubmitButton();

            ClickBackButton();
        }
    }
}
