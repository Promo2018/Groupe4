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
    class AccesBDD
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


        public DataSet AfficherTout(string table)          // Afficher tout le contenu d'une table
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

        public DataSet AfficherColonnes(string table)          // Afficher les noms des colonnes
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
                adapter.Fill(this.dataset, "Resultat");
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
                resultat = "La requête a été refusée par le serveur.";
                Console.WriteLine(e.Message);            
            }
            this.Deconnecter();
            return resultat;
        }

        public DataSet RechercherID(string table, int ID)          // Select all from a table
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


        public bool Supprimer(string table, int id)
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


        // Ajouter soit un client, soit un voyage à la base de données via GestionClient ou GestionVoyage
        public void Ajouter(string[] nouvelleLigne, string table)
        {
            this.Connecter(this.baseDeDonnees);
            try
            {
                if (table == "Client")
                {
                    commande.CommandText = "insert into " + table + " (Civilite, Nom, Prenom, Adresse, Ville, DateDeNaissance, Telephone, Email, Statut, DossierID) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "', '" + nouvelleLigne[5] + "', '" + nouvelleLigne[6] + "', '" + nouvelleLigne[7] + "', '" + nouvelleLigne[8] + "', '" + nouvelleLigne[9] + "');";
                }
                else if (table == "Voyage")
                {
                    //cmd.CommandText = "INSERT [dbo].[Voyage] ([DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix]) VALUES (4, N'2019-02-08', N'2019-02-23', 5, 1638)";
                    commande.CommandText = "insert into " + table + " (DestinationID, DateAller, DateRetour, NombreDePlaces, Prix) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "');";
                }
                this.commande.Connection = this.connexion;
                commande.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("probleme de requete");
                Console.WriteLine(e.Message);
            }
            this.Deconnecter();
        }

        public int ExecuterProcedure(String procedure)
        {
            this.Connecter(this.baseDeDonnees);
            int lignes = -1;
            try
            {
                this.commande.CommandText = procedure;
                this.commande.Connection = this.connexion;
                //this.commande.CommandType = CommandType.StoredProcedure;
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

        public int ExecuteStoredProcedureParameters(String procedure, String[] parms)
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



        /*public void SelectAll(string table)
        {

            SqlCommand commande = new SqlCommand { Connection = con };

            if (table == "Client")
            {
                commande.CommandText = "Select * from " + table + " ;";
            }
            /*else if (table == "Voyage")
            {
                commande.CommandText = "select V.VoyageID, D.Region, D.Pays, V.DateAller, V.DateRetour, V.NombreDePlaces, V.Prix from Destination D, Voyage V where D.DestinationID = V.DestinationID;";
            }
            else if (table == "Dossier")
            {
                commande.CommandText = "select D.DossierID, C.Statut, C.Prenom, C.Nom, c.Adresse, D.Etat from Dossier D, Client C where D.DossierID=C.DossierID;";
            }*/

        /*
        SqlDataReader reader;

        reader = commande.ExecuteReader();

        while (reader.Read())
        {
            if (table == "Client")
            {
                Console.WriteLine(reader["ClientID"].ToString() + "   " + reader["Civilite"] + "   " + reader["Nom"] + "   " + reader["Prenom"] + "   " + reader["Adresse"] + "   " + reader["Ville"] + "   " + reader["DateDeNaissance"] + "   " + reader["Telephone"] + "   " + reader["Email"]);

            }*/
        /*
        else if (table == "Voyage")
        {
            Console.WriteLine(reader["VoyageID"].ToString() + "   " + reader["Region"] + "   " + reader["Pays"] + "   " + reader["DateAller"] + "   " + reader["DateRetour"] + "   " + reader["NombreDePlaces"] + "   " + reader["Prix"]);
        }
        else if (table == "Dossier")
        {
            Console.WriteLine(reader["DossierID"].ToString() + "   " + reader["Statut"] + "   " + reader["Prenom"] + "   " + reader["Nom"] + "   " + reader["Adresse"] + reader["Etat"]);

        }

    }
    reader.Close();
    con.Close();
}


/*


//Méthode de connexion à la base de données Bovoyages
private void Connexion(bool checkConnexion)
{
    if (checkConnexion == true)
    {

        Console.WriteLine("coucou");
    }
    else
    {

        Console.ReadKey();
    }

}

public void SelectAll(string table)
{

    SqlConnection con = new SqlConnection
    {
        ConnectionString = @"Data Source=localhost;Initial Catalog = " + baseDeDonnees + "; Integrated Security = SSPI"
    };
    con.Open();

    //step2
    SqlCommand commande = new SqlCommand{Connection = con};

    if (table == "Client")
    {
        commande.CommandText = "Select * from " + table + " ;";
    }
    else if (table == "Voyage")
    {
        commande.CommandText = "select V.VoyageID, D.Region, D.Pays, V.DateAller, V.DateRetour, V.NombreDePlaces, V.Prix from Destination D, Voyage V where D.DestinationID = V.DestinationID;";
    }
    else if (table == "Dossier")
    {
        commande.CommandText = "select D.DossierID, C.Statut, C.Prenom, C.Nom, c.Adresse, D.Etat from Dossier D, Client C where D.DossierID=C.DossierID;";
    }

    //step3
    SqlDataReader reader;

    //steps 4 and 5
    reader = commande.ExecuteReader();

    //step 6
    while (reader.Read())
    {
        if (table == "Client")
        {
            Console.WriteLine(reader["ClientID"].ToString() + "   " + reader["Civilite"] + "   " + reader["Nom"] + "   " + reader["Prenom"] + "   " + reader["Adresse"] + "   " + reader["Ville"] + "   " + reader["DateDeNaissance"] + "   " + reader["Telephone"] + "   " + reader["Email"]);

        }
        else if(table == "Voyage")
        {
            Console.WriteLine(reader["VoyageID"].ToString() + "   " + reader["Region"] + "   " + reader["Pays"] + "   " + reader["DateAller"] + "   " + reader["DateRetour"] + "   " + reader["NombreDePlaces"] + "   " + reader["Prix"]);
        }
        else if(table == "Dossier")
        {
            Console.WriteLine(reader["DossierID"].ToString() + "   " + reader["Statut"] + "   " + reader["Prenom"] + "   " + reader["Nom"] + "   " + reader["Adresse"] + reader["Etat"]);

        }

    }
    reader.Close();
    con.Close();

}

public void SelectID(string table, int ID)
{
    SqlConnection con = new SqlConnection
    {
        ConnectionString = @"Data Source=localhost;Initial Catalog = " + baseDeDonnees + "; Integrated Security = SSPI"
    };
    con.Open();

    SqlCommand commande = new SqlCommand
    {
        Connection = con
    };
    if (table == "Client")
    {
        commande.CommandText = "Select * from " + table + " where ClientID =" + ID + ";";
    }
    else if (table == "Dossier")
    {
        commande.CommandText = "select C.Statut, C.Civilite, C.Prenom, C.Nom, V.Prix, D.PrixTotal, D.Etat from Client C, Voyage V, Dossier D where D.DossierID=" + ID + " and D.DossierID=C.DossierID and V.VoyageID=D.VoyageID;";
    }

    //                          select C.Statut, C.Civilite, C.Prenom, C.Nom, D.PrixTotal, D.Etat, V.Prix from Client C, Dossier D, Voyage V where C. DossierID=84 and D.DossierID=C.DossierID and V.VoyageID = D.VoyageID; --GOOD ONE!!!


    // OLD VER: -----commande.CommandText = "select C.Statut, C.Civilite, C.Prenom, C.Nom, E.Region, V.Prix, D.PrixTotal, D.Etat from Client C, Voyage V, Dossier D, destination E where D.DossierID=" + ID + " and D.DossierID=C.DossierID and V.VoyageID=D.VoyageID and E.DestinationID=V.DestinationID;";

    SqlDataReader reader;
    reader = commande.ExecuteReader();

    if(table == "Dossier")
    {
        Console.WriteLine("\n Voici les participants du dossier dont l'ID est " + ID + ":\n");
    }

    while (reader.Read())
    {
        if (table == "Client")
        {
            Console.WriteLine("\n Voici le client dont l'ID est " + ID + " :");
            Console.WriteLine(reader["ClientID"].ToString() + "   " + reader["Civilite"] + "   " + reader["Nom"] + "   " + reader["Prenom"] + "   " + reader["Adresse"] + "   " + reader["Ville"] + "   " + reader["DateDeNaissance"] + "   " + reader["Telephone"] + "   " + reader["Email"] + "\n");

        }
        // else if VOYAGES .....
        else if (table == "Dossier")
        {
            Console.WriteLine(reader["Statut"].ToString() + "   " + reader["Civilite"] + "   " + reader["Prenom"] + "   " + reader["Nom"] + "   "  + reader["Prix"] + "   " + reader["PrixTotal"] + "   " + reader["Etat"]);
        }
    }

    reader.Close();

    con.Close();
}

// Ajouter soit un client, soit un voyage à la base de données via GestionClient ou GestionVoyage
public void AddLine(string[] nouvelleLigne, string nomDeTable)
{

    SqlConnection con = new SqlConnection
    {
        ConnectionString = @"Data Source=localhost;Initial Catalog = " + baseDeDonnees + "; Integrated Security = SSPI"
    };
    con.Open();


    //2

    SqlCommand cmd = new SqlCommand
    {
        Connection = con
    };


    if (nomDeTable == "Client")
    {
        cmd.CommandText = "insert into dbo.Client (Civilite, Nom, Prenom, Adresse, Ville, DateDeNaissance, Telephone, Email, Statut, DossierID) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "', '" + nouvelleLigne[5] + "', '" + nouvelleLigne[6] + "', '" + nouvelleLigne[7] + "', '" + nouvelleLigne[8] + "', '" + nouvelleLigne[9] + "');";
    }
    else if (nomDeTable == "Voyage")
    {
        //cmd.CommandText = "INSERT [dbo].[Voyage] ([DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix]) VALUES (4, N'2019-02-08', N'2019-02-23', 5, 1638)";
        cmd.CommandText = "insert into dbo.Voyage (DestinationID, DateAller, DateRetour, NombreDePlaces, Prix) values ('" + nouvelleLigne[0] + "', '" + nouvelleLigne[1] + "', '" + nouvelleLigne[2] + "', '" + nouvelleLigne[3] + "', '" + nouvelleLigne[4] + "');";
    }

    Console.ReadKey();
    //steps 4 and 5
    cmd.ExecuteNonQuery();
    con.Close();
}

// Supprimer soit un client, soit un voyage à la base de données via GestionClient ou GestionVoyage
public void SupprimerLine(int clientDelete, string nomDeTable)
{

    SqlConnection con = new SqlConnection
    {
        ConnectionString = @"Data Source=localhost;Initial Catalog = " + baseDeDonnees + "; Integrated Security = SSPI"
    };
    con.Open();

    SqlCommand cmd = new SqlCommand
    {
        Connection = con
    };


    if (nomDeTable == "Client")
    {
        cmd.CommandText = "delete from dbo.Client where ClientID='" + clientDelete + "'";
    }
    else if (nomDeTable == "Voyage")
    {
        cmd.CommandText = "delete from dbo.Voyage where VoyageID='" + clientDelete + "'";
    }
    else if (nomDeTable =="Dossier")
    {

        cmd.CommandText = "delete from dbo.Dossier where DossierID = '" + clientDelete + "'";
        cmd.CommandText = "delete from dbo.Client where DossierID = '" + clientDelete + "'";

    }


    //steps 4 and 5
    cmd.ExecuteNonQuery();
    con.Close();
}

// Modifier soit un client, soit un voyage à la base de données via GestionClient ou GestionVoyage
public void ModifierLine(int clientModifier, string nomColonne, string nouvelleValeur , string nomDeTable)
{

    SqlConnection con = new SqlConnection
    {
        ConnectionString = @"Data Source=localhost;Initial Catalog = " + baseDeDonnees + "; Integrated Security = SSPI"
    };
    con.Open();


    //2

    SqlCommand cmd = new SqlCommand
    {
        Connection = con
    };


    if (nomDeTable == "Client")
    {
        cmd.CommandText = "update dbo.Client set "+ nomColonne +" = '"+ nouvelleValeur +"' where ClientID = "+ clientModifier +";"; 
    }
    else if (nomDeTable == "Voyage")
    {
       // cmd.CommandText = "delete from dbo.Voyage where VoyageID='" + clientDelete + "'";
    }


    //steps 4 and 5
    cmd.ExecuteNonQuery();
    con.Close();
}
*/

    }
}

