using OpenQA.Selenium;

namespace OutlookTests.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By HomeLbl = By.ClassName("product-name");

        public HomePage() : base(HomeLbl, "Home Page") { }

        private readonly BaseElement _signinButton = new BaseElement(By.XPath("//nav[@class='auxiliary-actions']//a[@data-task='signin']"));

        public void GoToSigninPage()
        {
            _signinButton.Click();
        }
    }
}
