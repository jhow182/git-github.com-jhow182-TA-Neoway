using log4net;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANeoway.Helpers;
using TechTalk.SpecFlow;

namespace TANeoway.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private PageHelper pageHelper;
        private ButtonHelper buttonHelper;
        private NavigationHelper navigationHelper;

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenario)
        {
            IWebDriver driver = null;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--lang=pt-br");
            // os testes devem SEMPRE ser executados nessa resolucao pois eh a mais utilizada no BR
            chromeOptions.AddArgument("--window-size=1380,768");

            if (File.Exists(@"C:\Chromedriver-SV2\chromedriver.exe"))
                driver = new ChromeDriver(@"C:\Chromedriver-SV2", chromeOptions);
            else
                driver = new ChromeDriver(chromeOptions);

            driver.Manage().Window.Size = new System.Drawing.Size(1380, 768);
        }
    }

    
}
        
    
        
