using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string DOCUMENT { get; set; }
        public bool STATUS { get; set; }
        public int ROLE_ID { get; set; }
        public int USER_ACCESS_ID { get; set; }
    }
}
