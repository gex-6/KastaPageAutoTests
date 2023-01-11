namespace KastaPageTest.Tests.ModuleTests
{
    // класи цього рівня розбити на модулі високорівневі: тест логування, тест корзина, продукту, 
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void SignInTest()
        {
            _webDriver.Navigate().GoToUrl(URLs.mainPage);

            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignInButtonClick()
                .SignIn(Users._email, Users._pass);

            Assert.IsTrue(mainMenu.CheckPresenceSignInSuccessNotification(), "sign in is wrong or wasn`t comleted");
        }

        [Test]
        public void AddToCartTest()
        {
            _webDriver.Navigate().GoToUrl(URLs.productPage);

            var productPage = new ProductPagePageObject(_webDriver);
            var actualItemsInCart = productPage
                .AddProductToCart()
                .CheckItemAddedToCart();

            Assert.That(actualItemsInCart, Is.EqualTo("1"), "product wasn`t added to cart");
        }

        [Test]
        public void TypeOfSizeIsSortedCorrect()
        {
            _webDriver.Navigate().GoToUrl(URLs.mainPage);

            var mainMenu = new MainMenuPageObject(_webDriver);
            bool result = mainMenu
                .NavigateToSportProductsPage()
                .ChangeSizeList(SizeTypesSorts.ByEuropeanTypeSort)
                .VerifyTheSizeButtonColorIsCorrect(SizeTypesSorts.ByEuropeanTypeSort);

            Assert.IsTrue(result, "the size type wasn`t changed");
        }

        [Test]
        public void TimeLoadKastaDesignPageIsLessThen2Seconds()
        {
            _webDriver.Navigate().GoToUrl(URLs.mainPage);

            var mainMenu = new MainMenuPageObject(_webDriver);

            var timeToFind = mainMenu
                .NavigateToKastaDesignPage()
                .GetTimeNeededToFindElement(Elements._h3KastaDesignPage);

            Assert.IsTrue(timeToFind.Seconds < 2, "loading takes more then 2 seconds");
        }

        [Test]
        public void CheckSearch()
        {
            _webDriver.Navigate().GoToUrl(URLs.mainPage);

            var mainMenu = new MainMenuPageObject(_webDriver);
            var searchResultsPage = new SearchResultPageObject(_webDriver);

            var actualSearchResults = mainMenu
                .PerformSearch(SearchPhrases.Dress)
                .GetActualSearchResultsInText();

            var expectedSearchResults = searchResultsPage
                .GetExpectedSearchResults(SearchPhrases.Dress);

            Assert.That(actualSearchResults, Is.EqualTo(expectedSearchResults), "search isn't made correctly");
        }

        [Test]
        public void SignInAndSignOut()
        {
            _webDriver.Navigate().GoToUrl(URLs.mainPage);

            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignInButtonClick()
                .SignIn(Users._email, Users._pass)
                .HoverTheProfileTab()
                .ClickSignOutButton()
                .SignInButtonClick();

            Assert.IsTrue(mainMenu.CheckSignInPopUpOpened(), "sign out wasn't succeeded");
        }

        [Test]
        public void CheckLikedItems()
        {
            _webDriver.Navigate().GoToUrl(URLs.productPage);

            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignInButtonClick()
                .SignIn(Users._email, Users._pass);

            var productPage = new ProductPagePageObject(_webDriver);
            string buttonActualName = productPage
                .ClickAddToFavoritesButton()
                .GetAddToFavoriteButtonName();

            productPage.ClickAddToFavoritesButton();

            Assert.That(buttonActualName, Is.EqualTo(Elements.AddToFavoritesButtonActiveName));

        }
    }
}