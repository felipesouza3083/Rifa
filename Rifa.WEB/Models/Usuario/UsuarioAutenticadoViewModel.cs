﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rifa.WEB.Models.Usuario
{
    public class UsuarioAutenticadoViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}