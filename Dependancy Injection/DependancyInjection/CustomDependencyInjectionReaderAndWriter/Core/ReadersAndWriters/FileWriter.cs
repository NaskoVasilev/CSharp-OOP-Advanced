using CustomDependencyInjectionReaderAndWriter.Core.Contracts;
using System.IO;

namespace CustomDependencyInjectionReaderAndWriter.Core.ReadersAndWriters
{
    public class FileWriter : IWriter
    {
        private const string filePath = "log.txt";

        public void Write(string content)
        {
            File.AppendAllText(filePath, content);
        }
    }
}
