using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {

        }
        [Test]
        public async Task Test1()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://poo.susu.ru/");
            driver.Manage().Window.Maximize();

            IWebElement webElement = driver.FindElement(By.Id("schools"));

            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("schools")));
            selectElement.SelectByValue("2");

            driver.FindElement(By.Name("UN")).SendKeys("Мальцев");

            webElement = driver.FindElement(By.Name("PW"));
            webElement.SendKeys("5044620");

            webElement.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            IWebElement otchet = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/nav/ul/li[3]/a"));
            otchet.Click();
            Thread.Sleep(5000);
            IWebElement otchet1 = driver.FindElement(By.XPath("//*[@id=\"ReportsList\"]/tbody/tr[6]/td[2]/a"));
            otchet.Click();


        }
    }
}
