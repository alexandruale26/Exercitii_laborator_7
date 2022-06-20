using System;
using System.Collections.Generic;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Scrieți un program care va modela o mână de poker.
              Mâna de poker conține 5 cărți. Cărțile vor avea valori de la 1 la 14 și vor putea fi de mai multe tipuri
                 • Inimă roșie
                 • Inimă neagră
                 • Romb
                 • Trifoi
              Creați o metoda prin intermediul căreia mâna de poker va putea fi tipărită pe ecran.
              Creați o metodă care va determina tipul mâinii de poker.
                 • Dacă toate cărțile sunt inimă neagră, vom avea un royal flush, dacă toate cărțile sunt inimă roșie, 
                   mâna va fi de tipul straight flush, iar dacă va conține 4 carți cu aceiași valoare
                   mâna va fi four of a kind. In orice altă situație, mâna va fi comună.

                 Hint: folosiți enumerații.

              În metoda  main creeati mai multe mâini de poker, tipărițile, 
              determinați-le tipul și afișați-l pe ecran.
             */


            bool continuaJoc = true;

            while (continuaJoc)
            {
                JocNou();

                Console.WriteLine("\nApasati ENTER pentru a continua sau ESC pentru a iesi din joc\n");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    continuaJoc =  true;
                else 
                    continuaJoc = false;
            }
        }


        static void JocNou()
        {
            Pachet pachetNou = new Pachet();
            Dealer dealer = new Dealer(pachetNou);

            dealer.AmestecaPachetCarti();
            
            List<Carte> manaNoua =  dealer.ImparteCarti();
            ManaPoker manaPoker = new ManaPoker(manaNoua);

            AfisareCarti(manaNoua);

            if (manaPoker.ChintaRoiala())
                Console.WriteLine("\nAveti Chinta roiala");

            else if (manaPoker.ChintaDeCuloare())
                Console.WriteLine("\nAveti Chinta de culoare");

            else if (manaPoker.Careu())
                Console.WriteLine("\nAveti Careu");

            else if (manaPoker.FullHouse())
                Console.WriteLine("\nAveti Full House");

            else if (manaPoker.Flush())
                Console.WriteLine("\nAveti Flush");

            else if (manaPoker.Chinta())
                Console.WriteLine("\nAveti Chinta");

            else if (manaPoker.TreiDeUnFel())
                Console.WriteLine("\nAveti Trei de-un fel");

            else if (manaPoker.DouaPerechi())
                Console.WriteLine("\nAveti Doua perechi");

            else if (manaPoker.OPereche())
                Console.WriteLine("\nAveti 1 pereche");

            else
                Console.WriteLine($"\nAveti cea mai mare carte {manaPoker.CeaMaiMareCarte()}");
        }

        static void AfisareCarti(List<Carte> pachet)
        {
            Console.WriteLine($"Mana ta este formata din: \n");

            foreach (Carte carte in pachet)
            {
                Console.WriteLine($"{carte.Valoare} de {carte.Simbol}");
            }
        }
    }
}
