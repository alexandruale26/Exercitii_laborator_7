using System;
using System.Collections.Generic;

namespace Ex_1
{
    /// <summary>
    /// Modeleaza un pachet
    /// </summary>
    class Pachet
    {
        public List<Carte> Carti { get; set; }

        /// <summary>
        /// Creeaza un pachet
        /// </summary>
        public Pachet()
        {
            this.Carti = GenerarePachet();
        }


        /// <summary>
        /// Genereaza un pachet de carti
        /// </summary>
        /// <returns>Returneaza o lista de carti</returns>
        private List<Carte> GenerarePachet()
        {
            List<Carte> pachetNou = new List<Carte>();

            int numaraCarti = 0;

            for (int i = 0; i < Enum.GetNames(typeof(Simbol)).Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if ( numaraCarti < 52)
                    {
                        pachetNou.Add(new Carte(j + 1, (Simbol)i));
                        numaraCarti++;
                    }
                }
            }
            return pachetNou;
        }
    }
}
