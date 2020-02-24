using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using FillingForm.Helpers;

namespace Visible.OptionPrice.PriceFunction.Test
{
    [TestFixture]
    class VisibleTest
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

            driver.Url = ("https://subline-dev.artsrn.ualberta.ca/Registration/Create/54?eventItemDef=398");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }
            FormHelper formHelper = new FormHelper();

            // Description 1 Visible Test
            string Des1NotVisibleTest = formHelper.IfVisible(driver, "desc1_5792");
            Assert.AreEqual(Des1NotVisibleTest, "display: none;");

            // Description 2 Visible Test
            string Des2NotVisibleTest = formHelper.IfVisible(driver, "desc2_5793");
            Assert.AreEqual(Des2NotVisibleTest, "display: none;");

            // Click on Opt 1
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 0);

            // Description 1 Visible Test
            string Des1VisibleTest = formHelper.IfVisible(driver, "desc1_5792");
            Assert.AreEqual(Des1VisibleTest, "display: block;");

            // Description 2 Not Visible Test
            //string Des2NotVisibleTest2 = formHelper.IfVisible(driver, "desc2_5793");
            Assert.AreEqual(Des2NotVisibleTest, "display: none;");

            // Click on Opt 2
            formHelper.ClickRadioOption(driver, "Elements_1__ExtendedValue_0_", 1);

            // Description 1 Not Visible Test
            //string Des1NotVisibleTest = formHelper.IfVisible(driver, "desc1_5792");
            Assert.AreEqual(Des1NotVisibleTest, "display: none;");

            // Description 2 Visible Test
            string Des2VisibleTest2 = formHelper.IfVisible(driver, "desc2_5793");
            Assert.AreEqual(Des2VisibleTest2, "display: block;");



        }

    }
}
