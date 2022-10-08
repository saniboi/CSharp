namespace _16_Vererbung_new
{
    public class Parent
    {
        public void WriteHello()
        {
            Console.WriteLine("Parent → Hello");
        }

        public virtual void WriteSeeYou()
        {
            Console.WriteLine("Parent → See you");
        }
    }
}