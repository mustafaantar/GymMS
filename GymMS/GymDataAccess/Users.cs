using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymDataAccess
{
    public class Users : BaseEntity//inherits from BaseEntity
    {
        //variable members
        string username;
        string password;
        char userType;
        bool isActive;

        // Properties for Encapsulation
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserType
        {
            get { return userType == 'R' ? "Receiptist" : userType == 'M' ? "Manager" : "Accountant"; }
            set { userType = value[0]; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        //constructors

        //for new objects
        public Users() { }

        //for existing data
        public Users(int id)
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
                SqlCommand comm = new SqlCommand("select * from users where id=@id", con);

                //add parameters to command
                comm.Parameters.AddWithValue("@id", id);


                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                if (reader.Read())
                {
                    //Assign data into object
                    this.id = (int)reader["id"];
                    username = reader["username"].ToString();
                    password = reader["password"].ToString();
                    userType = char.Parse(reader["user_type"].ToString());
                    isActive = (int)reader["is_active"] == 1;
                    createdBy = (int)reader["created_by"];
                    creationDate = (DateTime)reader["creation_date"];
                }
            }
            //close connection
            finally { con.Close(); }
        }

        //methods
        public override void AddToDB(int userId)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            //method to add data into database
            try
            {
                //prepare insert statement
                string str = @"insert into users (username, password, user_type, is_active, created_by)
                               values (@user,@pass,@user_type,@active,@createdBy)";

                //preparing command
                SqlCommand comm = new SqlCommand(str, con);

                //add parameters to command
                comm.Parameters.AddWithValue("@user", username);
                comm.Parameters.AddWithValue("@pass", password);
                comm.Parameters.AddWithValue("@user_type", userType);
                comm.Parameters.AddWithValue("@active", isActive ? 1 : 0);
                comm.Parameters.AddWithValue("@createdBy", userId);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute insert statement
                comm.ExecuteNonQuery();
            }
            //close connection
            finally { con.Close(); }
        }

        public override void UpdateInDB()
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            //method to edit data into database
            try
            {
                //prepare update statement
                string str = @"update users set
                               username=@username, password=@password,
                               user_type=@user_type, is_active=@active
                               where id=@id";

                //preparing command
                SqlCommand cmd = new SqlCommand(str, con);

                //add parameters to command
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@user_type", userType);
                cmd.Parameters.AddWithValue("@active", isActive ? 1 : 0);

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute update statement
                cmd.ExecuteNonQuery();
            }
            //close connection
            finally { con.Close(); }
        }

        public static List<Users> ListData(string filter)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            //create empty list
            List<Users> list = new List<Users>();

            try
            {
                //prepare select statement
                string str = "select * from users where (username like '%' + @filter + '%' or @filter is null)";

                //preparing command
                SqlCommand comm = new SqlCommand(str, con);

                //add filter to command
                comm.Parameters.AddWithValue("@filter", string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);


                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Users u = new Users();

                    //Assign data into object
                    u.id = (int)reader["id"];
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.userType = char.Parse(reader["user_type"].ToString());
                    u.isActive = (int)reader["is_active"] == 1;
                    u.createdBy = (int)reader["created_by"];
                    u.creationDate = (DateTime)reader["creation_date"];

                    //Add object to list
                    list.Add(u);
                }
            }
            //close connection
            finally { con.Close(); }

            //return results
            return list;
        }

        public static Users Login(string username, string password)
        {
            //prepare connection
            SqlConnection con = GymDBConnection;

            try
            {
                //prepare select statement
                string str = "select * from users where username=@username and password=@password";

                //preparing command
                SqlCommand comm = new SqlCommand(str, con);

                //add parameters to command
                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@password", password);


                Users u = null;

                //open connection
                if (GymDBConnection.State != System.Data.ConnectionState.Open)
                    con.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                if (reader.Read())
                {
                    u = new Users();

                    //Assign data into object
                    u.id = (int)reader["id"];
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.userType = char.Parse(reader["user_type"].ToString());
                    u.isActive = (int)reader["is_active"] == 1;
                    u.createdBy = (int)reader["created_by"];
                    u.creationDate = (DateTime)reader["creation_date"];
                }

                return u;
            }
            //any exception throw it to up level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { con.Close(); }
        }

        public override string ToString()
        {
            //overridded method to display user name
            return this.username;
        }
    }
}