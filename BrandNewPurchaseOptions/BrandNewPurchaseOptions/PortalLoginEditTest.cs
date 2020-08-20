using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Brandnew.Configuration;

namespace Portal.Login.Edit.Test
{
    [TestFixture]
    class BrandNewPurchse
    {
        private IWebDriver driver;
        //private string id;

        //protected IWebDriver driver;

        
        public void Login()
        {
            //driver = new ChromeDriver(".");
            //driver.Url = ("https://subline-test.artsrn.ualberta.ca/portals/edit/54");

            IWebElement element1 = driver.FindElement(By.ClassName("btn"));
            element1.Click();

            IWebElement insertemail = driver.FindElement(By.Id("identifierId"));
            insertemail.SendKeys(Settings.UserName);

            IWebElement clicknext = driver.FindElement(By.ClassName("VfPpkd-RLmnJb"));
            clicknext.Click();

            Thread.Sleep(10000);

            IWebElement insertpassword = driver.FindElement(By.ClassName("whsOnd"));
            insertpassword.SendKeys(Settings.Password);

            Thread.Sleep(5000);

            IWebElement clicknext2 = driver.FindElement(By.ClassName("VfPpkd-RLmnJb"));
            clicknext2.Click();

            Thread.Sleep(7000);
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
            driver.Url = Settings.TestConfig.EventUrl;

            Login();
        }
            [Test]
        public void NewOptionTest()
        {
            IWebElement clickonpurchasetab = driver.FindElements(By.ClassName("fa"))[6];
            clickonpurchasetab.Click();

            IWebElement clickonpurchaseoptionstab = driver.FindElements(By.ClassName("nav-link"))[10];
            clickonpurchaseoptionstab.Click();

            //IWebElement clickondropicon = driver.FindElement(By.Id("dropdown-icon-0"));
            //clickondropicon.Click();

            IWebElement clickonaddacategory = driver.FindElement(By.Id("add-category-button"));
            clickonaddacategory.Click();

            IWebElement clickondropicon = driver.FindElement(By.Id("dropdown-icon-0"));
            clickondropicon.Click();

            Thread.Sleep(3000);

            IWebElement insertcategorytitle = driver.FindElement(By.Id("purchase-category-label0"));
            insertcategorytitle.SendKeys("Category 1");
            IWebElement clickonstartdate = driver.FindElement(By.Id("pc-start-date-0__value_"));
            clickonstartdate.Click();
            IWebElement clickoncurrentdate = driver.FindElement(By.Id("__BVID__132__cell-2020-07-23_"));
            clickoncurrentdate.Click();
            IWebElement clickonstarttime = driver.FindElement(By.Id("pc-start-time-0"));
            clickonstarttime.Click();
            IWebElement insertstarttime = driver.FindElement(By.Id("pc-start-time-0"));
            insertstarttime.SendKeys("12:30A");
            IWebElement clickonend = driver.FindElement(By.Id("pc-end-date-0__value_"));
            clickonend.Click();
            IWebElement clicknext = driver.FindElements(By.ClassName("bi-chevron-left"))[3];
            clicknext.Click();
            IWebElement clickonenddate = driver.FindElement(By.Id("__BVID__136__cell-2020-08-23_"));
            clickonenddate.Click();
            IWebElement clickonendtime = driver.FindElement(By.Id("pc-start-time-0"));
            clickonendtime.Click();
            IWebElement insertendtime = driver.FindElement(By.Id("pc-end-time-0"));
            insertendtime.SendKeys("12:30A");
            
            IWebElement clickaddpricebtn = driver.FindElement(By.Id("add-price-option-0"));
            clickaddpricebtn.Click();
            IWebElement insertpricelabel = driver.FindElement(By.Id("po-label-input-pc-0-po-0"));
            insertpricelabel.SendKeys("Price Option 1");
            IWebElement insertpricevalue = driver.FindElement(By.Id("price-option-price-pc-0-po-0"));
            insertpricevalue.Clear();
            insertpricevalue.SendKeys("25.50");
            IWebElement insertpricelimit = driver.FindElement(By.Id("price-option-limit-pc-0-po-0"));
            insertpricelimit.Clear();
            insertpricelimit.SendKeys("10");
            
            IWebElement clickaddpricebtn2 = driver.FindElement(By.Id("add-price-option-0"));
            clickaddpricebtn2.Click();
            IWebElement insertpricelabel2 = driver.FindElement(By.Id("po-label-input-pc-0-po-1"));
            insertpricelabel2.SendKeys("Price Option 2");
            IWebElement insertpricevalue2 = driver.FindElement(By.Id("price-option-price-pc-0-po-1"));
            insertpricevalue2.Clear();
            insertpricevalue2.SendKeys("25.50");
            IWebElement insertpricelimit2 = driver.FindElement(By.Id("price-option-limit-pc-0-po-1"));
            insertpricelimit2.Clear();
            insertpricelimit2.SendKeys("0");

            IWebElement clickonokbtn = driver.FindElement(By.Id("form-properties-ok-button"));
            clickonokbtn.Click();

            Thread.Sleep(5000);

            IWebElement clickonsavebtn = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div[1]/button"));
            clickonsavebtn.Click();       
            
            driver.Navigate().Refresh();
            
            IWebElement clickonpurchasetab2 = driver.FindElements(By.ClassName("fa"))[6];
            clickonpurchasetab2.Click();
            IWebElement clickonpurchaseoptionstab2 = driver.FindElements(By.ClassName("nav-link"))[10];
            clickonpurchaseoptionstab2.Click();
            IWebElement clickondropicon2 = driver.FindElement(By.Id("dropdown-icon-0"));
            clickondropicon2.Click();
            /*
            IWebElement pricecheck = driver.FindElement(By.Id("price-option-price-pc-0-po-0"));         
            Assert.AreEqual("25.5", pricecheck.Text);

            IWebElement limitcheck = driver.FindElement(By.Id("price-option-limit-pc-0-po-0"));
            Assert.AreEqual("10", limitcheck.Text);

            IWebElement pricecheck2 = driver.FindElement(By.Id("price-option-price-pc-0-po-1"));
            Assert.AreEqual("25.5", pricecheck2.Text);
            IWebElement limitcheck2 = driver.FindElement(By.Id("price-option-limit-pc-0-po-1"));
            Assert.AreEqual("0", limitcheck2.Text);*/

            IWebElement clickondeletebtn = driver.FindElement(By.Id("delete-category-button-0"));
            clickondeletebtn.Click();

            IWebElement clickonyesdeletebtn = driver.FindElement(By.Id("are-you-sure-close-all-button"));
            clickonyesdeletebtn.Click();


        }
    }       
}