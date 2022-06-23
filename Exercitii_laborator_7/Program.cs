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

            manaPoker.CalculeazaMana();
            manaPoker.AfisareRezultat();
            
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
