using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository FilmeRepositorio;

        public FilmesController()
        {
            FilmeRepositorio = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> ListaFilmes = FilmeRepositorio.LerTodos();
            return Ok(ListaFilmes);
        }

        [HttpGet("{IdFilme}")]
        public IActionResult GetById(int IdFilme)
        {
            FilmeDomain FilmeConsulta = FilmeRepositorio.BuscarPorId(IdFilme);

            if (FilmeConsulta == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(FilmeConsulta);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain NovoFilme)
        {
            FilmeRepositorio.Cadastrar(NovoFilme);
            return StatusCode(201);
        }

        [HttpDelete("Excluir/{IdFilme}")]

        public IActionResult Delete(int IdFilme)
        {
            FilmeRepositorio.Deletar(IdFilme);
            return StatusCode(201);
        }

        [HttpDelete]

        public IActionResult Delete(FilmeDomain FilmeDeletado)
        {
            FilmeRepositorio.Deletar(FilmeDeletado.IdFilme);
            return StatusCode(201);
        }

        [HttpPut("{IdFilme}")]
        public IActionResult Update(int IdFilme, FilmeDomain FilmeAtualizado)
        {
            FilmeDomain FilmeConsulta = FilmeRepositorio.BuscarPorId(IdFilme);

            if (FilmeConsulta == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Filme não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                FilmeRepositorio.Atualizar(FilmeAtualizado, IdFilme);

                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpPut]
        public IActionResult Update(FilmeDomain FilmeAtualizado)
        {
            if (FilmeAtualizado.Titulo == null || FilmeAtualizado.IdFilme <= 0 || FilmeAtualizado.IdGenero <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou o id do filme não foi informado!"
                    });
            }

            FilmeDomain FilmeConsulta = FilmeRepositorio.BuscarPorId(FilmeAtualizado.IdFilme);

            if (FilmeConsulta != null)
            {
                try
                {
                    FilmeRepositorio.Atualizar(FilmeAtualizado);

                    return NoContent();
                }
                catch (Exception Erro)
                {
                    return BadRequest(Erro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Filme não encontrado!",
                        errorStatus = true
                    }
                );
        }
    }
}