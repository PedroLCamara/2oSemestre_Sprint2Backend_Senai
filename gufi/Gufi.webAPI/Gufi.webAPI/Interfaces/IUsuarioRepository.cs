using Gufi.webAPI.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);

        void SalvarPerfilBD(IFormFile Foto, int IdUsuario);
        void SalvarPerfilDir(IFormFile Foto, int IdUsuario);
        string ConsultarPerfilBD(int IdUsuario);
        string ConsultarPerfilDir(int IdUsuario);
    }
}
