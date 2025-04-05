using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class Fantome : Monstre
    {
        public Fantome(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int cagnotte) : base(fonction, matricule, nom, prenom, sexe, cagnotte)
        {
        }

        public override string ToString()
        {
            return "Fantome  : " + base.ToString();
        }
    }
}
