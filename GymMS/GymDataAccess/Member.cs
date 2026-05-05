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
            SqlCommand comm = new SqlCommand("select * from members where id=" + id, GymDBConnection);

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
            VALUES (@name,@phone,@birthDate,@startDate,@createdBy,@endDate)", GymDBConnection);

                comm.Parameters.AddWithValue("@name", FullName);
                comm.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                comm.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                comm.Parameters.AddWithValue("@startDate", StartDate);
                comm.Parameters.AddWithValue("@createdBy", CreatedBy);
                comm.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);

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
                SqlCommand cmd = new SqlCommand(@"update members set
            full_name=@name, phone_pumber=@phone, birth_date=@birthDate,
            start_date=@startDate, end_date=@endDate
            where id=@id", GymDBConnection);

                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", FullName);
                cmd.Parameters.AddWithValue("@phone", (object)PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@birthDate", (object)BirthDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@startDate", StartDate);
                cmd.Parameters.AddWithValue("@endDate", (object)EndDate ?? DBNull.Value);

                GymDBConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { GymDBConnection.Close(); }
        }

        public static List<Member> ListData(string filter)
        {
            List<Member> list = new List<Member>();
            string str = "select * from members";
            if ((filter != null) && (filter != ""))
                str += "where fullname like '%' + @filter + '%'";
            SqlCommand comm = new SqlCommand(str, GymDBConnection);

            comm.Parameters.AddWithValue("@filter",
                string.IsNullOrEmpty(filter) ? (object)DBNull.Value : filter);

            try
            {
                GymDBConnection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Member m = new Member();

                    m.Id = (int)reader["id"];
                    m.FullName= reader["full_name"].ToString();
                    m.PhoneNumber = reader["phone_number"].ToString();
                    m.BirthDate = (DateTime)reader["birth_date"];
                    m.startDate = (DateTime)reader["start_date"];
                    m.endDate = reader["end_date"] as DateTime?;
                    m.CreatedBy = (int)reader["created_by"];
                    m.CreationDate = (DateTime)reader["creation_date"];

                    list.Add(m);
                }
            }
            finally { GymDBConnection.Close(); }

            return list;
        }
    }
}