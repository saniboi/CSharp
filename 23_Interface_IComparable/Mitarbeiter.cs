namespace _23_Interfaces_IComparable
{
    public class Mitarbeiter : IComparable // Den ": IComparable"-Teil auskommentieren und schauen was passiert
        // Folge: Sort() kann nicht mehr sortieren. InvalidOperation-Exception.
    {
        public string Name { get; set; }
        public decimal Lohn { get; set; }

        public int CompareTo(object obj)
        {
            Mitarbeiter that = (Mitarbeiter)obj;
            if (this.Lohn > that.Lohn) return 1;
            if (this.Lohn < that.Lohn) return -1;
            return 0; // if (this.Lohn == that.Lohn) return 0;
        }
    }
}