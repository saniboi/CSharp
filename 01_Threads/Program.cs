using System;
using System.Threading;

namespace _01_Threads
{
    public class Program
    {
        /// <summary>
        /// Die zwei Delgates sind
        /// 
        /// public delegate void ThreadStart();
        /// public delegate void ParametrizedThreadStart(object obj);
        ///
        /// Thread thread = new Thread(...) kann nur eine dieser beiden Delegate übergeben bekommen.
        /// 
        /// Thread thread = new Thread(new ThreadStart(...))
        /// Thread thread = new Thread(new ParametrizedThreadStart(...))
        ///
        /// Thread thread = new Thread(DoSomething) geht auch, weil DoSomething in ThreadStart umgewandelt wird
        /// 
        /// </summary>
        public static void Main()
        {
            int beispiel = 2;

            var p = new Program();

            switch (beispiel)
            {
                case 1:
                    p.StartThreadWithoutParameter();
                    return;
                case 2:
                    p.StartThreadWithParameter();
                    return;
                case 3:
                    p.StartThreadWithParameterWithLambda();
                    return;
                case 4:
                    p.DisplayThreadId();
                    return;
                case 5:
                    p.PutThreadToSleep();
                    return;
                case 6:
                    p.SetThreadPriority();
                    return;
            }
            // Für die restlichen Beispiele siehe Lösungen der Übungen von 5.1 bis 5.7
        }

        #region StartThreadWithoutParameter

        /// <summary>
        /// Beachte in der Ausgabe, wie der Code von StartThreadWithoutParameter mitten drin irgendwo gestoppt wird und Code von DoSomething startet.
        /// Und dasselbe auch umgekehrt. D.h. mental kann man sich keinen linearen Fluss durch die Codeblöcke vorstellen.
        ///
        /// Beispiel: Nach einer Ausführung von
        /// Console.Write(".");
        /// kann z.B. die Zeile
        /// Console.WriteLine($"Thread 2: {i}");
        /// ausgeführt werden.
        /// </summary>
        private void StartThreadWithoutParameter()     // Thread 1 starten
        {
            // Console console1 = new Console();
            // console1.Color = green

            ThreadStart myDelegate = DoSomething;
            Thread thread = new Thread(myDelegate);

            //Thread thread = new Thread(DoSomething); // Obiges ginge auch in einer Zeile; DoSomething wird automatisch in ThreadStart konvertiert:

            thread.Start();                            // Thread 2 starten

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write("a");
                }

                lock (new object())
                {
                    Console.WriteLine(); // Atomar
                    // Change color // Atomar
                }


                Console.WriteLine($"Thread 1: {i}");
            }
        }

        private void DoSomething()
        {
            // Console console2 = new Console();
            // console2.Color = blue

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write("b");
                }
                Console.WriteLine();
                // Change Color 2
                Console.WriteLine($"Thread 2: {i}");
            }
        }

        #endregion

        #region StartThreadWithParameter

        private void StartThreadWithParameter()
        {
            ParameterizedThreadStart myDelegate = new ParameterizedThreadStart(DoSomething2);
            Thread thread = new Thread(myDelegate);
            thread.Start("x");              // Thread 2 starten; mit Parameterübergabe; Start("/") übergibt "/" an DoSomething2("/")

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 1: {i}");
            }
        }

        private void DoSomething2(object obj)       // Beachte: Der übergebene Parameter ist vom Typ object: https://docs.microsoft.com/en-us/dotnet/api/system.threading.parameterizedthreadstart?view=netframework-4.8
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write((string)obj);
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 1: {i}");
            }
        }

        #endregion

        #region StartThreadWithParameterWithLambda

        private void StartThreadWithParameterWithLambda()
        {
            Console.WriteLine("StartThreadWithParameterWithLambda()");
            ParameterizedThreadStart myDelegate = parameter => // Lambda anstatt einer Methode
                                                               // Nur empfohlen, wenn die Logik nur ein paar Zeilen
                                                               // lang ist
                                                               //
                                                               // ReSharper schlägt vor eine lokale Funktion (ein C# 7.0 Feature) zu verwenden
                                                               // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
            {
                for (int i = 0; i <= 100; i++)
                {
                    for (int k = 0; k <= 20; k++)
                    {
                        Console.Write((string)parameter);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Thread 1: {i}");
                }
            };

            Thread thread = new Thread(myDelegate);
            thread.Start("/");              // Thread 2 starten

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 1: {i}");
            }
        }

        #endregion
        
        #region DisplayThreadId

        private void DisplayThreadId()      // Thread 1
        {
            ThreadStart myDelegate = new ThreadStart(DoSomething4);
            Thread thread = new Thread(myDelegate);
            thread.Start();                 // Thread 2 starten

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    // Nothing
                }
                Console.WriteLine($"Thread 1: ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Thread 1: GetHashCode()   = {Thread.CurrentThread.ManagedThreadId.GetHashCode()}"); // The hash code is not guaranteed to be unique. Use the ManagedThreadId property if you need a unique identifier for a managed thread.
                                                                                                                        // https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.gethashcode?view=netframework-4.8
            }
        }

        private void DoSomething4()
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    // Nothing
                }
                Console.WriteLine($"Thread 2: ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Thread 2: GetHashCode()   = {Thread.CurrentThread.ManagedThreadId.GetHashCode()}");

            }
        }

        #endregion

        #region PutThreadToSleep()

        private void PutThreadToSleep()     // Thread 1
        {
            ThreadStart myDelegate = new ThreadStart(DoSomething5);
            Thread thread = new Thread(myDelegate);
            thread.Start();                 // Thread 2 starten

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 1: {i}");
            }
        }

        private void DoSomething5()
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Thread.Sleep(10); // 1000ms = 1 Sekunde
                    Console.Write("X");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 2: {i}");
            }
        }

        #endregion

        #region SetThreadPriority()

        private void SetThreadPriority()                           // Thread 1
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest; // Priorität setzten via statischer Methode (1/2)

            ThreadStart myDelegate = new ThreadStart(DoSomething6);
            Thread thread = new Thread(myDelegate);
            thread.Priority = ThreadPriority.Highest;              // Priorität setzen via Eigenschaft (2/2)
            thread.Start();                                        // Thread 2 starten

            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 1: {i}");
            }
        }

        private void DoSomething6()
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 0; k <= 20; k++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
                Console.WriteLine($"Thread 2: {i}");
            }
        }

        #endregion
    }
}