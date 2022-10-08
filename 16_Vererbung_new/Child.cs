namespace _16_Vererbung_new
{
    public class Child : Parent
    {
        /// <summary>
        /// Bewusste Überschreibung der Methode der Basisklasse mit new.
        /// Die Methode der Basisklasse wird versteckt.
        /// </summary>
        public new void WriteHello()
        {
            Console.WriteLine("Child  → Hello");
        }

        public override void WriteSeeYou()
        {
            Console.WriteLine("Child  → See you");
        }
    }
}