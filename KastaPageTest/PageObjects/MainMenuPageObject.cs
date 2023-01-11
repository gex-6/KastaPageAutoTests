namespace KastaPageTest.PageObjects
{
    internal class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _accountIcon = By.XPath("//span[contains(text(),'Профіль')]");

        private readonly By _signSuccessPopUp = By.XPath("//span[@class='notification__info']");

        private readonly By _itemsInCart = By.XPath("//span[@class='header_quantity']");

        private readonly By _sportProductsPage = By.XPath("//img[@class='dsc__icon']/following-sibling::div[contains(text(),'Спорт')]");

        private readonly By _kastaDesignPage = By.XPath("//img[@class='dsc__icon']/following-sibling::div[contains(text(), 'KASTA design')]");

        private readonly string _logInSuccess = "notification_info";

        private readonly By _searchInput = By.XPath("//input[@type='search']");

        private readonly By _profileButton = By.XPath("//span[contains(text(),'Профіль')]");

        private readonly By _signOutButton = By.XPath("//a[contains(text(),'Вийти')]");


        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignInButtonClick()
        {
            _webDriver.FindElement(_accountIcon).Click();

            return new AuthorizationPageObject(_webDriver);
        }

        public string GetTextInSuccessSignInPopUp()
        {
            string signSuccessActual = _webDriver.FindElement(_signSuccessPopUp).Text;

            return signSuccessActual;
        }

        public bool CheckPresenceSignInSuccessNotification()
        {
            try
            {
                _webDriver.PageSource.Contains(_logInSuccess);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string CheckItemAddedToCart()
        {
            WaitUntil.ElementShouldHaveText(_webDriver, _itemsInCart);

            string itemAddedSuccess = _webDriver.FindElement(_itemsInCart).Text;

            return itemAddedSuccess;
        }

        public SportProductsPageObject NavigateToSportProductsPage()
        {
            _webDriver.FindElement(_sportProductsPage).Click();
            return new SportProductsPageObject(_webDriver);
        }

        public KastaDesignPageObject NavigateToKastaDesignPage()
        {
            _webDriver.FindElement(_kastaDesignPage).Click();
            return new KastaDesignPageObject(_webDriver);
        }

        public SearchResultPageObject PerformSearch(string searchPhrase)
        {
            var searchField = _webDriver.FindElement(_searchInput);
            searchField.SendKeys(searchPhrase);
            searchField.SendKeys(Keys.Enter);
            return new SearchResultPageObject(_webDriver);
        }

        public MainMenuPageObject HoverTheProfileTab()
        {
            WaitUntil.WaitSomeInterval(8);
            Actions action = new Actions(_webDriver);

            var profileSettings = _webDriver.FindElement(_profileButton);
            action.MoveToElement(profileSettings).Build().Perform();

            return new MainMenuPageObject(_webDriver);
        }

        public MainMenuPageObject ClickSignOutButton()
        {
            WaitUntil.WaitSomeInterval(3);
            _webDriver.FindElement(_signOutButton).Click();
            return new MainMenuPageObject(_webDriver);
        }

        public bool CheckSignInPopUpOpened()
        {
            try
            {
                _webDriver.PageSource.Contains("//div[contains(text(),'Вхід / Реєстрація')]");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
