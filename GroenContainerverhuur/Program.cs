using System;

namespace GroenContainerverhuur
{
    class Program
    {
        static Double berekenHuurbedrag(int aantaldagen, bool kleinebak, bool vasteklant, int aantalgeleegd, int containergrootte)
        {
            Double huur = 0.0;
            huur = 40 * containergrootte * aantaldagen;
            if (kleinebak)
            {
                huur = huur + (aantalgeleegd * 60);
            }
            else if (!kleinebak)
            {
                huur = huur + (aantalgeleegd * 125);
            }
            if (vasteklant)
            {
                huur = huur * 0.85;
            }
            return huur;
        }

        static void Main(string[] args)
        {
            DateTime begindatum;
            DateTime einddatum;
            int aantaldagen = 0;
            int aantalgeleegd = 0;
            int containergrootte = 0;
            bool vasteklant = false;
            bool kleinebak = false;
            String invoer = "";

            Console.WriteLine("Containerverhuur.");
            Console.WriteLine("Geef begindatum verhuur container in formaat jjjj/mm/dd:");
            begindatum = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Geef einddatum verhuur container in formaat jjjj/mm/dd:");
            einddatum = DateTime.Parse(Console.ReadLine());
            if (DateTime.Compare(einddatum, begindatum) < 0)
            {
                Console.WriteLine("Einddatum moet na begindatum komen.");
                Environment.Exit(0);
            }

            if (begindatum.Year != einddatum.Year)
            {
                Console.WriteLine("Verhuur moet plaatsvinden in hetzelfde kalenderjaar!");
                Environment.Exit(0);
            }
            Console.WriteLine("Geef de grootte van de bak in gehele kubieke meters: ");
            containergrootte = int.Parse(Console.ReadLine());
            if (containergrootte == 0)
            {
                Console.WriteLine("Zulke kleine bakken hebben we niet!!");
                Environment.Exit(0);
            }
            if ((containergrootte == 1) || (containergrootte == 2))
            {
                kleinebak = true;
            }
            Console.WriteLine("Is de klant een vaste klant? (ja of nee) ");
            invoer = Console.ReadLine();
            if (invoer == "ja")
            {
                vasteklant = true;
            }
            Console.WriteLine("Hoe vaak is de bak geleegd? ");
            aantalgeleegd = int.Parse(Console.ReadLine());

            TimeSpan td = einddatum - begindatum;
            aantaldagen = (int)td.TotalDays;
            Console.WriteLine("Het totaal verschuldigde huurbedrag is: {0}", berekenHuurbedrag(aantaldagen, kleinebak, vasteklant, aantalgeleegd, containergrootte));
        }
    }
}
