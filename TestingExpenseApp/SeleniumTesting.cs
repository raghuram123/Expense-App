using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;

namespace TestingExpenseApp
{
    [TestClass]
    public class SeleniumTesting
    {

        [TestMethod]
        public void UserLogin()
        {
            ChromeDriver driver = null;
            WebDriverWait wait;
            string url = "http://localhost:63571//Account//Login";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("MainContent_txtbxUserName")).SendKeys("don");
            driver.FindElement(By.Id("MainContent_txtbxPassword")).SendKeys("don");
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            Assert.AreEqual("Welcome don", driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div[2]/h2")).Text);
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void invalidUserLogin()
        {
            ChromeDriver driver = null;
            WebDriverWait wait;
            string url = "http://localhost:63571//Account//Login";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElementById("MainContent_txtbxUserName").SendKeys("raghu12345");
            driver.FindElementById("MainContent_txtbxPassword").SendKeys("don");
            driver.FindElementById("MainContent_btnLogin").Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            Assert.AreEqual("Invalid UserName", driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/p")).Text);
            driver.Close();
            driver.Dispose();
        }
        [TestMethod]
        public void userRegister() // when running this test please change the user name as it tests with the original database
        {
            ChromeDriver driver = null;
            WebDriverWait wait;
            string url = "http://localhost:63571//Account//Register";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElementById("MainContent_txtbxUserName").SendKeys("raghu");
            driver.FindElementById("MainContent_txtbxPassword").SendKeys("don");
            driver.FindElementById("MainContent_txtbxConfirmPassword").SendKeys("don");
            driver.FindElementById("MainContent_txtbxFirstName").SendKeys("raghu");
            driver.FindElementById("MainContent_txtbxLastName").SendKeys("srini");
            driver.FindElementById("MainContent_btnRegister").Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.FindElementById("MainContent_btnLogin");
            driver.Close();
            driver.Dispose();
        }
        [TestMethod]
        public void userExistingRegister()
        {
            ChromeDriver driver = null;
            WebDriverWait wait;
            string url = "http://localhost:63571//Account//Register";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElementById("MainContent_txtbxUserName").SendKeys("raghu");
            driver.FindElementById("MainContent_txtbxPassword").SendKeys("don");
            driver.FindElementById("MainContent_txtbxConfirmPassword").SendKeys("don");
            driver.FindElementById("MainContent_txtbxFirstName").SendKeys("raghu");
            driver.FindElementById("MainContent_txtbxLastName").SendKeys("srini");
            driver.FindElementById("MainContent_btnRegister").Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            Assert.AreEqual("User Name raghu already exists", driver.FindElement(By.XPath("//*[@id=\"MainContent_userNameValidator\"]")).Text);


            driver.Close();
            driver.Dispose();
        }
    }
}
