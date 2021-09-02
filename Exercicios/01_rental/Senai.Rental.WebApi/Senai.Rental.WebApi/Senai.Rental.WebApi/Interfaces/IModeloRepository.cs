using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IModeloRepository
    {
        ModeloDomain BuscarPorId(int IdModelo);
    }
}
