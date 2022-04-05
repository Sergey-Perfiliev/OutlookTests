using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.Entities;
using OutlookTests.WebObjects;

namespace OutlookTests.Tests
{
    [TestClass]
    public class AuthTest : BaseTest
    {
        [DataTestMethod, Priority(1), TestCategory("Auth")]
        [DataRow("testpostlook@outlook.com", "test_login")]
        public void Assert_CorrectEmailSignin_Matches(string email, string password)
        {
            var user = new User(email, password);

            // navigate to signin page
            new HomePage().GoToSigninPage();

            // singin into outlook account
            var AuthPage = new SigninPage();

            // sign in
            new SigninPage().Signin(user);

            var mainPage = new OutlookMainPage();
            var actual = mainPage.GetCurrentEmail();

            // get current email and match
            Assert.AreEqual(email, actual);
        }
    }
}
