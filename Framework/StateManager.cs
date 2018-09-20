using System;
using TechTalk.SpecFlow;

namespace ClassLibrary2.Framework
{
    public class StateManager
    {
        public static void Save(string key, object value)
        {
            ScenarioContext.Current[key] = value;
        }

        public static T Get<T>(string key) where T : class
        {
            return ScenarioContext.Current[key] as T;
        }
    }
}
