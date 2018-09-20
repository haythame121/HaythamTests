using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary2.Framework.PageObjectModel
{
    public class SearchPage
    {
        private const string SearchUrl = "http://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "o-btn--primary")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "nameSearch")]
        public IWebElement RestaurantSearchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "c-serp__header")]
        public IWebElement RestaurantHeader { get; set; }

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }

        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        public string FindInPage()
        {
            Thread.Sleep(3000);
            var header = RestaurantHeader.FindElement(By.TagName("h1"));
            var subHeaderTxt = header.Text;

            return subHeaderTxt;
        }

        public void Click()
        {
            SearchButton.Click();
        }
    }
}
