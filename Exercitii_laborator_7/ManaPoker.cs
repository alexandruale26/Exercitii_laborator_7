﻿using System;
using System.Collections.Generic;

namespace Ex_1
{
    class ManaPoker
    {
        private readonly List<Carte> manaCarti;

        private int[] ValoriOrdonate { get; set; }

        public ManaPoker(List<Carte> manaCarti)
        {
            this.manaCarti = manaCarti;
            this.ValoriOrdonate = OrdoneazaValoriCarti();
        }


        private int[] OrdoneazaValoriCarti()
        {
            int[] valoriOrdonate = new int[manaCarti.Count];

            for (int i = 0; i < manaCarti.Count; i++)
            {
                valoriOrdonate[i] = manaCarti[i].Valoare;
            }

            Array.Sort(valoriOrdonate);
            return valoriOrdonate;
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

            for (int i = 0; i < ValoriOrdonate.Length - 1; i++)
            {
                if (ValoriOrdonate[i] + 1 != ValoriOrdonate[i + 1])
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
            int contor;

            for (int i = 0; i < 2; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contor++;
                }

                if (contor >= 4)
                {
                    return true;
                }
            }
            return false;
        }


        public bool FullHouse() // 3 carti de acelasi numar + o pereche
        {
            int contor;
            int treiCarti = 0;
            int douaCarti = 0;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contor++;
                }

                if (contor == 3)
                {
                    treiCarti = 3;
                }
                else if (contor == 2)
                {
                    douaCarti = 2;
                }
            }

            if (treiCarti == 3 && douaCarti == 2)
                return true;
            else
                return false;
        }


        public bool Flush() // 5 carti oarecare cu acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                if (manaCarti[i].Simbol != simbolActiv)
                {
                    return false;
                }
            }
            return true;
        }


        public bool Chinta() // 5 carti in ordine de simboluri diferite
        {
            for (int i = 0; i < ValoriOrdonate.Length - 1; i++)
            {
                if (ValoriOrdonate[i] + 1 != ValoriOrdonate[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


        public bool TreiDeUnFel() // 3 carti de acelasi numar
        {
            int contorCurent;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contorCurent = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contorCurent++;
                }

                if (contorCurent == 3)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DouaPerechi() // 2 perechi
        {
            int contor;
            int perecheaUnu = -1;
            int perecheaDoi = 0;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contor++;
                }

                if (contor == 2 && perecheaUnu < 2)
                {
                    perecheaUnu = 2;
                    continue;
                }
                else if (contor == 2)
                {
                    perecheaDoi = 2;
                }
            }

            if (perecheaUnu == perecheaDoi)
                return true;
            else
                return false;
        }


        public bool OPereche() // o pereche
        {
            int contor;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i] == manaCarti[j])
                        contor++;
                }

                if (contor == 2)
                {
                    return true;
                }
            }
            return false;
        }


        public int CarteMare() // cea mai mare carte
        {
            return ValoriOrdonate[ValoriOrdonate.Length-1];
        }
    }

    enum IerarhiePoker
    {
        ChintaRoiala, // A K Q J 10 - acelasi simbol
        ChintaDeCuloare, // 5 carti in ordine de acelasi simbol
        Careu, // 4 carti de acelasi numar
        FullHouse, // 3 carti de acelasi numar + o pereche
        Flush, // 5 carti oarecare cu acelasi simbol
        Chinta, // 5 carti in ordine de simboluri diferite
        TreiDeUnFel, // 3 carti de acelasi numar
        DouaPerechi, // 2 perechi
        OPereche, // o pereche
        CarteMare // cea mai mare carte
    }
}
