namespace KastaPageTest.PageObjects
{
    internal class SportProductsPageObject        
    {
        private IWebDriver _webDriver;

        private readonly By _allTypesOfSize = By.XPath("//label[@class='size-tab filters__button smaller px-2 py-1 lh-24 mr-2 mb-2']");

        private readonly By _buttonSizeType = By.XPath("");

        public SportProductsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SportProductsPageObject ChangeSizeList(string typeCategoryName)
        {
            WaitUntil.WaitSomeInterval(2);
            var getCategory = _webDriver.FindElements(_allTypesOfSize).First(x => x.Text == typeCategoryName);
            getCategory.Click();
            return this;
        }

        public bool VerifyTheSizeButtonColorIsCorrect(string buttonType)
        {
            string buttonCollor = _webDriver.FindElement(By.XPath($"//label[contains(text(),'{buttonType}')]")).GetCssValue("background-color");
            if (buttonCollor == rgbColors.sizeButtonsActiveColor)
            {
                return true;
            }
            else return false;
        }
    }
}
