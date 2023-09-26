using net_ef_videogame.Database;
using net_ef_videogame.Models;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isProgramRunning = true;


            while (isProgramRunning)
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
                        Console.WriteLine("Inserisci nome videogame");
                        string nomeVideogioco = Console.ReadLine();

                        Console.WriteLine("Inserisci descrizione videogame");
                        string descrizione = Console.ReadLine();

                        Console.WriteLine("Inserisci id software_house");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Inserisci data");
                        string data = Console.ReadLine();
                        DateTime dataUtente = DateTime.Parse(data);

                        Console.WriteLine("Inserisci id videogioco");
                        int idVideogame = int.Parse(Console.ReadLine());


                        Videogame nuovoVideogame = new Videogame(idVideogame, nomeVideogioco, descrizione, dataUtente, id);

                        VideogameManager.AggiungiVideogioco(nuovoVideogame);


                        break;

                    case 2:
                        Console.WriteLine("Inserisci id videogioco");
                        int videogameId = int.Parse(Console.ReadLine());

                        Videogame videogameTrovato = VideogameManager.RicercaGiocoPerId(videogameId);
                        if(videogameTrovato != null)
                        {
                            Console.WriteLine(videogameTrovato);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Inserisci nome videogioco");
                        string nomeVideogame = Console.ReadLine();

                        List<Videogame> videogiochi = VideogameManager.RicercaPerNome(nomeVideogame);
                        foreach(Videogame videogioco in videogiochi)
                        {
                            Console.WriteLine(videogioco);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Inserisci id videogioco da camcellare");
                        int idVideogameDaCancellare = int.Parse(Console.ReadLine());

                        VideogameManager.CancellaVideogame(idVideogameDaCancellare);
                        break;
                    case 5:
                        isProgramRunning = false;
                        Console.WriteLine("Programma chiuso!");
                        break;
                }

            }


        }
    }
}