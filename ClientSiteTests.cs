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
        [Test]
        public void PriceFunctionTest()
        {
            IWebDriver driver = new ChromeDriver(".");

            // Launch the Form WebSite
            driver.Url = "https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=400";
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }

            FormHelper formHelper = new FormHelper();
            
            string dataPriceOpt1 = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 0, "data-price");
            Assert.AreEqual(dataPriceOpt1, "100");
            string dataPriceCalculatedOpt1 = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 0, "data-price-calculated");
            Assert.AreEqual(dataPriceCalculatedOpt1, "100");

            string spanValue = formHelper.GetRadioSpanText(driver, "Elements_2__ExtendedValue_0_", 0);
            Assert.AreEqual(spanValue, "Opt 1 - $100");
            

            string dataPriceOpt2 = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 1, "data-price");
            Assert.AreEqual(dataPriceOpt2, "200");
            string dataPriceCalculatedOpt2 = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 1, "data-price-calculated");
            Assert.AreEqual(dataPriceCalculatedOpt2, "200");

            string spanValue2 = formHelper.GetRadioSpanText(driver, "Elements_2__ExtendedValue_0_", 1);
            Assert.AreEqual(spanValue2, "Opt 2 - $200");

            string textValue = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(textValue, "0.00");

            // Click on Student
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 1);

            string dataPriceOpt1Student = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 0, "data-price");
            Assert.AreEqual(dataPriceOpt1Student, "100");
            string dataPriceCalculatedOpt1Student = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 0, "data-price-calculated");
            Assert.AreEqual(dataPriceCalculatedOpt1Student, "50");

            string spanValue3 = formHelper.GetRadioSpanText(driver, "Elements_2__ExtendedValue_0_", 0);
            Assert.AreEqual(spanValue3, "Opt 1 - $50");

            string dataPriceOpt2Student = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 1, "data-price");
            Assert.AreEqual(dataPriceOpt2Student, "200");
            string dataPriceCalculatedOpt2Student = formHelper.GetRadioOptionAttributeValue(driver, "Elements_2__ExtendedValue_0_", 1, "data-price-calculated");
            Assert.AreEqual(dataPriceCalculatedOpt2Student, "100");

            string spanValue4 = formHelper.GetRadioSpanText(driver, "Elements_2__ExtendedValue_0_", 1);
            Assert.AreEqual(spanValue4, "Opt 2 - $100");

            string subTotalValue = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValue, "0.00");
            string GSTValue = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValue, "0.00");
            string totalValue = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValue, "0.00");

            // Click Option 1
            formHelper.ClickRadioOption(driver, "Elements_2__ExtendedValue_0_", 0);

            string subTotalValueOpt1 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValueOpt1, "50.00");
            string GSTValueOpt1 = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValueOpt1, "2.50");
            string totalValueOpt1 = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValueOpt1, "52.50");

            // Click on Staff
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 0);

            // Click Option 2
            formHelper.ClickRadioOption(driver, "Elements_2__ExtendedValue_0_", 1);

            string subTotalValueOpt2 = formHelper.GetTextFieldValue(driver, "subTotal");
            Assert.AreEqual(subTotalValueOpt2, "200.00");
            string GSTValueOpt2 = formHelper.GetTextFieldValue(driver, "gst");
            Assert.AreEqual(GSTValueOpt2, "10.00");
            string totalValueOpt2 = formHelper.GetTextFieldValue(driver, "total");
            Assert.AreEqual(totalValueOpt2, "210.00");

            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();
        }
    }
}
