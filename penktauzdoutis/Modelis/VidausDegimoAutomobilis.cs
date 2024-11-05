using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penktauzdoutis.Modelis
{
    public class VidausDegimoAutomobilis : Automobilis
    {
        public string KuroTipas { get; set; }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Kuro Tipas: {KuroTipas}");
        }
    }
}
