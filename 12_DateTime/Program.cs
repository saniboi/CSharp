using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace _12_DateTime
{
    /// <summary>
    /// Beachte: wenn das Projekt "DateTime" statt z.B. "09_DateTime" benannt wird, gleich wie die Klasse, muss man 
    /// das System vor DateTime voranstellen, um nicht das eigene Projekt, sondern die DateTime-Klasse zu referenzieren
    /// </summary>
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    ErstesBeispiel();
                    break;
                case 2:
                    Addition();
                    break;
                case 3:
                    Parsen();
                    break;
                case 4:
                    Zeitspanne();
                    break;
            }
        }

        private static void ErstesBeispiel()
        {
            // Dokumentation: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.8
            DateTime date1 = new DateTime(2013, 9, 16, 17, 30, 52);
            DateTime date2 = DateTime.Now;

            Console.WriteLine($"{nameof(date1)}: {date1}");
            Console.WriteLine($"{nameof(date2)}: {date2}");
        }

        private static void Addition()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"now.AddDays(1): {now.AddDays(1)}");
            Console.WriteLine($"now.AddMonths(2): {now.AddMonths(2)}");
        }

        private static void Parsen()
        {
            // Vorsicht: je nach Windows-Einstellung und Land kann das unterschiedlich interpretiert werden
            // In diesem Fall ist es klar: 16. September. Aber z.B. bei "06/07/2013" ist nicht mehr klar,
            // ob der 6. Juli oder 7. Juni gemeint ist.
            //
            // The date and time are based on the system's time-zone setting.
            // https://docs.microsoft.com/en-us/globalization/locale/time-formatting-and-time-zones-in-dotnet-framework

            DateTime input1 = DateTime.Parse("16.09.2013");
            DateTime input2 = DateTime.Parse("2013-09-16");
            DateTime input3 = DateTime.Parse("2000-12-31", CultureInfo.InvariantCulture);

            Console.WriteLine($"{nameof(input1)}: {input1}");
            Console.WriteLine($"{nameof(input2)}: {input2}");
            Console.WriteLine($"{nameof(input3)}: {input3}");
        }

        private static void Zeitspanne()
        {
            DateTime startDate = new DateTime(2013, 9, 16);
            DateTime endDate = new DateTime(2013, 9, 20);
            TimeSpan elapsed = endDate.Subtract(startDate); // Methode Subtract gibt etwas vom Typ TimeSpan zurück
            double daysAgo = elapsed.TotalDays;
            Console.WriteLine($"{nameof(daysAgo)}: {daysAgo} days");
        }
    }
}