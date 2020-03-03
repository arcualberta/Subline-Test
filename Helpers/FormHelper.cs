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

        public string GetSpanElementText(IWebDriver driver, string class1)
        {
            var spanId = driver.FindElement(By.ClassName(class1));
            return spanId.GetAttribute("span");
        }
        /*public string GetTextFieldValue2(IWebDriver driver, string xPath)
        {
            var textField2 = driver.FindElement(By.XPath(xPath));
            return textField2.GetAttribute("value");
        }*/

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
        
        public void ClickOnButton(IWebDriver driver, string text)
        {
            var clickButton = driver.FindElement(By.LinkText(text));
            clickButton.Click();
        }

    }
}
