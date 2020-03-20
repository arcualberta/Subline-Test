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

namespace Required.If.Test
{
    [TestFixture]
    class RequiredIfTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
        }
        [Test]
        public void RequiredTest()
        {
            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=408");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }
            FormHelper formHelper = new FormHelper();

            // Click next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            string checkErrortxt = formHelper.CheckErrorVisible(driver, "field-validation-error");
            Assert.AreEqual(checkErrortxt, "Cannot be empty.");
                        
            // Check Cannot be empty
            //IWebElement result = driver.FindElement(By.ClassName("field-validation-error"));
            //Assert.AreEqual("Cannot be empty.", result.Text);

            // Reload the page
            driver.Navigate().Refresh();
            // Click Opt 1
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 0);
            // Click next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Check the error text
            string checkErrorText = formHelper.GetRadioSpanText(driver, "Elements_2__Value-error", 0);
            Assert.AreEqual(checkErrorText, "This field is required.");

            // Insert value
            formHelper.InsertValueInput1(driver, "Elements_2__Value", 0);

            // Required message check
            string requiredMessageCheck = formHelper.CheckErrorTextNotVisible(driver, "Elements_2__Value");
            Assert.AreEqual(requiredMessageCheck, "false");

            // Click next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Check back button
            string checkBackButton = formHelper.CheckBackButtonVisible(driver, "btn");
            Assert.AreEqual(checkBackButton, "Back");

            // Click back
            driver.FindElement(By.CssSelector("input[value ='Back']")).Click();
            // Click Opt 2
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 1);
            // Click next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Check the error text
            string checkErrorText2 = formHelper.GetRadioSpanText(driver, "Elements_3__Value-error", 0);
            Assert.AreEqual(checkErrorText2, "This field is required.");

            // Insert value
            formHelper.InsertValueInput2(driver, "Elements_3__Value", 0);

            // Required message check
            string requiredMessageCheck2 = formHelper.CheckErrorTextNotVisible(driver, "Elements_3__Value");
            Assert.AreEqual(requiredMessageCheck2, "false");

            driver.Navigate().Refresh();

            // Click Opt 3
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 2);
            // Click next
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();
            // Check back button
            string checkBackButtonAgain = formHelper.CheckBackButtonVisible(driver, "btn");
            Assert.AreEqual(checkBackButtonAgain, "Back");
        }
    }
}