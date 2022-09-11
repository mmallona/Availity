using System;
using System.Collections.Generic;
using System.Text;

namespace EnrolleeFiltering.Interfaces
{
    interface IFileReader
    {
        string GetFileContent(string path);
    }
}
