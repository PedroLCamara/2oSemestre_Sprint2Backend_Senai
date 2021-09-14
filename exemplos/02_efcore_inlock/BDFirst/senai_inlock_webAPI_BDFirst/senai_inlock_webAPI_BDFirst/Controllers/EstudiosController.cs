using Microsoft.AspNetCore.Mvc;
using senai_inlock_webAPI_BDFirst.Domains;
using senai_inlock_webAPI_BDFirst.Interfaces;
using senai_inlock_webAPI_BDFirst.Repositories;
using System;

namespace senai_inlock_webAPI_BDFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository EstudioRepositorio { get; set; }

        public EstudiosController()
        {
            EstudioRepositorio = new EstudioRepository();
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(EstudioRepositorio.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("BuscarPorId/{IdEstudio}")]
        public IActionResult BuscarPorId(int IdEstudio)
        {
            try
            {
                return Ok(EstudioRepositorio.BuscarPorId(IdEstudio));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Estudio NovoEstudio)
        {
            try
            {
                EstudioRepositorio.Cadastrar(NovoEstudio);
                return StatusCode(201);
            }
            catch (Exception erro )
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPut("Atualizar/{IdEstudio}")]
        public IActionResult Atualizar(Estudio EstudioAtualizado, int IdEstudio)
        {
            try
            {
                EstudioRepositorio.Atualizar(EstudioAtualizado, IdEstudio);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("Deletar/{IdEstudio}")]
        public IActionResult Deletar(int IdEstudio)
        {
            try
            {
                EstudioRepositorio.Deletar(IdEstudio);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        
        [HttpGet("ListarComJogos")]
        public IActionResult ListarComJogos()
        {
            try
            {
                return Ok(EstudioRepositorio.ListarComJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}