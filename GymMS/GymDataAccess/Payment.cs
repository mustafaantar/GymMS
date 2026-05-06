using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Payment : BaseEntity
    {
        //variable members
        DateTime paymentDate;
        int? memberId;
        decimal amount;

        //properties (Encapsulation)
        public DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; } }
        public int? MemberId { get { return memberId; } set { memberId = value; } }
        public decimal Amount { get { return amount; } set { amount = value; } }

        //constructors
        public Payment() { }

        public Payment(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            try
            {
                //prepare select statement
                SqlCommand cmd = new SqlCommand("select * from payments where id=@id", GymDBConnection);
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                GymDBConnection.Open();

                //execute command
                SqlDataReader datareader = cmd.ExecuteReader();

                //if data exists read it
                if (datareader.Read())
                {
                    //assign data into object
                    Id = (int)datareader["id"];
                    PaymentDate = (DateTime)datareader["payment_date"];
                    MemberId = datareader["member_id"] as int?;
                    Amount = (decimal)datareader["amount"];
                    CreatedBy = (int)datareader["created_by"];
                    CreationDate = (DateTime)datareader["creation_date"];
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
                //prepare insert statement
                string str = "insert into payments (payment_date, member_id, amount, created_by) "
                           + "values(@date, @member, @amount, @createdBy)";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters
                cmd.Parameters.AddWithValue("@date", PaymentDate);
                cmd.Parameters.AddWithValue("@member", (object)MemberId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@amount", Amount);
                cmd.Parameters.AddWithValue("@createdBy", CreatedBy);

                //open connection
                GymDBConnection.Open();

                //execute command
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
                //prepare update statement
                string str = "update payments set payment_date=@date, member_id=@member, amount=@amount where id=@id";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@date", PaymentDate);
                cmd.Parameters.AddWithValue("@member", (object)MemberId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@amount", Amount);

                //open connection
                GymDBConnection.Open();

                //execute command
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }
        }

        public static List<Payment> ListData(int? memberId, DateTime? fromDate, DateTime? toDate)
        {
            //create empty list
            List<Payment> list = new List<Payment>();

            //prepare select statement
            string str = "select * from payments where 1=1";

            //if filter used add it to select statement
            if (memberId.HasValue)
                str += " and member_id=@memberId";
            if (fromDate.HasValue)
                str += " and payment_date >= @fromDate";
            if (toDate.HasValue)
                str += " and payment_date <= @toDate";

            //preparing command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            //add filter to command
            comm.Parameters.AddWithValue("@memberId", !memberId.HasValue ? (object)DBNull.Value : memberId.HasValue);
            comm.Parameters.AddWithValue("@fromDate", !fromDate.HasValue ? (object)DBNull.Value : fromDate.HasValue);
            comm.Parameters.AddWithValue("@toDate", !toDate.HasValue ? (object)DBNull.Value : toDate.HasValue);

            try
            {
                //open connection
                GymDBConnection.Open();

                //execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Payment p = new Payment();

                    //assign data into object
                    p.Id = (int)reader["id"];
                    p.paymentDate = (DateTime)reader["payment_date"];
                    p.memberId = reader["member_id"] as int?;
                    p.amount = (decimal)reader["amount"];

                    //add object to list
                    list.Add(p);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { GymDBConnection.Close(); }

            //return result list
            return list;
        }
    }
}