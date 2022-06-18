using System;

namespace Ex_1
{
    class Carte
    {
        public int Valoare { get; private set; }
        public Simbol Simbol { get; private set; }
     

        public Carte(int valoare, Simbol simbol)
        {
            this.Valoare = valoare;
            this.Simbol = simbol;
        }
    }


    enum Simbol
    {
        InimaRosie,
        InimaNeagra,
        Romb,
        Trifoi
    }

}
