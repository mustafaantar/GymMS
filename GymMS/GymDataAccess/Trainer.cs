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

        //properties
        public int Specialty_id { get { return specialty_id; } }

        //constructors
        public Trainer() { }

        public Trainer(int id)
        {
            LoadById(id);
        }


        public override void LoadById(int id)
        {
            //Load data from database
            SqlCommand comm = new SqlCommand("select * from trainers where id=@id", GymDBConnection);

            comm.Parameters.AddWithValue("@id", id);

            try
            {
                GymDBConnection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    id = (int)reader["id"];
                    FullName = reader["full_name"].ToString();
                    PhoneNumber = reader["phone_number"].ToString();
                    BirthDate = (DateTime)reader["birth_date"];
                    specialty_id = (int)reader["specialty_id"];
                    createdBy = (int)reader["created_by"];
                    creationDate = (DateTime)reader["creation_date"];
                }
            }
            finally { GymDBConnection.Close(); }
        }

        public override void AddToDB(int userId)
        {
            try
            {
                string str = "insert into trainers "
                    + "(full_name, phone_number, birth_date, specialty_id, created_by)"
                    + "values (@name,@phone,@birthDate,@specialty_id,@createdBy)";
                //method to add data into database
                SqlCommand comm = new SqlCommand(str, GymDBConnection);

                comm.Parameters.AddWithValue("@name", FullName);
                comm.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                comm.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@specialty_id", specialty_id);
                comm.Parameters.AddWithValue("@createdBy", userId);

                GymDBConnection.Open();
                comm.ExecuteNonQuery();
            }
            finally { GymDBConnection.Close(); }
        }

        public override void UpdateInDB()
        {
            try
            {
                //method to edit data into database
                string str = "update trainers "
                    + "set full_name=@name, phone_number=@phone, birth_date=@birthDate,"
                    + "specialty_id=@specialty_id where id=@id";
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", FullName);
                cmd.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@specialty_id", specialty_id);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            finally { GymDBConnection.Close(); }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}