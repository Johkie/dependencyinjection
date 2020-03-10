using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DI_WebAPI.DataReader
{

    public interface IFileLoader
    {
        string LoadFile();
    }

    public class FileLoader : IFileLoader
    {
        string _filePath;

        public FileLoader(string filePath)
        {
            _filePath = filePath;
        }

        public string LoadFile()
        {
            using (var reader = new StreamReader(_filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
