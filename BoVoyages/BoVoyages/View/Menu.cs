using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BoVoyages.View
{
    public abstract class Menu
    {
        protected int nombreOptions = 0;
        private int selection = 0;

        public abstract void Afficher();
        public abstract Menu Executer(int sel);

        //Retourne vrai si l'option choisie est inférieur au nombre d'options disponibles
        private bool ValiderSelection()
        {
            return (selection <= nombreOptions);
        }

        //Vérifie qu'un nombre est entré, et qu'il est inférieur au nombre d'options disponibles
        public int Lire()
        {
            try
            {
                selection = Int32.Parse(System.Console.ReadLine());
                if (!ValiderSelection())
                {
                    System.Console.WriteLine("BoVoyages: Veuillez entrer un nombre entre 0 et " + nombreOptions);
                    Lire();
                }
            }
            catch
            {
                System.Console.WriteLine("BoVoyages: Veuillez entrer un nombre entre 0 et " + nombreOptions);
                selection = Lire();
            }
            return selection;
        }

        //Vérifie qu'un nombre est entré, et qu'il est inférieur au nombre d'options saisies
        public int Lire(int nombreChoix)
        {
            try
            {
                selection = Int32.Parse(System.Console.ReadLine());
                if (!ValiderSelection())
                {
                    System.Console.WriteLine("BoVoyages: Veuillez entrer un nombre entre 0 et " + nombreChoix);
                    Lire();
                }
            }
            catch
            {
                System.Console.WriteLine("BoVoyages: Veuillez entrer un nombre entre 0 et " + nombreChoix);
                selection = Lire();
            }
            return selection;
        }

        //Méthode qui affiche toute une table de données en fonction du menu qui l'appelle
        public static void ImpressionTable(DataSet dataset)
        {
            if (dataset.Tables["Resultat"].Rows.Count > 0)
            {
                string impression = "";
                foreach (DataRow ligne in dataset.Tables["Resultat"].Rows)
                {

                    for (int i = 0; i < ligne.ItemArray.Length; i++)
                    {
                        impression = String.Concat(impression, ligne[i].ToString(), ", ");

                    }

                    impression = String.Concat(impression, "\n");
                }
                Console.WriteLine(impression);
            }
            else
            {
                Console.WriteLine("Aucune ligne à afficher.");
            }
        }

        //Methode qui convertit l'ID en int
        public int ConvertirSaisieEnNombre()
        {
            bool succes = Int32.TryParse(Console.ReadLine(), out int saisie);
            if (!succes)
            {
                Console.WriteLine("Une erreur est survenue pendant la conversion de la saisie en int.\n Veuillez rentrer un chiffre.");
                succes = Int32.TryParse(Console.ReadLine(), out saisie);
            }
            return saisie;
        }

        //Méthode qui permet de choisir la colonne que l'on veut selon le menu
        public int ChoixColonne(string table)
        {
            int nombreColonnes = 0;
            if (table == "Client")
            {
                Console.WriteLine("\nVoici la liste des colonnes : \n0=Civilite \n1=Nom \n2=Prenom \n3=Adresse \n4=Ville \n5=Date De Naissance \n6=Telephone \n7=Email \n8=Statut \n9=DossierID");
                nombreColonnes = 9;
            }
            else if (table == "Voyage")
            {
                Console.WriteLine("\nVoici la liste des colonnes : XXX");
                nombreColonnes = 9;
            }
            else if (table == "Dossier")
            {
                Console.WriteLine("\nVoici la liste des colonnes : XXX");
                nombreColonnes = 9;
            }

            Console.WriteLine("\nEntrez un numéro de colonne que vous souhaitez modifier.");

            bool success = Int32.TryParse(Console.ReadLine(), out int colonneSaisie);
            while (success == false)
            {
                Console.WriteLine("Vous n'avez pas rentré un chiffre");
                success = Int32.TryParse(Console.ReadLine(), out colonneSaisie);
            }

            while (colonneSaisie > nombreColonnes)
            {
                Console.WriteLine("Veuillez entrer un numéro de colonne entre 0 et " + nombreColonnes);
                colonneSaisie = Convert.ToInt32(Console.ReadLine());
            }
            return colonneSaisie;
        }
    }
}
