using EnrolleeFiltering.BL;
using EnrolleeFiltering.Interfaces;
using EnrolleeFiltering.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace AvailityTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EnrolleeList()
        {
            //set up
            ISortEnrollees enrolle = new EnrolleeSort();

            //arrange
            IList<Enrollee> list = enrolle.enrolleeList();

            //test
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void Driver()
        {
            //set up
            string path = @"../../../Filtered/";
            IExecutor driver = new ClientDriver();

            //arrange
            driver.Execute();

            //test
            string[] filePaths = Directory.GetFiles(path);

            Assert.IsTrue(filePaths.Length > 0);
        }

    }
}