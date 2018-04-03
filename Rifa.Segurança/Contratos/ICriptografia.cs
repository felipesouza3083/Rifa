using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifa.Segurança.Contratos
{
    public interface ICriptografia
    {
        string Encriptar(string valor);
    }
}
