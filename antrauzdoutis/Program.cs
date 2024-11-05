using antrauzdoutis.Modelis;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<TransportoPriemone> transportoPriemones = new List<TransportoPriemone>
        {
            new Automobilis("Volkswagen Golf", 5.5),
            new Motociklas("Yamaha YZF-R3", 3.5),
            new Automobilis("Toyota Corolla", 6.2),
            new Motociklas("Kawasaki Ninja", 4.0)
        };

        Console.Write("Įveskite atstumą (km): ");
        if (int.TryParse(Console.ReadLine(), out int kelias))
        {
            foreach (var tp in transportoPriemones)
            {
                double kuroSanaudos = tp.ApskaiciuotiKuroSanaudas(kelias);
                Console.WriteLine($"Transporto priemonė: {tp.Pavadinimas}, Kuro sąnaudos: {kuroSanaudos:F2} litrai");
            }
        }
        else
        {
            Console.WriteLine("Neteisingai įvestas atstumas.");
        }
    }
}
