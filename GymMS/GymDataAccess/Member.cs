using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Member : Person
    {
        DateTime startDate;
        DateTime? endDate;
        public DateTime StartDate { get { return startDate; } }
        public DateTime? EndDate { get { return endDate; } }

        public Member() { }

        public Member(int id)
        {
            LoadById(id);
        }

    }
}