using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Software_house
    {
        public int Software_houseId { get; set; }
        public string Name { get; set; }
        public string Tax_id { get; set; }
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }
    }
}
