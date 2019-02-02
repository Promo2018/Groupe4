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
    /*Classe qui permet de gérer les clients en affichant une liste complète ou le résultat d'une recherche.*/

    class GestionClient : Gestion
    {
        public AccesBDD accesBDD = new AccesBDD();
        private string table = "Clients";

        public GestionClient()
        {
            
        }

        //Afficher une liste de tous les clients
        public void ListerClients()
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.AfficherTout(table);

            if(dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        //Chercher un client précis
        public void ChercherClient(int ID)
        {
            ListerColonnes(accesBDD, table);

            DataSet dataset = accesBDD.RechercherID(table, ID);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }

        }
        
        public string ModifierClient(int id, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {
                case 0: nomColonne = "Civilite"; break;
                case 1: nomColonne = "Nom"; break;
                case 2: nomColonne = "Prenom"; break;
                case 3: nomColonne = "Adresse"; break;
                case 4: nomColonne = "Ville"; break;
                case 5: nomColonne = "DateDeNaissance"; break;
                case 6: nomColonne = "Telephone"; break;
                case 7: nomColonne = "Email"; break;
                case 8: nomColonne = "Statut"; break;
                case 9: nomColonne = "DossierID"; break;
            }
       
            return accesBDD.Modifier("Clients", nomColonne, nouvelleValeur, id);
        }

        // Ajout d'une ligne de client
        public string AjouterClient(params String[] nouveauClient)
        {
            return accesBDD.Ajouter(nouveauClient, table);
        }

        public void SupprimerClient(int id)
        {
            accesBDD.Supprimer(table, id);
        }
    }
}
