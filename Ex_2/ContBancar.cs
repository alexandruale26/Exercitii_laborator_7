using System;
using System.Collections.Generic;

namespace Ex_2
{
    class ContBancar
    {
        private readonly Cont cont;

        private decimal Sold { get; set;}


        public ContBancar(Cont tipCont)
        {
            this.cont = tipCont;
            this.Sold = 0m;
        }   


        public void AdaugaBani (decimal suma)
        {
            this.Sold += suma;
        }


        public void RetrageBani (decimal suma)
        {
            if (suma < this.Sold)
            {
                this.Sold -= suma;
            }
            else
            {
                Console.WriteLine("\nSuma ceruta depaseste soldul dumneavoastra");
            }
        }


        public void Tipareste()
        {
            Console.WriteLine($"\nSoldul dumneavoastra este {this.Sold:N2}\n");
        }
       
    }


    enum Cont
    {
        Economii,
        ContCurent
    }
}
