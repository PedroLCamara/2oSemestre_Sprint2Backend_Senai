﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Controlador responsável pelo end points referentes aos generos.
/// </summary>

namespace senai_filmes_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no Formato JSON.
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]

    public class GenerosController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IGeneroRepository 
        /// </summary>
        private IGeneroRepository GeneroRepositorio { get; set; }


        /// <summary>
        /// Instacia um objeto GeneroRepositorio para que haja a referencia dos método no reposotório.
        /// </summary>
        public GenerosController()
        {
            GeneroRepositorio = new GeneroRepository();
        }

        [HttpGet]

        //IActionResult = Resultado de uma acao.
        //Get() = nome generico
        public IActionResult Get()
        {
            //Lista de generos
            //Se conectar com o Repositorio.
            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> ListaGeneros = GeneroRepositorio.LerTodos();

            //Retorna os status code 200(OK) com a lista generos no formato JSON
            return Ok(ListaGeneros);
        }

        [HttpPost]

        
        public IActionResult Post(GeneroDomain NovoGenero)
        {
            //Chama o método cadastrar do GeneroRepository
            GeneroRepositorio.Cadastrar(NovoGenero);

            //Retorna um status code 201, significado: Created
            return StatusCode(201);
        }
    }
}
