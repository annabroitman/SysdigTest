using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysdigTest.PageObject
{
    public class LoginPage : BaseClass
    {

        //Login section
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement login_Email { get; set; }


        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement login_Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "simple-btn--login")]
        private IWebElement loginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "login__error-display")]
        private IWebElement loginError { get; set; }

        //Forgot password
        [FindsBy(How = How.LinkText, Using = "Forgot your password?")]
        private IWebElement forgotPwd { get; set; }

        //Login with... section
        [FindsBy(How = How.LinkText, Using = "Google")]
        private IWebElement loginGoogle { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[.//img[contains(@class,'saml')]]")]
        private IWebElement loginSAML { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[.//img[contains(@class,'openid')]]")]
        private IWebElement loginOpenID { get; set; }

        //Sign up
        [FindsBy(How = How.PartialLinkText, Using = "Sign up")]

        private IWebElement signUp { get; set; }


        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
        }

        //Methods

       
        public bool verifyLoginEmailUI()
        {

            return login_Email.Displayed && login_Email.GetAttribute("placeholder").Equals("Enter your email address");
        }

        public bool verifyCursorLocation()
        {
            bool isCursorOnMail = login_Email.Equals(_driver.SwitchTo().ActiveElement());
            return isCursorOnMail;
        }
        public void enterEmail(string email)
        {

            login_Email.SendKeys(email);
        }


        public void enterPassword(string pwd)
        {
            login_Password.SendKeys(pwd);
        }

        public void clickLogin()
        {
            loginButton.Click();
        }


        public string getInvalidCredentialsText()
        {
            return loginError.Text;
        }
        public void clickForgotPwd()
        {
            forgotPwd.Click();

        }

        public void clickSignUp()
        {
            signUp.Click();

        }

        public void clickLoginGoogle()
        {
            loginGoogle.Click();

        }

        public void clickLoginSAML()
        {
            loginSAML.Click();

        }

        public void clickLoginOpenID()
        {
            loginOpenID.Click();

        }


        public bool hoverOverLoginIsPointer()
        {
            return loginButton.GetCssValue("cursor").Equals("pointer");


        }

        public bool hoverOverForgotIsPointer()
        {
            return loginButton.GetCssValue("cursor").Equals("pointer");


        }


        public string loginValidationMsgEmail()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            String validationMessage = (String)js.ExecuteScript("return arguments[0].validationMessage;", login_Email);

            return validationMessage;

        }

        public string loginValidationMsgPwd()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            String validationMessage = (String)js.ExecuteScript("return arguments[0].validationMessage;", login_Password);

            return validationMessage;

        }




    }
}