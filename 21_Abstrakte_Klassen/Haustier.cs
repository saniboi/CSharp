namespace _21_Abstrakte_Klassen
{
    public abstract class Haustier
    {
        public abstract void MachGeräusch();  // Keine Implementierung für die Methode vorhanden
        // Die ableitenden Klassen müssen für eine Implementierung sorgen
        // Das "virtual"-Schlüsselwort ist nicht nötig (per Sprachdefinition verboten),
        // aber "abstract" ist implizit "virtual"
    }
}