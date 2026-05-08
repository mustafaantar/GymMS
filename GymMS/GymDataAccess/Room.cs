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
                SqlCommand cmd = new SqlCommand("select * from rooms where id=@id", GymDBConnection);
                cmd.Parameters.AddWithValue("@id", id);

                GymDBConnection.Open();
                SqlDataReader datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    id = (int)datareader["id"];
                    roomName = datareader["room_name"].ToString();
                    capacity = (int)datareader["capacity"];
                    createdBy = (int)datareader["created_by"];
                    creationDate = (DateTime)datareader["creation_date"];
                }
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public override void AddToDB(int userId)
        {
            try
            {
                string str = "insert into rooms (room_name, capacity, created_by)"
                    + "values(@name, @capacity, @createdBy)";
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                cmd.Parameters.AddWithValue("@name", roomName);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@createdBy", userId);

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
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", roomName);
                cmd.Parameters.AddWithValue("@capacity", capacity);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public override string ToString()
        {
            return this.RoomName;
        }
    }
}