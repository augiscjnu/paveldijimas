using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using treciauzdoutis.modelis;

namespace treciauzdoutis
{ 
public class DarbuotojuRepository
    {
        public List<Darbuotojas> NuskaytiDarbuotojusIsFailo(string failoKelias)
        {
            List<Darbuotojas> darbuotojai = new List<Darbuotojas>();

            foreach (var eilute in File.ReadLines(failoKelias))
            {
                var dalys = eilute.Split(';');
                int id = int.Parse(dalys[0]);
                string vardas = dalys[1];
                string pavarde = dalys[2];
                double atlyginimas = double.Parse(dalys[3]);
                string tipas = dalys[4];
                string papildomaInformacija = dalys[5];

                if (tipas == "Vadybininkas")
                {
                    darbuotojai.Add(new Vadybininkas(id, vardas, pavarde, atlyginimas, papildomaInformacija));
                }
                else if (tipas == "Inzinierius")
                {
                    darbuotojai.Add(new Inzinierius(id, vardas, pavarde, atlyginimas, papildomaInformacija));
                }
            }

            return darbuotojai;
        }
    }

}
