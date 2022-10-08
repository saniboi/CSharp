using System;
using Übung_3_3_Geometrische_Formen.Formen;

namespace Übung_3_3_Geometrische_Formen
{
    public class TestTreiber
    {
        private readonly IForm[] geometrischeFormenListe;

        public TestTreiber(IForm[] listeVonFormen)
        {
            geometrischeFormenListe = listeVonFormen;
        }

        public void DruckeDieListeDerFormen()
        {
            foreach (IForm geometrischeForm in geometrischeFormenListe)
            {
                Drucke(geometrischeForm);
            }
        }

        private void Drucke(IForm geometrischeForm)
        {
            IForm form = geometrischeForm;
            string t = geometrischeForm.GetType().Name;
            double f = geometrischeForm.BerechneFläche();
            double u = geometrischeForm.Umfang;

            Console.WriteLine($"{form,-23} |Typ = {t,-15} | Fläche = {f,5:F2} | Umfang = {u,5:F2}");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
    }
}