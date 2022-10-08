namespace Übung_5_1_Methoden_überladen
{
    public class Kalkulation
    {
        public float Add(int summand1, int summand2)
        {
            return summand1 + summand2;
        }

        public float Add(float summand1, int summand2)
        {
            return summand1 + summand2;
        }

        public float Add(float summand1, float summand2)
        {
            return summand1 + summand2;
        }
    }
}