using Microsoft.Data.SqlClient;
using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideogameManager
    {

        public static bool AggiungiVideogioco(Videogame videogame)
        {
            using (VideogamesContext db = new VideogamesContext())
            {

                try
                {
                    
                        db.Add(videogame);
                        db.SaveChanges();

                        Console.WriteLine("Videogioco aggiunto con successo!");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;

            }
        }

        public static Videogame RicercaGiocoPerId(long id)
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                Videogame videogameTrovato = null;

                try
                {
                    videogameTrovato = db.Videogames.Where(videogame => videogame.VideogameId == id).FirstOrDefault<Videogame>();
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ciaone");
                    Console.WriteLine(ex.Message);
                }

                return videogameTrovato;
            }
        }

        public static List<Videogame> RicercaPerNome(string nome)
        {
            List<Videogame> videogames = new List<Videogame>();
            using (VideogamesContext db = new VideogamesContext())

                try
                {
                    videogames = db.Videogames.Where(videogame => videogame.Name == nome).ToList<Videogame>();

                    if(videogames.Count > 0)
                    {
                        foreach(Videogame videogame in videogames)
                        {
                            Console.WriteLine(videogame.ToString()); 
                        }

                    }else
                    {
                        Console.WriteLine("Nessun videogioco trovato");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return videogames;

         }

        public static Videogame CancellaVideogame(long idDaCancellare)
        {
            Videogame videogameDaCancellare = null;

            using (VideogamesContext db = new VideogamesContext())
            {
                try
                {
                    videogameDaCancellare = db.Videogames.Where(videogame => videogame.VideogameId == idDaCancellare).FirstOrDefault<Videogame>();

                    if (videogameDaCancellare != null)
                    {
                        db.Remove(videogameDaCancellare);
                        db.SaveChanges();
                        Console.WriteLine("Videogioco cancellato");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return videogameDaCancellare;

        }
    }
}
    
