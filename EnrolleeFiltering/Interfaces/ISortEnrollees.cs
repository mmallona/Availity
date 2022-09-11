using EnrolleeFiltering.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrolleeFiltering.BL
{
    public interface ISortEnrollees
    {
        IList<Enrollee> enrolleeList();
    }
}
