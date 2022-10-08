using System;
using System.Diagnostics;

namespace Konsole_WieSchreibtManInDenVSOutput
{
    public class Program
    {
        public static void Main()
        {
            // Dokumentation
            // Output-Ansicht: https://docs.microsoft.com/en-us/visualstudio/ide/reference/output-window?view=vs-2019

            // In die Konsole schreiben
            Console.WriteLine("Hallo, Konsole!");

            // In die Output-Ansicht schreiben
            //
            // Beachte:
            //   Die Ausgabe sieht man nur, wenn
            //   1. der Haken weg ist bei: Menu Tools → Options → Debugging → Redirect all Output Window text to the Immediate Window.
            //   2. die Applikation im Debug-Modus (d.h. mit F5 und nicht mit Ctrl+F5) gestartet wurde.
            // Quelle:
            //   https://stackoverflow.com/a/9466903
            //
            // Beachte zudem:
            //   Im Release-Build werden die Debug-Anweisungen entfernt.
            // Quellen: 
            //   https://stackoverflow.com/a/5419568
            //   https://newbedev.com/what-s-the-difference-between-console-writeline-vs-debug-writeline
            //   https://stackoverflow.com/a/10936505
            Debug.WriteLine("Hallo, Output-Ansicht!");

            // Ins Trace schreiben
            //
            // Schreibt auch in die Output-Ansicht.
            // Aber im Gegensatz zum Debug.WriteLine bleibt der Code auch im Release-Model drin.
            // Quelle:
            //   https://stackoverflow.com/a/46925335
            Trace.WriteLine("Hello, Trace!");
        }
    }
};
