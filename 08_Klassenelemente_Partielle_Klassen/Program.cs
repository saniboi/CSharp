namespace _08_Klassenelemente_Partielle_Klassen
{
    public class Program
    {
        public static void Main()
        {
            var auto = new Auto();
            Console.WriteLine(auto.MethodeAusPartialClassAuto1()); // Die Methode kommt aus der partiellen Klasse Teil 1
            Console.WriteLine(auto.MethodeAusPartialClassAuto2()); // Die Methode kommt aus der partiellen Klasse Teil 2
            Console.WriteLine(auto.MethodeAusPartialClassAuto3()); // Die Methode kommt aus der partiellen Klasse Teil 3

            // Anwendungsfall: Wenn ein Teil der Klasse von einem Werkzeug generiert wird
            // Beispiel: WinForms-GUI-Generator
            // Beispiel: Entity-Framework-Domain-Klassen
        }
    }
}