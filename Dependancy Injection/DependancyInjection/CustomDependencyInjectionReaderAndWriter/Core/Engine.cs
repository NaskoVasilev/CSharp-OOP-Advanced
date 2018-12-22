using CustomDependancyInjectionFramework.Attributes;
using CustomDependencyInjectionReaderAndWriter.Core.Contracts;

namespace CustomDependencyInjectionReaderAndWriter.Core
{
    public class Engine : IEngine
    {
        //[Inject]
        //[Named("ConsoleWriter")]
        //private IWriter consoleWriter;

        //[Inject]
        //[Named("FileWriter")]
        //private IWriter fileWriter;

        //[Inject]
        //private IReader reader;

        private IReader reader;
        private IWriter consoleWriter;
        private IWriter fileWriter;

        [Inject]
        public Engine(IReader reader, [Named("ConsoleWriter")] IWriter consoleWriter,
            [Named("FileWriter")] IWriter fileWriter)
        {
            this.reader = reader;
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
        }

        public void Run()
        {
            while (true)
            {
                string content = reader.Read();

                if(content == "exit")
                {
                    break;
                }

                consoleWriter.Write(content);
                fileWriter.Write(content);
            }
        }
    }
}
