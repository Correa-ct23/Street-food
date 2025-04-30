using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Blogs_Of_The_U.Infrastructure.Dtos
{
    public class PagoDto
    {
        public int ID { get; set; }
        public int PEDIDO_ID { get; set; }
        public int METODO_PAGO_ID { get; set; }
        public decimal MONTO { get; set; }
        public DateTime FECHA_PAGO { get; set; }
        public string ESTADO { get; set; }
        public string TRANSACCION_ID { get; set; }
    }
}
