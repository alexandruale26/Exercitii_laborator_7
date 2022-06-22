using System;

namespace Ex_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
              Scrieti un program care va modela conturile bancare. Un cont bancar poate fi de economii sau cont curent.

                • In ambele conturi vom putea depune bani.
                    - La depunerea banilor soldul curent va crește cu valoarea depusa.

                  Din ambele conturi vom putea extrage bani.
                    - În situatia in care suma ceruta depașește soldul curent, pe ecran 
                      va fi afișat un mesaj corespunzator, iar suma extrasă va fi 0.

                • Contul de economii va oferi posibilitatea recalculării soldului astfel 
                  încât noului sold îi va fi adaugată dobânda corespunzatoare, valoarea 
                  dobânzii fiind specificată la fiecare recalculare.
            
              Creați clasele, adăugați câteva instanțe in Main, testați și rulați programul
            */
            


            ContBancar contNou = new ContBancar(Cont.Economii);
            //ContBancar contNou = new ContBancar(Cont.Curent);

            Client clientNou = new Client(contNou);
            
            BT24(clientNou);

        }

        static void BT24(Client clientNou)
        {
            bool continuaOperatieBancara = true;

            while (continuaOperatieBancara)
            {
                clientNou.OperatiuniContBancar();

                Console.WriteLine("\nApasati ENTER pentru a continua sau ESC pentru a iesi\n");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    continuaOperatieBancara = true;
                else
                    continuaOperatieBancara = false;
            }
        }
    }
}
