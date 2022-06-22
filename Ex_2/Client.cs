using System;

namespace Ex_2
{
    class Client
    {
        private readonly ContBancar contBancar;

        public Client(ContBancar contBancar)
        {
            this.contBancar = contBancar;
        }


        public void OperatiuniContBancar()
        {
            if (contBancar.tipCont == Cont.Curent)
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
                    contBancar.Tipareste();
                    break;
                case 2:
                    Console.WriteLine("\nIntroduceti suma");
                    contBancar.AdaugaBani(double.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("\nIntroduceti suma");
                    contBancar.RetrageBani(double.Parse(Console.ReadLine()));
                    break;

                case 4:
                    if (contBancar.tipCont == Cont.Economii)
                    {
                        Console.WriteLine("\nIntroduceti procentul");
                        contBancar.RecalculareDobanda(double.Parse(Console.ReadLine()));
                    }
                    break;
            }
        }
    }
}
