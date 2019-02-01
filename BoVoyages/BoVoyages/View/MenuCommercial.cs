using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyages.View
{
    public class MenuCommercial : Menu
    {
        private MenuVoyage menuVoyage = null;
        private MenuClient menuClient = null;
        private MenuDossier menuDossier = null;
        private MenuAssurance menuAssurance = null;


        public MenuCommercial()
        {
            menuDossier = new MenuDossier(this);
            menuVoyage = new MenuVoyage(this);
            menuClient = new MenuClient(this);
            menuAssurance = new MenuAssurance(this);
            nombreOptions = 4;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Commercial   ******************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Gérer les dossiers");
            System.Console.WriteLine("BoVoyages :\t 2 - Gérer les voyages");
            System.Console.WriteLine("BoVoyages :\t 3 - Gérer les clients");
            System.Console.WriteLine("BoVoyages :\t 4 - Gérer les assurances");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }

        public override Menu Executer(int selection)
        {
            Menu menu = null;

            if(selection == 1)
            {
                menu = menuDossier; 
            }

            else if(selection == 2)
            {
                menu = menuVoyage; 
            }

            else if (selection == 3)
            {
                menu = menuClient;
            }

            else if (selection == 4)
            {
                menu = menuAssurance;
            }

            return menu;
        }
    }
}
