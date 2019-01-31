using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace BoVoyages.Model
{
    class Client:Participant
    {
        private int clientId;
        private static string file = @"..\..\Properties\Client.txt";

        public int ClientId { get => clientId; set => clientId = value; }

        public Client(string civilite, string nom, string prenom, string adresse, int codePostal, string ville, string pays, int telephone, string email, DateTime dateDeNaissance) : base(civilite, nom, prenom, adresse, codePostal, ville, pays, telephone, email, dateDeNaissance)
        {
            this.ClientId = clientId;
        }

        public static string[] GetClients()
        {
            // Ouvrir le fichier txt des Clients
            return File.ReadAllLines(file);
        }


    }
}
