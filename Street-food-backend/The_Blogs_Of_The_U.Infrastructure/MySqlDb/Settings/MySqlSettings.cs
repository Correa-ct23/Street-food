using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.MySqlDb.Settings
{
    public class MySqlSettings
    {
        public string server { get; set; }
        public string host { get; set; }
        public string port { get; set; }
        public string db { get; set; }
        public string dbUser { get; set; }
        public string dbPassword { get; set; }
    }
}
