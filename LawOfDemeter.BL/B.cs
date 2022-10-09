using LawOfDemeter.DAL;

namespace LawOfDemeter.BL
{
    public class B
    {
        public C GetC()
        {
            return new C();
        }
    }
}