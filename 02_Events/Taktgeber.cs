namespace _02_Events
{
    public class Taktgeber
    {
        public delegate void TickHandler(Taktgeber sender, TickEventArgs args);
        public event TickHandler Tick;
        public int Interval { get; set; }

        public void Start()
        {
            while (true) // Vorsicht Unendlichschlaufe. Programm muss abgeschossen werden.
            {
                Thread.Sleep(Interval);
                TickEventArgs args = new TickEventArgs { Interval = Interval, Time = DateTime.UtcNow };
                if (Tick != null)   // Siehe Blitz-Icon für Events bei IntelliSense.
                    // Ohne diesen Null-Check käme es zu einer Exception, wenn
                    // Start() aufgerufen würde, ohne vorher einen Listener
                    // anzuhängen.
                {
                    Tick(this, args);
                }
                //Tick?.Invoke(this, args); // Obige if-Klausel kann man auch vereinfacht so schreiben
            }
        }
    }
}