using System;

namespace Delegates
{
    class Delegates
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        public delegate int Operation(int firstNumbet, int secondNumber);

        static void Main(string[] args)
        {
            WorkPerformedHandler methodDelagete = new WorkPerformedHandler(PerformWork);
            methodDelagete += PerformSecondWork;
            WorkPerformedHandler thirdDelagate = PerformThirddWork;
            methodDelagete += thirdDelagate;
            methodDelagete(150, WorkType.Programmer);

            Console.WriteLine();
            Console.WriteLine("Another way of invocation");
            //DoWork(methodDelagete, 150, WorkType.Teacher);
            DoWork(thirdDelagate, 200, WorkType.Teacher);

            Operation add = (int a, int b) => a + b;
            Operation multiply = (int a, int b) => a * b;
            Operation subtract = (int a, int b) => a - b;

            Console.WriteLine();
            Console.WriteLine("Operations:");
            Console.WriteLine(add(10, 5));
            Console.WriteLine(multiply(10, 5));
            Console.WriteLine(subtract(10, 5));
        }

        public static void DoWork(WorkPerformedHandler handler,int hours,WorkType workType)
        {
            handler(hours, workType);
        }

        public static void PerformWork(int workHours, WorkType workType)
        {
            Console.WriteLine($"Work performed for {workHours} hours!");
        }

        public static void PerformSecondWork(int workHours, WorkType workType)
        {
            Console.WriteLine($"Second work performed for {workHours} hours!");
        }

        public static void PerformThirddWork(int workHours, WorkType workType)
        {
            Console.WriteLine($"Third work performed for {workHours} hours!");
        }
    }
}
