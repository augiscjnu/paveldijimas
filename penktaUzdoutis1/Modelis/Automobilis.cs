public class Automobilis
{
    public int Id { get; set; }
    public string Marke { get; set; }
    public string Modelis { get; set; }
    public int Metai { get; set; }
    public double Kaina { get; set; }

    public Automobilis(int id, string marke, string modelis, int metai, double kaina)
    {
        Id = id;
        Marke = marke;
        Modelis = modelis;
        Metai = metai;
        Kaina = kaina;
    }

    public virtual void SpausdintiInformacija()
    {
        Console.WriteLine($"ID: {Id}, Marke: {Marke}, Modelis: {Modelis}, Metai: {Metai}, Kaina: {Kaina} EUR");
    }
}
