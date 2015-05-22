using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARWEN.DTO.Database;

namespace ARWEN.Class
{
    public class GlobalUser
    {
        public static int UserID = -1;
        public static string FullName = "";
        public static string UserName = "";
        public static string Password = "";
        public static byte PermissionID = 0;

    }
    public class GlobalCustomer
    {
        public static int CustomerID = -1;
        public static string FullName = "";
        public static bool Choosed = false;
        
    }

}
