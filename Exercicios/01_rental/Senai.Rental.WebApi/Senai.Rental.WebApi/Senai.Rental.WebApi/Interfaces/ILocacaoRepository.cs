using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface ILocacaoRepository
    {
        List<LocacaoDomain> ListarTodos();
        LocacaoDomain BuscarPorId(int IdLocacao);
        void Cadastrar(LocacaoDomain NovaLocacao);
        void Atualizar(LocacaoDomain LocacaoAtualizada);
        void Atualizar(LocacaoDomain LocacaoAtualizada, int IdLocacao);
        void Deletar(int IdLocacaoDeletada);
    }
}