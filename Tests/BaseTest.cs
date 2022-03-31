using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlookTests.WebDriver;

namespace OutlookTests.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        public TestContext? TestContext { get; set; }

        [TestInitialize]
        public void TestSetup()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
