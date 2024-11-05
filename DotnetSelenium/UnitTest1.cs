using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V128.Debugger;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests : PageTest
    {
        [Test]
        public async Task Test1()
        {
            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            var edgeOptions = new EdgeOptions();
            var downloadDirectory = "C:\\Users\\sasha\\Desktop\\excel отчёты";
            edgeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
            edgeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            edgeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            var driver = new EdgeDriver(service, edgeOptions);

            driver.Navigate().GoToUrl("https://poo.susu.ru/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);
            IWebElement webElement = driver.FindElement(By.Id("schools"));

            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("schools")));
            selectElement.SelectByValue("2");

            driver.FindElement(By.Name("UN")).SendKeys("Отчет");

            webElement = driver.FindElement(By.Name("PW"));
            webElement.SendKeys("987654");

            webElement.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
            IWebElement otchet = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/nav/ul/li[5]/a"));
            otchet.Click();

            otchet = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/nav/ul/li[5]/ul/li[1]/a"));
            otchet.Click();



            for (int i = 0; i < int.MaxValue; i++)
            {
                try
                {

                    SelectElement group = new SelectElement(driver.FindElement(By.Name("PCLID_IUP")));
                    group.SelectByIndex(i);

                    for (int j = 0; j <= int.MaxValue; j++)
                    {
                        try
                        {
                            
                            SelectElement course = new SelectElement(driver.FindElement(By.Name("SGID")));
                            course.SelectByIndex(j);

                            Thread.Sleep(3000);
                            try
                            {
                                SelectElement period = new SelectElement(driver.FindElement(By.Name("TERMID")));
                                period.SelectByValue("9");
                            }
                            catch { }




                            Thread.Sleep(3000);
                            IWebElement load = driver.FindElement(By.Id("load-journal-btn"));
                            load.Click();
                            load.SendKeys(Keys.Return);

                            try
                            {
                                Thread.Sleep(3000);
                                IWebElement setup = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div/div/div[2]/div[1]/div[1]/div[1]/div/div/button[3]"));
                                setup.SendKeys(Keys.Return);

                                Thread.Sleep(3000);
                                IWebElement confirm = driver.FindElement(By.XPath("//button[text()='Да, больше не спрашивать']"));
                                confirm.SendKeys(Keys.Return);

                            }
                            catch
                            {
                                continue;
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                catch
                {
                    break;
                }

            }


        }

    }
}
