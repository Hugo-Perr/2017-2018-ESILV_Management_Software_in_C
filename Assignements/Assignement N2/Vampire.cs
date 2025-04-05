using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class Vampire : Monstre
    {
        double indiceLuminosite;

        public Vampire(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int cagnotte, double indiceLuminosite) : base(fonction, matricule, nom, prenom, sexe, cagnotte)
        {
            this.IndiceLuminosite = indiceLuminosite;
        }

        public double IndiceLuminosite { get => indiceLuminosite; set => indiceLuminosite = value; }

        public override string ToString()
        {
            return  "Vampire  : " + base.ToString() + "," + IndiceLuminosite;
        }
    }
}
