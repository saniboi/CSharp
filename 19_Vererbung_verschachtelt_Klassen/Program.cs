namespace _19_Vererbung_verschachtelt_Klassen
{
    public class Program
    {
        public static void Main()
        {
            Bank.Account a = new Bank.Account(); // Zugreifbar, weil public
            //Bank.AccountNumberGenerator b = Bank.AccountNumberGenerator // Gesperrt, weil privat
        }
    }
}