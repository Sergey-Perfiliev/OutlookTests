using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.Entities;
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Resources\\TestData.csv",
            "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Assert_CreateDraft_Created()
        {
            // get data from csv file
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();

            var user = new User(email, password);

            var messageReceiver = TestContext.DataRow["messageReceiver"].ToString();
            var messageSubject = TestContext.DataRow["messageSubject"].ToString();
            var messageText = TestContext.DataRow["messageText"].ToString();

            //expected value
            int draftsCount = TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow) + 1;

            // navigate to signin page
            new HomePage().GoToSigninPage();

            // singin into outlook account
            new SigninPage().Signin(user);

            // create new draft
            _outlookMainPage = new OutlookMainPage();
            _outlookMainPage.CreateNewDraft(messageReceiver, messageSubject, messageText);

            // assert
            Assert.AreEqual(draftsCount, _outlookMainPage.GetDraftsCount());

            // signout
            _outlookMainPage.SignOut();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Resources\\TestData.csv",
            "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Assert_DeleteDraft_Deleted()
        {
            // get data from csv file
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();

            var user = new User(email, password);

            var messageSubject = TestContext.DataRow["messageSubject"].ToString();

            // navigate to signin page
            new HomePage().GoToSigninPage();

            // singin into outlook account
            new SigninPage().Signin(user);

            // discard message
            _outlookMainPage = new OutlookMainPage();

            //expected value
            int draftsCount = _outlookMainPage.GetDraftsCount() - 1;

            _outlookMainPage.DeleteMessage(messageSubject);

            // assert
            Assert.AreEqual(draftsCount, _outlookMainPage.GetDraftsCount());

            // signout
            _outlookMainPage.SignOut();
        }
    }
}
