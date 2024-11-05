namespace Knygos
{
    public class ElektronineKnyga : Knyga
    {
        public double FailoDydisMB { get; set; }
        public string Formatas { get; set; }

        public ElektronineKnyga(int id, string pavadinimas, string autorius, int isleidimoMetai,
            string zanras, double failoDydisMB, string formatas)
            : base(id, pavadinimas, autorius, isleidimoMetai, zanras)
        {
            FailoDydisMB = failoDydisMB;
            Formatas = formatas;
        }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Failo dydis: {FailoDydisMB} MB, Formatas: {Formatas}");
        }
    }
}
