using EnrolleeFiltering.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnrolleeFiltering.BL
{
    class FileReader : IFileReader
    {
        public string GetFileContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
