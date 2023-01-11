namespace KastaPageTest
{
    internal class WaitUntil
    {
        public static void ElementShouldHaveText(IWebDriver webDriver, By location)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(5);

            string result = fluentWait.Until(x => x.FindElement(location).Text);
        }

        public static void WaitSomeInterval(int seconds = 5)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }
}
