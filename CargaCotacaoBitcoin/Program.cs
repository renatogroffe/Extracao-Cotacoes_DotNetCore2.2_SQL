using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CargaCotacaoBitcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();


            Console.WriteLine("Imagem do site de testes no Docker Hub: " +
                "renatogroffe/site-indicadores-economia-nginx");
            Console.WriteLine("Iniciando a extração das cotações...");

            DateTime dataHoraExtracao = DateTime.Now;

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations"))
                    .Configure(seleniumConfigurations);

            var pagina = new PaginaCotacoes(seleniumConfigurations);
            pagina.CarregarPagina();
            var cotacao = pagina.ObterCotacaoBitcoin();
            pagina.Fechar();

            Console.WriteLine("Incluindo cotação de Bitcoin na base de dados...");
            new CotacaoBitcoinRepository(configuration).Incluir(cotacao);

            Console.WriteLine("Concluído o processo de carga!");
        }
    }
}