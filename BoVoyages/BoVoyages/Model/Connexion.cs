using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BoVoyages.Model
{
    class Connexion
    {
        public static void Select()
        {
            try
            {
                // phase n°1
                SqlConnection con = new SqlConnection{ConnectionString = @"Data Source=localhost;"};
                con.ConnectionString += @"Initial Catalog=Northwind;Integrated Security=SSPI";
                con.Open();
                // phase n°2
                SqlCommand cmd = new SqlCommand{Connection = con,CommandText = "SELECT * FROM Cours;"};
                // phase n°3
                SqlDataReader reader;
                // phase n°4 et 5
                reader = cmd.ExecuteReader();
                // phase n°6
                int n = 1;
                while (reader.Read())
                {
                    Console.WriteLine(n.ToString() + ") " + reader["Matiere"].ToString() + " est une matière d'une durée de " + reader["Duree"].ToString() + " heures");
                    n++;
                }
                reader.Close();
                // phase n°7
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        Console.ReadKey();
        }

        public static void Update()
        {
            try
            {
                // phase n°1
                SqlConnection con = new SqlConnection
                {ConnectionString = @"Data Source=localhost;"};
                con.ConnectionString += @"Initial Catalog=Northwind;Integrated Security=SSPI";
                con.Open();
                // phase n°2
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "UPDATE Cours set Duree = 3000 where CoursID = 2;"
                };
                // phase n°6
                cmd.ExecuteNonQuery();
                Console.WriteLine("Update effectuée");
                // phase n°7
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void Insert()
        {
            try
            {
                // phase n°1
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=localhost;"
                };
                con.ConnectionString += @"Initial Catalog=Northwind;Integrated Security=SSPI";
                con.Open();
                // phase n°2
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "INSERT INTO Cours (Matiere, Duree) values('Jardinier', 487);"
                };
                // phase n°6
                cmd.ExecuteNonQuery();
                Console.WriteLine("INSERT effectué");
                // phase n°7
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void Delete()
        {
            try
            {
                // phase n°1
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=localhost;"
                };
                con.ConnectionString += @"Initial Catalog=Northwind;Integrated Security=SSPI";
                con.Open();
                // phase n°2
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "DELETE from Cours WHERE CoursID = (SELECT TOP 1 CoursID FROM Cours ORDER BY CoursID DESC);"
                };
                // phase n°6
                cmd.ExecuteNonQuery();
                Console.WriteLine("DELETE effectué");
                // phase n°7
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
