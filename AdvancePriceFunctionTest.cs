using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using FillingForm.Helpers;
using System.Threading;

namespace Advance.Price.Function.Test
{
    [TestFixture]
    class AdvancePriceFunctionTest
    {
        private IWebDriver driver;
        //private string id;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
        }
        [Test]
        public void advancePriceFunTest()
        {

            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=407");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }
            FormHelper formHelper = new FormHelper();
            
            // Test for Number of Journals and Number of Catalogues fields 
            string JourValue = formHelper.GetTextFieldValue(driver, "Elements_2__Value");
            Assert.AreEqual(JourValue, "0");
            string CataValue = formHelper.GetTextFieldValue(driver, "Elements_3__Value");
            Assert.AreEqual(CataValue, "0");

            // Subtotal value
            string subTotalValue = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue, "0.00");

            // Click ship button
            formHelper.ClickRadioOption(driver, "Elements_4__ExtendedValue_0_", 1);

            // Subtotal value
            Assert.AreEqual(subTotalValue, "0.00");

            // Insert value of Journals
            formHelper.InsertValueJour(driver, "Elements_2__Value", 0);

            Thread.Sleep(5000);

            // Subtotal value 120
            string subTotalValue1 = formHelper.GetTextFieldValue(driver, "subTotal");
            //Thread.Sleep(2000);
            Assert.AreEqual(subTotalValue1, "120.00");

            // Click pickup button
            formHelper.ClickRadioOption(driver, "Elements_4__ExtendedValue_0_", 0);

            // Subtotal value 100
            string subTotalValue2 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue2, "100.00");

            // Click ship button
            formHelper.ClickRadioOption(driver, "Elements_4__ExtendedValue_0_", 1);

            // Subtotal value 120
            string subTotalValue3 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue3, "120.00");

            Thread.Sleep(2000);
            // Insert value catalogue
            formHelper.InsertValueCata(driver, "Elements_3__Value", 0);

            Thread.Sleep(2000);

            // Span text, delivery option text
            string spanValue = formHelper.GetRadioSpanText(driver, "Elements_4__ExtendedValue_0_", 1);
            Assert.AreEqual(spanValue, "Ship ($10 per book) - $30");
            // Subtotal value 120
            string subTotalValue4 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue4, "155.00");

            // GST & TOTAL value
            string GSTValue = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValue, "7.75");
            string totalValue = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValue, "162.75");            
            
            // Click on next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Test the value of review page
            string subTotal = formHelper.GetReviewPageText(driver, "elements_4__FormElementDefinitionId", 0);
            Assert.AreEqual(subTotal, "155.00");
            string GST = formHelper.GetReviewPageText2(driver, "elements_4__FormElementDefinitionId", 0);
            Assert.AreEqual(GST, "7.75");
            string TOTAL = formHelper.GetReviewPageText3(driver, "elements_4__FormElementDefinitionId", 0);
            Assert.AreEqual(TOTAL, "162.75");
        }
    }
}