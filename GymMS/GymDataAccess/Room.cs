using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GymDataAccess
{
    //Room class inherits from BaseEntity
    public class Room : BaseEntity
    {
        //variable members
        string roomName;
        int capacity;

        //Properties for Encapsulation
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        //constructors

        //for new objects
        public Room() { }

        //for existing data
        public Room(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            try
            {
                //prepare select statement
                SqlCommand cmd = new SqlCommand("select * from rooms where id=@id", GymDBConnection);

                //add parameter value
                cmd.Parameters.AddWithValue("@id", id);

                //open connection
                GymDBConnection.Open();

                //execute select statement
                SqlDataReader datareader = cmd.ExecuteReader();

                //if data exists read it
                if (datareader.Read())
                {
                    //assign data into object
                    this.id = (int)datareader["id"];
                    roomName = datareader["room_name"].ToString();
                    capacity = (int)datareader["capacity"];
                    createdBy = (int)datareader["created_by"];
                    creationDate = (DateTime)datareader["creation_date"];
                }
            }
            //any exception throw it to upper level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override void AddToDB(int userId)
        {
            try
            {
                //prepare insert statement
                string str = "insert into rooms (room_name, capacity, created_by)"
                    + " values(@name, @capacity, @createdBy)";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters values
                cmd.Parameters.AddWithValue("@name", roomName);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@createdBy", userId);

                //open connection
                GymDBConnection.Open();

                //execute insert statement
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to upper level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override void UpdateInDB()
        {
            try
            {
                //prepare update statement
                string str = "update rooms set room_name=@name, capacity=@capacity where id=@id";

                //prepare command
                SqlCommand cmd = new SqlCommand(str, GymDBConnection);

                //add parameters values
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", roomName);
                cmd.Parameters.AddWithValue("@capacity", capacity);

                //open connection
                GymDBConnection.Open();

                //execute update statement
                cmd.ExecuteNonQuery();
            }
            //any exception throw it to upper level
            catch (Exception ex) { throw ex; }

            //close connection
            finally { GymDBConnection.Close(); }
        }

        public override string ToString()
        {
            //overridded method to display room name
            return this.RoomName;
        }
    }
}