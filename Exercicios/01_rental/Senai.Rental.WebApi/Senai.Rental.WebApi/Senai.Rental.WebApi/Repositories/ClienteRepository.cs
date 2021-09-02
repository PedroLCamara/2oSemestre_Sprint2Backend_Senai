using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public void Atualizar(ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Cliente SET CPF = @CPF, NomeCliente = @Nome, SobrenomeCliente = @Sobrenome WHERE IdCliente = @IdCliente";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("IdCliente", ClienteAtualizado.IdCliente);
                    if(ClienteAtualizado.CPF != null) 
                    { 
                        Comando.Parameters.AddWithValue("@CPF", ClienteAtualizado.CPF);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@CPF", BuscarPorId(ClienteAtualizado.IdCliente).CPF);
                    }
                    if (ClienteAtualizado.Nome != null)
                    {
                        Comando.Parameters.AddWithValue("@Nome", ClienteAtualizado.Nome);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Nome", BuscarPorId(ClienteAtualizado.IdCliente).Nome);
                    }
                    if (ClienteAtualizado.Sobrenome != null)
                    {
                        Comando.Parameters.AddWithValue("@Sobrenome", ClienteAtualizado.Sobrenome);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Sobrenome", BuscarPorId(ClienteAtualizado.IdCliente).Sobrenome);
                    }
                }
            }
        }

        public void Atualizar(ClienteDomain ClienteAtualizado, int IdCliente)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Cliente SET CPF = @CPF, NomeCliente = @Nome, SobrenomeCliente = @Sobrenome WHERE IdCliente = @IdCliente";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("IdCliente", IdCliente);
                    if (ClienteAtualizado.CPF != null)
                    {
                        Comando.Parameters.AddWithValue("@CPF", ClienteAtualizado.CPF);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@CPF", BuscarPorId(IdCliente).CPF);
                    }
                    if (ClienteAtualizado.Nome != null)
                    {
                        Comando.Parameters.AddWithValue("@Nome", ClienteAtualizado.Nome);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Nome", BuscarPorId(IdCliente).Nome);
                    }
                    if (ClienteAtualizado.Sobrenome != null)
                    {
                        Comando.Parameters.AddWithValue("@Sobrenome", ClienteAtualizado.Sobrenome);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Sobrenome", BuscarPorId(IdCliente).Sobrenome);
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int IdCliente)
        {
            ClienteDomain ClienteConsultado = new ClienteDomain();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelect = "SELECT IdCliente, CPF, NomeCliente, SobrenomeCliente FROM Cliente WHERE IdCliente = @IdCliente";
                Conexao.Open();
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelect, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdCliente", IdCliente);
                    LeitorDeDados = Comando.ExecuteReader();
                    if (LeitorDeDados.Read())
                    {
                        ClienteConsultado.IdCliente = Convert.ToInt32(LeitorDeDados[0]);
                        ClienteConsultado.CPF = Convert.ToString(LeitorDeDados[1]);
                        ClienteConsultado.Nome = Convert.ToString(LeitorDeDados[2]);
                        ClienteConsultado.Sobrenome = Convert.ToString(LeitorDeDados[3]);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return ClienteConsultado;
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using(SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdInsertInto = "INSERT INTO Cliente (CPF, NomeCliente, SobrenomeCliente) VALUES (@CPF, @Nome, @Sobrenome)";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdInsertInto, Conexao))
                {
                    Comando.Parameters.AddWithValue("@CPF", NovoCliente.CPF);
                    Comando.Parameters.AddWithValue("@Nome", NovoCliente.Nome);
                    Comando.Parameters.AddWithValue("@Sobrenome", NovoCliente.Sobrenome);
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdClienteDeletado)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdDelete = "DELETE FROM Cliente WHERE IdCliente = @IdCliente";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdDelete, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdCliente", IdClienteDeletado);
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ClientesListados = new List<ClienteDomain>();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = "SELECT IdCliente, CPF, NomeCliente, SobrenomeCliente FROM Cliente";
                Conexao.Open();
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelectAll, Conexao))
                {
                    LeitorDeDados = Comando.ExecuteReader();
                    while (LeitorDeDados.Read())
                    {
                        ClienteDomain ClienteConsultado = new ClienteDomain();
                        ClienteConsultado.IdCliente = Convert.ToInt32(LeitorDeDados[0]);
                        ClienteConsultado.CPF = Convert.ToString(LeitorDeDados[1]);
                        ClienteConsultado.Nome = Convert.ToString(LeitorDeDados[2]);
                        ClienteConsultado.Sobrenome = Convert.ToString(LeitorDeDados[3]);
                        ClientesListados.Add(ClienteConsultado);
                    }
                }
            }
            return ClientesListados;
        }
    }
}
