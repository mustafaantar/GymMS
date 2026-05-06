using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Subscription : BaseEntity
    {
        // variable members
        int memberId;
        string subscriptionType;
        decimal subscriptionAmount;
        decimal paidAmount;
        DateTime startDate;
        DateTime? endDate;

        // Properties
        public int MemberId { get { return memberId; } }
        public string SubscriptionType { get { return subscriptionType; } }
        public decimal SubscriptionAmount { get { return subscriptionAmount; } }
        public decimal PaidAmount { get { return paidAmount; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime? EndDate { get { return endDate; } }

        //constructors
        public Subscription() { }

        public Subscription(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //Load object data from the database

            //prepare select statement
            string str = "select * from subscriptions where id=@id";

            //prepare SQL statement
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            //Add parameters to the command (to avoid SQL Injuction
            comm.Parameters.AddWithValue("@id", id);

            try
            {
                //open the connection
                GymDBConnection.Open();

                //execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exist then read it
                if (reader.Read())
                {
                    //assign the data into the variable members of the object
                    Id = (int)reader["id"];
                    memberId = (int)reader["member_id"];
                    subscriptionType = reader["subscription_type"].ToString();
                    subscriptionAmount = (decimal)reader["subscription_amount"];
                    paidAmount = (decimal)reader["paid_amount"];
                    startDate = (DateTime)reader["start_date"];
                    endDate = reader["end_date"] as DateTime?;
                    CreatedBy = (int)reader["created_by"];
                    CreationDate = (DateTime)reader["creation_date"];
                }
            }
            //close the conneciton
            finally { GymDBConnection.Close(); }
        }

        public override void AddtoDB()
        {
            //Adding new data object to the database
            try
            {
                //prepare insert statement
                string str = @"insert into subscriptions"
            + "(member_id, subscription_type, subscription_amount, paid_amount, start_date, end_date, created_by)"
            + "values (@memberId,@type,@subscriptionAmount,@paidAmount,@startDate,@endDate,@createdBy)";

                //prepare SQL command
                SqlCommand comm = new SqlCommand(str, GymDBConnection);

                //Add parameters to the command (to avoid SQL Injuction
                comm.Parameters.AddWithValue("@memberId", MemberId);
                comm.Parameters.AddWithValue("@type", SubscriptionType);
                comm.Parameters.AddWithValue("@subscriptionAmount", SubscriptionAmount);
                comm.Parameters.AddWithValue("@paidAmount", PaidAmount);
                comm.Parameters.AddWithValue("@startDate", StartDate);
                comm.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@createdBy", CreatedBy);

                //Open the database connection
                GymDBConnection.Open();

                //execute the insert statement
                comm.ExecuteNonQuery();
            }
            //close the connection
            finally { GymDBConnection.Close(); }
        }

        public override void updateInDB()
        {
            //Edit an object data in the database
            try
            {
                //prepare update statement
                string str = "update subscriptions set"
                    + "member_id=@memberId,subscription_type=@type,subscription_amount=@subscriptionAmount,"
                    + "paid_amount=@paidAmount,start_date=@startDate,end_date=@endDate where id=@id";

                //prepare SQL command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //Add parameters to the command (to avoid SQL Injuction
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@memberId", MemberId);
                cmd.Parameters.AddWithValue("@type", SubscriptionType);
                cmd.Parameters.AddWithValue("@subscriptionAmount", SubscriptionAmount);
                cmd.Parameters.AddWithValue("@paidAmount", PaidAmount);
                cmd.Parameters.AddWithValue("@startDate", StartDate);
                cmd.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);

                //Open the database connection
                GymDBConnection.Open();
                
                //execute the update statement
                cmd.ExecuteNonQuery();
            }
            //close the connection
            finally { GymDBConnection.Close(); }
        }

        public static List<Subscription> ListData(int? memberIdFilter)
        {
            //prepare the list
            List<Subscription> list = new List<Subscription>();

            //prepare the select statement
            string str = "select * from subscriptions";

            //check if member filter parameter exists
            if (memberIdFilter.HasValue)
                str += " where member_id = @memberId";

            //prepare SQL command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            comm.Parameters.AddWithValue("@memberId", (object)memberIdFilter ?? DBNull.Value);

            try
            {
                //open the connection
                GymDBConnection.Open();

                //execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    //create new Subscriptions object
                    Subscription s = new Subscription();

                    //assign read data to the object
                    s.Id = (int)reader["id"];
                    s.memberId = (int)reader["member_id"];
                    s.subscriptionType = reader["subscription_type"].ToString();
                    s.subscriptionAmount = (decimal)reader["subscription_amount"];
                    s.paidAmount = (decimal)reader["paid_amount"];
                    s.startDate = (DateTime)reader["start_date"];
                    s.endDate = reader["end_date"] as DateTime?;
                    s.CreatedBy = (int)reader["created_by"];
                    s.CreationDate = (DateTime)reader["creation_date"];

                    //add the object to the list
                    list.Add(s);
                }
            }
            //close the connection
            finally { GymDBConnection.Close(); }

            //return list
            return list;
        }
    }
}