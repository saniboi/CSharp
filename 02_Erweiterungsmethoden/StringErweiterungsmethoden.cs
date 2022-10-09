namespace _02_Erweiterungsmethoden
{
    // Klasse muss statisch sein
    public static class StringErweiterungsmethoden
    {
        public static string F�geBegr�ssungHinzu(this string nameDerPerson) // Schl�sselwort "this" steht vor dem Parametertyp.
                                                                            // Parametertyp nach "this" gibt an auf welchen
                                                                            // Typ diese Erweiterungsmethode anwendbar ist.
        {
            return $"Hallo, {nameDerPerson}!";
        }
    }
}