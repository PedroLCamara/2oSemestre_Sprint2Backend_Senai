using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ModeloRepository : BaseRepository, IModeloRepository
    {
        public ModeloDomain BuscarPorId(int IdModelo)
        {
            ModeloDomain ModeloConsultado = new ModeloDomain();
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string CmdSelect = "SELECT IdModelo, IdMarca, NomeModelo FROM Modelo WHERE IdModelo = @IdModelo";
                SqlDataReader LeitorDeDados;
                Conexao.Open();
                using (SqlCommand Comando = new SqlCommand(CmdSelect, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdModelo", IdModelo);
                    LeitorDeDados = Comando.ExecuteReader();
                    if (LeitorDeDados.Read())
                    {
                        ModeloConsultado.IdModelo = Convert.ToInt32(LeitorDeDados[0]);
                        ModeloConsultado.NomeModelo = Convert.ToString(LeitorDeDados[1]);
                        return ModeloConsultado;
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
