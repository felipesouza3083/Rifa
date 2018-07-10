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
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public Perfil Perfil { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string login, string senha, string foto, DateTime dataCadastro)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Foto = foto;
            DataCadastro = dataCadastro;
        }

        public override string ToString()
        {
            return $"Id do Usuário: {IdUsuario}, Nome: {Nome}, E-Mail: {Email}, Data de Cadastro: {DataCadastro}";
        }
    }
}
