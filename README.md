**Test Plan:** 

*This test plan describes the tests to be executed on Sysdig Login screen.*

1. Verify that the login screen contains elements such as logo, Email, Password, Log in button, Forgot password link, alternative sign in options (Google, SAML and OpenID) and Sign up link.
1. Verify that Email and Password input fields have a valid placeholder
1. Verify that the cursor is in Email field when login page opens
1. Verify cursor shape change when hovering over clickable page elements (links, buttons, etc.)
1. Verify successful login after providing valid credentials:
   1. By clicking on Login button
   1. By pressing Enter
1. Verify invalid login scenarios – relevant error should be displayed:
   1. Empty email / password / both
   1. Invalid email (both invalid format and non-registered email) / password / both
   1. Case-sensitivity – password should be case sensitive
1. Verify that the user is redirected to the Forgot password page when clicking on the Forgot password link and that if e-mail was entered on the Login screen, it is copied
1. Verify that the user is redirected to relevant page when clicking on the Sign up link
1. Verify all possible login methods (Log in with):
   1. Verify relevant page opens
   1. Verify successful login
   1. Verify unsuccessful login (invalid details provided)

**Additional tests:**

Authentication / Security:

1. Verify entered password is masked
1. Verify password cannot be copy-pasted
1. Verify page that opens after successful login is according to logged in user’s role
1. Verify sign out after successful login
1. Verify invalid sign in attempts limit
1. Verify that the user is not able to login with inactive credentials
1. Verify password expiry
1. Verify it’s impossible to log in to the account using an old password
1. Verify passwords are stored encrypted
1. Security breach – verify unauthorized access via direct link is not allowed
1. SQL injection, Cross-site scripting - javascript to execute alert pop-up in manually entered field

**Session:**

1. Cookies are deleted when expired or when cache is cleared
1. Login credentials are requested after deletion of cookies
1. Session expiry
1. Verify that closing the browser should not log-out an authenticated user

**Performance – monitor CPU, memory, disk space:**

1. Response time at different connection speeds
1. Load – normal and peak (many concurrent users)

**Usability**

Accessibility:

1. Tab navigation
1. Screen reader

Other tests (missing requirements):

1. Verify allowed length of input fields
1. Verify Region drop-down functionality and values
1. Verify on all supported browsers
1. Mobile / tablet (including horizontal and vertical modes)

**Discussion points:**

1. IDs of the elements are dynamically generated
1. Up-to-date best practices (PageFactory, ExpectedCondition are obsolete...)
