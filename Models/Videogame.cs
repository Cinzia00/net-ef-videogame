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

        public Videogame() { }

        public Videogame(int videogameid, string name, string overview, DateTime release_date, int software_houseId) /*, Software_house software_house, List<Device> devices, List<Pegi_label> pegi_labels, List<Category> categories, List<Award> awards, List<Tournament> tournaments, List<Review> reviews)*/
        {
            VideogameId = videogameid;
            Name = name;
            Overview = overview;
            Release_date = release_date;
            Software_houseId = software_houseId;
            //Software_house = software_house;
            //Devices = devices;
            //Pegi_labels = pegi_labels;
            //Categories = categories;
            //Awards = awards;
            //Tournaments = tournaments;
            //Reviews = reviews;
        }

        public int Software_houseId { get; set; }
        public Software_house Software_house { get; set; }


        public List<Device> Devices { get; set; }
        public List<Pegi_label> Pegi_labels { get; set; }
        public List<Category> Categories { get; set; }
        public List<Award> Awards { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Review> Reviews { get; set; }


        public override string ToString()
        {
            return $"Il videogioco {this.Name} è stato rilasciato in data: {this.Release_date}. Descrizione gioco: {this.Overview}";
        }



    }
}
