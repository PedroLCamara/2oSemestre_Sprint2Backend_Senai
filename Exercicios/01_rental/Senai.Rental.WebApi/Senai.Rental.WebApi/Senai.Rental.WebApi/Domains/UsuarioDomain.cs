using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
