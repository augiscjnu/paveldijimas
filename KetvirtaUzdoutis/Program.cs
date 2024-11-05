using Knygos;

public class Program
{
    static void Main(string[] args)
    {
        var knygosRepository = new KnyguRepository();

        
        knygosRepository.NuskaitytiKnygasIsFailo("knygos.txt");

        while (true)
        {
            Console.WriteLine("Pasirinkite veiksmą:");
            Console.WriteLine("1. Peržiūrėti visas knygas");
            Console.WriteLine("2. Filtruoti knygas pagal žanrą");
            Console.WriteLine("3. Rikiuoti knygas pagal išleidimo metus");
            Console.WriteLine("4. Ieškoti knygos pagal autorių ar pavadinimą");
            Console.WriteLine("5. Pridėti naują knygą");
            Console.WriteLine("6. Išsaugoti knygas į failą");
            Console.WriteLine("7. Išeiti");

            string pasirinkimas = Console.ReadLine();

            switch (pasirinkimas)
            {
                case "1":
                    knygosRepository.IsvestiKnygas();
                    break;

                case "2":
                    Console.WriteLine("Įveskite žanrą:");
                    string zanras = Console.ReadLine();
                    var filtruotosKnygos = knygosRepository.FiltruotiPagalZanra(zanras);
                    if (filtruotosKnygos.Count > 0)
                    {
                        foreach (var knyga in filtruotosKnygos)
                        {
                            knyga.SpausdintiInformacija();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nerasta knygų pagal šį žanrą.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Ar norite rikiuoti nuo seniausių iki naujausių? (y/n)");
                    string pasirinkimasRikiuoti = Console.ReadLine();
                    bool nuoSeniiausiu = pasirinkimasRikiuoti.ToLower() == "y";
                    knygosRepository.RikiuotiPagalIsleidimoMetus(nuoSeniiausiu);
                    knygosRepository.IsvestiKnygas();
                    break;

                case "4":
                    Console.WriteLine("Įveskite autoriaus vardą arba knygos pavadinimą:");
                    string paieskosTerminas = Console.ReadLine();
                    var rastosKnygos = knygosRepository.IeškotiPagalAutoriuArPavadinima(paieskosTerminas);
                    if (rastosKnygos.Count > 0)
                    {
                        foreach (var knyga in rastosKnygos)
                        {
                            knyga.SpausdintiInformacija();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nerasta knygų pagal šį paieškos terminą.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Pasirinkite knygos tipą (1 - Popierinė, 2 - Elektroninė):");
                    string tipoPasirinkimas = Console.ReadLine();
                    Console.WriteLine("Įveskite knygos pavadinimą:");
                    string pavadinimas = Console.ReadLine();
                    Console.WriteLine("Įveskite autorių:");
                    string autorius = Console.ReadLine();
                    Console.WriteLine("Įveskite išleidimo metus:");
                    int isleidimoMetai = int.Parse(Console.ReadLine());
                    Console.WriteLine("Įveskite žanrą:");
                    string zanrasNauja = Console.ReadLine();

                    if (tipoPasirinkimas == "1")
                    {
                        Console.WriteLine("Įveskite puslapių skaičių:");
                        int puslapiuSkaicius = int.Parse(Console.ReadLine());
                        var popierineKnyga = new PopierineKnyga(0, pavadinimas, autorius, isleidimoMetai, zanrasNauja, puslapiuSkaicius);
                        knygosRepository.Knygos.Add(popierineKnyga);
                    }
                    else if (tipoPasirinkimas == "2")
                    {
                        Console.WriteLine("Įveskite failo dydį MB:");
                        double failoDydis = double.Parse(Console.ReadLine());
                        Console.WriteLine("Įveskite formato tipą (pvz., PDF, EPUB):");
                        string formatas = Console.ReadLine();
                        var elektronineKnyga = new ElektronineKnyga(0, pavadinimas, autorius, isleidimoMetai, zanrasNauja, failoDydis, formatas);
                        knygosRepository.Knygos.Add(elektronineKnyga);
                    }
                    break;

                case "6":
                    knygosRepository.IrasytiKnygasIFaila("knygos.txt");
                    Console.WriteLine("Visos knygos išsaugotos failo.");
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Neteisingas pasirinkimas.");
                    break;
            }
        }
    }
}
