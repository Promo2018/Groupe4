using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyages.Model
{
    public class Destination
    {
        private int destinationId;
        private string destinationName;
        private string continent;
        private string pays;
        private string region;
        private string description;

        public Destination(int destinationId, string destinationName, string continent, string pays, string region, string description)
        {
            this.destinationId = destinationId;
            this.destinationName = destinationName;
            this.continent = continent;
            this.pays = pays;
            this.region = region;
            this.description = description;
        }

        public int DestinationId { get => destinationId; set => destinationId = value; }
        public string DestinationName { get => destinationName; set => destinationName = value; }
        public string Continent { get => continent; set => continent = value; }
        public string Pays { get => pays; set => pays = value; }
        public string Region { get => region; set => region = value; }
        public string Description { get => description; set => description = value; }
    }
}
