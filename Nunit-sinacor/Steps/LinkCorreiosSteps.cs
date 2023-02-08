using Nunit_sinacor.Pages;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class LinkCorreiosSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private LinkCorreiosPage _page;

        public LinkCorreiosSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _page = new LinkCorreiosPage();
        }

        [AfterTestRun]
        public static void SalvarArquivoTexto()
        {
            Nunit_sinacor.Helpers.Helper.Close();
        }
        
        [Given(@"Que eu acesse o site LinkCorreios")]
        public void GivenQueEuAcesseOSiteLinkCorreios()
        {
            _page.NavigateToSiteLinkCorreios();
        }

        [When(@"Preencha o campo de código de rastreamento com o valor ""(.*)""")]
        public void WhenPreenchaOCampoDeCodigoDeRastreamentoComOValor(string cod)
        {
            _page.FillFieldCodRastreamento(cod);
        }

        [When(@"Clique no botão de pesquisar")]
        public void WhenCliqueNoBotaoDePesquisar()
        {
            _page.ClickSearchRastreamento();
        }

        [Then(@"A página retornará com o texto ""(.*)""")]
        public void ThenAPaginaRetornaraComOTexto(string txt)
        {
            _page.WaitUntilResultRastreamento();
            bool rastreamentoIndisponivel = _page.TextExistInPage(txt);
            Assert.IsTrue(rastreamentoIndisponivel);
        }
    }
}
