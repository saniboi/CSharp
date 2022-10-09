namespace Corona_Tracing_App.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string IdTransmit { get; set; }
        public string IdReceived { get; set; }
        public bool Infected { get; set; }
        public bool Quarantine { get; set; }
    }
}
