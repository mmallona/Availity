using EnrolleeFiltering.BL;
using EnrolleeFiltering.Interfaces;
using EnrolleeFiltering.POCO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AvailityTests
{
    public class Tests
    {
        string path = string.Empty;
        string content = string.Empty;
        string pathFiltered = string.Empty;


      [SetUp]
        public void Setup()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", String.Format("{0}\\app.config", AppDomain.CurrentDomain.BaseDirectory));
            path = ConfigurationManager.AppSettings.Get("DataFile");//@"../../../CSV\Enrollees.txt";
            pathFiltered = ConfigurationManager.AppSettings.Get("Filtered");

            content = new FileReader().GetFileContent(path);
        }

        [Test]
        public void EnrolleeList()
        {
            //set up
            ISortEnrollees enrolle = new EnrolleeSort();

            //arrange
            IList<Enrollee> list = enrolle.enrolleeList(content);

            //test
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void Driver()
        {
            //set up
            IExecutor driver = new ClientDriver();

            //arrange
            driver.Execute();

            //test
            string[] filePaths = Directory.GetFiles(pathFiltered);

            Assert.IsTrue(filePaths.Length > 0);
        }

    }
}