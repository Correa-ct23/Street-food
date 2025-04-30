using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Entities;

namespace The_Blogs_Of_The_U.Domain.Models
{
    public class UserResponse
    {
        public class ResponseLogin()
        {
            public Users User { get; set; }
            public UserAcces UserAcces { get; set; }
        }

    }
}
