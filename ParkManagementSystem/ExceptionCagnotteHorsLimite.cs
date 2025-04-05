using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class ExceptionCagnotteHorsLimite : Exception
    {
        public ExceptionCagnotteHorsLimite(int Entier, int Min) :
        base(string.Format("La nouvelle cagnotte de {0} serait inférieure à {1}",
        Entier, Min))
        { }
    }
}
