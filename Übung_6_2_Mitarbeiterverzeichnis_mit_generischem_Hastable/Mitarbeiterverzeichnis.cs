using System.Collections.Generic;

namespace Übung_6_2_Mitarbeiterverzeichnis_mit_generischem_Hastable
{
    public class Mitarbeiterverzeichnis
    {
        private readonly IDictionary<int, Mitarbeiter> mitarbeiterverzeichnis;

        public Mitarbeiterverzeichnis()
        {
            mitarbeiterverzeichnis = new Dictionary<int, Mitarbeiter>(); // http://stackoverflow.com/questions/772831/what-is-the-generic-version-of-a-hashtable
                                                              // Es gibt keinen generischen Hashtable, stattdessen gibt
                                                              // es ein Dictionary<TK, TV>.
                                                              // Zudem ist das Verhalten anders, wenn man auf einen nicht
                                                              // existenten Schlüssel zugreift:
                                                              // - Beim Hashtable kommt null zurück
                                                              // - Beim Dictionary<TK, TV> wird eine KeyNotFoundException geworfen
        }

        public void FügeMitarbeiterHinzu(Mitarbeiter mitarbeiter)
        {
            mitarbeiterverzeichnis.Add(mitarbeiter.Personalnummer, mitarbeiter);
        }

        /// <summary>
        /// Wenn eine Personalnummer nicht existiert, wird eine KeyNotFoundException
        /// geworfen.
        /// </summary>
        /// <param name="personalnummer">Personalnummer des gesuchten Mitarbeiters.</param>
        /// <returns>Der Mitarbeiter mit der gesuchten Personalnummer.</returns>
        public Mitarbeiter FindeMitarbeiterMitMitarbeiternummer(int personalnummer)
        {
            return mitarbeiterverzeichnis[personalnummer];
        }

        public List<Mitarbeiter> FindeMitarbeiterMitVornamen(string vorname)
        {
            List<Mitarbeiter> listeDerMitarbeiterMitGesuchtemVornamen = new List<Mitarbeiter>();

            foreach (KeyValuePair<int, Mitarbeiter> entry in mitarbeiterverzeichnis)
            {
                Mitarbeiter mitarbeiter = entry.Value;
                if (mitarbeiter.Vorname== vorname)
                {
                    listeDerMitarbeiterMitGesuchtemVornamen.Add(mitarbeiter);
                }
            }

            return listeDerMitarbeiterMitGesuchtemVornamen;
        }
    }
}