using ClassLibrary2.Framework.PageObjectModel;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace ClassLibrary2.Steps
{
    [Binding]
    public class RestaurantSearchSteps
    {
        private readonly IWebDriver _driver;
        private SearchPage _searchPage;

        public RestaurantSearchSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _searchPage = PageFactory.InitElements<SearchPage>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [Given(@"I want food in (.*)")]
        public void GivenIWantFoodIn(string input)
        {
            _searchPage.Navigate();
            _searchPage.Search(input);
        }

        [When(@"I search for restaurants")]
        public void WhenISearchForRestaurants()
        {

        }

        [Then(@"I should see some restaurants in (.*)")]
        public void ThenIShouldSeeSomeRestaurantsIn(string p0)
        {

        }
    }
}
