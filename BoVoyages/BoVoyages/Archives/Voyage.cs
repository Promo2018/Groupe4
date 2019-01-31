using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoVoyages.Model
{
    public class Voyage
    {
        private static string file = @"..\..\Properties\voyages.txt";
        private Destination destination = null;
        private DateTime dateAller;
        private DateTime dateRetour;
        private int nombrePersonnes = 0;
        private Client client;

        public Destination Destination { get => destination; set => destination = value; }
        public DateTime DateAller { get => dateAller; set => dateAller = value; }
        public DateTime DateRetour { get => dateRetour; set => dateRetour = value; }
        public int NombrePersonnes { get => nombrePersonnes; set => nombrePersonnes = value; }
        internal Client Client { get => client; set => client = value; }

        public static string[] getVoyages()
        {
            return File.ReadAllLines(file);
        }

        public static void setVoyages(string[] lines)
        {
            File.WriteAllLines(file, lines);
        }

    }
}
