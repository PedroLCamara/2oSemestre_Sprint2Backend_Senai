using Gufi.webAPI.Contexts;
using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private GufiContext Ctx = new();

        public void Atualizar(int IdTipoEventoAtualizado, TipoEvento TipoEventoAtualizado)
        {
            TipoEvento TipoEventoConsulta = BuscarPorId(IdTipoEventoAtualizado);
            if (TipoEventoConsulta != null)
            {
                TipoEventoConsulta.TituloTipoEvento = TipoEventoAtualizado.TituloTipoEvento;
                Ctx.Update(TipoEventoConsulta);
                Ctx.SaveChanges();
            }
        }

        public TipoEvento BuscarPorId(int IdTipoEvento)
        {
            return Ctx.TipoEventos.FirstOrDefault(TpE => TpE.IdTipoEvento == IdTipoEvento);
        }

        public void Cadastrar(TipoEvento NovoTipoEvento)
        {
            Ctx.TipoEventos.Add(NovoTipoEvento);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdTipoEventoDeletado)
        {
            Ctx.TipoEventos.Remove(BuscarPorId(IdTipoEventoDeletado));
            Ctx.SaveChanges();
        }

        public List<TipoEvento> ListarTodos()
        {
            return Ctx.TipoEventos.ToList();
        }
    }
}
