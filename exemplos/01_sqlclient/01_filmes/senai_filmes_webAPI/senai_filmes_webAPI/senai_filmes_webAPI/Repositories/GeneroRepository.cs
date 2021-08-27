using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace senai_filmes_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão ao BD. (Data Source=Nome do servidor; initial catalog=Nome do BD; 
        /// user Id=Id do usuário do SQL Server; pwd=Senha do usuário do SQL Server 
        /// (caso autenticação com windows e não com SQL Server: integrated security= true))
        /// </summary>
        private string StringConexao = "Data Source=PEDRO-PC\\SQLEXPRESS; initial catalog=Catalogo; user Id=sa; pwd=senai@123";
        public void Atualizar(GeneroDomain GeneroAtualizado)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int IdGenero, GeneroDomain GeneroAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int IdGenero)
        {
            GeneroDomain Genero = new GeneroDomain();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string QuerySelecionarPorId = $"SELECT IDGenero, NomeGenero FROM GENERO WHERE IDGenero = {IdGenero}";
            Conexao.Open();
            SqlDataReader LeitorDeDados;
            SqlCommand Comando = new SqlCommand(QuerySelecionarPorId, Conexao);
            LeitorDeDados = Comando.ExecuteReader();
            while (LeitorDeDados.Read())
            {
                Genero.IdGenero = Convert.ToInt32(LeitorDeDados[0]);
                Genero.NomeGenero = Convert.ToString(LeitorDeDados[1]);
            }
            return Genero;
        }
        public GeneroDomain BuscarPorNome(string NomeGenero)
        {
            GeneroDomain Genero = new GeneroDomain();
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string QuerySelecionarPorId = $"SELECT IDGenero, NomeGenero FROM GENERO WHERE NomeGenero = '{NomeGenero}'";
            Conexao.Open();
            SqlDataReader LeitorDeDados;
            SqlCommand Comando = new SqlCommand(QuerySelecionarPorId, Conexao);
            LeitorDeDados = Comando.ExecuteReader();
            while (LeitorDeDados.Read())
            {
                Genero.IdGenero = Convert.ToInt32(LeitorDeDados[0]);
                Genero.NomeGenero = Convert.ToString(LeitorDeDados[1]);
            }
            return Genero;
        }

        /// <summary>
        /// Cria um novo gênero no BD com base em um GeneroDomain
        /// </summary>
        /// <param name="NovoGenero">GeneroDomain criado que carrega um nome específico para a criação</param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            SqlConnection Conexao = new SqlConnection(StringConexao);
            string cmd = $"INSERT INTO Genero (NomeGenero) VALUES ('{NovoGenero.NomeGenero}')";
            Conexao.Open();
            SqlCommand Comando = new SqlCommand(cmd, Conexao);
            Comando.ExecuteNonQuery();
        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> LerTodos()
        {
            //Cria uma lista de objetos gênero
            List<GeneroDomain> ListaDeGeneros = new List<GeneroDomain>();

            //Cria e usa uma nova conexão ao banco
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                //Variavel tipo string com um comando de SELECT para exibir a tabela Genero do BD
                string QuerySelecionarTodos = "SELECT IDGenero, NomeGenero FROM GENERO";

                //Abre a conexão com o BD
                Conexao.Open();

                //Cria um novo objeto do tipo leitor de dados do sql
                SqlDataReader LeitorDeDados;

                //Cria e usa um novo comando SQL, recebenco como argumentos
                //o comando anterior em forma de string e a conexão criada
                using (SqlCommand Comando = new SqlCommand(QuerySelecionarTodos, Conexao))
                {
                    //Executa o comando e salva os dados no leitor de dados
                    LeitorDeDados = Comando.ExecuteReader();

                    //Aplica uma condição de funcionamento enquanto as leituras forem existentes
                    while (LeitorDeDados.Read())
                    {
                        GeneroDomain Genero = new GeneroDomain();
                        Genero.IdGenero = Convert.ToInt32(LeitorDeDados[0]);
                        Genero.NomeGenero = Convert.ToString(LeitorDeDados[1]);
                        ListaDeGeneros.Add(Genero);
                    }
                }
            }
            return ListaDeGeneros;
        }
    }
}