using ReaderAndWriter.Core.Contracts;
using System.IO;

namespace ReaderAndWriter.Core
{
    public class FileWriter : IWriter
    {
        private const string filePath = "log.txt";

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }
    }
}
