using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Exceptions
{
    public class NaoExisteException : Exception
    {
        public NaoExisteException(string message) : base(message)
        {

        }
    }
    
}
