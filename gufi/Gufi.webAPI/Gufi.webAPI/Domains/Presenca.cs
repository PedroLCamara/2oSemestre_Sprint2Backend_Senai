using System;
using System.Collections.Generic;

#nullable disable

namespace Gufi.webAPI.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public byte? IdSituacaoPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual SituacaoPresenca IdSituacaoPresencaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
