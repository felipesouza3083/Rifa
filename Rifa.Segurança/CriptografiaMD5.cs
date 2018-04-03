using Rifa.Segurança.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Segurança
{
    public class CriptografiaMD5 : ICriptografia
    {
        public string Encriptar(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //para encriptar, precisamos converter o valor
            //de string para bytes..
            byte[] valorEmBytes = Encoding.UTF8.GetBytes(valor);

            //realizar a criptografia..
            byte[] hash = md5.ComputeHash(valorEmBytes);

            //converter o resultado da criptografia (hash)
            //de formato byte para formato string..
            string resultado = string.Empty;

            //varrer o vetor de bytes
            foreach(byte b in hash)
            {
                resultado += b.ToString("X2");
            }

            //retornando o resultado
            return resultado;
        }
    }
}
