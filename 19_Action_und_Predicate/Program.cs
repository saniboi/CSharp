using System;

namespace _19_Action_und_Predicate
{
    public class Program
    {
        public static void Main()
        {
            new Program().RunActionDemo();
            new Program().RunPredicateDemo();
        }

        private void RunActionDemo()
        {
            Console.WriteLine("--- RunActionDemo() ---");

            // Variante 1: mit Referenz auf Methode
            Action<int> myAction = new Action<int>(DoSomethingAction);

            // Variante 2: mit Lambda-Ausdruck
            //Action<int> myAction = new Action<int>(number => Console.WriteLine($"DoSomethingAction: {number}"));

            myAction(1);
        }

        private void DoSomethingAction(int i)
        {
            Console.WriteLine($"DoSomethingAction: {i}");
        }

        private void RunPredicateDemo()
        {
            Console.WriteLine("\n\n--- RunPredicateDemo() ---");

            // Variante 1: mit Referenz auf Methode
            Predicate<string> myPredicate = new Predicate<string>(DoSomethingPredicate);

            // Variante 2: mit Lambda-Ausdruck
            //Predicate<string> myPredicate = new Predicate<string>(parameter => parameter == "Test1");

            bool resultOfPredicateMethode1 = myPredicate("Test1");
            bool resultOfPredicateMethode2 = myPredicate("Test2");

            Console.WriteLine($"resultOfPredicateMethode1: {resultOfPredicateMethode1}");
            Console.WriteLine($"resultOfPredicateMethode2: {resultOfPredicateMethode2}");
        }

        private bool DoSomethingPredicate(string parameter)
        {
            return parameter == "Test1";
        }
    }
}