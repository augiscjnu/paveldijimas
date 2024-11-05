using penktauzdoutis.Repo;

public class Program
{
    public static void Main(string[] args)
    {
        string failoPavadinimas = "automobiliai.txt";
        AutomobiliuValdymas valdymas = new AutomobiliuValdymas(failoPavadinimas);
        valdymas.Menu();
    }
}
