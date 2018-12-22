namespace FestivalManager.Core
{
    using System;
    using System.Linq;

    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(' ');

            var commandType = tokens[0];
            string[] args = tokens.Skip(1).ToArray();
            string result = "";

            if (commandType == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                MethodInfo festivalControlerMethod = this.festivalCоntroller
               .GetType()
               .GetMethods()
               .FirstOrDefault(x => x.Name == commandType);

                try
                {
                    result = (string)festivalControlerMethod
                        .Invoke(this.festivalCоntroller, new object[] { args });
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }

            return result;
        }
    }
}