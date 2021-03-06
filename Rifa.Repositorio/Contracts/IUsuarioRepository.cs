﻿using Rifa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Repositorio.Contracts
{
    public interface IUsuarioRepository:IBaseRepository<Usuario>
    {
        Usuario Find(string login, string senha);

        bool HasLogin(string login);
    }
}
