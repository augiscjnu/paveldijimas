using System;
using System.Collections.Generic;
using treciauzdoutis;
using treciauzdoutis.modelis;

class Program
{
    static void Main(string[] args)
    {
        DarbuotojuRepository repository = new DarbuotojuRepository();
        List<Darbuotojas> darbuotojai = repository.NuskaytiDarbuotojusIsFailo("darbuotojai.txt");

        foreach (var darbuotojas in darbuotojai)
        {
            darbuotojas.SpausdintiInformacija();
            Console.WriteLine();
        }
    }
}
