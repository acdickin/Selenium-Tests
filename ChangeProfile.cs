using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UnitTest_CSM_Web;

namespace UnitTest_CSM_Web
{
    [TestClass]
    public class ChangeProfile
    {
        private BrowserConfig Conf;
        private Controller Ctrl;
        private BrowserOptions Options; 
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
        public void NavigateToWebsiteChrome()
        {
            Assert.AreEqual(Ctrl.GetPageTitle(), "Home");
        }
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckDefaultProfile()
        {
            Ctrl.wait();
            Ctrl.ClickProfiles();
            Assert.IsTrue(Ctrl.GetProfileName().Contains("Profile: Profile1"));
            
        }
        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyChangeProfile()
        {
            
            Ctrl.ClickProfiles();
            Ctrl.ClickCurrentProfile();
            Ctrl.ClickProfiles();
            Assert.IsTrue(Ctrl.GetProfileName().Contains("Profile: Profile2"));
            
        }
     
        [TestCleanup()]
        public void Cleanup()
        {
            browserDriver.Manage().Cookies.DeleteAllCookies();
            browserDriver.Quit();
        }
    }
}
