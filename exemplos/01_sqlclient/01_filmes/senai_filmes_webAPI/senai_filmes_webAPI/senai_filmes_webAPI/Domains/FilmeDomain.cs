using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade Filme no BD de Catálogo
    /// </summary>
    public class FilmeDomain
    {
        //Atributo que representa a coluna/chave(primária) IDFilme da tabela especificada no sumário da classe
        public int IdFilme { get; set; }

        //Atributo que representa a coluna/chave(secundária) IDGenero da tabela especificada no sumário da classe
        public int IdGenero { get; set; }

        //Atributo que representa a coluna Titulo da tabela especificada no sumário da classe
        public string Titulo { get; set; }

        //Atributo que representa o gênero com o qual o registo da tabela especificada no sumário da classe se relaciona
        public GeneroDomain Genero { get; set; }
    }
}