using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=PEDRO-PC\\SQLEXPRESS; initial catalog=Catalogo; user Id=sa; pwd=senai@123";
        public void Atualizar(FilmeDomain FilmeAtualizado)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string cmd = "UPDATE Filme SET TituloFilme = @TituloFilme, IDGenero = @IdGenero WHERE IDFilme = @IdFilme";
                using (SqlCommand Comando = new SqlCommand(cmd, Conexao))
                {
                    Comando.Parameters.AddWithValue("@TituloFilme", FilmeAtualizado.Titulo);
                    Comando.Parameters.AddWithValue("@IdFilme", FilmeAtualizado.IdFilme);
                    Comando.Parameters.AddWithValue("@IdGenero", FilmeAtualizado.IdGenero);
                    Conexao.Open();

                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(FilmeDomain FilmeAtualizado, int IdFilme)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string cmd = "UPDATE Filme SET TituloFilme = @TituloFilme, IDGenero = @IdGenero WHERE IDFilme = @IdFilme";
                using (SqlCommand Comando = new SqlCommand(cmd, Conexao))
                {
                    Comando.Parameters.AddWithValue("@TituloFilme", FilmeAtualizado.Titulo);
                    Comando.Parameters.AddWithValue("@IdFilme", IdFilme);
                    Comando.Parameters.AddWithValue("@IdGenero", FilmeAtualizado.IdGenero);
                    Conexao.Open();

                    Comando.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int IdFilme)
        {
            GeneroRepository GeneroRepositorio = new GeneroRepository();
            FilmeDomain Filme = new FilmeDomain();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string QuerySelecionarPorId = $"SELECT IDFilme, TituloFilme, IDGenero FROM Filme WHERE IDFilme = @IdFilme";
            Conexao.Open();
            SqlDataReader LeitorDeDados;
            SqlCommand Comando = new SqlCommand(QuerySelecionarPorId, Conexao);
            Comando.Parameters.AddWithValue("@IdFilme", IdFilme);
            LeitorDeDados = Comando.ExecuteReader();
            if (LeitorDeDados.Read() == true)
            {
                Filme.IdFilme = Convert.ToInt32(LeitorDeDados[0]);
                Filme.Titulo = Convert.ToString(LeitorDeDados[1]);
                if(LeitorDeDados[2] != DBNull.Value)
                {
                    Filme.IdGenero = Convert.ToInt32(LeitorDeDados[2]);
                    Filme.Genero = GeneroRepositorio.BuscarPorId(Filme.IdGenero);
                }
                Conexao.Close();
                return Filme;
            }
            else
            {
                Conexao.Close();
                return null;
            }
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            GeneroRepository GeneroRepositorio = new GeneroRepository();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string cmd = $"INSERT INTO Filme (TituloFilme, IDGenero) VALUES (@Titulo,@IdGenero)";
            Conexao.Open();
            SqlCommand Comando = new SqlCommand(cmd, Conexao);
            Comando.Parameters.AddWithValue("@Titulo", NovoFilme.Titulo);
            GeneroDomain teste = GeneroRepositorio.BuscarPorNome(NovoFilme.Genero.NomeGenero);
            if (teste == null)
            {
                Comando.Parameters.AddWithValue("@IdGenero", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@IdGenero", GeneroRepositorio.BuscarPorNome(teste.NomeGenero).IdGenero);
            }
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Deletar(int IdFilme)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                string cmd = "DELETE FROM Filme WHERE IDFilme = @IdFilme";
                Conexao.Open();
                using(SqlCommand Comando = new SqlCommand(cmd, Conexao))
                {
                    Comando.Parameters.AddWithValue("@IdFilme", IdFilme);
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> LerTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();
            GeneroRepository RepositorioGenero = new GeneroRepository();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string QuerySelecionarTodos = "SELECT IDFilme, TituloFilme, IDGenero FROM Filme";
            Conexao.Open();
            SqlDataReader LeitorDeDados;
            SqlCommand Comando = new SqlCommand(QuerySelecionarTodos, Conexao);
            LeitorDeDados = Comando.ExecuteReader();
            while (LeitorDeDados.Read())
            {
                FilmeDomain Filme = new FilmeDomain();
                Filme.IdFilme = Convert.ToInt32(LeitorDeDados[0]);
                Filme.Titulo = Convert.ToString(LeitorDeDados[1]);
                if (LeitorDeDados[2] != DBNull.Value)
                {
                    Filme.IdGenero = Convert.ToInt32(LeitorDeDados[2]);
                    Filme.Genero = RepositorioGenero.BuscarPorId(Convert.ToInt32(LeitorDeDados[2]));
                }
                ListaFilmes.Add(Filme);
            }
            Conexao.Close();
            return ListaFilmes;
        }
    }
}