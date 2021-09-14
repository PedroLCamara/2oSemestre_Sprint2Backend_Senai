using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webAPI_BDFirst.Interfaces;
using senai_inlock_webAPI_BDFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_BDFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepositorio { get; set; }
        public JogosController()
        {
            JogoRepositorio = new JogoRepository();
        }

        [HttpGet("ListarComEstudio")]
        public IActionResult ListarComEstudio()
        {
            try
            {
                return Ok(JogoRepositorio.ListarComEstudio());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
