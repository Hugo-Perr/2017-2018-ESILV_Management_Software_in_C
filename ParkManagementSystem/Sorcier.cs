using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_PFR_Rendu_3
{
    class Sorcier : Personnel
    {
        public enum Grade { novice, mega, giga, strata};
        List<String> pouvoirs;
        Grade tatouage;

        public List<string> Pouvoirs { get => pouvoirs; set => pouvoirs = value; }
        internal Grade Tatouage { get => tatouage; set => tatouage = value; }

        public Sorcier(string fonction, int matricule, string nom, string prenom, TypeSexe sexe, List<String> pouvoirs, Grade tatouage) : base(fonction, matricule, nom, prenom, sexe)
        {
            this.Pouvoirs = pouvoirs;
            this.Tatouage = tatouage;
        }

        public override string ToString()
        {
            return "Sorcier  : " + base.ToString() + "," + AfficherPouvoirs(Pouvoirs) + "," + Tatouage;
        }

        public string AfficherPouvoirs(List<String> pouvoirs)
        {
            string chaine = "[" +  String.Join(",", pouvoirs.ToArray()) + "]";
            return chaine;
        }
    }
}
