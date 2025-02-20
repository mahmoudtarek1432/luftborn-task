using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public class RoleConstants
    {
        public static string ADMIN = "ADMIN";
        public static string USER = "USER";

        public static List<string> Roles = new List<string> { ADMIN, USER };
    }
}
