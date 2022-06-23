using System;

namespace Ex_2
{
    /// <summary>
    /// Modeleaza un cont bancar
    /// </summary>
    class ContBancar
    {
        public readonly Cont tipCont;
        private double Sold { get; set;}


        /// <summary>
        /// Creeaza un cont bancar
        /// </summary>
        /// <param name="tipCont">Accepta un parametru de tip Cont</param>
        public ContBancar(Cont tipCont)
        {
            this.tipCont = tipCont;
            this.Sold = 0f;
        }


        /// <summary>
        /// Adauga bani si afiseaza soldul
        /// </summary>
        /// <param name="suma">Accepta un parametru de tip double</param>
        private void AdaugaBani (double suma)
        {
            if (suma > 0)
            {
                this.Sold += suma;
                Tipareste();
            }
            else
            {
                Console.WriteLine("Suma nu poate fi mai mica decat 0");
            }
        }


        /// <summary>
        /// Retrage bani si afiseaza soldul
        /// </summary>
        /// <param name="suma">Accepta un parametru de tip double</param>
        private void RetrageBani (double suma)
        {
            if (suma < this.Sold)
            {
                this.Sold -= suma;
                Tipareste();

            }
            else
            {
                Console.WriteLine("\nSuma ceruta depaseste soldul dumneavoastra");
                Tipareste();
            }
        }


        /// <summary>
        /// Recalculeaza dobanda si afiseaza soldul
        /// </summary>
        /// <param name="procentDobanda">Accepta un parametru de tip double</param>
        private void RecalculareDobanda(double procentDobanda)
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


        /// <summary>
        /// Afiseaza soldul
        /// </summary>
        private void Tipareste()
        {
            Console.WriteLine($"Soldul dumneavoastra este {this.Sold:N2}");
        }


        /// <summary>
        /// Efectueaza operatiuni
        /// </summary>
        public void OperatiuniContBancar()
        {
            if (tipCont == Cont.Curent)
            {
                Console.WriteLine("1 afisare Sold | 2 Adauga bani " +
               "| 3 Retrage bani");
            }
            else
            {
                Console.WriteLine("1 Afisare sold | 2 Adauga bani " +
               "| 3 Retrage bani | 4 Recalculare dobanda");
            }

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
                    if (tipCont == Cont.Economii)
                    {
                        Console.WriteLine("\nIntroduceti procentul");
                        RecalculareDobanda(double.Parse(Console.ReadLine()));
                    }
                    break;
            }
        }
    }


    enum Cont
    {
        Economii,
        Curent
    }
}
