using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillingForm.Helpers
{
    public class FormHelper
    {
        public string GetRadioOptionAttributeValue(IWebDriver driver, string id, int optNum, string attName)
        {
            var elementList = driver.FindElements(By.Id(id));
            var element = elementList[optNum];
            var attVal = element.GetAttribute(attName);
            return attVal;
        }
<<<<<<< HEAD
=======

>>>>>>> ee5c5b55c823ff0638b8cca3222d39c4a5d54bd0
        public string GetTextFieldValue(IWebDriver driver, string id)
        {
            var textField = driver.FindElement(By.Id(id));
            return textField.GetAttribute("value");
        }
        public void ClickRadioOption(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
            var element = radioButtonList[optNum];
            element.Click();
        }
<<<<<<< HEAD
=======

>>>>>>> ee5c5b55c823ff0638b8cca3222d39c4a5d54bd0
        // Get the span value
        public string GetRadioSpanText(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var span = parent.FindElement(By.TagName("span"));
            return span.Text;
        }
<<<<<<< HEAD
=======

>>>>>>> ee5c5b55c823ff0638b8cca3222d39c4a5d54bd0
        // Visible if Test
        public string IfVisible(IWebDriver driver, string id)
        {
            var visible = driver.FindElement(By.Id(id));
            return visible.GetAttribute("style");
        }

        public void InsertValueJour(IWebDriver driver, string id, int optNum)
        {
            var ValueOpt = driver.FindElements(By.Id(id));
            var element = ValueOpt[optNum];
            element.Clear();
            element.SendKeys("2");
        }

        public void InsertValueCata(IWebDriver driver, string id, int optNum)
        {
            var ValueOpt1 = driver.FindElements(By.Id(id));
            var element = ValueOpt1[optNum];
            element.Clear();
            element.SendKeys("1");
        }        
        public string GetResultText(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));

            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var bTag = parent.FindElement(By.CssSelector("tr:nth-child(11) td:nth-child(2) b"));            
            return bTag.Text;
        }
<<<<<<< HEAD
        public string GetReviewPageText(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
=======
        
        public string GetResultText(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));

            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var bTag = parent.FindElement(By.CssSelector("tr:nth-child(11) td:nth-child(2) b"));            
            return bTag.Text;
        }
        public string GetReviewPageText(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
>>>>>>> ee5c5b55c823ff0638b8cca3222d39c4a5d54bd0
            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var subTotal = parent.FindElement(By.CssSelector("tr:nth-child(20) td:nth-child(2)"));
            return subTotal.Text;
        }
        public string GetReviewPageText2(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var GST = parent.FindElement(By.CssSelector("tr:nth-child(21) td:nth-child(2)"));
            return GST.Text;
        }
        public string GetReviewPageText3(IWebDriver driver, string id, int optNum)
        {
            var radioButtonList = driver.FindElements(By.Id(id));
            var element = radioButtonList[optNum];
            var parent = element.FindElement(By.XPath("./.."));
            var TOTAL = parent.FindElement(By.CssSelector("tr:nth-child(22) td:nth-child(2)"));
            return TOTAL.Text;
        }
    }
}
