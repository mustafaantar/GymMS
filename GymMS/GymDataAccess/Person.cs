using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public abstract class Person : BaseEntity//inherits from BaseEbtry
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

        //constructors
        //for new objects
        public Person() : base() { }

        //for  existing  data
        public Person(int id)
        {
            LoadById(id);
        }

        public static List<Person> ListData(string filter)
        {
            //create empty list
            List<Person> list = new List<Person>();

            //prepare select statement
            string str = "select * from v_persons";

            //if filter used add it to select statement
            if ((filter != null) && (filter != ""))
                str += "where fullname like '%' + @filter + '%'";

            //preparing command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            //add filter to command
            comm.Parameters.AddWithValue("@filter", string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);

            try
            {
                //open connection
                GymDBConnection.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Person p;

                    //create member or trainer object depending on person type
                    if (reader["person_type"].ToString() == "Member")
                        p = new Member();
                    else
                        p = new Trainer();

                    //Assign data into object
                    p.Id = (int)reader["id"];
                    p.FullName = reader["full_name"].ToString();
                    p.PhoneNumber = reader["phone_number"].ToString();
                    p.BirthDate = (DateTime)reader["birth_date"];
                    p.CreatedBy = (int)reader["created_by"];
                    p.CreationDate = (DateTime)reader["creation_date"];

                    //Add object to list
                    list.Add(p);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

            return list;
        }

        public static List<Member> ListMembersData(string filter)
        {
            //create empty list
            List<Member> list = new List<Member>();

            //prepare select statement
            string str = "select * from v_persons";

            //if filter used add it to select statement
            if ((filter != null) && (filter != ""))
                str += "where fullname like '%' + @filter + '%'";

            //preparing command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            //add filter to command
            comm.Parameters.AddWithValue("@filter", string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);

            try
            {
                //open connection
                GymDBConnection.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Person p;

                    //create member or trainer object depending on person type
                    if (reader["person_type"].ToString() == "Trainer")
                        continue;
                    p = new Member();

                    //Assign data into object
                    p.Id = (int)reader["id"];
                    p.FullName = reader["full_name"].ToString();
                    p.PhoneNumber = reader["phone_number"].ToString();
                    p.BirthDate = (DateTime)reader["birth_date"];
                    p.CreatedBy = (int)reader["created_by"];
                    p.CreationDate = (DateTime)reader["creation_date"];

                    //Add object to list
                    list.Add(p);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

            return list;
        }
    }
}
}