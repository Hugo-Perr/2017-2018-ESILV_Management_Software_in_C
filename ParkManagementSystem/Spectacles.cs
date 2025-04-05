using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class Spectacles : Attraction
    {
        List<DateTime> horaire;
        int nombrePlace;
        string nomSalle;

        public List<DateTime> Horaire { get => horaire; set => horaire = value; }
        public int NombrePlace { get => nombrePlace; set => nombrePlace = value; }
        public string NomSalle { get => nomSalle; set => nomSalle = value; }

        // CONSTRUCTEUR DE BASE:
        public Spectacles(int indentifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, List<DateTime> horaire,int nombrePlace, string nomSalle) : base(indentifiant,  nom,  nbMinMonstre,  besoinSpecifique,  typeDeBesoin)
        {
            this.Horaire = horaire;
            this.NombrePlace = nombrePlace;
            this.NomSalle = nomSalle;
        }

        public override string ToString()
        {
            return "Spectacle  : " + base.ToString() + "," + AfficherHoraires(Horaire) + "," + NombrePlace + "," + NomSalle;
        }

        public string AfficherHoraires(List<DateTime> Horaire)
        {
            string chaine = "[" + String.Join(",", Horaire.ToArray()) + "]";
            return chaine;
        }
    }
}
