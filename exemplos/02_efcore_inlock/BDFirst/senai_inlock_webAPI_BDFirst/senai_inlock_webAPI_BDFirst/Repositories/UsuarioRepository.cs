using Microsoft.EntityFrameworkCore;
using senai_inlock_webAPI_BDFirst.Contexts;
using senai_inlock_webAPI_BDFirst.Domains;
using senai_inlock_webAPI_BDFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_BDFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private InLockContext Contexto = new InLockContext();
        public Usuario Logar(string Email, string Senha)
        {
            return Contexto.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Senha == Senha && u.Email == Email);
        }
    }
}
