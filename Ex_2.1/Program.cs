using System;

namespace Ex_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Contul de investiții este un cont bancar care se comportă precum un cont de
             economii, cu mențiunea că nu vor putea fi extrași bani decât în situația 
             în care termenul extragerii a fost atins.

            Dacă se incearcă extragerea banilor înainte de termen, contul va afișa un mesaj corespunzător iar suma extrasă va fi 0.

            Contul de investiții va pune la dispoziție o modalitate prin care se va putea
            specifica dacă termenul de extragere a fost sau nu atins.
            
            Creați clasele, adăugați câteva instanțe in Main, testați și rulați programul
            */


            //ContCurent contNou = new ContCurent(Cont.Curent);
            //ContEconomii contNou = new ContEconomii(Cont.Economii);
            ContInvestitii contNou = new ContInvestitii(Cont.Investitii);

            Bancomat bancomat = new Bancomat(contNou);

            BT24(bancomat);
        }

        static void BT24(Bancomat bancomat)
        {
            bool continuaOperatieBancara = true;

            while (continuaOperatieBancara)
            {
                bancomat.OperatiuniContBancar();

                Console.WriteLine("\nApasati ENTER pentru a continua sau ESC pentru a iesi\n");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    continuaOperatieBancara = true;
                else
                    continuaOperatieBancara = false;
            }
        }
    }
}
