using System;
using System.Collections.Generic;
using System.IO;

public class AutomobiliuRepository
{
    public List<Automobilis> Automobiliai { get; set; }

    public AutomobiliuRepository()
    {
        Automobiliai = new List<Automobilis>();
    }


    public void NuskaitytiAutomobiliusIsFailo(string failoKelias)
    {
        if (File.Exists(failoKelias))
        {
            var eilutes = File.ReadAllLines(failoKelias);
            if (eilutes.Length == 0)
            {
                Console.WriteLine("Failas yra tuščias.");
            }
            else
            {
                foreach (var eilute in eilutes)
                {
                    var duomenys = eilute.Split(';');
                    int id = int.Parse(duomenys[0]);
                    string marke = duomenys[1];
                    string modelis = duomenys[2];
                    int metai = int.Parse(duomenys[3]);
                    double kaina = double.Parse(duomenys[4]);
                    string tipas = duomenys[5];
                    string papildomaInformacija = duomenys[6];

                    if (tipas == "ElektrinisAutomobilis")
                    {
                        var info = papildomaInformacija.Split(';');
                        double baterijosTalpa = double.Parse(info[0]);
                        int nuotolis = int.Parse(info[1]);
                        Automobiliai.Add(new ElektrinisAutomobilis(id, marke, modelis, metai, kaina, baterijosTalpa, nuotolis));
                    }
                    else if (tipas == "VidausDegimoAutomobilis")
                    {
                        Automobiliai.Add(new VidausDegimoAutomobilis(id, marke, modelis, metai, kaina, papildomaInformacija));
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Failas nerastas.");
        }
    }



    public void IsvestiAutomobilius()
    {
        if (Automobiliai.Count == 0)
        {
            Console.WriteLine("Nėra automobilių.");
        }
        else
        {
            foreach (var automobilis in Automobiliai)
            {
                automobilis.SpausdintiInformacija();
                Console.WriteLine();
            }
        }
    }



    public void IsaugotiAutomobiliusIFaila(string failoKelias)
    {
        var eilutes = new List<string>();

        foreach (var automobilis in Automobiliai)
        {
            string eilute;
            if (automobilis is ElektrinisAutomobilis elektrinis)
            {
                eilute = $"{automobilis.Id};{automobilis.Marke};{automobilis.Modelis};{automobilis.Metai};{automobilis.Kaina};ElektrinisAutomobilis;{elektrinis.BaterijosTalpa};{elektrinis.Nuotolis}";
            }
            else if (automobilis is VidausDegimoAutomobilis vidausDegimo)
            {
                eilute = $"{automobilis.Id};{automobilis.Marke};{automobilis.Modelis};{automobilis.Metai};{automobilis.Kaina};VidausDegimoAutomobilis;{vidausDegimo.KuroTipas}";
            }
            else
            {
                eilute = $"{automobilis.Id};{automobilis.Marke};{automobilis.Modelis};{automobilis.Metai};{automobilis.Kaina};Automobilis;";
            }

            eilutes.Add(eilute);
        }

        File.WriteAllLines(failoKelias, eilutes);
    }

   
    public void PridetiNaujaAutomobili(Automobilis automobilis)
    {
        Automobiliai.Add(automobilis);
    }
}
