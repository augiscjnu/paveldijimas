﻿using antrauzdoutis.Modelis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrauzdoutis.Modelis
{

    public class Motociklas : TransportoPriemone
    {
        public Motociklas(string pavadinimas, double kuroSanaudos100km)
            : base(pavadinimas, kuroSanaudos100km)
        {
        }
    }
}
