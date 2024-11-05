using System;

namespace Automobiliai
{
    class Program
    {
        static void Main(string[] args)
        {
            var automobiliuRepository = new AutomobiliuRepository();
            automobiliuRepository.NuskaitytiAutomobiliusIsFailo("automobiliai.txt");

            while (true)
            {
                Console.WriteLine("Pasirinkite veiksmą:");
                Console.WriteLine("1. Peržiūrėti visus automobilius");
                Console.WriteLine("2. Pridėti naują automobilį");
                Console.WriteLine("3. Išsaugoti automobilių informaciją į failą");
                Console.WriteLine("4. Baigti programą");

                string pasirinkimas = Console.ReadLine();

                switch (pasirinkimas)
                {
                    case "1":
                        automobiliuRepository.IsvestiAutomobilius();
                        break;

                    case "2":
                        Console.WriteLine("Pasirinkite automobilio tipą (1 - ElektrinisAutomobilis, 2 - VidausDegimoAutomobilis):");
                        string tipoPasirinkimas = Console.ReadLine();

                        Console.WriteLine("Įveskite markę:");
                        string marke = Console.ReadLine();
                        Console.WriteLine("Įveskite modelį:");
                        string modelis = Console.ReadLine();
                        Console.WriteLine("Įveskite gamybos metus:");
                        int metai = int.Parse(Console.ReadLine());
                        Console.WriteLine("Įveskite kainą EUR:");
                        double kaina = double.Parse(Console.ReadLine());

                        if (tipoPasirinkimas == "1")
                        {
                            Console.WriteLine("Įveskite baterijos talpą kWh:");
                            double baterijosTalpa = double.Parse(Console.ReadLine());
                            Console.WriteLine("Įveskite maksimalų nuotolį km:");
                            int nuotolis = int.Parse(Console.ReadLine());

                            var elektrinisAutomobilis = new ElektrinisAutomobilis(0, marke, modelis, metai, kaina, baterijosTalpa, nuotolis);
                            automobiliuRepository.PridetiNaujaAutomobili(elektrinisAutomobilis);
                        }
                        else if (tipoPasirinkimas == "2")
                        {
                            Console.WriteLine("Įveskite kuro tipą (pvz., Benzinas, Dyzelinas):");
                            string kuroTipas = Console.ReadLine();

                            var vidausDegimoAutomobilis = new VidausDegimoAutomobilis(0, marke, modelis, metai, kaina, kuroTipas);
                            automobiliuRepository.PridetiNaujaAutomobili(vidausDegimoAutomobilis);
                        }
                        break;

                    case "3":
                        automobiliuRepository.IsaugotiAutomobiliusIFaila("automobiliai.txt");
                        Console.WriteLine("Automobilių informacija išsaugota į failą.");
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar kartą.");
                        break;
                }
            }
        }
    }
}
