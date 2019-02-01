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

        //Affiche toutes les colonnes, à faire avant une ImpressionTable
        public static void ImpressionColonnes(DataSet dataColumn)
        {
            if (dataColumn.Tables["Colonnes"].Rows.Count > 0)
            {
                string impression = "";
                foreach (DataRow ligne in dataColumn.Tables["Colonnes"].Rows)
                {

                    for (int i = 0; i < ligne.ItemArray.Length; i++)
                    {
                        impression = String.Concat(impression, ligne[i].ToString(), " ");
                    }
                }
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(impression);
                Console.WriteLine("----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Aucun nom de colonne à afficher.");
            }
        }

        //Affiche toutes les colonnes une à une et demande une saisie (pas de contrôle spécifique, surcharger pour ajouter contrôles)
        public static string[] SaisirNouvelleLigne(DataSet dataColumn)
        {
            List<string> listeSaisies = new List<string>();

            if (dataColumn.Tables["Colonnes"].Rows.Count > 0)
            {
                foreach (DataRow ligne in dataColumn.Tables["Colonnes"].Rows)
                {
                    for (int i = 0; i < ligne.ItemArray.Length; i++)
                    {
                        if(ligne[i].ToString() == "ID")
                        {

                        }
                        else
                        {
                            Console.Write(ligne[i] + " : ");
                            listeSaisies.Add(Console.ReadLine());
                        }
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("Erreur, pas de colonne trouvée dans la table.");
            }
            return listeSaisies.ToArray();
        }

        //Convertit l'ID en int
        public int SaisirEtVerifierID()
        {
            bool succes = true;
            int saisie;
            do
            {
                succes = Int32.TryParse(Console.ReadLine(), out saisie);
                if (succes == false)
                {
                    Console.WriteLine("Une erreur est survenue pendant la conversion de la saisie en int.\nVeuillez rentrer un chiffre.");
                }
                if (succes == true && saisie > 200)
                {
                    Console.WriteLine("Cet ID n'existe pas dans la table. Merci de rentrer un ID existant");
                    succes = false;
                }
                
            } while (succes == false); //Recommencer tant qu'un nombre n'est pas saisi
            return saisie;
        }

        //Permet de choisir la colonne que l'on veut selon le menu
        public int ChoixColonne(int nombreColonnes)
        {
            Console.WriteLine("\nVeuillez entrer un numéro de colonne que vous souhaitez modifier.");

            bool success = Int32.TryParse(Console.ReadLine(), out int colonneSaisie);
            while (success == false)
            {
                Console.WriteLine("Vous n'avez pas rentré un chiffre");
                success = Int32.TryParse(Console.ReadLine(), out colonneSaisie);
            }

            while (colonneSaisie >= nombreColonnes)
            {
                Console.WriteLine("Veuillez entrer un numéro de colonne entre 0 et " + (nombreColonnes - 1));
                colonneSaisie = Convert.ToInt32(Console.ReadLine());
            }
            return colonneSaisie;
        }
    }
}
