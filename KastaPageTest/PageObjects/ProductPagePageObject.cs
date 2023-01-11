namespace KastaPageTest.PageObjects
{
    internal class ProductPagePageObject
    {
        private IWebDriver _webDriver;

        private readonly By _buyButton = By.XPath("//button[@id='productBuy']");
        private readonly By _sizeButton = By.XPath("//button[text()='S']");
        private readonly By _addToFavoriteButton = By.XPath("//div[@ts-req='/api/v2/wishlist/items']");

        public ProductPagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject AddProductToCart()
        {
            _webDriver.FindElement(_buyButton).Click();
            _webDriver.FindElement(_sizeButton).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public ProductPagePageObject ClickAddToFavoritesButton()
        {
            _webDriver.FindElement(_addToFavoriteButton).Click();
            WaitUntil.WaitSomeInterval(3);
            return new ProductPagePageObject(_webDriver);
        }

        public string GetAddToFavoriteButtonName()
        {
            return _webDriver.FindElement(_addToFavoriteButton).GetAttribute("title");
        }
    }
}
