using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
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
