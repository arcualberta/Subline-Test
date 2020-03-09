using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using System.Threading;
using FindForm.Configuration;

namespace Full.Chain.Registration.Test
{
    [TestFixture]
    class FullRegistrationTest
    {
        private IWebDriver driver;
        private string id;

        public void Login()
        {
            // Click login button
            IWebElement element1 = driver.FindElement(By.CssSelector(".nav-item"));
            element1.Click();

            // Inserting login credentials
            IWebElement element2 = driver.FindElement(By.Id("Email"));
            element2.SendKeys(Settings.UserName);
            IWebElement element3 = driver.FindElement(By.Id("Password"));
            element3.SendKeys(Settings.Password);

            // Click login button to log in
            IWebElement element4 = driver.FindElement(By.Id("logInButton"));
            element4.Click();

            // Click setting button
            IWebElement element5 = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            element5.Click();

            // Click add button
            IWebElement element6 = driver.FindElement(By.Id("addEventItem_Registration_ADD"));
            element6.Click();
        }
            


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
            driver.Url = Settings.TestConfig.EventUrl;

            Login();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Thread.Sleep(2000);

            IWebElement element7 = driver.FindElement(By.Id("addEventItem_Registration_ADD_BTN"));
            element7.Click();

            Thread.Sleep(1000);

            // Click edit form button
            var element8 = driver.FindElements(By.LinkText("Edit Form"));
            element8[element8.Count - 1].Click();

            // To find the same page further
            string siteUrl = driver.Url;
            int lastSlash = siteUrl.LastIndexOf("/");
            id = siteUrl.Substring(lastSlash + 1);
            
            // Click delete section
            IWebElement element9 = driver.FindElement(By.CssSelector("i.fa-trash-o"));
            element9.Click();

            Thread.Sleep(4000);

            // Click remove button
            IWebElement remove = driver.FindElement(By.CssSelector("button.btn-danger"));
            remove.Click();
        }

