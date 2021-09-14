using Microsoft.EntityFrameworkCore;
using senai_inlock_webAPI_BDFirst.Contexts;
using senai_inlock_webAPI_BDFirst.Domains;
using senai_inlock_webAPI_BDFirst.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_inlock_webAPI_BDFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private InLockContext Contexto = new InLockContext();
        public void Atualizar(Estudio EstudioAtualizado, int IdEstudio)
        {
            Estudio EstudioBuscado = BuscarPorId(IdEstudio);

            if (EstudioBuscado != null)
            {
                EstudioBuscado.NomeEstudio = EstudioAtualizado.NomeEstudio;

                Contexto.Estudios.Update(EstudioBuscado);

                Contexto.SaveChanges();
            }
        }

        public Estudio BuscarPorId(int IdEstudio)
        {
            return Contexto.Estudios.FirstOrDefault(e => e.IdEstudio == IdEstudio);
        }

        public void Cadastrar(Estudio NovoEstudio)
        {
            Contexto.Estudios.Add(NovoEstudio);

            Contexto.SaveChanges();
        }

        public void Deletar(int IdEstudio)
        {
            Contexto.Estudios.Remove(BuscarPorId(IdEstudio));

            Contexto.SaveChanges();
        }

        public List<Estudio> ListarComJogos()
        {
            return Contexto.Estudios.Include(e => e.Jogos).ToList();
        }

        public List<Estudio> ListarTodos()
        {
            return Contexto.Estudios.ToList();
        }
    }
}
