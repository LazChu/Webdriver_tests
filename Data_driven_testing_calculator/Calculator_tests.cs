using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Data_driven_testing_calculator
{
    public class WebDriverCalculatorTests
    {
        private ChromeDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate_button;
        IWebElement reset;
        IWebElement result;
        
        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate_button = driver.FindElement(By.Id("calcButton"));
            reset = driver.FindElement(By.Id("resetButton"));
            result = driver.FindElement(By.Id("result"));

        }
        [OneTimeTearDown]
        public void ShutDown() 
        { 
            driver.Quit();  
        }

        [Test]
        public void Test_Calculator()
        {
            field1.SendKeys("5");
            field2.SendKeys("5");   
            operation.SendKeys("+");
            calculate_button.Click();

            var expectedResult = "Result: 10";

            Assert.That(expectedResult, Is.EqualTo(result.Text));

            reset.Click();

        }
        [TestCase("20", "6","+","Result: 26")]
        [TestCase("20", "6", "-", "Result: 14")]
        [TestCase("5", "6", "*", "Result: 30")]
        [TestCase("20", "5", "/", "Result: 4")]
        [TestCase("0", "6", "*", "Result: 0")]
        [TestCase("0", "6", "/", "Result: 0")]
        [TestCase("one", "two", "+", "Result: invalid input")]

        public void Test_Cases_for_operations(string num1, string num2 , string operate, string outcome)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operate);
            field2.SendKeys(num2);
            calculate_button.Click();

            Assert.That(result.Text, Is.EqualTo(outcome));
            reset.Click();

        }
    }
}