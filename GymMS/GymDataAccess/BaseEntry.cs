    using System;
using System.Data.SqlClient;
using System.Reflection;
namespace GymDataAccess
{
    public abstract class BaseEntity : IEntity
    {
        //SQL connection
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Assembly.GetExecutingAssembly() +"\\GymDB.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection GymDBConnection = new SqlConnection(connectionString);

        //Shared variable members
        protected int id;
       protected int createdBy;
        protected DateTime creationDate;

        public int Id { get { return id; }set { id = value; } }
        public Users CreatedBy { get { return new Users(createdBy); } }
        public DateTime CreationDate { get { return creationDate; } }

        public BaseEntity()
        {
            
        }

        public abstract void LoadById(int id);
        public abstract void AddToDB(int userId);
        public abstract void UpdateInDB();
    }
}