namespace _22_Interfaces
{
    public class HaustierFabrik
    {
        public static IHaustier[] HoleHaustierListe()
        {
            IHaustier[] haustiere =
            {
                new Hund { Name = "Bello" },
                new Katze { Name = "Miezi" },
                new Hund { Name = "Brutus" }
                // Hier können beliebige neue Haustiere hinzugefügt werden, solange
                // sie das Interface IHaustiert implementieren; und die Program.cs-
                // Klasse muss deswegen nicht angepasst werden!
            };
            return haustiere;
        }
    }
}