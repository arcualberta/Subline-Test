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
    }
}
