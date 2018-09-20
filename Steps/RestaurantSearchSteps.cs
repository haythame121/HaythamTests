using System.Threading;
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
            _searchPage= PageFactory.InitElements<SearchPage>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //_driver.Quit();
        }

        [Given(@"I want food in (.*)")]
        public void GivenIWantFoodIn(string input)
        {
            //Navigation to the page
            _searchPage.Navigate();

            //Search by Postcode
            _searchPage.Search(_searchPage.PostcodeSearchInput, input);
            _searchPage.Click();
        }

        [When(@"I search for (.*)")]
        public void WhenISearchForRestaurants(string restaurant)
        {
            _searchPage.Search(_searchPage.RestaurantSearchInput, restaurant);
            _searchPage.FindInPage(restaurant);
 
            Thread.Sleep(5000);

        }

        [Then(@"I should see some restaurants in (.*)")]
        public void ThenIShouldSeeSomeRestaurantsIn(string p0)
        {

        }
    }
}
