using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public void Atualizar(UsuarioDomain UsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorId(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain NovoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
