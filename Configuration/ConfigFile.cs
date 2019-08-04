using SampleWeb.Utilities;
using SampleWeb.Utilities.Reports;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace SampleWeb.Configuration
{
    class ConfigFile
    {
        private static IWebDriver driver;

        /// <summary>
        /// Initialize webdriver for the browser specified in appSettings and navigate to the URL specified in appSettings 
        /// </summary>
        /// <returns>driver - Initialized webdriver</returns>
        public static IWebDriver Init()
        {

            
            string driverPath = GetAbsoluteFilePath("WebDrivers");

            if (Constant.browser.Contains("chrome"))
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
                driver = new ChromeDriver(driverPath, chromeOptions);
            }
            else if (Constant.browser.Contains("internet explorer"))
            {
                driver = new InternetExplorerDriver(driverPath);
            }

            driver.Navigate().GoToUrl(Constant.url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constant.waitTimeout);

            return driver;
        }

        /// <summary>
        /// To retrieve testdata array input in json array format for the input file specified
        /// </summary>
        /// <param name="fileName">Input testdata file name</param>
        public static JArray RetrieveInputTestData(string fileName)
        {
            fileName = GetAbsoluteFilePath("TestData\\") + fileName;
            string json = File.ReadAllText(fileName);
            JObject jObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jObject["TestData"];
            return jsonArray;
        }

        /// <summary>
        /// Retreieve absolute path of the file or directory 
        /// </summary>
        /// <param name="fileOrDirectoryName">Input file name or directory name</param>
        /// <returns></returns>
        public static string GetAbsoluteFilePath(string fileOrDirectoryName)
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                                .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return Path.Combine(appRoot, fileOrDirectoryName);
        }

        public static List<TestReportSteps> GetReportFile(String reportFileName)
        {
            string fileName = ConfigFile.GetAbsoluteFilePath("Report\\") + reportFileName;
            TestReport testReport;
            List<TestReportSteps> listOfReport;
            string json;
            using (StreamReader reader = File.OpenText(fileName))
            {

                json = File.ReadAllText(fileName);
            }
            testReport = Newtonsoft.Json.JsonConvert.DeserializeObject<TestReport>(json);
            listOfReport = testReport.getTestReportSteps();

            return listOfReport;
        }

        public static JObject RetrieveUIMap(string fileName)
        {
            fileName = GetAbsoluteFilePath("UISelectors\\") + fileName;
            string json = File.ReadAllText(fileName);
            JObject jObject = JObject.Parse(json);
            return jObject;
        }

    }
}
