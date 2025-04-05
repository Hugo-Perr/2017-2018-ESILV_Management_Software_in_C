using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class Zombie : Monstre
    {
        public enum CouleurZ { bleuatre, grisatre};
        int degreDecomposition;
        CouleurZ teint;

        public int DegreDecomposition { get => degreDecomposition; set => degreDecomposition = value; }
        public CouleurZ Teint { get => teint; set => teint = value; }

        public Zombie(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int degreDecomposition, CouleurZ teint, int cagnotte) : base(fonction, matricule, nom, prenom, sexe, cagnotte)
        {
            this.DegreDecomposition = degreDecomposition;
            this.Teint = teint;
        }

        public override string ToString()
        {
            return "Zombie  : " + base.ToString() + "," + DegreDecomposition + "," + Teint;
        }
    }
}
