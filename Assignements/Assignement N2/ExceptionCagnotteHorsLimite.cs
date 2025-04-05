using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class ExceptionCagnotteHorsLimite : Exception
    {
        public ExceptionCagnotteHorsLimite(int Entier, int Min) :
        base(string.Format("La nouvelle cagnotte de {0} serait inférieure à {1}",
        Entier, Min))
        { }
    }
}
