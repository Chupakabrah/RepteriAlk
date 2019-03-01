using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepteriAlkalmazas
{
    class NegativKesesException : Exception
    {
        public NegativKesesException(string jaratSzam) : base("A késést a " + jaratSzam + " számú járat behozta!")
        {

        }

    }
}
