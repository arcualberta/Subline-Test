using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

namespace FindForm.SubmitForm
{

    class FindElementCommands
    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver(".");
            
            // Launch the Form WebSite
            driver.Url = ("https://subline-test.artsrn.ualberta.ca/Registration/Create/48?eventItemDef=369");
            IWebElement element = driver.FindElement(By.Id("mPolicyAgree"));
            if (element != null)
            {
                element.Click();
            }

            // First Name
            IWebElement element1 = driver.FindElement(By.Name("Elements[0].Value"));
            //IWebElement element2.Clear();
            element1.SendKeys("Abdul");

            // Insert the Date
            IWebElement datepicker = driver.FindElement(By.Name("Elements[1].DateValue"));
            //var today = DateTime.Today;
            //datepicker.Click();

            /*Actions action = new Actions(driver);
            action.MoveByOffset(700, 383).Perform();
            action.Click(); */

            // Clicking the calendar to popup & Click the date
            Actions action = new Actions(driver);
            action.MoveToElement(datepicker, datepicker.Size.Width - 10, datepicker.Size.Height - 15).Click().SendKeys(Keys.ArrowDown + Keys.ArrowRight).SendKeys(Keys.Return).Perform();

            // Date picker
            /* 
            datepicker.SendKeys("2019");//today.Year.ToString());
            datepicker.SendKeys(Keys.Tab);
            datepicker.SendKeys("02");//today.Month.ToString());
            //datepicker.SendKeys(Keys.Tab);
            datepicker.SendKeys(today.Day.ToString());
            //datepicker.Click(); */

            // Specific location click on web page               
            //action.MoveByOffset(-150, 150).Click().Build().Perform();

            // Insert the Number of Adult Tickets 
            IWebElement element2 = driver.FindElement(By.Id("Elements_2__Value"));
            element2.Clear();
            element2.SendKeys("5");

            // Radio Button
            IWebElement element7 = driver.FindElement(By.CssSelector("input[value = 'Two']"));
            //element.Clear();
            element7.Click();

            // Dropdown selection
            var dropdown = driver.FindElement(By.Name("Elements[5].Value"));
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByValue("Pick this one");

            // Subform button clicker Add Tickets
            IWebElement element20 = driver.FindElement(By.CssSelector("span.fa-plus"));
            element20.Click();

            // Enter the subform value
            var elements40 = driver.FindElements(By.CssSelector(".panel-tickets-section  input[data-name = 'extraTickets']"));
            Assert.AreEqual(1, elements40.Count);

            elements40[0].Clear();
            elements40[0].SendKeys("2");
            element20.Click();


            // Remove Tickets Button
            //IWebElement element21 = driver.FindElement(By.CssSelector("span.fa-times"));
            //element21.Click();
            //driver.SwitchTo().Alert().Accept();

            //action.SendKeys(Keys.Enter).SendKeys(Keys.Return).Perform();
            //.Click(); //Sendkeys(Keys.Enter).Sendkeys(Keys.Return);

            //IWebElement element20 = driver.FindElement(By.XPath("//span[@class=' fa-plus']"));
            //element20.Click();

            //string total = element.Text;
            //Assert.AreEqual(total, element7.Text);

            /* // Store value for matching
            IWebElement element11 = driver.FindElement(By.Id("Elements_0__Value"));
            string Elements_0__Value = element11.GetAttribute("value");

            IWebElement element12 = driver.FindElement(By.Id("Elements_2__Value"));
            string Elements_2__Value = element12.GetAttribute("value");

            IWebElement element10 = driver.FindElement(By.Id("total"));
            string total = element10.GetAttribute("value");

            // Click on the Submit button
            driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

            // Matching with the input value
            string result0 = driver.FindElement(By.XPath("//table/tbody/tr[contains(td/text(), 'Name')]/td[2]")).Text;
            Assert.AreEqual(Elements_0__Value, result0);

            string result1 = driver.FindElement(By.XPath("//table/tbody/tr[contains(td/text(), 'Tickets')]/td[2]")).Text;
            Assert.AreEqual(Elements_2__Value, result1);

            string result = driver.FindElement(By.XPath("//table/tbody/tr[td/b/text()='Total']/td[2]/b")).Text;
            Assert.AreEqual(total, result);

                                    */


            //decimal decimalTotal = decimal.Parse(total);
            //Assert.AreEqual((7m * 8m) * 1.05m, decimalTotal);

            /*
             
           // Click on the Submit button
           driver.FindElement(By.CssSelector("input[value ='Next']")).Click();

           // Click the payment proceed button submit
           driver.FindElement(By.Name("submit")).Click();

           // Cardholder Name id cardholder
           driver.FindElement(By.Id("cardholder")).SendKeys("David Pitter");

           // Card Number id pan
           driver.FindElement(By.Id("pan")).SendKeys("5454545454545454");

           // Expiry Date id exp_date
           driver.FindElement(By.Id("exp_date")).SendKeys("1222");

           // Process Transaction id buttonProcessCC
           driver.FindElement(By.Id("buttonProcessCC")).Click();

           //driver.Close();          */

        }

    }
}
