using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using FillingForm.Helpers;

namespace OptionPrice.Test
{
    [TestFixture]
    class OptionPriceTest
    {
        private IWebDriver driver;
        //private string id;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
        }
        [Test]
        public void VisibleIfTest()
        {

            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=399");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }
            FormHelper formHelper = new FormHelper();
        }
    }
}