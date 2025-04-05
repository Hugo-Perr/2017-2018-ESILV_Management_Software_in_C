using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class DarkRide : Attraction
    {
        TimeSpan duree;
        bool vehicule;

        // CONSTRUCTEUR DE BASE : 
        public DarkRide(int indentifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TimeSpan duree, bool vehicule) : base ( indentifiant,  nom,  nbMinMonstre,  besoinSpecifique,  typeDeBesoin)
        {
            this.Duree = duree;
            this.Vehicule = vehicule;
        }

        public TimeSpan Duree { get => duree; set => duree = value; }
        public bool Vehicule { get => vehicule; set => vehicule = value; }

        public override string ToString()
        {
            return "Darkride  : " + base.ToString() + "," + Duree + "," + Vehicule;
        }
    }

}
