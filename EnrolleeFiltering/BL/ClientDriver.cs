using EnrolleeFiltering.Interfaces;
using EnrolleeFiltering.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnrolleeFiltering.BL
{
    public class ClientDriver : IExecutor
    {
        public void Execute()
        {
            ISortEnrollees sorting = new EnrolleeSort();
            IList<Enrollee> list = sorting.enrolleeList().OrderBy(n => n.Provider).ToList();
            string path = @"../../../Filtered/";
            string tempProvider = string.Empty;

            // pre empty the folder
            PreDeleteFiles(path);

            foreach (Enrollee en in list)
            {
                try
                {
                    string fileName = en.Provider + ".txt";
                    string name = en.Name;
                    string content = en.userId + "," + name + "," + en.Provider + "," + en.Version + Environment.NewLine;

                    File.AppendAllText(path + fileName, content);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }               
               
            }
        }
        private void PreDeleteFiles(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
                File.Delete(filePath);
        }
    }
}
