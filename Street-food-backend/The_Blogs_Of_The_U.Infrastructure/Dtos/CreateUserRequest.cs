using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class CreateUserRequest
    {
        public Users users { get; set; }
        public UserAcces UserAcces { get; set; }
    }
}
