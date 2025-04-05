using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace POOI_PFR_Rendu_3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Administration mon_administration; // initialisation administration
        Monstre m;  // initialisation monstre a ajouter ensuite dans programme
        
        public MainWindow()
        {
            InitializeComponent();
            mon_administration = new Administration();
            mon_administration.Lecture_CSV_initialisation("Listing.csv");
            
        }

        /* Boutons du MENU : */
        private void Boutton_Ajouter_Monstre(object sender, RoutedEventArgs e)    // Bouton 1 
        {
            Saisir_employe s = new Saisir_employe();
            s.Show();
            this.Close();
        }
        private void Boutton_Ajouter_Attraction(object sender, RoutedEventArgs e) // Bouton 2 
        {
            /* Dans le meme style mais avec une autre fenetre que "Saisir_employe"
            Saisir_employe s = new Saisir_employe();
            s.Show();
            this.Close();
            */
        }
        private void Boutton_Modifier_Cagnotte(object sender, RoutedEventArgs e)  // Bouton 3 
        {
            /* Dans le meme style mais avec une autre fenetre que "Saisir_employe"
            Saisir_employe s = new Saisir_employe();
            s.Show();
            this.Close();
            */
        }
        private void Boutton_Selection_Monstre(object sender, RoutedEventArgs e)  // Bouton 4 
        {
            /* Dans le meme style mais avec une autre fenetre que "Saisir_employe"
            Saisir_employe s = new Saisir_employe();
            s.Show();
            this.Close();
            */
        }




    }
}
