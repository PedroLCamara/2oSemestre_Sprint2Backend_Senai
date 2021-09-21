using Gufi.webAPI.Contexts;
using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private GufiContext Ctx = new();

        public Usuario Login(string Email, string Senha)
        {
            return Ctx.Usuarios.FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }
    }
}
