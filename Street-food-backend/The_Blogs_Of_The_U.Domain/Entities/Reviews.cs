using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Domain.Entities
{
    public class Reviews
    {
        public string UserName { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ServiceName { get; set; }
        public string ProviderName { get; set; }
    }
}