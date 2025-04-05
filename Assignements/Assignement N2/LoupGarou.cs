using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class LoupGarou : Monstre
    {
        double indiceCruaute;

        public LoupGarou(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int cagnotte, double indiceCruaute) : base (fonction, matricule, nom, prenom, sexe, cagnotte)
        {
            this.IndiceCruaute = indiceCruaute;
        }

        public double IndiceCruaute { get => indiceCruaute; set => indiceCruaute = value; }

        public override string ToString()
        {
            return "LoupGarou  : " + base.ToString() + "," + IndiceCruaute;
        }
    }
}
