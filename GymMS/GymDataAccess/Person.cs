using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public abstract class Person : BaseEntity
    {
        //variable members
        string fullName;
        string phoneNumber;
        DateTime? birthDate;

        // Properties for Encapsulation
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public DateTime? BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Person() : base() { }

        public Person(int id)
        {
            LoadById(id);
        }        
    }
}