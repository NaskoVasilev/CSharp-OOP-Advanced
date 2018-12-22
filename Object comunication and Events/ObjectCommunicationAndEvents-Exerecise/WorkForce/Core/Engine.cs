using System;
using System.Collections.Generic;
using System.Text;
using WorkForce.Models;

namespace WorkForce.Core
{
    public class Engine
    {
        private Dictionary<string, Employee> employees;
        private JobManager jobManager;

        public Engine(JobManager jobManager)
        {
            this.employees = new Dictionary<string, Employee>();
            this.jobManager = jobManager;
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string command = data[0];
                string name = "";

                switch (command)
                {
                    case "Job":
                        string nameOfJob = data[1];
                        int hoursOfWorkRequired = int.Parse(data[2]);
                        string employeeName = data[3];
                        Employee employee = this.employees[employeeName];

                        Job job = new Job(employee, nameOfJob, hoursOfWorkRequired);
                        this.jobManager.AddJob(job);
                        break;
                    case "StandardEmployee":
                        name = data[1];
                        this.employees.Add(name, new StandardEmployee(name));
                        break;
                    case "PartTimeEmployee":
                        name = data[1];
                        this.employees.Add(name, new PartTimeEmployee(name));
                        break;
                    case "Pass":
                        this.jobManager.UpdateJobs();
                        break;
                    case "Status":
                        string output = jobManager.GetJobsStatus();
                        Console.WriteLine(output);
                        break;
                }

            }
        }
    }
}
