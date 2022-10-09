using LawOfDemeter.BL;

namespace LawOfDemeter.App
{
    public class A
    {
        public B GetB()
        {
            return new B();
        }
    }
}