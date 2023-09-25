using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}

        public List<Videogame> Videogames { get; set; }

    }
}
