using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // pour utiliser le streamReader
using System.Globalization; // pour la gestion de l'heure

namespace ProjetFilRouge_2_
{
    class Administration
    {
        private List<Personnel> list;
        private List<Attraction> list_a;
        List<Personnel> list_neant;
        List<Personnel> list_parc;

        public List<Personnel> List { get => list; set => list = value; }
        public List<Attraction> List_a { get => list_a; set => list_a = value; }

        public Administration()
        {
            list = new List<Personnel>();
            list_a = new List<Attraction>();
            list_neant = new List<Personnel>();
            list_parc = new List<Personnel>();
        }

        public void AffichePersonnel()
        {
            foreach (Personnel personnel_ in list)
            {
                Console.WriteLine(personnel_);
            }
        }

        public void AfficherAttraction()
        {
            foreach (Attraction attraction_ in list_a)
            {
                Console.WriteLine(attraction_);
            }
        }

        // QUESTION n°1 --------------

        //Trouver personnel
        #region
        public Personnel TrouverPersonnel (int matricule) // Retourne le personnel correspondant au matricule en entrée. 
        {
            return list.Find(i => i.Matricule == matricule);
        }
        #endregion
        //Personel present?
        #region
        public bool Perso_est_present (int matricule)
        {
            bool sortie = false;
            foreach (Personnel p in list)
            {
                
                if (p.Matricule == matricule)
                {
                    sortie = true;
                    break;
                }
            }

            return sortie;
        } // permet de vérifier si le personnel à ajouter n'est pas déjà present dans la liste.
        #endregion
        //Attraction presente?
        #region
        public bool Attra_est_present (int identifiant)
        {
            bool sortie = false;
            foreach (Attraction at in list_a)
            {

                if (at.Identifiant == identifiant)
                {
                    sortie = true;
                    break;
                }
            }

            return sortie;
        } // permet de vérifier si l'attraction à ajouter n'est pas déjà presente dans la liste.
        #endregion
        //Ajout attraction
        #region
        public void Ajout_attraction (string[] mdl)
        {
            Boutique boutique_;
            Spectacles spectacle_;
            DarkRide darkride_;
            RollerCoaster rollercoaster_;

            if (Attra_est_present(int.Parse(mdl[1])) == false)
            {
                try
                {
                    if (mdl[0] == "Boutique")
                    {
                        Boutique.TypeBoutique type_boutique = (Boutique.TypeBoutique)Enum.Parse(typeof(Boutique.TypeBoutique), mdl[6]);
                        bool besoin_spe = Convert.ToBoolean(mdl[4]);
                        boutique_ = new Boutique(int.Parse(mdl[1]), mdl[2], int.Parse(mdl[3]), besoin_spe, mdl[5], type_boutique);
                        list_a.Add(boutique_);
                    }

                    if (mdl[0] == "Spectacle")
                    {
                        List<DateTime> horaire = new List<DateTime>();
                        DateTime horaire_;
                        if (mdl[8] != "")
                        {
                            string s = mdl[8];
                            string[] words = s.Split(' ');

                            foreach (string word in words)
                            {
                                string pattern = "HH:mm";
                                if (DateTime.TryParseExact(word, pattern, null, DateTimeStyles.None, out horaire_))
                                {
                                    horaire.Add(horaire_);
                                }
                            }
                        }
                        else { horaire = null; }
                        bool besoin_spe = Convert.ToBoolean(mdl[4]);
                        spectacle_ = new Spectacles(int.Parse(mdl[1]), mdl[2], int.Parse(mdl[3]), besoin_spe, mdl[5], horaire, int.Parse(mdl[7]), mdl[6]);
                        list_a.Add(spectacle_);
                    }

                    if (mdl[0] == "DarkRide")
                    {
                        TimeSpan duree_ = new TimeSpan(0, int.Parse(mdl[6]), 0);
                        bool besoin_spe = Convert.ToBoolean(mdl[4]);
                        bool vehicule = Convert.ToBoolean(mdl[7]);
                        darkride_ = new DarkRide(int.Parse(mdl[1]), mdl[2], int.Parse(mdl[3]), besoin_spe, mdl[5], duree_, vehicule);
                        list_a.Add(darkride_);
                    }

                    if (mdl[0] == "RollerCoaster")
                    {
                        bool besoin_spe = Convert.ToBoolean(mdl[4]);
                        RollerCoaster.TypeCategorie categorie = (RollerCoaster.TypeCategorie)Enum.Parse(typeof(RollerCoaster.TypeCategorie), mdl[6]);
                        rollercoaster_ = new RollerCoaster(int.Parse(mdl[1]), mdl[2], int.Parse(mdl[3]), besoin_spe, mdl[5], categorie, int.Parse(mdl[7]), float.Parse(mdl[8]));
                        list_a.Add(rollercoaster_);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Type of attraction not available");
                }
            }
        }
        #endregion
        //Trouver Attraction
        #region
        public Attraction TrouverAttraction (int identifiant_)
        {
            return list_a.Find(i => i.Identifiant == identifiant_);
        }
        #endregion
        //Csv affectation attraction
        #region
        public void CSV_Affectation_Attraction (string info, Monstre monstre)
        {
            if (info != "")
            {
                if (info == "neant")
                {
                    monstre.Affectation = null;
                    list_neant.Add(monstre);
                }
                if (info == "parc")
                {
                    monstre.Affectation = null;
                    list_parc.Add(monstre);
                }
                else
                {
                    int identifiant_ = 0;
                    int.TryParse(info, out identifiant_);
                    Attraction son_affectation = TrouverAttraction(identifiant_);
                    monstre.Ajouter_Affectation(son_affectation);
                }
            }
            else
            {
                monstre.Affectation = null; 
            }
        }
        #endregion
        //Ajout personnel
        #region
        public void Ajout_personnel (string[] mdl)
        {
            Sorcier sorcier_;
            Monstre monstre_;
            Vampire vampire_;
            Demon demon_;
            Fantome fantome_;
            Zombie zombie_;
            LoupGarou loupgarou_;

            if ( Perso_est_present( int.Parse(mdl[1])) == false)
            {
                if (mdl[0] == "Sorcier")
                {
                    List<String> pouvoirs = new List<String>();
                    if (mdl[7] != "")
                    {
                        string s = mdl[7];
                        string[] words = s.Split('-');
                        foreach (string word in words)
                        {
                            pouvoirs.Add(word);
                        }
                    }
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    Sorcier.Grade grade_ = (Sorcier.Grade)Enum.Parse(typeof(Sorcier.Grade), mdl[6]);
                    sorcier_ = new Sorcier(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, pouvoirs, grade_);
                    list.Add(sorcier_);
                }

                if (mdl[0] == "Monstre")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    monstre_ = new Monstre(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[6]));
                    CSV_Affectation_Attraction(mdl[7], monstre_);
                    list.Add(monstre_);
                }

                if (mdl[0] == "Vampire")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    vampire_ = new Vampire(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[6]), double.Parse(mdl[8]));
                    CSV_Affectation_Attraction(mdl[7], vampire_);
                    list.Add(vampire_);
                }

