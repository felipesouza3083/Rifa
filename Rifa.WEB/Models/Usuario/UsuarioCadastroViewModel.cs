using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rifa.WEB.Models
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido")]
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres")]
        public string Senha { get; set; }
    }
}