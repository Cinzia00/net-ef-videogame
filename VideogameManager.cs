using Microsoft.Data.SqlClient;
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
        private static string connectionString = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";

        public static bool AggiungiVideogioco(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@Name, @Overview, @Release_date, @Software_house_id);";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Name", videogame.Name));
                    cmd.Parameters.Add(new SqlParameter("@Overview", videogame.Overview));
                    cmd.Parameters.Add(new SqlParameter("@Release_date", videogame.Release_date));
                    //cmd.Parameters.Add(new SqlParameter("@Software_house_id", videogame.SoftwareHouseID));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;

            }
        }

        public static Videogame? RicercaGiocoPerId(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Videogame videogameTrovato = null;

                try
                {
                    connection.Open();

                    string query = "SELECT * FROM videogames WHERE videogames.id = " + id;

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                videogameTrovato = new Videogame(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt64(6));

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return videogameTrovato;
            }
        }

        public static List<Videogame> RicercaPerNome(string nome)
        {
            List<Videogame> videogames = new List<Videogame>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM videogames WHERE videogames.name LIKE(@Nome)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nome", "%" + nome + "%"));
                        using SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Videogame videogameTrovato = new Videogame(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt64(6));
                            videogames.Add(videogameTrovato);
                        }
                    }




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return videogames;

            }

        }
        public static bool CancellaVideogame(long idDaCancellare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM videogames WHERE @id=Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idDaCancellare));

                    int videogiocoDaCancellare = cmd.ExecuteNonQuery();

                    if (videogiocoDaCancellare > 0)
                    {
                        return true;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;

            }


        }



    }
    
}
