using net_ef_videogame.Database;
using net_ef_videogame.Models;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {



            while (true)
            {
                Console.WriteLine(@"
1-Inserire un nuovo videogioco
2-Ricerca videogioco per id
3-Ricercare tutti i videogiochi per nome
4-Cancellare un videogioco
5-Chiudere il programma"
                );

                Console.WriteLine();
                Console.WriteLine("Scegli un opzione");

                int opzioneSelezionata = int.Parse(Console.ReadLine());

                switch (opzioneSelezionata)
                {
                    case 1:
                        using (VideogamesContext db = new VideogamesContext())
                        {

                        Console.WriteLine("Inserisci nome videogame");
                        string nomeVideogioco = Console.ReadLine();

                        Console.WriteLine("Inserisci descrizione videogame");
                        string descrizione = Console.ReadLine();

                        Console.WriteLine("Inserisci id software_house");
                        int id = int.Parse(Console.ReadLine());


                        Videogame nuovoVideogame = new Videogame()
                        {
                            Name = nomeVideogioco,
                            Overview = descrizione,
                            Software_houseId=id
                        };


                            try
                            {
                                db.Add(nuovoVideogame);
                                db.SaveChanges();

                                Console.WriteLine("Videogioco aggiunto con successo!");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }


                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        break;

                }

            }


        }
    }
}