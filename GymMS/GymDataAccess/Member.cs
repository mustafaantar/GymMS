using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public class Member : Person
    {
        DateTime startDate;
        DateTime? endDate;
        public DateTime StartDate { get { return startDate; } }
        public DateTime? EndDate { get { return endDate; } }

        public Member() { }

        public Member(int id)
        {
            LoadById(id);
        }

        public override void LoadById(int id)
        {
            SqlCommand comm = new SqlCommand("SELECT * FROM members WHERE id=" + id, GymDBConnection);

            GymDBConnection.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {

                Id = (int)reader["id"];
                FullName = reader["full_name"].ToString();
                PhoneNumber = reader["phone_pumber"].ToString();
                BirthDate = reader["birth_date"] as DateTime?;
                startDate = (DateTime)reader["start_date"];
                endDate = reader["end_date"] as DateTime?;
                CreatedBy = (int)reader["created_by"];
                CreationDate = (DateTime)reader["creation_date"];
            }
        }

        public override void AddtoDB()
        {
            try
            {
                SqlCommand comm = new SqlCommand(@"insert into members 
            (full_name, phone_pumber, birth_date, start_date, created_by, end_date)
            VALUES (@n,@p,@b,@s,@c,@e)", GymDBConnection);

                comm.Parameters.AddWithValue("@n", FullName);
                comm.Parameters.AddWithValue("@p", (object)PhoneNumber ?? DBNull.Value);
                comm.Parameters.AddWithValue("@b", (object)BirthDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@s", StartDate);
                comm.Parameters.AddWithValue("@c", CreatedBy);
                comm.Parameters.AddWithValue("@e", (object)EndDate ?? DBNull.Value);

                GymDBConnection.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public override void UpdateInDB()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE members SET
            full_name=@n, phone_pumber=@p, birth_date=@b,
            start_date=@s, end_date=@e
            WHERE id=@id", GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@n", FullName);
                cmd.Parameters.AddWithValue("@p", (object)PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@b", (object)BirthDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@s", StartDate);
                cmd.Parameters.AddWithValue("@e", (object)EndDate ?? DBNull.Value);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }
    }
}