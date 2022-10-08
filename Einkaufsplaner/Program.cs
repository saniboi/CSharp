namespace Einkaufsplaner
{
    class Program
    {
        static void Main()
        {
            Kommando komando = new Kommando();
            komando.Start();
            komando.DefaultWerte();
            while (true)
            {
                komando.MenueFuehrung();
            }
        }
    }
}
