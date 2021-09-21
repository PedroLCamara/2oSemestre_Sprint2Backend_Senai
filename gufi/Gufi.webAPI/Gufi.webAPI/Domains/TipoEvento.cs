using System;
using System.Collections.Generic;

#nullable disable

namespace Gufi.webAPI.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public short IdTipoEvento { get; set; }
        public string TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
