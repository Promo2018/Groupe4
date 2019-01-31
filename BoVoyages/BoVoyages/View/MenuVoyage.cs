using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;

namespace BoVoyages.View
{
    public class MenuVoyage : Menu
    {
        private GestionVoyage gestionVoyage = new GestionVoyage();
        private readonly Menu previousMenu;
        public string[] titreColonnes = { "DestinationID", "DateAller", "DateRetour", "Nombre de Places", "Prix" };

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
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Liste de voyages disponible");
                gestionVoyage.ListVoyages();
            }

            else if (sel == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter les voyages");

                //0 = DestinationID(int); 1 = DateAller; 2 = DateRetour; 3 = NombreDePlaces(int); 4 = Prix(float);

                string[] nouveauVoyage = new string[5];
                int n = 0;

                foreach (string column in nouveauVoyage)
                {
                    Console.WriteLine(titreColonnes[n] + " :");
                    nouveauVoyage[n] = Console.ReadLine();
                    n++;
                }
                Console.WriteLine("Le voyage du " + nouveauVoyage[1] + " a été ajouté");

                gestionVoyage.AjouterVoyages(nouveauVoyage);
            }

            else if (sel == 3)
            {
                //Modifier un voyage
            }

            else if (sel == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer le voyage");

                int id = this.ConvertirSaisieEnNombre();

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
