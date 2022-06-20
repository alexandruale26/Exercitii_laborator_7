using System;
using System.Collections.Generic;

namespace Ex_1
{
    class Dealer
    {
        public Pachet Pachet { get; private set; }

        public Dealer(Pachet pachet)
        {
            this.Pachet = pachet;
        }


        public void AmestecaPachetCarti()
        {
            List<Carte> pachetAmestecat = new List<Carte>();

            pachetAmestecat.AddRange(Pachet.Carti);

            Random rand = new Random();

            for (int i = 0; i < pachetAmestecat.Count; i++)
            {
                int aleator = rand.Next(i, pachetAmestecat.Count);
                Carte carteTemp = pachetAmestecat[i];
                pachetAmestecat[i] = pachetAmestecat[aleator];
                pachetAmestecat[aleator] = carteTemp;
            }

            Pachet.Carti = pachetAmestecat;
        }


        public List<Carte> ImparteCarti()
        {
            List<Carte> cartiImpartite = new List<Carte>();

            int contor = 0;
            Random rand = new Random();

            for (int i = rand.Next(Pachet.Carti.Count - 1); i < Pachet.Carti.Count; i = rand.Next(Pachet.Carti.Count - 1))
            {
                if (!(contor < 5))
                    break;

                if (!cartiImpartite.Contains(Pachet.Carti[i]))
                {
                    cartiImpartite.Add(Pachet.Carti[i]);
                    contor++;
                }
            }

            return cartiImpartite;

        }
    }
}
