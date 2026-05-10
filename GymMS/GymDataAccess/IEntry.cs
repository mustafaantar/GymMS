
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccess
{
    public interface IEntity
    {
        //Abstruct interface
        //Includes Abstruct methods
        //Load object data by ID (primaryy key) of each table type
        void LoadById(int id);
        //Add data row into a table in the database
        void AddToDB(int userId);

        //Edit object data in a table in the database
        void UpdateInDB();
    }
}