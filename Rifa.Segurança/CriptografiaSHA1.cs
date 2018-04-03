using Rifa.Segurança.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Rifa.Segurança
{
    public class CriptografiaSHA1 : ICriptografia
    {
        public string Encriptar(string valor)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] valorEmBytes = Encoding.UTF8.GetBytes(valor);

            byte[] hash = sha1.ComputeHash(valorEmBytes);

            string resultado = string.Empty;

            foreach(byte b in hash)
            {
                resultado += b.ToString("X2");
            }

            return resultado;
        }
    }
}
