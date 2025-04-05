using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class Monstre : Personnel
    {
        Attraction affectation;

        public int cagnotte;

        public Attraction Affectation  { get =>  affectation; set => value = affectation; }

        

        public Monstre(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, int cagnotte) : base(fonction, matricule, nom, prenom, sexe)
        {
            affectation = null ; // de base : on affecte aucune attraction aux monstres
            this.cagnotte = cagnotte;
        }



        public override string ToString()
        {
            if (affectation == null)
            { return "Monstre," + base.ToString() + "," + " pas d'attraction " + "," + cagnotte; }
            else
            { return "Monstre," + base.ToString() + "," + affectation.Identifiant + "," + cagnotte; }
        }

        public void Ajouter_Affectation(Attraction at)
        {
            affectation = at;
        }
    }
}
