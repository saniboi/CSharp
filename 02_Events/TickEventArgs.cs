namespace _02_Events
{
    public class TickEventArgs : EventArgs
    {
        public int Interval { get; set; }
        public DateTime Time { get; set; }
    }
}