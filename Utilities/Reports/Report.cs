using SampleWeb.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SampleWeb.Utilities.Reports
{
    class Report
    {
        public static String htmlFilepath;
        /**
         * Generate html report
         * @param items - report steps
         * @param filepath - array of screenshot path
         * @param getCurrentDateTime
         * @param getCurrentTime
         * @param count - 0 append to single report , else multiple report file
         */
        public static int failedSteps = 0;
        public static int passedSteps = 0;
        public static String executionTime;

        public static void WriteResultToHtml(IWebDriver driver, List<TestReportSteps> listItems, List<string> filepath, string testObjective)
        {
            try
            {
                string browserName = Constant.browser;
                string currentDateTime = Constant.currentDateTime;
                String getCurrentDate = Constant.currentDate;
                String getCurrentTime = Constant.currentTime;
                int pathCounter = 0;
                StringBuilder color = new StringBuilder();
                StringBuilder status = new StringBuilder();
                // define a HTML String Builder
                StringBuilder actualResult = new StringBuilder();
                StringBuilder htmlStringBuilder = new StringBuilder();
                // append html header and title
                htmlStringBuilder.Append(
                        "<html><head><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\" integrity=\"sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm\" crossorigin=\"anonymous\">\r\n"
                                + "<script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js\" integrity=\"sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl\" crossorigin=\"anonymous\"></script><title>Selenium Test </title></head>");


                // append body
                htmlStringBuilder.Append("<body>");
                // append table

                htmlStringBuilder.Append("<table class=\"table table-striped table-bordered\">");
                htmlStringBuilder.Append("<tr><th style=\"background-color:#a6a6a6\">Date Time</th><td>"
                        + currentDateTime
                        + "</td><th style=\"background-color:#a6a6a6\">Environment Tested</th><td>QC</td></tr><tr><th style=\"background-color:#a6a6a6\">OS</th><td>Windows</td><th style=\"background-color:#a6a6a6\">Browser</th><td>" + browserName + "</td></tr><tr><th style=\"background-color:#a6a6a6\">Script Name</th><td> iMAAP Application</td><th style=\"background-color:#a6a6a6\">Version</th><td>1.0</td></tr><tr><th style=\"background-color:#a6a6a6\">Objective</th><td colspan=\""
                        + 3 + "\">" + testObjective + "</td><tr><tr></table>");


                // append row
                htmlStringBuilder.Append("<table class=\"table table-striped\">");
                htmlStringBuilder.Append(
                        "<thead style=\"background-color:#a6a6a6\"><tr><th><b>TestObjective</b></th><th><b>StepName</b></th><th><b>StepDescription</b></th><th><b>ExpectedResult</b></th><th><b>ActualResult</b></th><th><b>Status</b></th><th><b>Screenshot</b></th></tr></thead><tbody>");
                // append row
                foreach (var a in listItems)
                {
                    if (!(string.IsNullOrEmpty(a.getActualResultFail())))
                    {
                        status.Append("Fail");
                        color.Append("red");
                        failedSteps++;
                        actualResult.Append(a.getActualResultFail());

                    }
                    else
                    {
                        status.Append("Pass");
                        color.Append("green");
                        passedSteps++;
                        actualResult.Append(a.getActualResultPass());

                    }
                    string check = a.getStepDescription().ToLower();
                    if (a.getStepDescription().ToLower().Contains("screenshot"))
                    {
                        htmlStringBuilder.Append("<tr><td style=\"font-weight:bold\">" + a.getTestObjective() + "</td><td>" + a.getStepName()
                                + "</td><td>" + a.getStepDescription() + "</td><td>" + a.getExpectedResult() + "</td><td>"
                                + actualResult + "</td><td style=\"color:" + color + ";font-weight:bolder;\">" + status
                                + "</td><td><a href=\"" + filepath[pathCounter++] + "\">Click here</a></td></tr>");
                    }

                    else
                    {
                        htmlStringBuilder.Append("<tr><td style=\"font-weight:bold\">" + a.getTestObjective() + "</td><td>"
                                + a.getStepName() + "</td><td>" + a.getStepDescription() + "</td><td>"
                                + a.getExpectedResult() + "</td><td>" + actualResult + "</td><td style=\"color:" + color
                                + ";font-weight:bolder;\">" + status + "</td><td></td></tr>");
                    }
                    actualResult.Remove(0, actualResult.Length);
                    color.Remove(0, color.Length);
                    status.Remove(0, status.Length);
                }

                // close html file
                htmlStringBuilder.Append("</tbody></table></body></html>");

                // write html string content to a file


                htmlFilepath = ConfigFile.GetAbsoluteFilePath("Results\\Report\\testfile-") + Constant.currentDate  + Constant.currentTime + ".htm";

                WriteToFile(htmlStringBuilder.ToString(), htmlFilepath);

            }
            catch (IOException e)
            {
                Console.WriteLine("Exception" + e);
            }
        }

        /**
        * Write html report to file
        */
        public static void WriteToFile(string fileContent, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(fileContent);
                }
            }

        }
    }
}
