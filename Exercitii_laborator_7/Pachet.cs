using System;
using System.Collections.Generic;

namespace Ex_1
{
    class Pachet
    {
        public List<Carte> Carti { get; set; }

        public Pachet()
        {
            this.Carti = GenerarePachet();
        }

        private List<Carte> GenerarePachet()
        {
            List<Carte> pachetNou = new List<Carte>();

            int numaraCarti = 0;
            int contorSimboluri = Enum.GetNames(typeof(Simbol)).Length;

            for (int i = 0; i < contorSimboluri; i++)
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
