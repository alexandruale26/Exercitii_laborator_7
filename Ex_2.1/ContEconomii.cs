using System;

namespace Ex_2._1
{
    /// <summary>
    /// Modeleaza un cont de economii de tip Cont Curent
    /// </summary>
    class ContEconomii : ContCurent
    {
        /// <summary>
        /// Efectueaza operatiuni bancare
        /// </summary>
        public override void OperatiuniContBancar()
        {
            Console.WriteLine("1 Afisare sold | 2 Adauga bani | 3 Retrage bani | 4 Recalculare dobanda");

            int operatiune = int.Parse(Console.ReadLine());

            switch (operatiune)
            {
                case 1:
                    Tipareste();
                    break;
                case 2:
                    Console.WriteLine("\nIntroduceti suma");
                    AdaugaBani(double.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("\nIntroduceti suma");
                    RetrageBani(double.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.WriteLine("\nIntroduceti procentul");
                    RecalculareDobanda(double.Parse(Console.ReadLine()));
                    break;
            }
        }


        /// <summary>
        /// Recalculeaza dobanda
        /// </summary>
        /// <param name="procentDobanda">Accepta un parametru de tip double</param>
        public override void RecalculareDobanda(double procentDobanda)
        {
            if (this.Sold != 0)
            {
                double dobanda = (this.Sold * procentDobanda) / 100;

                Console.WriteLine($"\nNoua dobanda este: {dobanda:N2}");
                this.Sold += dobanda;

                Tipareste();
            }
            else
            {
                Console.WriteLine("Soldul este 0. Nu se poate recalcula dobanda");
            }
        }
    }
}
