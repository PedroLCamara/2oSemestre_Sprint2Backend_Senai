using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.InLock.webAPI.CodeFirst.Domains
{
    [Table("ESTUDIO")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "TINYINT")]
        public int IdEstudio { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome do estúdio é necessário")]
        public string NomeEstudio { get; set; }

        List<Jogos> JogosConexao { get; set; }
    }
}