using System;

namespace Events
{
    public class Events
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        public delegate int Operation(int firstNumbet, int secondNumber);
        public static event WorkPerformedHandler WorkPerformed;

        public static void Main(string[] args)
        {
            WorkPerformed += CompleteWork;
            WorkPerformed(50, WorkType.GenerateReports);

            WorkPerformedHandler delagetMethod = WorkPerformed as WorkPerformedHandler;
            delagetMethod(200, WorkType.DevelopSite);

            Console.WriteLine();
            Console.WriteLine("Worker class handle event!");

            Worker worker = new Worker();

            // worker.PerformWork += Worker_PerformWork;
            worker.PerformWork += new WorkPerformHandler(Worker_PerformWork);
            worker.PerformWork += Worker_PerformWorkPartTwo;
            worker.PerformWork += delegate (object sender, WorkPerformHandlerArgs workPerformHandlerArgs)
            {
                Console.WriteLine(workPerformHandlerArgs.WorkType + " => " + workPerformHandlerArgs.Hours);
            };

            worker.PerformWork += (object sender, WorkPerformHandlerArgs WorkPerformHandlerArgs) =>
                {
                    Console.WriteLine("Uisng lambda function!");
                    Console.WriteLine(WorkPerformHandlerArgs.WorkType + " => " + WorkPerformHandlerArgs.Hours);
                };

            worker.DoWork(200, WorkType.DevelopSoftware);
        }

        private static void Worker_PerformWorkPartTwo(object sender, WorkPerformHandlerArgs workPerformeHandlerArgs)
        {
            Console.WriteLine($"I am waiting for next task!");
        }

        private static void Worker_PerformWork(object sender, WorkPerformHandlerArgs workPerformeHandlerArgs)
        {
            Console.WriteLine($"{workPerformeHandlerArgs.WorkType} performed for {workPerformeHandlerArgs.Hours}");
        }

        public static void CompleteWork(int hours, WorkType workType)
        {
            Console.WriteLine($"{workType} for {hours} hours");
        }

        public void WriteEventInfo(object Sender, EventArgs eventArgs)
        {
            Console.WriteLine("Event info!!!");
        }
    }
}
