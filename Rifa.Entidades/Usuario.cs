using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string senha)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override string ToString()
        {
            return $" Id: {IdUsuario}, Nome: {Nome}, Email: {Email}";
        }
    }
}
