using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Framework
{
    public static class StateManager
    {   
        //Saving results using the ScenarioContext feature
        public static void Save(string restaurant, string headerText)
        {
            ScenarioContext.Current[restaurant] = headerText;
        }

        //Getting results from the ScenarioContext for the Assertion purpose
        public static string Get(string restaurant)
        {
            return ScenarioContext.Current[restaurant].ToString();
        }
    }
}
