using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Trainer : Person//inherits from Person
    {
        //variable members
        int specialty_id;

        // Properties for Encapsulation
        public int Specialty_id
        {
            get { return specialty_id; }
            set { specialty_id = value; }
        }

        //constructors

        //for new objects
        public Trainer() { }

        //for existing data
        public Trainer(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //prepare select statement
            SqlCommand comm = new SqlCommand("select * from trainers where id=@id", GymDBConnection);

            //add parameter to command
            comm.Parameters.AddWithValue("@id", id);

            try
            {
                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                GymDBConnection.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                if (reader.Read())
                {
                    //Assign data into object
                    this.id = (int)reader["id"];
                    FullName = reader["full_name"].ToString();
                    PhoneNumber = reader["phone_pumber"].ToString();
                    BirthDate = (DateTime)reader["birth_date"];
                    specialty_id = (int)reader["specialty_id"];
                    createdBy = (int)reader["created_by"];
                    creationDate = (DateTime)reader["creation_date"];
                }
            }
            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override void AddToDB(int userId)
        {
            try
            {
                //prepare insert statement
                string str = "insert into trainers "
                    + "(full_name, phone_pumber, birth_date, specialty_id, created_by)"
                    + "values (@name,@phone,@birthDate,@specialty_id,@createdBy)";

                //preparing command
                SqlCommand comm = new SqlCommand(str, GymDBConnection);

                //add parameters to command
                comm.Parameters.AddWithValue("@name", FullName);
                comm.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                comm.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@specialty_id", specialty_id);
                comm.Parameters.AddWithValue("@createdBy", userId);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                GymDBConnection.Open();

                //Execute insert statement
                comm.ExecuteNonQuery();
            }
            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override void UpdateInDB()
        {
            try
            {
                //prepare update statement
                string str = "update trainers "
                    + "set full_name=@name, phone_pumber=@phone, birth_date=@birthDate,"
                    + "specialty_id=@specialty_id where id=@id";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters to command
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", FullName);
                cmd.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@specialty_id", specialty_id);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //Execute update statement
                cmd.ExecuteNonQuery();
            }
            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override string ToString()
        {
            //overridded method to display trainer name
            return base.ToString();
        }
    }
}