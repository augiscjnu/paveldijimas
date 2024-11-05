using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penktauzdoutis.Modelis
{
    public class Automobilis
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int Metai { get; set; }
        public double Kaina { get; set; }





        public virtual void SpausdintiInformacija()
        {
            Console.WriteLine($"ID: {Id}, Marke: {Marke}, Modelis: {Modelis}, Metai: {Metai}, Kaina: {Kaina} Eur");
        }
    }
}


