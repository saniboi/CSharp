namespace _04_Methoden_params
{
    public class Program
    {
        public static void Main()
        {
            var program = new Program();
            int resultat1 = program.Add();
            int resultat2 = program.Add(1);
            int resultat3 = program.Add(1, 2);
            int resultat4 = program.Add(4, 2, 8, 2000, 100, 50);

            Console.WriteLine($"resultat1 = {resultat1}");
            Console.WriteLine($"resultat2 = {resultat2}");
            Console.WriteLine($"resultat3 = {resultat3}");
            Console.WriteLine($"resultat3 = {resultat3}");
            Console.WriteLine($"resultat4 = {resultat4}");


            // Mit F12 auf WriteLine die Methodensignatur anschauen: es wird ein "params" verwendet
            Console.WriteLine("Altes Console.WriteLine, welches auch params verwendet: {0} {1} {2} {3} {0} {3}.", "eins", "zwei", "blah", "test");
        }

        private int Add(params int[] zahlen) // Ausprobieren, wie sich die Aufrufseite verändert, wenn man das "params" weglässt → Lösung befindet sich ganz unten.
        {
            int summe = 0;
            foreach (int zahl in zahlen)
            {
                summe += zahl;
            }
            return summe;
        }

























        // So muss man die Argumente eingeben, wenn man das "params" weglässt
        //int resultat1 = program.Add(new int[] { });
        //int resultat2 = program.Add(new[] { 1 });
        //int resultat3 = program.Add(new[] { 1, 2 });
        //int resultat4 = program.Add(new[] { 4, 2, 8, 2000, 100, 50 });
    }
}