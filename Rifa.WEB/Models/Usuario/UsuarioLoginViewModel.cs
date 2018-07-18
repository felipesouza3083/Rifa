using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rifa.WEB.Models.Usuario
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}