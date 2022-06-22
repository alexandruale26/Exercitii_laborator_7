using System;

namespace Ex_1
{
    /// <summary>
    /// Modeleaza o carte
    /// </summary>
    class Carte
    {
        public int Valoare { get; private set; }
        public Simbol Simbol { get; private set; }
     
        /// <summary>
        /// Creeaza o carte
        /// </summary>
        /// <param name="valoare">parametru de tip int</param>
        /// <param name="simbol">parametru de tip simbol</param>
        public Carte(int valoare, Simbol simbol)
        {
            this.Valoare = valoare;
            this.Simbol = simbol;
        }
    }


    enum Simbol
    {
        Inima_Rosie,
        Inima_Neagra,
        Romb,
        Trifoi
    }

}
