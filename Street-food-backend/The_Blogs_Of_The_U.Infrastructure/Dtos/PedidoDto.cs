using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class PedidoDto
    {
        public int ID { get; set; }
        public int CLIENTE_ID { get; set; }
        public DateTime FECHA_HORA { get; set; }
        public string ESTADO { get; set; }
        public decimal TOTAL { get; set; }
        public int? COCINERO_ID { get; set; }
        public int? DOMICILIARIO_ID { get; set; }
        public string INSTRUCCIONES { get; set; }
    }

}
