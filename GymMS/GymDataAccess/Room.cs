using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GymDataAccess
{
    public class Room : BaseEntity
    {
        string roomName { get; set; }
        int capacity { get; set; }
        public string RoomName { get { return roomName; } set { roomName = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public Room() { }

        public Room(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            try
            {
                var cmd = new SqlCommand("select * from rooms where id=@id", GymDBConnection);
                cmd.Parameters.AddWithValue("@id", id);

                GymDBConnection.Open();
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Id = (int)dr["id"];
                    RoomName = dr["room_name"].ToString();
                    Capacity = (int)dr["capacity"];
                    CreatedBy = (int)dr["created_by"];
                    CreationDate = (DateTime)dr["creation_date"];
                }
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public override void AddInDB()
        {
            try
            {
                string str = "INSERT INTO rooms (room_name, capacity, created_by)"
                    + "values(@name, @capacity, @createdBy)";
                var cmd = new SqlCommand(str, GymDBConnection);

                cmd.Parameters.AddWithValue("@name", RoomName);
                cmd.Parameters.AddWithValue("@capacity", Capacity);
                cmd.Parameters.AddWithValue("@createdBy", CreatedBy);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }


        public override void UpdateInDB()
        {
            try
            {
                string str = "update rooms set room_name=@name, capacity=@capacity where id=@id";
                var cmd = new SqlCommand(str, GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", RoomName);
                cmd.Parameters.AddWithValue("@capacity", Capacity);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public static List<Room> ListData(string filter)
        {
            //create empty list
            List<Room> list = new List<Room>();

            //prepare select statement
            string str = "select * from rooms";

            //if filter used add it to select statement
            if ((filter != null) && (filter != ""))
                str += "where room_name like '%' + @filter + '%'";

            //preparing command
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            //add filter to command
            comm.Parameters.AddWithValue("@filter", string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);

            try
            {
                //open connection
                GymDBConnection.Open();

                //Execute select statement
                SqlDataReader reader = comm.ExecuteReader();

                //if data exists read it
                while (reader.Read())
                {
                    Room s = new Room();

                    //Assign data into object
                    s.Id = (int)reader["id"];
                    s.roomName = reader["room_name"].ToString();
                    s.capacity = (int)reader["capacity"];

                    //Add object to list
                    list.Add(s);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
            return list;
        }
    }
}