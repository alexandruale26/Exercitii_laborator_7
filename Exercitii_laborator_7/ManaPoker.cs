using System;
using System.Collections.Generic;

namespace Ex_1
{
    /// <summary>
    /// Modeleaza o mana de poker
    /// </summary>
    class ManaPoker
    {
        private readonly List<Carte> manaCarti;
        private int[] ValoriOrdonate { get; set; }

        /// <summary>
        /// Creeaza un pachet
        /// </summary>
        /// <param name="manaCarti"> returneaza o lista de carti</param>
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


        /// <summary>
        /// Verifica daca este Chinta roiala
        /// </summary>
        /// <returns>Returneaza un bool</returns>
        public bool ChintaRoiala() // A K Q J 10 - acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;
            List<int> listaVerificareValori = new List<int>() { 1, 10, 11, 12, 13 };

            for (int i = 0; i < manaCarti.Count; i++)
            {
                if (listaVerificareValori.Contains(manaCarti[i].Valoare))
                {
                    if (manaCarti[i].Simbol != simbolActiv)
                    {
                        return false;
                    }
                    listaVerificareValori.Remove(manaCarti[i].Valoare);

                    continue;
                }
                return false;
            }
            return true;
        }


        /// <summary>
        /// Verifica daca este Chinta de culoare
        /// </summary>
        /// <returns>Returneaza un bool</returns>
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


        /// <summary>
        /// Verifica daca este Careu
        /// </summary>
        /// <returns>Returneaza un bool</returns>
        public bool Careu() // 4 carti de acelasi numar
        {
            int contor;

            for (int i = 0; i < 2; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i].Valoare == manaCarti[j].Valoare)
                        contor++;
                }

                if (contor >= 4)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Verifica daca este Full House
        /// </summary>
        /// <returns>Returneaza un bool</returns>
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
                    if (manaCarti[i].Valoare == manaCarti[j].Valoare)
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


        /// <summary>
        /// Verifica daca este Flush
        /// </summary>
        /// <returns>Returneaza un bool</returns>
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


        /// <summary>
        /// Verifica daca este Chinta
        /// </summary>
        /// <returns>Returneaza un bool</returns>
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


        /// <summary>
        /// Verifica daca sunt Trei de-un fel
        /// </summary>
        /// <returns>Returneaza un bool</returns>
        public bool TreiDeUnFel() // 3 carti de acelasi numar
        {
            int contorCurent;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contorCurent = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i].Valoare == manaCarti[j].Valoare)
                        contorCurent++;
                }

                if (contorCurent == 3)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Verifica daca sunt doua perechi
        /// </summary>
        /// <returns>Returneaza un bool</returns>
        public bool DouaPerechi() // 2 perechi
        {
            int contor;
            int valoarePerecheAnterioara = 0;
            int perecheaUnu = -1;
            int perecheaDoi = 0;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i].Valoare == manaCarti[j].Valoare && manaCarti[i].Valoare != valoarePerecheAnterioara)
                        contor++;
                }

                if (contor >= 2 && perecheaUnu < 2)
                {
                    perecheaUnu = 2;
                    valoarePerecheAnterioara = manaCarti[i].Valoare;
                    continue;
                }
                else if (contor >= 2)
                {
                    perecheaDoi = 2;
                }
            }

            if (perecheaUnu == perecheaDoi)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Verifica daca este o pereche
        /// </summary>
        /// <returns>Returneaza un bool</returns>
        public bool OPereche() // o pereche
        {
            int contor;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                contor = 0;

                for (int j = 0; j < manaCarti.Count; j++)
                {
                    if (manaCarti[i].Valoare == manaCarti[j].Valoare)
                        contor++;
                }

                if (contor >= 2)
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// Arata cea mai mare carte
        /// </summary>
        /// <returns>Returneaza cea mai mare valoare</returns>
        public int CeaMaiMareCarte() // cea mai mare carte
        {
            return ValoriOrdonate[^1];
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
