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
        private IerarhiePoker ierarhie;


        /// <summary>
        /// Creeaza un pachet
        /// </summary>
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
        private void ChintaRoiala() // A K Q J 10 - acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;
            List<int> listaVerificareValori = new List<int>() { 1, 10, 11, 12, 13 };

            for (int i = 0; i < manaCarti.Count; i++)
            {
                if (listaVerificareValori.Contains(manaCarti[i].Valoare))
                {
                    if (manaCarti[i].Simbol != simbolActiv)
                    {
                        return;
                    }
                    listaVerificareValori.Remove(manaCarti[i].Valoare);

                    continue;
                }
                return;
            }
            ierarhie = IerarhiePoker.ChintaRoiala;
        }


        /// <summary>
        /// Verifica daca este Chinta de culoare
        /// </summary>
        private void ChintaDeCuloare() // 5 carti in ordine de acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;

            for (int i = 0; i < ValoriOrdonate.Length - 1; i++)
            {
                if (ValoriOrdonate[i] + 1 != ValoriOrdonate[i + 1])
                {
                    return;
                }

                if (manaCarti[i + 1].Simbol != simbolActiv)
                {
                    return;
                }
            }
            ierarhie = IerarhiePoker.ChintaDeCuloare;
        }


        /// <summary>
        /// Verifica daca este Careu
        /// </summary>
        private void Careu() // 4 carti de acelasi numar
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
                    ierarhie = IerarhiePoker.Careu;
                }
            }
        }


        /// <summary>
        /// Verifica daca este Full House
        /// </summary>
        private void FullHouse() // 3 carti de acelasi numar + o pereche
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
                ierarhie = IerarhiePoker.FullHouse;
        }


        /// <summary>
        /// Verifica daca este Flush
        /// </summary>
        private void Flush() // 5 carti oarecare cu acelasi simbol
        {
            Simbol simbolActiv = manaCarti[0].Simbol;

            for (int i = 0; i < manaCarti.Count; i++)
            {
                if (manaCarti[i].Simbol != simbolActiv)
                {
                    return;
                }
            }
            ierarhie = IerarhiePoker.Flush;
        }


        /// <summary>
        /// Verifica daca este Chinta
        /// </summary>
        private void Chinta() // 5 carti in ordine de simboluri diferite
        {
            for (int i = 0; i < ValoriOrdonate.Length - 1; i++)
            {
                if (ValoriOrdonate[i] + 1 != ValoriOrdonate[i + 1])
                {
                    return;
                }
            }
            ierarhie = IerarhiePoker.Chinta;
        }


        /// <summary>
        /// Verifica daca sunt Trei de-un fel
        /// </summary>
        private void TreiDeUnFel() // 3 carti de acelasi numar
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
                    ierarhie = IerarhiePoker.TreiDeUnFel;
                }
            }
        }


        /// <summary>
        /// Verifica daca sunt doua perechi
        /// </summary>
        private void DouaPerechi() // 2 perechi
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
                ierarhie = IerarhiePoker.DouaPerechi;
        }


        /// <summary>
        /// Verifica daca este o pereche
        /// </summary>
        private void OPereche() // o pereche
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
                    ierarhie = IerarhiePoker.OPereche;
                }
            }
        }


        /// <summary>
        /// Arata cea mai mare carte
        /// </summary>
        private void CeaMaiMareCarte() // cea mai mare carte
        {
            ierarhie = IerarhiePoker.CeaMaiMareCarte;
        }


        /// <summary>
        /// Calculeaza rezultatul
        /// </summary>
        public void CalculeazaMana()
        {
            CeaMaiMareCarte();
            OPereche();
            DouaPerechi();
            TreiDeUnFel();
            Chinta();
            Flush();
            FullHouse();
            Careu();
            ChintaDeCuloare();
            ChintaRoiala();
        }


        /// <summary>
        /// Afiseaza rezultatul
        /// </summary>
        public void AfisareRezultat()
        {
            switch (ierarhie)
            {
                case IerarhiePoker.ChintaRoiala:
                    Console.WriteLine("\nAveti Chinta roiala");
                    break;
                case IerarhiePoker.ChintaDeCuloare:
                    Console.WriteLine("\nAveti Chinta de culoare");
                    break;
                case IerarhiePoker.Careu:
                    Console.WriteLine("\nAveti Careu");
                    break;
                case IerarhiePoker.FullHouse:
                    Console.WriteLine("\nAveti Full House");
                    break;
                case IerarhiePoker.Flush:
                    Console.WriteLine("\nAveti Flush");
                    break;
                case IerarhiePoker.Chinta:
                    Console.WriteLine("\nAveti Chinta");
                    break;
                case IerarhiePoker.TreiDeUnFel:
                    Console.WriteLine("\nAveti Trei de-un fel");
                    break;
                case IerarhiePoker.DouaPerechi:
                    Console.WriteLine("\nAveti Doua perechi");
                    break;
                case IerarhiePoker.OPereche:
                    Console.WriteLine("\nAveti 1 pereche");
                    break;
                case IerarhiePoker.CeaMaiMareCarte:
                    Console.WriteLine($"\nAveti cea mai mare carte {ValoriOrdonate[^1]}");
                    break;
            }
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
        CeaMaiMareCarte // cea mai mare carte 
    }
}
