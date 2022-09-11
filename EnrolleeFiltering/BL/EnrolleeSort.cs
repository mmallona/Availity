using EnrolleeFiltering.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EnrolleeFiltering.BL
{
    public class EnrolleeSort : ISortEnrollees
    {
        
        public IList<Enrollee> enrolleeList()
        {
            string path = @"..\..\..\CSV\Enrollees.txt";
            IList<Enrollee> list = null;
            try
            {
                string content = new FileReader().GetFileContent(path);
                IList<Enrollee> enrolleeList = new List<Enrollee>();
                string[] lines = content.Split('\r');

                foreach (string line in lines)
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

                list = SortCandidates(enrolleeList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }           

            return (IList<Enrollee>)list.ToList();
        }
        /// <summary>
        /// The Actual sorting to the list Name and Provider
        /// </summary>
        /// <param name="enrolleeList"></param>
        /// <returns></returns>
        private IList<Enrollee> SortCandidates(IList<Enrollee> enrolleeList)
        {
            IList<Enrollee> final = (from s in enrolleeList
                                    group s by s.Name into stugrp
                                    let topVersion = stugrp.Max(x => x.Version)
                                    select new Enrollee
                                    {
                                        Provider = stugrp.Select(n => n.Provider).First(),
                                        Name = stugrp.First(y => y.Version == topVersion).Name.Split(" ")[1] + " " +
                                                                        stugrp.First(y => y.Version == topVersion).Name.Split(" ")[0],
                                        Version = topVersion,
                                        userId = stugrp.Select(n => n.userId).First()
                                    }).OrderBy(n => n.Name).ToList();

            return final;
        }
    }
}
