namespace _02_Events
{
    public class Program
    {
        public static void Main()
        {
            EventBeispiel();
        }

        private static void EventBeispiel()
        {
            var taktgeber = new Taktgeber { Interval = 2000 };
            var listener = new Listener { Id = 1 };
            listener.Subscribe(taktgeber); // Beachte: der Taktgeber muss seine Listener nicht kennen.
            // Nur die Listener müssen den Taktgeber kennen (lose Kopplung).

            // Weitere Listener an den Taktgeber anhängen
            //var listerner2 = new Listener {Id = 2};
            //listerner2.Subscribe(taktgeber);

            taktgeber.Start();
        }
    }
}