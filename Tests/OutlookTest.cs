using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.Tests;
using OutlookTests.WebObjects;
using System;

namespace OutlookTests
{
    [TestClass]
    public class OutlookTest : BaseTest
    {
        private HomePage? _homePage;
        private SigninPage? _signinPage;
        private OutlookMainPage? _outlookMainPage;

        [TestMethod]
        public void Outlook_Signin_CreateMessage_Signout()
        {
            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin();

            // create new draft
            _outlookMainPage = new OutlookMainPage();

            //expected value
            int draftsCount = _outlookMainPage.GetDraftsCount() + 1;

            _outlookMainPage.CreateNewDraft();

            // assert
            Assert.AreEqual(draftsCount, _outlookMainPage.GetDraftsCount());

            // signout
            _outlookMainPage.SignOut();
        }

        [TestMethod]
        public void Outlook_Signin_DiscardMessage_Signout()
        {
            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin();

            // discard message
            _outlookMainPage = new OutlookMainPage();

            //expected value
            int draftsCount = _outlookMainPage.GetDraftsCount() - 1;

            _outlookMainPage.DeleteMessage();

            // assert
            Assert.AreEqual(draftsCount, _outlookMainPage.GetDraftsCount());

            // signout
            _outlookMainPage.SignOut();
        }
    }
}
