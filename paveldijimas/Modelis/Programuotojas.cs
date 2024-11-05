using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paveldijimas.Modelis
{
    
    public class Programuotojas : Darbuotojas
    {
        public Programuotojas(string vardas, long asmensKodas, double bazinisAtlyginimas)
            : base(vardas, asmensKodas, bazinisAtlyginimas)
        {
        }

        public override double SkaiciuotiAtlyginima()
        {
            return BazinisAtlyginimas * 1.20; 
        }
    }

}
