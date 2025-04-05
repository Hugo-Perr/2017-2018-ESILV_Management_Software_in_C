using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class RollerCoaster : Attraction
    {
        public enum TypeCategorie { assise, inversee, bobsleigh};
        TypeCategorie categorie;
        int ageMinimum;
        float tailleMinimum;

        internal TypeCategorie Categorie { get => categorie; set => categorie = value; }
        public int AgeMinimum { get => ageMinimum; set => ageMinimum = value; }
        public float TailleMinimum { get => tailleMinimum; set => tailleMinimum = value; }


        // CONSTRUCTEUR DE BASE : 
        public RollerCoaster(int indentifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TypeCategorie categorie, int ageMinimum, float tailleMinimum) : base(indentifiant, nom, nbMinMonstre, besoinSpecifique, typeDeBesoin)
        {
            this.Categorie = categorie;
            this.AgeMinimum = ageMinimum;
            this.TailleMinimum = tailleMinimum;
        }

        public override string ToString()
        {
            return "RollerCoaster  : " + base.ToString() + "," + AgeMinimum + "," + Categorie + "," + TailleMinimum;
        }
    }
}
