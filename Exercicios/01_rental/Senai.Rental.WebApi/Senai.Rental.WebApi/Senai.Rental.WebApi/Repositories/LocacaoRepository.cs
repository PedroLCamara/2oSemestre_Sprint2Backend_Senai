using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class LocacaoRepository : BaseRepository, ILocacaoRepository
    {
        public void Atualizar(LocacaoDomain LocacaoAtualizada)
        {
            using(SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                ClienteRepository ClienteRepositorio = new ClienteRepository();
                VeiculoRepository VeiculoRepositorio = new VeiculoRepository();
                string CmdUpdate = "UPDATE Locacao SET IdCliente = @IdCliente, IdVeiculo = @IdVeiculo, DataRetirada = @DataRetirada, DataDevolucao = @DataDevolucao, StatusDevolucao = @StatusDevolucao WHERE @IdLocacao = IdLocacao";
                Conexao.Open();
                using(SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdLocacao", LocacaoAtualizada.IdLocacao);
                    if (LocacaoAtualizada.DataRetirada.ToString() == "{01/01/0001 00:00:00}")
                    {
                        Comando.Parameters.AddWithValue("@DataRetirada", LocacaoAtualizada.DataRetirada);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@DataRetirada", BuscarPorId(LocacaoAtualizada.IdLocacao).DataRetirada);
                    }
                    if (LocacaoAtualizada.DataDevolucao.ToString() == "{01/01/0001 00:00:00}")
                    {
                        Comando.Parameters.AddWithValue("@DataDevolucao", LocacaoAtualizada.DataDevolucao);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@DataDevolucao", BuscarPorId(LocacaoAtualizada.IdLocacao).DataDevolucao);
                    }
                    if (LocacaoAtualizada.StatusDevolucao != null)
                    {
                        Comando.Parameters.AddWithValue("@StatusDevolucao", LocacaoAtualizada.StatusDevolucao);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@StatusDevolucao", BuscarPorId(LocacaoAtualizada.IdLocacao).StatusDevolucao);
                    }
                    if (ClienteRepositorio.BuscarPorId(LocacaoAtualizada.IdCliente) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdCliente", LocacaoAtualizada.IdCliente);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdCliente", BuscarPorId(LocacaoAtualizada.IdLocacao).IdCliente);
                    }
                    if (VeiculoRepositorio.BuscarPorId(LocacaoAtualizada.IdVeiculo) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdVeiculo", LocacaoAtualizada.IdVeiculo);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdVeiculo", BuscarPorId(LocacaoAtualizada.IdLocacao).IdVeiculo);
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(LocacaoDomain LocacaoAtualizada, int IdLocacao)
        {
            ClienteRepository ClienteRepositorio = new ClienteRepository();
            VeiculoRepository VeiculoRepositorio = new VeiculoRepository();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Locacao SET IdCliente = @IdCliente, IdVeiculo = @IdVeiculo, DataRetirada = @DataRetirada, DataDevolucao = @DataDevolucao, StatusDevolucao = @StatusDevolucao WHERE @IdLocacao = IdLocacao";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdLocacao", IdLocacao);
                    if (LocacaoAtualizada.DataRetirada.ToString() == "{01/01/0001 00:00:00}")
                    {
                        Comando.Parameters.AddWithValue("@DataRetirada", LocacaoAtualizada.DataRetirada);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@DataRetirada", BuscarPorId(IdLocacao).DataRetirada);
                    }
                    if (LocacaoAtualizada.DataDevolucao.ToString() == "{01/01/0001 00:00:00}")
                    {
                        Comando.Parameters.AddWithValue("@DataDevolucao", LocacaoAtualizada.DataDevolucao);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@DataDevolucao", BuscarPorId(IdLocacao).DataDevolucao);
                    }
                    if (LocacaoAtualizada.StatusDevolucao != null)
                    {
                        Comando.Parameters.AddWithValue("@StatusDevolucao", LocacaoAtualizada.StatusDevolucao);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@StatusDevolucao", BuscarPorId(IdLocacao).StatusDevolucao);
                    }
                    if (ClienteRepositorio.BuscarPorId(LocacaoAtualizada.IdCliente) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdCliente", LocacaoAtualizada.IdCliente);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdCliente", BuscarPorId(IdLocacao).IdCliente);
                    }
                    if (VeiculoRepositorio.BuscarPorId(LocacaoAtualizada.IdVeiculo) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdVeiculo", LocacaoAtualizada.IdVeiculo);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdVeiculo", BuscarPorId(IdLocacao).IdVeiculo);
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public LocacaoDomain BuscarPorId(int IdLocacao)
        {
            LocacaoDomain LocacaoConsultada = new LocacaoDomain();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = "SELECT IdLocacao, IdCliente, IdVeiculo, DataRetirada, DataDevolucao, StatusDevolucao FROM Locacao WHERE IdLocacao = @IdLocacao";
                Conexao.Open();
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelectAll, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdLocacao", IdLocacao);
                    LeitorDeDados = Comando.ExecuteReader();
                    if (LeitorDeDados.Read())
                    {
                        LocacaoConsultada.IdLocacao = Convert.ToInt32(LeitorDeDados[0]);
                        LocacaoConsultada.IdCliente = Convert.ToInt32(LeitorDeDados[1]);
                        LocacaoConsultada.IdVeiculo = Convert.ToInt32(LeitorDeDados[2]);
                        LocacaoConsultada.DataRetirada = Convert.ToDateTime(LeitorDeDados[3]);
                        LocacaoConsultada.DataDevolucao = Convert.ToDateTime(LeitorDeDados[4]);
                        LocacaoConsultada.StatusDevolucao = Convert.ToString(LeitorDeDados[5]);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return LocacaoConsultada;
        }

        public void Cadastrar(LocacaoDomain NovaLocacao)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdInsertInto = "INSERT INTO Locacao(IdCliente, IdVeiculo, DataRetirada, DataDevolucao, StatusDevolucao) VALUES (@IdCliente, @IdVeiculo, @DataRetirada, @DataDevolucao, @StatusDevolucao)";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdInsertInto, Conexao))
                {
                    Comando.Parameters.AddWithValue("@DataRetirada", NovaLocacao.DataRetirada);
                    Comando.Parameters.AddWithValue("@DataDevolucao", NovaLocacao.DataDevolucao);
                    Comando.Parameters.AddWithValue("@StatusDevolucao", NovaLocacao.StatusDevolucao);
                    Comando.Parameters.AddWithValue("@IdVeiculo", NovaLocacao.IdVeiculo);
                    Comando.Parameters.AddWithValue("@IdCliente", NovaLocacao.IdCliente);
                    string CmdSelectCliente = "SELECT IdCliente FROM Cliente WHERE CPF = @CPF";
                    SqlDataReader LeitorDeDadosCliente;
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdLocacaoDeletada)
        {
            using(SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdDelete = "DELETE FROM Locacao WHERE IdLocacao = @IdLocacao";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdDelete, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdLocacao", IdLocacaoDeletada);
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public List<LocacaoDomain> ListarTodos()
        {
            List<LocacaoDomain> LocacoesListadas = new List<LocacaoDomain>();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = "SELECT IdLocacao, IdCliente, IdVeiculo, DataRetirada, DataDevolucao, StatusDevolucao FROM Locacao";
                Conexao.Open();
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelectAll, Conexao))
                {
                    LeitorDeDados = Comando.ExecuteReader();
                    while (LeitorDeDados.Read())
                    {
                        LocacaoDomain LocacaoConsultada = new LocacaoDomain();
                        LocacaoConsultada.IdLocacao = Convert.ToInt32(LeitorDeDados[0]);
                        LocacaoConsultada.IdCliente = Convert.ToInt32(LeitorDeDados[1]);
                        LocacaoConsultada.IdVeiculo = Convert.ToInt32(LeitorDeDados[2]);
                        LocacaoConsultada.DataRetirada = Convert.ToDateTime(LeitorDeDados[3]);
                        LocacaoConsultada.DataDevolucao = Convert.ToDateTime(LeitorDeDados[4]);
                        LocacaoConsultada.StatusDevolucao = Convert.ToString(LeitorDeDados[5]);
                        LocacoesListadas.Add(LocacaoConsultada);
                    }
                }
            }
            return LocacoesListadas;
        }
    }
}
