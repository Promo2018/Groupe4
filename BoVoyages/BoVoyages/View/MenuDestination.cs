using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;
using BoVoyages.Model;

namespace BoVoyages.View
{
    public class MenuDestination : Menu
    {
        private GestionDestination gestionDestination = new GestionDestination();
        public Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();
        bool succes;

        private int id;
        public string[] titreColonnes = { "Statut", "Civilite", "Prenom", "Nom", "Region", "Prix", "PrixTotal", "Etat" }; // ("Voyage ID", "Etat", "Prix Total")

        public MenuDestination(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 5;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Destination   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister toutes les destinations");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher une destination");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter une destination");
            System.Console.WriteLine("BoVoyages :\t 4 - Modifier une destination");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }


        public override Menu Executer(int selection)
        {
            Menu menu = this;

            if (selection == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister toutes les agences \n");

                gestionDestination.ListerDestination();
            }


            else if (selection == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher une agence \n");
                Console.WriteLine("Entrez un ID d'une assurance");
                id = SaisirEtVerifierID();

                gestionDestination.ChercherDestination(id);
            }
            /*
            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un assurance");

                gestionDossier.AjouterAssurance();
            }
            */

            else if (selection == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier une agence");

                Console.WriteLine("\nVoici la liste des colonnes : \n0=Region \n1=Pays \n2=Continent \n3=Description");
                int colonneSaisie = this.ChoixColonne(3);

                Console.WriteLine("Entrez l'id d'assurance que vous voulez modifier.");
                int id = this.SaisirEtVerifierID();

                Console.WriteLine("Veuillez saisir une nouvelle valeur à insérer dans la colonne : ");
                string nouvelleValeur = Console.ReadLine();

                //Envoyer les valeurs au constructeur et récupérer la réponse
                Console.WriteLine(gestionDestination.ModifierDestination(id, colonneSaisie, nouvelleValeur));
            }

            else if (selection == 0)
            {
                menu = previousMenu;
            }

            return menu;

        }



    }
}
