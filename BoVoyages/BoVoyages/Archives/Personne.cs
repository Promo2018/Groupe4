using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//La classe Personne contient des attributs de base hérités par les classes Commercial et Participant
namespace BoVoyages.Model
{
    public class Personne
    {
        private string civilite;
        private string nom;
        private string prenom;
        public string Civilite { get => civilite; set => civilite = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public Personne(string civilite, string nom, string prenom)
        {
            this.Civilite = civilite;
            this.Nom = nom;
            this.Prenom = prenom;
        }

    }
}
