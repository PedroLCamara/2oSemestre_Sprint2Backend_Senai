using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface do repositorio GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Método para acessar todos os gêneros do BD
        /// </summary>
        /// <returns> Todos os gêneros em forma de lista</returns>
        List<GeneroDomain> LerTodos();

        /// <summary>
        /// Busca um gênero específico por seu id
        /// </summary>
        /// <param name="IdGenero">id do gênero a ser encontrado</param>
        /// <returns>Gênero em forma de objeto (GeneroDomain)</returns>
        GeneroDomain BuscarPorId(int IdGenero);

        /// <summary>
        /// Cadastra um novo gênero 
        /// </summary>
        /// <param name="NovoGenero">Gênero a ser cadastrado na forma de objeto (GeneroDomain)</param>
        void Cadastrar(GeneroDomain NovoGenero);

        /// <summary>
        /// Atualiza um gênero já existente (se guiando pelo JSON Object)
        /// </summary>
        /// <param name="GeneroAtualizado">Gênero após as mudanças desejadas em forma de objeto (GeneroDomain)</param>
        void Atualizar(GeneroDomain GeneroAtualizado);

        /// <summary>
        /// Atualiza um gênero já existente (se guiando pelo recurso da URL)
        /// </summary>
        /// <param name="IdGenero">Id que especificará o gênero a ser atualizado na URL</param>
        /// <param name="GeneroAtualizado">Gênero após as mudanças desejadas em forma de objeto (GeneroDomain)</param>
        void Atualizar(int IdGenero, GeneroDomain GeneroAtualizado);

        /// <summary>
        /// Deleta um gênero do BD
        /// </summary>
        /// <param name="IdGenero">Id do gênero que será deletado</param>
        void Deletar(int IdGenero);
    }
}
