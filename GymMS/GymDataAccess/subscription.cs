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
        int subscriptionType;
        int subscriptionAmount;
        int paidAmount;
        DateTime startDate;
        DateTime endDate;

        // Properties
        public Member Member { get { return new Member(memberId); } }
        public int SubscriptionType { get { return subscriptionType; } }
        public int SubscriptionAmount { get { return subscriptionAmount; } }
        public int PaidAmount { get { return paidAmount; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }

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
                    id = (int)reader["id"];
                    memberId = (int)reader["member_id"];
                    subscriptionType = (int)reader["subscription_type"];
                    subscriptionAmount = (int)reader["subscription_amount"];
                    paidAmount = (int)reader["paid_amount"];
                    startDate = (DateTime)reader["start_date"];
                    endDate = (DateTime)reader["end_date"];
                    createdBy = (int)reader["created_by"];
                    creationDate = (DateTime)reader["creation_date"];
                }
            }
            //close the conneciton
            finally { GymDBConnection.Close(); }
        }

        public override void AddToDB()
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
                comm.Parameters.AddWithValue("@memberId", memberId);
                comm.Parameters.AddWithValue("@type", subscriptionType);
                comm.Parameters.AddWithValue("@subscriptionAmount", subscriptionAmount);
                comm.Parameters.AddWithValue("@paidAmount", paidAmount);
                comm.Parameters.AddWithValue("@startDate", startDate);
                comm.Parameters.AddWithValue("@endDate", endDate);
                comm.Parameters.AddWithValue("@createdBy", CreatedBy);

                //Open the database connection
                GymDBConnection.Open();

                //execute the insert statement
                comm.ExecuteNonQuery();
            }
            //close the connection
            finally { GymDBConnection.Close(); }
        }

        public override void UpdateInDB()
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
                cmd.Parameters.AddWithValue("@memberId", memberId);
                cmd.Parameters.AddWithValue("@type", subscriptionType);
                cmd.Parameters.AddWithValue("@subscriptionAmount", subscriptionAmount);
                cmd.Parameters.AddWithValue("@paidAmount", paidAmount);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                //Open the database connection
                GymDBConnection.Open();

                //execute the update statement
                cmd.ExecuteNonQuery();
            }
            //close the connection
            finally { GymDBConnection.Close(); }
        }

        public static List<Subscription> ListData(int? memberId, int? typeId, DateTime? fromDate, DateTime? toDate)
        {
            //prepare the list
            List<Subscription> list = new List<Subscription>();

            //prepare the select statement
            string str = "select * from subscriptions "
                + "where member_id = @memberId"
                + " and subscription_type = @TypeId"
                + " and (subscription_date >= @fromDate or @fromDate is null)"
                + " and (subscription_date <= @toDate or @toDate is null)";

            //prepare SQL command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            comm.Parameters.AddWithValue("@memberId", (object)memberId ?? DBNull.Value);
            comm.Parameters.AddWithValue("@TypeId", (object)typeId ?? DBNull.Value);
            comm.Parameters.AddWithValue("@fromDate", (object)fromDate ?? DBNull.Value);
            comm.Parameters.AddWithValue("@toDate", (object)toDate ?? DBNull.Value);

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
                    s.id = (int)reader["id"];
                    s.memberId = (int)reader["member_id"];
                    s.subscriptionType = (int)reader["subscription_type"];
                    s.subscriptionAmount = (int)reader["subscription_amount"];
                    s.paidAmount = (int)reader["paid_amount"];
                    s.startDate = (DateTime)reader["start_date"];
                    s.endDate = (DateTime)reader["end_date"];
                    s.createdBy = (int)reader["created_by"];
                    s.creationDate = (DateTime)reader["creation_date"];

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