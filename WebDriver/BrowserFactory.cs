using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OutlookTests.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("start-maximized");
                        driver = new ChromeDriver(options);
                        break;
                    }

                case BrowserType.Firefox:
                    {
                        driver = new FirefoxDriver();
                        break;
                    }

                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;
        }
    }
}
