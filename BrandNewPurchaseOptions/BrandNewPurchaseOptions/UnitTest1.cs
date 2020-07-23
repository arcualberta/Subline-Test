using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Option.Test
{
    [TestFixture]
    class PurchaseOptionsTest
    {
        private IWebDriver driver;

        //protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(".");
            driver.Url = ("https://subline-test.artsrn.ualberta.ca/portals/edit/54");

            IWebElement element1 = driver.FindElement(By.ClassName("btn"));
            element1.Click();

            IWebElement insertemail = driver.FindElement(By.Id("identifierId"));
            insertemail.SendKeys("arcguya@gmail.com");

            IWebElement clicknext = driver.FindElement(By.ClassName("VfPpkd-RLmnJb"));
            clicknext.Click();

            Thread.Sleep(10000);

            IWebElement insertpassword = driver.FindElement(By.ClassName("whsOnd"));
            insertpassword.SendKeys("water4sealion");

            Thread.Sleep(5000);

            IWebElement clicknext2 = driver.FindElement(By.ClassName("VfPpkd-RLmnJb"));
            clicknext2.Click();

            Thread.Sleep(5000);
        }

        [Test]
        public void NewOptionTest()
        {
            IWebElement clickonpurchasetab = driver.FindElements(By.ClassName("fa"))[6];
            clickonpurchasetab.Click();

            IWebElement clickonpurchaseoptionstab = driver.FindElement(By.Id("__BVID__67___BV_tab_button__"));
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

            IWebElement clickonstartdate= driver.FindElement(By.Id("pc-start-date-0__value_"));
            clickonstartdate.Click();

            IWebElement clickoncurrentdate = driver.FindElement(By.Id("__BVID__132__cell-2020-07-23_"));
            clickoncurrentdate.Click();

            IWebElement clickonstarttime = driver.FindElement(By.Id("pc-start-time-0"));
            clickonstarttime.Click();

            IWebElement insertstarttime = driver.FindElement(By.Id("pc-start-time-0"));
            insertstarttime.SendKeys("12:30A");

            IWebElement clickonend = driver.FindElement(By.Id("pc-end-date-0__value_"));
            clickonend.Click();

            IWebElement clicknext = driver.FindElement(By.ClassName("bi-chevron-left b-icon bi"));
            clicknext.Click();

            //IWebElement clickonenddate = driver.FindElement(By.Id("__BVID__136__cell-2020-08-23_"));
            //clickonenddate.Click();

        }
    }
}