using System;

namespace Ex_2._1
{
    /// <summary>
    /// Modeleaza un cont curent
    /// </summary>
    class ContCurent
    {
        public double Sold { get; set; }


        /// <summary>
        /// Creeaza un cont curent
        /// </summary>
        public ContCurent()
        {
            this.Sold = 0f;
        }


        /// <summary>
        /// Mareste soldul
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
        /// Retrage bani
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
        /// Recalculeaza dobanda
        /// </summary>
        /// <param name="procentDobanda">Accepta un parametru de tip double</param>
        public virtual void RecalculareDobanda(double procentDobanda) { }


        /// <summary>
        /// Efectueaza operatiuni bancare
        /// </summary>
        public virtual void OperatiuniContBancar()
        {
            Console.WriteLine("1 afisare Sold | 2 Adauga bani | 3 Retrage bani");
            
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
            }
        }


        /// <summary>
        /// Afiseaza soldul
        /// </summary>
        public void Tipareste()
        {
            Console.WriteLine($"Soldul dumneavoastra este {this.Sold:N2}");
        }
    }
}
