using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();
        TipoUsuarioDomain BuscarPorId(int IdTipoUsuario);
        void Atualizar(TipoUsuarioDomain TipoUsuarioAtualizado);
        void Cadastrar(TipoUsuarioDomain NovoTipoUsuario);
        void Deletar(int IdTipoUsuario);
    }
}