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
    /*Classe qui permet de gérer les clients en affichant une liste complète ou le résultat d'une recherche. 
    L'ajout et la suppression de clients seront gérés au moment de leur achat d'un voyage sur le site internet.*/

    class GestionClient
    {
        public List<string> clients = new List<string>();
        public AccesBDD accesBDD = new AccesBDD();

        public GestionClient()
        {
            clients = Client.GetClients().ToList();
        }

        //Afficher une liste de tous les clients
        public void ListerClients()
        {
            DataSet dataset = accesBDD.AfficherTout("Client");

            if(dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        //Afficher seulement les clients demandés, en fonction d'une entrée et dans une colonne au choix
        
        public void ChercherClient(int ID)
        {
            DataSet dataset = accesBDD.RechercherID("Client", ID);

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
       
            return accesBDD.Modifier("Client", nomColonne, nouvelleValeur, id);
        }

        // Ajout d'une ligne de client
        public void AjouterClient(params String[] nouveauClient)
        {
            accesBDD.Ajouter(nouveauClient, "Client");
        }

        public void ProcedureSupprimer(string[] parametres)
        {
            string procedure = "DeleteClient";
            parametres[0] = "ClientID";
            accesBDD.ExecuteStoredProcedureParameters(procedure, parametres);
        }





        /*
        //Afficher seulement les clients demandés, en fonction d'une entrée et dans une colonne au choix
        public void ChercherClient(int ID)
        {
            accesBDD.SelectID("Client", ID);
        }



        // Ajout d'une ligne de client
        public void AjouterClient(params String[] nouveauClient)
        {
            accesBDD.AddLine(nouveauClient, "Client");
        }


        //Modifier client
        public void ModifierClient(int clientID, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {
                case 0: nomColonne = "Civilite"; break;
                case 1: nomColonne = "Nom"; break;
                case 2: nomColonne = "Prenom"; break;
                case 3: nomColonne = "Adresse"; break;
                case 4: nomColonne = "CodePostal"; break;
                case 5: nomColonne = "Ville"; break;
                case 6: nomColonne = "DateDeNaissance"; break;
                case 7: nomColonne = "Telephone"; break;
                case 8: nomColonne = "Email"; break;
                case 9: nomColonne = "Statut"; break;
                case 10: nomColonne = "DossierID"; break;
            }
            
            accesBDD.ModifierLine(clientID, nomColonne, nouvelleValeur, "Client");
        }



        // Supprimer d'une ligne de client
        public void Supprimer(int clientSupprimer)
        {
            accesBDD.SupprimerLine(clientSupprimer, "Client");

        }
        */
    }
}
