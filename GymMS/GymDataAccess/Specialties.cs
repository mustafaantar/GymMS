using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    using System.CodeDom;
    using System.Data.SqlClient;

    public class Specialties : BaseEntity
    {
        //variable members
        string specialtyName { get; set; }
        //Properties for Encapsulation
        public string SpecialtyName { get { return specialtyName; } set { specialtyName = value; } }

        //constructors
        public Specialties() { }

        public Specialties(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            try
            {
                //preparing select statement
                SqlCommand cmd = new SqlCommand("select * from specialties where id=@id", GymDBConnection);
                //add parameter value
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //execute select statement
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    id = (int)reader["id"];
                    specialtyName = reader["specialty_name"].ToString();
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

        }

        public override void AddToDB(int userId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                "insert into specialties (specialty_name, created_by, creation_date) values (@name, @createdBy, @creationDate)", GymDBConnection);

                //add parameter values
                cmd.Parameters.AddWithValue("@name", specialtyName);
                cmd.Parameters.AddWithValue("@created_by", userId);
                cmd.Parameters.AddWithValue("@creation_date", creationDate);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //execute insert statement
                cmd.ExecuteNonQuery();

            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

        }

        public override void UpdateInDB()
        {
            try
            {
                //preparing command
                SqlCommand cmd = new SqlCommand("update specialties set specialty_name=@name where id=@id", GymDBConnection);

                //add parameter values
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", specialtyName);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //execute update statement
                cmd.ExecuteNonQuery();

            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

        }

        public static List<Specialties> ListData()
        {
            //create empty list
            List<Specialties> list = new List<Specialties>();

            //prepare select statement
            string str = "select * from specialties";

            //preparing command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            try
            {
                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Specialties s = new Specialties();

                    //Assign data into object
                    s.id = (int)reader["id"];
                    s.specialtyName = reader["specialty_name"].ToString();

                    //Add object to list
                    list.Add(s);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

            return list;
        }
        public override string ToString()
        {
            //overridded method to display specialty name
            return this.specialtyName;
        }
    }
}