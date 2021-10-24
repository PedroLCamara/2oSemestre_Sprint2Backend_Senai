using Gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Interfaces
{
    interface ITipoEventoRepository
    {
        List<TipoEvento> ListarTodos();
        TipoEvento BuscarPorId(int IdTipoEvento);
        void Cadastrar(TipoEvento NovoTipoEvento);
        void Deletar(int IdTipoEventoDeletado);
        void Atualizar(int IdTipoEventoAtualizado, TipoEvento TipoEventoAtualizado);
    }
}