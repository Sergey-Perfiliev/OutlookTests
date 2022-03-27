using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.Tests;
using OutlookTests.WebObjects;

namespace OutlookTests
{
    [TestClass]
    public class OutlookTest : BaseTest
    {
        private HomePage? _homePage;
        private SigninPage? _signinPage;
        private OutlookMainPage? _outlookMainPage;

        [TestMethod]
        public void Outlook_Signin_CreateMessage_Logout()
        {
            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin();

            // create new message
            _outlookMainPage = new OutlookMainPage();
            _outlookMainPage.CreateNewMessage();

            // signout
            _outlookMainPage.SignOut();
        }

        [TestMethod]
        public void Outlook_Signin_DiscardMessage()
        {
            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin();

            // send message
            _outlookMainPage = new OutlookMainPage();
            _outlookMainPage.DeleteMessage();

            // signout
            _outlookMainPage.SignOut();
        }
    }
}
