using CustomLogger.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CustomLogger.Exeptions;

namespace CustomLogger.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtention = "txt";
        private static readonly string DefalutName = $"Log_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
        private static readonly string DefaultPath = $"{Directory.GetCurrentDirectory()}";

        private string name;
        private string path;
        private string extention;

        private StringBuilder content;
        public LogFile()
        {
            Name = DefalutName;
            Extension = DefaultExtention;
            Path = DefaultPath;
            content = new StringBuilder();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFileNameExeption();
                }
                name = value;
            }
        }
        public string Extension
        {
            get => extention;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFileExtentionExeption();
                }
                extention = value;
            }
        }

        public string Path
        {
            get=>path;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFilePathExeption();
                }
                path = value;   
            }
        }





        public int Size => content.Length;

        public void WriteLine(string text)
        {
            content.AppendLine(text);
        }
        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");

        public string Content => content.ToString();
    }
}
