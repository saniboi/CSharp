using System.Collections;

namespace Übung_6_1_Mitarbeiterverzeichnis_mit_Hastable
{
    public class Mitarbeiterverzeichnis
    {
        private readonly IDictionary mitarbeiterverzeichnis;

        public Mitarbeiterverzeichnis()
        {
            mitarbeiterverzeichnis = new Hashtable();
        }

        public void FügeMitarbeiterHinzu(Mitarbeiter mitarbeiter)
        {
            mitarbeiterverzeichnis.Add(mitarbeiter.Personalnummer, mitarbeiter);
        }

        /// <summary>
        /// Wenn eine Personalnummer nicht existiert, wird null retourniert.
        /// </summary>
        /// <param name="personalnummer">Personalnummer des gesuchten Mitarbeiters.</param>
        /// <returns>Der Mitarbeiter mit der gesuchten Personalnummer.</returns>
        public object FindeMitarbeiterMitPersonalnummer(int personalnummer)
        {
            return mitarbeiterverzeichnis[personalnummer];
        }

        public ArrayList FindeMitarbeiterMitVornamen(string vorname)
        {
            ArrayList listeDerMitarbeiterMitGesuchtemVornamen = new ArrayList();

            foreach (DictionaryEntry entry in mitarbeiterverzeichnis)
            {
                object value = entry.Value;
                Mitarbeiter mitarbeiter = (Mitarbeiter)value;
                if (mitarbeiter?.Vorname == vorname) // Possible NullReferenceException abfangen
                {
                    listeDerMitarbeiterMitGesuchtemVornamen.Add(value);
                }
            }

            return listeDerMitarbeiterMitGesuchtemVornamen;
        }
    }
}