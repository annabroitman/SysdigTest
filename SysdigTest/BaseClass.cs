using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysdigTest.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SysdigTest
{
    public class BaseClass
    {
        public IWebDriver driver;
        public LoginPage loginp;
        public string baseURL = "https://app.sysdigcloud.com";

        [TestInitialize]

        public void Initialize()
        {
            driver = new Driver().NewChromeDriver();

            driver.Url = baseURL;
            driver.Manage().Window.Maximize();
            loginp = new LoginPage(driver);
            WaitForElementLoadByClass("login_wrapper");
        }

        [TestCleanup]
        public void CleanUp()
        {
              driver.Quit();
        }

        public void WaitForElementLoadByClass(string classname)
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            w.Until(ExpectedConditions.ElementExists(By.ClassName(classname)));
        }

       
    }
}
