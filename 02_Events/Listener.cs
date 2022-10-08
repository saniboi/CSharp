namespace _02_Events
{
    public class Listener
    {
        public int Id { get; set; }

        public void Subscribe(Taktgeber sender)
        {
            sender.Tick += new Taktgeber.TickHandler(OnTick); // Beachte: keine runden Klammern hinter "new Taktgeber"

            // Beachte: Bei Events geht nur "+=" und kein "=" wie bei Delegates;
            // d.h. ein Listener kann nicht die Abonnemente aller anderen
            // Listener überschreiben.
            //
            // Teste: Lösche oben das "+" bei "+=".
            // Der Kompiler sagt dann: "Error CS0070 The event 'Taktgeber.Tick' can only appear on the left hand side
            // of += or -= (except when used from within the type 'Taktgeber')

        }

        private void OnTick(Taktgeber sender, TickEventArgs args)
        {
            // Hier kommt der Code hin, der ausgeführt werden soll, wenn ein Ereignis ausgelöst wird
            // Exemplarisch implementieren wir ein Console.WriteLine();
            Console.WriteLine($"Listener {Id}: Takt empfangen (Intervall: {args.Interval}, Time: {args.Time})");
        }
    }
}