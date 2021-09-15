using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.InLock.webAPI.CodeFirst.Domains
{
    [Table("USUARIO")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INT")]
        public int IdUsuario { get; set; }

        [Column(TypeName = "TINYINT")]
        public int IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Email do usuário é necessário")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(16)")]
        [Required(ErrorMessage = "Senha do usuário é necessária")]
        [StringLength(16, MinimumLength = 5)]
        public string Senha { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario TipoUsuarioConexao { get; set; }
    }
}