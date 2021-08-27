using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface do repositorio FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Método para acessar todos os filmes do BD
        /// </summary>
        /// <returns> Todos os filmes em forma de lista</returns>
        List<FilmeDomain> LerTodos();

        /// <summary>
        /// Busca um filme especifico por seu id
        /// </summary>
        /// <param name="IdFilme">id do filme a ser encontrado/param>
        /// <returns>Filme na forma de objeto (FilmeDomain)</returns>
        FilmeDomain BuscarPorId(int IdFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="NovoFilme">Filme a ser cadastrado na forma de objeto (FilmeDomain)</param>
        void Cadastrar(FilmeDomain NovoFilme);

        /// <summary>
        /// Atualiza um filme já existente (se guiando pelo JSON Object)
        /// </summary>
        /// <param name="FilmeAtualizado">Filme após as mudanças desejadas em forma de objeto (FilmeDomain)</param>
        void Atualizar(FilmeDomain FilmeAtualizado);

        /// <summary>
        /// Atualiza um filme já existente (se guiando pelo recurso da URL)
        /// </summary>
        /// <param name="IdFilme">Id que especificará o filme a ser atualizado na URL</param>
        /// <param name="FilmeAtualizado">Filme após as mudanças desejadas em forma de objeto (FilmeDomain)</param>
        void Atualizar(FilmeDomain FilmeAtualizado, int IdFilme);

        /// <summary>
        /// Deleta um filme do BD
        /// </summary>
        /// <param name="IdFilme">Id do filme que será deletado</param>
        void Deletar(int IdFilme);
    }
}
