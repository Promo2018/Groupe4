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
    public class MenuClient : Menu
    {
        private GestionClient gestionClient = new GestionClient();
        public Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();
        private int clientID ;
        protected string[] titreColonnes = { "Civilite", "Nom", "Prenom", "Adresse", "Ville", "Date De Naissance", "Telephone", "Email", "Statut", "DossierID" };

        public MenuClient(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 5;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Client   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister tous les clients");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher un client");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter un client");
            System.Console.WriteLine("BoVoyages :\t 4 - Modifier un client");
            System.Console.WriteLine("BoVoyages :\t 5 - Supprimer un client");

            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }

        public override Menu Executer(int selection)
        {
            Menu menu = this;

            if (selection == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister tous les clients\n");
                gestionClient.ListerClients();
            }

            if (selection == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher un client\n");
                Console.WriteLine("Entrez un ID de client");
                clientID = Convert.ToInt32(Console.ReadLine());
                gestionClient.ChercherClient(clientID);
            }

            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un client");

                //Affiche les colonnes. Stocke les valeurs saisies. String[] intermédiaire pour la clarté du code 
                string[] nouveauClient = SaisirNouvelleLigne(accesBDD.RecupererNomsColonnes("Clients"));

                Console.WriteLine(gestionClient.AjouterClient(nouveauClient));
            }


            else if (selection == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier un client");

                Console.WriteLine("\nVoici la liste des colonnes : \n0=Civilite \n1=Nom \n2=Prenom \n3=Adresse \n4=Ville \n5=Date De Naissance \n6=Telephone \n7=Email \n8=Statut \n9=DossierID");
                int colonneSaisie = this.ChoixColonne(10);

                Console.WriteLine("Entrez l'id du client que vous voulez modifier.");
                int id = this.SaisirEtVerifierID();

                Console.WriteLine("Veuillez saisir une nouvelle valeur à insérer dans la colonne : ");
                string nouvelleValeur = Console.ReadLine();

                //Envoyer les valeurs au constructeur et récupérer la réponse
                Console.WriteLine(gestionClient.ModifierClient(id, colonneSaisie, nouvelleValeur));
            }

            else if (selection == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer le client");
                System.Console.WriteLine("Veuillez saisir l'ID de la ligne à supprimer.");

                //Vérifier que l'ID saisi peut être converti en int, puis convertir en string
                int id = this.SaisirEtVerifierID();

                gestionClient.SupprimerClient(id);
            }

            else if (selection == 0)
            {
                menu = new MenuCommercial();
            }

            return menu;
        }
    }
}
