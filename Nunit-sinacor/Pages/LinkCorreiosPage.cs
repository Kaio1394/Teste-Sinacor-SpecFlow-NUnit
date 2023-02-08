using Nunit_sinacor.data;
using Nunit_sinacor.Helpers;
using OpenQA.Selenium;

namespace Nunit_sinacor.Pages
{
    public class LinkCorreiosPage : Helper
    {
        private string LinkCorreios =               "https://www.linkcorreios.com.br/";
        private string IdInputRastreamento =        ReadJson.ReadFileJson("Locators", "linkCorreios", "IdInputRastreamento");
        private string XPathBtnEnviar =             ReadJson.ReadFileJson("Locators", "linkCorreios", "XPathBtnEnviar");
        private string XPathResultRastreamento =    ReadJson.ReadFileJson("Locators", "linkCorreios", "XPathResultRastreamento");

        public LinkCorreiosPage() : base(null) { }

        public void FillFieldCodRastreamento(string cod)
        {
            this.WaitUntilElement(By.XPath(IdInputRastreamento));
            this.SendKeys(By.Id(IdInputRastreamento), cod);
        }
        public void ClickSearchRastreamento()
        {
            this.Click(By.XPath(XPathBtnEnviar));
        }
        public void WaitUntilResultRastreamento()
        {
            bool found = this.WaitUntilElement(By.XPath(XPathResultRastreamento));
            if (!found)
                throw new Exception("Página do resultado do rastreamento não foi carregada.");
        }
        public bool TextExistInPage(string text)
        {
            try
            {
                string xpath = "//p['" + text + "']";
                string result = this.GetText(By.XPath(xpath));
                return result.Contains(text);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void NavigateToSiteLinkCorreios()
        {
            try
            {
                this.NavigateToURL(LinkCorreios);
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível navegar para url");
            }
        }
    }
}
