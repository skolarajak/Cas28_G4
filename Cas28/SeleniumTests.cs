using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cas28
{
    class SeleniumTests
    {
        // Declare a variable to hold our webdriver reference
        IWebDriver driver;

        [SetUp]
        // This method is called automatically every time a test is run
        public void Init()
        {
            // Initialize Chrome as our webdriver
            driver = new ChromeDriver();
        }

        [Test]
        public void TestUnos()
        {
            string txtMessage = "Ovo je tekst poruke.";
            GoToWebsite("http://qa.todorowww.net/", 2000);
            IWebElement txtUnos = FindElement(By.Name("unos"));
            // If element was found, simulate keystrokes
            txtUnos?.SendKeys(txtMessage);
            Wait(2000);
            if (txtUnos.Text != txtMessage)
            {
                // If entered text doesn't match the one we tryed to enter, fail the test
                Assert.Fail("The text differs fron requested.");
            } else
            {
                // If the texts match, pass the test
                Assert.Pass("Entered text matches the requested one.");
            }
        }

        [Test]
        public void TestRegister()
        {
            // Store XPath into this variable
            string xpath;
            GoToWebsite("http://qa.todorowww.net/", 2000);
            IWebElement lnkRegister;
            // Try to find an <a> element that contains specified text
            lnkRegister = FindElement(By.PartialLinkText("Registruj"));
            Wait(1000);
            if (lnkRegister != null) {
                // If we could find a link, click on it
                lnkRegister.Click();
            }
            // Try to find an element, if found, simulate keystrokes
            FindElement(By.Name("ime"))?.SendKeys("Petar");
            Wait(1000);
            // Try to find an element, if found, simulate keystrokes
            FindElement(By.Name("preime"))?.SendKeys("Petrovic");
            Wait(1000);
            xpath = "//input[@name='korisnicko']";
            // By.Name("korisnicko");
            // Try to find an element, if found, simulate keystrokes
            FindElement(By.XPath(xpath))?.SendKeys("PPetrovicc");
            Wait(5000);
        }

        [TearDown]
        // This method is called automatically every time a test has finished its run
        public void Destroy()
        {
            // Close our webdriver and release memory
            driver.Close();
        }

        ///<summary>
        ///Wait a specified number of <paramref name="ms" />.
        ///</summary>
        ///<param name="ms">Integer. Number of miliseconds to wait for.</param>
        static private void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        ///<summary>
        ///Navigate to a specified <paramref name="url" />.
        ///Wait specified number of <paramref name="ms"/> before, and after navigating.
        ///</summary>
        ///<param name="url">String. URL to which to navigate to.</param>
        ///<param name="ms">Integer. Number of miliseconds to wait before and after navigating.</param>
        private void GoToWebsite(string url, int ms)
        {
            Wait(ms);
            driver.Navigate().GoToUrl(url);
            Wait(ms);
        }

        ///<summary>
        ///Searches for an element usng the <paramref name="criteria" /> provided.
        ///</summary>
        ///<param name="criteria">By. Criteria by which to look for an element.</param>
        public IWebElement FindElement(By selector)
        {
            // Declare a variable to hold our found element
            IWebElement elReturn = null;
            // Try/Catch
            try
            {
                // Try to find an element using Selenium
                elReturn = driver.FindElement(selector);
            } catch (NoSuchElementException)
            {
                // If Selenium can't find an element, catch the exception
                // and log it
                // File path must contain double slashes (\\) to avoid unwanted escape sequences.
                string File = "C:\\Kurs\\Selenium.log";
                // Put a $ in front of double quotes to allow code between { and } to be executed
                // within the string
                string Message = $"Element \"{selector.ToString()}\" not found.";
                FileClass.Log(File, Message);
            } catch (Exception e)
            {
                // Allow other exceptions to pass through our code
                throw e;
            }

            // Return found element
            return elReturn;
        }
    }
}
