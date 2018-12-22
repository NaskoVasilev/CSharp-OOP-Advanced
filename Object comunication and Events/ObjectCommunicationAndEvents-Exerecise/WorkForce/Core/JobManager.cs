using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkForce.Models;

namespace WorkForce.Core
{
    public class JobManager : List<Job>
    {
        public void AddJob(Job job)
        {
            job.CompleteWork += RemoveJob;
            this.Add(job);
        }

        public void RemoveJob(Job job)
        {
            this.Remove(job);
        }

        public void UpdateJobs()
        {
            this.ToList().ForEach(j => j.Update());
        }

        public string GetJobsStatus()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Job job in this)
            {
                sb.AppendLine(job.GetJobStatus());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
