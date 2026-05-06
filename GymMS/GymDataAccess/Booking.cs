using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    namespace GymDataAccess
    {
        public class Booking : BaseEntity
        {
            //variable members
            DateTime bookingDate;
            int? memberId;
            int? classId;


            //properties
            public DateTime BookingDate { get { return bookingDate; } set { bookingDate = value; } }
            public int? MemberId { get { return memberId; } set { memberId = value; } }
            public int? ClassId { get { return classId; } set { classId = value; } }

            //constructors
            public Booking() { }

            public Booking(int id)
            {
                LoadById(id);
            }

            public override void LoadById(int id)
            {
                //load booking data from database
                try
                {
                    //preparing command 
                    SqlCommand cmd = new SqlCommand("select * from booking where id=@id", GymDBConnection);

                    //adding id to command paramenters
                    cmd.Parameters.AddWithValue("@id", id);

                    //open connection
                    GymDBConnection.Open();

                    //execute statement
                    SqlDataReader reader = cmd.ExecuteReader();

                    //if data exists read it
                    if (reader.Read())
                    {
                        //asign data into object variable members
                        Id = (int)reader["id"];
                        bookingDate = (DateTime)reader["booking_date"];
                        memberId = reader["member_id"] as int?;
                        classId = reader["class_id"] as int?;
                        CreatedBy = (int)reader["created_by"];
                        CreationDate = (DateTime)reader["creation_date"];
                    }
                }
                //any exception throw it to up level
                catch (Exception ex) { throw ex; }
                //close connection
                finally { GymDBConnection.Close(); }
            }

            public override void AddToDB()
            {
                try
                {
                    //preparing insert statement
                    string str = "insert into booking (booking_date, member_id, class_id, created_by) "
                               + "values(@date, @member, @class, @createdBy)";

                    //preparing command
                    SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                    //adding data into command parameters
                    cmd.Parameters.AddWithValue("@date", BookingDate);
                    cmd.Parameters.AddWithValue("@member", (object)MemberId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@class", (object)ClassId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@createdBy", CreatedBy);

                    //open connection
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
                //preparing update statement
                    string str = "update booking set booking_date=@date, member_id=@member, class_id=@class where id=@id";

                    //preparing command
                    SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                    //add data to the update statement
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@date", BookingDate);
                    cmd.Parameters.AddWithValue("@member", (object)MemberId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@class", (object)ClassId ?? DBNull.Value);

                    //open connection
                    GymDBConnection.Open();

                    //execute select statement
                    cmd.ExecuteNonQuery();
                }
                //any exception throw it to up level
                catch (Exception ex) { throw ex; }
                //close connection
                finally { GymDBConnection.Close(); }
            }


            public static List<Booking> ListData(DateTime? fromDate)
            {
                //preparing empty list
                List<Booking> list = new List<Booking>();

                //prepare select statement
                string str = "select * from booking where 1=1 ";

                //if from date filter used add it to the statement
                if (!fromDate.HasValue)
                    str += " and  booking_date >= @fromDate";

                SqlCommand comm = new SqlCommand(str, GymDBConnection);

                comm.Parameters.AddWithValue("@fromDate",!fromDate.HasValue ? (object)DBNull.Value : fromDate);

                try
                {
                    //open connection
                    GymDBConnection.Open();

                    //execute select statement
                    SqlDataReader reader = comm.ExecuteReader();

                    //if data exists read it
                    while (reader.Read())
                    {
                        Booking b = new Booking();
                        
                        //assign data to object variables
                        b.Id = (int)reader["id"];
                        b.bookingDate = (DateTime)reader["booking_date"];
                        b.memberId = reader["member_id"] as int?;
                        b.classId = reader["class_id"] as int?;

                        //add the object to list
                        list.Add(b);
                    }
                }
                //any exception throw it to up level
                catch (Exception ex) { throw ex; }
                //close connection
                finally { GymDBConnection.Close(); }

                //return results
                return list;
            }
        }
    }
}