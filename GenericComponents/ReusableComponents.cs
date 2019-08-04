using OpenQA.Selenium;
using System;

namespace SampleWeb.GenericComponents
{
    class ReusableComponents
    {

        public static void WaitUntilElementInvisible(IWebDriver driver, string selector)
        {
            bool found = false;
            do
            {
                try
                {

                    driver.FindElement(By.XPath(selector));
                }
                catch (Exception e)
                {
                    found = true;
                }
            } while (!found);
        }

        public static void WaitUntilElementVisible(IWebDriver driver, string selector)
        {
            bool found = false;
            do
            {
                try
                {
                    driver.FindElement(By.XPath(selector));
                    found = true;
                    break;
                }
                catch (Exception e)
                {
                    found = false;
                }
            } while (!found);
        }
    }
}
