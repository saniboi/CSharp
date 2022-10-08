using System.Diagnostics.CodeAnalysis;

namespace _13_Structs
{
    class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    StructErzeugenOhneNew();
                    break;
                case 2:
                    StructErzeugenMitNew();
                    break;
            }
        }

        /// <summary>
        /// Beispiel ohne new von http://www.dotnetperls.com/struct
        /// </summary>
        private static void StructErzeugenOhneNew()
        {
            // Create struct on stack
            Simple s;
            s.Position = 1;
            s.Exists = false;
            s.LastValue = 5.5;

            // Write struct field
            Console.WriteLine($"Position {s.Position}");
            Console.WriteLine($"Exists {s.Exists}");
            Console.WriteLine($"LastValue {s.LastValue}");
        }

        struct Simple
        {
            public int Position;
            public bool Exists;
            public double LastValue;
        }

        /// <summary>
        /// Beispiel mit new: https://stackoverflow.com/questions/9207488/what-does-the-keyword-new-do-to-a-struct-in-c
        ///
        /// From struct (C# Reference) on MSDN:
        /// 
        /// When you create a struct object using the new operator, it gets created and the appropriate
        /// constructor is called. Unlike classes, structs can be instantiated without using the new operator.
        /// If you do not use new, the fields will remain unassigned and the object cannot be used until
        /// all of the fields are initialized.
        /// </summary>
        private static void StructErzeugenMitNew()
        {
            Position p1 = new Position(1, 2);
            Position p2;
            p2.X = 3;
            p2.Y = 4;

            Console.WriteLine(p1.X);
            Console.WriteLine(p1.Y);
            Console.WriteLine(p2.X);
            Console.WriteLine(p2.Y);
        }
        struct Position
        {
            public double X;
            public double Y;

            public Position(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}