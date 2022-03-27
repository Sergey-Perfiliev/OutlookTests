using OpenQA.Selenium;

namespace OutlookTests.WebObjects
{
    public class BasePage
    {
        protected By _titleLocator;
        protected string _title;
        public static string _titleForm;

        protected BasePage(By TitleLocator, string title)
        {
            _titleLocator = TitleLocator;
            _title = _titleForm = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(_titleLocator, _title);
            label.WaitForIsVisible();
        }
    }
}
