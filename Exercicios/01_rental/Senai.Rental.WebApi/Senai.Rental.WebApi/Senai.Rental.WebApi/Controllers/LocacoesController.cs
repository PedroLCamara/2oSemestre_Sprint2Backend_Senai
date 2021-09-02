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
    public class LocacoesController : ControllerBase
    {
        private ILocacaoRepository LocacaoRepositorio;
        
        public LocacoesController()
        {
            LocacaoRepositorio = new LocacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<LocacaoDomain> Locacoes = LocacaoRepositorio.ListarTodos();

            return Ok(Locacoes);
        }

        [HttpGet("{IdLocacao}")]
        public IActionResult GetById(int IdLocacao)
        {
            try
            {
                LocacaoDomain Locacao = LocacaoRepositorio.BuscarPorId(IdLocacao);
                if (Locacao != null)
                {
                    return Ok(Locacao);
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Não há uma locação com esse id"
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
        public IActionResult Post(LocacaoDomain NovaLocacao)
        {
            try
            {
                LocacaoRepositorio.Cadastrar(NovaLocacao);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut("{IdLocacao}")]
        public IActionResult Update(LocacaoDomain LocacaoAtualizada, int IdLocacao)
        {
            try
            {
                LocacaoDomain LocacaoConsulta = LocacaoRepositorio.BuscarPorId(IdLocacao);
                if (LocacaoConsulta != null)
                {
                    LocacaoRepositorio.Atualizar(LocacaoAtualizada, IdLocacao);
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Nenhuma locação possui este id"
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
        public IActionResult Update(LocacaoDomain LocacaoAtualizada)
        {
            try
            {
                LocacaoDomain LocacaoConsulta = LocacaoRepositorio.BuscarPorId(LocacaoAtualizada.IdLocacao);
                if (LocacaoConsulta != null)
                {
                    LocacaoRepositorio.Atualizar(LocacaoAtualizada);
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Erro = "Id inválido",
                        Descricao = "Nenhuma locação possui este id"
                    });
                }
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpDelete("{IdLocacao}")]
        public IActionResult Delete(int IdLocacao)
        {
            try
            {
                LocacaoDomain LocacaoConsulta = LocacaoRepositorio.BuscarPorId(IdLocacao);
                if (LocacaoConsulta != null)
                {
                    LocacaoRepositorio.Deletar(IdLocacao);
                    return NoContent();
                }
                else
                {
                    return NotFound(new { 
                        Erro= "Id inválido",
                        Descricao= "Nenhuma locação possui este id"
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