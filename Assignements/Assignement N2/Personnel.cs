using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class Personnel
    {
        public enum TypeSexe { male, femelle, autre };
        string fonction;
        int matricule;
        string nom;
        string prenom;
        TypeSexe sexe;
        
        public int Matricule
        {
            get { return matricule; }
        }

        public TypeSexe Sexe { get => sexe; set => sexe = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Fonction { get => fonction; set => fonction = value; }

        public Personnel(string fonction, int matricule, string nom, string prenom, TypeSexe sexe)
        {
            this.Fonction = fonction;
            this.matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Sexe = sexe;
        }

        public override string ToString()
        {
            return Fonction + "," + matricule + "," + Nom + "," + Prenom + "," + Sexe;
        }
    }
}
