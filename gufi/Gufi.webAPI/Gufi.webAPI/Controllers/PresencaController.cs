using Gufi.webAPI.Domains;
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
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository RPresenca { get; set; }
        public PresencaController()
        {
            RPresenca = new PresencaRepository();
        }

        [HttpGet("Minhas")]
        [Authorize(Roles = "2")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(RPresenca.ListarMinhas(IdUsuario));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPost("Inscricao/{IdEvento}")]
        [Authorize(Roles = "2")]
        public IActionResult Inscrever(int IdEvento)
        {
            try
            {
                Presenca NovaPresenca = new()
                {
                    IdEvento = IdEvento,
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value),
                    IdSituacaoPresenca = 3
                };

                RPresenca.Inscrever(NovaPresenca);

                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPatch("Aprovar/{IdPresenca}")]
        [Authorize(Roles = "1")]
        public IActionResult AtualizarStatus(int IdPresenca, Presenca Status)
        {
            try
            {
                RPresenca.AtualizarStatus(IdPresenca, Status.IdSituacaoPresenca.ToString());

                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}
