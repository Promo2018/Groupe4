using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.View;
using BoVoyages.Model;
using System.Data.SqlClient;
using BoVoyages.Controller;

namespace BoVoyages
{
    class Program
    {
        static int selection = 0;
        

        static void Main(string[] args)
        {

            
            MenuLogin menuLogin = new MenuLogin();

            //Si le login fonctionne, générer le menu. Enlever le // de la ligne suivante pour tester sans login
            ShowMenu(new MenuCommercial());
            if (menuLogin.IsLoginOK()) 
            {
                ShowMenu(new MenuCommercial());
            }
            System.Console.WriteLine("BoVoyages : Au revoir.");
            System.Console.ReadKey();
        }

        static void ShowMenu(Menu menu)
        {
            menu.Afficher();
            selection = menu.Lire();
            menu = menu.Executer(selection);
            if(menu != null)
            {
                ShowMenu(menu);
            }
        }
    }
}
