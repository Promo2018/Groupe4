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
    class GestionDossier : Gestion
    {
        /*Classe qui permet de gérer les dossiers en affichant une liste complète ou le résultat d'une recherche.*/

        public List<string> dossiers = new List<string>();
        public AccesBDD accesBDD = new AccesBDD();
        private string nomDeTable = "Dossiers";

        public GestionDossier()
        {
        }

        enum EtatDossierReservation : byte {EnAttente, EnCours, Refusee, Acceptee}
        enum RaisonAnnulationDossier : byte { client, placeInsufffisante }

        //Afficher une liste de tous les dossiers
        public void ListerDossiers()
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.AfficherTout(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherDossier(int ID)
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.RechercherID(nomDeTable, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string AjouterDossier(params String[] nouveauDossier)
        {
            return accesBDD.Ajouter(nouveauDossier, nomDeTable);
        }

        public string ModifierEtatDossier(string nouvelleValeur, int id)
        {
            return accesBDD.Modifier(nomDeTable, "Etat", nouvelleValeur, id);
        }

        public string ModifierRaisonAnnulation(string nouvelleValeur, int id)
        {
            return accesBDD.Modifier(nomDeTable, "RaisonAnnulation", nouvelleValeur, id);
        }

        public int CalculerPrixTousVoyages ()
        {
            return accesBDD.ExecuterProcedure("CalculPrixVoyage");
                       
        }

        public void Supprimer(int id)
        {
            accesBDD.Supprimer("Dossiers", id);
        }


    }
}
