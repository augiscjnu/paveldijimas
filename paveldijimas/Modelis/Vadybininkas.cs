using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paveldijimas.Modelis
{
    public class Vadybininkas : Darbuotojas
    {
       public Vadybininkas(string vardas, long asmensKodas, double bazinisAtlyginimas)
                : base(vardas, asmensKodas, bazinisAtlyginimas)
       {
      }

        public override double SkaiciuotiAtlyginima() => BazinisAtlyginimas * 1.10; 


    }
}
