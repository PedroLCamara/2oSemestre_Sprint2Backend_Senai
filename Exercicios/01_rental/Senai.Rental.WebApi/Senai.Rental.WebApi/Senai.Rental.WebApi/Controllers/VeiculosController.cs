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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository VeiculoRepositorio;
        public VeiculosController()
        {
            VeiculoRepositorio = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> Veiculos = VeiculoRepositorio.ListarTodos();
            return Ok(Veiculos);
        }

        [HttpGet("{IdVeiculo}")]
        public IActionResult GetById(int IdVeiculo)
        {
            try
            {
                VeiculoDomain Veiculo = VeiculoRepositorio.BuscarPorId(IdVeiculo);
                if (Veiculo != null)
                {
                    return Ok(Veiculo);
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Não há veículos com esse id"
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
        public IActionResult Post(VeiculoDomain NovoVeiculo)
        {
            //try
            //{
                VeiculoRepositorio.Cadastrar(NovoVeiculo);
                return StatusCode(201);
            //}
            //catch (Exception Erro)
            //{
             //   return BadRequest(Erro);
            //    throw;
            //}
        }

        [HttpPut("{IdVeiculo}")]
        public IActionResult Update(VeiculoDomain VeiculoAtualizado, int IdVeiculo)
        {
            try
            {
                VeiculoDomain VeiculoConsulta = VeiculoRepositorio.BuscarPorId(IdVeiculo);
                if (VeiculoConsulta != null)
                {
                    VeiculoRepositorio.Atualizar(VeiculoAtualizado, IdVeiculo);
                    return NoContent();
                }
                else
                {
                    return NotFound(new {
                        Erro= "Id inválido",
                        Descricao= "Não há veículos com esse id"
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
        public IActionResult Update(VeiculoDomain VeiculoAtualizado)
        {
            try
            {
                VeiculoDomain VeiculoConsulta = VeiculoRepositorio.BuscarPorId(VeiculoAtualizado.IdVeiculo);
                if (VeiculoConsulta != null)
                {
                    VeiculoRepositorio.Atualizar(VeiculoAtualizado);
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Não há veículos com esse id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpDelete("{IdVeiculo}")]
        public IActionResult Delete(int IdVeiculo)
        {
            try
            {
                VeiculoDomain VeiculoConsulta = VeiculoRepositorio.BuscarPorId(IdVeiculo);
                if (VeiculoConsulta != null)
                {
                    VeiculoRepositorio.Deletar(IdVeiculo);
                    return NoContent();
                }
                else
                {
                    return NotFound(new { 
                        Erro = "Id inválido",
                        Descricao = "Não há veículos com esse id"
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
