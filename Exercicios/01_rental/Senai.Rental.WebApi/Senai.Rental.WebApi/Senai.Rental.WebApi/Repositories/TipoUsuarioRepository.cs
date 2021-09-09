using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class TipoUsuarioRepository : BaseRepository, ITipoUsuarioRepository
    {
        public void Atualizar(TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDomain BuscarPorId(int IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuarioDomain NovoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = $@"SELECT Id";
            }
        }
    }
}
