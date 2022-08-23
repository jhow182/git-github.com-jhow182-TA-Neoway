using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using TANeoway.Helpers;
using TechTalk.SpecFlow;

namespace TANeoway.Steps
{
    [Binding]
    public class W3SchoolSteps
    {
        private IWebDriver _driver;
        private NavigationHelper navigationHelper;
        private ButtonHelper buttonHelper;
        private PageHelper pageHelper;

        [Given(@"que acessei o site da WSchool")]
        public void GivenQueAcesseiOSiteDaWSchool()
        {
            navigationHelper.GoToUrl("https://www.w3schools.com/");
        }

        [Given(@"que usei a navegação principal para a modal Boxes")]
        public void GivenQueUseiANavegacaoPrincipalParaAModalBoxes()
        {
            buttonHelper.ClickButton(PageObjects.HomePages.BtnModalTutorial);
            buttonHelper.ClickButton(By.XPath("//*[@id='nav_tutorials']/div/div/div[2]/a[text()='Learn How To']"));
            pageHelper.WaitPageLoad();
        }

        [Given(@"que usei a navegação lateral para a abrir modal Boxes")]
        public void GivenQueUseiANavegacaoLateralParaAAbrirModalBoxes()
        {
            buttonHelper.ClickButton(By.XPath("//*[@id='leftmenuinnerinner']/a[text()='Modal Boxes']"));
            buttonHelper.ClickButton(By.XPath("//*[@id='main']/button[text()='Open Modal']"));
        }

        [Given(@"que usei a navegação principal para a abrir Grupos de Cores")]
        public void GivenQueUseiANavegacaoPrincipalParaAAbrirGruposDeCores()
        {
            buttonHelper.ClickButton(PageObjects.HomePages.BtnModalTutorial);
            buttonHelper.ClickButton(By.XPath("//*[@id='main']/button[text()='Learn Colors']"));
        }

        [Given(@"que usei a navegação lateral para a abrir Grupo de Cores")]
        public void GivenQueUseiANavegacaoLateralParaAAbrirGrupoDeCores()
        {
            buttonHelper.ClickButton(By.XPath("//*[@id='leftmenuinnerinner']/a[text()='Color Groups']"));
            buttonHelper.ClickButton(By.XPath("//*[@id='main']/button[text()='Open Modal']"));
        }

        [Given(@"que usei a navegação principal para a formulários HTML")]
        public void GivenQueUseiANavegacaoPrincipalParaAFormulariosHTML()
        {
            buttonHelper.ClickButton(PageObjects.HomePages.BtnModalTutorial);
            buttonHelper.ClickButton(By.XPath("//*[@id='nav_tutorials']/div/div/div[2]/a[text()='Learn HTML']"));
        }

        [Given(@"que usei a navegação lateral para a abrir formulários HTML")]
        public void GivenQueUseiANavegacaoLateralParaAAbrirFormulariosHTML()
        {
            buttonHelper.ClickButton(By.XPath("//*[@id='leftmenuinnerinner']/a[text()='HTML Forms']"));

        }

        [Given(@"clico em ""(.*)""")]
        public void GivenClicoEm(string titulo)
        {
            buttonHelper.ClickButton(By.XPath($"//*[@id='main']/div[4]/a[text()='{titulo}']"));
            pageHelper.WaitPageLoad();
        }

        [Then(@"verifico se a modal Boxes foi exibida")]
        public void ThenVerificoSeAModalBoxesFoiExibida()
        {
            Assert.IsTrue(pageHelper.ElementoEstaVisivel(By.XPath("//*[@id='id01']/div/header/h2[text()='Modal Header']")));
        }

        [Then(@"fecho a modal boxes")]
        public void ThenFechoAModalBoxes()
        {
            buttonHelper.ClickButton(By.XPath("//*[@id='loginModal']/div/div[3]/button[text()='Cancel']"));
        }

        [Then(@"verifico se a modal boxes não está mais visível")]
        public void ThenVerificoSeAModalBoxesNaoEstaMaisVisivel()
        {
            Assert.IsFalse(pageHelper.ElementoEstaVisivel(By.XPath("//*[@id='id01']/div/header/h2[text()='Modal Header']")));
        }

        [Then(@"verifico se a ""(.*)"" está igual  a ""(.*)""")]
        public void ThenVerificoSeAEstaIgualA(string cor, string hexadecimal)
        {
            // criar um array para receber a lista no w3school e utilizar a tabela para verificar se as linhas correspondentes contempla os dados conforme tabela
            ////*[@id="main"]/div[3]/table/tbody/tr/td/a[text()='Black']
            ///
        }

        [Then(@"na nova aba aberta, envio meu nome ""(.*)"" e sobrenome ""(.*)""")]
        public void ThenNaNovaAbaAbertaEnvioMeuNomeESobrenome(string nome, string sobrenome)
        {
            IWebElement fieldNome = _driver.FindElement(By.Id("//*[@id='fname']"));
            fieldNome.Clear();
            fieldNome.SendKeys(nome);

            IWebElement fieldSobreNome = _driver.FindElement(By.Id("//*[@id='lname']"));
            fieldSobreNome.Clear();
            fieldSobreNome.SendKeys(sobrenome);

            buttonHelper.ClickButton(By.XPath("//*[@id='main']/div[3]/div/form/input[3]"));
            pageHelper.WaitPageLoad();
        }

        [Then(@"verifico se o meu nome ""(.*)"" e sobrenome ""(.*)"" foram enviados corretamente")]
        public void ThenVerificoSeOMeuNomeESobrenomeForamEnviadosCorretamente(string nome, string sobrenome)
        {
            var inputRecebido = _driver.FindElement(By.XPath("/html/body/div[1]")).Text;
            Assert.IsTrue(inputRecebido.Contains(nome));
            Assert.IsTrue(inputRecebido.Contains(sobrenome));
        }
    }
}
