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

        enum EtatDossierReservation : byte { EnAttente, EnCours, Refusee, Acceptee }
        enum RaisonAnnulationDossier : byte { client, placeInsufffisante }

        public MenuDossier(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 6;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Dossier   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister tous les dossiers");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher un dossier");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter un dossier");
            System.Console.WriteLine("BoVoyages :\t 4 - Changer l'état d'un dossier");
            System.Console.WriteLine("BoVoyages :\t 5 - Supprimer un dossier");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }


        public override Menu Executer(int selection)
        {
            Menu menu = this;

            if (selection == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister tous les dossiers");
                
                gestionDossier.ListerDossiers();
            }

            
            if (selection == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher un dossier");
                //gestionDossier.ListerDossiers();
                
                do
                {
                    Console.WriteLine("Entrez un DossierID de dossier");
                    dossierID = this.ConvertirID();

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

            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un dossier");

                gestionDossier.AjouterDossier();
            }

            else if (selection == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier l'état d'un dossier");

                Console.WriteLine("Entrez un DossierID de dossier");
                dossierID = this.ConvertirID();

                foreach (string name in Enum.GetNames(typeof(EtatDossierReservation)))
                {
                    System.Console.WriteLine(name);
                }
                Console.WriteLine("Veuillez saisir l'une des valeurs suivantes : " + EtatDossierReservation.EnAttente);

                gestionDossier.ModifierEtatDossier("nouvelleValeur",dossierID);
            }

            else if (selection == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer un dossier");
                int id = this.ConvertirID();

                gestionDossier.Supprimer(id);
            }
                                   
            else if (selection == 0)
            {
                menu = previousMenu;
            }

            return menu;
        }
    }
}
