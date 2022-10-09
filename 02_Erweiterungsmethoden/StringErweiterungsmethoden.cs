namespace _02_Erweiterungsmethoden
{
    // Klasse muss statisch sein
    public static class StringErweiterungsmethoden
    {
        public static string FügeBegrüssungHinzu(this string nameDerPerson) // Schlüsselwort "this" steht vor dem Parametertyp.
                                                                            // Parametertyp nach "this" gibt an auf welchen
                                                                            // Typ diese Erweiterungsmethode anwendbar ist.
        {
            return $"Hallo, {nameDerPerson}!";
        }
    }
}