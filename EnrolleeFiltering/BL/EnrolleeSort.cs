using EnrolleeFiltering.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EnrolleeFiltering.BL
{
    class EnrolleeSort : ISortEnrollees
    {
        
        public IList<Enrollee> enrolleeList()
        {
            string path = @"..\..\..\CSV\Enrollees.txt";
            string content = new FileReader().GetFileContent(path);
            IList<Enrollee> enrolleeList = new List<Enrollee>();
            string[] lines = content.Split('\r');

            foreach(string line in lines)
            {                
                string[] fields = line.Replace("\n", "").Split(',');
                Enrollee enrollee = new Enrollee()
                {
                    userId = fields[0],
                    Name = fields[1],
                    Version = string.IsNullOrEmpty(fields[2]) == false ? Int32.Parse(fields[2]) : 0,
                    Provider = fields[3]
                };
                enrolleeList.Add(enrollee);                
            }

            var list = (from s in enrolleeList
                       group s by s.Name into stugrp
                       let topp = stugrp.Max(x => x.Version)
                       select new Enrollee
                       {
                           Provider = stugrp.Select(n => n.Provider).First(),
                           Name = stugrp.First(y => y.Version == topp).Name.Split(" ")[1] + " " +
                                                        stugrp.First(y => y.Version == topp).Name.Split(" ")[0],
                           Version = topp,
                           userId = stugrp.Select(n => n.userId).First()
                       }).OrderBy(n => n.Name).ToList();

            return (IList<Enrollee>)list.ToList();
        }
    }
}
