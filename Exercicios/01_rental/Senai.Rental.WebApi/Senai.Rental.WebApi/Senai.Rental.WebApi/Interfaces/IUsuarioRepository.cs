using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();
        UsuarioDomain BuscarPorId(int IdUsuario);
        void Atualizar(UsuarioDomain UsuarioAtualizado);
        void Cadastrar(UsuarioDomain NovoUsuario);
        void Deletar(int IdUsuario);
    }
}
