using System;

namespace Ex_2._1
{
    /// <summary>
    /// Modeleaza un cont de investitii de tip Cont Economii
    /// </summary>
    class ContInvestitii : ContEconomii
    {
        private DateTime urmatoareaRetragere = new DateTime();


        /// <summary>
        /// Retrage bani
        /// </summary>
        /// <param name="suma">Accepta un parametru de tip double</param>
        public override void RetrageBani(double suma)
        {
            DateTime timpCurent = DateTime.Now;
            
            if (DateTime.Compare(timpCurent, urmatoareaRetragere) < 0)
            {
                Console.WriteLine($"Nu aveti voie sa retrageti bani pana la data de :  {urmatoareaRetragere}");
                return;
            }

            if (suma < this.Sold)
            {
                this.Sold -= suma;

                urmatoareaRetragere = DateTime.Now.AddDays(30f);

                Tipareste();
            }
            else
            {
                Console.WriteLine("\nSuma ceruta depaseste soldul dumneavoastra");
                Tipareste();
            }
        }
    }
}
