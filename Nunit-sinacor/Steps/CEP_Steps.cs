using Nunit_sinacor.Pages;
using System;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class CEP_Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private Pages _pages;

        public CEP_Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pages = new Pages();
        }

        [BeforeTestRun] 
        public static void Run(){ }

        [AfterTestRun]
        public static void SalvarArquivoTexto()
        {
            Nunit_sinacor.Helpers.Helper.Close();
        }
        [Given(@"Navegar para o site dos correios")]
        public void GivenNavegarParaOSiteDosCorreios()
        {
            _pages.correioPage.NavigateToSiteCEP();
        }

        [Given(@"Clique em buscar CEP")]
        public void GivenCliqueEmBuscarCEP()
        {
            _pages.correioPage.ClickBuscarCEP();
        }

        [Given(@"Preencher o campo do CEP com valor ""(.*)""")]
        public void GivenPreencherOCampoDoCEPComValor(string CEP)
        {
            _pages.correioPage.FillFieldCEP(CEP);
        }
        [Then(@"O campo ""(.*)"" da tabela retornará o valor ""(.*)""")]
        public void ThenOCampoDaTabelaRetornaraOValor(string field, string value)
        {
            _pages.correioPage.WaitUntilTitleResultIsPresent();
            string? getTableValue = null;
            switch (field.ToLower())
            {
                case "street":
                    getTableValue = _pages.correioPage.GetTableResultSearch("street");
                    break;
                case "uf":
                    getTableValue = _pages.correioPage.GetTableResultSearch("uf");
                    break;
                default:
                    break;
            }
            Assert.That(value, Is.EqualTo(getTableValue));
        }
        [Then(@"A página irá retornar a mensagem ""(.*)""")]
        public void ThenAPaginaIraRetornarAMensagem(string msg)
        {
            Assert.IsTrue(_pages.correioPage.TextResultRastreamento(msg));
        }

    }
}
