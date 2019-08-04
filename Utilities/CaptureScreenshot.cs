using SampleWeb.Configuration;
using OpenQA.Selenium;
using System;

namespace SampleWeb.Utilities
{
    class CaptureScreenshot
    {
        public static bool IsScreenshotCaptured { get; private set; }

        /// <summary>
        /// Take screenshot of current browser window
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="fileName"></param>
        public static string TakeSingleSnapShot(IWebDriver driver, String fileName)
        {
            if (driver.ToString().Contains("(null)"))
                IsScreenshotCaptured = false;
            else if (string.IsNullOrEmpty(fileName))
                IsScreenshotCaptured = false;
            else
            {
                fileName = ConfigFile.GetAbsoluteFilePath("Results\\Screenshots\\") + fileName + Constant.currentDateTime+".png";
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();

                //Save the screenshot
                image.SaveAsFile(fileName, OpenQA.Selenium.ScreenshotImageFormat.Png);

            }
            return fileName;
        }


    }
}