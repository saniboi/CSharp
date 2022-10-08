using System.Diagnostics.CodeAnalysis;

namespace _01_Methoden
{
    public class Program
    {
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 4;

            var objekt = new KlasseMitMethoden();
            switch (beispiel)
            {
                case 1:
                    objekt.MethodeOhneParameterUndOhneRückgabewert();
                    break;
                case 2:
                    objekt.MethodeMitParameter();
                    break;
                case 3:
                    objekt.MethodeMitRückgabewert();
                    break;
                case 4:
                    objekt.MethodeMitRückgabewertUndJederPfadMussEinReturnHaben();
                    break;
            }
        }
    }

    public class KlasseMitMethoden
    {
        public void MethodeOhneParameterUndOhneRückgabewert()
        {
            GibAus();  // Methodenaufruf; Namenskonvention Verben/Aktionen verwenden; in der Befehlsform (Imperativ)
        }

        private void GibAus() // Keine Parameter; kein Rückgabewert
        {
            Console.WriteLine("Eine beliebige Konsolenausgabe.");
        }

        public void MethodeMitParameter()
        {
            GibAus("irgend ein String-Wert");
        }

        private void GibAus(string name) // Ein Parameter vom Typ string; kein Rückgabewert
        {
            Console.WriteLine($"Ausgabe: {nameof(name)} = {name}");
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        public void MethodeMitRückgabewert()
        {
            int sieben = FordereZahlSiebenAn();
            sieben = FordereZahlSiebenAnExpressionBodiedMemberSchreibweise();
            Console.WriteLine($"{nameof(sieben)} = {sieben}");
        }

        private int FordereZahlSiebenAn() // Keine Parameter, aber ein Rückgabewert
        {
            return 7;
        }

        // "Expression-bodied members"-Syntax seit C# 6 (2015) und C# 7 (2017)
        private int FordereZahlSiebenAnExpressionBodiedMemberSchreibweise() => 7;

        public void MethodeMitRückgabewertUndJederPfadMussEinReturnHaben()
        {
            int resultat = Addiere(1, 2);
            Console.WriteLine($"{nameof(resultat)} = {resultat}");
            int maximum = GibMaximumZurück(8, 3);
            Console.WriteLine($"{nameof(maximum)} = {maximum}");
            ThrowZähltAlsEinReturn();
        }

        private int Addiere(int summand1, int summand2) // Mehrere Parameter und ein Rückgabewert
        {
            int summe = summand1 + summand2;
            return summe;
        }

        private int GibMaximumZurück(int zahl1, int zahl2) // Wenn ein Rückgabewert definiert ist, muss jeder Codepfad ein return haben
        {
            if (zahl1 > zahl2)
            {
                return zahl1;
            }
            else
            {
                return zahl2;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/16854308/do-i-need-a-return-after-throwing-exception-c-and-c
        /// </summary>
        /// <returns>A fake exception for demo purposes.</returns>
        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private int ThrowZähltAlsEinReturn()
        {
            throw new Exception("Statt dem return wird auch ein throw als return-Wert akzeptiert");
        }
    }
}