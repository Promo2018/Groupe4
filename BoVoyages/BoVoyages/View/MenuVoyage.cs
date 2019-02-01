using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;
using BoVoyages.Model;

namespace BoVoyages.View
{
    public class MenuVoyage : Menu
    {
        private GestionVoyage gestionVoyage = new GestionVoyage();
        private readonly Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();

        public MenuVoyage(Menu previousMenu)
        {
            nombreOptions = 5;
            this.previousMenu = previousMenu;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Voyage   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Liste de voyages disponibles");
            System.Console.WriteLine("BoVoyages :\t 2 - Ajouter les voyages");
            System.Console.WriteLine("BoVoyages :\t 3 - Modifier un voyage");
            System.Console.WriteLine("BoVoyages :\t 4 - Supprimer le voyage");
            System.Console.WriteLine("BoVoyages :\t 5 - Supprimer les voyages expirés");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }

        public override Menu Executer(int sel)
        {
            Menu menu = this;

            if (sel == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Liste de tous les voyages\n");
                gestionVoyage.ListerVoyages();
            }

            else if (sel == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter les voyages");

                string[] nouveauClient = SaisirNouvelleLigne(accesBDD.RecupererNomsColonnes("Voyages"));

                Console.WriteLine(gestionVoyage.AjouterVoyage(nouveauClient));
            }

            else if (sel == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier un voyage");

                Console.WriteLine("\nVoici la liste des colonnes : \n0=Destination ID \n1=Date Aller \n2=Date Retour \n3=Nombre de Places \n4=Prix \n5=Agence ID");
                int colonneSaisie = this.ChoixColonne(6);

                Console.WriteLine("Entrez l'id du voyage que vous voulez modifier.");
                int id = this.SaisirEtVerifierID();

                Console.WriteLine("Veuillez saisir une nouvelle valeur à insérer dans la colonne : ");
                string nouvelleValeur = Console.ReadLine();

                //Envoyer les valeurs au constructeur et récupérer la réponse
                Console.WriteLine(gestionVoyage.ModifierVoyage(id, colonneSaisie, nouvelleValeur));

            }

            else if (sel == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer le voyage");

                int id = this.SaisirEtVerifierID();

                gestionVoyage.Supprimer(id);
            }


            else if (sel == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer les voyages expirés");
                gestionVoyage.SupprimerVoyagesExpires();
            }

            else if (sel == 0)
            {
                menu = previousMenu;
            }

            return menu;
        }

    }
}
