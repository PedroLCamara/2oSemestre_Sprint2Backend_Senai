using Gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);
    }
}
