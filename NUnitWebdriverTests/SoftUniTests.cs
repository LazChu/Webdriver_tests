using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;

namespace NUnitWebdriverTests
{
    public class SoftuniTests
    {

        private WebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown() 
        { 
            driver.Quit();
        }
        [Test]
        public void Test_assert_main_page_title()
        {
            //var driver = new ChromeDriver();
           // driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

            //driver.Quit();
         }
        [Test]
        public void Test_Contacts_button()
        {
            //var driver = new ChromeDriver();
              
            //driver.Url = "https://softuni.bg";
            var element = driver.FindElement(By.CssSelector("#nav-items-list > ul > li:nth-child(7) > a > span"));
            element.Click();

            string expectedTitle = "Контакти - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            
            //driver.Quit()l;
        
        }
        [Test]
        public void Test_Programs_button()
        {
            var element = driver.FindElement(By.CssSelector("#nav-items-list > ul > li:nth-child(1) > a > span.main-title"));
            element.Click();
            var apply_button = driver.FindElement(By.CssSelector("#\\31  > div.tab-content-header.buttons-wrapper.bottom-border > a"));
            apply_button.Click();

            var expectedElement = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/div/div[1]/h1"));
            expectedElement.Click();
            Assert.That(expectedElement.Displayed);

        }
    }
}