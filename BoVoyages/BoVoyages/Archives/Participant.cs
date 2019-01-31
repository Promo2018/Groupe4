using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyages.Model
{
    class Participant : Personne
    {
        private string adresse;
        private int codePostal;
        private string ville;
        private string pays;
        private int telephone;
        private string email;
        private DateTime dateDeNaissance;

        public string Adresse { get => adresse; set => adresse = value; }
        public int CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Pays { get => pays; set => pays = value; }
        public int Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateDeNaissance { get => dateDeNaissance; set => dateDeNaissance = value; }

        public Participant(string civilite, string nom, string prenom, string adresse, int codePostal, string ville, string pays, int telephone, string email, DateTime dateDeNaissance):base(civilite, nom, prenom)
        {
            this.Adresse = adresse;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Pays = pays;
            this.Telephone = telephone;
            this.Email = email;
            this.DateDeNaissance = dateDeNaissance;
        }
    }
}
