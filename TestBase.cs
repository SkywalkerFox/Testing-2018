using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Testing_2018
{
    public class TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        public string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"D:\");
            baseURL = "http://pnote.ru/index.php";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void OpenURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string login, string password)
        {
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys(login);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            Thread.Sleep(2000);
        }

        public void AddNote(string noteText)
        {
            driver.FindElement(By.XPath("//div[@id='all']/div[3]/table/tbody/tr/td[2]/a/b")).Click();
            driver.FindElement(By.Id("add_data_text")).Clear();
            driver.FindElement(By.Id("add_data_text")).SendKeys(noteText);
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(2000);
        }

        public void DeleteNote(int noteNumber)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'МЕНЮ')])[" + noteNumber + "]")).Click();
            acceptNextAlert = true;
            driver.FindElement(By.LinkText("  Удалить")).Click();
            CloseAlertAndGetItsText();
            Thread.Sleep(2000);
        }

        public void AddNoteWithSettings(string noteText, string settings)
        {
            driver.FindElement(By.XPath("//div[@id='all']/div[3]/table/tbody/tr/td[2]/a/b")).Click();
            driver.FindElement(By.Id("add_data_type")).Click();
            new SelectElement(driver.FindElement(By.Id("add_data_type"))).SelectByText(settings);
            driver.FindElement(By.Id("add_data_type")).Click();
            driver.FindElement(By.Id("add_data_text")).Click();
            driver.FindElement(By.Id("add_data_text")).Clear();
            driver.FindElement(By.Id("add_data_text")).SendKeys(noteText);
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(2000);
        }

        public void AddSubNoteWithSettings(string noteText, string settings)
        {
            driver.FindElement(By.LinkText(" МЕНЮ")).Click();
            driver.FindElement(By.LinkText("  Добавить")).Click();
            driver.FindElement(By.Id("add_data_text")).Clear();
            driver.FindElement(By.Id("add_data_text")).SendKeys(noteText);
            driver.FindElement(By.Id("add_data_type")).Click();
            new SelectElement(driver.FindElement(By.Id("add_data_type"))).SelectByText(settings);
            driver.FindElement(By.Id("add_data_type")).Click();
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(2000);
        }

        public void EditSubNoteSettings(int noteNumber, string newSettings)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'МЕНЮ')])[" + noteNumber + "]")).Click();
            driver.FindElement(By.LinkText("  Редактировать")).Click();
            driver.FindElement(By.Id("edit_data_type")).Click();
            new SelectElement(driver.FindElement(By.Id("edit_data_type"))).SelectByText(newSettings);
            driver.FindElement(By.Id("edit_data_type")).Click();
            driver.FindElement(By.XPath("(//input[@name='submit'])[" + noteNumber + "]")).Click();
            Thread.Sleep(2000);
        }

        public void LogOut()
        {
            driver.FindElement(By.LinkText("Выход")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }

            
        }
    }
}