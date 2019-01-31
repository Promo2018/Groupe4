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

        public override Menu Executer(int sel)
        {
            Menu menu = this;

            if (sel == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister les clients");
                gestionClient.ListerClients();
            }

            if (sel == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher un client");
                Console.WriteLine("Entrez un ClientID de client");
                clientID = Convert.ToInt32(Console.ReadLine());
                gestionClient.ChercherClient(clientID);
            }

            else if (sel == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un client");

                //0 = Civilité, 1 = Nom, 2 = Prénom, 3 = Adresse, 4 = Ville, 5 = Date de naissance, 6 = Telephone, 7 = Email, 8 = Statut, 9 = DossierID

                string[] nouveauClient = new string[10]; //deleted option

                int n = 0;

                foreach (string column in nouveauClient)
                {
                    Console.WriteLine(titreColonnes[n] + " :");
                    nouveauClient[n] = Console.ReadLine();
                    n++;
                }
                Console.WriteLine("Le ou la cliente " + nouveauClient[2] + " " + nouveauClient[1] + " a été ajouté(e)");


                gestionClient.AjouterClient(nouveauClient);
            }


            else if (sel == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier le client");

                int colonneSaisie = this.ChoixColonne("Client");

                Console.WriteLine("Entrez l'id du client que vous voulez modifier.");
                int id = this.ConvertirID();

                Console.WriteLine("Veuillez saisir une nouvelle valeur à insérer dans la colonne : ");
                string nouvelleValeur = Console.ReadLine();

                gestionClient.ModifierClient(id, colonneSaisie, nouvelleValeur);
            }

            else if (sel == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer le client");
                System.Console.WriteLine("Veuillez saisir l'ID de la ligne à supprimer.");

                string[] parametres = new string[2];
                //Vérifier que l'ID saisi peut être converti en int, puis convertir en string
                parametres[1] = this.ConvertirID().ToString();

                //Passer les paramètres au constructeur
                gestionClient.ProcedureSupprimer(parametres);
            }

            else if (sel == 0)
            {
                menu = new MenuCommercial();
            }

            return menu;
        }
    }
}
