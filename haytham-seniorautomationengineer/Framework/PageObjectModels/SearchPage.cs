using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HaythamSeniorAutomationEngineer.Tests.Framework.PageObjectModels
{
    public class SearchPage : BaseSearchPage
    {
        private const string SearchUrl = "http://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "o-btn o-btn--primary")]
        public IWebElement SearchButton { get; set; }

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }


        public void Search(string input)
        {
            PostcodeSearchInput.Clear();
            PostcodeSearchInput.SendKeys(input);
            SearchButton.Click();
        }
    }
}