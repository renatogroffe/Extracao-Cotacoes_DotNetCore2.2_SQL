using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CargaCotacaoBitcoin
{
    public class PaginaCotacoes
    {
        private SeleniumConfigurations _configurations;
        private IWebDriver _driver;

        public PaginaCotacoes(SeleniumConfigurations seleniumConfigurations)
        {
            _configurations = seleniumConfigurations;

            ChromeOptions optionsFF = new ChromeOptions();
            optionsFF.AddArgument("--headless");

            _driver = new ChromeDriver(
                _configurations.CaminhoDriverChrome
                , optionsFF);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(60);
            _driver.Navigate().GoToUrl(
                _configurations.UrlPaginaCotacoes);
        }

        public CotacaoBitcoin ObterCotacaoBitcoin()
        {
            CotacaoBitcoin cotacao = null;

            var cotacaoBitcoinHTML = _driver.FindElement(
                By.Id("cotacaoBitcoin"));
            if (cotacaoBitcoinHTML != null)
            {
                cotacao = new CotacaoBitcoin();
                cotacao.UltimaAtualizacao = DateTime.Now;
                cotacao.VlCotacaoDolar = Convert.ToDouble(
                    cotacaoBitcoinHTML.Text);
            }

            return cotacao;
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}