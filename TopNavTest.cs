using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using UnitTest_CSM_Web;

namespace UnitTest_CSM_Web
{
    [TestClass]
    public class TopNavTest
    {
        private BrowserConfig Conf;
        private BrowserOptions Options;
        private Controller Ctrl;
        private IWebDriver browserDriver;

        [TestInitialize()]
        public void Initialize()
        {
            Conf = new BrowserConfig();
            Options = new BrowserOptions();
            browserDriver = Conf.InitalizeBrowser(Options.getChromeEnum());
            Ctrl = new Controller(browserDriver);
            Ctrl.Login();
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckNotifications()
         {

            Ctrl.ClickNotifications();
            Assert.AreEqual(Ctrl.NotificationsBG(), "rgba(234, 234, 234, 1)");
         }
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckHelp()
        {
            Ctrl.ClickHelp();
            Assert.AreEqual(Ctrl.HelpBG(), "rgba(255, 255, 255, 1)");
        }
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckProfiles()
        {
            Ctrl.ClickProfiles();
            Assert.AreEqual(Ctrl.ProfilesBG(), "rgba(255, 255, 255, 1)");
        }
        [TestCleanup()]
        public void Cleanup()
        {
            browserDriver.Manage().Cookies.DeleteAllCookies();
            browserDriver.Quit();
        }
    }
   
}
