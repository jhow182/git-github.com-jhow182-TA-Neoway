using OpenQA.Selenium;
using TANeoway.Helpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Repository.Hierarchy;

namespace TANeoway.Helpers
{
    public class PageHelper
    {
        private const int _customTimeout = 20;
        
        private WebDriverWait wait;
        private static IWebDriver driver;

        private static IJavaScriptExecutor javaScriptExecutor;
        private static Actions actions;

        private static By Alerts = By.Id("alertsContainer");

        private static By SuccessMessage = By.Id("snackBarMensagem");
        private static By ErrorMessage = By.CssSelector(".alert-danger");
        private static By WarningMessage = By.CssSelector(".alert-warning");

        public PageHelper(IWebDriver _driver)
        {
            driver = _driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_customTimeout));
            javaScriptExecutor = (IJavaScriptExecutor)_driver;
            actions = new Actions(_driver);
        }
        
        public bool EstaNaUrl(string pUrl)
        {
            this.WaitPageLoad();
            return driver.Url.Contains(pUrl);
        }

        public string GetURL()
        {
            this.WaitPageLoad();
            return driver.Url;
        }

        public void WaitPageLoad()
        {
            try
            {
                string script = "return (document.readyState == 'complete' && jQuery.active == 0)";

                Func<IWebDriver, bool> readyCondition = driver =>
                (bool)javaScriptExecutor.ExecuteScript(script);

                wait.Until(readyCondition);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ElementoEstaVisivel(By locator)
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch
            {
                    return false;
            }
        }
    }
}
