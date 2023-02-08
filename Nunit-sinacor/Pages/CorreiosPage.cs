using Nunit_sinacor.data;
using Nunit_sinacor.Helpers;
using OpenQA.Selenium;

namespace Nunit_sinacor.Pages
{
    
    public class CorreiosPage : Helper
    {
        private string LCorreios =                          "https://buscacepinter.correios.com.br/app/endereco/index.php";
        private string PathToSaveImg =                      @"C:\temp\";
        private string IdFieldCEP =                         ReadJson.ReadFileJson("Locators", "correios", "IdFieldCEP");
        private string IdbtnPesquisa =                      ReadJson.ReadFileJson("Locators", "correios", "IdbtnPesquisa");
        private string XPathTabelaRua =                     ReadJson.ReadFileJson("Locators", "correios", "XPathTabelaRua");
        private string XPathTabelaCidade =                  ReadJson.ReadFileJson("Locators", "correios", "XPathTabelaCidade");
        private string XPathTabelaCEP =                     ReadJson.ReadFileJson("Locators", "correios", "XPathTabelaCEP");
        private string XPathResultTitle =                   ReadJson.ReadFileJson("Locators", "correios", "XPathResultTitle");
        private string XPathLinkCorreios =                  ReadJson.ReadFileJson("Locators", "correios", "XPathLinkCorreios");
        private string IdInputRastreamento =                ReadJson.ReadFileJson("Locators", "correios", "IdInputRastreamento");
        private string ClassNameIconSearchRastreamento  =   ReadJson.ReadFileJson("Locators", "correios", "ClassNameIconSearchRastreamento");
        private string IdCaptchImg =                        ReadJson.ReadFileJson("Locators", "correios", "IdCaptchImg");
        private string IdNewBusca =                         ReadJson.ReadFileJson("Locators", "correios", "IdNewBusca");

        public CorreiosPage() : base(null) { }

        public void FillFieldCEP(string CEP)
        {
            this.SendKeys(By.Id(IdFieldCEP), CEP);
        }

        public void FillFieldCodRastreamento(string cod)
        {
            this.WaitUntilElement(By.XPath(IdInputRastreamento));
            this.SendKeys(By.Id(IdInputRastreamento), cod);
        }
        public string GetTextCaptcha()
        {           
            var pathImg = this.SaveImage(IdCaptchImg, PathToSaveImg);
            return this.GetTextByImg(pathImg);
        }
        public void ClickSearchRastreamento()
        {
            this.Click(By.ClassName(ClassNameIconSearchRastreamento));
        }

        public string GetTableResultSearch(string alias)
        {
            switch (alias.ToLower())
            {
                case "street":
                    return this.GetText(By.XPath(XPathTabelaRua));
                case "uf":
                    return this.GetText(By.XPath(XPathTabelaCidade));
                case "cep":
                    return this.GetText(By.XPath(XPathTabelaCEP));
                default:
                    throw new Exception("Opção inválida.");
            }

        }
        public bool WaitUntilTitleResultIsPresent()
        {
            return this.WaitUntilElement(By.XPath(XPathResultTitle));
        }
        public void ClickNewBusca()
        {
            this.Click(By.Id(IdNewBusca));
        }
        public void NavigateToSiteCEP()
        {
            try
            {
                this.NavigateToURL(LCorreios);
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível navegar na url");
            }
        }
        public void ClickBuscarCEP()
        {
            var teste = IdbtnPesquisa;
            this.Click(By.Id(IdbtnPesquisa));
        }
        public bool TextResultRastreamento(string text)
        {
            try
            {
                string xpath = "//h6[text()='" + text + "']";
                this.WaitUntilElement(By.XPath(xpath));
                this.GetText(By.XPath(xpath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ClickImgCorreios()
        {
            this.Click(By.XPath(XPathLinkCorreios));
        }
    }
}
