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
            throw new NotImplementedException();
        }

        public void Atualizar(FilmeDomain FilmeAtualizado, int IdFilme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int IdFilme)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            GeneroRepository GeneroRepositorio = new GeneroRepository();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string cmd = $"INSERT INTO Filme (TituloFilme, IDGenero) VALUES ('{NovoFilme.Titulo}', {GeneroRepositorio.BuscarPorNome(NovoFilme.Genero.NomeGenero).IdGenero})";
            Conexao.Open();
            SqlCommand Comando = new SqlCommand(cmd, Conexao);
            Comando.ExecuteNonQuery();
        }

        public void Deletar(int IdFilme)
        {
            throw new NotImplementedException();
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
                FilmeDomain Filme = new FilmeDomain() {
                    IdFilme = Convert.ToInt32(LeitorDeDados[0]),
                    Titulo = Convert.ToString(LeitorDeDados[1]),
                    IdGenero = Convert.ToInt32(LeitorDeDados[2]),
                    Genero = RepositorioGenero.BuscarPorId(Convert.ToInt32(LeitorDeDados[2]))
                };
                ListaFilmes.Add(Filme);
            }
            return ListaFilmes;
        }
    }
}