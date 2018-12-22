using System;

namespace WorkForce.Models
{
    public delegate void CompleteWorkEventHandler(Job job);
    
    public class Job
    {
        private Employee employee;

        public Job(Employee employee, string name, int workHoursRequied)
        {
            this.employee = employee;
            Name = name;
            WorkHoursRequied = workHoursRequied;
        }

        public event CompleteWorkEventHandler CompleteWork;

        public string Name { get; private set; }

        public int WorkHoursRequied { get; private set; }

        public void Update()
        {
            this.WorkHoursRequied -= employee.WorkHoursPerWeek;

            if (this.WorkHoursRequied <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.CompleteWork?.Invoke(this);
            }
        }

        public string GetJobStatus()
        {
            return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequied}";
        }
    }
}
