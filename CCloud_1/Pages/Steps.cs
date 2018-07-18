using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace CCloud_1.Pages
{
    [Binding]
    public class Steps
    {

        IWebDriver driver;

        [StepDefinition(@"I navigato to website")]
        public void GivenINavigatoToWebsite()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            var yahoo = "http://www.yahoo.com";

            //Test with another website to check if failed test returns correct message
            var google = "http://www.google.com";


            driver.Navigate().GoToUrl(yahoo);

        }


        [Then(@"Expected text '(.*)' will appear on page for less than '(.*)' seconds")]
        public void ThenExpectedTextWillAppearOnPageForSeconds(string text, int timeout)
        {
            int driverTimeout = Convert.ToInt32(timeout);

            Assert.True(GetText(text, driverTimeout), "Expected text is missing from page for expected load time");
        }

        public bool GetText(string text, int timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='uh-signin']")));

                IWebElement s = driver.FindElement(By.XPath("//*[@id='uh-signin']"));

                string str = s.GetAttribute("textContent");
                if (text == str)

                    return true;

                else

                    return false;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }

        }
    }
}
