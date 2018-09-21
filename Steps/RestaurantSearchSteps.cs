using NUnit.Framework;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Framework;
using RestaurantSearch.UITests.Framework.PageObjectModel;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
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
            _driver.Quit();
        }

        [Given(@"I want food in (.*)")]
        public void GivenIWantFoodIn(string input)
        {
            //Navigation to the page
            _searchPage.Navigate();

            //Search by Postcode
            _searchPage.Search(_searchPage.PostcodeSearchInput, input);
            _searchPage.SearchButton.Click();
        }

        [When(@"I search for (.*)")]
        public void WhenISearchForRestaurants(string restaurant)
        {
            _searchPage.Search(_searchPage.RestaurantSearchInput, restaurant);
            var subHeaderText = _searchPage.FindInPage();
            StateManager.Save(restaurant, subHeaderText);
        }
        //I navigate to the information page of the restaurant

        [When(@"I change the area to (.*) using the 'Change Location' button")]
        public void IChangeTheAreaUsingTheButton(string newInput)
        {
            _searchPage.RestaurantHeader.FindElement(By.TagName("a")).Click();
            _searchPage.Search(_searchPage.PostcodeSearchInput, newInput);
            _searchPage.SearchButton.Click();
        }

        [Then(@"I should see some (.*) in (.*)")]
        public void ThenIShouldSeeSomeRestaurantsIn(string restaurant, string expectedPostcode)
        {
            var actualSubheaderforRestaurant = StateManager.Get(restaurant);

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
        }

        [Then(@"I shouldn't see the (.*) and I see the error message (.*)")]
        public void ThenIShouldntSeeSomeRestaurantsIn(string restaurant, string errorMessage)
        {
            var actualSubheaderforRestaurant = StateManager.Get(restaurant);

            Assert.That(actualSubheaderforRestaurant.Equals(errorMessage));
        }
    }
}
