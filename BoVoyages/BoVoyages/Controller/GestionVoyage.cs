using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Model;
using System.Data;
using BoVoyages.View;


namespace BoVoyages.Controller
{
    public class GestionVoyage : Gestion
    {
        AccesBDD accesBDD = new AccesBDD();
        string nomDeTable = "Voyages";

        public GestionVoyage()
        {
            
        }

        //Lister tous les voyages
        public void ListerVoyages()
        {
            ListerColonnes(accesBDD, nomDeTable);

            DataSet dataset = accesBDD.AfficherTout(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public string AjouterVoyage(params String[] nouveauVoyage)
        {
            return accesBDD.Ajouter(nouveauVoyage, nomDeTable);
        }

        public string ModifierVoyage(int id, int colonne, string nouvelleValeur)
        {
            string nomColonne = "";

            switch (colonne)
            {
                case 0: nomColonne = "DestinationID"; break;
                case 1: nomColonne = "DateAller"; break;
                case 2: nomColonne = "DateRetour"; break;
                case 3: nomColonne = "NombreDePlaces"; break;
                case 4: nomColonne = "Prix"; break;
                case 5: nomColonne = "AgenceID"; break;
            }

            return accesBDD.Modifier(nomDeTable, nomColonne, nouvelleValeur, id);
        }

        // Supprimer une ligne de voyage
        public void SupprimerVoyage(int id)
        {
            accesBDD.Supprimer(nomDeTable, id);
        }

        public void ListerColonnes()
        {
            DataSet dataset = accesBDD.RecupererNomsColonnes(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionColonnes(dataset);
            }
        }
    }
}

