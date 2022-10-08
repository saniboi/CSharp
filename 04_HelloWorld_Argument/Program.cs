namespace _04_HelloWorld_Argument
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Hello, World!");
            }
            else
            {
                //Console.WriteLine("Hello, {0}!", args[0]); // Alte Schreibweise
                Console.WriteLine($"Hello, {args[0]}!");     // Neue Schreibweise mit String-Interpolation ab C# 6 (Juli 2015)

                // Kommandozeilen-Argumente eingeben
                // a) Entweder HelloWorld.exe direkt aus der Konsole starten mit: HelloWorld.exe Hans
                // b) Oder Argument via Visual Studio eingeben:
                //      Kontextmenü auf Projekt: Properties → Lasche: Debug → Start Options: Command Line Arguments: Hans
            }
        }
    }
}