using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GymDataAccess
{
    public class Member : Person//inherits from Person
    {
        //variable members
        DateTime startDate;
        DateTime? endDate;

        // Properties for Encapsulation
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        //constructors

        //for new objects
        public Member() { }

        //for existing data
        public Member(int id)
        {
            LoadById(id);
        }

        //copy constructor
        public Member(Member copyMember)
        {
            this.id = copyMember.id;
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;
            
            //read object data and assign it to the variable members
            try
            {
                //prepare select statement
                string str = "select * from members where id=@id";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, con);

                //add parameters to command
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                con.Open();

                //Execute select statement
                SqlDataReader reader = cmd.ExecuteReader();

                //if data exists read it
                if (reader.Read())
                {
                    //Assign data into object
                    this.id = (int)reader["id"];
                    FullName = reader["full_name"].ToString();
                    PhoneNumber = reader["phone_pumber"].ToString();
                    BirthDate = (DateTime)reader["birth_date"];
                    startDate = (DateTime)reader["start_date"];
                    endDate = reader["end_date"] as DateTime?;
                    createdBy = (int)reader["created_by"];
                    creationDate = (DateTime)reader["creation_date"];
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { con.Close(); }
        }

        public override void AddToDB(int userId)
        {
            //add a new object to the database
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //prepare insert statement
                string str = "insert into members "
                    + "(full_name, phone_pumber, birth_date, start_date, created_by, end_date)"
                    + "values (@name,@phone,@birthDate,@startDate,@createdBy,@endDate)";

                //preparing command
                SqlCommand comm = new SqlCommand(str, con);

                //add parameters to command
                comm.Parameters.AddWithValue("@name", FullName);
                comm.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                comm.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@startDate", StartDate);
                comm.Parameters.AddWithValue("@createdBy", userId);
                comm.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                con.Open();

                //Execute insert statement
                comm.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { con.Close(); }
        }

        public override void UpdateInDB()
        {
            //update existsing data in the database
            //prepare connection
            SqlConnection con = GymDBConnection;


            try
            {
                //prepare update statement
                string str = @"update members set
                            full_name=@name, phone_pumber=@phone, birth_date=@birthDate,
                            start_date=@startDate, end_date=@endDate
                            where id=@id";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, con);

                //add parameters to command
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", FullName);
                cmd.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@startDate", StartDate);
                cmd.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute update statement
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { con.Close(); }
        }

        public override string ToString()
        {
            //overridded method to display member name
            return base.ToString();
        }
    }
}