using Rifa.Entidades;
using Rifa.Repositorio.Context;
using Rifa.Repositorio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Repositorio.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>,
        IUsuarioRepository
    {
        public Usuario Find(string login, string senha)
        {
            using(DataContext d = new DataContext())
            {
                return d.Usuario.FirstOrDefault(u => u.Login.Equals(login)
                                                  && u.Senha.Equals(senha));
            }
        }

        public bool HasLogin(string login)
        {
            using(DataContext d = new DataContext())
            {
                return d.Usuario.Count(u => u.Login.Equals(login)) > 0;
            }
        }
    }
}
