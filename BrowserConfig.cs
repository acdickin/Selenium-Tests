using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace UnitTest_CSM_Web
{
    class BrowserConfig
    {
        
        public IWebDriver driver;
        public IWebDriver InitalizePhantomDriver()
        {
            var driver = new PhantomJSDriver();
            return driver;
        }

        public IWebDriver InitalizeChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument(@"--incognito");
            driver = new ChromeDriver(options);
            return driver;
        }

        public IWebDriver InitalizeBrowser(Enum Browser)
        {
            switch (Browser)
            {
                case BrowserOptions.browserOptions.Phantom:
                    return InitalizePhantomDriver();
                default:
                    return InitalizeChromeDriver();
            }
        }
       
    }
}
