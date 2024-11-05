public class VidausDegimoAutomobilis : Automobilis
{
    public string KuroTipas { get; set; }

    public VidausDegimoAutomobilis(int id, string marke, string modelis, int metai, double kaina, string kuroTipas)
        : base(id, marke, modelis, metai, kaina)
    {
        KuroTipas = kuroTipas;
    }

    public override void SpausdintiInformacija()
    {
        base.SpausdintiInformacija();
        Console.WriteLine($"Kuro tipas: {KuroTipas}");
    }
}
