namespace _15_Polymorphie_mit_Vererbung
{
    public class Haustier
    {
        //public override string ToString()
        //{
        //    return "Ich bin ein Haustier.";
        //}

        /// <summary>
        /// Zuerst versuchen ohne virtual die Methode in der Unterklasse
        /// zu überschreiben → Der Kompiler sagt, dass Method-Hiding stattfindet
        /// und man darum explizit das new-Schlüsselwort benutzen muss.
        /// Und in der TiergeräuschMachen-Methode wird immer die Machgeräusch-Methode
        /// von Haustier aufgerufen, egal welche Unterklasse man hineingibt.
        /// </summary>
        public virtual string MachGeräusch()
        {
            return "Für ein Haustier ist kein Geräusch definiert. Benutzen Sie eine Subklasse.";
        }
    }
}