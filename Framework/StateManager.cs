using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ClassLibrary2.Framework
{
    public static class StateManager
    {
        public static void Save(string restaurant, string headerText)
        {
            ScenarioContext.Current[restaurant] = headerText;
        }

        public static string Get(string restaurant)
        {
            return ScenarioContext.Current[restaurant].ToString();
        }
    }
}
