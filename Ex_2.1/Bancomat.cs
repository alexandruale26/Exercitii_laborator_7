using System;

namespace Ex_2._1
{
    class Bancomat
    {
        private readonly ContCurent contBancar;

        /// <summary>
        /// Creeaza un bancomat
        /// </summary>
        /// <param name="contBancar">Accepta un parametru de tip ContBancar</param>
        public Bancomat (ContCurent contBancar)
        {
            this.contBancar = contBancar;
        }


        /// <summary>
        /// Efectueaza operatiuni bancare
        /// </summary>
        public void OperatiuniContBancar()
        {
            if (contBancar.Cont == Cont.Curent)
            {
                Console.WriteLine("1 Afisare sold | 2 Adauga bani | 3 Retrage bani");
            }
            else
            {
                Console.WriteLine("1 Afisare sold | 2 Adauga bani | 3 Retrage bani | 4 Recalculare dobanda");
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
                    if (contBancar.Cont == Cont.Economii || contBancar.Cont == Cont.Investitii)
                    {
                        Console.WriteLine("\nIntroduceti procentul");
                        contBancar.RecalculareDobanda(double.Parse(Console.ReadLine()));
                    }
                    break;
            }
        }
    }
}
