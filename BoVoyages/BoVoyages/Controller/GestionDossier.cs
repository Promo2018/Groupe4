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
    class GestionDossier
    {
        public List<string> dossiers = new List<string>();
        public AccesBDD accesBDD = new AccesBDD();

        //Afficher une liste de tous les dossiers
        public void ListerDossiers()
        {
            accesBDD.Connecter(accesBDD.baseDeDonnees);

            DataSet dataset = accesBDD.AfficherTout("Dossier");

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void ChercherDossier(int ID)
        {
            accesBDD.RechercherID("Dossier", ID);
        }

        public void AjouterDossier(params String[] nouveauDossier)
        {
            accesBDD.Ajouter(nouveauDossier, "Dossier");
        }

        public void Supprimer(int id)
        {
            accesBDD.Supprimer("Dossier", id);
        }


    }
}
