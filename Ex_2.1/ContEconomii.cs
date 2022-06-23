using System;

namespace Ex_2._1
{
    /// <summary>
    /// Modeleaza un cont de economii de tip Cont Curent
    /// </summary>
    class ContEconomii : ContCurent
    {
        public ContEconomii(Cont cont) : base(cont) { }

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
