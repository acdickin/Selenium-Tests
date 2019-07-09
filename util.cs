using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace UnitTest_CSM_Web.util
{
    class init
    {
        private RemoteWebDriver browserDriver;
        private string websiteURL = @"https://###Website###​​​​​​​ ";
        private string user = "User";
        public void initalizeChrome()
        {
            var caps = DesiredCapabilities.Chrome();
            var options = new ChromeOptions();

            options.AddArgument(@"--incognito");
            caps.SetCapability(ChromeOptions.Capability, options);
            browserDriver = new ChromeDriver(options);
            browserDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(160));
            browserDriver.Navigate().GoToUrl(this.websiteURL);
            browserDriver.FindElement(By.Name("loginfmt")).SendKeys(user);
            browserDriver.FindElement(By.Id("idSIButton9")).Click();
            System.Threading.Thread.Sleep(3000);
        }
        
    }
}
