using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Enums;

namespace The_Blogs_Of_The_U.Domain.Entities
{
    public class Users
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Document { get; set; }
        public bool Status { get; set; }
        public int RolId { get; set; }
        public int UserAccesId { get; set; }
        public Roles Role { get; set; }
        public UserAcces? Access { get; set; }

    }
}
