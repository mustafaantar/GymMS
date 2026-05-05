using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMS
{
    static class GlobalVariables
    {

        static GymDataAccess.Users loginUser;
        public static GymDataAccess.Users LoginUser { get { return loginUser; } }
       public static void InitailizeLoginUser(GymDataAccess.Users u)
        {
            loginUser = u;
        }
    }
}