using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;

namespace CargaCotacaoBitcoin
{
    public class CotacaoBitcoinRepository
    {
        private IConfiguration _configuration;

        public CotacaoBitcoinRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Incluir(CotacaoBitcoin cotacao)
        {
            using (SqlConnection conexao = new SqlConnection(
                 _configuration.GetConnectionString("BaseBitcoin")))
            {
                conexao.Insert(cotacao);
            }
        }
    }
}