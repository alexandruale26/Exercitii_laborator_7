using System.Collections.Generic;

namespace Ex_1
{
    class ManaPoker
    {
        private readonly List<Carte> manaCarti;

        public ManaPoker(List<Carte> manaCarti)
        {
            this.manaCarti = manaCarti;
        }


        public bool ChintaRoiala() // A K Q J 10 - acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                int nr = manaCarti[i].Valoare;

                if (nr != 1 || nr != 10 || nr != 11 || nr != 12 || nr != 13)
                {
                    return false;
                }

                if (manaCarti[i].Simbol != simbolActiv)
                {
                    return false;
                }
            }
            return true;
        }


        public bool ChintaDeCuloare() // 5 carti in ordine de acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;

            for (int i = 0; i < manaCarti.Count - 1; i++)
            {
                if (manaCarti[i].Valoare + 1 != manaCarti[i + 1].Valoare)
                {
                    return false;
                }

                if (manaCarti[i + 1].Simbol != simbolActiv)
                {
                    return false;
                }
            }
            return true;
        }


        public bool Careu() // 4 carti de acelasi numar
        {
            int contorCurent;
            int contorAnterior = 0;

            for (int i = 0; i < 2; i++)
            {
                contorCurent = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contorCurent++;
                }

                if (contorCurent >= contorAnterior)
                { 
                    contorAnterior = contorCurent; 
                }
            }

            if (contorAnterior >= 4)
                return true;
            else 
                return false;
        }


        public bool FullHouse() // 3 carti de acelasi numar + o pereche
        {

        }

    }

    enum IerarhiePoker
    {
        ChintaRoiala, // A K Q J 10 - acelasi simbol
        ChintaDeCuloare, // 5 carti in ordine de acelasi simbol
        Careu, // 4 carti de acelasi numar
        FullHouse, // 3 carti de acelasi numar + o pereche
        Flush, // 5 carti oarecare cu acelasi simbol
        Chinta, // 5 carti consecutive de simboluri diferite
        TreiDeUnFel, // 3 carti de acelasi numar
        DouaPerechi, // 2 perechi
        OPereche, // o pereche
        CarteMare // cea mai mare carte
    }
}
