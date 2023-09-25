using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Videogame
    {
        public int VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }    
        public DateTime Release_date { get; set; }


        public int Software_houseId { get; set; }
        public Software_house Software_house { get; set; }


        public List<Device> Devices { get; set; }
        public List<Pegi_label> Pegi_labels { get; set; }
        public List<Category> Categories { get; set; }
        public List<Award> Awards { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Review> Reviews { get; set; }






    }
}
