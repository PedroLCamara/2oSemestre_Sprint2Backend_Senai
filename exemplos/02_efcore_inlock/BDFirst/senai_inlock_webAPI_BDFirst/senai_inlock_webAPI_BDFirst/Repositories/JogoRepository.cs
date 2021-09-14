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
    public class JogoRepository : IJogoRepository
    {
        private InLockContext Contexto = new InLockContext();
        public List<Jogo> ListarComEstudio()
        {
            return Contexto.Jogos.Include(j => j.IdEstudioNavigation).ToList();
        }
    }
}
