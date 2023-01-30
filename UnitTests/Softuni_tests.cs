using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace NunitWebDriverTests
{   
    public class SoftuniTests
    {
        [SetUp] 
        public void Setup()
        {
        }

        [Test]
        public void Test_Assert_page_title()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";


            Assert.That(driver.Title , Is.EqualTo(expectedTitle));

            driver.Quit();  
        }
    }
}