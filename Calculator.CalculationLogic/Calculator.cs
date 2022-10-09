namespace Calculator.CalculationLogic
{
    public class Calculator
    {
        public int Add(int addendA, int addendB)
        {
            //return addendA + addendA; // Ausversehen falsch implementiert, aber der Test findet den Fehler
            return addendA + addendB;
        }

        public int Divide(int dividend, int divisor)
        {
            // Das lässt den Test fehlschlagen, weil wir ein DivideByZeroException erwarten
            // wir aber ein NotImplementedException erhalten
            // throw new System.NotImplementedException();

            // So würde man die Methode normalerweise implementieren.
            // Die if-Klausel ist aber bei der Division durch die Zahl Null
            // nicht nötig, weil C# bereits eine DivideByZeroException wirft.
            //if (divisor == 0) throw new DivideByZeroException("Der Divisor darf nicht 0 sein, war es aber.");

            return dividend / divisor;
        }
    }
}
