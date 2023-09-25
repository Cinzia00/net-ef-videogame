using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public int Name { get; set; }

        public List<Videogame> Videogames { get; set; }
    }
}
