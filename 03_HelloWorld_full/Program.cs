namespace _03_HelloWorld_full
{
    class Program
    {
        /// <summary>
        /// The following is a list of valid Main signatures:
        ///
        /// public static void Main() { }
        /// public static int Main() { }
        /// public static void Main(string[] args) { }
        /// public static int Main(string[] args) { }
        /// public static async Task Main() { }
        /// public static async Task<int> Main() { }
        /// public static async Task Main(string[] args) { }
        /// public static async Task<int> Main(string[] args) { }
        ///
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/ (04.11.2020)
        /// </summary>
        static void Main() // Den "string[] args"-Parameter kann man löschen, wenn man keine Argumente aus der Konsole erwartet
        {
            Console.WriteLine("Hello, World!");
        }


        // Das Kompilat liegt unter:                "...\01 HelloWorld\bin\Debug\netcoreapp3.1\01 HelloWorld.exe"
        // Die Konfigurationsdatei liegt daneben:   "...\01 HelloWorld\bin\Debug\netcoreapp3.1\01 HelloWorld.runtimeconfig.json"
        // 01 HelloWorld.csproj-Datei in öffnen und den Inhalt anschauen
        // Projekteigenschaften anschauen:          Kontextmenü auf der Projektdatei → Properties → Lasche: Package → z.B. Copyright ändern und Inhalt von 01 HelloWorld.csproj anschauen
    }
}