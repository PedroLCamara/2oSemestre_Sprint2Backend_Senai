using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using Gufi.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventosController : ControllerBase
    {
        private ITipoEventoRepository TpERepositorio;
        public TiposEventosController()
        {
            TpERepositorio = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(TpERepositorio.ListarTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpGet("{IdTpEventoBuscado}")]
        public IActionResult BuscarPorId(int IdTpEventoBuscado)
        {
            try
            {
                return Ok(TpERepositorio.BuscarPorId(IdTpEventoBuscado));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoEvento NovoTipoEvento)
        {
            try
            {
                TpERepositorio.Cadastrar(NovoTipoEvento);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut("{IdTipoEventoAtualizado}")]
        public IActionResult Atualizar(TipoEvento TipoEventoAtualizado, int IdTipoEventoAtualizado)
        {
            try
            {
                TpERepositorio.Atualizar(IdTipoEventoAtualizado, TipoEventoAtualizado);
                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpDelete("{IdTipoEventoDeletado}")]
        public IActionResult Deletar(int IdTipoEventoDeletado)
        {
            try
            {
                TpERepositorio.Deletar(IdTipoEventoDeletado);
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
