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
    class NewLoadTest
    {
        private IWebDriver driver;
        private String id;

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
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
            driver.Url = Settings.TestConfig.EventUrl;

            Login();

            // Click setting button
            IWebElement element5 = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            element5.Click();

            // Click add button
            IWebElement element6 = driver.FindElement(By.Id("addEventItem_Submission_ADD"));
            element6.Click();

            Thread.Sleep(2000);

            IWebElement element7 = driver.FindElement(By.Id("addEventItem_Submission_ADD_BTN"));
            element7.Click();

            Thread.Sleep(2000);

            // Click edit form button
            var element8 = driver.FindElement(By.Id("tableEventItem_Submission")).FindElements(By.LinkText("Edit Form"));
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

            Thread.Sleep(1000);
        } /*
        [TearDown]
        public void TearDown()
        {
            // Click Testerevent to back
            IWebElement TesterEvent = driver.FindElement(By.LinkText("Tester Event"));
            TesterEvent.Click();

            // Click setting button
            //IWebElement SettingButton = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            //SettingButton.Click();

            //driver.Close();
        }*/

        //[TestCase("Test 5_1", 5, 1)]
        [TestCase ("Test 5_5", 5, 5)]
        public void LoadTest(string name, int fieldsPerSection, int sections)
        {
            // Insert name
            IWebElement element10 = driver.FindElement(By.CssSelector(".field-input"));
            element10.Clear();
            element10.SendKeys(name);
            for (int section = 0; section < sections; ++section)
            {
                // Add the section
                var element11 = driver.FindElement(By.CssSelector("i.fa-file-o"));
                element11.Click();

                for (int field = 0; field < fieldsPerSection; ++field)
                {
                    // Add the field
                    var element12 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
                    element12.Click();

                    // Label name Field 0_0---
                    string label = "Field " + section + "_" + field;
                    // Name property name 0_0---
                    string name1 = "name " + section + "_" + field;

                    // Insert value to Label & Name
                    IWebElement labelELement = driver.FindElements(By.CssSelector(".field-input-drop-shadow .field-input"))[0];
                    labelELement.SendKeys(label);

                    // Click advance button
                    IWebElement advancebutton = driver.FindElements(By.CssSelector(".field-input-drop-shadow .is-field-advaned"))[0];
                    advancebutton.Click();

                    IWebElement name1Element = driver.FindElements(By.CssSelector(".field-input-drop-shadow .field-input"))[7];
                    name1Element.SendKeys(name1);

                    Console.WriteLine(label);
                }

                var closeElements = driver.FindElements(By.CssSelector(".toast-body .close")); // Find Elements
                foreach(IWebElement close in closeElements)
                {
                    close.Click();
                }

                IWebElement savebutton = driver.FindElement(By.CssSelector("i.fa-save"));
                savebutton.Click();
            }
            
            // Click Testerevent to back
            IWebElement TesterEvent = driver.FindElement(By.LinkText("Tester Event"));
            TesterEvent.Click();

            // Click to purchase button
            var purchase = driver.FindElements(By.LinkText("Click here to purchase"));
            purchase[purchase.Count - 1].Click();

            // Click agree
            IWebElement agree = driver.FindElement(By.Id("mPolicyAgree"));
            agree.Click();

            // Matching the field --------------------------
            for (int field = 0; field < fieldsPerSection; ++field)
            {
                // Label name Field 0_0---
                string label = "Field " + 0 + "_" + field;
                // Name property name 0_0---
                string name1 = "name " + 0 + "_" + field;

                IWebElement matchlabel = driver.FindElements(By.CssSelector(".form-group > .control-label"))[field];
                Assert.AreEqual(label, matchlabel.Text);
            }

            for (int section = 1; section < sections; ++section)
            {                
                for (int field = 0; field < fieldsPerSection; ++field)
                {
                    // Label name Field 0_0---
                    string label = "Field " + section + "_" + field;
                    // Name property name 0_0---
                    string name1 = "name " + section + "_" + field;

                    int index = field + (fieldsPerSection * section);
                    IWebElement matchlabel = driver.FindElements(By.CssSelector(".form-group > .control-label"))[index];
                    Assert.AreEqual(label, matchlabel.Text);                    
                }

                // Click next buton
                IWebElement nextbutton = driver.FindElement(By.Id("nextPage"));
                nextbutton.Click();
            }
            // Matching the label
            IWebElement matchlabel1 = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual(name,matchlabel1.Text);
            
            // Click Testerevent to back
            IWebElement TesterEvent2 = driver.FindElement(By.LinkText("Tester Event"));
            TesterEvent2.Click();

            // Click setting button
            IWebElement setting = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            setting.Click();
            
             // CLick setting button
            driver.FindElement(By.Id("editEventItem_Submission_" + id + "_EDIT")).Click();

            Thread.Sleep(2000);

            // Click delete button
            IWebElement delete = driver.FindElement(By.Id("editEventItem_Submission_DELETE_BUTTON"));
            delete.Click();

            driver.SwitchTo().Alert().Accept();

        }

    }
}