using System.Configuration;

namespace OutlookTests.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "10");

        public static string Browser => GetEnvironmentVar("Browser", "Chrome");

        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://outlook.live.com/owa/");
    }
}
