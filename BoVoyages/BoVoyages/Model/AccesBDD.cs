using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace BoVoyages.Model
{
    public class AccesBDD
    {
        public string baseDeDonnees = "Bovoyages";

        private SqlConnection connexion;
        private SqlCommand commande;
        private DataSet dataset;

        public AccesBDD()
        {
            this.commande = new SqlCommand();
            this.dataset = new DataSet();
        }

        public SqlConnection Connecter(String bdd)
        {
            bool result = true;
            this.connexion = new SqlConnection
            {
                ConnectionString = @"Data Source=localhost;" + @"Initial Catalog=" + baseDeDonnees + ";" + @"Integrated Security=SSPI"
            };
            try
            {
                this.connexion.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("probleme de connexion à " + baseDeDonnees);
                result = false;
            }
            return result ? this.connexion : null;
        }

        public Boolean Deconnecter()
        {
            bool result = true;
            try
            {
                this.connexion.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("probleme de déconnexion");
                result = false;
            }
            return result;
        }

        public DataSet AfficherTout(string table)          // Récupérer toute une table, la renvoyer pour affichage
        {
            this.Connecter(this.baseDeDonnees);
            try
            {
                this.dataset.Clear();
                this.commande.CommandText = "select * from " +table;
                this.commande.Connection = this.connexion;
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = this.commande
                };
                adapter.Fill(this.dataset, "Resultat");
            }
            catch (Exception e)
            {
                Console.WriteLine("probleme de requete");
                Console.WriteLine(e.Message);
                this.dataset = null;
            }
            this.Deconnecter();
            return this.dataset;
        }

        public DataSet RecupererNomsColonnes(string table)          // Récupérer les noms des colonnes, les renvoyer pour affichage
        {
            this.Connecter(this.baseDeDonnees);
            try
            {
                this.dataset.Clear();
                this.commande.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + table + "'";
                this.commande.Connection = this.connexion;
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = this.commande
                };
                adapter.Fill(this.dataset, "Colonnes");
            }
            catch (Exception e)
            {
                Console.WriteLine("Problème dans la tentative d'afficher les noms des colonnes");
                Console.WriteLine(e.Message);
                this.dataset = null;
            }
            this.Deconnecter();
            return this.dataset;
        }

        public string Modifier(string table, string nomColonne, string nouvelleValeur, int id)
        {
            this.Connecter(this.baseDeDonnees);
            string resultat = "";

            try
            {
                this.commande.CommandText = "update "+ table + " set " + nomColonne + " = '" + nouvelleValeur + "' where ID=" + id + ";"; //Changement en dur en attendant nouvelle BDD
                this.commande.Connection = this.connexion;
                this.commande.ExecuteNonQuery();
                resultat = "Mise à jour de la ligne d'ID " + id + " de la table " + table;
            }
            catch (Exception e)
            {
                resultat = "La requête a été refusée par le serveur." + e.Message;           
            }
            this.Deconnecter();
            return resultat;
        } //Modifier une ligne

        public DataSet RechercherID(string table, int ID)          // Chercher un élément précis par son ID, le renvoyer pour affichage
        {
            this.Connecter(this.baseDeDonnees);
            try
            {
                this.dataset.Clear();
                this.commande.CommandText = "Select * from " + table + " where ID =" + ID + ";";
                this.commande.Connection = this.connexion;

                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = this.commande
                };
                adapter.Fill(this.dataset, "Resultat");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("probleme de requete");
                this.dataset = null;
            }
            this.Deconnecter();
            return this.dataset;
        }

        public bool Supprimer(string table, int id) // Supprimer une ligne 
        {
            this.Connecter(this.baseDeDonnees);
            bool result = true;
            try
            {
                this.commande.CommandText = "delete from " + table + " where ID=" + id + ";";
                Console.WriteLine(this.commande.CommandText);
                this.commande.Connection = this.connexion;
                this.commande.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("probleme de requete");
                result = false;
            }
            this.Deconnecter();
            return result;
        } 

        public string Ajouter(string[] nouvelleLigne, string table)  // Ajouter une ligne
        {
            string retour = "";
            this.Connecter(this.baseDeDonnees);
            try
            {
                if (table == "Clients")
                {
                    commande.CommandText = "insert into " + table + " (Civilite, Nom, Prenom, Adresse, Ville, DateDeNaissance, Telephone, Email, Statut, DossierID) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "', '" + nouvelleLigne[5] + "', '" + nouvelleLigne[6] + "', '" + nouvelleLigne[7] + "', '" + nouvelleLigne[8] + "', '" + nouvelleLigne[9] + "');";
                    retour = "Le client " + nouvelleLigne[1] + "a été ajouté.";
                }
                else if (table == "Voyages")
                {
                    commande.CommandText = "insert into " + table + " (DestinationID, DateAller, DateRetour, NombreDePlaces, Prix, AgenceID) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "', '" + nouvelleLigne[5] + "');";
                    retour = "Le voyage du " + nouvelleLigne[1] + "a été ajouté.";
                }
                else if (table == "Dossiers")
                {
                    //La colonne état est toujours fixée à 0 (enAttente) au départ
                    commande.CommandText = "insert into " + table + " (VoyageID, ClientID, Etat, PrixTotal, CarteBancaire) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', 0, '" + nouvelleLigne[4] + "', '" + nouvelleLigne[5] + "');";
                    retour = "Le dossier correspond au client numéro " + nouvelleLigne[1] + " a été ajouté.";
                }
                else if (table == "Assurances")
                {
                    commande.CommandText = "insert into " + table + " (Nom, Cout, Type) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "');";
                    retour = "L'agence " + nouvelleLigne[0] + " a été ajoutée.";
                }

                else if (table == "AgencesVoyages")
                {
                    commande.CommandText = "insert into " + table + " (NomAgence) values ('" + nouvelleLigne[0] + "');";
                    retour = "L'agence " + nouvelleLigne[0] + " a été ajoutée.";
                }
                this.commande.Connection = this.connexion;
                commande.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                retour = "probleme de requête lors de la tentative d'ajout d'une nouvelle ligne à la table " + table + "\n" + e.Message;
            }
            this.Deconnecter();
            return retour;
        }

        public int ExecuterProcedure(String procedure)
        {
            this.Connecter(this.baseDeDonnees);
            int lignes = -1;
            try
            {
                this.commande.CommandText = procedure;
                this.commande.Connection = this.connexion;
                this.commande.CommandType = CommandType.StoredProcedure;
                lignes = this.commande.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("La procedure " + procedure + " n'a pas pu être appelée.");
                Console.WriteLine(e.Message);
            }
            this.Deconnecter();
            return lignes;
        }

        public int ExecuterProcedureAvecParametres(String procedure, String[] parms)
        {
            this.Connecter(this.baseDeDonnees);
            int lignes = -1;
            if (parms.Length == 0)
            {
                lignes = ExecuterProcedure(procedure);
            }
            else
            {
                SqlParameter par;

                try
                {
                    this.commande.CommandText = procedure;
                    this.commande.Connection = this.connexion;
                    this.commande.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parms.Length; i = i + 2)
                    {
                        par = commande.Parameters.AddWithValue('@' + parms[i], parms[i + 1]);
                    }
                    lignes = this.commande.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("La procedure " + procedure + " n'a pas pu être appelée.");
                    Console.WriteLine(e.Message);
                }
            }
            this.Deconnecter();
            return lignes;
        }

    }
}

