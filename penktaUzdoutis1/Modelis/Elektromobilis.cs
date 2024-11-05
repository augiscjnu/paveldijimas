public class ElektrinisAutomobilis : Automobilis
{
    public double BaterijosTalpa { get; set; }
    public int Nuotolis { get; set; }

    public ElektrinisAutomobilis(int id, string marke, string modelis, int metai, double kaina, double baterijosTalpa, int nuotolis)
        : base(id, marke, modelis, metai, kaina)
    {
        BaterijosTalpa = baterijosTalpa;
        Nuotolis = nuotolis;
    }

    public override void SpausdintiInformacija()
    {
        base.SpausdintiInformacija();
        Console.WriteLine($"Baterijos talpa: {BaterijosTalpa} kWh, Nuotolis: {Nuotolis} km");
    }
}
