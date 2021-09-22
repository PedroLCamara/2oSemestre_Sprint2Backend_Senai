using Gufi.webAPI.Interfaces;
using Gufi.webAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private IUsuarioRepository RUsuario { get; set; }

        public PerfilsController()
        {
            RUsuario = new UsuarioRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpPost("Imagem/BD")]
        public IActionResult PostBD(IFormFile Arquivo)
        {
            try
            {
                if (Arquivo.Length > 5000)
                {
                    return BadRequest("O tamanho do arquivo excedeu o limite de 5MB!");
                }

                if (Arquivo.FileName.Split(".").Last() != "png")
                {
                    return BadRequest("O arquivo deve estar no formato .png!");
                }

                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);

                RUsuario.SalvarPerfilBD(Arquivo, IdUsuario);

                return Ok();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPost("Imagem/Dir")]
        public IActionResult PostDir(IFormFile Arquivo)
        {
            try
            {
                if (Arquivo.Length > 5000)
                {
                    return BadRequest("O tamanho do arquivo excedeu o limite de 5MB!");
                }

                if (Arquivo.FileName.Split(".").Last() != "png")
                {
                    return BadRequest("O arquivo deve estar no formato .png!");
                }

                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);

                RUsuario.SalvarPerfilDir(Arquivo, IdUsuario);

                return Ok();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult GetBD()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);

                string Base64 = RUsuario.ConsultarPerfilBD(IdUsuario);

                return Ok(Base64);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult GetDir()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);

                string Base64 = RUsuario.ConsultarPerfilDir(IdUsuario);

                return Ok(Base64);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}
