using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paveldijimas.Modelis
{
    public class Darbuotojas
    {

        public string Vardas { get; set; }

        public long AsmensKodas { get; set; }

        public double BazinisAtlyginimas { get; set; }



        public Darbuotojas(string vardas,long asmensKodas,double bazinisAtlyginimas) 
        {

            Vardas = vardas;
            AsmensKodas = asmensKodas;
            BazinisAtlyginimas = bazinisAtlyginimas;

            
        }


        public virtual double SkaiciuotiAtlyginima()
        {
            return BazinisAtlyginimas;
        }
    }


}
    

    


