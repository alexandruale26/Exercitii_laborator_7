using System;

namespace Ex_2._1
{
    /// <summary>
    /// Modeleaza un cont curent
    /// </summary>
    class ContCurent
    {
        public double Sold { get; set; }
        public Cont Cont { get; private set; }


        /// <summary>
        /// Creeaza un cont curent
        /// </summary>
        public ContCurent(Cont cont)
        {
            this.Sold = 0f;
            this.Cont = cont;
        }


        /// <summary>
        /// Adauga bani si afiseaza soldul
        /// </summary>
        /// <param name="suma">Accepta un parametru de tip double</param>
        public void AdaugaBani(double suma)
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
        public virtual void RetrageBani(double suma)
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
        public virtual void RecalculareDobanda(double procentDobanda) { }


        /// <summary>
        /// Afiseaza soldul
        /// </summary>
        public void Tipareste()
        {
            Console.WriteLine($"Soldul dumneavoastra este {this.Sold:N2}");
        }
    }


    enum Cont
    {
        Curent,
        Economii,
        Investitii
    }
}
