using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class Attraction
    {
        int identifiant;
        string nom;
        int nbMinMonstre;
        bool besoinSpecifique;
        string typeDeBesoin;
        List<Monstre> equipe;

        bool ouvert;      // nous considèrerons que ouvert correspond à pas en maintenance et inversement
        bool maintenance;
        TimeSpan dureeMaintenance;  
        string natureMaintenance;    
       

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public string Nom { get => nom; set => nom = value; }
        public int NbMinMonstre { get => nbMinMonstre; set => nbMinMonstre = value; }
        public bool BesoinSpecifique { get => besoinSpecifique; set => besoinSpecifique = value; }
        public string TypeDeBesoin { get => typeDeBesoin; set => typeDeBesoin = value; }
        public bool Ouvert { get => ouvert; set => ouvert = value; }
        public bool Maintenance { get => maintenance; set => maintenance = value; }
        public List<Monstre> Equipe { get => equipe; set => equipe = value; }
        public string NatureMaintenance { get => natureMaintenance; set => natureMaintenance = value; }

        // CONSTRUCTEUR DE BASE


        public Attraction(int indentifiant, string nom, int nbMinMonstre, bool besoinSpecifique,string typeDeBesoin)
        {
            this.Identifiant = indentifiant;
            this.Nom = nom;
            this.NbMinMonstre = nbMinMonstre;
            this.BesoinSpecifique = besoinSpecifique;
            this.TypeDeBesoin = typeDeBesoin;

            List<Monstre> equipe = new List<Monstre>();
            this.equipe = equipe;
            Ouvert = true;
            Maintenance = false;
            TimeSpan dureeMaintenance = new TimeSpan(0, 0, 0);
            this.dureeMaintenance = dureeMaintenance;
            natureMaintenance = "";     
        }

        
        public override string ToString()
        {
            string temp = "";
            int compteur = 0;
            if (temp != null) // permet d'afficher de manière jolie l'équipe (pas mettre juste les identifiants)
            {
                temp = "[";
                foreach (Monstre m in Equipe)
                {
                    temp = temp + m.Matricule.ToString() + ",";
                    compteur += 1;
                }
                temp = temp + "]";
            }
            string equipe_ = "Equipe contient " + compteur + " monstre(s):" + temp;
            return BesoinSpecifique + "," + equipe_ + "," + Identifiant + ","  + NbMinMonstre + "," + Nom + "," + TypeDeBesoin + "," + Maintenance + "," + NatureMaintenance;
        }
    }
}
