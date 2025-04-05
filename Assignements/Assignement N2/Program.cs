using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // pour utiliser le streamReader
using System.Globalization; // pour la gestion de l'heure


namespace ProjetFilRouge_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // QUESTION 1 et 2
            Console.WriteLine("LECTURE FICHIER CSV  -  CREATION DES LISTES");
            Administration monAdministration = new Administration();
            monAdministration.Lecture_CSV_initialisation("Listing.csv");
            
            Console.WriteLine("\n----- AFFICHAGE DES ATTRACTIONS : ----------------------------------------------------------------------------------------------------");
            monAdministration.AfficherAttraction();
            Console.WriteLine("\n----- AFFICHAGE DES MEMBRES DU PERSONNEL: --------------------------------------------------------------------------------------------");
            monAdministration.AffichePersonnel();
            Console.WriteLine("\n");

            //QUESTION 3
            Console.WriteLine("\nENSEMBLE DES MODIFICATIONS APPORTEES AU PERSONNEL");
            monAdministration.Changer_de_fonction(66604, "employé");
            Console.WriteLine("Modification du personnel au matricule 66604 qui devient un employé");
            monAdministration.Changer_Affectation(66754, 112);
            Console.WriteLine("Modification du monstre au matricule 66634 qui est affecté à l'attraction 684");
            monAdministration.Monter_en_grade(66545);
            Console.WriteLine("Modification du sorcier au matricule 66545 qui monte en grade");
            monAdministration.Baisser_en_grade(66966);
            Console.WriteLine("Modification du sorcier au matricule 66966 qui baisse en grade");
            monAdministration.Ajouter_Pouvoir(66966,"20/20 en POOI");
            Console.WriteLine("Modification du sorcier au matricule 66966 qui obtient le pouvoir 20/20 en POOI");
            Console.WriteLine("\n");

            Console.WriteLine("\nENSEMBLE DES MODIFICATIONS APPORTEES AUX ATTRACTIONS");
            monAdministration.Mise_en_maintenance(428);
            Console.WriteLine("Modification de l'attracion à l'identifiant 428 qui est mise en maintenance");

            Console.WriteLine("\n----- AFFICHAGE DES ATTRACTIONS MODIFIEES: ----------------------------------------------------------------------------------------------------");
            monAdministration.AfficherAttraction();
            Console.WriteLine("\n");

            // QUESTION 4 
            string[] test_q4 = { "Sorcier", "Monstre", "Demon", "Fantome", "LoupGarou", "Vampire", "Zombie", "Boutique", "DarkRide", "RollerCoaster", "Spectacles" };
            for (int i=0; i<test_q4.Length;i++)
            {
                monAdministration.Recuperer_elements_de_type(test_q4[i], "C:/Users/Public/");
                Console.WriteLine("");
            }
            monAdministration.Recuperer_attractions_maintenance(false, "C:/Users/Public/");
            monAdministration.Recuperer_attractions_maintenance(true, "C:/Users/Public/");

            // QUESTION 5
            monAdministration.Tri_Force();
            Console.WriteLine("\n");
            monAdministration.Tri_cagnotte();
            Console.WriteLine("\n");

            // QUESTION 6 et 7
            Console.WriteLine("\nACTION SUR LA CAGNOTTE\n\n");
            monAdministration.Agir_sur_Cagnotte(66966, -200);
            monAdministration.Agir_sur_Cagnotte(66634, -80);
            monAdministration.Agir_sur_Cagnotte(66548, +200);

            Console.WriteLine("\n----- AFFICHAGE DES MEMBRES DU PERSONNEL MODIFIES APRES TOUTES LES MODIFICATIONS: --------------------------------------------------------------------------------");
            monAdministration.AffichePersonnel();


            Console.ReadLine();
        }
    }
}
