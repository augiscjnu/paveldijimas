using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treciauzdoutis.modelis
{
   
    public class Vadybininkas : Darbuotojas
    {
        public string Skyrius { get; set; }

        public Vadybininkas(int id, string vardas, string pavarde, double atlyginimas, string skyrius)
            : base(id, vardas, pavarde, atlyginimas)
        {
            Skyrius = skyrius;
        }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Skyrius: {Skyrius}");
        }
    }

}
