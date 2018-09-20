using System.IO;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ClassLibrary2.Framework
{
    [Binding]
    public class SeleniumIoCFactory
    {
        private readonly IObjectContainer _objectContainer;

        public SeleniumIoCFactory(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            var webDriver = new ChromeDriver(Path.GetFullPath(@"Driver/"));
            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }
    }
}
