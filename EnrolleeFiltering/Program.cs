using EnrolleeFiltering.BL;
using EnrolleeFiltering.Interfaces;
using System;

namespace EnrolleeFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            IExecutor driver = new ClientDriver();
            driver.Execute();

            Console.WriteLine("Hello World!");
        }
    }
}
