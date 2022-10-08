namespace _02_Methoden_überladen
{
    /// <summary>
    /// Methoden "überladen" heisst Methoden mit dem gleichen Namen aber
    /// unterschiedlichen Methodensignaturen zu haben.
    ///
    /// Beachte: der Rückgabetyp zählt nicht zur Methodensignatur.
    ///
    /// Wenn man mehrere Konstruktoren hat, ist das auch ein "Überladen".
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            var program = new Program();
            program.MethodeÜberladen();
            program.MethodeÜberladen("Hans", 1); // Vokabel: auf der Aufruferseite spricht man von "Argumenten".
                                                 // "Argumente" sind Werte, die an die Methode übergeben werden.
                                                 // "Hans" ist das erste Argument und
                                                 // 1 ist das zweite Argument.
            program.MethodeÜberladen(1, "Peter");
        }

        public Program()                    // Parameterloser Konstruktor
        {
            // ...
        }

        public Program(string name)         // Konstruktor mit einem Parameter; überlädt obigen parameterlosen Konstruktor
        {
            // ...
        }

        private void MethodeÜberladen()
        {
            // ...
        }

        private void MethodeÜberladen(string name, int alter)   // Vokabel: auf der Methodensignaturseite spricht man von "Parametern".
                                                                // "Parameter" sind Variablennamen, die in der Methodensignatur stehen.
                                                                // "name" ist der erste Parameter.
                                                                // "alter" ist der zweite Paramter.
        {
            // ...
        }


        private void MethodeÜberladen(int alter, string name)
        {
            // ...
        }

        //private string MethodeÜberladen(int alter, string name)   // Das funktioniert nicht, weil nur
        // der Rückgabewert anders ist verglichen
        // zur obigen Methode. Das reicht nicht.
        // Die Methodensignatur (= Methodenname + Parameterliste)
        // muss anders sein.
        //{
        //    // ...
        //}

        // Siehe vom .NET Framework gelieferte überladene Methoden am Beispiel Console.WriteLine()
        private void EineMethode()
        {
            System.Console.WriteLine("test"); // F12 auf WriteLine machen oder "WriteLine(" tippen und den Tooltip anschauen
        }
    }
}