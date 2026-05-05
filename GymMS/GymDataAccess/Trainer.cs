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
        //variable members
        int specialty_id;
        decimal salary;

        //properties
        public int Specialty_id { get { return specialty_id; } }
        public decimal Salary { get { return salary; } }

        //constructors
        public Trainer() { }

        public Trainer(int id)
        {
            LoadById(id);
        }


        
    }
}