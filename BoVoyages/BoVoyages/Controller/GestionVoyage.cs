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
    public class GestionVoyage
    {
        private List<string> voyages = new List<string>();

        AccesBDD accesBDD = new AccesBDD();

        public GestionVoyage()
        {
            voyages = Voyage.getVoyages().ToList();
        }

        public void ListVoyages()
        {
            accesBDD.Connecter(accesBDD.baseDeDonnees);

            DataSet dataset = accesBDD.AfficherTout("Voyage");

            if (dataset != null)
            {
                Menu.ImpressionTable(dataset);
            }
        }

        public void AjouterVoyages(params String[] nouveauVoyage)
        {
            accesBDD.Ajouter(nouveauVoyage, "Voyage");
        }

        public void Enregistrer()
        {
            Voyage.setVoyages(voyages.ToArray());
        }

        public void SupprimerVoyagesExpires()
        {
            for(int i = 0; i < voyages.Count; i++ )
            {
                if(GetDateDebut(voyages[i]) < DateTime.Today)
                {
                    voyages.Remove(voyages[i]);
                }
            }
        }

        private DateTime GetDateDebut(string line)
        {
            DateTime dateDebut;
            string[] values = line.Split(',');
            dateDebut = DateTime.Parse(values[2]);
            return dateDebut;
        }

        // Supprimer une ligne de voyage
        public void Supprimer(int id)
        {
            accesBDD.Supprimer("Voyage", id);

        }

    }
}

