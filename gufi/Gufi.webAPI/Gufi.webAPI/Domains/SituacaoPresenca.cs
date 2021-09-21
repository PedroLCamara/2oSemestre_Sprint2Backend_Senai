using System;
using System.Collections.Generic;

#nullable disable

namespace Gufi.webAPI.Domains
{
    public partial class SituacaoPresenca
    {
        public SituacaoPresenca()
        {
            Presencas = new HashSet<Presenca>();
        }

        public byte IdSituacaoPresenca { get; set; }
        public string TituloSituacaoPresenca { get; set; }

        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
