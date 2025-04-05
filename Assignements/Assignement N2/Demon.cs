using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class Demon : Monstre
    {
        int force;
        public int Force { get => force; set => force = value; }
        public Demon(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int cagnotte, int force) : base(fonction, matricule, nom, prenom, sexe, cagnotte)
        {
            this.force = force;
        }

        public override string ToString()
        {
            return "Demon  : " + base.ToString() +"," + force;
        }
    }
}
