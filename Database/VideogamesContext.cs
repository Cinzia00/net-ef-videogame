using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Database
{
    public class VideogamesContext : DbContext
    {

        DbSet<Videogame> Videogames { get; set; }
        DbSet<Software_house> Software_houses { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<Pegi_label> Pegi_labels { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Award> Awards { get; set; }
        DbSet<Tournament> Tournaments { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFVideogames;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
