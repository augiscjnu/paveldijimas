using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrauzdoutis.Modelis
{
 
    public class TransportoPriemone
    {
        public string Pavadinimas { get; set; }
        public double KuroSanaudos100km { get; set; }

        public TransportoPriemone(string pavadinimas, double kuroSanaudos100km)
        {
            Pavadinimas = pavadinimas;
            KuroSanaudos100km = kuroSanaudos100km;
        }

        public virtual double ApskaiciuotiKuroSanaudas(int kelias)
        {
            return (KuroSanaudos100km * kelias) / 100;
        }
    }

}
