using Gufi.webAPI.Contexts;
using Gufi.webAPI.Domains;
using Gufi.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.webAPI.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private GufiContext Ctx = new();

        public void AtualizarStatus(int IdPresenca, string Status)
        {
            Presenca PresencaBuscada = Ctx.Presencas
                .FirstOrDefault(p => p.IdPresenca == IdPresenca);

            switch (Status)
            {
                case "1":
                    PresencaBuscada.IdSituacaoPresenca = 1;
                    break;

                case "2":
                    PresencaBuscada.IdSituacaoPresenca = 2;
                    break;

                case "3":
                    PresencaBuscada.IdSituacaoPresenca = 3;
                    break;

                default:
                    PresencaBuscada.IdSituacaoPresenca = PresencaBuscada.IdSituacaoPresenca;
                    break;
            }

            Ctx.Presencas.Update(PresencaBuscada);

            Ctx.SaveChanges();
        }

        public void Inscrever(Presenca Inscricao)
        {
            Ctx.Presencas.Add(Inscricao);

            Ctx.SaveChanges();
        }

        public List<Presenca> ListarMinhas(int Id)
        {
            return Ctx.Presencas.Where(P => P.IdUsuario == Id).ToList();
        }
    }
}
