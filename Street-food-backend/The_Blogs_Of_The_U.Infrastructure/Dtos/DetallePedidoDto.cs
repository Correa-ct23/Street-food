using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class DetallePedidoDto
    {
        public int ID { get; set; }
        public int PEDIDO_ID { get; set; }
        public int PRODUCTO_ID { get; set; }
        public int CANTIDAD { get; set; }
        public decimal PRECIO_UNITARIO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public string OBSERVACIONES { get; set; }
    }
}
