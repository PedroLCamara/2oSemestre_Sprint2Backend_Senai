using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository ClienteRepositorio;

        public ClientesController()
        {
            ClienteRepositorio = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> Clientes = ClienteRepositorio.ListarTodos();
            return Ok(Clientes);
        }

        [HttpGet("{IdCliente}")]
        public IActionResult GetById(int IdCliente)
        {
            try
            {
                ClienteDomain Cliente = ClienteRepositorio.BuscarPorId(IdCliente);
                if (Cliente != null)
                {
                        return Ok(Cliente); 
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Nenhum cliente possui esse Id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain NovoCliente)
        {
            try
            {
                ClienteRepositorio.Cadastrar(NovoCliente);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut("{IdCliente}")]
        public IActionResult Update(ClienteDomain ClienteAtualizado, int IdCliente)
        {
            try
            {
                ClienteDomain ClienteConsulta = ClienteRepositorio.BuscarPorId(IdCliente);
                if (ClienteConsulta != null)
                {
                    ClienteRepositorio.Atualizar(ClienteAtualizado, IdCliente);
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Nenhum cliente possui esse id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut]
        public IActionResult Update(ClienteDomain ClienteAtualizado)
        {
            try
            {
                ClienteDomain ClienteConsulta = ClienteRepositorio.BuscarPorId(ClienteAtualizado.IdCliente);
                if (ClienteConsulta != null)
                {
                    ClienteRepositorio.Atualizar(ClienteAtualizado);
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Nenhum cliente possui esse id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpDelete("{IdCliente}")]
        public IActionResult Delete(int IdCliente)
        {
            try
            {
                ClienteDomain ClienteConsulta = ClienteRepositorio.BuscarPorId(IdCliente);
                if (ClienteConsulta != null)
                {
                    ClienteRepositorio.Deletar(IdCliente);
                    return NoContent();
                }
                else
                {
                    return NotFound(new {
                        Erro = "Id inválido",
                        Descricao = "Nenhum cliente possui esse id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}
