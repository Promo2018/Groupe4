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
    class GestionAgence : Gestion
    {
        /*Classe qui permet de gérer les assurances en affichant une liste complète ou le résultat d'une recherche.*/

        public AccesBDD accesBDD = new AccesBDD();
        private string nomDeTable = "AgencesVoyages";

        public GestionAgence()
        {
        }


        //Afficher une liste de tous les dossiers
        public void ListerAgence()
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.AfficherTout(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherAgence(int ID)
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.RechercherID(nomDeTable, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string ModifierAgence(int id, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {
                case 0: nomColonne = "NomAgence"; break;

            }

            return accesBDD.Modifier("AgencesVoyages", nomColonne, nouvelleValeur, id);
        }



    }
}
