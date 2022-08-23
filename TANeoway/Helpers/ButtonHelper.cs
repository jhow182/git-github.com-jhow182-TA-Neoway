using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANeoway.Helpers
{
    public class ButtonHelper
    {
        private static IWebDriver _driver;
        private PageHelper pageHelper;
        private WebDriverWait wait;

        public ButtonHelper(IWebDriver driver)
        {
            _driver = driver;
            pageHelper = new PageHelper(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void ClickButton(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Click();
        }

        public void ClickButtonWithoutWait(By locator)
        {
            var botao = _driver.FindElement(locator);
            botao.Click(); 
        }
    }
}
