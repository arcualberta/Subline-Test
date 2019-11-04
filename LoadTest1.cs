using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;
using System.Threading;

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
            element2.SendKeys("arctech@ualberta.ca");
            IWebElement element3 = driver.FindElement(By.Id("Password"));
            element3.SendKeys("p4ssword!");

            // Click login button to log in
            IWebElement element4 = driver.FindElement(By.Id("logInButton"));
            element4.Click();
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
            driver.Url = "https://subline-test.artsrn.ualberta.ca/48";

            Login();
            
            // Click setting button
            IWebElement element5 = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            element5.Click();
            /*
            // Click add button
            IWebElement element6 = driver.FindElement(By.Id("addEventItem_Submission_ADD"));
            element6.Click();

            Thread.Sleep(2000);

            IWebElement element7 = driver.FindElement(By.Id("addEventItem_Submission_ADD_BTN"));
            element7.Click();*/

            Thread.Sleep(2000);

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
            
        } 
        [TearDown]
        public void TearDown()
        {
            // Click Testerevent to back
            IWebElement TesterEvent = driver.FindElement(By.LinkText("Tester Event"));
            TesterEvent.Click();

            // Click setting button
            IWebElement SettingButton = driver.FindElement(By.CssSelector(".navbar-nav > .nav-item"));
            SettingButton.Click();


            //driver.Close();
        }

        [TestCase ("Test 5_1", 5, 1)]
        //[TestCase ("Test 5_2", 5, 5)]
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

                for(int field = 0; field < fieldsPerSection; ++field)
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
                    IWebElement name1Element = driver.FindElements(By.CssSelector(".field-input-drop-shadow .field-input"))[3];
                    name1Element.SendKeys(name1);


    
                    Console.WriteLine(label);
                }
            }
        }
    }
}