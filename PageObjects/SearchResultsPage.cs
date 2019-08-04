using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using SampleWeb.Configuration;
using SampleWeb.GenericComponents;
using SampleWeb.Utilities.Reports;
using System;
using System.Collections.Generic;

namespace SampleWeb.PageObjects
{
    class SearchResultsPage
    {
        int step = 0;
        List<TestReportSteps> listOfReport;
        JObject jObject;

        private string verifyResultPage = "VerifyResultPage";

        public SearchResultsPage(IWebDriver driver)
        {
            jObject = ConfigFile.RetrieveUIMap("SearchResultsPageSelector.json");

        }

        public List<TestReportSteps> VerifySearchResultsPage(IWebDriver driver, JToken inputjson)
        {

            listOfReport = ConfigFile.GetReportFile("VerifySearchResultsPageReport.json");

            //Verify Google Home page
            ReusableComponents.WaitUntilElementVisible(driver, jObject[verifyResultPage].ToString());

            //Set report
            Console.WriteLine("User was able to verify google search result page");
            listOfReport[step++].setActualResultFail("");

            return listOfReport;

        }
    }
}
