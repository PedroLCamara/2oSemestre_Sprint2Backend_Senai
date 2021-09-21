using Gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> ListarMinhas(int Id);
        void Inscrever(Presenca Inscricao);
        void AtualizarStatus(int IdPresenca, string Status);
    }
}
