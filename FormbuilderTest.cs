using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace FindForm.SubmitForm.Formbuilder
{
    [TestFixture]
    class FormbuilderTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(".");
            driver.Url = "https://subline-test.artsrn.ualberta.ca/admin?returnUrl=~%2F48&eventId=48";

            // Inserting login credentials
            IWebElement element1 = driver.FindElement(By.Id("Email"));
            element1.SendKeys("arctech@ualberta.ca");
            IWebElement element2 = driver.FindElement(By.Id("Password"));
            element2.SendKeys("p4ssword!");

            //Click login button
            IWebElement element3 = driver.FindElement(By.Id("logInButton"));
            element3.Click();
            driver.Url = "https://subline-test.artsrn.ualberta.ca/FormEditor/Edit/373";

            // Click delete section
            IWebElement element4 = driver.FindElement(By.CssSelector("i.fa-trash-o"));
            element4.Click();
        }
        /*
        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
        */
        [Test]
        public void CreateTextboxTest()
        {                      
            // Insert form name
            IWebElement element7 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element7.Clear();
            element7.SendKeys("Text Area");

            // Click the section button to add section
            IWebElement element5 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element5.Click();

            // Click to add field button
            IWebElement element6 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element6.Click();
            
            // Select dropdown menu
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Text Area");

            // Insert the label
            var element8 = driver.FindElements(By.CssSelector(".section .field-input"));
            element8[0].SendKeys("Test Elements");
            //IWebElement element8 = driver.FindElement(By.CssSelector(".field-input:nth-child(2)"));
            //element8.SendKeys("Text Box 1");

            // Insert description
            var element9 = driver.FindElements(By.CssSelector(".section .field-input"));
            element9[1].SendKeys("This is a test");
            //IWebElement element9 = driver.FindElement(By.CssSelector("textarea.field-input:nth-child(1)"));
            //element9.SendKeys("This is a test");

            // Insert name
            var element10 = driver.FindElements(By.CssSelector(".section .field-input"));
            element10[3].SendKeys("Test 1");
            //IWebElement element10 = driver.FindElement(By.CssSelector(".field-input:nth-child(4)"));
            //element10.SendKeys("Test 1");

            // Click the save button
            IWebElement element11 = driver.FindElement(By.CssSelector("i.fa-save"));
            element11.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                        
            // Check the pop up text
            IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element12 = driver.FindElement(By.CssSelector("button.close"));
            element12.Click();

            // Click in advance button
            //var element17 = driver.FindElements(By.CssSelector(".section custom-control-label"));
            //element17[0].Click();
            IWebElement element17 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element17.Click();

            // Insert default value
            IWebElement element18 = driver.FindElement(By.CssSelector("form.section-advanced textarea.field-input"));
            element18.SendKeys("Test Value 1");
            //var element18 = driver.FindElements(By.CssSelector(".section .field-input"));
            //element18[4].SendKeys("Test Value");

            // Insert number in limitmax box
            var element19 = driver.FindElements(By.CssSelector(".section .field-input"));
            element19[3].Clear();
            element19[3].SendKeys("250");

            // Click radio button
            IWebElement element20 = driver.FindElement(By.CssSelector("input[value = 'words']"));
            element20.Click();

            // Click required button
            //var element21 = driver.FindElements(By.CssSelector(".section .field-input"));
            //element21[1].Click();
            IWebElement element21 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element21.Click();

            // Click the save button
            IWebElement element22 = driver.FindElement(By.CssSelector("i.fa-save"));
            element22.Click();
            
            // Form page
            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element13 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element13.Click();
            /*
            // Match the title of the form
            IWebElement element14 = driver.FindElement(By.CssSelector("#page-content h2"));
            Assert.AreEqual("Test Form", element14.Text);

            //IWebElement element15 = driver.FindElement(By.CssSelector("label"));
            //Assert.AreEqual("Test Elements", element15.Text);

            IWebElement element16 = driver.FindElement(By.CssSelector(".control-field > p"));
            Assert.AreEqual("This is a test", element16.Text);*/

            driver.Close();
        }
        /*
        [Test]
        public void TextboxWordcountTest()
        {
            Assert.Fail();
        }*/

        [Test]
        public void DatefieldTest()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("Date Field Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Date Field");

            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".section .field-input"));
            element4[0].SendKeys("Test Date");
            //IWebElement element8 = driver.FindElement(By.CssSelector(".field-input:nth-child(2)"));
            //element8.SendKeys("Text Box 1");

            // Insert description
            var element5 = driver.FindElements(By.CssSelector(".section .field-input"));
            element5[1].SendKeys("This is a test Date");
            //IWebElement element9 = driver.FindElement(By.CssSelector("textarea.field-input:nth-child(1)"));
            //element9.SendKeys("This is a test");

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".section .field-input"));
            element6[3].SendKeys("Test Date Form");
            //IWebElement element10 = driver.FindElement(By.CssSelector(".field-input:nth-child(4)"));
            //element10.SendKeys("Test 1");

            // Click in advance button            
            IWebElement element7 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element7.Click();

            // Insert date
            var element8 = driver.FindElements(By.CssSelector(".section .field-input"));
            element8[2].Click();
            IWebElement element9 = driver.FindElement(By.CssSelector(".react-datepicker__day--003"));
            element9.Click();

            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Check the pop up text
            IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector("button.close"));
            element13.Click();

            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();
        }

        [Test]
        public void CheckBoxTest()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("Checkbox Field Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Checkbox Set");

            // Click option field
            IWebElement element15 = driver.FindElement(By.CssSelector("button.form-control"));
            element15.Click();

            // Insert option field
            var element16 = driver.FindElements(By.CssSelector(".form-control"));
            element16[2].SendKeys("Checkbox Option");

            // Click price button
            var element17 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element17[3].Click();

            // Insert the price
            var element20 = driver.FindElements(By.CssSelector(".form-control"));
            element20[3].SendKeys("10");

            // Click date range button
            var element18 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element18[4].Click();

            // Put the date
            var element21 = driver.FindElements(By.CssSelector(".field-input"));
            element21[2].Click();
            var element22 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element22[3].Click();

            var element23 = driver.FindElements(By.CssSelector(".field-input"));
            element23[3].Click();
            var element24 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element24[30].Click();

            // Click limit button
            var element19 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element19[5].Click();

            // Put limit value
            var element25 = driver.FindElements(By.CssSelector(".form-control"));
            element25[6].SendKeys("5");


            // Click X button
            //IWebElement element17 = driver.FindElement(By.CssSelector("button.close"));
            //element17.Click();
            
            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[4].SendKeys("Checkbox Test");
            
            // Insert description
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[5].SendKeys("This is a Checkbox test");

            // Click in advance button            
            IWebElement element7 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element7.Click();

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".field-input"));
            element6[14].SendKeys("Test Checkbox field");       
                                    
            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Check the pop up text
            //IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            //Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector(".toast button.close"));
            element13.Click();
            
            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();
        }
        
        [Test]
        public void RadiobuttonTest()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("Radio Button Field Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Radio Button Set");

            // Click option field
            IWebElement element15 = driver.FindElement(By.CssSelector("button.form-control"));
            element15.Click();

            // Insert option field
            var element16 = driver.FindElements(By.CssSelector(".form-control"));
            element16[2].SendKeys("Radio Button Option");

            // Click price button
            var element17 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element17[3].Click();

            // Insert the price
            var element20 = driver.FindElements(By.CssSelector(".form-control"));
            element20[3].SendKeys("10");
            
            // Click date range button
            var element18 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element18[4].Click();

            // Put the date
            var element21 = driver.FindElements(By.CssSelector(".field-input"));
            element21[2].Click();
            var element22 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element22[3].Click();

            var element23 = driver.FindElements(By.CssSelector(".field-input"));
            element23[3].Click();
            var element24 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element24[30].Click();

            // Click limit button
            var element19 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element19[5].Click();

            // Put limit value
            var element25 = driver.FindElements(By.CssSelector(".form-control"));
            element25[6].SendKeys("5");
            
            // Click X button
            //IWebElement element17 = driver.FindElement(By.CssSelector("button.close"));
            //element17.Click();

            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[4].SendKeys("Radio Button Test");

            // Insert description
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[5].SendKeys("This is a Radio Button test");

            // Click in advance button            
            IWebElement element7 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element7.Click();

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".field-input"));
            element6[14].SendKeys("Test Radio Button field");

            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Check the pop up text
            //IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            //Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector(".toast button.close"));
            element13.Click();

            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();
        }
        
        [Test]
        public void DropdownTest()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("Drop Down Field Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Drop Down List");

            // Click option field
            IWebElement element15 = driver.FindElement(By.CssSelector("button.form-control"));
            element15.Click();

            // Insert option field
            var element16 = driver.FindElements(By.CssSelector(".form-control"));
            element16[2].SendKeys("Drop Down Option");

            // Click price button
            var element17 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element17[2].Click();
            
            // Insert the price
            var element20 = driver.FindElements(By.CssSelector(".form-control"));
            element20[3].SendKeys("10");

            // Click date range button
            var element18 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element18[3].Click();
            
            // Put the date
            var element21 = driver.FindElements(By.CssSelector(".field-input"));
            element21[2].Click();
            var element22 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element22[3].Click();

            var element23 = driver.FindElements(By.CssSelector(".field-input"));
            element23[3].Click();
            var element24 = driver.FindElements(By.CssSelector(".react-datepicker__day"));
            element24[30].Click();
            
            // Click limit button
            var element19 = driver.FindElements(By.CssSelector(".custom-control-label"));
            element19[4].Click();
            
            // Put limit value
            var element25 = driver.FindElements(By.CssSelector(".form-control"));
            element25[6].SendKeys("5");
            
            // Click X button
            //IWebElement element17 = driver.FindElement(By.CssSelector("button.close"));
            //element17.Click();

            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[4].SendKeys("Drop Down Test");

            // Insert description
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[5].SendKeys("This is a Drop Down test");

            // Click in advance button            
            IWebElement element7 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element7.Click();

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".field-input"));
            element6[14].SendKeys("Test Drop Down field");

            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Check the pop up text
            //IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            //Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector(".toast button.close"));
            element13.Click();

            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();
        }

        [Test]
        public void SubformTest()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("Subform Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Sub Form List");

            // Click in advance button            
            IWebElement element9 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element9.Click();

            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[1].SendKeys("Sub Form Test");

            // Insert description
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[2].SendKeys("This is a Sub Form test");

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".field-input"));
            element6[14].SendKeys("Test Sub Form field");

            // Insert range min
            var element7 = driver.FindElements(By.CssSelector(".field-input"));
            element7[3].Clear();
            element7[3].SendKeys("1");

            // Insert name
            var element8 = driver.FindElements(By.CssSelector(".field-input"));
            element8[4].Clear();
            element8[4].SendKeys("10");

            var dropdown2 = driver.FindElement(By.CssSelector("select.field-input:nth-child(1)"));
            var element10 = new SelectElement(dropdown2);
            element10.SelectByText("Subform Item");
                      
            // Click X button
            //IWebElement element17 = driver.FindElement(By.CssSelector("button.close"));
            //element17.Click();
            
            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Check the pop up text
            //IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            //Assert.AreEqual("Form saved successfully.", result.Text);
            
            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector(".toast button.close"));
            element13.Click();
            
            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();

        }

        [Test]
        public void TestHTMLfield()
        {
            // Insert form name title
            IWebElement element1 = driver.FindElement(By.CssSelector(".field-input:nth-child(1)"));
            element1.Clear();
            element1.SendKeys("HTML Field Test");

            // Click the section button to add section
            IWebElement element2 = driver.FindElement(By.CssSelector("i.fa-file-o"));
            element2.Click();

            // Click to add field button
            IWebElement element3 = driver.FindElement(By.CssSelector("i.fa-plus-square-o"));
            element3.Click();

            // Select dropdown menu date field
            var dropdown = driver.FindElement(By.CssSelector(".field-type-input"));
            var selectelement = new SelectElement(dropdown);
            selectelement.SelectByText("Html");

            // Click in advance button            
            IWebElement element7 = driver.FindElement(By.CssSelector("label.custom-control-label"));
            element7.Click();
            
            // Insert the label
            var element4 = driver.FindElements(By.CssSelector(".field-input"));
            element4[1].SendKeys("HTML Test");

            // Insert content
            var element5 = driver.FindElements(By.CssSelector(".field-input"));
            element5[2].SendKeys(@"<html>
            <meta charset = ""UTF-8"">
            <meta name = ""viewport"" content = ""width=device-width, initial-scale=1"">
            <link rel = ""stylesheet"" href = ""/w3css/3/w3.css"">
            <body>

            <!--Navigation-->
            <nav class=""w3-bar w3-black"">
            <a href = ""#home"" class=""w3-button w3-bar-item"">Home</a>
            <a href = ""#band"" class=""w3-button w3-bar-item"">Band</a>
            <a href = ""#tour"" class=""w3-button w3-bar-item"">Tour</a>
            <a href = ""#contact"" class=""w3-button w3-bar-item"">Contact</a>
            </nav>

            </body>
            </html>");            

            // Insert name
            var element6 = driver.FindElements(By.CssSelector(".field-input"));
            element6[11].SendKeys("Test HTML field");
            
            // Click the save button
            //IWebElement element10 = driver.FindElement(By.CssSelector("i.fa-save"));
            //element10.Click();

            // Time delay for loading page
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Click required button
            IWebElement element11 = driver.FindElement(By.CssSelector(".is-field-required > label.custom-control-label"));
            element11.Click();

            // Click the save button
            IWebElement element12 = driver.FindElement(By.CssSelector("i.fa-save"));
            element12.Click();

            // Time delay for loading page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Check the pop up text
            //IWebElement result = driver.FindElement(By.CssSelector(".toast-body > .flex-grow-1"));
            //Assert.AreEqual("Form saved successfully.", result.Text);

            // Click on X
            IWebElement element13 = driver.FindElement(By.CssSelector(".toast button.close"));
            element13.Click();

            driver.Url = "https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=373";
            IWebElement element14 = driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)"));
            element14.Click();

        }

    }
            
}


