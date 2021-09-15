using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.InLock.webAPI.CodeFirst.Domains
{
    [Table("TIPO_USUARIO")]
    public class TiposUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "TINYINT")]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Título do tipo de usuário é necessário")]
        [Column(TypeName = "VARCHAR(50)")]
        public string Titulo { get; set; }

        List<Usuarios> UsuariosConexao { get; set; }
    }
}