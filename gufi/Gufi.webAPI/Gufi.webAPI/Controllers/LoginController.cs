using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using Gufi.webAPI.Repositories;
using Gufi.webAPI.ViewsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gufi.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository RUsuario { get; set; }

        public LoginController()
        {
            RUsuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Login)
        {
            try
            {
                Usuario UsuarioConsulta = RUsuario.Login(Login.Email, Login.Senha);

                if (UsuarioConsulta == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioConsulta.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioConsulta.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioConsulta.IdTipoUsuario.ToString())
                };

                var Chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                var Credenciais = new SigningCredentials(Chave, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken(
                        issuer: "gufi.webAPI",
                        audience: "gufi.webAPI",
                        claims: Claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: Credenciais
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(Token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
