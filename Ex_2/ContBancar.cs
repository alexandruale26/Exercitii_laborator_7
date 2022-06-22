using System;

namespace Ex_2
{
    class ContBancar
    {
        public readonly Cont tipCont;

        private double Sold { get; set;}


        public ContBancar(Cont tipCont)
        {
            this.tipCont = tipCont;
            this.Sold = 0f;
        }   


        public void AdaugaBani (double suma)
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


        public void RetrageBani (double suma)
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


        public void RecalculareDobanda(double procentDobanda)
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


        public void Tipareste()
        {
            Console.WriteLine($"Soldul dumneavoastra este {this.Sold:N2}");
        }
    }


    enum Cont
    {
        Economii,
        Curent
    }
}
