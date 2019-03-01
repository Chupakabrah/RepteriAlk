using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepteriAlkalmazas
{
    class JaratKezelo
    {
        class Jarat
        {
            public string jarat { get; set; }
            public string repterHonnan { get; set; }
            public string repterHova { get; set; }
            public DateTime indulas { get; set; }
            public int keses { get; set; }

            public Jarat(string jarat, string repterHonnan, string repterHova, DateTime indulas, int keses = 0)
            {
                this.jarat = jarat;
                this.repterHonnan = repterHonnan;
                this.repterHova = repterHova;
                this.indulas = indulas;
                this.keses = keses;
            }
        }

        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            var ujJarat = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);

            foreach (var ismetles in jaratok)
            {
                if (ismetles.jarat.Equals(ujJarat.jarat))
                {
                    throw new ArgumentException();

                }
            }
            jaratok.Add(ujJarat);
        }

        public void Keses(string jaratSzam, int keses)
        {
            foreach (var keslekedes in jaratok)
            {
                if (keslekedes.jarat.Equals(jaratSzam))
                {
                    keslekedes.keses += keses;
                    if (keslekedes.keses < 0)
                    {
                        throw new NegativKesesException(jaratSzam);
                    }
                }
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            foreach (var indulas in jaratok)
            {
                if (indulas.jarat.Equals(jaratSzam))
                {
                    indulas.indulas.AddMinutes(indulas.keses);
                    return indulas.indulas;
                }
            }
            throw new ArgumentException();
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> repterJaratai = new List<string>();

            foreach (var repuloter in jaratok)
            {
                if (repuloter.repterHonnan.Equals(repter))
                {
                    repterJaratai.Add(repuloter.jarat);
                }
            }

            if (repterJaratai.Count > 0)
            {
                return repterJaratai;
            }
            else
            {
                throw new ArgumentException();
            }

        }


    }
}
