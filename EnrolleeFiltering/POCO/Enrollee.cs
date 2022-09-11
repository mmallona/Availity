using System;
using System.Collections.Generic;
using System.Text;

namespace EnrolleeFiltering.POCO
{
    public class Enrollee
    {
        public string userId { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }

        public string Provider { get; set; }
    }
}
