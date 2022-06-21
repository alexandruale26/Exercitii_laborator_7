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
            Console.WriteLine("Introduceti 1 pentru afisare Sold\nIntroduceti 2 pentru a adauga bani\n" +
               "Introduceti 3 pentru a retrage bani\n");

            int operatie = int.Parse(Console.ReadLine());

            switch (operatie)
            {
                case 1:
                    contBancar.Tipareste();
                    break;
                case 2:
                    Console.WriteLine("Introduceti suma\n");
                    contBancar.AdaugaBani(decimal.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Introduceti suma\n");
                    contBancar.RetrageBani(decimal.Parse(Console.ReadLine()));
                    break;
            }
        }
    }
}
