using System;
using System.Collections.Generic;

#nullable disable

namespace senai_inlock_webAPI_BDFirst.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public short? IdEstudio { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataLancamento { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
    }
}
