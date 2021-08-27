using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade Genero do BD de Catálogo
    /// </summary>
    public class GeneroDomain
    {
        //Atributo que representa a coluna/chave(primária) IDGenero da tabela especificada no sumário da classe
        public int IdGenero { get; set; }

        //Atributo que representa a coluna NomeGenero da tabela especificada no sumário da classe
        public string NomeGenero { get; set; }
    }
}
