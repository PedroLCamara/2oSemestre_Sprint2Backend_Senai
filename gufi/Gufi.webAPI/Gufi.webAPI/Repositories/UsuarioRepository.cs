using Gufi.webAPI.Contexts;
using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private GufiContext Ctx = new();

        public string ConsultarPerfilBD(int IdUsuario)
        {
            ImagemPerfil ImagemConsulta= Ctx.ImagemPerfils.FirstOrDefault(Img => Img.IdUsario == IdUsuario);
            if (ImagemConsulta != null)
            {
                return Convert.ToBase64String(ImagemConsulta.Binario);
            }
            else return null;
        }

        public string ConsultarPerfilDir(int IdUsuario)
        {
            string NomeArquivo = IdUsuario.ToString() + ".png";
            string Caminho = Path.Combine("perfil", NomeArquivo);
            if (File.Exists(Caminho))
            {
                byte[] BytesArquivo = File.ReadAllBytes(Caminho);

                return Convert.ToBase64String(BytesArquivo);
            }
            else return null;
        }

        public Usuario Login(string Email, string Senha)
        {
            return Ctx.Usuarios.FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }

        public void SalvarPerfilBD(IFormFile Foto, int IdUsuario)
        {
            ImagemPerfil ImagemUsuario = new ImagemPerfil();

            using (var ms = new MemoryStream())
            {
                Foto.CopyTo(ms);
                ImagemUsuario.Binario = ms.ToArray();
                ImagemUsuario.NomeArquivo = Foto.FileName;
                ImagemUsuario.MimeType = Foto.FileName.Split(".").Last();
                ImagemUsuario.IdUsario = IdUsuario;
            }

            ImagemPerfil ImagemExistente = Ctx.ImagemPerfils.FirstOrDefault(Img => Img.IdUsario == IdUsuario);

            if (ImagemExistente != null)
            {
                ImagemExistente.Binario = ImagemUsuario.Binario;
                ImagemExistente.NomeArquivo = ImagemUsuario.NomeArquivo;
                ImagemExistente.MimeType = ImagemUsuario.MimeType;
                ImagemExistente.IdUsario = IdUsuario;
                Ctx.ImagemPerfils.Update(ImagemExistente);
            }
            else Ctx.ImagemPerfils.Add(ImagemUsuario);

            Ctx.SaveChanges();
        }

        public void SalvarPerfilDir(IFormFile Foto, int IdUsuario)
        {
            string NomeArquivo = IdUsuario.ToString() + ".png";

            using (var Stream = new FileStream(Path.Combine("perfil", NomeArquivo), FileMode.Create))
            {
                Foto.CopyTo(Stream);
            }
        }
    }
}
