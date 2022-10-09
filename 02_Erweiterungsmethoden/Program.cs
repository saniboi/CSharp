using System;

namespace _02_Erweiterungsmethoden
{
    public class Program
    {
        /// <summary>
        /// Repetition des Themas Erweiterungsmethoden aus CS1, weil LINQ das Konzept verwendet.
        ///
        /// FügeBegrüssungHinzu in hans.FügeBegrüssungHinzu wurde als Erweiterungsmethode an string angebaut.
        ///
        /// Select ist analog eine Erweiterungsmethode für den Type IEnumerable<T>.
        ///
        /// 1. Dokumentation anschauen: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=net-6.0
        /// 2. Code anschauen: Entweder auf referencesource.micrsoft.com oder mit Resharper anschauen:
        ///    a) https://referencesource.microsoft.com/#System.Core/System/Linq/Enumerable.cs,577032c8811e20d3
        ///    b) Öffne "Class View" (oder "Object Browser")
        ///         → Suche nach "System.Linq.Enumerable"
        ///         → Selektiere Erweiterungsmethode "Select"
        ///         → Mit F12 Code von Reshaper dekompilieren lassen
        /// </summary>
        public static void Main()
        {
            string hans = "Hans";

            string hansMitGreeting = hans.FügeBegrüssungHinzu();

            Console.WriteLine(hansMitGreeting);
        }
    }
}