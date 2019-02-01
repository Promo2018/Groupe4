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

        public AccesBDD accesBDD = new AccesBDD();
        private string table = "Dossiers";

        public GestionDossier()
        {
        }

        enum EtatDossierReservation : byte {EnAttente, EnCours, Refusee, Acceptee}
        enum RaisonAnnulationDossier : byte { client, placeInsufffisante }

        //Afficher une liste de tous les dossiers
        public void ListerDossiers()
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.AfficherTout(table);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherDossier(int ID)
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.RechercherID(table, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string AjouterDossier(params String[] nouveauDossier)
        {
            return accesBDD.Ajouter(nouveauDossier, table);
        }

        //Modifier l'état d'une réservation et, si c'est une annulation, signaler qu'un mail sera envoyé.
        public string ModifierEtatDossier(string nouvelleValeur, int id)
        {
            string messageRetour = accesBDD.Modifier(table, "Etat", nouvelleValeur, id);
            if (messageRetour == "Mise à jour de la ligne d'ID " + id + " de la table " + table && Int32.Parse(nouvelleValeur) == 2)
            {
                messageRetour = messageRetour + "\nVous avez modifié la réservation en 'annulée'. Un mail sera envoyé au client pour le prévenir.";
            }

            return messageRetour;
        }

        public string ModifierRaisonAnnulation(string nouvelleValeur, int id)
        {
            return accesBDD.Modifier(table, "RaisonAnnulation", nouvelleValeur, id);
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
