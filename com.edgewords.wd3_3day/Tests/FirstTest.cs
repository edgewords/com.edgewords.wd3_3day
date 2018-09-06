using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

using com.edgewords.wd3_3day.PageObjects;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace com.edgewords.wd3_3day.Tests
{
    [TestFixture]
    public class FirstTest
    {
        IWebDriver driver;
        string baseURL = "https://www.edgewordstraining.co.uk/demo-site/";

        public static ExtentReports extent;
        public static ExtentTest test;
        public String dir;


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Add QA system info to html report
            extent.AddSystemInfo("Host Name", "My Laptop");
            extent.AddSystemInfo("Environment", "My QA Environment");
            extent.AddSystemInfo ("Username", "A Tester");
        }

        [TearDown]
        public void Teardown()
        {
            extent.Flush();
            driver.Quit();


        }
       
        [Test]
        public void TestMethod()
        {
            //Start Report
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            driver.Url = baseURL;

            SearchPage SearchPage = new SearchPage(driver);
            SearchPage.SearchForItem("cap")
                .ClickShopLink();

            Console.WriteLine("Cap added to basket");

            test.Log(Status.Info, "Here is a user info line!");

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(dir + "screenshot." + System.Drawing.Imaging.ImageFormat.Png);

            test.AddScreenCaptureFromPath("screenshot.png");

            test.Pass("My Test Passed!");
        }
    }
}
