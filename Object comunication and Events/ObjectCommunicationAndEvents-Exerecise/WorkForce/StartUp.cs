using System;
using WorkForce.Core;

namespace WorkForce
{
    class StartUp
    {
        static void Main(string[] args)
        {
            JobManager jobManager = new JobManager();

            Engine engine = new Engine(jobManager);
            engine.Run();
        }
    }
}
