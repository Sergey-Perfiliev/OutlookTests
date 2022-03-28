using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OutlookTests.WebDriver;

namespace OutlookTests.WebObjects
{
    public class BaseElement : IWebElement
    {
        private IWebDriver _driver = Browser.GetDriver();
        protected string? _name;
        protected By _locator;
        protected IWebElement? _element;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return _driver.FindElement(_locator).Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                _element = Browser.GetDriver().FindElement(_locator);
            }
            catch (Exception)
            {

                throw;
            }
            return _element;
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(_locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public string TagName { get; }

        public string Text { get; }

        public bool Enabled { get; }

        public bool Selected { get; }

        public Point Location { get; }

        public Size Size { get; }

        public bool Displayed { get; }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Submit();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void JSClick()
        {
            WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetElement());
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            WaitForIsVisible();
            return Browser.GetDriver().FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
