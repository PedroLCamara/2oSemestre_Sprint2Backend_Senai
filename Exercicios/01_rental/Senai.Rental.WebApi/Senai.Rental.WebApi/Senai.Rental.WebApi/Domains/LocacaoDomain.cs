using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class LocacaoDomain
    {
        public int IdLocacao { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string StatusDevolucao { get; set; }

        public ClienteDomain Cliente { get; set; }
        public VeiculoDomain Veiculo { get; set; }
    }
}
