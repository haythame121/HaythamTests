# .Net-Core-Specflow-Sample

Restaurant Search Automation Tests:

Set up:

The framwork uses .net core.
Packages used for the framework to work are: 
1) Specflow 2.1 (correct versioning is important as most other versions are not yet compatible with .net core)
2) NUnit3TestAdapter 3.10
3) NUnit.Framework for TestFixtureSetUpAttribute

Additional packages to support the Automation framework:
1) DotNetSeleniumExtras.PageObjects.Core
2) Chrome.Webdriver


Running the tests:

The tests can run on either Mac or Windows.
To run the tests: 
1) Unzip the file, use an IDE (compatible for running Specflow tests), launch the sln file and Build solution before running.
2) Or, simply clone the project from https://github.com/haythame121/HaythamTests and launch the sln.