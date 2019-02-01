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
        private string nomDeTable = "Assurances";

        public GestionAssurance()
        {
        }


        //Afficher une liste de tous les dossiers
        public void ListerAssurance()
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.AfficherTout(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherAssurance(int ID)
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.RechercherID(nomDeTable, ID);

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

            return accesBDD.Modifier("Assurances", nomColonne, nouvelleValeur, id);
        }

        /*
        public void AjouterDossier(params String[] nouveauDossier)
        {
            accesBDD.Ajouter(nouveauDossier, nomDeTable);
        }

        public string ModifierEtatDossier(string nouvelleValeur, int id)
        {
            return accesBDD.Modifier(nomDeTable, "Etat", nouvelleValeur, id);
        }

        public string ModifierRaisonAnnulation(string nouvelleValeur, int id)
        {
            return accesBDD.Modifier(nomDeTable, "RaisonAnnulation", nouvelleValeur, id);
        }

        public int CalculerPrixTousVoyages()
        {
            return accesBDD.ExecuterProcedure("CalculPrixVoyage");

        }

        public void Supprimer(int id)
        {
            accesBDD.Supprimer("Dossiers", id);
        }
        */

    }
}
