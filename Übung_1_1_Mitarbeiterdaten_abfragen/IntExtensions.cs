namespace Übung_1_1_Mitarbeiterdaten_abfragen
{
    public static class IntExtensions
    {
        // http://www.softwareandfinance.com/CSharp/Count_Digits.html
        public static int HasNumberOfDigits(this int number)
        {
            int numberOfDigits = 0;

            do
            {
                number = number / 10;
                numberOfDigits++;
            } while (number > 0);
            return numberOfDigits;
        }
    }
}