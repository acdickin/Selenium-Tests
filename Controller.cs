using System;
using OpenQA.Selenium;
using UnitTest_CSM_Web;

namespace UnitTest_CSM_Web
{

    class Controller
    {

        public IWebElement Help;
        public IWebElement Profiles;
        public IWebElement ProfileName;
        public IWebElement Notifications;
        public IWebElement Settings;
        public IWebElement Engagements;
        public IWebElement Accounts;
        public IWebElement DownArrow;
        public IWebElement UpArrow;
        public IWebElement PageTitle;
        public IWebElement LeftNavExpandIcon;
        public IWebElement LeftNavExpands;
        public IWebDriver driver;


        public Controller(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void setHelp()
        {
            Help = FindXPath("Help");
        }
        public void setProfile()
        {
            Profiles = FindXPath("Profile and Settings");
        }
        public void setProfileName()
        {
            ProfileName = FindCss(".ms-ContextualMenu-link");
        }
        public void setNotifications()
        {
            Notifications = FindByName("Notifications");
        }
        
        public void setSettings()
        {
            Settings = FindXPath("Settings");
        }
        public void setEngagements()
        {
            Engagements = FindXPathDataIconName("FinancialSolid");
        }
        public void setAccounts()
        {
            Accounts = FindXPathDataIconName("CityNext");
        }
        public void setDownArrow()
        {
            DownArrow = FindXPathDataIconName("ChevronDown");
        }
        public void setUpArrow()
        {
            UpArrow = FindXPathDataIconName("ChevronUp");
        }
        public void setLeftNavExpandIcon()
        {
            LeftNavExpandIcon = FindXPathDataIconName("GlobalNavButton");
        }
        public void setLeftNavExpands()
        {
            LeftNavExpands = FindCss("#key");
        }
        public void setPageTitle()
        {
            PageTitle = FindCss("#id__1");
        }

        public void wait()
        {
            System.Threading.Thread.Sleep(5000);
        }
        public IWebElement FindXPath(string name)
        {
            return driver.FindElement(By.XPath("//button[contains(@name,'" + name + "')]"));
        }
        public IWebElement FindXPathDataIconName(string name)
        {
            return driver.FindElement(By.XPath("//i[contains(@data-icon-name,'" + name + "')]"));
        }
        public IWebElement FindCss(string name)
        {
            return driver.FindElement(By.CssSelector(name));
        }
        public IWebElement FindByName(string name)
        {
            return driver.FindElement(By.Name(name));
        }
        public void ClickHelp()
        {
            setHelp();
            Help.Click();
            wait();
        }
        public void ClickProfiles()
        {
            wait();
            setProfile();
            Profiles.Click();
            wait();
        }
        public void ClickCurrentProfile()
        {
            wait();
            setProfileName();
            ProfileName.Click();
            wait();
        }
        public void ClickNotifications()
        {
            wait();
            setNotifications();
            Notifications.Click();
            wait();
        }

        public void ClickSettings()
        {
            setSettings();
            Settings.Click();
            wait();
        }
        public void ClickEngagements()
        {
            wait();
            ClickLeftNavExpandIcon();
            setEngagements();
            Engagements.Click();
            wait();
        }
        public void ClickAccounts()
        {
            wait();
            ClickLeftNavExpandIcon();
            setAccounts();
            Accounts.Click();
            wait();
        }
        public void ClickDownArrow()
        {
            wait();
            setDownArrow();
            DownArrow.Click();
            wait();
        }
        public void ClickLeftNavExpandIcon()
        {
            wait();
            setLeftNavExpandIcon();
            LeftNavExpandIcon.Click();
            wait();
        }
        public string HelpBG()
        {
            return Help.GetCssValue("background-color");
        }
        public string ProfilesBG()
        {
            return Profiles.GetCssValue("background-color");
        }
        public string NotificationsBG()
        {
            return Notifications.GetCssValue("background-color");
        }
       
        public string GetPageTitle()
        {
            setPageTitle();
            return PageTitle.GetAttribute("innerText");
        }
        public string GetProfileName()
        {
            setProfileName();
            return ProfileName.GetAttribute("innerText");
        }
        public string GetProfile()
        {
            setProfile();
            return Profiles.GetAttribute("innerText");
        }

        public bool CheckUpArrowExists()
        {
            setUpArrow();
            return IsElementVisible(UpArrow);
        }
        public String CheckLeftNavExpands()
        {
            setLeftNavExpands();
            return LeftNavExpands.GetAttribute("aria-label");
        }
        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }
        public void Login()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(Initalizer.url);
            wait();
            Console.WriteLine(driver.Url);
            FindByName("loginfmt").SendKeys(Initalizer.user);
            FindCss("#idSIButton9").Click();
            FindCss(".normalText").Click();
            FindByName("Password").SendKeys(Initalizer.pass);
            FindCss("#submitButton").Click();
            FindCss("#idBtn_Back").Click();
        }
        public void TopNavUnitTest_Cleanup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }
    }
}
