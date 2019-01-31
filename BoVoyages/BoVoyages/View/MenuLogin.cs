using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controlleur;

namespace BoVoyages.View
{
    class MenuLogin
    {
        static int tries = 1;
        private readonly GestionLogin gestionLogin = new GestionLogin();
        private bool loginOK = true;
        private string login;
        private string mdp;

        public bool IsLoginOK()
        {
            

            System.Console.WriteLine("BoVoyages : Bienvenue.");
            System.Console.WriteLine("BoVoyages : Login:");
            login = Console.ReadLine();
            System.Console.WriteLine("BoVoyages : Mot de passe:");
            mdp = System.Console.ReadLine();

            //Vérificateur d'erreur
            if (GestionLogin.Login(login, mdp))
            {
                loginOK = true;
            }
            else
            {
                //Si moins de trois erreurs, redemander le login
                if ((tries++) < 3)
                {
                    System.Console.WriteLine("BoVoyages : Login et mot de passe invalide, merci de réessayer");
                    loginOK = IsLoginOK();
                }
                //Si au moins 3 erreurs, fermer l'application
                else
                {
                    System.Console.WriteLine("BoVoyages : Login Echoué. Sortie du logiciel.");
                    System.Console.ReadKey();
                    loginOK = false;
                }
            }
            return loginOK;
        }
    }
}
