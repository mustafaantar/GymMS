using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Users : BaseEntity
    {
        // Variable members
        string username;
        string password;
        int userType;
        bool isActive;

        // Properties
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int UserType { get { return UserType; } set { UserType = value; } }
        public bool IsActive { get { return isActive; } }

        public Users() { }

        public Users(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            SqlCommand comm = new SqlCommand("select * from users where id=@id", GymDBConnection);

            comm.Parameters.AddWithValue("@id", id);

            try
            {
                GymDBConnection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    Id = (int)reader["id"];
                    username = reader["username"].ToString();
                    password = reader["password"].ToString();
                    userType = (int)reader["user_type"];
                    isActive = (bool)reader["is_active"];
                    CreatedBy = (int)reader["created_by"];
                    CreationDate = (DateTime)reader["creation_date"];
                }
            }
            finally { GymDBConnection.Close(); }
        }

        //methods
        public override void AddtoDB()
        {
            //method to add data into database
            try
            {
                SqlCommand comm = new SqlCommand(@"insert into users (username, password, user_type, is_active, created_by)
            VALUES (@user,@pass,@name,@active,@createdBy)", GymDBConnection);

                comm.Parameters.AddWithValue("@user", Username);
                comm.Parameters.AddWithValue("@pass", Password);
                comm.Parameters.AddWithValue("@user_type", userType);
                comm.Parameters.AddWithValue("@active", IsActive);
                comm.Parameters.AddWithValue("@createdBy", CreatedBy);

                GymDBConnection.Open();
                comm.ExecuteNonQuery();
            }
            finally { GymDBConnection.Close(); }
        }

        public override void updateInDB()
        {
            //method to edit data into database
            try
            {
                SqlCommand cmd = new SqlCommand(@"update users SET
            username=@username, password=@password, user_type=@user_type, is_active=@active
            where id=@id", GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@user_type", userType);
                cmd.Parameters.AddWithValue("@active", IsActive);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            finally { GymDBConnection.Close(); }
        }

        public static List<Users> ListData(string filter)
        {
            List<Users> list = new List<Users>();
            string str = "select * from users";
            if ((filter != null) && (filter != ""))
                str += "where (username like '%' + @filter + '%' or full_name like '%' + @filter + '%')";
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            comm.Parameters.AddWithValue("@filter",
                string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);

            try
            {
                GymDBConnection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Users u = new Users();

                    u.Id = (int)reader["id"];
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.userType = (int)reader["user_type"];
                    u.isActive = (bool)reader["is_active"];
                    u.CreatedBy = (int)reader["created_by"];
                    u.CreationDate = (DateTime)reader["creation_date"];

                    list.Add(u);
                }
            }
            finally { GymDBConnection.Close(); }

            return list;
        }
        public static Users Login(string username, string password)
        {
            string str = "select * from users where username=@username and password=@password";
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            comm.Parameters.AddWithValue("@username", username);
            comm.Parameters.AddWithValue("@password", password);

            try
            {
                Users u = null;
                GymDBConnection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    u = new Users();
                    u.Id = (int)reader["id"];
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.userType = (int)reader["user_type"];
                    u.isActive = (bool)reader["is_active"];
                    u.CreatedBy = (int)reader["created_by"];
                    u.CreationDate = (DateTime)reader["creation_date"];
                }
                    return u;
            }
            catch (Exception ex) { return null; }
            finally { GymDBConnection.Close(); }
        }
    }
}