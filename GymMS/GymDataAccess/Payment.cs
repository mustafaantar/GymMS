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
        int subscriptionId;
        decimal amount;

        //Properties for Encapsulation
        public DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; } }
        public Subscription Subscription { get { return new Subscription(subscriptionId); } set { subscriptionId = value.Id; } }
        public decimal Amount { get { return amount; } set { amount = value; } }

        //constructors
        public Payment() { }

        public Payment(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //prepare select statement
                SqlCommand cmd = new SqlCommand("select * from payments where id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute command
                SqlDataReader datareader = cmd.ExecuteReader();

                //if data exists read it
                if (datareader.Read())
                {
                    //assign data into object
                    id = (int)datareader["id"];
                    paymentDate = (DateTime)datareader["payment_date"];
                    subscriptionId = (int)datareader["subscription_id"];
                    amount = (decimal)datareader["amount"];
                    createdBy = (int)datareader["created_by"];
                    creationDate = (DateTime)datareader["creation_date"];
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
                //prepare insert statement
                string str = "insert into payments (payment_date, subscription_id, amount, created_by) "
                           + "values(@date, @subscription_id, @amount, @createdBy)";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, con);

                //add parameters
                cmd.Parameters.AddWithValue("@date", paymentDate);
                cmd.Parameters.AddWithValue("@subscription_id", subscriptionId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@createdBy", userId);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute command
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
                //prepare update statement
                string str = "update payments set payment_date=@date, amount=@amount where id=@id";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, con);

                //add parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", paymentDate);
                cmd.Parameters.AddWithValue("@amount", amount);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //execute command
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { con.Close(); }
        }

        public static List<Payment> ListData(int? subscriptionId, DateTime? fromDate, DateTime? toDate)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;


            //create empty list
            List<Payment> list = new List<Payment>();

            try
            {
                //prepare select statement
                string str = "select * from payments where "
                    + " (subscription_id = @subscriptionId or @subscriptionId is null)"
                    + " and (payment_date >= @fromDate or @fromDate is null)"
                    + " and (payment_date <= @toDate or @toDate is null)";

                //preparing command
                SqlCommand comm = new SqlCommand(str, con);

                //add filter to command
                comm.Parameters.AddWithValue("@subscriptionId", !subscriptionId.HasValue ? (object)DBNull.Value : subscriptionId);
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
                    Payment p = new Payment();

                    //assign data into object
                    p.id = (int)reader["id"];
                    p.paymentDate = (DateTime)reader["payment_date"];
                    p.subscriptionId = (int)reader["subscription_id"];
                    p.amount = (decimal)reader["amount"];

                    //add object to list
                    list.Add(p);
                }
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }
            //close connection
            finally { con.Close(); }

            //return result list
            return list;
        }

        public override string ToString()
        {
            //overridded method to display payment No.
            return this.id + "/" + this.subscriptionId + "/" + this.Subscription.Member.FullName;
        }
    }
}