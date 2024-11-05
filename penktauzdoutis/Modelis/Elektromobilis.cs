using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penktauzdoutis.Modelis
{
    public class ElektrinisAutomobilis : Automobilis
    {
        public double BaterijosTalpa { get; set; }
        public int Nuotolis { get; set; }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Baterijos Talpa: {BaterijosTalpa} kWh, Nuotolis: {Nuotolis} km");
        }
    }
}
