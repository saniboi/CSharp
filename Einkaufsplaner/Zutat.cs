
namespace Einkaufsplaner
{
    public class Zutat
    {
        public string Zutatname { get; set; }
        public double Menge { get; set; }
        public EnumEinheit Einheit { get; set; }

        public override string ToString()
        {
            return $"{Zutatname}" + $"{Menge}" + $"{Einheit}";
        }
    }
}
