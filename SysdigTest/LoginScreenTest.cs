using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SysdigTest.PageObject;

namespace SysdigTest
{
    [TestClass]
    public class LoginScreenTest : BaseClass
    {

        [TestMethod]
        /// <summary>
        /// Verify Login page UI:
        /// Page URL, Cursor default location, Email field presence and placeholder, 
        /// Cursor shape when hovering over Login button and Forgot password link
        /// TODO: verify Password field presence and placeholder, other fields/elements presence (including Logo, etc),
        /// cursor shape for other clickable items, design of items
        /// </summary>

        public void VerifyLoginPageUI()
        {
            Assert.AreEqual(driver.Url, baseURL + "/#/login", "error: incorrect login page URL");
            Assert.IsTrue(loginp.verifyCursorLocation(), "error: Incorrect default cursor location");
            Assert.IsTrue(loginp.verifyLoginEmailUI(), "error: Login page email field is not displayed or has incorrect placeholder");
            Assert.IsTrue(loginp.hoverOverLoginIsPointer(), "error: Incorrect cursor shape when hovering over Login button");
            Assert.IsTrue(loginp.hoverOverForgotIsPointer(), "error: Incorrect cursor shape when hovering over Forgot password link");
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow("", "invalid")]
        [DataRow("", "valid")]
        [DataRow("invalid", "")]
        [DataRow("invalid", "invalid")]
        [DataRow("invalid", "valid")]
        [DataRow("invalid@", "")]
        [DataRow("invalid@", "invalid")]
        [DataRow("invalid@", "valid")]
        [DataRow("invalid@mail.com", "invalid")]
        [DataRow("invalid@mail.com", "valid")]
        /// <summary>
        /// Verify invalid login scenarios - invalid email:
        /// Combinations of empty email with different password values
        /// Combinations of email without @ with different password values
        /// Combinations of email with nothing after @ with different password values
        /// Combinations of valid but non-existing email with different password values
        /// </summary>
        public void VerifyInvalidLoginMail(string email, string pwd)
        {

            loginp.enterEmail(email);
            loginp.enterPassword(pwd);
            loginp.clickLogin();
            switch (email)
            {
                case "":
                    string errorMsgEmpty = loginp.loginValidationMsgEmail();
                    //Note: the error message in this case is browser-dependent, currently it's for Chrome 
                    Assert.IsTrue(errorMsgEmpty.Contains("Please fill out this field"), "Incorrect error message for empty login");
                    break;
                case "invalid":
                    string errorMsgInvMail = loginp.loginValidationMsgEmail();
                    //Note: the error message in this case is browser-dependent, currently it's for Chrome 
                    Assert.IsTrue(errorMsgInvMail.Contains("Please include an \'@\' in the email address"), "Incorrect error message for email without @");
                    break;
                case "invalid@":
                    string errorMsgInvMail2 = loginp.loginValidationMsgEmail();
                    //Note: the error message in this case is browser-dependent, currently it's for Chrome 
                    Assert.IsTrue(errorMsgInvMail2.Contains("Please enter a part following \'@\'"), "Incorrect error message for invalid email format");
                    break;
                default:
                    // Legal but non-registered email 
                    Assert.AreEqual(loginp.getInvalidCredentialsText(), "Credentials are not valid", "error: Error message for invalid credentails is incorrect");
                    break;

            }
        }


        [TestMethod]
        [DataRow("invalid@mail.com", "")]
        [DataRow("valid@mail.com", "")]
        [DataRow("valid@mail.com", "invalid")]

        /// <summary>
        /// Verify invalid login scenarios - invalid password:
        /// Combinations of empty password with different legal email values
        /// Valid email with invalid password
        /// </summary>
        public void VerifyInvalidLoginPwd(string email, string pwd)
        {

            loginp.enterEmail(email);
            loginp.enterPassword(pwd);
            loginp.clickLogin();
            switch (pwd)
            {
                case "":
                    string errorMsgEmpty = loginp.loginValidationMsgPwd();
                    //Note: the error message in this case is browser-dependent, currently it's for Chrome 
                    Assert.IsTrue(errorMsgEmpty.Contains("Please fill out this field"), "Incorrect error message for empty password");
                    break;


                default:
                    // Incorrect password provided
                    Assert.AreEqual(loginp.getInvalidCredentialsText(), "Credentials are not valid", "error: Error message for invalid credentails is incorrect");
                    break;

            }



        }

        // TODO - add valid login tests (when valid credentails are provided)

        [TestMethod]
        /// <summary>
        /// Verify 'Forgot you password?' link functionality:
        /// Verify URL of the page that opens when clicking on the link
        /// </summary>
        public void VerifyForgotPwdLink()
        {

            loginp.clickForgotPwd();
            WaitForElementLoadByClass("login_wrapper");
            string actualURL = driver.Url;
            string expectedURL = baseURL + "/#/forgotPassword";
            Assert.AreEqual(actualURL, expectedURL, "error: unexpected URL for clicking on Forgot password link");
            //TODO - verify entered mail is copied to the opened page

        }


        [TestMethod]
        /// <summary>
        /// Verify 'Login with Google' functionality:
        /// Verify URL of the page that opens when clicking on Google
        /// </summary>
        public void VerifyLoginWithGoogle()
        {

            loginp.clickLoginGoogle();
            string actualURL = driver.Url;
            Assert.IsTrue(actualURL.StartsWith("https://accounts.google.com/"), "error: Incorrect redirection to Google accounts");


        }

        [TestMethod]
        /// <summary>
        /// Verify 'Login with SAML' functionality:
        /// Verify URL of the page that opens when clicking on SAML
        /// </summary>
        public void VerifyLoginWithSAML()
        {

            loginp.clickLoginSAML();
            string actualURL = driver.Url;
            string expectedURL = baseURL + "/#/samlAuthentication";
            Assert.AreEqual(actualURL, expectedURL, "error: Incorrect redirection to SAML");



        }

        [TestMethod]
        /// <summary>
        /// Verify 'Login with OpenID' functionality:
        /// Verify URL of the page that opens when clicking on OpenID
        /// </summary>
        public void VerifyLoginWithOpenID()
        {

            loginp.clickLoginOpenID();
            string actualURL = driver.Url;
            string expectedURL = baseURL + "/#/openIdAuthentication";
            Assert.AreEqual(actualURL, expectedURL, "error: Incorrect redirection to OpenID");


        }

        [TestMethod]
        /// <summary>
        /// Verify 'Sign up for a free trial!' link functionality:
        /// Verify URL of the page that opens when clicking on the link
        public void VerifySignUpLink()
        {


            loginp.clickSignUp();
            WaitForElementLoadByClass("my-8");
            string actualURL = driver.Url;
            string expectedURL = "https://sysdig.com/company/start-free/";
            Assert.AreEqual(actualURL, expectedURL, "error: unexpected URL for clicking on Sign up link");

        }

    }
}