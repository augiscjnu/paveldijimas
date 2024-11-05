using Knygos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class KnyguRepository
{
    public List<Knyga> Knygos { get; set; }

    public KnyguRepository()
    {
        Knygos = new List<Knyga>();
    }

    
    public List<Knyga> FiltruotiPagalZanra(string zanras)
    {
        return Knygos.Where(k => k.Zanras.Equals(zanras, StringComparison.OrdinalIgnoreCase)).ToList();
    }

   
    public void RikiuotiPagalIsleidimoMetus(bool nuoSeniiausiu)
    {
        if (nuoSeniiausiu)
        {
            Knygos = Knygos.OrderBy(k => k.IsleidimoMetai).ToList();
        }
        else
        {
            Knygos = Knygos.OrderByDescending(k => k.IsleidimoMetai).ToList(); 
        }
    }

    
    public List<Knyga> IeškotiPagalAutoriuArPavadinima(string paieskosTerminas)
    {
        return Knygos.Where(k => k.Autorius.Contains(paieskosTerminas, StringComparison.OrdinalIgnoreCase) ||
                                 k.Pavadinimas.Contains(paieskosTerminas, StringComparison.OrdinalIgnoreCase)).ToList();
    }

  
    public void IrasytiKnygasIFaila(string failoKelias)
    {
        var eilutes = new List<string>();

        foreach (var knyga in Knygos)
        {
            string eilute;
            if (knyga is ElektronineKnyga elektronineKnyga)
            {
                eilute = $"{knyga.KnygosID};{knyga.Pavadinimas};{knyga.Autorius};{knyga.IsleidimoMetai};{knyga.Zanras};ElektronineKnyga;{elektronineKnyga.FailoDydisMB};{elektronineKnyga.Formatas}";
            }
            else if (knyga is PopierineKnyga popierineKnyga)
            {
                eilute = $"{knyga.KnygosID};{knyga.Pavadinimas};{knyga.Autorius};{knyga.IsleidimoMetai};{knyga.Zanras};PopierineKnyga;{popierineKnyga.PuslapiuSkaicius}";
            }
            else
            {
                eilute = $"{knyga.KnygosID};{knyga.Pavadinimas};{knyga.Autorius};{knyga.IsleidimoMetai};{knyga.Zanras};Knyga;";
            }

            eilutes.Add(eilute);
        }

        File.WriteAllLines(failoKelias, eilutes);
    }

    
    public void NuskaitytiKnygasIsFailo(string failoKelias)
    {
        if (File.Exists(failoKelias))
        {
            var eilutes = File.ReadAllLines(failoKelias);
            foreach (var eilute in eilutes)
            {
                var duomenys = eilute.Split(';');
                if (duomenys.Length >= 6)
                {
                    int id = int.Parse(duomenys[0]);
                    string pavadinimas = duomenys[1];
                    string autorius = duomenys[2];
                    int isleidimoMetai = int.Parse(duomenys[3]);
                    string zanras = duomenys[4];
                    string tipas = duomenys[5];

                    if (tipas == "PopierineKnyga")
                    {
                        int puslapiuSkaicius = int.Parse(duomenys[6]);
                        Knygos.Add(new PopierineKnyga(id, pavadinimas, autorius, isleidimoMetai, zanras, puslapiuSkaicius));
                    }
                    else if (tipas == "ElektronineKnyga")
                    {
                        double failoDydis = double.Parse(duomenys[6]);
                        string formatas = duomenys[7];
                        Knygos.Add(new ElektronineKnyga(id, pavadinimas, autorius, isleidimoMetai, zanras, failoDydis, formatas));
                    }
                    else
                    {
                        Knygos.Add(new Knyga(id, pavadinimas, autorius, isleidimoMetai, zanras));
                    }
                }
            }
        }
    }

   
    public void IsvestiKnygas()
    {
        foreach (var knyga in Knygos)
        {
            knyga.SpausdintiInformacija();
            Console.WriteLine();
        }
    }
}
