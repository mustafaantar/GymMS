using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Trainer : Person
    {
        string specialization;
        decimal salary;

        public string Specialization { get { return specialization; } }
        public decimal Salary { get { return salary; } }

        public Trainer() { }

        public Trainer(int id)
        {
            LoadById(id);
        }

    }
}