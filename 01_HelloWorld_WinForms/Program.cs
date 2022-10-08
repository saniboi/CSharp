using System;
using System.Windows.Forms;

namespace _01_Hello_World
{
    public class Program
    {
        // Schritt 1: Ein KonsolenApplikation-Projekt auswählen (statt eine WindowsForms-Applikation)
        // Schritt 2: Add → Forms
        // Schritt 3: Properties: Windows Forms Application daraus machen

        [STAThread] // STATread = Single-Threaded Apartment (Thread)
                    // Sonst funktioniert die Applikation nicht richtig und es kommt
                    // irgendwann die Fehlermeldung oder die DialogBox lasse sich nicht
                    // anzeigen:
                    // An unhandled exception of type 'System.Threading.ThreadStateException'
                    // occurred in System.Windows.Forms.dll
                    // Additional information: Current thread must be set to single thread
                    // apartment(STA) mode before OLE calls can be made. Ensure that your
                    // Main function has STAThreadAttribute marked on it. This exception
                    // is only raised if a debugger is attached to the process.
                    // https://msdn.microsoft.com/en-us/library/ms182351.aspx
                    //
                    // Das Gegenstück zu STAThread ist MTAThread.
        public static void Main()
        {
            var form = new MyForm
            {
                Text = "Hello World" // Eigenschaft "Text" = Festertitel
            };
            Application.Run(form);
        }
    }
}