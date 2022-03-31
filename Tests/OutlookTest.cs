using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.Tests;
using OutlookTests.WebObjects;
using System;

namespace OutlookTests
{
    [DeploymentItem(@"Resources")]
    [TestClass]
    public class OutlookTest : BaseTest
    {
        private HomePage? _homePage;
        private SigninPage? _signinPage;
        private OutlookMainPage? _outlookMainPage;

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv",
            "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Outlook_Signin_CreateMessage_Signout()
        {
            // get data from csv file
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();

            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin(email, password);

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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv",
            "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Outlook_Signin_DiscardMessage_Signout()
        {
            // get data from csv file
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();

            // navigate to signin page
            _homePage = new HomePage();
            _homePage.GoToSigninPage();

            // singin into outlook account
            _signinPage = new SigninPage();
            _signinPage.Signin(email, password);

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
