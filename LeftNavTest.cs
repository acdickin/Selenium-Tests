using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using UnitTest_CSM_Web;

namespace UnitTest_CSM_Web
{
    [TestClass]
    public class LeftNavTest
    {
        private BrowserConfig Conf;
        private BrowserOptions Options;
        private Controller Ctrl;
        private IWebDriver browserDriver;
        
        public TestContext TestContext { get; set; }
        [TestInitialize()]
        public void TopNavUnitTest_Initialize()
        {
            Conf = new BrowserConfig();
            Options = new BrowserOptions();
            browserDriver = Conf.InitalizeBrowser(Options.getChromeEnum());
            Ctrl = new Controller(browserDriver);
            Ctrl.Login();
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckAccountsLink()
        {
            Ctrl.ClickAccounts();
            Assert.AreEqual(Ctrl.GetPageTitle(), "Accounts");
        }
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckEngagementsLink()
        {
            Ctrl.ClickEngagements();
            Assert.AreEqual(Ctrl.GetPageTitle(), "Engagements");
        }
        /**** Not enough items in current menu for dropdown *****
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckDownArrowClick()
        { 
            Ctrl.ClickDownArrow();
            Assert.IsTrue(Ctrl.CheckUpArrowExists());
        }
        [TestMethod]
        [TestCategory("Selenium")]
        public void CheckMenuExpands()
        {
            Ctrl.ClickLeftNavExpandIcon();
            Assert.AreEqual(Ctrl.CheckLeftNavExpands(), "Expanded");
        }
        ***/

    [TestCleanup()]
        public void Cleanup()
        {
            browserDriver.Manage().Cookies.DeleteAllCookies();
            browserDriver.Quit();
        }
    }
   
}
