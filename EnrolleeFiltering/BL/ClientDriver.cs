using EnrolleeFiltering.Interfaces;
using EnrolleeFiltering.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace EnrolleeFiltering.BL
{
    public class ClientDriver : IExecutor
    {
        public void Execute()
        {
            string path  = ConfigurationManager.AppSettings["DataFile"];
            string pathFiltered = ConfigurationManager.AppSettings["Filtered"];
            ISortEnrollees sorting = new EnrolleeSort();
            string tempProvider = string.Empty;
            string content = new FileReader().GetFileContent(path);

            IList<Enrollee> list = sorting.enrolleeList(content).OrderBy(n => n.Provider).ToList();

            // pre empty the folder
            PreDeleteFiles(pathFiltered);

            foreach (Enrollee en in list)
            {
                try
                {
                    string fileName = en.Provider + ".txt";
                    string name = en.Name;
                    string line = en.userId + "," + name + "," + en.Provider + "," + en.Version + Environment.NewLine;

                    File.AppendAllText(pathFiltered + fileName, line);
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
