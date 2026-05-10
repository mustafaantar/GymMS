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
        public Member Member { get { return new Member(memberId); } set { memberId = value.Id; } }
        public int SubscriptionType { get { return subscriptionType; } set { subscriptionType = value; } }
        public int SubscriptionAmount { get { return subscriptionAmount; } set { subscriptionAmount = value; } }
        public int PaidAmount { get { return paidAmount; } set { paidAmount = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }

        //constructors
        public Subscription() { }

        public Subscription(int id)
        {
            LoadById(id);
        }

        //copy constructor
        public Subscription(Subscription subscription)
        {
            this.id = subscription.id;
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            //Load object data from the database
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            { //prepare select statement
                string str = "select * from subscriptions where id=@id";

            //prepare SQL statement
            SqlCommand comm = new SqlCommand(str, con);

            //Add parameters to the command (to avoid SQL Injuction
            comm.Parameters.AddWithValue("@id", id);

           
                //open the connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
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

        public override void AddToDB(int userId)
        {
            //Adding new data object to the database
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //prepare insert statement
                string str = @"insert into subscriptions"
            + "(member_id, subscription_type, subscription_amount, paid_amount, start_date, end_date, created_by)"
            + "values (@memberId,@type,@subscriptionAmount,@paidAmount,@startDate,@endDate,@createdBy)";

                //prepare SQL command
                SqlCommand comm = new SqlCommand(str, con);

                //Add parameters to the command (to avoid SQL Injuction
                comm.Parameters.AddWithValue("@memberId", memberId);
                comm.Parameters.AddWithValue("@type", subscriptionType);
                comm.Parameters.AddWithValue("@subscriptionAmount", subscriptionAmount);
                comm.Parameters.AddWithValue("@paidAmount", paidAmount);
                comm.Parameters.AddWithValue("@startDate", startDate);
                comm.Parameters.AddWithValue("@endDate", endDate);
                comm.Parameters.AddWithValue("@createdBy", userId);

                //Open the database connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
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
            //prepare connection
            SqlConnection con = GymDBConnection;
            try
            {
                //prepare update statement
                string str = "update subscriptions set"
                    + "member_id=@memberId,subscription_type=@type,subscription_amount=@subscriptionAmount,"
                    + "paid_amount=@paidAmount,start_date=@startDate,end_date=@endDate where id=@id";

                //prepare SQL command
                SqlCommand cmd = new SqlCommand(str, con);

                //Add parameters to the command (to avoid SQL Injuction
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@memberId", memberId);
                cmd.Parameters.AddWithValue("@type", subscriptionType);
                cmd.Parameters.AddWithValue("@subscriptionAmount", subscriptionAmount);
                cmd.Parameters.AddWithValue("@paidAmount", paidAmount);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                //Open the database connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    GymDBConnection.Open();

                //execute the update statement
                cmd.ExecuteNonQuery();
            }
            //close the connection
            finally { GymDBConnection.Close(); }
        }

        public static List<Subscription> ListData(int? memberId, int? typeId, DateTime? fromDate, DateTime? toDate)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            //prepare the list
            List<Subscription> list = new List<Subscription>();

            try
            {
                //prepare the select statement
                string str = "select * from subscriptions "
                + "where member_id = @memberId"
                + " and subscription_type = @TypeId"
                + " and (subscription_date >= @fromDate or @fromDate is null)"
                + " and (subscription_date <= @toDate or @toDate is null)";

            //prepare SQL command
            SqlCommand comm = new SqlCommand(str, con);

            comm.Parameters.AddWithValue("@memberId", (object)memberId ?? DBNull.Value);
            comm.Parameters.AddWithValue("@TypeId", (object)typeId ?? DBNull.Value);
            comm.Parameters.AddWithValue("@fromDate", (object)fromDate ?? DBNull.Value);
            comm.Parameters.AddWithValue("@toDate", (object)toDate ?? DBNull.Value);


                //open the connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
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

        public override string ToString()
        {
            //overridded method to display subscription No.
            return this.id + "-" + this.Member.FullName;
        }
    }
}