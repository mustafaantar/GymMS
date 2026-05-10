using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Booking : BaseEntity
    {
        //variable members
        DateTime bookingDate;
        int memberId;
        int trainerId;


        //Properties for Encapsulation
        public DateTime BookingDate { get { return bookingDate; } set { bookingDate = value; } }
        public Member Member { get { return new Member(memberId); } set { memberId = value.Id; } }
        public Trainer Trainer { get { return new Trainer(trainerId); } set { trainerId = value.Id; } }

        //constructors
        public Booking() { }

        public Booking(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //load booking data from database
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //preparing command
                SqlCommand cmd = new SqlCommand("select * from booking where id=@id", con);

                //adding id to command paramenters
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute statement
                SqlDataReader reader = cmd.ExecuteReader();

                //if data exists read it
                if (reader.Read())
                {
                    //asign data into object variable members
                    id = (int)reader["id"];
                    bookingDate = (DateTime)reader["booking_date"];
                    memberId = (int)reader["member_id"];
                    trainerId = (int)reader["trainer_id"];
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
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //preparing insert statement
                string str = "insert into booking (booking_date, member_id, trainer_id, created_by) "
                           + "values(@date, @member, @trainerId, @createdBy)";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, con);

                //adding data into command parameters
                cmd.Parameters.AddWithValue("@date", BookingDate);
                cmd.Parameters.AddWithValue("@member", memberId);
                cmd.Parameters.AddWithValue("@trainer_id", trainerId);
                cmd.Parameters.AddWithValue("@createdBy", userId);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute insert statement
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { con.Close(); }
        }

        public override void UpdateInDB()
        {
            //prepare connection
            SqlConnection con = GymDBConnection;


            try
            {
                //preparing update statement
                string str = "update booking set booking_date=@date, member_id=@memberId, trainer_id=@trainerId where id=@id";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, con);

                //add data to the update statement
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", bookingDate);
                cmd.Parameters.AddWithValue("@memberId", memberId);
                cmd.Parameters.AddWithValue("@trainerId", trainerId);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute select statement
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { con.Close(); }
        }


        public static List<Booking> ListData(int? memberId, int? trainerId, DateTime? fromDate, DateTime? toDate)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            //preparing empty list
            List<Booking> list = new List<Booking>();

            try
            {
                //prepare select statement
                string str = "select * from booking where "
                    + "(member_id= @memberId or @memberId is null)"
                    + "(trainer_id= @trainerId or @trainerId is null)"
                    + "(booking_date >= @fromDate or @fromDate is null)"
                    + "(booking_date <= @toDate or @toDate is null)";

                SqlCommand comm = new SqlCommand(str, con);

                comm.Parameters.AddWithValue("@memberId", !memberId.HasValue ? (object)DBNull.Value : memberId);
                comm.Parameters.AddWithValue("@trainerId", !trainerId.HasValue ? (object)DBNull.Value : trainerId);
                comm.Parameters.AddWithValue("@fromDate", !fromDate.HasValue ? (object)DBNull.Value : fromDate);
                comm.Parameters.AddWithValue("@toDate", !toDate.HasValue ? (object)DBNull.Value : toDate);


                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Booking b = new Booking();

                    //assign data to object variables
                    b.id = (int)reader["id"];
                    b.bookingDate = (DateTime)reader["booking_date"];
                    b.memberId = (int)reader["member_id"];
                    b.trainerId = (int)reader["trainer_id"];

                    //add the object to list
                    list.Add(b);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { con.Close(); }

            //return results
            return list;
        }

        public override string ToString()
        {
            //overrided method to display booking No.
            return this.id + "/" + this.Member.FullName;
        }
    }
}