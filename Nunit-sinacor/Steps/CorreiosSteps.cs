using Nunit_sinacor.Pages;
using System;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class CorreiosSteps
    {
        private readonly ScenarioContext _scenarioContext;
        CorreiosPage _pages;

        public CorreiosSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pages = new CorreiosPage();
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
            _pages.NavigateToSiteCEP();
        }

        [Given(@"Clique em buscar CEP")]
        public void GivenCliqueEmBuscarCEP()
        {
            _pages.ClickBuscarCEP();
        }       
        [Given(@"Preencher o campo do CEP com valor ""(.*)""")]
        public void GivenPreencherOCampoDoCEPComValor(string CEP)
        {
            _pages.FillFieldCEP(CEP);
        }
        [Then(@"O campo ""(.*)"" da tabela retornará o valor ""(.*)""")]
        public void ThenOCampoDaTabelaRetornaraOValor(string field, string value)
        {
            _pages.WaitUntilTitleResultIsPresent();
            string? getTableValue = null;
            switch (field.ToLower())
            {
                case "street":
                    getTableValue = _pages.GetTableResultSearch("street");
                    break;
                case "uf":
                    getTableValue = _pages.GetTableResultSearch("uf");
                    break;
                default:
                    break;
            }
            Assert.That(value, Is.EqualTo(getTableValue));
        }
        [Then(@"A página irá retornar a mensagem ""(.*)""")]
        public void ThenAPaginaIraRetornarAMensagem(string msg)
        {
            Assert.IsTrue(_pages.TextResultRastreamento(msg));
        }

    }
}
