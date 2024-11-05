using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treciauzdoutis.modelis
{
   
    public class Inzinierius : Darbuotojas
    {
        public string Specializacija { get; set; }

        public Inzinierius(int id, string vardas, string pavarde, double atlyginimas, string specializacija)
            : base(id, vardas, pavarde, atlyginimas)
        {
            Specializacija = specializacija;
        }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Specializacija: {Specializacija}");
        }
    }

}
