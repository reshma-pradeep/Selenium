using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using SampleWeb.Configuration;
using SampleWeb.GenericComponents;
using SampleWeb.Utilities;
using SampleWeb.Utilities.Reports;
using System;
using System.Collections.Generic;

namespace SampleWeb.PageObjects
{
    class GoogleHomePage
    {
        int step = 0;
        List<TestReportSteps> listOfReport;
        JObject jObject;

        private string logo = "Logo";
        private string searchText = "SearchText";
        private string searchBtn = "SearchBtn";
        public string screenshot;
        public GoogleHomePage(IWebDriver driver)
        {
            jObject = ConfigFile.RetrieveUIMap("GoogleHomePageSelector.json");

        }

        public List<TestReportSteps> SearchText(IWebDriver driver, JToken inputjson)
        {

            listOfReport = ConfigFile.GetReportFile("SearchTestReport.json");

            //Verify Google Home page
            ReusableComponents.WaitUntilElementVisible(driver, jObject[logo].ToString());

            //Set report
            Console.WriteLine("User was able to verify google home page");
            listOfReport[step++].setActualResultFail("");

            //Enter search text
            ReusableComponents.WaitUntilElementVisible(driver,jObject[searchText].ToString());
            driver.FindElement(By.XPath(jObject[searchText].ToString())).SendKeys(inputjson[searchText].ToString());

            //Set report
            Console.WriteLine("User was able to enter search text");
            listOfReport[step++].setActualResultFail("");
            screenshot = CaptureScreenshot.TakeSingleSnapShot(driver, "Search");

            //Press Google Search button
            ReusableComponents.WaitUntilElementVisible(driver, jObject[searchBtn].ToString());
            driver.FindElement(By.XPath(jObject[searchBtn].ToString())).Click();


            Console.WriteLine("User was able to press Enter button");
            listOfReport[step++].setActualResultFail("");

            return listOfReport;

        }

        public string GetScreenshot()
        {
            return screenshot;
        }
    }
}