                if (mdl[0] == "Demon")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    demon_ = new Demon(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[6]), int.Parse(mdl[8]));
                    CSV_Affectation_Attraction(mdl[7], demon_);
                    list.Add(demon_);
                }

                if (mdl[0] == "Fantome")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    fantome_ = new Fantome(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[6]));
                    CSV_Affectation_Attraction(mdl[7], fantome_);
                    list.Add(fantome_);
                }

                if (mdl[0] == "Zombie")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    Zombie.CouleurZ couleur_ = (Zombie.CouleurZ)Enum.Parse(typeof(Zombie.CouleurZ), mdl[8]);
                    zombie_ = new Zombie(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[9]), couleur_, int.Parse(mdl[6]));
                    CSV_Affectation_Attraction(mdl[7], zombie_);
                    list.Add(zombie_);
                }

                if (mdl[0] == "LoupGarou")
                {
                    Personnel.TypeSexe sexe_ = (Personnel.TypeSexe)Enum.Parse(typeof(Personnel.TypeSexe), mdl[4]);
                    loupgarou_ = new LoupGarou(mdl[5], int.Parse(mdl[1]), mdl[2], mdl[3], sexe_, int.Parse(mdl[6]), double.Parse(mdl[8]));
                    CSV_Affectation_Attraction(mdl[7], loupgarou_);
                    list.Add(loupgarou_);
                }
            }
            
        }
        #endregion
        //Lecture CSV
        #region
        public void Lecture_CSV_initialisation(string pathfile)
        { 
            // PREMIERE LECTURE DU FICHIER CSV --> AJOUT ATTRACTIONS
            StreamReader monStreamReader = new StreamReader(pathfile);
            string ligne = " ";
            string[] mdl;  // pour "mot de ligne"
            while (ligne != null)
            {
                ligne = monStreamReader.ReadLine();
                if (ligne != null)
                {
                    mdl = ligne.Split(';');
                    Ajout_attraction(mdl);
                }
            }
            Console.WriteLine("-> Attractions du CSV chargées.");
            monStreamReader.Close();

            // DEUXIEME LECTURE DU FICHIER CSV --> AJOUT PERSONNEL
            StreamReader monStreamReader2 = new StreamReader(pathfile);
            ligne = " ";
            string[] mdl2;  // pour "mot de ligne"
            while (ligne != null)
            {
                ligne = monStreamReader2.ReadLine();
                if (ligne != null)
                {
                    mdl2 = ligne.Split(';');
                    Ajout_personnel(mdl2);
                }
            }
            Console.WriteLine("-> Personnel du CSV chargé.");
            monStreamReader2.Close();
            RemplirEquipes();
        }
        #endregion

        /* QUESTION n°2 ----------------
        // L'implementation se faisant sans l'intervention humaine au sein de la console, on considere qu'un 
        // element string "ligne" (pouvant etre créé a la suite de plusieurs Console.Read) ce qui permet de réutiliser 
        // simplement les méthodes precedentes : Ajout_personnel et Ajout attraction.*/

        //QUESTION n°3 --------------------

        //Méthodes Utiles
        #region
        public void RemplirEquipes()
        {
            foreach(Attraction a in list_a)
            {
                    foreach (Personnel p in list)
                    {
                    if (p is Monstre)
                    {
                        Monstre m = (Monstre)p;
                        if ((m.Affectation != null) &&(m.Affectation.Identifiant == a.Identifiant))
                        {
                            a.Equipe.Add(m);
                        }
                    }
                }
            }
        }
        #endregion
        #region
        public void RetirerMonstreAttraction(Monstre monstre)
        {
            foreach(Attraction a in list_a)
            {
                if(monstre.Affectation != null)
                {
                    if (monstre.Affectation.Equals(a))
                    {
                        List<Monstre> temp = new List<Monstre>();
                        temp = a.Equipe;
                        foreach (Monstre m in temp)
                        {
                            if (m.Equals(monstre))
                            {
                                a.Equipe.Remove(m);
                                break;
                            }
                        }
                        //a.Equipe.Remove(a.Equipe.Find(x => x.Matricule == monstre.Matricule)); ne marche pas
                    }
                }
            }
        }

        public void AjouterMonstreAttraction(Monstre monstre, Attraction attraction)
        {
            attraction.Equipe.Add(monstre);
        }

        public Boutique BarbeaPapa()
        {
            foreach (Attraction d in list_a)
            {
                if (d is Boutique)
                {
                    Boutique l = (Boutique)d;
                    if (l.Type == Boutique.TypeBoutique.barbeAPapa)
                    {
                        return l;
                    }
                }
            }
            return null;
        }
        #endregion
        // Méthodes Personnel
        #region
        public void Changer_de_fonction(int matricule, string fonction)
        {
            Personnel monstre = TrouverPersonnel(matricule);
            monstre.Fonction = fonction;
            // Utiliser une méthode de la classe Personnel changeant la fonction ou une propriété avec set 
        }
        #endregion
        // Méthodes Sorcier
        #region
        public void Monter_en_grade(int matricule)
        {
            Sorcier sorcier = (Sorcier)TrouverPersonnel(matricule);
            int grade_actuel = (int)sorcier.Tatouage; // valeur actuelle de grade
            if (grade_actuel < 3)
            {
                sorcier.Tatouage = (Sorcier.Grade)grade_actuel + 1; //rang inferieur}
            }
        }
        public void Baisser_en_grade(int matricule)
        {
            Sorcier sorcier = (Sorcier)TrouverPersonnel(matricule);
            int grade_actuel = (int)sorcier.Tatouage; // valeur actuelle de grade
            if (grade_actuel > 0)
            {
                sorcier.Tatouage = (Sorcier.Grade)grade_actuel - 1; //rang inferieur}
            }
            else
            {
                Console.WriteLine("Le grade ne peut pas être diminué");
            }
        }
        public void Ajouter_Pouvoir(int matricule, string pouvoir)
        {
            Sorcier sorcier = (Sorcier)TrouverPersonnel(matricule);
            sorcier.Pouvoirs.Add(pouvoir);
        }
        #endregion
        // Méthodes Monstre 
        #region
        public void Changer_Affectation(int matricule, int identifiant)
        {
            if(Est_neant(matricule) == false || Est_parc(matricule) == false)
            {
                Monstre monstre = (Monstre)TrouverPersonnel(matricule);
                Attraction attraction = TrouverAttraction(identifiant);
                try
                {
                    RetirerMonstreAttraction(monstre);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("affectation nulle");
                }
                attraction.Equipe.Add(monstre);
                monstre.Ajouter_Affectation(attraction);
            }
            else
            {
                Console.WriteLine("Ne peut etre affecté");
            }
        }
        #endregion
        // Méthodes Attractions
        #region
        public void Mise_en_maintenance(int identifiant)
        {
            Attraction attraction = TrouverAttraction(identifiant); // Chercher l'attrac ayant l'id
            if(attraction.Maintenance == false)
            {
                attraction.Maintenance = true;// Utiliser une méthode de la classe Attraction pour mettre en maintenance
                attraction.Ouvert = false;
                attraction.NatureMaintenance = "crise cardiaque visiteur";
            }
            else
            {
                Console.WriteLine("Attraction deja en maintenance");
            }
        }
        public void Arreter_la_maintenance(int identifiant)
        {
            Attraction attraction = TrouverAttraction(identifiant); // Chercher l'attrac ayant l'id
            if(attraction.Maintenance == false)
            {
                attraction.Maintenance = false;// Utiliser une méthode de la classe Attraction pour mettre en maintenance
                attraction.Ouvert = true;
            }
            else
            {
                Console.WriteLine("Attraction deja en marche");
            }
        }
        #endregion

        // QUESTION n°4 -----------------

        //Est parc & est neant
        #region
        public bool Est_neant (int matricule_) // true si personnel dans cette liste 
        {
            /*bool sortie = false;
            foreach (Personnel p in list_neant)
            {
                if (p.Matricule == matricule_)
                {
                    sortie = true;
                }
            }
            return sortie;*/
            return list_neant.Contains(TrouverPersonnel(matricule_));
        } 

        public bool Est_parc(int matricule_) // true si personnel dans cette liste  
        {
            /*bool sortie = false;
            foreach (Personnel p in list_parc)
            {
                if (p.Matricule == matricule_)
                {
                    sortie = true;
                }
            }
            return sortie;*/
            return list_parc.Contains(TrouverPersonnel(matricule_));
        }
        #endregion
        //Affichage affectation pour affectation neant ou parc
        #region
        public void Ecrire_Afficher_affectation(StreamWriter mon_streamwriter,Monstre i) // Affiche l'affectation des monstres en fonction de leur presence dans list_neant ou list_parc.
        {
            if (i.Affectation != null)
            {
                mon_streamwriter.Write(i.Affectation.Identifiant);
                Console.Write(i.Affectation.Identifiant + " " );
            }
            else
            {
                if (Est_neant(i.Matricule))
                {
                    mon_streamwriter.Write("neant");
                    Console.Write(" neant ");
                }
                if (Est_parc(i.Matricule))
                {
                    mon_streamwriter.Write("parc");
                    Console.Write(" parc ");
                }
                if (Est_neant(i.Matricule)==false && Est_parc(i.Matricule)==false)
                {
                    mon_streamwriter.Write("");
                    Console.Write(" pas d'attraction ");
                }
            }
        }
        #endregion
        //Récupération elements d'un type pour affciher
        #region
        public void Recuperer_elements_de_type (string type,string pathfile) // Affiche et créé un fichier CSV dans pathfile de tous les elements du type en entré. 
        {
            Console.WriteLine("RECUPERATION DES ELEMENTS DE TYPE : " + type);
            FileInfo fichier = new FileInfo(pathfile + type + ".csv");
            if (fichier.Exists)
            {
                fichier.Delete();
                fichier = new FileInfo(pathfile + type + ".csv");
            }
            StreamWriter mon_streamwriter = new StreamWriter(pathfile + type + ".csv", true, System.Text.Encoding.ASCII);

            if (type == "Sorcier")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;TATOUAGE;POUVOIRS");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; TATOUAGE ; POUVOIRS");
                foreach (Personnel p in list )
                {
                    if (p is Sorcier)
                    {
                        Sorcier i = (Sorcier)p;

                        mon_streamwriter.Write("Sorcier;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.Tatouage + ";");
                        Console.Write("Sorcier ;" + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.Tatouage + " ; "); 
                        foreach (string pouvoirs_ in i.Pouvoirs)
                        {
                            mon_streamwriter.Write(pouvoirs_ + "-");
                            Console.Write(pouvoirs_ + "-");
                        }
                        mon_streamwriter.WriteLine("");
                        Console.WriteLine("");
                    }
                    
                }
            }
       
            if (type == "Monstre")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION");
                foreach (Personnel p in list)
                {
                    if (p is Monstre )
                    {
                        Monstre i = (Monstre)p;
                        mon_streamwriter.Write("Monstre;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("Monstre ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine("");
                        Console.WriteLine("");
                    }
                }
            }
   
            if (type == "Demon")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION;FORCE");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION ; FORCE");
                foreach (Personnel p in list)
                {
                    if (p is Demon)
                    {
                        Demon i = (Demon)p;
                        mon_streamwriter.Write("Demon;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("Demon ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine(";" + i.Force);
                        Console.WriteLine("; " + i.Force );
                    }
                }
            }

            if (type == "Fantome")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION");
                foreach (Personnel p in list)
                {
                    if (p is Fantome)
                    {
                        Fantome i = (Fantome)p;
                        mon_streamwriter.Write("Fantome;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("Fantome ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine("");
                        Console.WriteLine("");
                    }
                }
            }

            if (type == "LoupGarou")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION;INDICE CRUAUTE");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION ; INDICE CRUAUTE");
                foreach (Personnel p in list)
                {
                    if (p is LoupGarou)
                    {
                        LoupGarou i = (LoupGarou)p;
                        mon_streamwriter.Write("LoupGarou;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("LoupGarou ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine(";"+i.IndiceCruaute);
                        Console.WriteLine("; "+i.IndiceCruaute);
                    }
                }
            }

            if (type == "Vampire")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION;INDICE LUMINOSITE");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION ; INDICE LUMINOSITE");
                foreach (Personnel p in list)
                {
                    if (p is Vampire)
                    {
                        Vampire i = (Vampire)p;
                        mon_streamwriter.Write("Vampire;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("Vampire ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine(";" + i.IndiceLuminosite);
                        Console.WriteLine("; " + i.IndiceLuminosite);
                    }
                }
            }

            if (type == "Zombie")
            {
                mon_streamwriter.WriteLine("TYPE;MATRICULE;NOM;PRENOM;SEXE;FONCTION;CAGNOTTE;AFFECTATION;COULEUR;DEGRE DECOMPOSITION");
                Console.WriteLine("TYPE ; MATRICULE ; NOM ; PRENOM ; SEXE ; FONCTION ; CAGNOTTE ; AFFECTATION ; COULEUR ; DEGRE DECOMPOSITION");
                foreach (Personnel p in list)
                {
                    if (p is Zombie)
                    {
                        Zombie i = (Zombie)p;
                        mon_streamwriter.Write("Zombie;" + i.Matricule + ";" + i.Nom + ";" + i.Prenom + ";" + i.Sexe + ";" + i.Fonction + ";" + i.cagnotte + ";");
                        Console.Write("Zombie ; " + i.Matricule + " ; " + i.Nom + " ; " + i.Prenom + " ; " + i.Sexe + " ; " + i.Fonction + " ; " + i.cagnotte + " ; ");
                        Ecrire_Afficher_affectation(mon_streamwriter, i);
                        mon_streamwriter.WriteLine(";" + i.Teint + ";" + i.DegreDecomposition);
                        Console.WriteLine("; " + i.Teint + " ; " + i.DegreDecomposition);
                    }
                }
            }

            if (type == "Boutique")
            {
                mon_streamwriter.WriteLine("TYPE;IDENTIFIANT;NOM;NB MIN MONSTRE;BESOIN SPECIFIQUE;TYPE BESOIN");
                Console.WriteLine("TYPE ; IDENTIFIANT ; NOM ; NB MIN MONSTRE ; BESOIN SPECIFIQUE ; TYPE BESOIN");
                foreach (Attraction at in list_a)
                {
                    if (at is Boutique)
                    {
                        Boutique i = (Boutique)at;
                        mon_streamwriter.WriteLine("Boutique;" + i.Identifiant +";"+ i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin);
                        Console.WriteLine("Boutique ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin);
                    }
                }
            }

            if (type == "DarkRide")
            {
                mon_streamwriter.WriteLine("TYPE;IDENTIFIANT;NOM;NB MIN MONSTRE;BESOIN SPECIFIQUE;TYPE BESOIN;DUREE;VEHICULE");
                Console.WriteLine("TYPE ; IDENTIFIANT ; NOM ; NB MIN MONSTRE ; BESOIN SPECIFIQUE ; TYPE BESOIN ; DUREE ; VEHICULE");
                foreach (Attraction at in list_a)
                {
                    if (at is DarkRide)
                    {
                        DarkRide i = (DarkRide)at;
                        mon_streamwriter.WriteLine("DarkRide;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Duree + ";" + i.Vehicule);
                        Console.WriteLine("DarkRide ; " + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Duree + " ; " + i.Vehicule);
                    }
                }
            }

            if (type == "RollerCoaster")
            {
                mon_streamwriter.WriteLine("TYPE;IDENTIFIANT;NOM;NB MIN MONSTRE;BESOIN SPECIFIQUE;TYPE BESOIN;CATEGORIE;AGEMIN;TAILLEMIN");
                Console.WriteLine("TYPE ; IDENTIFIANT ; NOM ; NB MIN MONSTRE ; BESOIN SPECIFIQUE ; TYPE BESOIN ; AGEMIN ; TAILLEMIN");
                foreach (Attraction at in list_a)
                {
                    if (at is RollerCoaster)
                    {
                        RollerCoaster i = (RollerCoaster)at;
                        mon_streamwriter.WriteLine("RollerCoaster;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Categorie + ";" + i.AgeMinimum + ";" + i.TailleMinimum);
                        Console.WriteLine("RollerCoaster ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Categorie + " ; " + i.AgeMinimum + " ; " + i.TailleMinimum);
                    }
                }
            }

            if (type == "Spectacles")
            {
                mon_streamwriter.WriteLine("TYPE;IDENTIFIANT;NOM;NB MIN MONSTRE;BESOIN SPECIFIQUE;TYPE BESOIN;NOMSALLE;NBRPLACE;HORAIRES");
                Console.WriteLine("TYPE ; IDENTIFIANT ; NOM ; NB MIN MONSTRE ; BESOIN SPECIFIQUE ; TYPE BESOIN ; NOMSALLE ; NBRPLACE ; HORAIRES");
                foreach (Attraction at in list_a)
                {
                    if (at is Spectacles)
                    {
                        Spectacles i = (Spectacles)at;
                        mon_streamwriter.Write("Spectacles;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.NomSalle + ";" + i.NombrePlace + ";"); ;
                        Console.Write("Spectacles ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + ";" + i.TypeDeBesoin + " ; " + i.NomSalle + " ; " + i.NombrePlace + " ; "); ;
                        foreach (DateTime dt in i.Horaire)
                        {
                            mon_streamwriter.Write(dt + " ");
                            Console.Write(dt + " ");
                        }
                        mon_streamwriter.WriteLine("");
                        Console.WriteLine("");
                    }
                }
            }

            mon_streamwriter.Close();
            Console.WriteLine("VOUS TROUVEREZ LE FICHIER  " + type + ".csv  DANS LE REPERTOIRE : " + pathfile + type + ".csv \n");
        }
#endregion
        //Récupération attractions en maintenance
        #region
        public void Recuperer_attractions_maintenance(bool maintenance,string pathfile) // Affiche et créé un fichier CSV dans pathfile de toutes les attractions ayant la meme maintenance en entrée. 
        {
            if (maintenance == true) { Console.WriteLine("RECUPERATION DES ATTRACTION EN MAINTENANCE"); }
            else { Console.WriteLine("RECUPERATION DES ATTRACTION QUI NE SONT PAS EN MAINTENANCE"); }

            FileInfo fichier = new FileInfo(pathfile + "Attractions_maintenance_" + Convert.ToString(maintenance) + ".csv");
            if (fichier.Exists)
            {
                fichier.Delete();
                fichier = new FileInfo(pathfile + "Attractions_maintenance_" + Convert.ToString(maintenance) + ".csv");
            } // si le fichier existe deja on le supprime
            StreamWriter mon_streamwriter = new StreamWriter(pathfile + "Attractions_maintenance_" + Convert.ToString(maintenance) + ".csv", true, System.Text.Encoding.ASCII);
            foreach (Attraction at in list_a)
            {
                if (at.Maintenance == maintenance)
                {
                    if (at is Boutique)
                    {
                        Boutique i = (Boutique)at;
                        
                            mon_streamwriter.WriteLine("Boutique;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin);
                            Console.WriteLine("Boutique ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin);
                        
                    }
                    if (at is DarkRide)
                    {
                        DarkRide i = (DarkRide)at;
                        mon_streamwriter.WriteLine("DarkRide;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Duree + ";" + i.Vehicule);
                        Console.WriteLine("DarkRide ; " + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Duree + " ; " + i.Vehicule);
                        
                    }
                    if (at is RollerCoaster)
                    {
                        RollerCoaster i = (RollerCoaster)at;
                        mon_streamwriter.WriteLine("RollerCoaster;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Categorie + ";" + i.AgeMinimum + ";" + i.TailleMinimum);
                        Console.WriteLine("RollerCoaster ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Categorie + " ; " + i.AgeMinimum + " ; " + i.TailleMinimum);  
                    }
                    if (at is Spectacles)
                    {
                        Spectacles i = (Spectacles)at;
                        mon_streamwriter.Write("Spectacles;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.NomSalle + ";" + i.NombrePlace + ";"); ;
                        Console.Write("Spectacles ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + ";" + i.TypeDeBesoin + " ; " + i.NomSalle + " ; " + i.NombrePlace + " ; "); ;
                        foreach (DateTime dt in i.Horaire)
                        {
                            mon_streamwriter.Write(dt + " ");
                            Console.Write(dt + " ");
                        }
                            mon_streamwriter.WriteLine("");
                            Console.WriteLine("");
                        
                    }
                }
            }
            mon_streamwriter.Close();
            Console.WriteLine("VOUS TROUVEREZ LE FICHIER  " + "Attractions_maintenance_" + Convert.ToString(maintenance) + ".csv" + "  DANS LE REPERTOIRE : " + pathfile + "Attractions_maintenance_" + Convert.ToString(maintenance) + ".csv\n");
        }
        #endregion
        //Récupération attractions ouvertes
        #region
        public void Recuperer_attractions_ouvertes(bool ouverte, string pathfile) // SIMILAIRE PRESCEDENTE : Affiche et créé un fichier CSV dans pathfile de toutes les attractions ouvertes/fermees en entree.
        {
            FileInfo fichier = new FileInfo(pathfile + "Attractions_maintenance_" + Convert.ToString(ouverte) + ".csv");
            if (fichier.Exists)
            {
                fichier.Delete();
                fichier = new FileInfo(pathfile + "Attractions_maintenance_" + Convert.ToString(ouverte) + ".csv");
            } // si le fichier existe deja on le supprime
            StreamWriter mon_streamwriter = new StreamWriter(pathfile + "Attractions_maintenance_" + Convert.ToString(ouverte) + ".csv", true, System.Text.Encoding.ASCII);
            foreach (Attraction at in list_a)
            {
                if (at.Maintenance == ouverte)
                {
                    if (at is Boutique)
                    {
                        Boutique i = (Boutique)at;
                        
                            mon_streamwriter.WriteLine("Boutique;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin);
                            Console.WriteLine("Boutique ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin);
                        
                    }
                    if (at is DarkRide)
                    {
                        DarkRide i = (DarkRide)at;
                        
                            mon_streamwriter.WriteLine("DarkRide;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Duree + ";" + i.Vehicule);
                            Console.WriteLine("DarkRide ; " + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Duree + " ; " + i.Vehicule);
                        
                    }
                    if (at is RollerCoaster)
                    {
                        RollerCoaster i = (RollerCoaster)at;
                        
                            mon_streamwriter.WriteLine("RollerCoaster;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.Categorie + ";" + i.AgeMinimum + ";" + i.TailleMinimum);
                            Console.WriteLine("RollerCoaster ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + " ; " + i.TypeDeBesoin + " ; " + i.Categorie + " ; " + i.AgeMinimum + " ; " + i.TailleMinimum);
                        
                    }
                    if (at is Spectacles)
                    {
                        Spectacles i = (Spectacles)at;
                        
                            mon_streamwriter.Write("Spectacles;" + i.Identifiant + ";" + i.Nom + ";" + i.NbMinMonstre + ";" + i.BesoinSpecifique + ";" + i.TypeDeBesoin + ";" + i.NomSalle + ";" + i.NombrePlace + ";"); ;
                            Console.Write("Spectacles ;" + i.Identifiant + " ; " + i.Nom + " ; " + i.NbMinMonstre + " ; " + i.BesoinSpecifique + ";" + i.TypeDeBesoin + " ; " + i.NomSalle + " ; " + i.NombrePlace + " ; "); ;
                            foreach (DateTime dt in i.Horaire)
                            {
                                mon_streamwriter.Write(dt + " ");
                                Console.Write(dt + " ");
                            }
                            mon_streamwriter.WriteLine("");
                            Console.WriteLine("");
                        
                    }
                }
            }
            mon_streamwriter.Close();

        }
        #endregion

        //QUESTION n°5 ----------------

        //Tri selon paramètre donné (zombie = cagnotte, démon = force)
        #region
        public void Tri_cagnotte()
        {
            // Extraire la sous liste d'un certain type de monstres à trier
            List<Zombie> zombies = new List<Zombie>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Zombie)
                {
                    zombies.Add((Zombie)list[i]);
                }
            }
            List<Zombie> zombies_ordre = zombies.OrderBy(d => d.cagnotte).ToList();
            Console.WriteLine("\n----- AFFICHAGE DES ZOMBIES TRIES SELON LA CAGNOTTE: ----------------------------------------------------------------------------------------------------");
            foreach (Zombie z in zombies_ordre)
            {
                Console.WriteLine(z);
            }
            // Ecrire dans un csv ou l'afficher
        }
        public void Tri_Force()
        {
            List<Demon> demons = new List<Demon>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Demon)
                {
                    demons.Add((Demon)list[i]);
                }
            }
            List<Demon> demons_ordre = demons.OrderBy(d => d.Force).ToList();
            Console.WriteLine("\n----- AFFICHAGE DES DEMONS TRIES SELON LA FORCE: ----------------------------------------------------------------------------------------------------");
            foreach(Demon d in demons_ordre)
            {
                Console.WriteLine(d);
            }
        }

        #endregion

        // QUESTION n°6 -----------------

        //Agir sur la cagnotte
        #region
        public void Agir_sur_Cagnotte(int matricule, int valeur_modification)
        {
            Personnel p = TrouverPersonnel(matricule);
            Console.WriteLine("MODIFICATION CAGNOTTE de " + p.Nom + " " + p.Prenom + " : " + valeur_modification);
            if ((p is Monstre)&& (p != null))
            {
                Monstre m = (Monstre)p;         
                Console.WriteLine("Ancienne Cagnotte de " + m.Nom + " " + m.Prenom + " : " + m.cagnotte);
                if (valeur_modification<0)
                {
                    if (Math.Abs(valeur_modification) < m.cagnotte)
                    {
                        Gerer_Cagnotte(m, valeur_modification);
                        //p.cagnotte = p.cagnotte + valeur_modification; // Modification possible.
                    }
                    else
                    {
                        throw new ExceptionCagnotteHorsLimite(m.cagnotte + valeur_modification, 0);
                        m.cagnotte = 0 ; // par défaut si on décremente trop la cagnotte on la met directement à zéro.
                    }
                }
                else
                {
                    Gerer_Cagnotte(m, valeur_modification);
                    //m.cagnotte = m.cagnotte + valeur_modification;
                }
                Console.WriteLine("Nouvelle Cagnotte de " + m.Nom + " " + m.Prenom + " : " + m.cagnotte+"\n");
            }
            else
            {
                Console.WriteLine("Modification de cagnotte impossible. Personnel non monstre ou non existant.\n");
            }
        }
        #endregion

        // QUESTION n°7 ------------
        //Gerer cagnotte
        #region
        public void Gerer_Cagnotte(Monstre monstre, int modif)
        {
            if((monstre.cagnotte > 50) || (monstre.cagnotte < 500))
            {
                monstre.cagnotte += modif;
                if (monstre.cagnotte < 50)
                {
                    RetirerMonstreAttraction(monstre);
                    monstre.Affectation.Identifiant = BarbeaPapa().Identifiant; //type bap
                    AjouterMonstreAttraction(monstre, BarbeaPapa());
                }
                else if (monstre.cagnotte > 500)
                {
                    RetirerMonstreAttraction(monstre);
                    monstre.Ajouter_Affectation(null);
                }
            }
            // Chercher le monstre avec ce mat puis enrengistrer son ancienne cagnotte
            // Modifier sa cagnotte
            // Regarder s'il y a eu le passage d'un palier 
            // Faire des conditions if gérant les cas
        }
        #endregion
    }
}
