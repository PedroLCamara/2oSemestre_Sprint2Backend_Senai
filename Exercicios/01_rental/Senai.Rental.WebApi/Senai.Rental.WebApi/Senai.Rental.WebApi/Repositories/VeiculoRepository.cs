using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : BaseRepository, IVeiculoRepository
    {
        public void Atualizar(VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Veiculo SET IdEmpresa = @IdEmpresa, IdModelo = @IdMoleo, Placa = @Placa WHERE IdVeiculo = @IdVeiculo";
                using(SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdVeiculo", VeiculoAtualizado.IdVeiculo);
                    if (VeiculoAtualizado.Placa != null){
                        Comando.Parameters.AddWithValue("@Placa", VeiculoAtualizado.Placa);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Placa", BuscarPorId(VeiculoAtualizado.IdVeiculo).Placa);
                    }
                    string CmdSelectEmpresa = "SELECT IdEmpresa FROM Empresa WHERE NomeEmpresa = @NomeEmpresa";
                    SqlDataReader LeitorDeDadosEmpresa;
                    using (SqlCommand ComandoSecundario = new SqlCommand(CmdSelectEmpresa, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeEmpresa", VeiculoAtualizado.Empresa.NomeEmpresa);
                        LeitorDeDadosEmpresa = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosEmpresa.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", LeitorDeDadosEmpresa[0]);
                        }
                        else if (VeiculoAtualizado.IdEmpresa > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", VeiculoAtualizado.IdEmpresa);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", BuscarPorId(VeiculoAtualizado.IdVeiculo).IdEmpresa);
                        }
                    }
                    string CmdSelectModelo = "SELECT IdModelo FROM Modelo WHERE NomeModelo = @NomeModelo";
                    SqlDataReader LeitorDeDadosModelo;
                    using (SqlCommand ComandoSecundario = new SqlCommand(CmdSelectModelo, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeModelo", VeiculoAtualizado.Modelo.NomeModelo);
                        LeitorDeDadosModelo = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosModelo.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", LeitorDeDadosModelo[0]);
                        }
                        else if (VeiculoAtualizado.IdModelo > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", VeiculoAtualizado.IdModelo);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", BuscarPorId(VeiculoAtualizado.IdVeiculo).IdModelo);
                        }
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(VeiculoDomain VeiculoAtualizado, int IdVeiculo)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Veiculo SET IdEmpresa = @IdEmpresa, IdModelo = @IdMoleo, Placa = @Placa WHERE IdVeiculo = @IdVeiculo";
                using (SqlCommand Comando = new SqlCommand(CmdUpdate, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);
                    if (VeiculoAtualizado.Placa != null)
                    {
                        Comando.Parameters.AddWithValue("@Placa", VeiculoAtualizado.Placa);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@Placa", BuscarPorId(IdVeiculo).Placa);
                    }
                    string CmdSelectEmpresa = "SELECT IdEmpresa FROM Empresa WHERE NomeEmpresa = @NomeEmpresa";
                    SqlDataReader LeitorDeDadosEmpresa;
                    using (SqlCommand ComandoSecundario = new SqlCommand(CmdSelectEmpresa, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeEmpresa", VeiculoAtualizado.Empresa.NomeEmpresa);
                        LeitorDeDadosEmpresa = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosEmpresa.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", LeitorDeDadosEmpresa[0]);
                        }
                        else if (VeiculoAtualizado.IdEmpresa > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", VeiculoAtualizado.IdEmpresa);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", BuscarPorId(IdVeiculo).IdEmpresa);
                        }
                    }
                    string CmdSelectModelo = "SELECT IdModelo FROM Modelo WHERE NomeModelo = @NomeModelo";
                    SqlDataReader LeitorDeDadosModelo;
                    using (SqlCommand ComandoSecundario = new SqlCommand(CmdSelectModelo, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeModelo", VeiculoAtualizado.Modelo.NomeModelo);
                        LeitorDeDadosModelo = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosModelo.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", LeitorDeDadosModelo[0]);
                        }
                        else if (VeiculoAtualizado.IdModelo > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", VeiculoAtualizado.IdModelo);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", BuscarPorId(IdVeiculo).IdModelo);
                        }
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int IdVeiculo)
        {
            VeiculoDomain VeiculoConsultado = new VeiculoDomain();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = "SELECT IdVeiculo, IdEmpresa, IdModelo, Placa FROM Veiculo WHERE IdVeiculo = @IdVeiculo";
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelectAll, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);
                    LeitorDeDados = Comando.ExecuteReader();
                    if (LeitorDeDados.Read())
                    {
                        VeiculoConsultado.IdVeiculo = Convert.ToInt32(LeitorDeDados[0]);
                        VeiculoConsultado.IdEmpresa = Convert.ToInt32(LeitorDeDados[1]);
                        VeiculoConsultado.IdModelo = Convert.ToInt32(LeitorDeDados[2]);
                        VeiculoConsultado.Placa = Convert.ToString(LeitorDeDados[3]);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return VeiculoConsultado;
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {
            using(SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdInsertInto = "INSERT INTO Veiculo (IdEmpresa, IdModelo, Placa) VALUES (@IdEmpresa, @IdModelo, @Placa)";
                using (SqlCommand Comando = new SqlCommand(CmdInsertInto, Conexao))
                {
                    Comando.Parameters.AddWithValue("@Placa", NovoVeiculo.Placa);
                    string CmdSelectEmpresa = "SELECT IdEmpresa FROM Empresa WHERE NomeEmpresa = @NomeEmpresa";
                    SqlDataReader LeitorDeDadosEmpresa;
                    using(SqlCommand ComandoSecundario = new SqlCommand(CmdSelectEmpresa, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeEmpresa", NovoVeiculo.Empresa.NomeEmpresa);
                        LeitorDeDadosEmpresa = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosEmpresa.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", LeitorDeDadosEmpresa[0]);
                        }
                        else if (NovoVeiculo.IdEmpresa > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", NovoVeiculo.IdEmpresa);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdEmpresa", DBNull.Value);
                        }
                    }
                    string CmdSelectModelo = "SELECT IdModelo FROM Modelo WHERE NomeModelo = @NomeModelo";
                    SqlDataReader LeitorDeDadosModelo;
                    using (SqlCommand ComandoSecundario = new SqlCommand(CmdSelectModelo, Conexao))
                    {
                        ComandoSecundario.Parameters.AddWithValue("@NomeModelo", NovoVeiculo.Modelo.NomeModelo);
                        LeitorDeDadosModelo = ComandoSecundario.ExecuteReader();
                        if (LeitorDeDadosModelo.Read())
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", LeitorDeDadosModelo[0]);
                        }
                        else if (NovoVeiculo.IdModelo > 0)
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", NovoVeiculo.IdModelo);
                        }
                        else
                        {
                            Comando.Parameters.AddWithValue("@IdModelo", DBNull.Value);
                        }
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdVeiculoDeletado)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdDelete = "DELETE FROM Veiculo WHERE IdVeiculo = @IdVeiculo";
                using (SqlCommand Comando = new SqlCommand(CmdDelete, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdVeiculo", IdVeiculoDeletado);
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> VeiculosListados = new List<VeiculoDomain>();
            using(SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelectAll = "SELECT IdVeiculo, IdEmpresa, IdModelo, Placa FROM Veiculo";
                SqlDataReader LeitorDeDados;
                using (SqlCommand Comando = new SqlCommand(CmdSelectAll, Conexao))
                {
                    LeitorDeDados = Comando.ExecuteReader();
                    while (LeitorDeDados.Read())
                    {
                        VeiculoDomain VeiculoConsultado = new VeiculoDomain();
                        VeiculoConsultado.IdVeiculo = Convert.ToInt32(LeitorDeDados[0]);
                        VeiculoConsultado.IdEmpresa = Convert.ToInt32(LeitorDeDados[1]);
                        VeiculoConsultado.IdModelo = Convert.ToInt32(LeitorDeDados[2]);
                        VeiculoConsultado.Placa = Convert.ToString(LeitorDeDados[3]);
                        VeiculosListados.Add(VeiculoConsultado);
                    }
                }
            }
            return VeiculosListados;
        }
    }
}
