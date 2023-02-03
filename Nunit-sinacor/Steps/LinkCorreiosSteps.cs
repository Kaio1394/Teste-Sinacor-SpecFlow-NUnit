using Nunit_sinacor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class LinkCorreios
    {
        private readonly ScenarioContext _scenarioContext;
        private Pages _pages;

        [AfterTestRun]
        public static void SalvarArquivoTexto()
        {
            Nunit_sinacor.Helpers.Helper.Close();
        }
        public LinkCorreios(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pages = new Pages();
        }
        [Given(@"Que eu acesse o site LinkCorreios")]
        public void GivenQueEuAcesseOSiteLinkCorreios()
        {
            _pages.linkCorreiosPage.NavigateToSiteLinkCorreios();
        }

        [When(@"Preencha o campo de código de rastreamento com o valor ""(.*)""")]
        public void WhenPreenchaOCampoDeCodigoDeRastreamentoComOValor(string cod)
        {
            _pages.linkCorreiosPage.FillFieldCodRastreamento(cod);
        }

        [When(@"Clique no botão de pesquisar")]
        public void WhenCliqueNoBotaoDePesquisar()
        {
            _pages.linkCorreiosPage.ClickSearchRastreamento();
        }

        [Then(@"A página retornará com o texto ""(.*)""")]
        public void ThenAPaginaRetornaraComOTexto(string txt)
        {
            _pages.linkCorreiosPage.WaitUntilResultRastreamento();
            bool rastreamentoIndisponivel = _pages.linkCorreiosPage.TextExistInPage(txt);
            Assert.IsTrue(rastreamentoIndisponivel);
        }
    }
}
