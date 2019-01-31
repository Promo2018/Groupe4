using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//La classe Commercial récupère la liste des logins et mots de passe des commerciaux de BoVoyages
// Elle est manipulée par LoginGestionnaire
namespace BoVoyages.Model
{
    public class Commercial:Personne
    {
        private int id;
        private string login;
        private string mdp;
        private static string file = @"..\..\Properties\Commercial.txt";

        public string Login { get => login; set => login = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public int Id { get => id; set => id = value; }

        public Commercial(string civilite, string nom, string prenom, string login, string mdp) : base(civilite, nom, prenom)
        {
            this.Login = login;
            this.Mdp = mdp;
        }

        public static string[] getCommerciaux()
        {
            // Ouvrir le fichier txt des Commerciaux
            return File.ReadAllLines(file);
        }
    }
}


