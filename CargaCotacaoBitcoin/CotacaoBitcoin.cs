using System;
using Dapper.Contrib.Extensions;

namespace CargaCotacaoBitcoin
{
    [Table("dbo.CotacaoBitcoin")]
    public class CotacaoBitcoin
    {
        [ExplicitKey]
        public DateTime UltimaAtualizacao { get; set; }
        public double VlCotacaoDolar { get; set; }
    }
}