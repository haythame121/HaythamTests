﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Framework.PageObjectModel
{
    public class SearchPage
    {
        private const string SearchUrl = "https://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;
        private WebDriverWait wait;

        //Identified objects from page elements
        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "o-btn--primary")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "nameSearch")]
        public IWebElement RestaurantSearchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "c-serp__header")]
        public IWebElement RestaurantHeader { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        //Re-Usable methods
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }
        //Including IWebElement parameter to use Search method in n other areas in the test journey
        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        public string FindInPage()
        {

            wait.Until(x => int.Parse(RestaurantHeader.FindElement(By.ClassName("c-serp__header--count")).Text) < 414) || 
                int.Parse(RestaurantHeader.FindElement(By.ClassName("c-serp__header--count")).Text) == null) ;

            return RestaurantHeader.FindElement(By.TagName("h1")).Text;
        }
        //Including IWebElement parameter to Click in other areas in the test journey
        public void Click(IWebElement searchOn)
        {
            searchOn.Click();
        }
    }
}
