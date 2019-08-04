using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SampleWeb.Configuration;
using SampleWeb.PageObjects;
using SampleWeb.Utilities;
using SampleWeb.Utilities.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWeb.TestScripts
{
    [TestFixture]
    class GoogleSearchTest
    {
        IWebDriver driver;
        string testObjective;
        JArray jsonArray;
        List<string> screenshotList = new List<string>();
        List<TestReportSteps> report;
        GoogleHomePage googleHomePage;
        SearchResultsPage searchResultsPage;

        [SetUp]
        public void Init()
        {
            driver = ConfigFile.Init();
            googleHomePage = new GoogleHomePage(driver);
            searchResultsPage = new SearchResultsPage(driver);

            testObjective = "To verify google search functionality.";
            jsonArray = ConfigFile.RetrieveInputTestData("GoogleSearchTest.json");
        }

        [Test]
        public void TestGoogleSearch()
        {
            if (jsonArray != null)
            {
                foreach (var testData in jsonArray)
                {
                    report = googleHomePage.SearchText(driver, testData);
                    screenshotList.Add(googleHomePage.GetScreenshot());

                    //Verify search results page
                    report.AddRange(searchResultsPage.VerifySearchResultsPage(driver, testData));
                    screenshotList.Add(CaptureScreenshot.TakeSingleSnapShot(driver, "Verify Result"));

                }
            }
        }

        [TearDown]
        public void Exit()
        {
            driver.Quit();
            Report.WriteResultToHtml(driver, report, screenshotList, testObjective);
        }
    }
}
