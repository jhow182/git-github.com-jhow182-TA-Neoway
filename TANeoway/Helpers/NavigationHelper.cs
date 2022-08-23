using log4net;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANeoway.Helpers
{
    public class NavigationHelper
    {
        private IWebDriver _driver;
        public PageHelper pageHelper;

        public NavigationHelper(IWebDriver driver)
        {
            _driver = driver;
            pageHelper = new PageHelper(driver);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            pageHelper.WaitPageLoad();
        }
    }
}
