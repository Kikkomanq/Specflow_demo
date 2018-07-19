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

            //Asserting if the conditions is true, and Error message for false condiotion of method
            Assert.True(GetText(text, driverTimeout), "Expected text is missing from page for expected load time");
        }


        /*Method GetText() will first wait for specified number of seconds to find element.
        If element is found (ElementIsVisible), then it will check if textAttribute is as expected
        At the end, it will handle exception in negative case (test with google), so that message from Assert method will be displayed,
        reather than default TimeoutException*/ 

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
