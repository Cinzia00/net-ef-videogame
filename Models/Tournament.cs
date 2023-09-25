using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Year { get; set; }


        public List<Videogame> Videogames { get; set; }
        public List<Player> Players { get; set; }


    }
}
