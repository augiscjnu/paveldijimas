namespace Knygos
{
    public class PopierineKnyga : Knyga
    {
        public int PuslapiuSkaicius { get; set; }

        public PopierineKnyga(int id, string pavadinimas, string autorius, int isleidimoMetai,
            string zanras, int puslapiuSkaicius)
            : base(id, pavadinimas, autorius, isleidimoMetai, zanras)
        {
            PuslapiuSkaicius = puslapiuSkaicius;
        }

        public override void SpausdintiInformacija()
        {
            base.SpausdintiInformacija();
            Console.WriteLine($"Puslapių skaičius: {PuslapiuSkaicius}");
        }
    }
}
