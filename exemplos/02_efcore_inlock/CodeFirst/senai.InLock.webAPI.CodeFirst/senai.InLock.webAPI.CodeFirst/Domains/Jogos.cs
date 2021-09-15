using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.InLock.webAPI.CodeFirst.Domains
{
    [Table("JOGO")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INT")]
        public int IdJogo { get; set; }

        [Column(TypeName = "TINYINT")]
        public int IdEstudio { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome do jogo é necessário")]
        public string Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do jogo é necessária")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento do jogo é necessária")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal Valor { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudios EstudioConexao { get; set; }
    }
}