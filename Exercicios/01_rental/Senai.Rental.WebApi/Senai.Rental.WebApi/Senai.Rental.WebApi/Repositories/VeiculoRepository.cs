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
            EmpresaRepository EmpresaRepositorio = new EmpresaRepository();
            ModeloRepository ModeloRepositorio = new ModeloRepository();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Veiculo SET IdEmpresa = @IdEmpresa, IdModelo = @IdModelo, Placa = @Placa WHERE IdVeiculo = @IdVeiculo";
                Conexao.Open();
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
                    if (EmpresaRepositorio.BuscarPorId(VeiculoAtualizado.IdEmpresa) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdEmpresa", VeiculoAtualizado.IdEmpresa);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdEmpresa", BuscarPorId(VeiculoAtualizado.IdVeiculo).IdEmpresa);
                    }
                    if (ModeloRepositorio.BuscarPorId(VeiculoAtualizado.IdModelo) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", VeiculoAtualizado.IdModelo);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", BuscarPorId(VeiculoAtualizado.IdVeiculo).IdModelo);
                    }
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(VeiculoDomain VeiculoAtualizado, int IdVeiculo)
        {
            EmpresaRepository EmpresaRepositorio = new EmpresaRepository();
            ModeloRepository ModeloRepositorio = new ModeloRepository();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdUpdate = "UPDATE Veiculo SET IdEmpresa = @IdEmpresa, IdModelo = @IdModelo, Placa = @Placa WHERE IdVeiculo = @IdVeiculo";
                Conexao.Open();
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
                    if (EmpresaRepositorio.BuscarPorId(VeiculoAtualizado.IdEmpresa) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdEmpresa", VeiculoAtualizado.IdEmpresa);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdEmpresa", BuscarPorId(IdVeiculo).IdEmpresa);
                    }
                    if (ModeloRepositorio.BuscarPorId(VeiculoAtualizado.IdModelo) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", VeiculoAtualizado.IdModelo);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", BuscarPorId(IdVeiculo).IdModelo);
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
                Conexao.Open();
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
            EmpresaRepository EmpresaRepositorio = new EmpresaRepository();
            ModeloRepository ModeloRepositorio = new ModeloRepository();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdInsertInto = "INSERT INTO Veiculo (IdEmpresa, IdModelo, Placa) VALUES (@IdEmpresa, @IdModelo, @Placa)";
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdInsertInto, Conexao))
                {
                    Comando.Parameters.AddWithValue("@Placa", NovoVeiculo.Placa);
                    if(EmpresaRepositorio.BuscarPorId(NovoVeiculo.IdEmpresa) != null){
                        Comando.Parameters.AddWithValue("@IdEmpresa", NovoVeiculo.IdEmpresa);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdEmpresa", DBNull.Value);
                    }
                    if (ModeloRepositorio.BuscarPorId(NovoVeiculo.IdModelo) != null)
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", NovoVeiculo.IdModelo);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@IdModelo", DBNull.Value);
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
                Conexao.Open();
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
                Conexao.Open();
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