        [Test]
        public void Registrationtest()
        {
            // Name of the form
            var element1 = driver.FindElements(By.CssSelector(".field-input"));
            element1[0].Clear();
            element1[0].SendKeys("Test Registration");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Text Box");

            // Insert label name
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[2].SendKeys("Name");

            // Click advance button
            IWebElement advancebutton = driver.FindElement(By.CssSelector(".custom-control-label"));
            advancebutton.Click();

            // Insert name property
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[11].SendKeys("name");

            // Click required field
            IWebElement element6 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element6.Click();
            
            //Email field-----------------            
            // Click add field button
            IWebElement element7 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element7.Click();

            // Select dropdown menu
            var dropdown2 = driver.FindElements(By.CssSelector("select.field-type-input"))[1];
            var element8 = new SelectElement(dropdown2);
            element8.SelectByText("Email Field");

            // Insert label name
            var element9 = driver.FindElements(By.CssSelector(".field-input"));
            element9[16].SendKeys("Email");

            // Click advance button
            var advancebutton2 = driver.FindElements(By.CssSelector(".custom-control-label"));
            advancebutton2[6].Click();

            // Insert name property
            //var element10 = driver.FindElements(By.CssSelector(".field-input"));
            //element10[27].SendKeys("email");

            // Click required button
            var element11 = driver.FindElements(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11[1].Click();

            // Click add field button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element12.Click();
            
            // Tickets number field-----------------------
            // Select dropdown menu
            var dropdown3 = driver.FindElements(By.CssSelector("select.field-type-input"))[2];
            var element13 = new SelectElement(dropdown3);
            element13.SelectByText("Number Field");
            
            // Insert label name
            var element14 = driver.FindElements(By.CssSelector(".field-input"));
            element14[9].SendKeys("Tickets");

            // Click advance button
            var element15 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element15[5].Click();

            // Insert price value 1
            var element16 = driver.FindElements(By.CssSelector(".field-input"));
            element16[11].SendKeys("1");

            // Insert name property
            var element17 = driver.FindElements(By.CssSelector(".field-input"));
            element17[20].SendKeys("tickets");

            // Click required button
            var element18 = driver.FindElements(By.CssSelector(".is-field-required > label.custom-control-label"));
            element18[2].Click();

            // Click the save button
            IWebElement element19 = driver.FindElement(By.CssSelector("i.fa-save"));
            element19.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click x on pop up
            IWebElement element20 = driver.FindElement(By.CssSelector(".toast button.close"));
            element20.Click();

            // Click setting button
            var element21 = driver.FindElements(By.CssSelector(".nav-link"));
            element21[2].Click();

            // Insert email template
            var element22 = driver.FindElements(By.CssSelector(".ql-editor"));
            element22[0].Clear();
            element22[0].SendKeys("Dear @Model[\"name\"], @Model[\"RegistrationReceipt\"]");

            // Click form button to back
            var element23 = driver.FindElements(By.CssSelector(".nav-link"));
            element23[1].Click();

            // Click the save button
            IWebElement element24 = driver.FindElement(By.CssSelector("i.fa-save"));
            element24.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click x on pop up
            IWebElement element25 = driver.FindElement(By.CssSelector(".toast button.close"));
            element25.Click();

            // Click form button to back
            var element26 = driver.FindElements(By.CssSelector(".nav-item"));
            element26[0].Click();

            // Go to form page
            driver.Url = "https://subline-test.artsrn.ualberta.ca/48";
            //var element50 = driver.FindElements(By.CssSelector(".nav-link"));
            //element50[0].Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click the registration form
            var element27 = driver.FindElements(By.CssSelector(".form-link a"));
            element27[2].Click();

            // Click agree button
            IWebElement element28 = driver.FindElement(By.Id("mPolicyAgree"));
            element28.Click();

            // Click on the next button
            //driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Check required field text
            //IWebElement result = driver.FindElement(By.Id("Elements_0__Value-error"));
            //Assert.AreEqual("This field is required.", result.Text);
            //IWebElement result2 = driver.FindElement(By.Id("Elements_1__Value-error"));
            //Assert.AreEqual("This field is required.", result2.Text);

            // Insert name
            IWebElement element29 = driver.FindElement(By.Id("Elements_0__Value"));
            element29.SendKeys("Abdul Malek");

            //driver.FindElement(By.Id("Elements_0__Value")).SendKeys("Malek");

            // Insert wrong email id to check error
            //IWebElement element30 = driver.FindElement(By.Id("Elements_1__Value"));
            //element30.SendKeys("malek4g");

            // Click on the next button
            //driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Check the error for email id
            //IWebElement result3 = driver.FindElement(By.Id("Elements_1__Value-error"));
            //Assert.AreEqual("Invalid", result3.Text);

            // Insert email id
            IWebElement element31 = driver.FindElement(By.Id("Elements_1__Value"));
            element31.Clear();
            element31.SendKeys("malek4g@gmail.com");

            // Insert negative value to check the error in tickets
            //IWebElement element32 = driver.FindElement(By.Id("Elements_2__Value"));
            //element32.Clear();
            //element32.SendKeys("-5");

            // Click next button
            //driver.FindElement(By.CssSelector("input[value = 'Next']")).Click();

            // Check the error of negative value
            //IWebElement result4 = driver.FindElement(By.Id("Elements_2__Value-error"));
            //Assert.AreEqual("Please enter a value greater than or equal to 0.", result4.Text);

            // Insert valid ticket number
            IWebElement element33 = driver.FindElement(By.Id("Elements_2__Value"));
            element33.Clear();
            element33.SendKeys("5");

         
            // Click next button
            //driver.FindElement(By.CssSelector("input[value = 'Next']")).Click();

            // Store value for matching
            IWebElement element34 = driver.FindElement(By.Id("Elements_0__Value"));
            string Elements_0__Value = element34.GetAttribute("value");

            IWebElement element35 = driver.FindElement(By.Id("Elements_1__Value"));
            string Elements_1__Value = element35.GetAttribute("value");

            IWebElement element36 = driver.FindElement(By.Id("Elements_2__Value"));
            string Elements_2__Value = element36.GetAttribute("value");
            element36.SendKeys(Keys.Tab);

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Thread.Sleep(1000);

            IWebElement element37 = driver.FindElement(By.Id("total"));
            string total = element37.GetAttribute("value");

            // Click on the Submit button
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Matching with the input value
            string result5 = driver.FindElement(By.XPath("//table/tbody/tr[contains(td/text(), 'Name')]/td[2]")).Text;
            Assert.AreEqual(Elements_0__Value, result5);

            string result6 = driver.FindElement(By.XPath("//table/tbody/tr[contains(td/text(), 'Email')]/td[2]")).Text;
            Assert.AreEqual(Elements_1__Value, result6);

            string result7 = driver.FindElement(By.XPath("//table/tbody/tr[contains(td/text(), 'Tickets')]/td[2]")).Text;
            Assert.AreEqual(Elements_2__Value, result7);

            decimal decimalTotal = decimal.Parse(total);
            Assert.AreEqual((1m * 5m) * 1.05m, decimalTotal);

            //string result8 = driver.FindElement(By.XPath("//table/tbody/tr[td/b/text()='Total']/td[2]/b")).Text;
            //Assert.AreEqual(total, result8);
            
            // Click on the Submit button
            driver.FindElement(By.CssSelector("input[value ='Proceed to Payment']")).Click();
                      
            // Cardholder Name id cardholder
            driver.FindElement(By.Id("cardholder")).SendKeys("David Pitter");

            // Card Number id pan
            driver.FindElement(By.Id("pan")).SendKeys("5454545454545454");

            // Expiry Date id exp_date
            driver.FindElement(By.Id("exp_date")).SendKeys("1222");

            // Process Transaction id buttonProcessCC
            driver.FindElement(By.Id("buttonProcessCC")).Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Thread.Sleep(5000);

            // Matching with the input value
            string result8 = driver.FindElement(By.XPath("//table/tbody/tr[contains(th/text(), 'Name')]/td[1]")).Text;
            Assert.AreEqual(Elements_0__Value, result8);

            string result9 = driver.FindElement(By.XPath("//table/tbody/tr[contains(th/text(), 'Email')]/td[1]")).Text;
            Assert.AreEqual(Elements_1__Value, result9);

            string result10 = driver.FindElement(By.XPath("//table/tbody/tr[contains(th/text(), 'Tickets')]/td[1]")).Text;
            Assert.AreEqual(Elements_2__Value, result10);

            // Click done button
            var element38 = driver.FindElements(By.CssSelector("button.btn"));
            element38[1].Click();

            // Click to login- for inactive the form
            Login();

            // Click setting button
            IWebElement element40 = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            element40.Click();

            // CLick setting button
            driver.FindElement(By.Id("editEventItem_Registration_" + id + "_EDIT")).Click();

            Thread.Sleep(3000);

            var dropdown4 = driver.FindElement(By.Id("editEventItem_Registration_STATUS"));
            var selectelement5 = new SelectElement(dropdown4);
            selectelement5.SelectByText("Inactive");

            // Click on save button
            var element39 = driver.FindElements(By.CssSelector("#editEventItem_Registration button.btn"));
            element39[1].Click();

            //driver.FindElements(By.CssSelector("#editEventItem_Registration button.btn"))[1].Click();

            
            //driver.Close();
        }
    }
}
