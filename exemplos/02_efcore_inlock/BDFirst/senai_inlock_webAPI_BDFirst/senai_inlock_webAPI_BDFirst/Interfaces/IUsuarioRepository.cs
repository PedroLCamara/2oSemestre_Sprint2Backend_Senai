﻿using senai_inlock_webAPI_BDFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_BDFirst.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Logar(string Email, string Senha);
    }
}
