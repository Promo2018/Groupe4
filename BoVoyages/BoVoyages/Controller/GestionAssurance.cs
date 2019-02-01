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
    class GestionAssurance : Gestion
    {
        /*Classe qui permet de gérer les assurances en affichant une liste complète ou le résultat d'une recherche.*/

        public AccesBDD accesBDD = new AccesBDD();
        private string table = "Assurances";

        public GestionAssurance()
        {
        }


        //Afficher une liste de tous les dossiers
        public void ListerAssurance()
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.AfficherTout(table);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherAssurance(int ID)
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.RechercherID(table, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string ModifierAssurance(int id, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {        
                case 0: nomColonne = "Nom"; break;
                case 1: nomColonne = "Cout"; break;
                case 2: nomColonne = "Type"; break;
                
            }

            return accesBDD.Modifier(table, nomColonne, nouvelleValeur, id);
        }

        public string AjouterAssurance(params String[] nouvelleAssurance)
        {
            return accesBDD.Ajouter(nouvelleAssurance, table);
        }

    }
}
