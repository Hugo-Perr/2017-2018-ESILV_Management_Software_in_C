using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge_2_
{
    class Boutique : Attraction
    {
        public enum TypeBoutique { souvenir, barbeAPapa, nourriture};
        TypeBoutique type;

        public TypeBoutique Type { get => type; set => type = value; }


        // CONSTRUCTEUR DE BASE :
        public Boutique(int indentifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TypeBoutique type) : base(indentifiant, nom, nbMinMonstre, besoinSpecifique, typeDeBesoin)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return "Boutique  : " + base.ToString() + "," + type;
        }
    }
}
