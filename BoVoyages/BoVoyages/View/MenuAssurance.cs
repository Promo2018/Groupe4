using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;
using BoVoyages.Model;

namespace BoVoyages.View
{   
    public class MenuAssurance : Menu
    {
        private GestionAssurance gestionDossier = new GestionAssurance();
        public Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();
        bool succes;

        private int id;
        public string[] titreColonnes = { "Statut", "Civilite", "Prenom", "Nom", "Region", "Prix", "PrixTotal", "Etat" }; // ("Voyage ID", "Etat", "Prix Total")
        
        public MenuAssurance(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 4;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Dossier   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister toutes les assurances");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher une assurance");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter une assurance");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }


        public override Menu Executer(int selection)
        {
            Menu menu = this;

            if (selection == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister toutes les assurances \n");

                gestionDossier.ListerAssurance();
            }

            
            else if (selection == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher une assurance \n");
                Console.WriteLine("Entrez un ID d'une assurance");
                id = SaisirEtVerifierID();

                gestionDossier.ChercherAssurance(id);
            }
            /*
            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un assurance");

                gestionDossier.AjouterAssurance();
            }
            */            
            else if (selection == 0)
            {
                menu = previousMenu;
            }
            
            return menu;
            
        }

        

    }

}
