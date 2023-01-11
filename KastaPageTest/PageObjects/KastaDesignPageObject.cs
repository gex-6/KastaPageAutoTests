namespace KastaPageTest.PageObjects
{
    internal class KastaDesignPageObject
    {
        private IWebDriver _webDriver;

        public KastaDesignPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public TimeSpan GetTimeNeededToFindElement(By by)
        {
            var timebefore = DateTime.Now;
            try
            {
                _webDriver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
            var timeafter = DateTime.Now;
            return (timeafter - timebefore);
        }
    }
}
