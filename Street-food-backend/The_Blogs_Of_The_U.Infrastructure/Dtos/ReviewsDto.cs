using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class ReviewsDto
    {
        public string USERNAME { get; set; }
        public string review_text { get; set; }
        public string rating { get; set; }
        public DateTime review_date { get; set; }
        public string service_name { get; set; }
        public string provider_name { get; set; }
    }
}