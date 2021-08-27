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
            List <FilmeDomain> ListaFilmes = FilmeRepositorio.LerTodos();

            return Ok(ListaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain NovoFilme)
        {
            GeneroRepository GeneroRepositorio = new GeneroRepository();
            GeneroDomain GeneroFilme = GeneroRepositorio.BuscarPorNome(NovoFilme.Genero.NomeGenero);
            if (GeneroFilme != null)
            {
                FilmeRepositorio.Cadastrar(NovoFilme);
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}