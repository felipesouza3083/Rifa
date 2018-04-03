using Rifa.Entidades;
using Rifa.Segurança;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.DAL
{
    public class UsuarioRepositorio : Conexao
    {
        public void Insert(Usuario u)
        {
            OpenConnection();

            CriptografiaMD5 md5 = new CriptografiaMD5();

            string query = "insert into Usuario(nomeUsuario, emailUsuario, senhaUsuario) "
                         + "values(@nomeUsuario, @emailUsuario, @senhaUsuario)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nomeUsuario", u.Nome);
            cmd.Parameters.AddWithValue("@emailUsuario", u.Email);
            cmd.Parameters.AddWithValue("@senhaUsuario", md5.Encriptar(u.Senha));
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Usuario u)
        {
            OpenConnection();

            CriptografiaMD5 md5 = new CriptografiaMD5();

            string query = "update Usuario set nomeUsuario = @nomeUsuario, emailUsuario = @emailUsuario, senhaUsuario = @senhaUsuario "
                         + "where idUsuario = @idUsuario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idUsuario", u.IdUsuario);
            cmd.Parameters.AddWithValue("@nomeUsuario", u.Nome);
            cmd.Parameters.AddWithValue("@emailUsuario", u.Email);
            cmd.Parameters.AddWithValue("@senhaUsuario", md5.Encriptar(u.Senha));
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idUsuario)
        {
            OpenConnection();

            string query = "delete from Usuario where idUsuario = @idUsuario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Usuario> FindAll()
        {
            OpenConnection();

            string query = "select * from Usuario";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (dr.Read())
            {
                Usuario u = new Usuario();

                u.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                u.Nome = Convert.ToString(dr["nomeUsuario"]);
                u.Email = Convert.ToString(dr["emailUsuario"]);
                u.Senha = Convert.ToString(dr["senhaUsuario"]);

                lista.Add(u);
            }
            
            CloseConnection();
            return lista;
        }

        public Usuario FindById(int idUsuario)
        {
            OpenConnection();

            string query = "select * from Usuario where idUsuario = @idUsuario";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            dr = cmd.ExecuteReader();

            Usuario u = null;
            if (dr.Read())
            {
                u = new Usuario();

                u.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                u.Nome = Convert.ToString(dr["nomeUsuario"]);
                u.Email = Convert.ToString(dr["emailUsuario"]);
                u.Senha = Convert.ToString(dr["senhaUsuario"]);
            }

            CloseConnection();
            return u;
        }
    }
}
