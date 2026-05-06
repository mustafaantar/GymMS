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
        int id;
        int createdBy;
        DateTime creationDate;
        public int Id { get { return id; } protected set { id = value; } }
        public int CreatedBy { get { return createdBy; } protected set { createdBy = value; } }
        public DateTime CreationDate { get { return creationDate; } protected set { creationDate = value; } }

        public BaseEntity()
        {
            
        }

        public abstract void LoadById(int id);
        public abstract void AddtoDB();
        public abstract void updateInDB();
    }
}