using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Model;
using BoVoyages.View;
using System.Data;

namespace BoVoyages.Controller
{
    class GestionDestination : Gestion
    {
        /*Classe qui permet de gérer les assurances en affichant une liste complète ou le résultat d'une recherche.*/

        public AccesBDD accesBDD = new AccesBDD();
        private string table = "Destinations";

        public GestionDestination()
        {
        }


        //Afficher une liste de tous les dossiers
        public void ListerDestination()
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.AfficherTout(table);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherDestination(int ID)
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.RechercherID(table, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string ModifierDestination(int id, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {
                case 0: nomColonne = "Region"; break;
                case 1: nomColonne = "Pays"; break;
                case 2: nomColonne = "Continent"; break;
                case 3: nomColonne = "DescriptionVoyage"; break;

            }

            return accesBDD.Modifier(table, nomColonne, nouvelleValeur, id);
        }

        public string AjouterDestination(params String[] nouvelleDestination)
        {
            return accesBDD.Ajouter(nouvelleDestination, table);
        }
    }
}
