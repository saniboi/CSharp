using System.Globalization;

namespace Übung_5_3_Erweiterungsmethoden
{
    public static class DoubleErweiterungsmethoden
    {
        public static int AnzahlDezimalstellen(this double doubleZahl)
        {
            const int indexDesNachkommateils = 1;

            return doubleZahl
                .ToString(CultureInfo.InvariantCulture)
                .Split('.')[indexDesNachkommateils]   // "double doubleZahl = 1;" als Input führt zu einer IndexOutOfRangeException.
                                                              // D.h. die Methode muss man noch so robust programmieren, dass sie auch mit ganzen Zahlen funktioniert.
                .Length;
        }
    }
}