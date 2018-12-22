using System;

namespace Events
{
    public delegate void WorkPerformHandler(object sender, WorkPerformHandlerArgs workPerformeHandlerArgs);

    public class Worker
    {
        public event WorkPerformHandler PerformWork;

        public virtual void DoWork(int hours, WorkType workType)
        {
            Console.WriteLine("I am working...");
            OnPerformedAction(this, new WorkPerformHandlerArgs(hours, workType));
        }

        protected virtual void OnPerformedAction(object sender, WorkPerformHandlerArgs workPerformeHandlerArgs)
        {
            if (PerformWork is WorkPerformHandler workPerformHandler)
            {
                workPerformHandler(this, workPerformeHandlerArgs);
            }
        }
    }

    public class WorkPerformHandlerArgs : EventArgs
    {
        public WorkPerformHandlerArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }

        public int Hours { get; set; }

        public WorkType WorkType { get; set; }
    }
}
