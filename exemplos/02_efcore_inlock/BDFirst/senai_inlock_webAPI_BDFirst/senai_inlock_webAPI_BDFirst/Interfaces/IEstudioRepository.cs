using senai_inlock_webAPI_BDFirst.Domains;
using System.Collections.Generic;

namespace senai_inlock_webAPI_BDFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> ListarTodos();
        Estudio BuscarPorId(int IdEstudio);
        void Cadastrar(Estudio NovoEstudio);
        void Atualizar(Estudio EstudioAtualizado, int IdEstudio);
        void Deletar(int IdEstudio);
        List<Estudio> ListarComJogos();
    }
}
