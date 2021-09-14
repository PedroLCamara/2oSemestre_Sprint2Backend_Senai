using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_inlock_webAPI_BDFirst.Domains;
using senai_inlock_webAPI_BDFirst.Interfaces;
using senai_inlock_webAPI_BDFirst.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_BDFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario Login)
        {
            try
            {
                Usuario UsuarioLogin = UsuarioRepositorio.Logar(Login.Email, Login.Senha);
                if (UsuarioLogin != null)
                {
                    var ClaimsToken = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, UsuarioLogin.Email),
                        new Claim(JwtRegisteredClaimNames.NameId, UsuarioLogin.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, UsuarioLogin.IdTipoUsuarioNavigation.Titulo)
                    };
                    var ChaveToken = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ChaveSeguraInLock"));
                    var CredenciaisToken = new SigningCredentials(ChaveToken, SecurityAlgorithms.HmacSha256);
                    var LoginToken = new JwtSecurityToken
                    (
                        issuer: "senai.inlock.webAPI.BDFirst",
                        audience: "senai.inlock.webAPI.BDFirst",
                        claims: ClaimsToken,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: CredenciaisToken
                    );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(LoginToken)
                    });
                }
                else return BadRequest("Email ou senha inválidos!!!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
