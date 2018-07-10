using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Entidades
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string NomePerfil { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Perfil()
        {

        }

        public Perfil(int idPerfil, string nomePerfil)
        {
            IdPerfil = idPerfil;
            NomePerfil = nomePerfil;
        }

        public override string ToString()
        {
            return $"Id do Perfil:{IdPerfil}, Nome: {NomePerfil}";
        }
    }
}
