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
        bool succes;

        private int id;
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
                    id = this.ConvertirSaisieEnNombre();

                    if (id <= 200) // CHANGE !!!! When there will be more dossierIDs... 
                    {
                        Console.WriteLine("Access granted. Please proceed");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Access denied - there's no such dossierID yet...");                        
                    }
                } while (id > 200); // CHANGE !!!! When there will be more dossierIDs... 

                gestionDossier.ChercherDossier(id);
            }

            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un dossier");

                gestionDossier.AjouterDossier();
            }

            else if (selection == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier l'état d'un dossier");

                Console.WriteLine("Entrez un ID de dossier :");
                id = ConvertirSaisieEnNombre();

                ListerEtatsDossier();

                Console.WriteLine("\nVeuillez saisir l'une de ces valeurs.");
                string etatString = VerifierSaisieEtatDossier(id);

                //Envoyer les données saisies et afficher la réponse renvoyée
                Console.WriteLine(gestionDossier.ModifierEtatDossier(etatString, id));
            }

            else if (selection == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer un dossier");
                Console.WriteLine("Entrez un ID de dossier :");
                int id = ConvertirSaisieEnNombre();

                gestionDossier.Supprimer(id);
            }
                                   
            else if (selection == 0)
            {
                menu = previousMenu;
            }

            return menu;
        }

        //Affiche tous les états possibles de dossier
        private void ListerEtatsDossier()
        {
            Console.WriteLine("\nLes valeurs possibles pour les états sont :");
            foreach (string colorName in Enum.GetNames(typeof(EtatDossierReservation)))
            {
                Console.WriteLine("{0} = {1:D}", colorName,
                                             Enum.Parse(typeof(EtatDossierReservation), colorName));
            }
        }

        //Vérifie si le chiffre saisie fait partie de la liste des états possibles de dossier
        private string VerifierSaisieEtatDossier(int id)
        {
            succes = false;
            string etatString = "";
            do
            {
                etatString = Console.ReadLine();
                EtatDossierReservation etatDossierReservation;
                succes = false;

                if (Enum.TryParse(etatString, out etatDossierReservation))
                {
                    if (Enum.IsDefined(typeof(EtatDossierReservation), etatDossierReservation) | etatDossierReservation.ToString().Contains(","))
                    {
                        Console.WriteLine("Le statut du dossier " + id + " va être changé en : '{0}'.", etatDossierReservation.ToString());
                        succes = true;
                    }
                    else
                    {
                        Console.WriteLine("{0} n'est pas une valeur de Réservation. Rentrez une valeur de réservation.", etatString);
                    }
                }
                else
                {
                    Console.WriteLine("{0} n'est pas une valeur de Réservation. Rentrez une valeur de réservation.", etatString);
                }
            } while (succes == false);
            return etatString;
        }
    }
}
