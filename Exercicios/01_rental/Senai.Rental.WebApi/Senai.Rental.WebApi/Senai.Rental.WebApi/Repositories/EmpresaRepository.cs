using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {
        public EmpresaDomain BuscarPorId(int IdEmpresa)
        {
            EmpresaDomain EmpresaConsultada = new EmpresaDomain();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelect = "SELECT IdEmpresa, NomeEmpresa FROM Empresa WHERE IdEmpresa = @IdEmpresa";
                SqlDataReader LeitorDeDados;
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdSelect, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    LeitorDeDados = Comando.ExecuteReader();
                    if (LeitorDeDados.Read())
                    {
                        EmpresaConsultada.IdEmpresa = Convert.ToInt32(LeitorDeDados[0]);
                        EmpresaConsultada.NomeEmpresa = Convert.ToString(LeitorDeDados[1]);
                        return EmpresaConsultada;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
