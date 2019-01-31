using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyages.Model
{
    class Accompagnant:Participant
    {
        private int accompagnantId;

        public int AccompagnantId { get => accompagnantId; set => accompagnantId = value; }

        public Accompagnant(string civilite, string nom, string prenom, string adresse, int codePostal, string ville, string pays, int telephone, string email, DateTime dateDeNaissance, int accompagnantId) : base(civilite, nom, prenom, adresse, codePostal, ville, pays, telephone, email, dateDeNaissance)
        {
            this.AccompagnantId = accompagnantId;
        }
        
    }
}
