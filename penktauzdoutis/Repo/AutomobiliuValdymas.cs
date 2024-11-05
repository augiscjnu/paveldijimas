using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penktauzdoutis.Repo
{
    using penktauzdoutis.Modelis;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class AutomobiliuValdymas
    {
        private List<Automobilis> automobiliai = new List<Automobilis>();
        private string failoPavadinimas;

        public AutomobiliuValdymas(string failoPavadinimas)
        {
            this.failoPavadinimas = failoPavadinimas;
            NuskaitimoFunkcija();
        }

        public void NuskaitimoFunkcija()
        {
            if (!File.Exists(failoPavadinimas))
            {
                Console.WriteLine("Failas nerastas. Sukuriamas tuščias sąrašas.");
                return;
            }

            foreach (var line in File.ReadLines(failoPavadinimas))
            {
                var parts = line.Split(';');
                int id = int.Parse(parts[0]);
                string marke = parts[1];
                string modelis = parts[2];
                int metai = int.Parse(parts[3]);
                double kaina = double.Parse(parts[4]);
                string tipas = parts[5];
                string papildomaInformacija = parts[6];

                if (tipas == "ElektrinisAutomobilis")
                {
                    var dalys = papildomaInformacija.Split(';');
                    double baterijosTalpa = double.Parse(dalys[0]);
                    int nuotolis = int.Parse(dalys[1]);
                    automobiliai.Add(new ElektrinisAutomobilis
                    {
                        Id = id,
                        Marke = marke,
                        Modelis = modelis,
                        Metai = metai,
                        Kaina = kaina,
                        BaterijosTalpa = baterijosTalpa,
                        Nuotolis = nuotolis
                    });
                }
                else if (tipas == "VidausDegimoAutomobilis")
                {
                    automobiliai.Add(new VidausDegimoAutomobilis
                    {
                        Id = id,
                        Marke = marke,
                        Modelis = modelis,
                        Metai = metai,
                        Kaina = kaina,
                        KuroTipas = papildomaInformacija
                    });
                }
            }
        }

        public void IssaugotiFunkcija()
        {
            using (var writer = new StreamWriter(failoPavadinimas))
            {
                foreach (var automobilis in automobiliai)
                {
                    if (automobilis is ElektrinisAutomobilis elektrinis)
                    {
                        writer.WriteLine($"{automobilis.Id};{automobilis.Marke};{automobilis.Modelis};{automobilis.Metai};{automobilis.Kaina};ElektrinisAutomobilis;{elektrinis.BaterijosTalpa};{elektrinis.Nuotolis}");
                    }
                    else if (automobilis is VidausDegimoAutomobilis vidaus)
                    {
                        writer.WriteLine($"{automobilis.Id};{automobilis.Marke};{automobilis.Modelis};{automobilis.Metai};{automobilis.Kaina};VidausDegimoAutomobilis;{vidaus.KuroTipas}");
                    }
                }
            }
        }

        public void PridetiAutomobili()
        {
            Console.WriteLine("Pasirinkite automobilio tipą (ElektrinisAutomobilis/VidausDegimoAutomobilis): ");
            string tipas = Console.ReadLine();
            int id = automobiliai.Count + 1; 
            Console.Write("Įveskite markę: ");
            string marke = Console.ReadLine();
            Console.Write("Įveskite modelį: ");
            string modelis = Console.ReadLine();
            Console.Write("Įveskite gamybos metus: ");
            int metai = int.Parse(Console.ReadLine());
            Console.Write("Įveskite kainą: ");
            double kaina = double.Parse(Console.ReadLine());

            if (tipas == "ElektrinisAutomobilis")
            {
                Console.Write("Įveskite baterijos talpą (kWh): ");
                double baterijosTalpa = double.Parse(Console.ReadLine());
                Console.Write("Įveskite maksimalų nuotolį (km): ");
                int nuotolis = int.Parse(Console.ReadLine());
                automobiliai.Add(new ElektrinisAutomobilis
                {
                    Id = id,
                    Marke = marke,
                    Modelis = modelis,
                    Metai = metai,
                    Kaina = kaina,
                    BaterijosTalpa = baterijosTalpa,
                    Nuotolis = nuotolis
                });
            }
            else if (tipas == "VidausDegimoAutomobilis")
            {
                Console.Write("Įveskite kuro tipą: ");
                string kuroTipas = Console.ReadLine();
                automobiliai.Add(new VidausDegimoAutomobilis
                {
                    Id = id,
                    Marke = marke,
                    Modelis = modelis,
                    Metai = metai,
                    Kaina = kaina,
                    KuroTipas = kuroTipas
                });
            }
            else
            {
                Console.WriteLine("Neteisingas automobilio tipas.");
                return;
            }

            Console.WriteLine("Automobilis pridėtas sėkmingai.");
        }

        public void PerziuretiAutomobilius()
        {
            foreach (var automobilis in automobiliai)
            {
                automobilis.SpausdintiInformacija();
                Console.WriteLine(new string('-', 40));
            }
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Peržiūrėti visus automobilius");
                Console.WriteLine("2. Pridėti naują automobilį");
                Console.WriteLine("3. Išsaugoti automobilių informaciją į failą");
                Console.WriteLine("4. Baigti programą");
                Console.Write("Pasirinkite veiksmą: ");
                string pasirinkimas = Console.ReadLine();

                switch (pasirinkimas)
                {
                    case "1":
                        PerziuretiAutomobilius();
                        break;
                    case "2":
                        PridetiAutomobili();
                        break;
                    case "3":
                        IssaugotiFunkcija();
                        Console.WriteLine("Informacija išsaugota sėkmingai.");
                        break;
                    case "4":
                        Console.WriteLine("Programos pabaiga.");
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Bandykite dar kartą.");
                        break;
                }
            }
        }
    }
}