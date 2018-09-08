using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace com.edgewords.wd3_3day.PageObjects
{
    public class SearchPage
    {
        private IWebDriver _driver;

        //Constructor to set driver object
        public SearchPage(IWebDriver driver) => _driver = driver;

        // Set our Locators for the elements on the Web Page
        public IWebElement SearchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        public IWebElement ShopLink => _driver.FindElement(By.LinkText("Shop"));


        // Helper Methods
        public SearchPage SearchForItem (string item)
        {
            SearchField.Clear();
            SearchField.Click();
            SearchField.SendKeys(item + Keys.Return);

            return this;
        }

        public SearchPage ClickShopLink ()
        {
            ShopLink.Click();
            return this;
        }
    }
}
