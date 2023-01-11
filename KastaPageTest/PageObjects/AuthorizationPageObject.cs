namespace KastaPageTest.PageObjects
{
    internal class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _inputEmail = By.XPath("//input[@id='email']");
        private readonly By _emailSubmitButton = By.XPath("//button[@class='btn']");
        private readonly By _inputPass = By.XPath("//input[@id='password']");
        private readonly By _signInBotton = By.XPath("//button[@class='btn auth-btn']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject SignIn(string login, string password)
        {
            _webDriver.FindElement(_inputEmail).SendKeys(login);
            _webDriver.FindElement(_emailSubmitButton).Click();
            _webDriver.FindElement(_inputPass).SendKeys(password);
            _webDriver.FindElement(_signInBotton).Click();

            return new MainMenuPageObject(_webDriver);
        }
    }
}
