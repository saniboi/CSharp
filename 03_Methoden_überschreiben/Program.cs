using _03_Methoden_überschreiben.Entitäten;

namespace _03_Methoden_überschreiben
{
    /// <summary>
    /// Methoden "überschreiben" heisst, Methoden von einer Oberklasse mit dem gleichen Namen in einer
    /// Unterklasse zu deklarieren. Das heisst auch, dass die Signatur gleich ist.
    /// Oben steht "virtual".
    /// Unten steht "override".
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            new Basisklasse().SagHallo("Hans");
            new Unterklasse().SagHallo("Hans");
        }
    }
}