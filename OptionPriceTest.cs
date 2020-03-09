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
        public void optionPriceTest()
        {
            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=399");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }
            FormHelper formHelper = new FormHelper();

            // Test for "SUBTOTAL", "GST", "TOTAL" 
            string subTotalValue = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue, "0.00");
            string GSTValue = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValue, "0.00");
            string totalValue = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValue, "0.00");

            // Click Option 1
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 0);

            // Test for "SUBTOTAL", "GST", "TOTAL" for Opt 1
            string subTotalValueOpt1 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValueOpt1, "100.00");
            string GSTValueOpt1 = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValueOpt1, "5.00");
            string totalValueOpt1 = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValueOpt1, "105.00");

            // Click Option 2
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 1);

            // Test for "SUBTOTAL", "GST", "TOTAL" for Opt 1
            string subTotalValueOpt2 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValueOpt2, "200.00");
            string GSTValueOpt2 = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValueOpt2, "10.00");
            string totalValueOpt2 = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValueOpt2, "210.00");

            // Click on next button
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Test the value of total
            string resultValue = formHelper.GetResultText(driver, "elements_1__FormElementDefinitionId", 0);
            Assert.AreEqual(resultValue, "210.00");
        }
    }
}
