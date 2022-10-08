using System.Diagnostics.CodeAnalysis;
using _05_Methoden_Rückgabewerte.Entitäten;

namespace _05_Methoden_Rückgabewerte
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 4;

            switch (beispiel)
            {
                case 1:
                    ParameterübergabeVonWertetypenHabenKeinenSeiteneffekt(); // mit out und ref aber schon → Siehe Beispiele unten
                    break;
                case 2:
                    OutBeispiel();
                    break;
                case 3:
                    RefBeispiel();
                    break;
                case 4:
                    ObjektAlsRückgabewert();
                    break;
            }
        }

        private static void ParameterübergabeVonWertetypenHabenKeinenSeiteneffekt()
        {
            int x = 1;
            Console.WriteLine($"Wert von x vor Methodenaufruf:\t\t {x}\n");
            Console.WriteLine("--- Methodenaufruf: Start ---");
            RufeEineMethodeAufUndÜbergibX(x);
            Console.WriteLine("--- Methodenaufruf: Ende ---\n");
            Console.WriteLine($"Wert von x nach Methodenaufruf:\t\t {x}");
        }

        private static void RufeEineMethodeAufUndÜbergibX(int wert)
        {
            Console.WriteLine($"Anfangswert von x innerhalb der Methode: {wert}");
            wert++;
            Console.WriteLine($"Endwert von x innerhalb der Methode:\t {wert}");
        }

        private static void OutBeispiel()
        {
            int x; // out-Variablen müssen vor dem Aufruf, nicht initialisiert sein,
                   // weil per Definition garantiert ist, dass sie _nach_ dem Methodenaufruf initialisiert sein werden
            int y; // Seit C# 7.0 (2017) kann man die out-Variablen auch "inline" deklarieren (mit ReSharper oder von Hand ausprobieren)
            MethodeMitOutParametern(out x, out y);
            Console.WriteLine($"x = {x}, y = {y}"); // Beachte: Wertetypen verhalten sich hier ausnahmsweise wie Referenztypen
        }

        public static void MethodeMitOutParametern(out int zahl1, out int zahl2)
        {
            zahl1 = 1;  // Diese Zeile auskommentieren und die Fehlermeldung lesen:
            // Error CS0177  The out parameter 'zahl1' must be assigned to before control leaves the current method
            zahl2 = 2;
            // Beachte: kein return-Ausdruck vorhanden
            // Beachte: alle out-Parameter müssen innerhalb der Methode initialisiert werden, sonst gibt es einen Compilerfehler
        }

        private static void RefBeispiel()
        {
            // Beachte: alle ref-Paramter müssen per Definition _vor_ der Verwendung initialisiert werden
            int a = 3;  // "= 3" auskommentieren und Fehler lesen
                        // Error CS0165  Use of unassigned local variable 'a'
            int b = 4;
            MethodeMitRefParameter(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");  // Beachte: Wertetypen verhalten sich hier ausnahmsweise wie Referenztypen
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void MethodeMitRefParameter(ref int zahl1, ref int zahl2)
        {
            // Beachte: bei ref Variablen ist sichergestellt, dass sie _vor_ dem Aufruf initialisiert wurden
            //          das heisst, wir können in der Methode direkt etwas mit den Werten machen
            int x = zahl1 + zahl2;

            // Und Änderungen innerhalb der Methoden haben eine Seiteneffekt nach ausserhalb der Methode,
            // was wir bei gewöhnlichen Wertetypen ohne ref _nicht_ haben.
            zahl1 = 5;
            zahl2 = 6;
        }

        private static void ObjektAlsRückgabewert()
        {
            Person p = Person.ErstelleObjekt();                                 // Hier kommt ein Person-Objekt zurück
            Console.WriteLine(p);

            p = MethodeDieEinPersonObjektEntgegennimmtMutiertUndRetourniert(p); // Hier kommt auch ein Person-Objekt zurück
            Console.WriteLine(p); // Name wurde in der Methode geändert und der (Seiten-)Effekt ist auch ausserhalb der Methode sichtbar.
        }

        private static Person MethodeDieEinPersonObjektEntgegennimmtMutiertUndRetourniert(Person person)
        {
            person.Name = "Sara";
            return person;
        }
    }
}