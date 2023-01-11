namespace KastaPageTest.PageObjects
{
    internal class SearchResultPageObject
    {
        private IWebDriver _webDriver;

        private IList<IWebElement> _searhcResultItems => _webDriver.FindElements(By.XPath("//div[@id='products']"));

        public SearchResultPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IList<string> GetActualSearchResultsInText()
        {
            return _searhcResultItems
                .Select(item => item.Text)
                .ToList();
        }

        public IList<string> GetExpectedSearchResults(string searchText)
        {
            return GetActualSearchResultsInText()
                .Where(item => item.Contains(searchText))
                .ToList();
        }
    }
}
