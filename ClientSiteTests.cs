using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using FillingForm.Helpers;

namespace Client.Site.Tests
{

    class ClientSiteTests
    {
        private IWebDriver driver;
       /* 
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void VisibleIfTest()
        {
            IWebDriver driver = new ChromeDriver(".");

            // Launch the Form WebSite
            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=398");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }     
        }
        */
        [Test]

        public void OptionPriceTest()
        {
            IWebDriver driver = new ChromeDriver(".");

            // Launch the Form WebSite
            driver.Url = "https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=399";
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }

            FormHelper formHelper = new FormHelper();

            string dataPrice = formHelper.GetRadioOptionAttributeValue(driver, "Elements_1__ExtendedValue_0_", 0, "data-price");
            Assert.AreEqual(dataPrice, "100");

            string textValue = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(textValue, "0.00");         

            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 0);         
                        
        }

    }
}
