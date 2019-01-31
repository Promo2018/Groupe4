using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;
using BoVoyages.Model;

using System.IO;

namespace BoVoyages.View
{
    public class MenuDossier : Menu
    {
        private GestionDossier gestionDossier = new GestionDossier();
        public Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();
        private int dossierID;
        public string[] titreColonnes = { "Statut", "Civilite", "Prenom", "Nom", "Region", "Prix", "PrixTotal", "Etat"}; // ("Voyage ID", "Etat", "Prix Total")
        
        public MenuDossier(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 5;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Dossier   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister tous les dossiers");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher un dossier");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter un dossier");
            System.Console.WriteLine("BoVoyages :\t 4 - Supprimer un dossier");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }


        public override Menu Executer(int sel)
        {
            Menu menu = this;

            if (sel == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister tous les dossiers");
                
                gestionDossier.ListerDossiers();
            }

            
            if (sel == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher un dossier");
                //gestionDossier.ListerDossiers();

                //Console.WriteLine("Entrez un DossierID de dossier");
                //dossierID = Convert.ToInt32(Console.ReadLine());
                
                do
                {
                    Console.WriteLine("Entrez un DossierID de dossier");
                    dossierID = Convert.ToInt32(Console.ReadLine());

                    if (dossierID <= 200) // CHANGE !!!! When there will be more dossierIDs... 
                    {
                        Console.WriteLine("Access granted. Please proceed");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Access denied - there's no such dossierID yet...");                        
                    }
                } while (dossierID > 200); // CHANGE !!!! When there will be more dossierIDs... 

                
                gestionDossier.ChercherDossier(dossierID);
            }

            else if (sel == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un dossier");

                gestionDossier.AjouterDossier();
            }

            else if (sel == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer un dossier");
                int id = this.ConvertirID();

                gestionDossier.Supprimer(id);
            }
                                   
            else if (sel == 0)
            {
                menu = previousMenu;
            }

            return menu;
        }
    }
}
