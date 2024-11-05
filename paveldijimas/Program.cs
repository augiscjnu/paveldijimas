using paveldijimas.Modelis;
using System;

namespace pirmauzdoutis;


public class Program
    {
        static void Main(string[] args)
        {
            List<Darbuotojas> darbuotojai = new List<Darbuotojas>
        {
            new Vadybininkas("Jonas", 123456789, 1500),
            new Programuotojas("Ona", 987654321, 1600),
            new Vadybininkas("Petras", 112233445, 1800),
            new Programuotojas("Laura", 556677889, 1700)
        };

            foreach (var darbuotojas in darbuotojai)
            {
                double galutinisAtlyginimas = darbuotojas.SkaiciuotiAtlyginima();
                Console.WriteLine($"Vardas: {darbuotojas.Vardas}, Galutinis atlyginimas: {galutinisAtlyginimas:F2} EUR");
            }
        }
    }









 
    


