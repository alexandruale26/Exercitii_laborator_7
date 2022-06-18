
namespace Ex_1
{
    class ManaPoker
    {
        private readonly Carte[] manaCarti;
        public IerarhiePoker rezultat;


        public ManaPoker(Carte[] manaCarti)
        {
            this.manaCarti = manaCarti;
        }

        public void ChintaDeCuloare()
        {
            bool suntInOrdine = false;
            bool auAceeasiCuloare = false;

            int valoareAnterioara;
            int valoareCurenta = manaCarti[0].Valoare;

            Simbol culoareCurenta = manaCarti[0].Simbol;


            foreach (Carte carte in manaCarti)
            {
                valoareAnterioara = valoareCurenta;
                valoareCurenta = carte.Valoare;

                if (valoareAnterioara + 1  == valoareCurenta)
                {
                    suntInOrdine = true;
                    break;
                }
                else
                    suntInOrdine = true;


                if (carte.Simbol == Simbol.InimaNeagra || carte.Simbol == Simbol.Trifoi && culoareCurenta == Simbol.InimaNeagra || culoareCurenta == Simbol.Trifoi)
                {
                    auAceeasiCuloare = true;
                }
                else if (carte.Simbol == Simbol.InimaRosie || carte.Simbol == Simbol.Romb && culoareCurenta == Simbol.InimaRosie || culoareCurenta == Simbol.Romb)
                {
                    auAceeasiCuloare = true;
                }
                else
                {
                    auAceeasiCuloare = false;
                    break;
                }
            }

            if (suntInOrdine && auAceeasiCuloare)
                this.rezultat = IerarhiePoker.ChintaDeCuloare;

        }

        public void Careu()
        {
            int contorCurent = 0;
            int contorAnterior = 0;

            for (int i = 0; i < manaCarti.Length; i++)
            {
                for (int j = 0; j < manaCarti.Length; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contorCurent++;
                }

                if (contorCurent >= contorAnterior)
                    contorAnterior = contorCurent;
            }

            if (contorAnterior >= 4)
                rezultat = IerarhiePoker.Careu;
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
