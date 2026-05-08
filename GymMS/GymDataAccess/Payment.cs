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
        int memberId;
        decimal amount;

        //properties (Encapsulation)
        public DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; } }
        public Member Member { get { return new Member(memberId); } }
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
                    id = (int)datareader["id"];
                    paymentDate = (DateTime)datareader["payment_date"];
                    memberId = (int)datareader["member_id"];
                    amount = (decimal)datareader["amount"];
                    createdBy = (int)datareader["created_by"];
                    creationDate = (DateTime)datareader["creation_date"];
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
                cmd.Parameters.AddWithValue("@date", paymentDate);
                cmd.Parameters.AddWithValue("@member", memberId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@createdBy", createdBy);

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
                string str = "update payments set payment_date=@date, amount=@amount where id=@id";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", paymentDate);
                cmd.Parameters.AddWithValue("@amount", amount);

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
            string str = "select * from payments where "
                + " (member_id=@memberId or @memberId is null)"
                + " and (payment_date >= @fromDate or @fromDate is null)"
                + " and (payment_date <= @toDate or @toDate is null)";

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
                    p.id = (int)reader["id"];
                    p.paymentDate = (DateTime)reader["payment_date"];
                    p.memberId = (int)reader["member_id"];
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